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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ServerDataObjects.Rdfe
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    [DataContract]
    public abstract class Payload
    {
        [DataMember(EmitDefaultValue = false)]
        public string ExtendedProperties { get; set; }

        public XmlReader SerializeToXmlReader()
        {
            var ser = new DataContractSerializer(this.GetType());
            var ms = Help.SafeCreate<MemoryStream>();
            try
            {
                ser.WriteObject(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
            }
            catch (Exception)
            {
                ms.Dispose();
                throw;
            }
            return Help.SafeCreate(() => XmlReader.Create(ms));
        }

        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode",
            Justification = "This is a DTO object, this is done for that purpose. [tgs]")]
        public XmlNode SerializeToXmlNode()
        {
            var doc = new XmlDocument();
            doc.Load(this.SerializeToXmlReader());
            return doc.DocumentElement;
        }

        public static T DeserializeFromXml<T>(string data) where T : Payload, new()
        {
            var ser = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                return (T)ser.ReadObject(ms);
            }
        }
    }
}