// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueAccessPolicy.
    /// </summary>
    [CodeGenModel("AccessPolicy")]
    public partial class QueueAccessPolicy
    {
        /// <summary>
        /// The DateTimeOffset when the policy becomes active.
        /// </summary>
        [CodeGenMember("Start")]
        public DateTimeOffset? StartsOn { get; set; }

        /// <summary>
        /// The DateTimeOffset when the policy expires.
        /// </summary>
        [CodeGenMember("Expiry")]
        public DateTimeOffset? ExpiresOn { get; set; }

        /// <summary>
        /// The permissions for the acl policy.
        /// </summary>
        [CodeGenMember("Permission")]
        public string Permissions { get; set; }
    }
}
