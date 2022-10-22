using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteamAuth;

namespace Steam_Desktop_Authenticator
{
    public partial class ProxyInputForm : Form
    {
        public Proxy proxy { get; set; }

        public SteamGuardAccount _account { get; set; }

        public ProxyInputForm()
        {
            InitializeComponent();
        }

        public ProxyInputForm(SteamGuardAccount account)
        {
            Console.WriteLine(account.Proxy.ProxyHost);
            InitializeComponent();
            _account = account;
            if (_account.Proxy.ProxyHost != null)
            {
                hostIP_textBox.Text = _account.Proxy.ProxyHost;
                port_textBox.Text = _account.Proxy.ProxyPort.ToString();
                username_textBox.Text = _account.Proxy.ProxyUsername;
                password_textBox.Text = _account.Proxy.ProxyPassword;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hostIP_textBox.Text != null)
            {
                proxy = new Proxy();
                proxy.ProxyHost = hostIP_textBox.Text;
                proxy.ProxyPort = port_textBox.Text;
                proxy.ProxyUsername = username_textBox.Text;
                proxy.ProxyPassword = password_textBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter all the proxy details.");
            }
        }

        private void ProxyInputForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = hostIP_textBox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            proxy = new Proxy();
            proxy.ProxyHost = null;
            proxy.ProxyPort = null;
            proxy.ProxyUsername = null;
            proxy.ProxyPassword = null;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
