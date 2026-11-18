// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct VpnAuthenticationType
    {
        // Both spellings shipped in 1.15.0; AAD was already obsolete and Aad was generated.
        // ApiCompat requires the released Obsolete arguments, including the incorrect message.
        // The correct replacement is Aad, not the unrelated TagToIPAddresses mentioned there.
        /// <summary> Compatibility alias for <see cref="Aad"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This value is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public static VpnAuthenticationType AAD => Aad;
    }
}
