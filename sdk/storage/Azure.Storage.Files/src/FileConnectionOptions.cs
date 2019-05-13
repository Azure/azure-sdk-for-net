// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Storage.Files
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure File
    /// Storage.
    /// </summary>
    public class FileConnectionOptions : StorageConnectionOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileConnectionOptions"/>
        /// class.
        /// </summary>
        public FileConnectionOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConnectionOptions"/>
        /// class for making service requests signed with an Azure File
        /// Storage shared key.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="SharedKeyCredentials"/> used to sign requests.
        /// </param>
        public FileConnectionOptions(SharedKeyCredentials credentials)
            : base(credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConnectionOptions"/>
        /// class for making service requests signed with Azure token
        /// credentials.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="TokenCredentials"/> used to authenticate requests.
        /// </param>
        internal FileConnectionOptions(TokenCredentials credentials)
            : base(credentials)
        {
        }
    }
}
