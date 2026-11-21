// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    public class Batch2026FeaturesIntegrationTests : BatchLiveTestBase
    {
        public Batch2026FeaturesIntegrationTests(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        public Task InstanceMixCreateGetUpdate() => VerifyPoolFeatures("instance-mix");

        [RecordedTest]
        public Task ZonePolicyCreateGetUpdate() => VerifyPoolFeatures("zone-policy");

        [RecordedTest]
        public Task HardwareProfileCreateGetUpdate() => VerifyPoolFeatures("hardware-profile");

        private async Task VerifyPoolFeatures(string feature)
        {
            var client = CreateBatchClient();
            string id = Recording.GenerateId("sdk2026-" + feature, 64);
            using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(5));
            VirtualMachineConfiguration configuration = Batch2026FeatureTestData.Configuration();
            var create = new BatchPoolCreateOptions(id, feature == "instance-mix" ? "Mix" : feature == "hardware-profile" ? "Standard_D4s_v3" : "Standard_D2_v2")
            {
                VirtualMachineConfiguration = configuration,
                TargetDedicatedNodes = 0,
                TargetLowPriorityNodes = 0
            };
            if (feature == "instance-mix")
            { create.VmSkuProfile = MixProfile(); }
            if (feature == "zone-policy")
            {
                configuration.Placement = Batch2026FeatureTestData.Placement();
                configuration.ResiliencyPolicy = Batch2026FeatureTestData.Resiliency();
            }
            if (feature == "hardware-profile")
            { configuration.HardwareProfile = Batch2026FeatureTestData.Hardware(); }
            bool created = false;
            try
            {
                await client.CreatePoolAsync(create, cancellationToken: timeout.Token);
                created = true;
                BatchPool pool = (await client.GetPoolAsync(id, cancellationToken: timeout.Token)).Value;
                AssertFeatures(pool, feature);

                var update = new BatchPoolUpdateOptions();
                update.Metadata.Add(new BatchMetadataItem("feature-test", "feature-preserving-update"));
                await client.UpdatePoolAsync(id, update, cancellationToken: timeout.Token);
                pool = (await client.GetPoolAsync(id, cancellationToken: timeout.Token)).Value;
                AssertFeatures(pool, feature);

                var metadataUpdate = new BatchPoolUpdateOptions();
                metadataUpdate.Metadata.Add(new BatchMetadataItem("feature-test", "metadata-only-update"));
                await client.UpdatePoolAsync(id, metadataUpdate, cancellationToken: timeout.Token);
                pool = (await client.GetPoolAsync(id, cancellationToken: timeout.Token)).Value;
                Assert.AreEqual("metadata-only-update", pool.Metadata.Single(item => item.Name == "feature-test").Value);
                AssertFeatures(pool, feature);
            }
            finally
            {
                if (created)
                {
                    using var cleanupTimeout = new CancellationTokenSource(TimeSpan.FromMinutes(5));
                    await client.DeletePoolAsync(WaitUntil.Completed, id, cancellationToken: cleanupTimeout.Token);
                }
            }
        }

        private static VirtualMachineSkuProfile MixProfile()
        {
            return new VirtualMachineSkuProfile
            {
                AllocationStrategy = VirtualMachineSkuAllocationStrategy.Prioritized,
                VmSizes =
                {
                    new VirtualMachineSkuProfileVmSize("Standard_D2as_v5") { Rank = 1 },
                    new VirtualMachineSkuProfileVmSize("Standard_D2s_v5") { Rank = 2 }
                }
            };
        }

        private static void AssertFeatures(BatchPool pool, string feature)
        {
            Assert.AreEqual(0, pool.CurrentDedicatedNodes);
            if (feature == "instance-mix")
            {
                Assert.AreEqual(2, pool.VmSkuProfile.VmSizes.Count);
                CollectionAssert.AreEquivalent(new[] { "standard_d2as_v5", "standard_d2s_v5" },
                    pool.VmSkuProfile.VmSizes.Select(size => size.Name.ToLowerInvariant()));
                Assert.AreEqual(VirtualMachineSkuAllocationStrategy.Prioritized, pool.VmSkuProfile.AllocationStrategy);
            }
            if (feature == "zone-policy")
            {
                Assert.AreEqual(ZonePlacementPolicyType.Auto, pool.VirtualMachineConfiguration.Placement.ZonePlacementPolicy);
                Assert.AreEqual(2, pool.VirtualMachineConfiguration.ResiliencyPolicy.ZoneAllocationPolicy.MaxZoneCount);
                Assert.AreEqual(75, pool.VirtualMachineConfiguration.ResiliencyPolicy.ZoneAllocationPolicy.MaxInstancePercentPerZonePolicy.Value);
            }
            if (feature == "hardware-profile")
            {
                Assert.AreEqual(2, pool.VirtualMachineConfiguration.HardwareProfile.VmSizeProperties.VCPUsAvailable);
                Assert.AreEqual(1, pool.VirtualMachineConfiguration.HardwareProfile.VmSizeProperties.VCPUsPerCore);
            }
        }
    }
}
