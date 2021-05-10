// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Manifest attributes details. </summary>
    public partial class ArtifactManifestProperties
    {
        internal ArtifactManifestProperties(string digest, ArtifactArchitecture architecture, ArtifactOperatingSystem operatingSystem)
        {
            this.Digest = digest;
            this.Architecture = architecture;
            this.OperatingSystem = operatingSystem;
        }

        /// <summary> List of manifest attributes details. </summary>
        internal IReadOnlyList<ManifestAttributesManifestReferences> References { get; }

        /// <summary></summary>
        public IReadOnlyList<ArtifactManifestProperties> Manifests
        {
            get
            {
                List<ArtifactManifestProperties> artifacts = new List<ArtifactManifestProperties>(this.References.Count);

                foreach (var reference in this.References)
                {
                    artifacts.Add(FromManifestAttributesManifestReferences(reference));
                }

                return artifacts.AsReadOnly();
            }
        }

        internal static ArtifactManifestProperties FromManifestAttributesManifestReferences(ManifestAttributesManifestReferences reference)
        {
            return new ArtifactManifestProperties(
                reference.Digest,
                reference.Architecture,
                reference.OperatingSystem);
        }
    }
}
