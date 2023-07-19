// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An Access policy for Blob Containers.
    /// </summary>
    [CodeGenModel("AccessPolicy")]
    public partial class BlobAccessPolicy
    {
        /// <summary>
        /// the date-time the policy is active.
        /// </summary>
        [CodeGenMember("Start")]
        public DateTimeOffset? PolicyStartsOn { get; set; }

        /// <summary>
        /// the date-time the policy expires.
        /// </summary>
        [CodeGenMember("Expiry")]
        public DateTimeOffset? PolicyExpiresOn { get; set; }

        /// <summary>
        /// The permissions for the acl policy.
        /// </summary>
        [CodeGenMember("Permission")]
        public string Permissions { get; set; }

        /// <summary>
        /// The date-time the policy is active.
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
        /// The date-time the policy expires.
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
    }
}
