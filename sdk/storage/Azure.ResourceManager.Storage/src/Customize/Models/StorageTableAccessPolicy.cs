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
        /// <summary> The deleted date. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? ExpiresOn
        {
            get
            {
                return ExpireOn;
            }
            set
            {
                ExpireOn = value;
            }
        }
    }
}
