// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Properties of the SBOM component for a CVE. </summary>
    public partial class CveComponent
    {
        /// <summary> ID of the SBOM component. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ComponentId { get; set; }
        /// <summary> Name of the SBOM component. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; set; }
        /// <summary> Version of the SBOM component. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Version { get; set; }
    }
}
