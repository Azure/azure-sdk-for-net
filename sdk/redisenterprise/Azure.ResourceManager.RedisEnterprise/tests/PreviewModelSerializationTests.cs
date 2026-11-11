// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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

        [Test]
        public void PreviousFactoryCallsWithNullArgumentsStillOmitFirewallRules()
        {
            var cluster = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(null);
            var patch = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(null, null);
            Assert.IsEmpty(cluster.FirewallRules);
            Assert.IsEmpty(patch.FirewallRules);

            using JsonDocument clusterDocument = JsonDocument.Parse(
                ModelReaderWriter.Write(cluster, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            using JsonDocument patchDocument = JsonDocument.Parse(
                ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            Assert.IsFalse(clusterDocument.RootElement.GetProperty("properties").TryGetProperty("firewallRules", out _));
            Assert.IsFalse(patchDocument.RootElement.GetProperty("properties").TryGetProperty("firewallRules", out _));
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
                firewallRules: new[] { new RedisEnterpriseFirewallRule("allow-source", sourceAddressPrefix) });

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

        [Test]
        public void ClusterDataDistinguishesOmittedAndArrayFirewallRules(
            [Values(false, true)] bool useFactory,
            [Values("omitted", "empty", "populated")] string state,
            [Values("Enabled", "Disabled")] string publicNetworkAccess,
            [Values("W", "J")] string format)
        {
            var access = new RedisEnterprisePublicNetworkAccess(publicNetworkAccess);
            var data = useFactory
                ? state == "omitted"
                    ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(
                        location: AzureLocation.EastUS,
                        sku: new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1),
                        publicNetworkAccess: access)
                    : ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(
                        location: AzureLocation.EastUS,
                        sku: new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1),
                        publicNetworkAccess: access, firewallRules: CreateFirewallRules(state))
                : new RedisEnterpriseClusterData(
                    AzureLocation.EastUS, new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1))
                {
                    PublicNetworkAccess = access
                };
            if (!useFactory && state != "omitted")
            {
                data.FirewallRules.Clear();
                foreach (RedisEnterpriseFirewallRule rule in CreateFirewallRules(state))
                {
                    data.FirewallRules.Add(rule);
                }
            }

            var options = new ModelReaderWriterOptions(format);
            BinaryData json = ModelReaderWriter.Write(data, options, AzureResourceManagerRedisEnterpriseContext.Default);
            AssertFirewallRulesWireState(json, state, publicNetworkAccess);

            var result = ModelReaderWriter.Read<RedisEnterpriseClusterData>(
                json, options, AzureResourceManagerRedisEnterpriseContext.Default);
            Assert.IsNotNull(result.FirewallRules);
            AssertFirewallRulesWireState(
                ModelReaderWriter.Write(result, options, AzureResourceManagerRedisEnterpriseContext.Default),
                state, publicNetworkAccess);
        }

        [Test]
        public void ClusterPatchDistinguishesOmittedAndArrayFirewallRules(
            [Values(false, true)] bool useFactory,
            [Values("omitted", "empty", "populated")] string state,
            [Values("Enabled", "Disabled")] string publicNetworkAccess,
            [Values("W", "J")] string format)
        {
            var access = new RedisEnterprisePublicNetworkAccess(publicNetworkAccess);
            var patch = useFactory
                ? state == "omitted"
                    ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(publicNetworkAccess: access)
                    : ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                        publicNetworkAccess: access, firewallRules: CreateFirewallRules(state))
                : new RedisEnterpriseClusterPatch { PublicNetworkAccess = access };
            if (!useFactory && state != "omitted")
            {
                patch.FirewallRules.Clear();
                foreach (RedisEnterpriseFirewallRule rule in CreateFirewallRules(state))
                {
                    patch.FirewallRules.Add(rule);
                }
            }

            var options = new ModelReaderWriterOptions(format);
            BinaryData json = ModelReaderWriter.Write(patch, options, AzureResourceManagerRedisEnterpriseContext.Default);
            AssertFirewallRulesWireState(json, state, publicNetworkAccess);

            var result = ModelReaderWriter.Read<RedisEnterpriseClusterPatch>(
                json, options, AzureResourceManagerRedisEnterpriseContext.Default);
            Assert.IsNotNull(result.FirewallRules);
            AssertFirewallRulesWireState(
                ModelReaderWriter.Write(result, options, AzureResourceManagerRedisEnterpriseContext.Default),
                state, publicNetworkAccess);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ReadingFirewallRulesDoesNotDefineAnOmittedCollection(bool isPatch)
        {
            if (isPatch)
            {
                var patch = new RedisEnterpriseClusterPatch();
                Assert.AreEqual(0, patch.FirewallRules.Count);
                using JsonDocument document = JsonDocument.Parse(
                    ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
                Assert.IsFalse(document.RootElement.GetProperty("properties").TryGetProperty("firewallRules", out _));
            }
            else
            {
                var data = new RedisEnterpriseClusterData(
                    AzureLocation.EastUS, new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1));
                Assert.AreEqual(0, data.FirewallRules.Count);
                using JsonDocument document = JsonDocument.Parse(
                    ModelReaderWriter.Write(data, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
                Assert.IsFalse(document.RootElement.GetProperty("properties").TryGetProperty("firewallRules", out _));
            }
        }

        [TestCase(false, "clear")]
        [TestCase(true, "clear")]
        [TestCase(false, "remove-last")]
        [TestCase(true, "remove-last")]
        public void ExplicitlyEmptyFirewallRulesSerializeAnEmptyArray(bool isPatch, string action)
        {
            var data = new RedisEnterpriseClusterData(
                AzureLocation.EastUS, new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1));
            var patch = new RedisEnterpriseClusterPatch();
            IList<RedisEnterpriseFirewallRule> rules = isPatch ? patch.FirewallRules : data.FirewallRules;
            if (action == "clear")
            {
                rules.Clear();
            }
            else if (action == "remove-last")
            {
                var rule = new RedisEnterpriseFirewallRule("allow-ip", "203.0.113.1");
                rules.Add(rule);
                rules.Remove(rule);
            }

            BinaryData json = isPatch
                ? ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default)
                : ModelReaderWriter.Write(data, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default);
            using JsonDocument document = JsonDocument.Parse(
                json);
            Assert.AreEqual(0, document.RootElement.GetProperty("properties").GetProperty("firewallRules").GetArrayLength());
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FirewallRulesCanReplacePreviouslyPopulatedRules(bool isPatch)
        {
            var data = new RedisEnterpriseClusterData(
                AzureLocation.EastUS, new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1));
            var patch = new RedisEnterpriseClusterPatch();
            if (isPatch)
            {
                patch.FirewallRules.Add(new RedisEnterpriseFirewallRule("old-rule", "203.0.113.1"));
                patch.FirewallRules.Clear();
                patch.FirewallRules.Add(new RedisEnterpriseFirewallRule("replacement", "198.51.100.1"));
            }
            else
            {
                data.FirewallRules.Add(new RedisEnterpriseFirewallRule("old-rule", "203.0.113.1"));
                data.FirewallRules.Clear();
                data.FirewallRules.Add(new RedisEnterpriseFirewallRule("replacement", "198.51.100.1"));
            }

            BinaryData json = isPatch
                ? ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default)
                : ModelReaderWriter.Write(data, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default);
            using JsonDocument document = JsonDocument.Parse(json);
            JsonElement rules = document.RootElement.GetProperty("properties").GetProperty("firewallRules");
            Assert.AreEqual(1, rules.GetArrayLength());
            Assert.AreEqual("replacement", rules[0].GetProperty("name").GetString());
            Assert.AreEqual("198.51.100.1", rules[0].GetProperty("sourceAddressPrefix").GetString());
        }

        [Test]
        public void NullFactoryFirewallRulesAreOmitted(
            [Values(false, true)] bool isPatch,
            [Values("W", "J")] string format)
        {
            var data = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterData(
                location: AzureLocation.EastUS,
                sku: new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1),
                publicNetworkAccess: RedisEnterprisePublicNetworkAccess.Enabled,
                firewallRules: null);
            var patch = ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                publicNetworkAccess: RedisEnterprisePublicNetworkAccess.Enabled,
                firewallRules: null);
            Assert.IsNotNull(data.FirewallRules);
            Assert.IsNotNull(patch.FirewallRules);

            var options = new ModelReaderWriterOptions(format);
            BinaryData json = isPatch
                ? ModelReaderWriter.Write(patch, options, AzureResourceManagerRedisEnterpriseContext.Default)
                : ModelReaderWriter.Write(data, options, AzureResourceManagerRedisEnterpriseContext.Default);
            AssertFirewallRulesWireState(json, "omitted", "Enabled");
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ClusterPatchSerializesReplacementFirewallRules(bool useFactory)
        {
            var patch = useFactory
                ? ArmRedisEnterpriseModelFactory.RedisEnterpriseClusterPatch(
                    firewallRules: new[] { new RedisEnterpriseFirewallRule("allow-subnet", "203.0.113.0/24") })
                : new RedisEnterpriseClusterPatch();
            if (!useFactory)
            {
                patch.FirewallRules.Add(new RedisEnterpriseFirewallRule("allow-subnet", "203.0.113.0/24"));
            }

            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(patch, WireOptions, AzureResourceManagerRedisEnterpriseContext.Default));
            JsonElement rules = document.RootElement.GetProperty("properties").GetProperty("firewallRules");
            Assert.AreEqual(1, rules.GetArrayLength());
            Assert.AreEqual("allow-subnet", rules[0].GetProperty("name").GetString());
            Assert.AreEqual("203.0.113.0/24", rules[0].GetProperty("sourceAddressPrefix").GetString());
        }

        private static IList<RedisEnterpriseFirewallRule> CreateFirewallRules(string state)
            => state == "empty" ? Array.Empty<RedisEnterpriseFirewallRule>()
                : new[] { new RedisEnterpriseFirewallRule("allow-ip", "203.0.113.1"), new RedisEnterpriseFirewallRule("allow-subnet", "203.0.113.0/24") };

        private static void AssertFirewallRulesWireState(BinaryData json, string state, string publicNetworkAccess)
        {
            using JsonDocument document = JsonDocument.Parse(json);
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual(publicNetworkAccess, properties.GetProperty("publicNetworkAccess").GetString());
            bool hasRules = properties.TryGetProperty("firewallRules", out JsonElement rules);
            Assert.AreEqual(state != "omitted", hasRules);
            if (state == "empty")
            {
                Assert.AreEqual(0, rules.GetArrayLength());
            }
            else if (state == "populated")
            {
                Assert.AreEqual(2, rules.GetArrayLength());
                Assert.AreEqual("allow-ip", rules[0].GetProperty("name").GetString());
                Assert.AreEqual("203.0.113.1", rules[0].GetProperty("sourceAddressPrefix").GetString());
                Assert.AreEqual("allow-subnet", rules[1].GetProperty("name").GetString());
                Assert.AreEqual("203.0.113.0/24", rules[1].GetProperty("sourceAddressPrefix").GetString());
            }
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
