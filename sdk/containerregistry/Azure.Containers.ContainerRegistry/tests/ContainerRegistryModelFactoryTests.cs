// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Containers.ContainerRegistry;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ContainerRegistryModelFactory"/> class.
    /// </summary>
    public class ContainerRegistryModelFactoryTests
    {
        [Test]
        public void CanMockArtifactManifestProperties()
        {
            string registryLoginServer = "example.azurecr.io";
            string repositoryName = "library/hello-world";
            string digest = "sha256:99046890ddae9f4f4a89a33e7a20401eda44513839cfcceb08f368e77444d9fe";
            long size = 1024;
            DateTimeOffset createdOn = new DateTimeOffset(new DateTime(2020, 06, 30));
            DateTimeOffset lastUpdatedOn = new DateTimeOffset(new DateTime(2020, 08, 30));
            ArtifactArchitecture architecture = ArtifactArchitecture.Arm64;
            ArtifactOperatingSystem os = ArtifactOperatingSystem.Linux;
            IReadOnlyList<string> tags = (new List<string> { "v1", "latest" }).AsReadOnly();
            bool canDelete = false;
            bool canWrite = false;
            bool canList = true;
            bool canRead = true;

            var manifestProperties = ContainerRegistryModelFactory.ArtifactManifestProperties(
                registryLoginServer,
                repositoryName,
                digest,
                size,
                createdOn,
                lastUpdatedOn,
                architecture,
                os,
                manifestReferences: null,
                tags,
                canDelete,
                canWrite,
                canList,
                canRead);

            Assert.AreEqual(registryLoginServer, manifestProperties.RegistryLoginServer);
            Assert.AreEqual(repositoryName, manifestProperties.RepositoryName);
            Assert.AreEqual(digest, manifestProperties.Digest);
            Assert.AreEqual(size, manifestProperties.Size);
            Assert.AreEqual(createdOn, manifestProperties.CreatedOn);
            Assert.AreEqual(lastUpdatedOn, manifestProperties.LastUpdatedOn);
            Assert.AreEqual(architecture, manifestProperties.Architecture);
            Assert.AreEqual(os, manifestProperties.OperatingSystem);
            Assert.AreEqual(null, manifestProperties.ManifestReferences);
            CollectionAssert.AreEqual(tags, manifestProperties.Tags);
            Assert.AreEqual(canDelete, manifestProperties.CanDelete);
            Assert.AreEqual(canWrite, manifestProperties.CanWrite);
            Assert.AreEqual(canList, manifestProperties.CanList);
            Assert.AreEqual(canRead, manifestProperties.CanRead);
        }

        [Test]
        public void CanMockArtifactManifestReference()
        {
            string digest = "sha256:99046890ddae9f4f4a89a33e7a20401eda44513839cfcceb08f368e77444d9fe";
            ArtifactArchitecture architecture = ArtifactArchitecture.Arm64;
            ArtifactOperatingSystem os = ArtifactOperatingSystem.Linux;

            var manifestReference = ContainerRegistryModelFactory.ArtifactManifestReference(
                digest,
                architecture,
                os);

            Assert.AreEqual(digest, manifestReference.Digest);
            Assert.AreEqual(architecture, manifestReference.Architecture);
            Assert.AreEqual(os, manifestReference.OperatingSystem);
        }
    }
}
