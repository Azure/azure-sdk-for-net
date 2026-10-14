// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class VirtualWanSecurityProvider
    {
        // Restore the original native name and retain the migration name over the same storage.
        /// <summary> Gets the security provider type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, use ProviderType instead", false)]
        public VirtualWanSecurityProviderType? Type => ProviderType;
    }
}
