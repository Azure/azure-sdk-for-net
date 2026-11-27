// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.KeyVault.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    public class ManagedHsmNetworkRuleSetTests
    {
        [TestCase("IPv4")]
        [TestCase("DualStack")]
        [TestCase("FutureAddressType")]
        public void PublicNetworkIPAddressTypeRoundTrips(string addressType)
        {
            var rules = new ManagedHsmNetworkRuleSet
            {
                PublicNetworkIPAddressType = new MhsmPublicNetworkIPAddressType(addressType)
            };

            BinaryData data = ModelReaderWriter.Write(rules, ModelReaderWriterOptions.Json);
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.AreEqual(addressType, document.RootElement.GetProperty("publicNetworkIpAddressType").GetString());

            ManagedHsmNetworkRuleSet result = ModelReaderWriter.Read<ManagedHsmNetworkRuleSet>(data, ModelReaderWriterOptions.Json);
            Assert.AreEqual(addressType, result.PublicNetworkIPAddressType.Value.ToString());
        }

        [Test]
        public void UnspecifiedPublicNetworkIPAddressTypeIsOmitted()
        {
            BinaryData data = ModelReaderWriter.Write(new ManagedHsmNetworkRuleSet(), ModelReaderWriterOptions.Json);
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.IsFalse(document.RootElement.TryGetProperty("publicNetworkIpAddressType", out _));

            ManagedHsmNetworkRuleSet result = ModelReaderWriter.Read<ManagedHsmNetworkRuleSet>(data, ModelReaderWriterOptions.Json);
            Assert.IsNull(result.PublicNetworkIPAddressType);
        }
    }
}
