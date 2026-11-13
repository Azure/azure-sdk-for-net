// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class EffectiveNetworkSecurityGroup
    {
        // Preserve the unpopulated 1.15 compatibility getter; the generated
        // TagToIPAddresses dictionary owns the tagMap wire binding.
        /// <summary> Compatibility member. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public string TagMap { get; }
    }
}
