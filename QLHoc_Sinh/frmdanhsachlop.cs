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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLHoc_Sinh
{
    public partial class frmdanhsachlop : Form
    {
        // kết nối cơ sở dữ liệu trên firebase
        IFirebaseConfig cofig = new FirebaseConfig
        {
            AuthSecret = "1fvtVeQfktUOQA3zbwWjUv0VpLxCjOGOWAsP1kcz",
            BasePath = "https://qlhocsinh-ce430-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmdanhsachlop()
        {
            InitializeComponent();
        }

        private void frmdanhsachlop_Load(object sender, EventArgs e)
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
            txtsiso.Text = "";
            txtmahs.Text = "";
            txthoten.Text = "";
            cmbgioitinh.Text = "";
            txtnamsinh.Text = "";
            txtdiachi.Text = "";
            txtlop.Focus();
        }
        public void loadstudents()
        {
            try
            {
                FirebaseResponse response = client.Get("DsLop/");
                Dictionary<string, dslop> getdslop = response.ResultAs<Dictionary<string, dslop>>();
                foreach (var get in getdslop)
                {
                    dgvhoso.Rows.Add(
                    get.Value.Lop,
                    get.Value.SiSo,
                    get.Value.MaHS,
                    get.Value.HoVaTen,
                    get.Value.GioiTinh,
                    get.Value.NamSinh,
                    get.Value.DiaChi
                    );
                }
            }
            catch
            {
                MessageBox.Show("No data Stored");
            }

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            dslop stud = new dslop()
            {
                Lop = txtlop.Text,
                SiSo = txtsiso.Text,
                MaHS = txtmahs.Text,
                HoVaTen = txthoten.Text,
                GioiTinh = cmbgioitinh.Text,
                NamSinh = txtnamsinh.Text,
                DiaChi = txtdiachi.Text,
            };
            FirebaseResponse response = client.Set("DsLop/" + txtlop.Text, stud);
            MessageBox.Show("Save Success");
            lammoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvhoso.DataSource = null;
            dgvhoso.Rows.Clear();
            loadstudents();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("DsLop/" + txtlop.Text);
            dslop studs = response.ResultAs<dslop>();
            if (txtlop.Text.Equals(studs.Lop))
            {
                txtsiso.Text = studs.SiSo;
                txtmahs.Text = studs.MaHS;
                txthoten.Text = studs.HoVaTen;
                cmbgioitinh.Text = studs.GioiTinh;
                txtnamsinh.Text = studs.NamSinh;
                txtdiachi.Text = studs.DiaChi;
                MessageBox.Show("Data Found.");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Delete("DsLop/" + txtlop.Text);
            MessageBox.Show("Delete Success");
            txtlop.Text = string.Empty;
            txtsiso.Text = string.Empty;
            txtmahs.Text = string.Empty;
            txthoten.Text = string.Empty;
            cmbgioitinh.Text = string.Empty;
            txtnamsinh.Text = string.Empty;
            txtdiachi.Text = string.Empty;
            lammoi();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            var stud = new dslop
            {
                Lop = txtlop.Text,
                SiSo = txtsiso.Text,
                MaHS = txtmahs.Text,
                HoVaTen = txthoten.Text,
                GioiTinh = cmbgioitinh.Text,
                NamSinh = txtnamsinh.Text,
                DiaChi = txtdiachi.Text,
            };
            FirebaseResponse response = client.Update("DsLop/" + txtlop.Text, stud);
            MessageBox.Show("Data Updated Success");
            txtlop.Text = string.Empty;
            txtsiso.Text = string.Empty;
            txtmahs.Text = string.Empty;
            txthoten.Text = string.Empty;
            cmbgioitinh.Text = string.Empty;
            txtnamsinh.Text = string.Empty;
            txtdiachi.Text = string.Empty;
        }
    }
}
