using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SindaSoft.XamppMultihost
{
    public partial class MainForm : Form
    {
        public string xamppDirectory;
        public int apacheVersion;
        public HostsFile hosts;
        public HttpdVhostsFile vHosts;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(xamppDirectory))
            { 
                UriBuilder uri = new UriBuilder(System.Reflection.Assembly.GetEntryAssembly().CodeBase);
                xamppDirectory = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));
            }

            if(!File.Exists(Path.Combine(xamppDirectory,  @"apache\bin\httpd.exe")))
            { 
                MessageBox.Show("Invalid XAMPP directory", this.Text, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            FileVersionInfo fiApache = GetVersionInfoIfExist(Path.Combine(xamppDirectory,  @"apache\bin\httpd.exe"));
            FileVersionInfo fiPhp = GetVersionInfoIfExist(Path.Combine(xamppDirectory,  @"php\php.exe"));
            FileVersionInfo fiMaria = GetVersionInfoIfExist(Path.Combine(xamppDirectory,  @"mysql\bin\mysqld.exe"));

            string databaseName = "MySQL";
            if(File.Exists(Path.Combine(xamppDirectory,  @"mysql\README")))
                databaseName = File.ReadAllText(Path.Combine(xamppDirectory,  @"mysql\README")).Contains("MariaDB") ? "MariaDB" : "MySQL";
            else if(File.Exists(Path.Combine(xamppDirectory,  @"mysql\README.md")))
                databaseName = File.ReadAllText(Path.Combine(xamppDirectory,  @"mysql\README.md")).Contains("MariaDB") ? "MariaDB" : "MySQL";

            apacheVersion = fiApache.FileMajorPart * 100 + fiApache.FileMinorPart;

            lblInfo.Text = "XAMPP located in " + xamppDirectory + "\r\n";
            if(fiApache != null)
                lblInfo.Text += "Apache " + fiApache.FileVersion + " ";
            if(fiPhp != null)
                lblInfo.Text += "PHP " + fiPhp.FileVersion + " ";
            if(fiMaria != null)
                lblInfo.Text += databaseName + " " + fiMaria.FileVersion;

            lbVHosts.DrawMode = DrawMode.OwnerDrawFixed;
            lbVHosts.DrawItem += (sndr, evarg) =>   { 
                                                        if(evarg.Index > -1)
                                                        {
                                                            ListBox lb = sndr as ListBox;
                                                            XamppVirtualHost vh = lb.Items[evarg.Index] as XamppVirtualHost;
                                                            bool adressOK = this.hosts.GetAddress(vh.VHostName) != null;
                                                            Color fgc = adressOK ? Color.Black : Color.Red;
                                                            Brush fg = adressOK ? Brushes.Black : Brushes.Red;

                                                            if ((evarg.State & DrawItemState.Selected) == DrawItemState.Selected)
                                                            {
                                                                fgc = adressOK ? Color.White : Color.Yellow;
                                                                fg = adressOK ? Brushes.White : Brushes.Yellow;

                                                                evarg = new DrawItemEventArgs(evarg.Graphics, 
                                                                                              evarg.Font, 
                                                                                              evarg.Bounds, 
                                                                                              evarg.Index,
                                                                                              evarg.State ^ DrawItemState.Selected,
                                                                                              fgc, 
                                                                                              adressOK ? Color.Black : Color.Red);//Choose the color
                                                            }
                                                            evarg.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                                            evarg.DrawBackground();
                                                            evarg.Graphics.DrawString(  lb.Items[evarg.Index].ToString(),
                                                                                        evarg.Font, 
                                                                                        fg, 
                                                                                        evarg.Bounds, 
                                                                                        StringFormat.GenericDefault);
                                                            //evarg.DrawFocusRectangle();
                                                        }
                                                    };

            hosts = new HostsFile ();
            vHosts = new HttpdVhostsFile (this);
            List<XamppVirtualHost> items = vHosts.LoadVhosts();
            foreach(var x in items)
                lbVHosts.Items.Add(x);
        }

        private FileVersionInfo GetVersionInfoIfExist(string p)
        { 
            return File.Exists(p) ? FileVersionInfo.GetVersionInfo(p) : null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetNameForm f = new GetNameForm ();
            if( f.ShowDialog() == DialogResult.OK )
            { 
                string hn = f.hostname;
                
                if(!vHosts.IsValid(hn))
                { 
                    MessageBox.Show(hn + " is not a valid name", 
                                   this.Text, 
                                   MessageBoxButtons.OK, 
                                   MessageBoxIcon.Error );
                    return;
                }

                if(vHosts.IsDefined(hn))
                { 
                    MessageBox.Show(hn + " is already defined", 
                                   this.Text, 
                                   MessageBoxButtons.OK, 
                                   MessageBoxIcon.Information );
                    return;
                }

                XamppVirtualHost xvh = new XamppVirtualHost (this);
                xvh.VHostName = hn;

                vHosts.AddEntry(xvh);
                hosts.AddAddress(hn);

                List<XamppVirtualHost> items = vHosts.LoadVhosts();
                lbVHosts.Items.Clear();
                foreach(var x in items)
                    lbVHosts.Items.Add(x);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XamppVirtualHost xvh = lbVHosts.SelectedItem as XamppVirtualHost;
            if(xvh != null)
            { 
                if(MessageBox.Show("Delete " + xvh.VHostName + "?", 
                                   this.Text, 
                                   MessageBoxButtons.YesNo, 
                                   MessageBoxIcon.Question ) == DialogResult.Yes)
                { 
                    vHosts.DeleteEntry(xvh);

                    List<XamppVirtualHost> items = vHosts.LoadVhosts();
                    lbVHosts.Items.Clear();
                    foreach(var x in items)
                        lbVHosts.Items.Add(x);

                    if(hosts.GetAddress(xvh.VHostName) != null)
                    { 
                        if(MessageBox.Show("Remove " + xvh.VHostName + " from hosts file?", 
                                           this.Text, 
                                           MessageBoxButtons.YesNo, 
                                           MessageBoxIcon.Question ) == DialogResult.Yes)
                        { 
                            hosts.DeleteAddress(xvh.VHostName);
                        }
                    }
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(lbVHosts.SelectedItem != null)
            { 
                string http = "http://" + lbVHosts.SelectedItem.ToString();
                Process.Start(new ProcessStartInfo { FileName = http,UseShellExecute = true });
            }
            else
                MessageBox.Show("Select item first", this.Text, 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExplore_Click(object sender, EventArgs e)
        {
            XamppVirtualHost xvh = lbVHosts.SelectedItem as XamppVirtualHost;
            if(xvh != null)
            { 
                Process.Start(new ProcessStartInfo { FileName = xvh.HomeDir, UseShellExecute = true });
            }
            else
                MessageBox.Show("Select item first", this.Text, 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditVHosts_Click(object sender, EventArgs e)
        {
            Process pi =  Process.Start("notepad.exe", this.vHosts.vhostsFilename);
            pi.WaitForExit();

            List<XamppVirtualHost> items = vHosts.LoadVhosts();
            lbVHosts.Items.Clear();
            foreach(var x in items)
                lbVHosts.Items.Add(x);

        }

        private void btnEditHosts_Click(object sender, EventArgs e)
        {
            Process pi =  Process.Start("notepad.exe", this.hosts.hostsFilename);
            pi.WaitForExit();

            hosts.ReloadHosts();
            lbVHosts.Invalidate();
            /*
            List<XamppVirtualHost> items = vHosts.LoadVhosts();
            lbVHosts.Items.Clear();
            foreach(var x in items)
                lbVHosts.Items.Add(x);
            */
        }

        private void btnFixHosts_Click(object sender, EventArgs e)
        {
            XamppVirtualHost xvh = lbVHosts.SelectedItem as XamppVirtualHost;

            if(MessageBox.Show("Add " + xvh.VHostName + " to hosts file?", 
                                this.Text, 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question ) == DialogResult.Yes)
            { 
                hosts.AddAddress(xvh.VHostName);

                List<XamppVirtualHost> items = vHosts.LoadVhosts();
                lbVHosts.Items.Clear();
                foreach(var x in items)
                    lbVHosts.Items.Add(x);

            }
        }

        private void lbVHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            XamppVirtualHost xvh = lbVHosts.SelectedItem as XamppVirtualHost;
            if(xvh != null)
                btnFixHosts.Visible = this.hosts.GetAddress(xvh.VHostName) == null;
            else
                btnFixHosts.Visible = false;

        }
    }
}
