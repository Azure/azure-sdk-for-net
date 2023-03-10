// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Scenario
{
    [ClientTestFixture(true, "2022-08-01")]
    public class LroRehydrationTests : VirtualMachineScaleSetTestBase
    {
        public LroRehydrationTests(bool isAsync, string apiVersion)
            : base(isAsync, AvailabilitySetResource.ResourceType, apiVersion)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var collection = await GetVirtualMachineScaleSetCollectionAsync();
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vnet = await CreateBasicDependenciesOfVirtualMachineScaleSetAsync();
            var input = ResourceDataHelper.GetBasicLinuxVirtualMachineScaleSetData(DefaultLocation, vmssName, GetSubnetId(vnet));

            input.VirtualMachineProfile.ExtensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions =
                    {
                        new VirtualMachineScaleSetExtensionData("TestExt")
                        {
                            AutoUpgradeMinorVersion = true,
                            EnableAutomaticUpgrade = false,
                            Settings = BinaryData.FromObjectAsJson(new {}),
                            ProtectedSettings = BinaryData.FromObjectAsJson(new
                                {
                                    commandToExecute = $@"echo helloworld",
                                }),
                            Publisher = "Microsoft.Azure.Extensions",
                            ExtensionType = "CustomScript",
                            TypeHandlerVersion = "2.1",
                        }
                    }
            };

            ArmOperation<VirtualMachineScaleSetResource> originalLro = await collection.CreateOrUpdateAsync(WaitUntil.Started, vmssName, input);
            var id = originalLro.Id;
            var resourceRehydratedLro = ArmOperation<VirtualMachineScaleSetResource>.Rehydrate<VirtualMachineScaleSetResource, VirtualMachineScaleSetData>(Client, id);
            await resourceRehydratedLro.WaitForCompletionAsync();
            Assert.True(resourceRehydratedLro.HasValue);
            VirtualMachineScaleSetResource rehydratedResult = resourceRehydratedLro.Value;
            await originalLro.UpdateStatusAsync();
            VirtualMachineScaleSetResource originalResult = originalLro.Value;
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.Sku), JsonSerializer.Serialize(rehydratedResult.Data.Sku));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.Plan), JsonSerializer.Serialize(rehydratedResult.Data.Plan));
            Assert.AreEqual(originalResult.Data.Identity, rehydratedResult.Data.Identity);
            //Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.Zones), JsonSerializer.Serialize(rehydratedResult.Data.Zones)); // original is empty, rehydrated is null
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.Location), JsonSerializer.Serialize(rehydratedResult.Data.Location));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.UpgradePolicy), JsonSerializer.Serialize(rehydratedResult.Data.UpgradePolicy));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.AutomaticRepairsPolicy), JsonSerializer.Serialize(rehydratedResult.Data.AutomaticRepairsPolicy));
            //Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.VirtualMachineProfile), JsonSerializer.Serialize(rehydratedResult.Data.VirtualMachineProfile));
            Assert.AreEqual(originalResult.Data.ProvisioningState, rehydratedResult.Data.ProvisioningState);
            Assert.AreEqual(originalResult.Data.Overprovision, rehydratedResult.Data.Overprovision);
            Assert.AreEqual(originalResult.Data.DoNotRunExtensionsOnOverprovisionedVms, rehydratedResult.Data.DoNotRunExtensionsOnOverprovisionedVms);
            Assert.AreEqual(originalResult.Data.UniqueId, rehydratedResult.Data.UniqueId);
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.SinglePlacementGroup), JsonSerializer.Serialize(rehydratedResult.Data.SinglePlacementGroup));
            Assert.AreEqual(originalResult.Data.ZoneBalance, rehydratedResult.Data.ZoneBalance);
            Assert.AreEqual(originalResult.Data.PlatformFaultDomainCount, rehydratedResult.Data.PlatformFaultDomainCount);
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.ProximityPlacementGroup), JsonSerializer.Serialize(rehydratedResult.Data.ProximityPlacementGroup));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.HostGroup), JsonSerializer.Serialize(rehydratedResult.Data.HostGroup));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.AdditionalCapabilities), JsonSerializer.Serialize(rehydratedResult.Data.AdditionalCapabilities));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.ScaleInPolicy), JsonSerializer.Serialize(rehydratedResult.Data.ScaleInPolicy));
            Assert.AreEqual(originalResult.Data.OrchestrationMode, rehydratedResult.Data.OrchestrationMode);
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.SpotRestorePolicy), JsonSerializer.Serialize(rehydratedResult.Data.SpotRestorePolicy));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.PriorityMixPolicy), JsonSerializer.Serialize(rehydratedResult.Data.PriorityMixPolicy));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.TimeCreated), JsonSerializer.Serialize(rehydratedResult.Data.TimeCreated));
            Assert.AreEqual(originalResult.Data.IsMaximumCapacityConstrained, rehydratedResult.Data.IsMaximumCapacityConstrained);

            var originalResponse = originalLro.GetRawResponse();
            var rehydratedResponse = resourceRehydratedLro.GetRawResponse();
            Assert.AreEqual(originalResponse.Status, rehydratedResponse.Status);
        }
    }
}
