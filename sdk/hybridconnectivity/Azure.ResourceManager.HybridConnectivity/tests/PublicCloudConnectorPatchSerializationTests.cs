// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.HybridConnectivity.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.HybridConnectivity.Tests
{
    public class PublicCloudConnectorPatchSerializationTests
    {
        [TestCase("J")]
        [TestCase("W")]
        public void DeserializeConnectorPatch(string format)
        {
            const string id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.HybridConnectivity/publicCloudConnectors/connector";
            BinaryData data = BinaryData.FromString($$"""
                {
                  "id": "{{id}}",
                  "name": "connector",
                  "type": "Microsoft.HybridConnectivity/publicCloudConnectors",
                  "systemData": { "createdBy": "creator" },
                  "tags": { "environment": "test", "nullable": null },
                  "properties": {
                    "awsCloudProfile": { "excludedAccounts": ["aws-account"] },
                    "gcpCloudProfile": {
                      "organizationProperties": {
                        "excludedProjectNumbers": ["123"],
                        "excludedFolderIds": ["456"]
                      }
                    }
                  },
                  "unknownProperty": { "value": 42 }
                }
                """);
            ModelReaderWriterOptions options = new(format);

            PublicCloudConnectorPatch patch = ModelReaderWriter.Read<PublicCloudConnectorPatch>(data, options, AzureResourceManagerHybridConnectivityContext.Default);

            Assert.AreEqual(id, patch.Id.ToString());
            Assert.AreEqual("connector", patch.Name);
            Assert.AreEqual("Microsoft.HybridConnectivity/publicCloudConnectors", patch.ResourceType.ToString());
            Assert.AreEqual("creator", patch.SystemData.CreatedBy);
            Assert.AreEqual("test", patch.Tags["environment"]);
            Assert.IsNull(patch.Tags["nullable"]);
            CollectionAssert.AreEqual(new[] { "aws-account" }, patch.Properties.AwsCloudExcludedAccounts);
            CollectionAssert.AreEqual(new[] { "aws-account" }, patch.AwsCloudExcludedAccounts);
            CollectionAssert.AreEqual(new[] { "123" }, patch.Properties.GcpCloudOrganizationProperties.ExcludedProjectNumbers);
            CollectionAssert.AreEqual(new[] { "456" }, patch.Properties.GcpCloudOrganizationProperties.ExcludedFolderIds);

            using JsonDocument serialized = JsonDocument.Parse(ModelReaderWriter.Write(patch, options, AzureResourceManagerHybridConnectivityContext.Default));
            JsonElement root = serialized.RootElement;
            Assert.AreEqual(format == "J", root.TryGetProperty("unknownProperty", out JsonElement unknownProperty));
            if (format == "J")
            {
                Assert.AreEqual(42, unknownProperty.GetProperty("value").GetInt32());
            }
            Assert.AreEqual("aws-account", root.GetProperty("properties").GetProperty("awsCloudProfile").GetProperty("excludedAccounts")[0].GetString());
            Assert.AreEqual("123", root.GetProperty("properties").GetProperty("gcpCloudProfile").GetProperty("organizationProperties").GetProperty("excludedProjectNumbers")[0].GetString());
        }

        [TestCase("J", "{}")]
        [TestCase("W", "{}")]
        [TestCase("J", """{"id":null,"type":null,"systemData":null,"tags":null,"properties":null}""")]
        [TestCase("W", """{"id":null,"type":null,"systemData":null,"tags":null,"properties":null}""")]
        public void DeserializeMissingOrNullProperties(string format, string json)
        {
            PublicCloudConnectorPatch patch = ModelReaderWriter.Read<PublicCloudConnectorPatch>(
                BinaryData.FromString(json), new ModelReaderWriterOptions(format), AzureResourceManagerHybridConnectivityContext.Default);

            Assert.IsNotNull(patch);
            Assert.IsNull(patch.Id);
            Assert.IsNull(patch.SystemData);
            Assert.IsEmpty(patch.Tags);
            Assert.IsNull(patch.Properties);
            Assert.IsEmpty(patch.AwsCloudExcludedAccounts);
            Assert.IsNotNull(patch.Properties);
        }
    }
}
