using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace QLHoc_Sinh
{
    public partial class frmlogin : Form
    {
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "1fvtVeQfktUOQA3zbwWjUv0VpLxCjOGOWAsP1kcz",
            BasePath = "https://qlhocsinh-ce430-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmlogin()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client != null)
                {
                    //this.CenterToScreen();
                    //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                }
            }
            catch
            {
                MessageBox.Show("Connection Fail.");
            }
        }
        public static string usernamepass;

        private void btnsignin_Click(object sender, EventArgs e)
        {
            //login
            if (string.IsNullOrEmpty(txtuse.Text) || string.IsNullOrEmpty(txtpass.Text))
            {
                //check if textbox is empty
                MessageBox.Show("Please put username or password!");
            }
            else
            {
                //looping to get the match data using foreach
                FirebaseResponse response = client.Get("Users");
                Dictionary<string, register> result = response.ResultAs<Dictionary<string, register>>();
                foreach (var get in result)
                {
                    string userresult = get.Value.username;
                    string passresult = get.Value.password;
                    if (txtuse.Text == userresult)
                    {
                        if (txtpass.Text == passresult)
                        {
                            MessageBox.Show("Đăng nhập thành công"+" " + txtuse.Text);
                            usernamepass = txtuse.Text;
                            frmchinh home = new frmchinh();
                            this.Hide();
                            home.Show();
                        }
                    }
                }
            }
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            //Register Form
            frmregester rf = new frmregester();
            this.Hide();
            rf.Show();
        }

        private void ckshow_CheckedChanged(object sender, EventArgs e)
        {
            if (ckshow.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }
    }
}
