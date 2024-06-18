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
    public partial class frmdanhsachhocsinh : Form
    {
        // kết nối cơ sở dữ liệu trên firebase
        IFirebaseConfig cofig = new FirebaseConfig
        {
            AuthSecret = "1fvtVeQfktUOQA3zbwWjUv0VpLxCjOGOWAsP1kcz",
            BasePath = "https://qlhocsinh-ce430-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public frmdanhsachhocsinh()
        {
            InitializeComponent();
        }

        private void frmdanhsachhocsinh_Load(object sender, EventArgs e)
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
            txtmahs.Text = "";
            txthoten.Text = "";
            txtlop.Text = "";
            txttbhk1.Text = "";
            txttbhk2.Text = "";
            txtmahs.Focus();
        }
        public void loadstudents()
        {
            try
            {
                FirebaseResponse response = client.Get("DsHocSinh/");
                Dictionary<string, dshocsinh> getdshocsinh = response.ResultAs<Dictionary<string, dshocsinh>>();
                foreach (var get in getdshocsinh)
                {
                    dgvhoso.Rows.Add(
                    get.Value.MaHs,
                    get.Value.HoVaTen,
                    get.Value.Lop,
                    get.Value.TBhk1,
                    get.Value.TBhk2
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
            dshocsinh stud = new dshocsinh()
            {
                MaHs = txtmahs.Text,
                HoVaTen = txthoten.Text,
                Lop = txtlop.Text,
                TBhk1 = txttbhk1.Text,
                TBhk2 = txttbhk2.Text,
            };
            FirebaseResponse response = client.Set("DsHocSinh/" + txtmahs.Text, stud);
            MessageBox.Show("Save Success");
            lammoi();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("DsHocSinh/" + txtmahs.Text);
            dshocsinh studs = response.ResultAs<dshocsinh>();
            if (txtmahs.Text.Equals(studs.MaHs))
            {
                txthoten.Text = studs.HoVaTen;
                txtlop.Text = studs.Lop;
                txttbhk1.Text = studs.TBhk1;
                txttbhk2.Text = studs.TBhk2;
                MessageBox.Show("Data Found.");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            var stud = new dshocsinh
            {
                MaHs = txtmahs.Text,
                HoVaTen = txthoten.Text,
                Lop = txtlop.Text,
                TBhk1 = txttbhk1.Text,
                TBhk2 = txttbhk2.Text,
            };
            FirebaseResponse response = client.Update("DsHocSinh/" + txtmahs.Text, stud);
            MessageBox.Show("Data Updated Success");
            txtmahs.Text = string.Empty;
            txthoten.Text = string.Empty;
            txtlop.Text = string.Empty;
            txttbhk1.Text = string.Empty;
            txttbhk2.Text = string.Empty;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Delete("DsHocSinh/" + txtmahs.Text);
            MessageBox.Show("Delete Success");
            txtmahs.Text = string.Empty;
            txthoten.Text = string.Empty;
            txtlop.Text = string.Empty;
            txttbhk1.Text = string.Empty;
            txttbhk2.Text = string.Empty;
            lammoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvhoso.DataSource = null;
            dgvhoso.Rows.Clear();
            loadstudents();
        }
    }
}
