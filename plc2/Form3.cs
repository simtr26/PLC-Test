using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7;
using S7.Net;
using S7.Net.Protocol;
using S7.Net.Types;
namespace plc2
{
    public partial class Form3 : Form
    {

        public static Plc plc = new Plc(CpuType.S71200, "192.168.0.1", 0, 1);
        private System.Windows.Forms.Timer speedReadTimer;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            speedReadTimer = new System.Windows.Forms.Timer();
            speedReadTimer.Interval = 500; // Her yarım saniyede bir okur
       
            speedReadTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                plc.Open();

                if (plc.IsConnected)
                    MessageBox.Show("PLC bağlantısı başarılı!");
                else
                    MessageBox.Show("Bağlantı kurulamadı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            this.Hide();
            f2.ShowDialog();
        }
    }

}
