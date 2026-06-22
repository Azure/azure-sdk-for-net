// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the DscpConfigurationData type. </summary>
    public partial class DscpConfigurationData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.QosIPRange> DestinationIPRanges { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.QosIPRange>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.QosIPRange> SourceIPRanges { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.QosIPRange>();
    }
}
