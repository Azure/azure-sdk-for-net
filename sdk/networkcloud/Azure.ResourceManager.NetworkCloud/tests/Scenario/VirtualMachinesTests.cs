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

        [Test]
        public async Task VirtualMachines()
        {
            VirtualMachineCollection collection = ResourceGroupResource.GetVirtualMachines();
            string virtualMachineName = "virtualMachineName";
            string resourceGroupName = ResourceGroupResource.Id.ResourceGroupName;
            ResourceIdentifier virtualMachineResourceId = VirtualMachineResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, resourceGroupName, virtualMachineName);
            VirtualMachineResource virtualMachine = Client.GetVirtualMachineResource(virtualMachineResourceId);

            // Create
            // Uri imageRepoUri = new Uri("https://" + TestEnvironment.VMImageRepoUri);
            string vmImageWithTag = String.Format("{0}/{1}", TestEnvironment.VMImageRepoUri, TestEnvironment.VMImage);
            var vmImageRepoPwd = TestEnvironment.VMImageRepoPwd;
            VirtualMachineData createData = new VirtualMachineData
            (
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                "admin",
                new NetworkAttachment
                (
                    TestEnvironment.CSNAttachmentId,
                    VirtualMachineIPAllocationMethod.Dynamic
                )
                {
                    DefaultGateway = DefaultGateway.False,
                    NetworkAttachmentName = TestEnvironment.CSNAttachmentName,
                },
                2,
                8,
                new StorageProfile
                (
                    new OSDisk(20)
                    {
                        CreateOption = OSDiskCreateOption.Ephemeral,
                        DeleteOption = OSDiskDeleteOption.Delete,
                    }
                ),
                vmImageWithTag
            )
            {
                BootMethod = VirtualMachineBootMethod.Uefi,
                NetworkAttachments =
                {
                    new NetworkAttachment
                    (
                        TestEnvironment.L3NAttachmentId,
                        VirtualMachineIPAllocationMethod.Dynamic
                    )
                    {
                        DefaultGateway = DefaultGateway.False,
                        NetworkAttachmentName = TestEnvironment.L3NAttachmentName,
                    }
                },
                PlacementHints = {},
                SshPublicKeys =
                {
                    new SshPublicKey("ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDLYVAibDxCYQcs4xeiGLcHMw+DvwKVAhMPG0OP85JKsBmFkeMPm5+2fEzQqjmE2r46V0+Idjdq3BYHwOzxPVb0p0Ekb4o7G3eEE/aCoSkr9S+cTn2CzCgDn3S8d1Muee56XlVJU4Z3G2oIcQchXetqYdD5NNwTyYZuDIaPoxCkGy1g+mYHsj7yxs65KfBNM/ucnvKy5cphI/uGNgcYUki0tRPT2/3H2QGVQVDfIficjPKBt9Jp08psvdJGs2Lk0Z5KrkgKyzb4VCDYmgV5AYoCPIO640n97nBwZlhVXkd4hSWHksVBBN+sajoWrWlU7h4ihwwwZcO90RYIiaHrJm9YmSMO3Y4AARHIKJ1+UerpAloAR3Jp01gTVzZdQrd9T0YfNnF7/ltg7OTo9m/mDn7zh1ZKFjyJv7bPQdhSIGbhdGrewyPe04+tSDGyH7bjpjm1A99qDYj6SeoEr790N0Lw2QGdP10Lo55+uMwzzbLyyIWzodHVIH4pPfz7mg1oWAs= osh@osh")
                },
                VmImageRepositoryCredentials = new ImageRepositoryCredentials
                (
                    vmImageRepoPwd,
                    TestEnvironment.VMImageRepoUri,
                    TestEnvironment.VMImageRepoUser
                ),
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<VirtualMachineResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineName, createData);

            // Get
            VirtualMachineResource getResult = await virtualMachine.GetAsync();
            Assert.AreEqual(virtualMachineName, getResult.Data.Name);

            // Update
            VirtualMachinePatch patch = new VirtualMachinePatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            ArmOperation<VirtualMachineResource> updateResult = await virtualMachine.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // List by Resource Group
            var listByResourceGroup = new List<VirtualMachineResource>();
            await foreach (VirtualMachineResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<VirtualMachineResource>();
            await foreach (VirtualMachineResource item in SubscriptionResource.GetVirtualMachinesAsync())
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
