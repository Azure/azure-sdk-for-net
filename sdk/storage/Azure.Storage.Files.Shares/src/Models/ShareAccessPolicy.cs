// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Share Access policy.
    /// </summary>
    public partial class ShareAccessPolicy
    {
        /// <summary>
        /// The date-time the policy is active.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.DateTimeOffset StartsOn
        {
            get
            {
                return PolicyStartsOn == default ?
                    DateTimeOffset.MinValue :
                    (DateTimeOffset)PolicyStartsOn;
            }
            set
            {
                PolicyStartsOn = value;
            }
        }

        /// <summary>
        /// The date-time the policy expires.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.DateTimeOffset ExpiresOn
        {
            get
            {
                return PolicyExpiresOn == default ?
                    DateTimeOffset.MinValue :
                    (DateTimeOffset)PolicyExpiresOn;
            }
            set
            {
                PolicyExpiresOn = value;
            }
        }
    }
}
