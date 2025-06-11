// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class DenyAssignmentCollectionTests : AuthorizationManagementTestBase
    {
        public DenyAssignmentCollectionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task GetAndExists()
        {
            var randomGuid = Recording.Random.NewGuid().ToString();
            var scope = DefaultSubscription.Id;
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            Assert.ThrowsAsync<RequestFailedException>(() => denyAssignmentCollection.GetAsync(randomGuid));
            Assert.IsFalse(await denyAssignmentCollection.ExistsAsync(randomGuid));
        }

        [RecordedTest]
        public async Task GetAllBySubscription()
        {
            var scope = DefaultSubscription.Id;
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            var denyAssignments = await denyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(denyAssignments);
        }

        [RecordedTest]
        public async Task GetAllByResourceGroup()
        {
            var subscriptionId = DefaultSubscription.Id;
            var scope = new ResourceIdentifier($"{subscriptionId}/resourceGroups/resourceGroupTestName1");
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            var denyAssignments = await denyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(denyAssignments);
        }

        [RecordedTest]
        public async Task GetAllByResource()
        {
            var subscriptionId = DefaultSubscription.Id;
            var scope = new ResourceIdentifier($"{subscriptionId}/resourceGroups/discoverProtectableItemTest/providers/Microsoft.RecoveryServices/vaults/recoveryVault");
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            var denyAssignments = await denyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(denyAssignments);
        }
    }
}
