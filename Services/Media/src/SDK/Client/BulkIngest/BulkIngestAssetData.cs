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
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.MediaServices.Client.BulkIngest
{
    internal class BulkIngestAssetData : IAsset
    {
        private readonly List<IFileInfo> _files = new List<IFileInfo>();
        private readonly List<IContentKey> _contentKeys = new List<IContentKey>();

        public BulkIngestAssetData(string name)
        {
            this.Name = name;
            Files = new ReadOnlyCollection<IFileInfo>(_files);
            Id = String.Empty;
            State = AssetState.Initialized;
            ContentKeys = new List<IContentKey>(_contentKeys);
        }

        public Task UploadFilesAsync(string[] files, BlobTransferClient blobTransferClient, ILocator locator,CancellationToken token)
        {
            throw new NotSupportedException();
        }

        public void Publish()
        {
            throw new NotSupportedException();
        }

        public string Id { get; internal set; }

        public AssetState State { get; internal set; }

        public string Name { get; set; }
        public string AlternateId { get; set; }
        public AssetCreationOptions Options { get; set; }

        public IList<IContentKey> ContentKeys { get; private set; }
        public ReadOnlyCollection<IFileInfo> Files { get; private set; }

        public List<IFileInfo> FilesList
        {
            get { return _files; }
        }

       

        public DateTime Created
        {
            get { return default(DateTime); }
        }

        public DateTime LastModified
        {
            get { return default(DateTime); }
        }

        public ReadOnlyCollection<ILocator> Locators
        {
            get { return new ReadOnlyCollection<ILocator>(new ILocator[0]); }
        }

        public ReadOnlyCollection<IAsset> ParentAssets
        {
            get { return new ReadOnlyCollection<IAsset>(new IAsset[0]); }
        }
    }
}
