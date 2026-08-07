// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class SupercomputerCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string SupercomputerName = "sanitized-supercomputer";

        public SupercomputerCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private DiscoverySupercomputerCollection GetDiscoverySupercomputerCollection()
            => GetResourceGroupReference(ResourceGroupName).GetDiscoverySupercomputers();

        private DiscoverySupercomputerResource GetSupercomputerReference()
            => Client.GetDiscoverySupercomputerResource(DiscoverySupercomputerResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, SupercomputerName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<DiscoverySupercomputerResource> operation = await GetDiscoverySupercomputerCollection().CreateOrUpdateAsync(WaitUntil.Completed, SupercomputerName, new DiscoverySupercomputerData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(SupercomputerName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoverySupercomputerResource> response = await GetDiscoverySupercomputerCollection().GetAsync(SupercomputerName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(SupercomputerName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<DiscoverySupercomputerResource> items = new List<DiscoverySupercomputerResource>();
            await foreach (DiscoverySupercomputerResource item in GetDiscoverySupercomputerCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<DiscoverySupercomputerResource> items = new List<DiscoverySupercomputerResource>();
            await foreach (DiscoverySupercomputerResource item in GetSubscriptionReference().GetDiscoverySupercomputersAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation operation = await GetSupercomputerReference().DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
