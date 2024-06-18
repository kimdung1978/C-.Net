using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace QLHoc_Sinh
{
    public partial class frmhosohocsinh : Form
    {
        // kết nối cơ sở dữ liệu trên firebase
        IFirebaseConfig cofig = new FirebaseConfig
        {
            AuthSecret = "1fvtVeQfktUOQA3zbwWjUv0VpLxCjOGOWAsP1kcz",
            BasePath = "https://qlhocsinh-ce430-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public frmhosohocsinh()
        {
            InitializeComponent();
        }

        private void frmhosohocsinh_Load(object sender, EventArgs e)
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
            txtmahoc.Text = "";
            txthoten.Text = "";
            cmbgioitinh.Text = "";
            txtngaysinh.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
            txtmahoc.Focus();
        }
        public void loadstudents()
        {
            try
            {
                FirebaseResponse response = client.Get("HoSoHocSinh/");
                Dictionary<string , hshocsinh>gethshocsinh = response.ResultAs<Dictionary<string , hshocsinh>>();
                foreach (var get in gethshocsinh)
                {
                    dgvhoso.Rows.Add(
                    get.Value.Mahs,
                    get.Value.HoVaTen,
                    get.Value.GioiTinh,
                    get.Value.NgaySinh,
                    get.Value.DiaChi,
                    get.Value.Email
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
            hshocsinh stud = new hshocsinh()
            {
                Mahs = txtmahoc.Text,
                HoVaTen = txthoten.Text,
                GioiTinh = cmbgioitinh.Text,
                NgaySinh = txtngaysinh.Text,
                DiaChi = txtdiachi.Text,
                Email = txtemail.Text,
            };
            FirebaseResponse response = client.Set("HoSoHocSinh/" + txtmahoc.Text, stud);
            MessageBox.Show("Save Success");
            lammoi();
        }

        private void dgvhoso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            var stud = new hshocsinh
            {
                Mahs = txtmahoc.Text,
                HoVaTen = txthoten.Text,
                GioiTinh = cmbgioitinh.Text,
                NgaySinh = txtngaysinh.Text,
                DiaChi = txtdiachi.Text,
                Email = txtemail.Text,
            };
            FirebaseResponse response = client.Update("HoSoHocSinh/" + txtmahoc.Text, stud);
            MessageBox.Show("Data Updated Success");
            txtmahoc.Text = string.Empty;
            txthoten.Text = string.Empty;
            cmbgioitinh.Text = string.Empty;
            txtngaysinh.Text = string.Empty;
            txtdiachi.Text = string.Empty;
            txtemail.Text = string.Empty;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Delete("HoSoHocSinh/" + txtmahoc.Text);
            MessageBox.Show("Delete Success");
            txtmahoc.Text = string.Empty;
            txthoten.Text = string.Empty;
            cmbgioitinh.Text = string.Empty;
            txtngaysinh.Text = string.Empty;
            txtdiachi.Text = string.Empty;
            txtemail.Text = string.Empty;   
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
            FirebaseResponse response = client.Get("HoSoHocSinh/" + txtmahoc.Text);
            hshocsinh studs = response.ResultAs<hshocsinh>();
            if (txtmahoc.Text.Equals(studs.Mahs))
            {
                txthoten.Text = studs.HoVaTen;
                cmbgioitinh.Text = studs.GioiTinh;
                txtngaysinh.Text = studs.NgaySinh;
                txtdiachi.Text = studs.DiaChi;
                txtemail.Text = studs.Email;
                MessageBox.Show("Data Found.");
            }
        }
    }
}
