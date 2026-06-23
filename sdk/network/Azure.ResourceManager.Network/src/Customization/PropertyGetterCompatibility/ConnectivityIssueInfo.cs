// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ConnectivityIssueInfo type. </summary>
    public partial class ConnectivityIssueInfo
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.ConnectivityIssueType> ConnectivityIssueType { get; }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::System.Collections.Generic.IDictionary<global::System.String, global::System.String>> Contexts { get; } = new global::System.Collections.Generic.List<global::System.Collections.Generic.IDictionary<global::System.String, global::System.String>>();
    }
}
