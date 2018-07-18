// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Authentication.Properties;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Microsoft.Azure.Common.Authentication
{
    public static class XmlUtilities
    {
        public static T DeserializeXmlFile<T>(string fileName, string exceptionMessage = null)
        {
            // TODO: fix and uncomment. second parameter is wrong
            // Validate.ValidateFileFull(fileName, string.Format(Resources.PathDoesNotExistForElement, string.Empty, fileName));

            T item;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(FileUtilities.DataStore.ReadFileAsStream(fileName)))
            {
                try { item = (T)xmlSerializer.Deserialize(reader); }
                catch
                {
                    if (!String.IsNullOrEmpty(exceptionMessage))
                    {
                        throw new InvalidOperationException(exceptionMessage);
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return item;
        }

        public static void SerializeXmlFile<T>(T obj, string fileName)
        {
            Validate.ValidatePathName(fileName, String.Format(Resources.PathDoesNotExistForElement, String.Empty, fileName));
            Validate.ValidateStringIsNullOrEmpty(fileName, String.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringBuilder sBuilder = new StringBuilder();
            using (StringWriter writer = new StringWriter(sBuilder))
            {
                xmlSerializer.Serialize(writer, obj);
            }
            FileUtilities.DataStore.WriteFile(fileName, sBuilder.ToString(), Encoding.Unicode);
        }

        public static string SerializeXmlString<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringBuilder sBuilder = new StringBuilder();

            using (StringWriter writer = new StringWriter(sBuilder))
            {
                xmlSerializer.Serialize(writer, obj);
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// Formats the given XML into indented way.
        /// </summary>
        /// <param name="content">The input xml string</param>
        /// <returns>The formatted xml string</returns>
        public static string TryFormatXml(string content)
        {
            try
            {
                XDocument doc = XDocument.Parse(content);
                return doc.ToString();
            }
            catch (Exception)
            {
                return content;
            }
        }

        /// <summary>
        /// Formats given string into well formatted XML.
        /// </summary>
        /// <param name="unformattedXml">The unformatted xml string</param>
        /// <returns>The formatted XML string</returns>
        public static string Beautify(string unformattedXml)
        {
            string formattedXml = String.Empty;
            if (!String.IsNullOrEmpty(unformattedXml))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(unformattedXml);
                StringBuilder stringBuilder = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings()
                    {
                        Indent = true,
                        IndentChars = "\t",
                        NewLineChars = Environment.NewLine,
                        NewLineHandling = NewLineHandling.Replace
                    };
                using (XmlWriter writer = XmlWriter.Create(stringBuilder, settings))
                {
                    doc.Save(writer);
                }
                formattedXml = stringBuilder.ToString();
            }

            return formattedXml;
        }
    }
}
