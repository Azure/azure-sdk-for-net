// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.RedisEnterprise.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.RedisEnterprise.Tests
{
    public class PreviewModelSerializationTests
    {
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");

        [Test]
        public void PreviousClusterFactoryOverloadsPreserveMetadataAndOmitFirewallRules()
        {
            var cluster = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(
                default, default, default, default, default, default, default, default,
                "target.eastus.redis.azure.net", default, default, default, default, default,
                "source.eastus.redisenterprise.cache.azure.net:10000", default, default, default,
                default, default, default, default);
            var patch = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                default, default, default, "target.eastus.redis.azure.net", default, default,
                default, default, default, "source.eastus.redisenterprise.cache.azure.net:10000",
                default, default, default, default, default);

            Assert.AreEqual("target.eastus.redis.azure.net", cluster.HostName);
            Assert.AreEqual("source.eastus.redisenterprise.cache.azure.net:10000", cluster.MigratedEndpoint);
            Assert.AreEqual("target.eastus.redis.azure.net", patch.HostName);
            Assert.AreEqual("source.eastus.redisenterprise.cache.azure.net:10000", patch.MigratedEndpoint);
            Assert.IsNotNull(cluster.FirewallRules);
            Assert.IsEmpty(cluster.FirewallRules);
            Assert.IsNotNull(patch.FirewallRules);
            Assert.IsEmpty(patch.FirewallRules);

            using JsonDocument clusterDocument = JsonDocument.Parse(
                ModelReaderWriter.Write(cluster, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            using JsonDocument patchDocument = JsonDocument.Parse(
                ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            Assert.IsFalse(clusterDocument.RootElement.GetProperty("properties").TryGetProperty("firewallRules", out _));
            Assert.IsFalse(patchDocument.RootElement.GetProperty("properties").TryGetProperty("firewallRules", out _));
        }

        [Test]
        public void PreviousPartialPositionalFactoryCallsPreserveHostName()
        {
            var cluster = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(
                default, default, default, default, default, default, default, default,
                "target.eastus.redis.azure.net");
            var patch = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                default, default, default, "target.eastus.redis.azure.net");

            Assert.AreEqual("target.eastus.redis.azure.net", cluster.HostName);
            Assert.AreEqual("target.eastus.redis.azure.net", patch.HostName);
        }

        [TestCase("203.0.113.1")]
        [TestCase("203.0.113.0/24")]
        [TestCase("AzureCloud")]
        public void ClusterFirewallRulesRoundTrip(string sourceAddressPrefix)
        {
            var data = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(
                location: AzureLocation.EastUS,
                sku: new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1),
                publicNetworkAccess: RedisEnterprisePublicNetworkAccess.Enabled,
                firewallRules: new[] { new FirewallRule("allow-source", sourceAddressPrefix) });

            BinaryData json = ModelReaderWriter.Write(data, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default);
            using JsonDocument document = JsonDocument.Parse(json);
            JsonElement rule = document.RootElement.GetProperty("properties").GetProperty("firewallRules")[0];
            Assert.AreEqual("allow-source", rule.GetProperty("name").GetString());
            Assert.AreEqual(sourceAddressPrefix, rule.GetProperty("sourceAddressPrefix").GetString());

            var result = ModelReaderWriter.Read<RedisEnterpriseClusterData>(json, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default);
            Assert.AreEqual(1, result.FirewallRules.Count);
            Assert.AreEqual("allow-source", result.FirewallRules[0].Name);
            Assert.AreEqual(sourceAddressPrefix, result.FirewallRules[0].SourceAddressPrefix);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ClusterDataFactoryDistinguishesOmittedAndClearedFirewallRules(bool clearRules)
        {
            var data = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(
                publicNetworkAccess: RedisEnterprisePublicNetworkAccess.Enabled,
                firewallRules: clearRules ? Array.Empty<FirewallRule>() : null);

            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(data, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            bool hasRules = document.RootElement.GetProperty("properties").TryGetProperty("firewallRules", out JsonElement rules);
            Assert.AreEqual(clearRules, hasRules);
            if (clearRules)
            {
                Assert.AreEqual(0, rules.GetArrayLength());
            }
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void ClusterPatchDistinguishesOmittedAndClearedFirewallRules(bool clearRules, bool useFactory)
        {
            var patch = useFactory
                ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                    publicNetworkAccess: RedisEnterprisePublicNetworkAccess.Enabled,
                    firewallRules: clearRules ? Array.Empty<FirewallRule>() : null)
                : new RedisEnterpriseClusterPatch
                {
                    PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
                };
            if (clearRules && !useFactory)
            {
                patch.FirewallRules.Clear();
            }

            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual("Enabled", properties.GetProperty("publicNetworkAccess").GetString());
            bool hasRules = properties.TryGetProperty("firewallRules", out JsonElement rules);
            Assert.AreEqual(clearRules, hasRules);
            if (clearRules)
            {
                Assert.AreEqual(0, rules.GetArrayLength());
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ClusterPatchSerializesReplacementFirewallRules(bool useFactory)
        {
            var patch = useFactory
                ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                    firewallRules: new[] { new FirewallRule("allow-subnet", "203.0.113.0/24") })
                : new RedisEnterpriseClusterPatch();
            if (!useFactory)
            {
                patch.FirewallRules.Add(new FirewallRule("allow-subnet", "203.0.113.0/24"));
            }

            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            JsonElement rules = document.RootElement.GetProperty("properties").GetProperty("firewallRules");
            Assert.AreEqual(1, rules.GetArrayLength());
            Assert.AreEqual("allow-subnet", rules[0].GetProperty("name").GetString());
            Assert.AreEqual("203.0.113.0/24", rules[0].GetProperty("sourceAddressPrefix").GetString());
        }

        [Test]
        public void AccessPolicyAssignmentSerializesCustomAccessStringWithoutPolicyName()
        {
            var data = new AccessPolicyAssignmentData
            {
                AccessString = "+@read ~cache:*",
                UserObjectId = Guid.Empty
            };

            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(data, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual("+@read ~cache:*", properties.GetProperty("accessString").GetString());
            Assert.IsFalse(properties.TryGetProperty("accessPolicyName", out _));
            Assert.AreEqual(Guid.Empty.ToString(), properties.GetProperty("user").GetProperty("objectId").GetString());
        }

        [Test]
        public void AccessPolicyAssignmentSerializesDefaultPolicyWithoutAccessString()
        {
            var data = new AccessPolicyAssignmentData
            {
                AccessPolicyName = "default",
                UserObjectId = Guid.Empty
            };

            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(data, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual("default", properties.GetProperty("accessPolicyName").GetString());
            Assert.IsFalse(properties.TryGetProperty("accessString", out _));
            Assert.AreEqual(Guid.Empty.ToString(), properties.GetProperty("user").GetProperty("objectId").GetString());
        }

        [Test]
        public void AccessPolicyAssignmentReadsProvisioningErrorWithoutSendingIt()
        {
            var json = BinaryData.FromString(
                "{\"properties\":{\"accessString\":\"invalid-acl\",\"provisioningError\":{\"code\":\"InvalidAccessString\",\"message\":\"Invalid ACL syntax.\",\"target\":\"properties.accessString\"},\"user\":{\"objectId\":\"00000000-0000-0000-0000-000000000000\"}}}");
            var data = ModelReaderWriter.Read<AccessPolicyAssignmentData>(json, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default);

            Assert.AreEqual("invalid-acl", data.AccessString);
            Assert.AreEqual("InvalidAccessString", data.ProvisioningError.Code);
            Assert.AreEqual("Invalid ACL syntax.", data.ProvisioningError.Message);
            Assert.AreEqual("properties.accessString", data.ProvisioningError.Target);

            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(data, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.IsFalse(properties.TryGetProperty("provisioningError", out _));
            Assert.AreEqual("invalid-acl", properties.GetProperty("accessString").GetString());
            Assert.AreEqual(Guid.Empty.ToString(), properties.GetProperty("user").GetProperty("objectId").GetString());
        }
    }
}
