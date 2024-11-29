using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using XmlAccess;

namespace ReaderTest
{
    public class Paths
    {
        public static string AppRoot = @".";
        public static string SettingsDir { get { return Path.Combine(AppRoot, "SettingFile"); } }
        static public string SavePath = Path.Combine(SettingsDir, "Paths.xml");

        public string ReaderSettingsPath
        {
            get
            {
                return Path.Combine(SettingsDir, "ReaderSettings.xml");
            }
        }

        static public Paths Load()
        {
            if (!File.Exists(SavePath))
            {
                Paths paths = new Paths();
                paths.Save();
                return paths;
            }

            return (Paths)XmlAccessor.ReadXML(SavePath, typeof(Paths));
        }

        public void Save()
        {
            string dir = Path.GetDirectoryName(SavePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            XmlAccessor.WriteXML(this, SavePath);
        }
    }
}
