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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents an Asset that can be an input to jobs or tasks.
    /// </summary>
    /// <seealso cref="BaseAssetCollection.Create(string)"/>
    /// <seealso cref="BaseAssetCollection.CreateFromDirectory(string,string)"/>
    /// <seealso cref="BaseAssetCollection"/>
    public partial interface IAsset
    {
        /// <summary>
        /// Gets a collection of files contained by the Asset.
        /// </summary>
        /// <value>A collection of files contained by the Asset.</value>
        ReadOnlyCollection<IFileInfo> Files { get; }

        /// <summary>
        /// Gets the Locators associated with this Asset.
        /// </summary>
        /// <value>A Collection of <see cref="ILocator"/> that are associated with the Asset.</value>
        /// <remarks>This collection is not modifiable. Instead a SAS locator is created from calling <see cref="LocatorCollection.CreateSasLocator(IAsset,IAccessPolicy)"/>.</remarks>
        ReadOnlyCollection<ILocator> Locators { get; }

        /// <summary>
        /// Gets the Content Keys associated with the Asset
        /// </summary>
        /// <value>A collection of <see cref="IContentKey"/> associated with the Asset.</value>
        IList<IContentKey> ContentKeys { get; }

        /// <summary>
        /// Gets the parent assets that were used to create the Asset
        /// </summary>
        /// <value>A collection of <see cref="IAsset"/> associated with the Asset.</value>
        ReadOnlyCollection<IAsset> ParentAssets { get; }


        /// <summary>
        /// Uploads the files asynconosly to an asset.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <param name="blobTransferClient">The <see cref="BlobTransferClient"/> which is used to upload files</param>
        /// <param name="locator">An asset <see cref="ILocator"/> which defines permissions associated with the Asset</param>
        /// <param name="token">A <see cref="CancellationToken"/> to use for canceling upload operation </param>
        /// <returns></returns>
        Task UploadFilesAsync(string[] files, BlobTransferClient blobTransferClient, ILocator locator, CancellationToken token);

        /// <summary>
        /// Publishes this asset instance
        /// </summary>
        void Publish();


    }
}
