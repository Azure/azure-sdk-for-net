// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageServiceAccessPolicy
    {
        /// <summary> Backward-compatible alias for ExpiryOn. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("expiryTime")]
        public DateTimeOffset? ExpireOn
        {
            get => ExpiryOn;
            set => ExpiryOn = value;
        }
    }
}
