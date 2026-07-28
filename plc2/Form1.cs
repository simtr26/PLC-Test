using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using S7.Net.Protocol;
using S7.Net.Types;
using S7.Net;

namespace plc2
{
    public partial class Form1 : Form
    {
        public static Plc plc = new Plc(CpuType.S71200, "192.168.0.1", 0, 1);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void butt_connect_Click(object sender, EventArgs e)
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

        private void butt_open_Click(object sender, EventArgs e)
        {
            try
            {
                if (!plc.IsConnected)
                {
                    plc.Open();
                }
                plc.WriteBit(DataType.DataBlock, 1, 0, 0, true);
                plc.WriteBit(DataType.DataBlock, 1, 0, 1, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void butt_close_Click(object sender, EventArgs e)
        {
            try
            {
                if (!plc.IsConnected)
                {
                    plc.Open();
                }
                plc.WriteBit(DataType.DataBlock, 1, 0, 0, false); 
                plc.WriteBit(DataType.DataBlock, 1, 0, 1, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // TextBox'a girilen hız değerini PLC'ye (Data_block_2, Offset 0) yazan buton
        private void butt_SetSpeed_Click(object sender, EventArgs e)
        {
            try
            {
                if (plc.IsConnected && short.TryParse(txtSpeedRef.Text, out short targetSpeed))
                {
                    // Int değerini 2 baytlık diziye çevirip doğrudan DB2, Offset 0'a yazıyoruz
                    byte[] bytes = S7.Net.Types.Int.ToByteArray(targetSpeed);
                    plc.WriteBytes(DataType.DataBlock, 2, 0, bytes);
                }
                else
                {
                    MessageBox.Show("Bağlantı kopuk veya geçersiz değer girdin, Kaptan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hız yazma hatası: " + ex.Message);
            }
        }

        // Timer her tetiklendiğinde motordan anlık hızı okuyup TextBox'a yazdırır
        private void SpeedReadTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (plc.IsConnected)
                {
                    // DB2, Offset 2'den 2 Byte (Int) oku
                    // Not: S7.Net ReadBytes metodu ile ilgili DB alanını çekiyoruz
                    byte[] bytes = plc.ReadBytes(DataType.DataBlock, 2, 2, 2);
                    short actualSpeed = S7.Net.Types.Int.FromByteArray(bytes);

                    // Anlık hızı arayüzdeki TextBox'a yansıt
                    txtSpeedAct.Text = actualSpeed.ToString();
                }
            }
            catch
            {
                // Okuma esnasındaki geçici bağlantı dalgalanmalarını bastırır
            }
        }

        private void txtSpeedAct_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}