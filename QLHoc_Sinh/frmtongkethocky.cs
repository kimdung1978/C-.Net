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
    public partial class frmtongkethocky : Form
    {
        // kết nối cơ sở dữ liệu trên firebase
        IFirebaseConfig cofig = new FirebaseConfig
        {
            AuthSecret = "1fvtVeQfktUOQA3zbwWjUv0VpLxCjOGOWAsP1kcz",
            BasePath = "https://qlhocsinh-ce430-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmtongkethocky()
        {
            InitializeComponent();
        }

        private void frmtongkethocky_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(cofig);
                if (client != null)
                {
                    MessageBox.Show("Connection successfull");
                }
            }
            catch
            {
                MessageBox.Show("Connection Fail.");
            }
            loadstudents();
        }
        private void lammoi()
        {
            txthocky.Text = "";
            txtlop.Text = "";
            txtsiso.Text = "";
            txtsldat.Text = "";
            txttile.Text = "";
            txthocky.Focus();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            tongkethk stud = new tongkethk()
            {
                HocKy = txthocky.Text,
                Lop = txtlop.Text,
                SiSo = txtsiso.Text,
                SLDat = txtsldat.Text,
                TiLe = txttile.Text,
            };
            FirebaseResponse response = client.Set("tongkethk/" + txthocky.Text, stud);
            MessageBox.Show("Save Success");
            lammoi();
        }
        public void loadstudents()
        {
            try
            {
                FirebaseResponse response = client.Get("tongkethk/");
                Dictionary<string, tongkethk> getbangdiemmon = response.ResultAs<Dictionary<string, tongkethk>>();
                foreach (var get in getbangdiemmon)
                {
                    dgvhoso.Rows.Add(
                    get.Value.HocKy,
                    get.Value.Lop,
                    get.Value.SiSo,
                    get.Value.SLDat,
                    get.Value.TiLe
                    );


                }
            }
            catch
            {
                MessageBox.Show("No data Stored");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dgvhoso.DataSource = null;
            dgvhoso.Rows.Clear();
            loadstudents();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("tongkethk/" + txthocky.Text);
            tongkethk studs = response.ResultAs<tongkethk>();
            if (txthocky.Text.Equals(studs.HocKy))
            {
                txthocky.Text = studs.HocKy;
                txtlop.Text = studs.Lop;
                txtsiso.Text = studs.SiSo;
                txtsldat.Text = studs.SLDat;
                txttile.Text = studs.TiLe;
                MessageBox.Show("Data Found.");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            var stud = new tongkethk
            {
                HocKy = txthocky.Text,
                Lop = txtlop.Text,
                SiSo = txtsiso.Text,
                SLDat = txtsldat.Text,
                TiLe = txttile.Text,
            };
            FirebaseResponse response = client.Update("tongkethk/" + txthocky.Text, stud);
            MessageBox.Show("Data Updated Success");
            txthocky.Text = string.Empty;
            txtlop.Text = string.Empty;
            txtsiso.Text = string.Empty;
            txtsldat.Text = string.Empty;
            txttile.Text = string.Empty;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Delete("tongkethk/" + txthocky.Text);
            MessageBox.Show("Delete Success");
            txthocky.Text = string.Empty;
            txtlop.Text = string.Empty;
            txtsiso.Text = string.Empty;
            txtsldat.Text = string.Empty;
            txttile.Text = string.Empty;
            lammoi();
        }
    }
}
