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
namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.Data
{
    using System.IO;
    using System.Xml;

    internal class XmlDocumentConverter
    {
        internal XmlDocument GetXmlDocument(string payLoad)
        {
            XmlDocument doc = new XmlDocument();
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(payLoad);
                writer.Flush();
                stream.Position = 0;
                using (var xmlReader = XmlReader.Create(stream))
                {
                    doc.Load(xmlReader);
                    return doc;
                }
            }
        }
    }
}