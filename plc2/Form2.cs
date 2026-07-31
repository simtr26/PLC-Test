using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plc2
{
    public partial class Form2 : Form
    {
        private List<UserProfile> _profileList = new List<UserProfile>();
        public static Plc plc = new Plc(CpuType.S71200, "192.168.0.1", 0, 1);
        private System.Windows.Forms.Timer speedReadTimer;
        public static string direction = null;

        public Form2()
        {
            InitializeComponent();
        }

        // Form ilk açıldığında diske kaydedilmiş profilleri otomatik çeker
        private void Form2_Load(object sender, EventArgs e)
        {
            YenileVeYukle();
        }

        // PROFİL OLUŞTUR Butonu
        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;// 1. Önce yön kararını nesne dışında belirliyoruz
        }

        // PROFİL SEÇ Butonu
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            // Kayıtlı profilleri diskten tekrar yükleyip ListBox'a tazeliyoruz
            YenileVeYukle();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // ListBox'tan profil seçildiğinde verileri ilgili textBox ve radioButton'lara doldurur
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is UserProfile selectedProfile)
            {
                textBox2.Text = selectedProfile.ProfileName;
                radioButton1.Checked = selectedProfile.Direction == "İLERİ";
                radioButton2.Checked = selectedProfile.Direction == "GERİ";
                textBox3.Text = selectedProfile.MaxRpm.ToString();
                textBox4.Text = selectedProfile.MaxRpmDurationSec.ToString();
                textBox5.Text = selectedProfile.AccelerationTimeSec.ToString();
                textBox6.Text = selectedProfile.StoppingTimeSec.ToString();
            }
        }

        // Ortak veri yükleme ve ListBox bağlama fonksiyonu
        private void RefreshListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _profileList;
            listBox1.DisplayMember = "ProfileName";
        }

        // Diskten verileri tazeleyip arayüzü güncelleyen yardımcı metod
        private void YenileVeYukle()
        {
            _profileList = ProfileManager.LoadProfiles();
            RefreshListBox();
        }
       public static string ProfileName;
        public static string Direction;
        public static double MaxRpm;
        public static double MaxRpmDurationSec;
        public static double AccelerationTimeSec;
        public static double StoppingTimeSec;
        // Alt taraftaki Kaydet / Profil Oluştur Butonu (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            string direction;
            if (radioButton1.Checked)
            {
                direction = "İLERİ";
            }
            else
            {
                direction = "GERİ";
            }

            // 2. Nesneyi kurallara uygun olarak oluşturuyoruz
            var newProfile = new UserProfile
            {
                ProfileName = textBox2.Text,
                Direction = direction,
                MaxRpm = int.TryParse(textBox3.Text, out int rpm) ? rpm : 0,
                MaxRpmDurationSec = double.TryParse(textBox4.Text, out double d1) ? d1 : 0,
                AccelerationTimeSec = double.TryParse(textBox5.Text, out double d2) ? d2 : 0,
                StoppingTimeSec = double.TryParse(textBox6.Text, out double d3) ? d3 : 0
            };

            // Listeye ekle ve JSON dosyasına kaydet
            _profileList.Add(newProfile);
            ProfileManager.SaveProfiles(_profileList);

            // Ekranı güncelle ve disk senkronizasyonunu sağla
            YenileVeYukle();

            MessageBox.Show("Profil başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Değerleri kutulardan alıp başlangıç ayarlarını yapıyoruz
           
            if (listBox1.SelectedItem is UserProfile selectedProfile)
            {
                // Panellerin görünürlüğünü ayarlama
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;

                // JSON'dan yuklenip ListBox'ta secilen profil verilerini doldurma
                label12.Text = selectedProfile.ProfileName;

                if (selectedProfile.Direction == "İLERİ")
                {
                    radioButton3.Checked = true;
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
                else
                {
                    radioButton4.Checked = true;
                }


                textBox10.Text = selectedProfile.MaxRpm.ToString();
                textBox9.Text = selectedProfile.MaxRpmDurationSec.ToString();
                textBox8.Text = selectedProfile.AccelerationTimeSec.ToString();
                textBox7.Text = selectedProfile.StoppingTimeSec.ToString();

                hedefHiz = selectedProfile.MaxRpm;
                adimSayisi = (int)selectedProfile.AccelerationTimeSec;

                // Her tick'te ne kadar dartacağını hesaplıyoruz
                artisMiktari = hedefHiz / adimSayisi;
                // Sayaçları sıfırla ve Timer'ı başlat
                mevcutHiz = 0;
                mevcutAdim = 0;

                hizlanma.Start();
            }
            else
            {
                MessageBox.Show("Lütfen önce listeden bir profil seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            speedReadTimer = new System.Windows.Forms.Timer();
            speedReadTimer.Interval = 500; // Her yarım saniyede bir okur
          
            speedReadTimer.Start();

            try
            {
                if (!plc.IsConnected)
                {
                    plc.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PLC'ye bağlanılamadı: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        double mevcutHiz = 0;
        double hedefHiz = 0;
        double adimSayisi = 0;
        double mevcutAdim = 0;
        double artisMiktari = 0;

        double donmesuresi = 0;
        double azalisMiktari = 0;
        double adimSayisi2 = 0;

        private void hizlanma_Tick(object sender, EventArgs e) //SIKINTILI KOD !!!!!!!!!!
        {
             
            azalisMiktari = hedefHiz / double.Parse(textBox7.Text);
            if (!plc.IsConnected)
{
    hizlanma.Stop();
    MessageBox.Show("Bağlantı yok, önce PLC'ye bağlanın.");
    return;
}

// 2. İvmelenme Süreci
if (mevcutAdim < adimSayisi)
{
    mevcutAdim++;
    mevcutHiz += artisMiktari;

    // Hedef hızı aşmamak için güvenlik kontrolü
    if (mevcutHiz > hedefHiz) 
    {
        mevcutHiz = hedefHiz;
    }

    try
    {
        // PLC'ye güncel hızı yazıyoruz
        // NOT: WORD (DBW) veri tipi kullanıyorsan mevcutHiz değerinin 'short' veya 'ushort' olduğundan emin ol.
        plc.Write("DB2.DBW0", Convert.ToInt16(mevcutHiz));
    }
    catch (Exception ex)
    {
        hizlanma.Stop();
        MessageBox.Show("Hız yazma hatası: " + ex.Message);
    }
}


            if (!plc.IsConnected)
            {
                hizlanma.Stop();
                MessageBox.Show("Bağlantı yok, önce PLC'ye bağlanın.");
                return;
            }

            // 0'a bölünme hatasını (Infinity/NaN) önlemek için güvenlik kontrolü
            double durmaSuresi = StoppingTimeSec > 0 ? StoppingTimeSec : 1;

            // Timer her çalıştığında düşecek hız miktarı (Interval hesabı dahil)
            double timerSaniyeCinsinden = durma.Interval / 1000.0;
            double adimSayisiDurma = durmaSuresi / timerSaniyeCinsinden;
           

            if (mevcutAdim > 0 && mevcutHiz > 0)
            {
                mevcutAdim--;
                mevcutHiz -= azalisMiktari;

                // GÜVENLİK: Hız 0'ın altına düşerse veya belirsiz (NaN/Infinity) olursa 0'a sabitle
                if (mevcutHiz < 0 || double.IsNaN(mevcutHiz) || double.IsInfinity(mevcutHiz))
                {
                    mevcutHiz = 0;
                }

                try
                {
                    // Güvenli dönüşüm
                    short yazilacakHiz = Convert.ToInt16(Math.Round(mevcutHiz));
                    plc.Write("DB2.DBW0", yazilacakHiz);
                }
                catch (Exception ex)
                {
                   hizlanma.Stop();
                    MessageBox.Show("Hız yazma hatası: " + ex.Message);
                }
            }
            else
            {
                // Yavaşlama bitti, hızı kesin olarak 0 yap ve timer'ı durdur
                mevcutHiz = 0;
                try
                {
                    plc.Write("DB2.DBW0", (short)0);
                }
                catch {
                    hizlanma.Stop();
                }

               
            }
        }
      
        private void donmet_Tick(object sender, EventArgs e)
        {
           
                
                
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void durma_Tick(object sender, EventArgs e)
        {
        
        }
    }
}