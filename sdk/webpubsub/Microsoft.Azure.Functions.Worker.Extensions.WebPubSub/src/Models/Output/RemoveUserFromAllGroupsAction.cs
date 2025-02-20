// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Operation to remove user from all groups.
    /// </summary>
    public sealed class RemoveUserFromAllGroupsAction : WebPubSubAction
    {
        /// <summary>
        /// Target UserId.
        /// </summary>
        public string UserId { get; set; }
    }
}
