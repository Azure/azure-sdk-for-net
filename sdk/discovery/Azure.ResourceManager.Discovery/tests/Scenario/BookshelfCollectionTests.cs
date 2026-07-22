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

        private BookshelfCollection GetBookshelfCollection()
            => GetResourceGroupReference(ResourceGroupName).GetBookshelves();

        private BookshelfResource GetBookshelfReference()
            => Client.GetBookshelfResource(BookshelfResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, BookshelfName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<BookshelfResource> operation = await GetBookshelfCollection().CreateOrUpdateAsync(WaitUntil.Completed, BookshelfName, new BookshelfData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(BookshelfName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<BookshelfResource> response = await GetBookshelfCollection().GetAsync(BookshelfName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(BookshelfName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<BookshelfResource> items = new List<BookshelfResource>();
            await foreach (BookshelfResource item in GetBookshelfCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<BookshelfResource> items = new List<BookshelfResource>();
            await foreach (BookshelfResource item in GetSubscriptionReference().GetBookshelvesAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<BookshelfResource> operation = await GetBookshelfReference().UpdateAsync(WaitUntil.Completed, new BookshelfData(AzureLocation.UKSouth));

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
