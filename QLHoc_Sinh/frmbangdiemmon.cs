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
    public partial class frmbangdiemmon : Form
    {
        // kết nối cơ sở dữ liệu trên firebase
        IFirebaseConfig cofig = new FirebaseConfig
        {
            AuthSecret = "1fvtVeQfktUOQA3zbwWjUv0VpLxCjOGOWAsP1kcz",
            BasePath = "https://qlhocsinh-ce430-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmbangdiemmon()
        {
            InitializeComponent();
        }

        private void frmbangdiemmon_Load(object sender, EventArgs e)
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
            txtlop.Text = "";
            txtmon.Text = "";
            txthocky.Text = "";
            txtmahs.Text = "";
            txthoten.Text = "";
            txtdiem15.Text = "";
            txt1tiet.Text = "";
            txtTB.Text = "";
            txtlop.Focus();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            bangdiemmon stud = new bangdiemmon()
            {
                Lop = txtlop.Text,
                Mon = txtmon.Text,
                HocKy = txthocky.Text,
                MaHS = txtmahs.Text,
                HoTen = txthoten.Text,
                diem15p = txtdiem15.Text,
                diem1tiet = txt1tiet.Text,
                diemTB = txtTB.Text,
            };
            FirebaseResponse response = client.Set("diemmonhoc/" + txtlop.Text, stud);
            MessageBox.Show("Save Success");
            lammoi();
        }
        public void loadstudents()
        {
            try
            {
                FirebaseResponse response = client.Get("diemmonhoc/");
                Dictionary<string, bangdiemmon> getbangdiemmon = response.ResultAs<Dictionary<string, bangdiemmon>>();
                foreach (var get in getbangdiemmon)
                {
                    dgvhoso.Rows.Add(
                    get.Value.Lop,
                    get.Value.Mon,
                    get.Value.HocKy,
                    get.Value.MaHS,
                    get.Value.HoTen,
                    get.Value.diem15p,
                    get.Value.diem1tiet,
                    get.Value.diemTB
                    );


                }
            }
            catch
            {
                MessageBox.Show("No data Stored");
            }

        }
        private void btntim_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("diemmonhoc/" + txtlop.Text);
            bangdiemmon studs = response.ResultAs<bangdiemmon>();
            if (txtlop.Text.Equals(studs.Lop))
            {
                txtlop.Text = studs.Lop;
                txtmon.Text = studs.Mon;
                txthocky.Text = studs.HocKy;
                txtmahs.Text = studs.MaHS;
                txthoten.Text = studs.HoTen;
                txtdiem15.Text = studs.diem15p;
                txt1tiet.Text = studs.diem1tiet;
                txtTB.Text = studs.diemTB;
                MessageBox.Show("Data Found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvhoso.DataSource = null;
            dgvhoso.Rows.Clear();
            loadstudents();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Delete("diemmonhoc/" + txtlop.Text);
            MessageBox.Show("Delete Success");
            txtlop.Text = string.Empty;
            txtmon.Text = string.Empty;
            txthocky.Text = string.Empty;
            txtmahs.Text = string.Empty;
            txthoten.Text = string.Empty;
            txtdiem15.Text = string.Empty;
            txt1tiet.Text = string.Empty;
            txtTB.Text = string.Empty;
            lammoi();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            var stud = new bangdiemmon
            {
                Lop = txtlop.Text,
                Mon = txtmon.Text,
                HocKy = txthocky.Text,
                MaHS = txtmahs.Text,
                HoTen = txthoten.Text,
                diem15p = txtdiem15.Text,
                diem1tiet = txt1tiet.Text,
                diemTB = txtTB.Text,
            };
            FirebaseResponse response = client.Update("DsLop/" + txtlop.Text, stud);
            MessageBox.Show("Data Updated Success");
            txtlop.Text = string.Empty;
            txtmon.Text = string.Empty;
            txthocky.Text = string.Empty;
            txtmahs.Text = string.Empty;
            txthoten.Text = string.Empty;
            txtdiem15.Text = string.Empty;
            txt1tiet.Text = string.Empty;
            txtTB.Text = string.Empty;
        }
    }
}
