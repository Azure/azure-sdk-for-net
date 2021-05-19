// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Helps mock the types in Azure.Containers.ContainerRegistry.
    /// </summary>
    public static partial class ContainerRegistryModelFactory
    {
        /// <summary> Initializes a new instance of ArtifactManifestProperties. </summary>
        /// <param name="registryLoginServer"> Registry login server name.  This is likely to be similar to {registry-name}.azurecr.io. </param>
        /// <param name="repositoryName"> Repository name. </param>
        /// <param name="digest"> Manifest. </param>
        /// <param name="size"> Image size. </param>
        /// <param name="createdOn"> Created time. </param>
        /// <param name="lastUpdatedOn"> Last update time. </param>
        /// <param name="architecture"> CPU architecture. </param>
        /// <param name="operatingSystem"> Operating system. </param>
        /// <param name="manifestReferences"> List of manifests referenced by this manifest list.  List will be empty if this manifest is not a manifest list. </param>
        /// <param name="tags"> List of tags. </param>
        /// <param name="canDelete"> Delete enabled. </param>
        /// <param name="canWrite"> Write enabled. </param>
        /// <param name="canList"> List enabled. </param>
        /// <param name="canRead"> Read enabled. </param>
        /// <returns> A new ArtifactManifestProperties instance for mocking. </returns>
        public static ArtifactManifestProperties ArtifactManifestProperties(
            string registryLoginServer,
            string repositoryName,
            string digest,
            long? size,
            DateTimeOffset createdOn,
            DateTimeOffset lastUpdatedOn,
            ArtifactArchitecture? architecture,
            ArtifactOperatingSystem? operatingSystem,
            IReadOnlyList<ArtifactManifestReference> manifestReferences,
            IReadOnlyList<string> tags,
            bool? canDelete,
            bool? canWrite,
            bool? canList,
            bool? canRead)
            => new ArtifactManifestProperties(registryLoginServer, repositoryName, digest, size, createdOn, lastUpdatedOn, architecture, operatingSystem, manifestReferences, tags, canDelete, canWrite, canList, canRead, quarantineState: string.Empty, quarantineDetails: string.Empty);

        /// <summary> Initializes a new instance of ArtifactManifestReference. </summary>
        /// <param name="digest"> Manifest digest. </param>
        /// <param name="architecture"> CPU architecture. </param>
        /// <param name="operatingSystem"> Operating system. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="digest"/> is null. </exception>
        /// <returns> A new ArtifactManifestReference instance for mocking. </returns>
        public static ArtifactManifestReference ArtifactManifestReference(string digest, ArtifactArchitecture architecture, ArtifactOperatingSystem operatingSystem)
            => new ArtifactManifestReference(digest, architecture, operatingSystem);

        /// <summary> Initializes a new instance of ArtifactTagProperties. </summary>
        /// <param name="registryLoginServer"> Registry login server name.  This is likely to be similar to {registry-name}.azurecr.io. </param>
        /// <param name="repositoryName"> Image name. </param>
        /// <param name="name"> Tag name. </param>
        /// <param name="digest"> Tag digest. </param>
        /// <param name="createdOn"> Tag created time. </param>
        /// <param name="lastUpdatedOn"> Tag last update time. </param>
        /// <param name="canDelete"> Delete enabled. </param>
        /// <param name="canWrite"> Write enabled. </param>
        /// <param name="canList"> List enabled. </param>
        /// <param name="canRead"> Read enabled. </param>
        /// /// <returns> A new ArtifactTagProperties instance for mocking. </returns>
        public static ArtifactTagProperties ArtifactTagProperties(
            string registryLoginServer,
            string repositoryName,
            string name,
            string digest,
            DateTimeOffset createdOn,
            DateTimeOffset lastUpdatedOn,
            bool? canDelete,
            bool? canWrite,
            bool? canList,
            bool? canRead)
            => new ArtifactTagProperties(registryLoginServer, repositoryName, name, digest, createdOn, lastUpdatedOn, canDelete, canWrite, canList, canRead);

        /// <summary> Initializes a new instance of RepositoryProperties. </summary>
        /// <param name="registryLoginServer"> Registry login server name.  This is likely to be similar to {registry-name}.azurecr.io. </param>
        /// <param name="name"> Image name. </param>
        /// <param name="createdOn"> Image created time. </param>
        /// <param name="lastUpdatedOn"> Image last update time. </param>
        /// <param name="manifestCount"> Number of the manifests. </param>
        /// <param name="tagCount"> Number of the tags. </param>
        /// <param name="canDelete"> Delete enabled. </param>
        /// <param name="canWrite"> Write enabled. </param>
        /// <param name="canList"> List enabled. </param>
        /// <param name="canRead"> Read enabled. </param>
        /// <param name="teleportEnabled"> Enables Teleport functionality on new images in the repository improving Container startup performance. </param>
        /// <returns> A new RepositoryProperties instance for mocking. </returns>
        public static RepositoryProperties RepositoryProperties(
            string registryLoginServer,
            string name,
            DateTimeOffset createdOn,
            DateTimeOffset lastUpdatedOn,
            int manifestCount,
            int tagCount,
            bool? canDelete,
            bool? canWrite,
            bool? canList,
            bool? canRead,
            bool? teleportEnabled)
            => new RepositoryProperties(registryLoginServer, name, createdOn, lastUpdatedOn, manifestCount, tagCount, canDelete, canWrite, canList, canRead, teleportEnabled);
    }
}
