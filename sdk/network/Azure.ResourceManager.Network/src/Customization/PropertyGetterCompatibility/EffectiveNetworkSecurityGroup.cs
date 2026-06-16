// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("TagMap")]
    public partial class EffectiveNetworkSecurityGroup
    {
        [Azure.ResourceManager.Network.WirePath("tagMap")]
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public string TagMap { get; }

        public global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Collections.Generic.IList<global::System.String>> TagToIPAddresses => default;
    }
}
