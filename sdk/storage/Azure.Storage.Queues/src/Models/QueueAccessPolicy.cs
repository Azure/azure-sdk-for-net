// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.ComponentModel;

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CodeGenMember("Permission")]
        public string Permissions
        {
            get => QueueAccessPolicyPermissions.ToPermissionsString();
            set => QueueAccessPolicyPermissions = value.ToPermissionsEnum();
        }

        /// <summary>
        /// To get/set the permissions enum for the queue access policy.
        /// </summary>
        [CodeGenMember("QueueAccessPolicyPermission")]
        public QueueAccessPolicyPermissions? QueueAccessPolicyPermissions { get; set; }
    }
}
