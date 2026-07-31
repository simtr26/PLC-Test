using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; // System.Text.Json kütüphanesini kullanıyoruz

namespace plc2
{
    public static class ProfileManager
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profiles.json");

        public static void SaveProfiles(List<UserProfile> profiles)
        {
            // System.Text.Json serileştirme mantığı
            string json = JsonSerializer.Serialize(profiles, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static List<UserProfile> LoadProfiles()
        {
            if (!File.Exists(FilePath))
                return new List<UserProfile>();

            // System.Text.Json geri yükleme mantığı
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<UserProfile>>(json) ?? new List<UserProfile>();
        }
    }
}