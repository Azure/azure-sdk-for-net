// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class BatchStringPropertyTests
    {
        [Test]
        public void RegistryServerRoundTripsAsString(
            [Values("docker.io", "myregistry.azurecr.io", "myregistry.azurecr.io:5000", "https://myregistry.azurecr.io/path", "")] string server,
            [Values("J", "W")] string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var registry = new ContainerRegistryReference { RegistryServerUri = server };

            BinaryData data = ModelReaderWriter.Write(registry, options);
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.AreEqual(server, document.RootElement.GetProperty("registryServer").GetString());
            ContainerRegistryReference restored = ModelReaderWriter.Read<ContainerRegistryReference>(data, options);
            Assert.AreEqual(server, restored.RegistryServerUri);
            Assert.AreEqual(server, ComputeBatchModelFactory.ContainerRegistryReference(registryServerUri: server).RegistryServerUri);
        }

        [Test]
        public void RegistryServerCanBeOmitted()
        {
            BinaryData data = ModelReaderWriter.Write(new ContainerRegistryReference());
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.IsFalse(document.RootElement.TryGetProperty("registryServer", out _));
            Assert.IsNull(ModelReaderWriter.Read<ContainerRegistryReference>(data).RegistryServerUri);
        }

        [Test]
        public void InboundAddressRoundTripsAsString(
            [Values("192.0.2.1", "2001:0db8:0:0:0:0:0:1", "service-defined-address", "")] string address,
            [Values("J", "W")] string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var endpoint = ComputeBatchModelFactory.InboundEndpoint(
                name: "endpoint",
                protocol: new InboundEndpointProtocol("tcp"),
                publicIpAddress: address,
                publicFqdn: "node.example",
                frontendPort: 443,
                backendPort: 443);

            BinaryData data = ModelReaderWriter.Write(endpoint, options);
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.AreEqual(address, document.RootElement.GetProperty("publicIPAddress").GetString());
            InboundEndpoint restored = ModelReaderWriter.Read<InboundEndpoint>(data, options);
            Assert.AreEqual(address, restored.PublicIpAddress);
        }

        [Test]
        public void PublicPropertiesUseStrings()
        {
            Assert.AreEqual(typeof(string), typeof(ContainerRegistryReference).GetProperty(nameof(ContainerRegistryReference.RegistryServerUri)).PropertyType);
            Assert.AreEqual(typeof(string), typeof(InboundEndpoint).GetProperty(nameof(InboundEndpoint.PublicIpAddress)).PropertyType);
        }
    }
}
