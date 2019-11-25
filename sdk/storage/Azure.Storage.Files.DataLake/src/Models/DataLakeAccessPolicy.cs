// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// An Access policy.
    /// </summary>
    public class DataLakeAccessPolicy
    {
        /// <summary>
        /// the date-time the policy is active.
        /// </summary>
        public System.DateTimeOffset StartsOn { get; set; }

        /// <summary>
        /// the date-time the policy expires.
        /// </summary>
        public System.DateTimeOffset ExpiresOn { get; set; }

        /// <summary>
        /// the permissions for the acl policy.
        /// </summary>
        public string Permissions { get; set; }
    }
}
