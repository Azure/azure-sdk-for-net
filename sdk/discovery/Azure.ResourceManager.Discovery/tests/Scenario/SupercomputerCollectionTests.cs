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

        private SupercomputerCollection GetSupercomputerCollection()
            => GetResourceGroupReference(ResourceGroupName).GetSupercomputers();

        private SupercomputerResource GetSupercomputerReference()
            => Client.GetSupercomputerResource(SupercomputerResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, SupercomputerName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<SupercomputerResource> operation = await GetSupercomputerCollection().CreateOrUpdateAsync(WaitUntil.Completed, SupercomputerName, new SupercomputerData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(SupercomputerName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<SupercomputerResource> response = await GetSupercomputerCollection().GetAsync(SupercomputerName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(SupercomputerName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<SupercomputerResource> items = new List<SupercomputerResource>();
            await foreach (SupercomputerResource item in GetSupercomputerCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<SupercomputerResource> items = new List<SupercomputerResource>();
            await foreach (SupercomputerResource item in GetSubscriptionReference().GetSupercomputersAsync())
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
