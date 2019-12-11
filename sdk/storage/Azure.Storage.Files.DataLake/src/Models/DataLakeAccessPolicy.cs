// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// An Access policy.
    /// </summary>
    public class DataLakeAccessPolicy
    {
        /// <summary>
        /// The <see cref="DateTimeOffset"/> the policy becomes active.
        /// </summary>
        public DateTimeOffset StartsOn { get; set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> the policy expires.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; set; }

        /// <summary>
        /// The file permissions for the policy.
        /// </summary>
        public string Permissions { get; set; }
    }
}
