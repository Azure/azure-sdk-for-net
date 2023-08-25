// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Operation to grant permission.
    /// </summary>
    public sealed class GrantPermissionAction : WebPubSubAction
    {
        /// <summary>
        /// Target connectionId.
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// Target permission.
        /// </summary>
        public WebPubSubPermission Permission { get; set; }

        /// <summary>
        /// Target name.
        /// </summary>
        public string TargetName { get; set; }
    }
}
