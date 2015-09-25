using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FBE2.MaXolution.Fertigungsplanung.Model
{
    class XMLWriter
    {
        public void Write(string File, Einstellungen einstellung)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Einstellungen));

            FileStream fs = new FileStream(File, FileMode.Create);

            serializer.Serialize(fs, einstellung);
            fs.Close();
        }

        private static string GetApplicationsPath()
        {
            FileInfo fi = new FileInfo(Assembly.GetEntryAssembly().Location);
            return fi.DirectoryName;
        }

        public Einstellungen Read(string File, Einstellungen einstellung)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Einstellungen));

            FileStream fs = new FileStream(File, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);

            einstellung = (Einstellungen)serializer.Deserialize(reader);
            fs.Close();
            return einstellung;
        }
    }
}
