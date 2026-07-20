// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    public partial class AgentPoolSnapshotData : TrackedResourceData
    {
        /// <summary> Whether to use a FIPS-enabled OS. </summary>
        [WirePath("properties.enableFIPS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableFips => IsFipsEnabled;
    }
}
