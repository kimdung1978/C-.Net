using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHoc_Sinh
{
    public partial class frmchinh : Form
    {
        public frmchinh()
        {
            InitializeComponent();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            frmlogin f = new frmlogin();
            f.Show();
            this.Hide();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Show();
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
        }
        private void frmchinh_Load(object sender, EventArgs e)
        {

        }

        private void hosohocsinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmhosohocsinh());
        }

        private void Danhsachlop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmdanhsachlop());
        }

        private void Danhsachhocsinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmdanhsachhocsinh());
        }

        private void bangdiemmon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmbangdiemmon());
        }

        private void tongketmon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmtongketmon());
        }

        private void tongkethocky_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmtongkethocky());
        }
    }
}
