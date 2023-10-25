// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Operation to add a user to group.
    /// </summary>
    public sealed class AddUserToGroupAction : WebPubSubAction
    {
        /// <summary>
        /// Target userId.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Target group name.
        /// </summary>
        public string Group { get; set; }
    }
}
