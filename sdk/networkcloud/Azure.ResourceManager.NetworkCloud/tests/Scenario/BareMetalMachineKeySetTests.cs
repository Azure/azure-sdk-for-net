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
    public class BareMetalMachineKeySetTests : NetworkCloudManagementTestBase
    {
        public BareMetalMachineKeySetTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public BareMetalMachineKeySetTests(bool isAsync) : base(isAsync) {}

        [Test]
        public async Task BareMetalMachineKeySet()
        {
            // get the collection of this BareMetalMachineKeySetResource
            string bareMetalMachineKeySetName = Recording.GenerateAssetName("bareMetalMachineKeySet");
            ClusterResource cluster = Client.GetClusterResource(TestEnvironment.ClusterId);
            cluster = await cluster.GetAsync();
            BareMetalMachineKeySetCollection collection = cluster.GetBareMetalMachineKeySets();
            ResourceIdentifier bareMetalMachineKeySetResourceId = BareMetalMachineKeySetResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, cluster.Id.ResourceGroupName, cluster.Data.Name, bareMetalMachineKeySetName);
            BareMetalMachineKeySetResource bareMetalMachineKeySet = Client.GetBareMetalMachineKeySetResource(bareMetalMachineKeySetResourceId);

            // Create
             BareMetalMachineKeySetData data = new BareMetalMachineKeySetData
             (
                TestEnvironment.Location,
                cluster.Data.ClusterExtendedLocation,
                "fake-id",
                TestEnvironment.DayFromNow,
                new string[]
                {},
                BareMetalMachineKeySetPrivilegeLevel.Standard,
                new KeySetUser[]
                {
                    new KeySetUser
                    (
                        "userABC",
                        new SshPublicKey("ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQCYnWX/sth0/ikG/d+ahWdO4sTp1stHP1jnEcxt0Vr4YcoKYh6cic2yZr3Mjb4NxcuJKAw4kmJ7bSRl5na8MEJkSFyMberQaqapahv+lx7Pm8ZTZVlVcvq0Q83yrHA/62RNtLqLF03RaTaBMrNXZoC76euPEHK4LNgk9UxhTfE0GDHGHOHGRafh24pTgVhyd7nSTuYyY+OlIfv6J726wGsRFZ8OXtE7xfHEtfzsFJBpf15YOEEtdrIQ0w+xj53nO2FOk+gLhExxlfj4gizQZPXtNI+nM7d25rlZWQW4RngFAvon63/3HNELCEHmAaEPpoAQpgESl19AtTQzUf5hl3RAyL75CM7V95/NcUG0UJ+3t1wI+Kc3WpTkHZmbcgOBYSi6+JPpmqB/oxEkjDUIvyyenLB9UFyTj8keQ2vCYzaTBLjcndDJWFYM+MbKHCSx/XxZXDkFiPQeLgkWixFAWLmufnwULIx/tr/VRdQFSZI6MoUmfUqaQhv7a2eVikiqLEk= fake-public-key")
                    ),
                }
            )
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<BareMetalMachineKeySetResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, bareMetalMachineKeySetName, data);
            Assert.AreEqual(bareMetalMachineKeySetName, createResult.Value.Data.Name);

            // Get
            var getResult = await bareMetalMachineKeySet.GetAsync();
            Assert.AreEqual(bareMetalMachineKeySetName, getResult.Value.Data.Name);

            // List by Resource Group
            var listByResourceGroup = new List<BareMetalMachineKeySetResource>();
            await foreach (BareMetalMachineKeySetResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            // var listBySubscription = new List<BareMetalMachineKeySetResource>();
            // await foreach (BareMetalMachineKeySetResource item in SubscriptionResource.GetBareMetalMachineKeySetsAsync(cluster.Data.Name))
            // {
            //     listBySubscription.Add(item);
            // }
            // Assert.IsNotEmpty(listBySubscription);

            // Update
            BareMetalMachineKeySetPatch patch = new BareMetalMachineKeySetPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            ArmOperation<BareMetalMachineKeySetResource> updateResult = await bareMetalMachineKeySet.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // Delete
            var deleteResult = await bareMetalMachineKeySet.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}