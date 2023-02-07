using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SindaSoft.XamppMultihost
{
    public class HostsFile
    {
        public string hostsFilename = null;
        private List<string> hostsLines;
        private int start;
        private int end;

        public HostsFile()
        { 
            if(string.IsNullOrEmpty(hostsFilename))
            { 
                hostsFilename = Path.Combine(
                        Environment.GetEnvironmentVariable("windir"),
                        @"System32\drivers\etc\hosts"
                );
                ReloadHosts();
            }
        }

        public void ReloadHosts()
        { 
            hostsLines = File.ReadAllLines(hostsFilename).ToList();
            start = hostsLines.IndexOf("#xampp-multihost start");
            end = hostsLines.IndexOf("#xampp-multihost end");
            if(start == -1)
            { 
                hostsLines.Add("");
                hostsLines.Add("#xampp-multihost start");
                hostsLines.Add("#xampp-multihost end");
                start = hostsLines.IndexOf("#xampp-multihost start");
                end = start + 1;

                File.WriteAllLines(hostsFilename, hostsLines.ToArray());
            }
        }

        public string GetAddress(string hostName, bool findAll=true)
        { 
            string line = hostsLines.FirstOrDefault( x => x.Trim().EndsWith(hostName) && !x.Trim().StartsWith("#"));
            if(line != null)
            { 
                int idx = hostsLines.IndexOf(line);
                if ( findAll || (idx > start && idx < end))
                {
                    string[] items = line.Trim().Split(new char[] {' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if(items.Length == 2)
                        return items[0];
                }
            }
            return null;
        }

        public bool DeleteAddress(string hostName, bool findAll=false)
        { 
            string line = hostsLines.FirstOrDefault( x => x.Trim().EndsWith(hostName) && !x.Trim().StartsWith("#"));
            if(line != null)
            { 
                int idx = hostsLines.IndexOf(line);
                if ( findAll || (idx > start && idx < end))
                {
                    hostsLines.RemoveAt(idx);
                    end--;
                    File.WriteAllLines(hostsFilename, hostsLines.ToArray());
                    return true;
                }
            }
            return false;
        }

        public bool AddAddress(string hostName, string ipAddress="127.0.0.1")
        { 
            if(GetAddress(hostName) == null)
            { 
                string line = ipAddress + " " + hostName;
                hostsLines.Insert(start+1, line);
                end++;
                File.WriteAllLines(hostsFilename, hostsLines.ToArray());
                return true;
            }
            return false;
        }

    }
}
