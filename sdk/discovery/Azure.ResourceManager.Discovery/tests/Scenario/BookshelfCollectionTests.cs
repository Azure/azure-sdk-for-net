// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class BookshelfCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string BookshelfName = "sanitized-bookshelf";

        public BookshelfCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private DiscoveryBookshelfCollection GetDiscoveryBookshelfCollection()
            => GetResourceGroupReference(ResourceGroupName).GetDiscoveryBookshelves();

        private DiscoveryBookshelfResource GetBookshelfReference()
            => Client.GetDiscoveryBookshelfResource(DiscoveryBookshelfResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, BookshelfName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<DiscoveryBookshelfResource> operation = await GetDiscoveryBookshelfCollection().CreateOrUpdateAsync(WaitUntil.Completed, BookshelfName, new DiscoveryBookshelfData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(BookshelfName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoveryBookshelfResource> response = await GetDiscoveryBookshelfCollection().GetAsync(BookshelfName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(BookshelfName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<DiscoveryBookshelfResource> items = new List<DiscoveryBookshelfResource>();
            await foreach (DiscoveryBookshelfResource item in GetDiscoveryBookshelfCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<DiscoveryBookshelfResource> items = new List<DiscoveryBookshelfResource>();
            await foreach (DiscoveryBookshelfResource item in GetSubscriptionReference().GetDiscoveryBookshelvesAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<DiscoveryBookshelfResource> operation = await GetBookshelfReference().UpdateAsync(WaitUntil.Completed, new DiscoveryBookshelfData(AzureLocation.UKSouth));

            Assert.That(operation.Value.Data.Name, Is.EqualTo(BookshelfName));
        }

        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation operation = await GetBookshelfReference().DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
