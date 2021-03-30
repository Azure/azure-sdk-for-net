// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Manifest attributes details. </summary>
    public partial class RegistryArtifactProperties
    {
        internal RegistryArtifactProperties(string digest, string architecture, string operatingSystem)
        {
            this.Digest = digest;
            this.CpuArchitecture = architecture;
            this.OperatingSystem = operatingSystem;
        }

        /// <summary> List of manifest attributes details. </summary>
        internal IReadOnlyList<ManifestAttributesManifestReferences> References { get; }

        /// <summary></summary>
        public IReadOnlyList<RegistryArtifactProperties> RegistryArtifacts
        {
            get
            {
                List<RegistryArtifactProperties> artifacts = new List<RegistryArtifactProperties>();

                foreach (var reference in this.References)
                {
                    artifacts.Add(FromManifestAttributesManifestReferences(reference));
                }

                return artifacts.AsReadOnly();
            }
        }

        internal static RegistryArtifactProperties FromManifestAttributesManifestReferences(ManifestAttributesManifestReferences reference)
        {
            return new RegistryArtifactProperties(
                reference.Digest,
                reference.CpuArchitecture,
                reference.OperatingSystem);
        }
    }
}
