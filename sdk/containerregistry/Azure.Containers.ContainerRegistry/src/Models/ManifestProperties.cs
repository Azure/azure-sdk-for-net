// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Manifest attributes details. </summary>
    [CodeGenModel("RegistryArtifactProperties")]
    public partial class ManifestProperties
    {
        internal ManifestProperties(string digest, string architecture, string operatingSystem)
        {
            this.Digest = digest;
            this.CpuArchitecture = architecture;
            this.OperatingSystem = operatingSystem;
        }

        /// <summary> List of manifest attributes details. </summary>
        internal IReadOnlyList<ManifestAttributesManifestReferences> References { get; }

        /// <summary></summary>
        public IReadOnlyList<ManifestProperties> RegistryArtifacts
        {
            get
            {
                List<ManifestProperties> artifacts = new List<ManifestProperties>();

                foreach (var reference in this.References)
                {
                    artifacts.Add(FromManifestAttributesManifestReferences(reference));
                }

                return artifacts.AsReadOnly();
            }
        }

        internal static ManifestProperties FromManifestAttributesManifestReferences(ManifestAttributesManifestReferences reference)
        {
            return new ManifestProperties(
                reference.Digest,
                reference.CpuArchitecture,
                reference.OperatingSystem);
        }
    }
}
