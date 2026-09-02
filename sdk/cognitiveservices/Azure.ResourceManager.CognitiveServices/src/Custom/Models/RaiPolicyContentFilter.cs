// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public partial class RaiPolicyContentFilter
    {
        /// <summary> If the ContentFilter is enabled. </summary>
        [WirePath("enabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enabled { get => IsEnabled; set => IsEnabled = value; }

        /// <summary> If blocking would occur. </summary>
        [WirePath("blocking")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Blocking { get => IsBlocking; set => IsBlocking = value; }
    }
}
