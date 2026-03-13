// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden ExpireOn/ExpiresOn aliases for renamed expiry property.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageTableAccessPolicy
    {
        /// <summary> Backward-compatible alias for ExpireOn. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("expiryTime")]
        public DateTimeOffset? ExpiresOn
        {
            get => ExpireOn;
            set => ExpireOn = value;
        }
    }
}
