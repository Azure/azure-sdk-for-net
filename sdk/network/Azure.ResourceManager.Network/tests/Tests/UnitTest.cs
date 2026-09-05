// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class UnitTest
    {
        // This is the test for fix of issue: https://github.com/Azure/azure-sdk-for-net/issues/46767
        [Test]
        public void DeserializeChangeNumber()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ServiceTags.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = AzureFirewallIPGroups.DeserializeAzureFirewallIPGroups(jsonContent.RootElement, ModelReaderWriterOptions.Json);
            Assert.NotNull(data.ChangeNumber);
        }

        // Regression test for ManagedRuleSetRuleGroup deserialization with mixed string/number rule IDs
        [Test]
        public void DeserializeManagedRuleSetRuleGroupWithMixedRuleTypes()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ManagedRuleSetRuleGroup.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = ManagedRuleSetRuleGroup.DeserializeManagedRuleSetRuleGroup(jsonContent.RootElement, ModelReaderWriterOptions.Json);

            Assert.NotNull(data.Rules);
            Assert.AreEqual(6, data.Rules.Count);

            // Verify that both string and numeric rule IDs are properly converted to strings
            Assert.AreEqual("920100", data.Rules[0]); // Originally string
            Assert.AreEqual("920110", data.Rules[1]); // Originally number
            Assert.AreEqual("920120", data.Rules[2]); // Originally string
            Assert.AreEqual("920130", data.Rules[3]); // Originally number
            Assert.AreEqual("920140", data.Rules[4]); // Originally string
            Assert.AreEqual("920150", data.Rules[5]); // Originally number
        }

        [Test]
        public void ApplicationGatewaySslCertificateSerializesLegacyBinaryDataOnce()
        {
            byte[] pfxContent = new byte[] { 0x30, 0x82, 0x01, 0x02, 0x00, 0xFF };
            var applicationGateway = new ApplicationGatewayData();
            applicationGateway.SslCertificates.Add(new ApplicationGatewaySslCertificate
            {
                Data = BinaryData.FromObjectAsJson(Convert.ToBase64String(pfxContent)),
                Password = "password"
            });

            BinaryData wire = ModelReaderWriter.Write(applicationGateway, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetworkContext.Default);

            using JsonDocument document = JsonDocument.Parse(wire);
            string serializedData = document.RootElement
                .GetProperty("properties")
                .GetProperty("sslCertificates")[0]
                .GetProperty("properties")
                .GetProperty("data")
                .GetString();
            CollectionAssert.AreEqual(pfxContent, Convert.FromBase64String(serializedData));
        }

        [Test]
        public void ApplicationGatewaySslCertificateDeserializationPreservesLegacyBinaryData()
        {
            BinaryData wire = BinaryData.FromString("""
                {
                  "properties": {
                    "data": "AQID",
                    "password": "password"
                  }
                }
                """);

            ApplicationGatewaySslCertificate certificate = ModelReaderWriter.Read<ApplicationGatewaySslCertificate>(wire, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetworkContext.Default);

            using JsonDocument document = JsonDocument.Parse(certificate.Data);
            Assert.AreEqual("AQID", document.RootElement.GetString());
        }

        [Test]
        public void ApplicationGatewaySslCertificateSerializesRawBytes()
        {
            var certificate = new ApplicationGatewaySslCertificate
            {
                Data = BinaryData.FromBytes(new byte[] { 1, 2, 3 }),
                Password = "password"
            };

            BinaryData wire = ModelReaderWriter.Write(certificate, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetworkContext.Default);

            using JsonDocument document = JsonDocument.Parse(wire);
            Assert.AreEqual("AQID", document.RootElement.GetProperty("properties").GetProperty("data").GetString());
        }
    }
}
