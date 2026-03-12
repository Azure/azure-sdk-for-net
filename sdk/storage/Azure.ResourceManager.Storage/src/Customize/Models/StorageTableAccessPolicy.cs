// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Table Access Policy Properties Object. </summary>
    public partial class StorageTableAccessPolicy
    {
        /// <summary> Expiry time of the access policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("expiryTime")]
        public DateTimeOffset? ExpireOn
        {
            get => ExpiryOn;
            set => ExpiryOn = value;
        }

        /// <summary> The deleted date. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? ExpiresOn
        {
            get
            {
                return ExpiryOn;
            }
            set
            {
                ExpiryOn = value;
            }
        }
    }
}
