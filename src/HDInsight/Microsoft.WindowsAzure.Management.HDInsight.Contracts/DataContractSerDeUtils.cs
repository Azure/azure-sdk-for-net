using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts
{
    public class DataContractsSerDeUtils
    {
        public static string SerializeToXml<T>(T o)
        {
            var ser = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, o);
                ms.Seek(0, SeekOrigin.Begin);
                return new StreamReader(ms).ReadToEnd();
            }
        }

        public static T DeserializeFromXml<T>(string intrinsicsettings)
        {
            var ser = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(intrinsicsettings)))
            {
                return (T)ser.ReadObject(ms);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security.Xml", "CA3057:DoNotUseLoadXml")]
        public static XmlNode SerializeToXmlNode<T>(T o)
        {
            var ser = new DataContractSerializer(typeof(T));
            var objAsXml = SerializeToXml(o);
            var doc = LoadXml(objAsXml);
            return doc.DocumentElement;
        }

        public static XmlDocument LoadXml(string objAsXml)
        {
            XmlDocument doc = new XmlDocument();
            LoadXml(objAsXml, doc);
            return doc;
        }

        public static void LoadXml(string objAsXml, XmlDocument doc)
        {
            Debug.Assert(doc != null);
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;
            using (var sr = new StringReader(objAsXml))
            using (var reader = XmlReader.Create(sr, settings))
            {
                doc.Load(reader);
            }
        }
        protected T DeserializeFromXmlNode<T>(string data)
        {
            var nodes = DeserializeFromXml<XmlNode[]>(data);
            if (nodes != null && nodes.Length > 0)
            {
                // Return the element
                return DeserializeFromXml<T>(nodes[0].OuterXml);
            }
            throw new ArgumentException("No data found to deserialize");
        }
    }
}
