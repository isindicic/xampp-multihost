using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SindaSoft.XamppMultihost
{
    public class XamppVirtualHost
    {
        public MainForm parent;

        public string VHostName;

        public string HomeDir  { 
                                get { 
                                        string r = Path.Combine(parent.xamppDirectory, "htdocs." + VHostName);
                                        return r;
                                    } 
                                }

        public string HomeDir4Conf  { 
                                        get { 
                                                string r = this.HomeDir;
                                                r = r.Substring(2).Replace(@"\", "/");
                                                return r;
                                            } 
                                      }



        public XamppVirtualHost(MainForm p)
        { 
            parent = p;
        }

        public override string ToString()
        {
            return this.VHostName;
        }
    }
}
