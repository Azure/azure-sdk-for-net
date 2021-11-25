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
        public IReadOnlyList<ArtifactManifestProperties> RegistryArtifacts
        {
            get
            {
                List<ArtifactManifestProperties> artifacts = new List<ArtifactManifestProperties>(this.Manifests.Count);
                foreach (var artifact in this.Manifests)
                {
                    artifacts.Add(FromManifestAttributesBase(this.RegistryLoginServer, this.Repository, artifact));
                }
                return artifacts.AsReadOnly();
            }
        }

        internal static ArtifactManifestProperties FromManifestAttributesBase(string registry, string repository, ManifestAttributesBase attributesBase)
        {
            return new ArtifactManifestProperties(
                registry,
                repository,
                attributesBase.Digest,
                attributesBase.Size,
                attributesBase.CreatedOn,
                attributesBase.LastUpdatedOn,
                attributesBase.Architecture,
                attributesBase.OperatingSystem,
                attributesBase.RelatedArtifacts,
                attributesBase.Tags,
                attributesBase.CanDelete,
                attributesBase.CanWrite,
                attributesBase.CanList,
                attributesBase.CanRead);
        }
    }
}
