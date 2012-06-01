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

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Describes an input asset in a job template.
    /// </summary>
    internal class JobTemplateInputAsset : IAsset
    {
        public ReadOnlyCollection<IFileInfo> Files
        {
            get { throw new NotImplementedException(); }
        }

        public ReadOnlyCollection<ILocator> Locators
        {
            get { throw new NotImplementedException(); }
        }

        public IList<IContentKey> ContentKeys
        {
            get { throw new NotImplementedException(); }
        }

        public ReadOnlyCollection<IAsset> ParentAssets
        {
            get { throw new NotImplementedException(); }
        }

        public Task UploadFilesAsync(string[] files, BlobTransferClient blobTransferClient, ILocator locator, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public void Publish()
        {
            throw new NotImplementedException();
        }

        public string Id
        {
            get { throw new NotImplementedException(); }
        }

        public AssetState State
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime Created
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime LastModified
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string AlternateId
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public AssetCreationOptions Options
        {
            get { throw new NotImplementedException(); }
        }
    }
}
