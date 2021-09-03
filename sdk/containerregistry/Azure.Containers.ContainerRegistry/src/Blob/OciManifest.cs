// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// A manifest for an OCI (Open Container Initiative) artifact.
    /// </summary>
    [CodeGenModel("OCIManifest")]
    public partial class OciManifest
    {
        /// <summary> Additional information provided through arbitrary metadata. </summary>
        public OciAnnotations Annotations { get; }

        /// <summary> Schema version. </summary>
        public int? SchemaVersion { get; set; }
    }
}
