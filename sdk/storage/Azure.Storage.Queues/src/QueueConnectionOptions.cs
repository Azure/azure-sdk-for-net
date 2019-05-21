// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Queue
    /// Storage
    /// </summary>
    public class QueueConnectionOptions : StorageConnectionOptions
    {
        /// <summary>
        /// Construct the default options for making service requests that
        /// don't require authentication.
        /// </summary>
        public QueueConnectionOptions()
            : base()
        {
        }

        /// <summary>
        /// Construct options for making service requests signed with an Azure
        /// Queue Storage shared key.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="SharedKeyCredentials"/> used to sign requests.
        /// </param>
        public QueueConnectionOptions(SharedKeyCredentials credentials)
            : base(credentials)
        {
        }

        /// <summary>
        /// Construct options for making service requests authenticated with
        /// Azure token credentials.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="TokenCredentials"/> used to authenticate requests.
        /// </param>
        internal QueueConnectionOptions(TokenCredentials credentials)
            : base(credentials)
        {
        }
    }
}
