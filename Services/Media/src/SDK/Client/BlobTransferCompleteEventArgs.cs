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
using System.ComponentModel;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents the information for blob transfer completion event.
    /// </summary>
    public class BlobTransferCompleteEventArgs:AsyncCompletedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of <see cref=" BlobTransferCompleteEventArgs"/>
        /// </summary>
        /// <param name="error">The error, if any, that occurred. Nulls allowed.</param>
        /// <param name="isCanceled">true if the operation was canceled; false otherwise.</param>
        /// <param name="userState">The user state provided for the operation.</param>
        /// <param name="localFileName">The name of the local file.</param>
        /// <param name="url">A <see cref="Uri"/> representing the location of the blob.</param>
        /// <param name="transferType">The blob transfer type.</param>
        /// <exception cref="ArgumentException">If <paramref name="localFileName"/> is null or empty.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="url"/> is null.</exception>
        public BlobTransferCompleteEventArgs(Exception error, bool isCanceled, object userState, string localFileName, Uri url, BlobTransferType transferType) : base(error, isCanceled, userState)
        {
            if(String.IsNullOrEmpty(localFileName))
            {
                throw new ArgumentException(StringTable.ErrorLocalFilenameIsNullOrEmpty);
            }
            if (url ==null)
            {
                throw new ArgumentNullException("url");
            }
            LocalFileName = localFileName;
            Url = url;
            TransferType = transferType;
        }

        /// <summary>
        /// Gets or sets the local file name used for transfer.
        /// </summary>
        public string LocalFileName { get; set; }

        /// <summary>
        /// Gets or sets the url address of blob which has been transferred.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the Transfer type.
        /// </summary>
        /// <seealso cref="BlobTransferType"/>
        public BlobTransferType TransferType { get; set; }
    }
}
