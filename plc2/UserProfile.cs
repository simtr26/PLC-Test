using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc2
{
    public class UserProfile
    {
        public string ProfileName { get; set; }
        public string Direction { get; set; } // "İLERİ" veya "GERİ"
        public int MaxRpm { get; set; }
        public double MaxRpmDurationSec { get; set; }
        public double AccelerationTimeSec { get; set; }
        public double StoppingTimeSec { get; set; }

        // ListBox'ta doğrudan Profil Adının görünmesi için
        public override string ToString()
        {
            return ProfileName;
        }
    }
}
