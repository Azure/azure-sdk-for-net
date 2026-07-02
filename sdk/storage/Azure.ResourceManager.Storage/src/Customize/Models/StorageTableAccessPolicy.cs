// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden ExpiresOn alias alongside the generated ExpireOn property.
// Old GA had both ExpireOn and ExpiresOn; @@clientName can only produce one name.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageTableAccessPolicy
    {
        // Backward-compatible alias for ExpireOn.
        /// <summary> The deleted date. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("expiryTime")]
        public DateTimeOffset? ExpiresOn
        {
            get => ExpireOn;
            set => ExpireOn = value;
        }
    }
}
