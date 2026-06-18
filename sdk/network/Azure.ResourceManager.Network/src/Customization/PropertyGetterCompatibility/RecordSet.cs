// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the RecordSet type. </summary>
    public partial class RecordSet
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::System.String> IPAddresses { get; } = new global::System.Collections.Generic.List<global::System.String>();
    }
}
