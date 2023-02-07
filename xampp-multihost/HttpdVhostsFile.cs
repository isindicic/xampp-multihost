using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SindaSoft.XamppMultihost
{
    public class HttpdVhostsFile
    {
        public string vhostsFilename;
        private MainForm parent;
        List<string> vhostsLines ;
        int start;
        int end;

        public HttpdVhostsFile(MainForm parent)
        { 
            this.parent = parent;
            vhostsFilename = Path.Combine(parent.xamppDirectory, @"apache\conf\extra\httpd-vhosts.conf");
        }

        public bool IsValid(string hostName)
        { 
            List<Char> ifc = Path.GetInvalidFileNameChars().ToList();
            for(int i = 0; i < hostName.Length; i++)
            { 
                if(ifc.Contains(hostName[i]))
                    return false;
            }
            return true;
        }

        public bool IsDefined(string hostName)
        { 
            string line = vhostsLines.FirstOrDefault( x => x.Trim().StartsWith("ServerName") && x.Trim().EndsWith(hostName));
            return line != null;
        }

        public List<XamppVirtualHost> LoadVhosts()
        { 
            List<XamppVirtualHost> retval = new List<XamppVirtualHost> ();
            vhostsLines = File.ReadAllLines(vhostsFilename).ToList();
            start = vhostsLines.IndexOf("#xampp-multihost start");
            end = vhostsLines.IndexOf("#xampp-multihost end");
            if(start == -1)
            { 
                vhostsLines.Add("");
                vhostsLines.Add("#xampp-multihost start");
                vhostsLines.Add("#xampp-multihost end");
                start = vhostsLines.IndexOf("#xampp-multihost start");
                end = start + 1;
                File.WriteAllLines(vhostsFilename, vhostsLines.ToArray());
                return retval;
            }

            for(int i = start + 1 ; i < end;  i++ )
            { 
                if(vhostsLines[i].Trim().StartsWith("ServerName"))
                { 
                    XamppVirtualHost x = new XamppVirtualHost(this.parent);
                    x.VHostName = vhostsLines[i].Replace("ServerName", "").Trim();
                    retval.Add(x);
                }
            }
            return retval;
        }

        public void AddEntry(XamppVirtualHost xvh, bool check4dir = true)
        { 
            List<string> entry = new List<string> ();

            entry.Add("<VirtualHost *:80>");
            entry.Add("    ServerName " + xvh.VHostName);
            entry.Add("    DocumentRoot \"" + xvh.HomeDir4Conf  + "\"");
            entry.Add("    <Directory \"" + xvh.HomeDir4Conf + "\">");
            entry.Add("        Options Indexes FollowSymLinks");
            entry.Add("        AllowOverride All");

            if(parent.apacheVersion < 204)
            {
                entry.Add("        Order allow,deny");
                entry.Add("        Allow from all");
            }
            else
                entry.Add("        Require all granted");

            entry.Add("    </Directory>");
            entry.Add("</VirtualHost>");

            vhostsLines.InsertRange(start + 1 , entry);
            end += entry.Count;
            File.WriteAllLines(vhostsFilename, vhostsLines.ToArray());

            if(check4dir)
            { 
                if(!Directory.Exists(xvh.HomeDir))
                { 
                    Directory.CreateDirectory(xvh.HomeDir);
                    File.WriteAllText(Path.Combine(xvh.HomeDir, "index.html"), "<html><h1>Home for '"+xvh.VHostName+"'</h1></html>");
                }
            }
        }

        public bool DeleteEntry(XamppVirtualHost xvh)
        { 
            string anchor = vhostsLines.FirstOrDefault( x => x.Trim().StartsWith("ServerName") && x.Trim().EndsWith(xvh.VHostName));
            if(anchor != null)
            {
                int idx = vhostsLines.IndexOf(anchor);
                int vhStart = -1;
                int vhEnd = -1;
                for(int i = start + 1 ; i < idx;  i++ )
                    if(vhostsLines[i].Trim().StartsWith("<VirtualHost"))
                        vhStart = i;

                if(vhStart != -1)
                { 
                    for(int i = vhStart + 1 ; i < end;  i++ )
                    {
                        if(vhostsLines[i].Trim().StartsWith("</VirtualHost"))
                        {
                            vhEnd = i;
                            break;
                        }
                    }

                    if(vhEnd != -1)
                        vhostsLines.RemoveRange(vhStart, vhEnd - vhStart + 1);

                    end -= vhEnd - vhStart + 1;
                    File.WriteAllLines(vhostsFilename, vhostsLines.ToArray());
                }

                return true;
            }
            return false;
        }
    }
}
