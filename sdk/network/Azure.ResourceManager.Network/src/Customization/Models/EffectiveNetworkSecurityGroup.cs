// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class EffectiveNetworkSecurityGroup
    {
        /// <summary> Mapping of tags to list of IP Addresses included within the tag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use TagDict instead", false)]
        public string TagMap { get; }
    }
}
