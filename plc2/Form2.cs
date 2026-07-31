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
            panel3.Visible = true;
            label12.Text = ProfileName;
            if (Direction == "İLERİ")
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton4.Checked = true;
            }
            
                textBox10.Text = MaxRpm.ToString();
                textBox9.Text = MaxRpmDurationSec.ToString();
                textBox8.Text = AccelerationTimeSec.ToString();
                textBox7.Text = StoppingTimeSec.ToString();
        }
    }
}