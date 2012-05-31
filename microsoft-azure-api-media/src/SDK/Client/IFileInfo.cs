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
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents an file belonging to an Asset.
    /// </summary>
    /// <see cref="IAsset.Files"/>
    public partial interface IFileInfo
    {
        /// <summary>
        /// Gets the Asset that this file belongs to.
        /// </summary>
        /// <value>The parent <see cref="IAsset"/>.</value>
        IAsset Asset { get; }

        /// <summary>
        /// Asyncroniusly downloads the represented file to the specified file path.
        /// </summary>
        /// <param name="file">The file name and path to download the file to.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task DownloadToFileAsync(string file, CancellationToken cancellationToken);

        /// <summary>
        ///  Downloads the represented file to the specified file path.
        /// </summary>
        /// <param name="file">The file name and path to download the file to</param>
        void DownloadToFile(string file);

        /// <summary>
        /// Occurs when a file download progresses.
        /// </summary>
        event EventHandler<DownloadProgressEventArgs> OnDownloadProgress;

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}
