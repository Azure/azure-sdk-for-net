// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class VirtualMachinesTests : NetworkCloudManagementTestBase
    {
        public VirtualMachinesTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public VirtualMachinesTests(bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        [RecordedTest]
        public async Task VirtualMachines()
        {
            NetworkCloudVirtualMachineCollection collection = ResourceGroupResource.GetNetworkCloudVirtualMachines();
            string virtualMachineName = Recording.GenerateAssetName("vm");
            string resourceGroupName = ResourceGroupResource.Id.ResourceGroupName;
            ResourceIdentifier virtualMachineResourceId = NetworkCloudVirtualMachineResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, resourceGroupName, virtualMachineName);
            NetworkCloudVirtualMachineResource virtualMachine = Client.GetNetworkCloudVirtualMachineResource(virtualMachineResourceId);

            // Create
            NetworkCloudVirtualMachineData createData = new NetworkCloudVirtualMachineData
            (
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                "admin",
                new NetworkAttachment
                (
                    TestEnvironment.CSNAttachmentId,
                    VirtualMachineIPAllocationMethod.Dynamic
                ),
                2,
                8,
                new NetworkCloudStorageProfile
                (
                    new NetworkCloudOSDisk(20)
                    {
                        CreateOption = OSDiskCreateOption.Ephemeral,
                        DeleteOption = OSDiskDeleteOption.Delete,
                    }
                ),
                TestEnvironment.VMImage
            )
            {
                CpuCores = 2,
                MemorySizeInGB = 1,
                VmDeviceModel = VirtualMachineDeviceModelType.T2,
                NetworkAttachments =
                {
                    new NetworkAttachment
                    (
                        TestEnvironment.L3NAttachmentId,
                        VirtualMachineIPAllocationMethod.Dynamic
                    )
                    {
                        DefaultGateway = DefaultGateway.True,
                        NetworkAttachmentName = "l3network",
                    }
                },
                SshPublicKeys =
                {
                    new NetworkCloudSshPublicKey("ssh-rsa ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDZVQ8kqj4YM4sM2+sXH/gQmqiVS4Bl9Y5ZAnBZSlW2QEs1Qg8ubiYHMwYU5Z+yKXmcnJ0lJEyF9opa0em3Y9Du5BZ5MMGWn8jWR0OpaDgXMxZJa5cIg6uGtk5vmav/XOAUHtjkqTKJgWBfHJZFfccyfOST66nyotrSrl1FQZUBVU0fTP/rnH/2MrD7r9rhC5hgRyh6RFjyw3rI5e+WJ9v/Edi9EGvnrUXQy9PXLQGiaEgCnktbdvHfvBZOYrrDLr/vjFFKBvgfEJqBg05lmQRw/bF9xuwfbM36wxGjIyohLMIHcHBP3QT55onaY8hyUSzcLAAvbpzev0gXujxXzkCKYEfXHjvEeEhRVm57Gnw8/2dTnqBJkNo5x+2y584oKbYthRkX4LM+JipDua6jMl5LYDJi5Y2V1A0uq67rxmnfI5i+Lw/Q9tiWPMh05ZsXTA2MGds5bWjsK9cL+w3YSPjmi59YHgZNZ4eW0/nMj6ioqy78A5casVmG4k/10TwqZik= cloudtest@simulator")
                },
                VmImageRepositoryCredentials = new ImageRepositoryCredentials
                (
                    TestEnvironment.VMImageRepoPwd,
                    TestEnvironment.VMImageRepoUri,
                    TestEnvironment.VMImageRepoUser,
                    null),
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<NetworkCloudVirtualMachineResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineName, createData);
            Assert.AreEqual(createResult.Value.Data.Name, virtualMachineName);

            // Get
            NetworkCloudVirtualMachineResource getResult = await virtualMachine.GetAsync();
            Assert.AreEqual(virtualMachineName, getResult.Data.Name);

            // Update
            NetworkCloudVirtualMachinePatch patch = new NetworkCloudVirtualMachinePatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            ArmOperation<NetworkCloudVirtualMachineResource> updateResult = await virtualMachine.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // List by Resource Group
            var listByResourceGroup = new List<NetworkCloudVirtualMachineResource>();
            await foreach (NetworkCloudVirtualMachineResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<NetworkCloudVirtualMachineResource>();
            await foreach (NetworkCloudVirtualMachineResource item in SubscriptionResource.GetNetworkCloudVirtualMachinesAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            var deleteResult = await virtualMachine.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
