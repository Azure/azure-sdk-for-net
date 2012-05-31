// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Globalization;
using System.Xml;

namespace Microsoft.WindowsAzure.MediaServices.Client.BulkIngest
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification="created through Lazy")]
    internal partial  class AssetWriter
    {
        private static readonly Lazy<FileInfoWriter> _fileWriter = new Lazy<FileInfoWriter>();

        private static void WriteContentKeyToAssetElement(XmlWriter writer, string keyId, string checksum, ContentKeyType keyType)
        {            
            writer.WriteStartElement("ContentKeyToAsset");
            writer.WriteAttributeString("KeyId", keyId);
            writer.WriteAttributeString("Checksum", checksum);
            writer.WriteAttributeString("KeyType", Convert.ToString((int)keyType, CultureInfo.InvariantCulture));
            writer.WriteEndElement();
        }

        protected override void WriteContents(IAsset entity, XmlWriter writer)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            _fileWriter.Value.Write(entity.Files, writer);

            foreach (IContentKey key in entity.ContentKeys)
            {
                WriteContentKeyToAssetElement(writer, key.Id, key.Checksum, key.ContentKeyType);
            }
        }
    }
}
