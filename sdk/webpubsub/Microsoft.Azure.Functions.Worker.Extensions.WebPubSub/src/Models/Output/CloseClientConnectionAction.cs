// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Operation to close a connection.
    /// </summary>
    public sealed class CloseClientConnectionAction : WebPubSubAction
    {
        /// <summary>
        /// Target connectionId.
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// Reason to close the connection.
        /// </summary>
        public string Reason { get; set; }
    }
}
