// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerRegistry.Tests
{
    public class ModelFactoryCompatibilityTests
    {
        [TestCase("mcr.microsoft.com")]
        [TestCase("https://MCR.microsoft.com/path")]
        [TestCase("")]
        [TestCase(null)]
        public void LegacyImportSourceFactoryPreservesArguments(string registryAddress)
        {
            var resourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ContainerRegistry/registries/source");
            var credentials = ArmContainerRegistryModelFactory.ContainerRegistryImportSourceCredentials("username", "password");

            var source = ArmContainerRegistryModelFactory.ContainerRegistryImportSource(
                resourceId, registryAddress, credentials, "repository:tag");

            Assert.That(source.ResourceId, Is.EqualTo(resourceId));
            Assert.That(source.RegistryAddress, Is.EqualTo(registryAddress));
            Assert.That(source.Credentials, Is.SameAs(credentials));
            Assert.That(source.SourceImage, Is.EqualTo("repository:tag"));
        }

        [Test]
        public void LegacyImportSourceFactoryMapsAbsoluteAddressToCurrentWireModel()
        {
            const string address = "https://mcr.microsoft.com/";
            var source = ArmContainerRegistryModelFactory.ContainerRegistryImportSource(
                null, address, null, "repository:tag");

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(source));
            Assert.That(json.RootElement.GetProperty("registryUri").GetString(), Is.EqualTo(address));
            Assert.That(json.RootElement.TryGetProperty("registryAddress", out _), Is.False);
        }

        [Test]
        public void CurrentImportSourceFactoryStillUsesRegistryUri()
        {
            var uri = new Uri("https://mcr.microsoft.com/");
            var source = ArmContainerRegistryModelFactory.ContainerRegistryImportSource(registryUri: uri);

#pragma warning disable CS0618 // The URI property remains the current generated representation.
            Assert.That(source.RegistryUri, Is.EqualTo(uri));
#pragma warning restore CS0618
            Assert.That(source.RegistryAddress, Is.EqualTo(uri.OriginalString));
        }
    }
}
