// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Share Access policy.
    /// </summary>
    [CodeGenModel("AccessPolicy")]
    public partial class ShareAccessPolicy
    {
        // TODO fix this.
//        /// <summary>
//        /// The date-time the policy is active.
//        /// This value is non-nullable, please use <see cref="PolicyStartsOn"/>.
//        /// </summary>
//        [EditorBrowsable(EditorBrowsableState.Never)]
//#pragma warning disable CA1822 // Mark members as static
//        public System.DateTimeOffset StartsOn
//#pragma warning restore CA1822 // Mark members as static
//        {
//            get
//            {
//                return PolicyStartsOn == default ?
//                    new DateTimeOffset() :
//                    PolicyStartsOn.Value;
//            }
//            set
//            {
//                PolicyStartsOn = value;
//            }
//        }

//        /// <summary>
//        /// The date-time the policy expires.
//        /// This value is non-nullable, please use <see cref="PolicyStartsOn"/>.
//        /// </summary>
//        [EditorBrowsable(EditorBrowsableState.Never)]
//#pragma warning disable CA1822 // Mark members as static
//        public System.DateTimeOffset ExpiresOn
//#pragma warning restore CA1822 // Mark members as static
//        {
//            get
//            {
//                return PolicyExpiresOn == default ?
//                    new DateTimeOffset() :
//                    PolicyExpiresOn.Value;
//            }
//            set
//            {
//                PolicyExpiresOn = value;
//            }
//        }
    }
}
