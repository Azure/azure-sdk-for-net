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
        public IReadOnlyList<ManifestProperties> RegistryArtifacts
        {
            get
            {
                List<ManifestProperties> artifacts = new List<ManifestProperties>();
                foreach (var artifact in this.Manifests)
                {
                    artifacts.Add(FromManifestAttributesBase(this.Repository, artifact));
                }
                return artifacts.AsReadOnly();
            }
        }

        internal static ManifestProperties FromManifestAttributesBase(string repository, ManifestAttributesBase attributesBase)
        {
            return new ManifestProperties(
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
