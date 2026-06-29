// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the NextHopResult type. </summary>
    [CodeGenSuppress("NextHopIPAddress")]
    public partial class NextHopResult
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String NextHopIPAddress { get; set; }
    }
}
