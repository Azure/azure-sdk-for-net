// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.StorageDiscovery.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageDiscovery.Tests
{
    public class CapabilitySerializationTests
    {
        private static readonly ModelReaderWriterOptions s_wireOptions = new("W");

        [Test]
        public void SerializeAzureBlobStorageCapability()
        {
            var capability = new AzureBlobStorageCapability(CapabilityStatus.Enabled);
            capability.PrefixConfigurations.Add(new PrefixConfiguration("storageaccount", "container") { Prefix = "logs" });

            BinaryData payload = ModelReaderWriter.Write(capability, s_wireOptions);

            Assert.That(payload.ToString(), Is.EqualTo("{\"capacityDetails\":{\"status\":\"Enabled\"},\"prefixConfigurations\":[{\"storageAccountName\":\"storageaccount\",\"containerName\":\"container\",\"prefix\":\"logs\"}]}"));
        }

        [Test]
        public void SerializeAzureBlobStorageCapabilityPatch()
        {
            var capability = new AzureBlobStorageCapabilityPatch { CapacityDetailsStatus = CapabilityStatus.Disabled };
            capability.PrefixConfigurations.Add(new AzureBlobStoragePrefixConfigurationPatch
            {
                StorageAccountName = "storageaccount",
                ContainerName = "container",
                Prefix = "archive"
            });

            BinaryData payload = ModelReaderWriter.Write(capability, s_wireOptions);

            Assert.That(payload.ToString(), Is.EqualTo("{\"capacityDetails\":{\"status\":\"Disabled\"},\"prefixConfigurations\":[{\"storageAccountName\":\"storageaccount\",\"containerName\":\"container\",\"prefix\":\"archive\"}]}"));
        }
    }
}
