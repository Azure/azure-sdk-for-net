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
                    new NetworkCloudSshPublicKey("ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDLYVAibDxCYQcs4xeiGLcHMw+DvwKVAhMPG0OP85JKsBmFkeMPm5+2fEzQqjmE2r46V0+Idjdq3BYHwOzxPVb0p0Ekb4o7G3eEE/aCoSkr9S+cTn2CzCgDn3S8d1Muee56XlVJU4Z3G2oIcQchXetqYdD5NNwTyYZuDIaPoxCkGy1g+mYHsj7yxs65KfBNM/ucnvKy5cphI/uGNgcYUki0tRPT2/3H2QGVQVDfIficjPKBt9Jp08psvdJGs2Lk0Z5KrkgKyzb4VCDYmgV5AYoCPIO640n97nBwZlhVXkd4hSWHksVBBN+sajoWrWlU7h4ihwwwZcO90RYIiaHrJm9YmSMO3Y4AARHIKJ1+UerpAloAR3Jp01gTVzZdQrd9T0YfNnF7/ltg7OTo9m/mDn7zh1ZKFjyJv7bPQdhSIGbhdGrewyPe04+tSDGyH7bjpjm1A99qDYj6SeoEr790N0Lw2QGdP10Lo55+uMwzzbLyyIWzodHVIH4pPfz7mg1oWAs= osh@osh")
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
