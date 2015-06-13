using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBusterPOS
{
    public partial class Login : Form
    {        
        public Login()
        {
            InitializeComponent();
        }



        private void ExitButton_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //private hello = new System.Security.Cryptography.SHA512CryptoServiceProvider;
        }
    }
}
