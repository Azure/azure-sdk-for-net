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
using System.Collections.Generic;
using System.Xml;

namespace Microsoft.WindowsAzure.MediaServices.Client.BulkIngest
{
    internal partial class ManifestWriter
    {
        private static readonly Lazy<AssetWriter> _assetWriter = new Lazy<AssetWriter>();
        private static readonly Lazy<ContentKeyWriter> _contentKeyWriter = new Lazy<ContentKeyWriter>();
        private readonly Guid _ingestIdentifier;
        private readonly IEnumerable<IAsset> _assets;
        private readonly IEnumerable<IContentKey> _contentKeys;

        public ManifestWriter(Guid ingestIdentifier, IEnumerable<IAsset> assets, IEnumerable<IContentKey> contentKeys)
        {
            _ingestIdentifier = ingestIdentifier;
            _assets = assets;
            _contentKeys = contentKeys;
        }

        public void WriteTo(XmlWriter output)
        {
            output.WriteStartDocument();
            output.WriteStartElement("BulkIngest");
            output.WriteAttributeString("Id", _ingestIdentifier.ToString());

            _assetWriter.Value.Write(_assets, output);

            _contentKeyWriter.Value.Write(_contentKeys, output);

            output.WriteEndElement();
            output.Flush();
        }
    }
}
