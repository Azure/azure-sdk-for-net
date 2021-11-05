// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

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
        public DateTimeOffset? PolicyStartsOn { get; set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> the policy expires.
        /// </summary>
        public DateTimeOffset? PolicyExpiresOn { get; set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> the policy becomes active.
        /// This value is non-nullable, please use <see cref="PolicyStartsOn"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.DateTimeOffset StartsOn
        {
            get
            {
                return PolicyStartsOn == default ?
                    new DateTimeOffset() :
                    PolicyStartsOn.Value;
            }
            set
            {
                PolicyStartsOn = value;
            }
        }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> the policy expires.
        /// This value is non-nullable, please use <see cref="PolicyExpiresOn"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.DateTimeOffset ExpiresOn
        {
            get
            {
                return PolicyExpiresOn == default ?
                    new DateTimeOffset() :
                    PolicyExpiresOn.Value;
            }
            set
            {
                PolicyExpiresOn = value;
            }
        }

        /// <summary>
        /// The file permissions for the policy.
        /// </summary>
        public string Permissions { get; set; }
    }
}
