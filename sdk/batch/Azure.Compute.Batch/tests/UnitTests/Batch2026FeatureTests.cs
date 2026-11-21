// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class Batch2026FeatureTests
    {
        [Test]
        public void PopulatedPoolFeaturesRoundTrip([Values("J", "W")] string format)
        {
            VirtualMachineConfiguration configuration = Batch2026FeatureTestData.Configuration();
            configuration.Placement = Batch2026FeatureTestData.Placement();
            configuration.ResiliencyPolicy = Batch2026FeatureTestData.Resiliency();
            configuration.HardwareProfile = Batch2026FeatureTestData.Hardware();
            var pool = new BatchPoolCreateOptions("feature-pool", "Mix")
            {
                TargetDedicatedNodes = 0,
                VirtualMachineConfiguration = configuration,
                VmSkuProfile = Batch2026FeatureTestData.MixProfile()
            };
            var options = new ModelReaderWriterOptions(format);
            BinaryData data = ModelReaderWriter.Write(pool, options);
            using JsonDocument document = JsonDocument.Parse(data);
            AssertFeatureJson(document.RootElement);
            BatchPoolCreateOptions restored = ModelReaderWriter.Read<BatchPoolCreateOptions>(data, options);
            Assert.AreEqual("Standard_D2s_v3", restored.VmSkuProfile.VmSizes[1].Name);
            Assert.AreEqual(2, restored.VmSkuProfile.VmSizes[1].Rank);
            Assert.AreEqual(VirtualMachineSkuAllocationStrategy.Prioritized, restored.VmSkuProfile.AllocationStrategy);
            Assert.AreEqual(ZonePlacementPolicyType.Auto, restored.VirtualMachineConfiguration.Placement.ZonePlacementPolicy);
            Assert.AreEqual(75, restored.VirtualMachineConfiguration.ResiliencyPolicy.ZoneAllocationPolicy.MaxInstancePercentPerZonePolicy.Value);
            Assert.AreEqual(1, restored.VirtualMachineConfiguration.HardwareProfile.VmSizeProperties.VCPUsPerCore);
        }

        [Test]
        public void PoolResponseDeserializesNewFeatures()
        {
            const string json = """
                {"id":"pool","vmSize":"Mix","vmSkuProfile":{"allocationStrategy":"prioritized","vmSizes":[{"name":"Standard_D2_v2","rank":1},{"name":"Standard_D2s_v3","rank":2}]},"virtualMachineConfiguration":{"imageReference":{"publisher":"MicrosoftWindowsServer","offer":"windowsserver2022","sku":"2022-datacenter-smalldisk","version":"latest"},"nodeAgentSKUId":"batch.node.windows amd64","placement":{"zonePlacementPolicy":"Auto"},"resiliencyPolicy":{"zoneAllocationPolicy":{"maxZoneCount":2,"maxInstancePercentPerZonePolicy":{"enabled":true,"value":75}}},"hardwareProfile":{"vmSizeProperties":{"vCPUsAvailable":2,"vCPUsPerCore":1}}}}
                """;
            BatchPool pool = ModelReaderWriter.Read<BatchPool>(BinaryData.FromString(json));
            Assert.AreEqual(2, pool.VmSkuProfile.VmSizes.Count);
            Assert.AreEqual(ZonePlacementPolicyType.Auto, pool.VirtualMachineConfiguration.Placement.ZonePlacementPolicy);
            Assert.AreEqual(2, pool.VirtualMachineConfiguration.ResiliencyPolicy.ZoneAllocationPolicy.MaxZoneCount);
            Assert.AreEqual(2, pool.VirtualMachineConfiguration.HardwareProfile.VmSizeProperties.VCPUsAvailable);
        }

        [Test]
        public void NodeResponsePreservesPublicAddresses()
        {
            BatchNode node = ModelReaderWriter.Read<BatchNode>(BinaryData.FromString(
                """{"id":"node","publicIPAddress":"192.0.2.1","publicIPv6Address":"2001:0db8::1"}"""));
            Assert.AreEqual("192.0.2.1", node.PublicIPAddress);
            Assert.AreEqual("2001:0db8::1", node.PublicIPv6Address);
        }

        [Test]
        public async Task PatchSendsPopulatedNewFields([Values(false, true)] bool isAsync)
        {
            BinaryData payload = null;
            var transport = new MockTransport(request =>
            {
                using var stream = new MemoryStream();
                request.Content.WriteTo(stream, default);
                payload = BinaryData.FromBytes(stream.ToArray());
                return new MockResponse(200);
            });
            var client = Client(transport);
            VirtualMachineConfiguration configuration = Batch2026FeatureTestData.Configuration();
            configuration.Placement = Batch2026FeatureTestData.Placement();
            configuration.ResiliencyPolicy = Batch2026FeatureTestData.Resiliency();
            configuration.HardwareProfile = Batch2026FeatureTestData.Hardware();
            var update = new BatchPoolUpdateOptions
            {
                VmSize = "Mix",
                VmSkuProfile = Batch2026FeatureTestData.MixProfile(),
                VirtualMachineConfiguration = configuration
            };
            if (isAsync)
            { await client.UpdatePoolAsync("pool", update); }
            else
            { client.UpdatePool("pool", update); }
            Assert.AreEqual("PATCH", transport.Requests[0].Method.ToString());
            using JsonDocument document = JsonDocument.Parse(payload);
            AssertFeatureJson(document.RootElement);
        }

        [Test]
        public void PartialPatchOmitsUnspecifiedFeatures([Values(false, true)] bool includeConfiguration)
        {
            var update = new BatchPoolUpdateOptions();
            update.Metadata.Add(new BatchMetadataItem("feature-test", "updated"));
            if (includeConfiguration)
            { update.VirtualMachineConfiguration = Batch2026FeatureTestData.Configuration(); }
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(update, new ModelReaderWriterOptions("W")));
            Assert.IsFalse(document.RootElement.TryGetProperty("vmSkuProfile", out _));
            if (includeConfiguration)
            {
                JsonElement configuration = document.RootElement.GetProperty("virtualMachineConfiguration");
                foreach (string name in new[] { "placement", "resiliencyPolicy", "hardwareProfile" })
                {
                    Assert.IsFalse(configuration.TryGetProperty(name, out _), name);
                }
            }
            else
            {
                Assert.IsFalse(document.RootElement.TryGetProperty("virtualMachineConfiguration", out _));
            }
        }

        [Test]
        public void MixStrategiesRoundTrip(
            [Values("prioritized", "lowestPrice", "capacityOptimized")] string strategy,
            [Values("J", "W")] string format)
        {
            VirtualMachineSkuProfile profile = Batch2026FeatureTestData.MixProfile();
            profile.AllocationStrategy = new VirtualMachineSkuAllocationStrategy(strategy);
            var options = new ModelReaderWriterOptions(format);

            BinaryData data = ModelReaderWriter.Write(profile, options);
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.AreEqual(strategy, document.RootElement.GetProperty("allocationStrategy").GetString());
            Assert.AreEqual(strategy, ModelReaderWriter.Read<VirtualMachineSkuProfile>(data, options).AllocationStrategy.Value.ToString());
        }

        [Test]
        public void UnspecifiedPolicySettingsStayOmitted()
        {
            using JsonDocument hardware = JsonDocument.Parse(ModelReaderWriter.Write(new VMSizeProperties(), new ModelReaderWriterOptions("W")));
            Assert.IsFalse(hardware.RootElement.TryGetProperty("vCPUsAvailable", out _));
            Assert.IsFalse(hardware.RootElement.TryGetProperty("vCPUsPerCore", out _));
            using JsonDocument zones = JsonDocument.Parse(ModelReaderWriter.Write(new ZoneAllocationPolicy(), new ModelReaderWriterOptions("W")));
            Assert.IsFalse(zones.RootElement.TryGetProperty("maxZoneCount", out _));
            Assert.IsFalse(zones.RootElement.TryGetProperty("maxInstancePercentPerZonePolicy", out _));
        }

        private static BatchClient Client(MockTransport transport) => new BatchClient(
            new Uri("https://account.region.batch.azure.com"),
            new MockCredential(),
            new BatchClientOptions { Transport = transport });

        private static void AssertFeatureJson(JsonElement root)
        {
            JsonElement mix = root.GetProperty("vmSkuProfile");
            Assert.AreEqual("prioritized", mix.GetProperty("allocationStrategy").GetString());
            Assert.AreEqual(2, mix.GetProperty("vmSizes").GetArrayLength());
            Assert.AreEqual("Standard_D2_v2", mix.GetProperty("vmSizes")[0].GetProperty("name").GetString());
            Assert.AreEqual(2, mix.GetProperty("vmSizes")[1].GetProperty("rank").GetInt32());
            JsonElement configuration = root.GetProperty("virtualMachineConfiguration");
            Assert.AreEqual("Auto", configuration.GetProperty("placement").GetProperty("zonePlacementPolicy").GetString());
            JsonElement zones = configuration.GetProperty("resiliencyPolicy").GetProperty("zoneAllocationPolicy");
            Assert.AreEqual(2, zones.GetProperty("maxZoneCount").GetInt32());
            Assert.IsTrue(zones.GetProperty("maxInstancePercentPerZonePolicy").GetProperty("enabled").GetBoolean());
            Assert.AreEqual(75, zones.GetProperty("maxInstancePercentPerZonePolicy").GetProperty("value").GetInt32());
            JsonElement hardware = configuration.GetProperty("hardwareProfile").GetProperty("vmSizeProperties");
            Assert.AreEqual(2, hardware.GetProperty("vCPUsAvailable").GetInt32());
            Assert.AreEqual(1, hardware.GetProperty("vCPUsPerCore").GetInt32());
        }
    }
}
