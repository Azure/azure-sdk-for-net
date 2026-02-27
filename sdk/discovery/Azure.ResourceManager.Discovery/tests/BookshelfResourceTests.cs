// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Tests for Bookshelf resource operations.
    /// </summary>
    public class BookshelfResourceTests : DiscoveryManagementTestBase
    {
        public BookshelfResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListBookshelvesBySubscription()
        {
            // Arrange & Act
            var bookshelves = new List<BookshelfResource>();
            await foreach (var bookshelf in DefaultSubscription.GetBookshelvesAsync())
            {
                bookshelves.Add(bookshelf);
            }

            // Assert
            Assert.That(bookshelves, Is.Not.Null);
            // List may be empty but should not throw
        }

        [RecordedTest]
        public async Task ListBookshelvesByResourceGroup()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // Act
            var bookshelves = new List<BookshelfResource>();
            await foreach (var bookshelf in resourceGroup.GetBookshelves().GetAllAsync())
            {
                bookshelves.Add(bookshelf);
            }

            // Assert
            Assert.That(bookshelves, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetBookshelf()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelfName = TestEnvironment.BookshelfName;

            // Act
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(bookshelfName);

            // Assert
            Assert.That(bookshelf.Value, Is.Not.Null);
            Assert.That(bookshelf.Value.Data.Name, Is.EqualTo(bookshelfName));
        }

        [RecordedTest]
        [Ignore("Requires proper setup with workload identities and managed resource group configuration")]
        public async Task CreateBookshelf()
        {
            // Arrange
            var resourceGroup = await CreateResourceGroupAsync();
            var bookshelfName = Recording.GenerateAssetName("bookshelf-");

            // TODO: Bookshelf creation may require additional configuration:
            // 1. WorkloadIdentities (user-assigned managed identities)
            // 2. Proper network configuration
            // Example:
            // var properties = new BookshelfProperties();
            // properties.WorkloadIdentities.Add("identityKey", new UserAssignedIdentity());
            // var bookshelfData = new BookshelfData(DefaultLocation) { Properties = properties };

            var bookshelfData = new BookshelfData(DefaultLocation)
            {
                Tags =
                {
                    { "test", "value" }
                }
            };

            // Act
            var operation = await resourceGroup.GetBookshelves().CreateOrUpdateAsync(
                WaitUntil.Completed,
                bookshelfName,
                bookshelfData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(bookshelfName));
        }

        [RecordedTest]
        [Ignore("Requires existing bookshelf to delete - should create first then delete")]
        public async Task DeleteBookshelf()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Either:
            // 1. Create a bookshelf first, then delete it
            // 2. Or use TestEnvironment.BookshelfName if deletion is acceptable
            var bookshelfName = "bookshelf-to-delete";
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(bookshelfName);

            // Act
            var operation = await bookshelf.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing bookshelf with properties that can be updated")]
        public async Task UpdateBookshelf()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelfName = TestEnvironment.BookshelfName;
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(bookshelfName);

            // Create update data with modified tags
            var updateData = bookshelf.Value.Data;
            updateData.Tags["updated"] = "true";

            // Act
            var operation = await resourceGroup.GetBookshelves().CreateOrUpdateAsync(
                WaitUntil.Completed,
                bookshelfName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("updated"), Is.True);
        }
    }
}
