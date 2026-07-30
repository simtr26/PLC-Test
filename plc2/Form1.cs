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
        private System.Windows.Forms.Timer speedReadTimer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Timer ayarlarını form açıldığında yap ve başlat
            speedReadTimer = new System.Windows.Forms.Timer();
            speedReadTimer.Interval = 500; // Her yarım saniyede bir okur
            speedReadTimer.Tick += SpeedReadTimer_Tick;
            speedReadTimer.Start(); // DÜZELTME 1: Timer hiç başlatılmıyordu, bu satır eksikti

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
                bool gerimi = (bool)plc.Read("DB3.DBX0.0");
                bool ilerimi = (bool)plc.Read("DB3.DBX0.1");
                if (gerimi == false && ilerimi == true)
                {
                    label3.Text = "GERİ";
                }
                else if (ilerimi == false && gerimi == true)
                {
                    label3.Text = "İLERİ";
                }
                else
                {
                    label3.Text = "MOTOR DURDU";
                }
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
                label3.Text = "MOTOR DURDU";
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
                if (!plc.IsConnected)
                {
                    MessageBox.Show("Bağlantı yok, önce PLC'ye bağlanın");
                    return;
                }

                if (!short.TryParse(txtSpeedAct.Text, out short targetSpeed))
                {
                    MessageBox.Show("Geçersiz hız değeri, lütfen sayısal bir değer girin");
                    return;
                }

                // S7.Net ile doğrudan DB2, Offset 0 adresine Int türünde yazma
                plc.Write("DB2.DBW0", targetSpeed);
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
                    txtSpeedRef.Text = actualSpeed.ToString();
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
            try
            {
                if (!plc.IsConnected)
                {
                    MessageBox.Show("Bağlantı yok, önce PLC'ye bağlanın");
                    return;
                }

                if (!short.TryParse(txtSpeedAct.Text, out short targetSpeed))
                {
                    MessageBox.Show("Geçersiz hız değeri, lütfen sayısal bir değer girin");
                    return;
                }

                // S7.Net ile doğrudan DB2, Offset 0 adresine Int türünde yazma
                plc.Write("DB2.DBW0", targetSpeed);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hız yazma hatası: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            try
            {
                if (!plc.IsConnected)
                    plc.Open();

                plc.Write("DB1.DBX0.1", false);
            

               
                    plc.Write("DB3.DBX0.3", true);  // geris = 1
                    Task.Delay(100);          // PLC'nin okuması için 100ms bekle
                    plc.Write("DB3.DBX0.3", false); // geris = 0 (Butondan elini çekti gibi)
                plc.Write("DB3.DBX0.0", false);
                plc.Write("DB3.DBX0.1", true);
                label3.Text="GERİ";

            }
            
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!plc.IsConnected)
                    plc.Open();

                plc.Write("DB1.DBX0.1", false);



                plc.Write("DB3.DBX0.2", true);  // geris = 1
                Task.Delay(100);          // PLC'nin okuması için 100ms bekle
                plc.Write("DB3.DBX0.2", false); // geris = 0 (Butondan elini çekti gibi)
                plc.Write("DB3.DBX0.1", false);
                plc.Write("DB3.DBX0.0", true);
                label3.Text = "İLERİ";

            }

            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex.Message);
            }
        }
    }
}