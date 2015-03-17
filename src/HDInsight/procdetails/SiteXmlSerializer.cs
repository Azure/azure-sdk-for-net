// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace ProcDetailsTestApplication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Used to deserialize an Hadoop "site.xml" file.
    /// </summary>
    public class SiteXmlSerializer
    {
        /// <summary>
        /// Deserializes the site.xml file into a entries.
        /// </summary>
        /// <param name="fileName">
        /// The file name to deserialize.
        /// </param>
        /// <returns>
        /// Entries representing the site.xml file.
        /// </returns>
        public Entries DeserializeXml(string fileName)
        {
            using (var file = File.OpenRead(fileName))
            {
                return this.DeserializeXml(file);
            }
        }

        /// <summary>
        /// Deserializes a stream representing a site.xml file.
        /// </summary>
        /// <param name="stream">
        /// The stream to deserialize.
        /// </param>
        /// <returns>
        /// Entries representing the site.xml file.
        /// </returns>
        public Entries DeserializeXml(Stream stream)
        {
            if (ReferenceEquals(stream, null))
            {
                throw new ArgumentNullException("stream");
            }
            using (var memStream = new MemoryStream())
            {
                stream.CopyTo(memStream);
                memStream.Flush();
                memStream.Position = 0;
                using (var reader = XmlReader.Create(memStream))
                {
                    return this.DeserializeXml(reader);
                }
            }
        }

        /// <summary>
        /// Deserializes an XmlReader representing a site.xml file.
        /// </summary>
        /// <param name="reader">
        /// The XmlReader to deserialize.
        /// </param>
        /// <returns>
        /// Entries representing the site.xml file.
        /// </returns>
        public Entries DeserializeXml(XmlReader reader)
        {
            Entries entries = new Entries();
            try
            {
                var doc = new XmlDocument();
                doc.Load(reader);
                var props = doc.SelectNodes("//property");
                if (!ReferenceEquals(props, null))
                {
                    foreach (XmlNode prop in props)
                    {
                        string name;
                        string value = string.Empty;
                        var nameNode = prop.SelectSingleNode("name");
                        var valueNode = prop.SelectSingleNode("value");
                        if (!ReferenceEquals(nameNode, null))
                        {
                            name = nameNode.InnerText;
                            if (!ReferenceEquals(valueNode, null))
                            {
                                value = valueNode.InnerText;
                            }
                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                entries.Add(name, value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!(ex is IOException || ex is XmlException))
                {
                    throw;
                }
            }
            return entries;
        }
    }
}
