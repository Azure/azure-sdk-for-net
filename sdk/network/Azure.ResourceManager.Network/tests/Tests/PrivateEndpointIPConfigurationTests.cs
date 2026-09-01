// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class PrivateEndpointIPConfigurationTests
    {
        private const string PrivateIPAddressValue = "10.80.1.10";

        [Test]
        public void PrivateIPAddressSerializesToProperties()
        {
            var configuration = new PrivateEndpointIPConfiguration
            {
                Name = "ipconfig1",
                PrivateIPAddress = IPAddress.Parse(PrivateIPAddressValue)
            };

            BinaryData serialized = ModelReaderWriter.Write(configuration, ModelReaderWriterOptions.Json);
            using JsonDocument document = JsonDocument.Parse(serialized);

            Assert.AreEqual(
                PrivateIPAddressValue,
                document.RootElement.GetProperty("properties").GetProperty("privateIPAddress").GetString());
        }

        [Test]
        public void PrivateIPAddressDeserializesFromProperties()
        {
            var configuration = ModelReaderWriter.Read<PrivateEndpointIPConfiguration>(
                BinaryData.FromString($"{{\"properties\":{{\"privateIPAddress\":\"{PrivateIPAddressValue}\"}}}}"),
                ModelReaderWriterOptions.Json);

            Assert.AreEqual(IPAddress.Parse(PrivateIPAddressValue), configuration.PrivateIPAddress);
        }

        [Test]
        public void CompatibilityModelFactoryPreservesPrivateIPAddress()
        {
            IPAddress privateIPAddress = IPAddress.Parse(PrivateIPAddressValue);

            PrivateEndpointIPConfiguration configuration = ArmNetworkModelFactory.PrivateEndpointIPConfiguration(
                name: "ipconfig1",
                privateEndpointIPConfigurationType: "Microsoft.Network/privateEndpoints/ipConfigurations",
                privateIPAddress: privateIPAddress);

            Assert.AreEqual(privateIPAddress, configuration.PrivateIPAddress);

            BinaryData serialized = ModelReaderWriter.Write(configuration, ModelReaderWriterOptions.Json);
            using JsonDocument document = JsonDocument.Parse(serialized);
            Assert.AreEqual(
                PrivateIPAddressValue,
                document.RootElement.GetProperty("properties").GetProperty("privateIPAddress").GetString());
        }
    }
}
