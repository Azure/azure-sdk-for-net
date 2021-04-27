// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Manifest attributes. </summary>
    internal partial class AcrManifests
    {
        /// <summary> List of manifests. </summary>
        public IReadOnlyList<RegistryArtifactProperties> RegistryArtifacts
        {
            get
            {
                List<RegistryArtifactProperties> artifacts = new List<RegistryArtifactProperties>();
                foreach (var artifact in this.Manifests)
                {
                    artifacts.Add(FromManifestAttributesBase(this.Repository, artifact));
                }
                return artifacts.AsReadOnly();
            }
        }

        internal static RegistryArtifactProperties FromManifestAttributesBase(string repository, ManifestAttributesBase attributesBase)
        {
            return new RegistryArtifactProperties(
                repository,
                attributesBase.Digest,
                attributesBase.Size,
                attributesBase.CreatedOn,
                attributesBase.LastUpdatedOn,
                attributesBase.CpuArchitecture,
                attributesBase.OperatingSystem,
                attributesBase.References,
                attributesBase.Tags,
                attributesBase.WriteableProperties);
        }
    }
}
