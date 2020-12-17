using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bil
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                result = webClient.DownloadString("https://pastebin.com/raw/wHW7Awi4");
                string[] links = result.Split('\n');
                var atom = textBox1.Text;
                if (atom.Contains("=="))
                {
                    var realatom0 = Regex.Split(atom, "==");
                    string name = realatom0[0];
                    string version = realatom0[1];
                    string downloadLink = $"https://github.com/GHGDev-11/{name}/archive/{version}.tar.gz";
                    System.Diagnostics.Process.Start(downloadLink);
                }
                else
                {
                    foreach (string link in links)
                    {
                        if (link.StartsWith($"https://github.com/GHGDev-11/{atom}/archive"))
                        {
                            string downloadLink = link;
                            System.Diagnostics.Process.Start(downloadLink);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}