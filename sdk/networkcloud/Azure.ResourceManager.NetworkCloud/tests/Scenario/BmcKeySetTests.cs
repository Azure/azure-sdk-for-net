// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class BmcKeySetTests : NetworkCloudManagementTestBase
    {
        public BmcKeySetTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public BmcKeySetTests(bool isAsync) : base(isAsync) {}

        [Test]
        public async Task BmcKeySet()
        {
            string bmcKeySetName = Recording.GenerateAssetName("bmckeyset");
            ResourceIdentifier bmcKeySetResourceId = BmcKeySetResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterRG, TestEnvironment.ClusterName, bmcKeySetName);
            BmcKeySetResource bmcKeySet = Client.GetBmcKeySetResource(bmcKeySetResourceId);

            ClusterResource cluster = Client.GetClusterResource(TestEnvironment.ClusterId);
            BmcKeySetCollection collection = cluster.GetBmcKeySets();

            // Create
            BmcKeySetData data = new BmcKeySetData
            (
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                "fake-ag-id",
                TestEnvironment.DayFromNow,
                BmcKeySetPrivilegeLevel.ReadOnly,
                new KeySetUser[]
                {
                new KeySetUser("username",new SshPublicKey("ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQCYnWX/sth0/ikG/d+ahWdO4sTp1stHP1jnEcxt0Vr4YcoKYh6cic2yZr3Mjb4NxcuJKAw4kmJ7bSRl5na8MEJkSFyMberQaqapahv+lx7Pm8ZTZVlVcvq0Q83yrHA/62RNtLqLF03RaTaBMrNXZoC76euPEHK4LNgk9UxhTfE0GDHGHOHGRafh24pTgVhyd7nSTuYyY+OlIfv6J726wGsRFZ8OXtE7xfHEtfzsFJBpf15YOEEtdrIQ0w+xj53nO2FOk+gLhExxlfj4gizQZPXtNI+nM7d25rlZWQW4RngFAvon63/3HNELCEHmAaEPpoAQpgESl19AtTQzUf5hl3RAyL75CM7V95/NcUG0UJ+3t1wI+Kc3WpTkHZmbcgOBYSi6+JPpmqB/oxEkjDUIvyyenLB9UFyTj8keQ2vCYzaTBLjcndDJWFYM+MbKHCSx/XxZXDkFiPQeLgkWixFAWLmufnwULIx/tr/VRdQFSZI6MoUmfUqaQhv7a2eVikiqLEk= fake-public-key")){}
                }
            )
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<BmcKeySetResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, bmcKeySetName, data);
            Assert.AreEqual(bmcKeySetName, createResult.Value.Data.Name);

            // Get
            var getResult = await bmcKeySet.GetAsync();
            Assert.AreEqual(bmcKeySetName, getResult.Value.Data.Name);

            // List by Resource Group
            var listByResourceGroup = new List<BmcKeySetResource>();
            await foreach (BmcKeySetResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Update
            BmcKeySetPatch patch = new BmcKeySetPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            ArmOperation<BmcKeySetResource> updateResult = await bmcKeySet.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // Delete
            var deleteResult = await bmcKeySet.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}