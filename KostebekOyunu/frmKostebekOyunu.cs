using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KostebekOyunu
{
    public partial class frmKostebekOyunu : Form
    {
        public frmKostebekOyunu()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int skor, sure;

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn=sender as Button;
            if (btn.BackgroundImage != null) 
            {
                skor++;
                lblSkor.Text = skor.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            sure--;
            btnSure.Text = sure.ToString();
            int random = rnd.Next(1, 61);
            string btnName = "button" + random;
                       
            foreach (Button item in panelControl1.Controls)
            {
                if (item.Name != btnName) item.BackgroundImage = null;
                else item.BackgroundImage = Image.FromFile("C:\\Users\\hp\\OneDrive\\Resimler\\İconlar\\kostebek.jpg");
            }
            if (sure == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Süreniz dolmuştur. \nSKOR: " + skor, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                skor = 0;
                lblSkor.Text = skor.ToString();
                sure = 59;
                btnSure.Text = sure.ToString();
                foreach (Button item in panelControl1.Controls) item.Enabled = false;
            }
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            skor = 0;
            sure = 60;
            lblSkor.Text = skor.ToString();
            timer1.Enabled = true;
            foreach (Button item in panelControl1.Controls) item.Enabled = true;
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            foreach (Button item in panelControl1.Controls) item.Enabled = false;
        }

        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            foreach (Button item in panelControl1.Controls) item.Enabled = true;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
