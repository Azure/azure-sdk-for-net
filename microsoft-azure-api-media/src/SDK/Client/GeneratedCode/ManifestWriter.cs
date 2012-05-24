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
	internal partial class ManifestWriter
	{
	}

	internal partial class AssetWriter : XmlTypeWriterBase<IAsset>
	{
		public AssetWriter() : base("Asset")
	    {
	    }

	    protected override void WriteAttributes(IAsset entity, XmlWriter writer)
	    {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if(writer == null)
            {
                throw new ArgumentNullException("writer");
            }

	            writer.WriteAttributeString("Name", Convert.ToString(entity.Name, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("AlternateId", Convert.ToString(entity.AlternateId, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("Options", Convert.ToString(entity.Options, CultureInfo.InvariantCulture));
	    }
	}
	internal partial class FileInfoWriter : XmlTypeWriterBase<IFileInfo>
	{
		public FileInfoWriter() : base("FileInfo")
	    {
	    }

	    protected override void WriteAttributes(IFileInfo entity, XmlWriter writer)
	    {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if(writer == null)
            {
                throw new ArgumentNullException("writer");
            }

	            writer.WriteAttributeString("IsPrimary", Convert.ToString(entity.IsPrimary, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("Name", Convert.ToString(entity.Name, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("EncryptionVersion", Convert.ToString(entity.EncryptionVersion, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("EncryptionScheme", Convert.ToString(entity.EncryptionScheme, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("IsEncrypted", Convert.ToString(entity.IsEncrypted, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("EncryptionKeyId", Convert.ToString(entity.EncryptionKeyId, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("InitializationVector", Convert.ToString(entity.InitializationVector, CultureInfo.InvariantCulture));
	    }
	}
	internal partial class ContentKeyWriter : XmlTypeWriterBase<IContentKey>
	{
		public ContentKeyWriter() : base("ContentKey")
	    {
	    }

	    protected override void WriteAttributes(IContentKey entity, XmlWriter writer)
	    {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if(writer == null)
            {
                throw new ArgumentNullException("writer");
            }

	            writer.WriteAttributeString("ContentKeyId", entity.Id);
	            writer.WriteAttributeString("Name", Convert.ToString(entity.Name, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("EncryptedContentKey", Convert.ToString(entity.EncryptedContentKey, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("ContentKeyType", Convert.ToString(entity.ContentKeyType, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("ProtectionKeyId", Convert.ToString(entity.ProtectionKeyId, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("ProtectionKeyType", Convert.ToString(entity.ProtectionKeyType, CultureInfo.InvariantCulture));
	            writer.WriteAttributeString("Checksum", Convert.ToString(entity.Checksum, CultureInfo.InvariantCulture));
	    }
	}
}
