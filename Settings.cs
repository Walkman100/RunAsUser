using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace RunAsUser {
    static class Settings {
        private static string settingsPath;
        private static bool loaded = false;

        public static bool Init() {
            string configFileName = "RunAsUser.xml";

            if (WalkmanLib.GetOS() == WalkmanLib.OS.Windows) {
                if (!Directory.Exists(Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS")))
                    Directory.CreateDirectory(Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS"));
                settingsPath = Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS", configFileName);
            } else {
                if (!Directory.Exists(Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS")))
                    Directory.CreateDirectory(Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS"));
                settingsPath = Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS", configFileName);
            }

            if (File.Exists(Path.Combine(Application.StartupPath, configFileName)))
                settingsPath = Path.Combine(Application.StartupPath, configFileName);
            else if (File.Exists(configFileName))
                settingsPath = new FileInfo(configFileName).FullName;

            try {
                if (File.Exists(settingsPath)) {
                    LoadSettings();
                    return true;
                } else {
                    return false;
                }
            } finally {
                loaded = true;
            }
        }

        private static List<SavedConfiguration> savedConfigurations = new List<SavedConfiguration>();
        public static IReadOnlyCollection<SavedConfiguration> SavedConfigurations => savedConfigurations;
        public static void UpdateConfigurations(List<SavedConfiguration> configurations) {
            savedConfigurations = configurations;
            SaveSettings();
        }

        private static void LoadSettings() {
            using (var reader = XmlReader.Create(settingsPath)) {
                try {
                    reader.Read();
                } catch (XmlException) {
                    return;
                }

                if (reader.IsStartElement() && reader.Name == "RunAsUser") {
                    if (reader.Read() && reader.IsStartElement() && reader.Name == "Settings" && reader.Read()) {
                        while (reader.IsStartElement()) {
                            switch (reader.Name) {
                                case "SavedConfigurations":

                                    while (reader.IsStartElement()) {
                                        if (reader.Read() && reader.IsStartElement() && reader.Name == "Config") {
                                            var config = new SavedConfiguration();
                                            config.Name = reader.GetAttribute("Name");
                                            config.Filename = reader.GetAttribute("Filename");
                                            config.Arguments = reader.GetAttribute("Arguments");
                                            config.UserName = reader.GetAttribute("UserName");
                                            config.Password = reader.GetAttribute("Password");
                                            config.Domain = reader.GetAttribute("Domain");
                                            savedConfigurations.Add(config);
                                        }
                                    }
                                    break;
                            }
                            reader.Read(); reader.Read();
                        }
                    }
                }
            }
        }

        private static void SaveSettings() {
            if (!loaded)
                return;
            using (var writer = XmlWriter.Create(settingsPath, new XmlWriterSettings() { Indent = true })) {
                writer.WriteStartDocument();
                writer.WriteStartElement("RunAsUser");

                writer.WriteStartElement("Settings");

                writer.WriteStartElement("SavedConfigurations");
                foreach (var item in SavedConfigurations) {
                    writer.WriteStartElement("Config");
                    writer.WriteAttributeString("Name", item.Name);
                    writer.WriteAttributeString("Filename", item.Filename);
                    writer.WriteAttributeString("Arguments", item.Arguments);
                    writer.WriteAttributeString("UserName", item.UserName);
                    writer.WriteAttributeString("Password", item.Password);
                    writer.WriteAttributeString("Domain", item.Domain);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement(); // SavedConfigurations

                writer.WriteEndElement(); // Settings

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
