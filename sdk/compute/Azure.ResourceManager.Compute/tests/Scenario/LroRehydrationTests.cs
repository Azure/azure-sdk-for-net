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
            var token = originalLro.GetRehydrationToken();
            var resourceRehydratedLro = await ArmOperation.RehydrateAsync<VirtualMachineScaleSetResource>(Client, token.Value);
            await resourceRehydratedLro.WaitForCompletionAsync();
            Assert.True(resourceRehydratedLro.HasValue);
            VirtualMachineScaleSetResource rehydratedResult = resourceRehydratedLro.Value;
            await originalLro.UpdateStatusAsync();
            VirtualMachineScaleSetResource originalResult = originalLro.Value;
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.Sku), JsonSerializer.Serialize(rehydratedResult.Data.Sku));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.Plan), JsonSerializer.Serialize(rehydratedResult.Data.Plan));
            Assert.AreEqual(originalResult.Data.Identity, rehydratedResult.Data.Identity);
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.Location), JsonSerializer.Serialize(rehydratedResult.Data.Location));
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Data.Properties), JsonSerializer.Serialize(rehydratedResult.Data.Properties));

            var originalResponse = originalLro.GetRawResponse();
            var rehydratedResponse = resourceRehydratedLro.GetRawResponse();
            Assert.AreEqual(originalResponse.Status, rehydratedResponse.Status);
        }
    }
}
