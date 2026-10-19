using System;
using System.IO;
using System.Text.Json;

namespace C3_QuanLyDaNgoai.Services
{
    public class UserSettings
    {
        public string Language { get; set; } = "vi";
    }

    public static class SettingsService
    {
        private static readonly string SettingsFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "usersettings.json"
        );

        public static UserSettings LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    string json = File.ReadAllText(SettingsFilePath);
                    var settings = JsonSerializer.Deserialize<UserSettings>(json);
                    if (settings != null)
                        return settings;
                }
            }
            catch
            {
                // Fallback to default
            }

            return new UserSettings { Language = "vi" };
        }

        public static void SaveSettings(UserSettings settings)
        {
            try
            {
                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SettingsFilePath, json);
            }
            catch
            {
                // Ignore write failures gracefully
            }
        }
    }
}
