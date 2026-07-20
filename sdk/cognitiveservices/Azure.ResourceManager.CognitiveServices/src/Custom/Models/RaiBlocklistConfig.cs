// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public partial class RaiBlocklistConfig
    {
        /// <summary> If blocking would occur. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("blocking")]
        public bool? Blocking { get => IsBlocking; set => IsBlocking = value; }
    }
}
