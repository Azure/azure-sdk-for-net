// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Blob
    /// Storage.
    /// </summary>
    public class BlobConnectionOptions : StorageConnectionOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobConnectionOptions"/>
        /// class.
        /// </summary>
        public BlobConnectionOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobConnectionOptions"/>
        /// class for making service requests signed with an Azure Blob
        /// Storage shared key.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="SharedKeyCredentials"/> used to sign requests.
        /// </param>
        public BlobConnectionOptions(SharedKeyCredentials credentials)
            : base(credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobConnectionOptions"/>
        /// class for making service requests signed with Azure token
        /// credentials.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="TokenCredentials"/> used to authenticate requests.
        /// </param>
        public BlobConnectionOptions(TokenCredentials credentials)
            : base(credentials)
        {
        }
    }
}
