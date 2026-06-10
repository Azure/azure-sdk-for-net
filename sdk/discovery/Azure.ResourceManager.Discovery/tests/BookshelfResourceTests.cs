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
        [Ignore("Recording not yet captured")]
        public async Task CreateBookshelf()
        {
            // Arrange - Bookshelf only requires location (matching Python/Java)
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelfName = TestEnvironment.BookshelfName;

            var bookshelfData = new BookshelfData(DefaultLocation);

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
            var bookshelfName = TestEnvironment.BookshelfName;
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

            // Update tags matching Python/Java pattern
            var updateData = bookshelf.Value.Data;
            updateData.Tags["SkipAutoDeleteTill"] = "2026-12-31";

            // Act
            var operation = await resourceGroup.GetBookshelves().CreateOrUpdateAsync(
                WaitUntil.Completed,
                bookshelfName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("SkipAutoDeleteTill"), Is.True);
        }
    }
}
