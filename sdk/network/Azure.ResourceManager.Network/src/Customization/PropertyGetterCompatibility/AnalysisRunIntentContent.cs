// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the AnalysisRunIntentContent type. </summary>
    [CodeGenSuppress("IPTraffic")]
    public partial class AnalysisRunIntentContent
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.NetworkVerifierIPTraffic IPTraffic { get; set; }
    }
}
