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
    /// Represents a Task output asset.
    /// </summary>
    /// <remarks>This is used when creating task to specify properties for a Task's output.</remarks>
    internal class OutputAsset : IAsset
    {
        /// <summary>
        /// Gets or sets whether or not the output is temporary (only exists while Job is running,) or permanent (exists after the Job is complete.)
        /// </summary>
        public bool IsTemporary { get; set; }


        public string Id { get; set; }

        public AssetState State { get { return AssetState.Initialized; } }

        public DateTime Created { get { return DateTime.UtcNow; } }

        public DateTime LastModified { get { return DateTime.MinValue; }  }

        public string Name { get; set; }

        public string AlternateId { get; set; }

        public AssetCreationOptions Options { get; set; }

        public ReadOnlyCollection<IFileInfo> Files
        {
            get { throw new NotSupportedException(StringTable.NotSupportedFiles); }
        }

        public ReadOnlyCollection<ILocator> Locators
        {
            get { throw new NotSupportedException(StringTable.NotSupportedLocators); }
        }

        public IList<IContentKey> ContentKeys
        {
            get { throw new NotSupportedException(); }
        }

        public ReadOnlyCollection<IAsset> ParentAssets { get; set; }

        public Task UploadFilesAsync(string[] files, BlobTransferClient blobTransferClient, ILocator locator,
                                     CancellationToken token)
        {
            throw new NotSupportedException(StringTable.NotSupportedUploadFilesAsync);
        }

        public void Publish()
        {
            throw new NotSupportedException(StringTable.NotSupportedPublish);
        }
    }
}
