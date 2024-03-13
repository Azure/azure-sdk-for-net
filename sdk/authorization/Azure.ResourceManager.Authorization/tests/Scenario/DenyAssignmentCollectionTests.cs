// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class DenyAssignmentCollectionTests : AuthorizationManagementTestBase
    {
        public DenyAssignmentCollectionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public ResourceGroupResource ResourceGroup { get; set; }

        [Test]
        public async Task Get()
        {
            var randomGuid = Recording.Random.NewGuid().ToString();
            var scope = DefaultSubscription.Id;
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            try
            {
                var denyAssignment = (await denyAssignmentCollection.GetAsync(randomGuid)).Value;
                Assert.AreEqual(1, 0);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [Test]
        public async Task GetAllBySubscription()
        {
            var scope = DefaultSubscription.Id;
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            var denyAssignments = await denyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, denyAssignments.Count);
        }

        [Test]
        public async Task GetAllByResourceGroup()
        {
            var subscriptionId = DefaultSubscription.Id;
            var scope = new ResourceIdentifier($"{subscriptionId}/resourceGroups/resourceGroupTestName1");
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            var denyAssignments = await denyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, denyAssignments.Count);
        }

        [Test]
        public async Task GetAllByResource()
        {
            var subscriptionId = DefaultSubscription.Id;
            var scope = new ResourceIdentifier($"{subscriptionId}/resourceGroups/discoverProtectableItemTest/providers/Microsoft.RecoveryServices/vaults/recoveryVault");
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            var denyAssignments = await denyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, denyAssignments.Count);
        }

        [Test]
        public async Task Exists()
        {
            var randomGuid = Recording.Random.NewGuid().ToString();
            var scope = DefaultSubscription.Id;
            var denyAssignmentCollection = Client.GetDenyAssignments(scope);
            Assert.IsFalse(await denyAssignmentCollection.ExistsAsync(randomGuid));
        }
    }
}
