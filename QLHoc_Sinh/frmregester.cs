using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace QLHoc_Sinh
{
    public partial class frmregester : Form
    {
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "1fvtVeQfktUOQA3zbwWjUv0VpLxCjOGOWAsP1kcz",
            BasePath = "https://qlhocsinh-ce430-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmregester()
        {
            InitializeComponent();
        }

        private void frmregester_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client != null)
                {
                }
            }
            catch
            {
                MessageBox.Show("Connection Fail.");
            }
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuse.Text) || string.IsNullOrEmpty(txtpass.Text) || string.IsNullOrEmpty(txtid.Text))
            {
                //check if textbox is empty
                MessageBox.Show("Please specify all data needed!");
            }
            else
            {
                var register = new register
                {
                    username = txtuse.Text,
                    password = txtpass.Text,
                    id = txtid.Text
                };
                FirebaseResponse response = client.Set("Users/" + txtid.Text, register);
                register res = response.ResultAs<register>();
                MessageBox.Show("Register account successfully!");
                frmlogin f1 = new frmlogin();
                f1.Show();
                this.Hide();
                txtid.Text = string.Empty;
                txtuse.Text = string.Empty;
                txtpass.Text = string.Empty;
            }
        }
        private void id_leave(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("Users/");
            Dictionary<string, register> getSameId = response.ResultAs<Dictionary<string, register>>();
            foreach (var sameID in getSameId)
            {
                string getsame = sameID.Value.id;
                if (txtid.Text == getsame)
                {
                    MessageBox.Show("ID is already taken");
                    txtid.Text = string.Empty;
                    break;
                }
            }
        }
    }
}
