// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryClientLiveTests : ContainerRegistryRecordedTestBase
    {
        public ContainerRegistryClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetRepositories(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);

            // Act
            AsyncPageable<string> repositories = client.GetRepositoryNamesAsync();

            bool gotHelloWorld = false;
            await foreach (string repository in repositories)
            {
                if (repository.Contains("library/hello-world"))
                {
                    gotHelloWorld = true;
                    break;
                }
            }

            // Assert
            Assert.That(gotHelloWorld, Is.True);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetRepositoriesWithCustomPageSize(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            int pageSize = 2;
            int minExpectedPages = 2;

            // Act
            AsyncPageable<string> repositories = client.GetRepositoryNamesAsync();
            var pages = repositories.AsPages(pageSizeHint: pageSize);

            int pageCount = 0;
            await foreach (var page in pages)
            {
                Assert.That(page.Values.Count <= pageSize, Is.True);
                pageCount++;
            }

            // Assert
            Assert.That(pageCount, Is.GreaterThanOrEqualTo(minExpectedPages));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanStartPagingMidCollection(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            int pageSize = 1;
            int minExpectedPages = 2;

            // Act
            AsyncPageable<string> repositories = client.GetRepositoryNamesAsync();
            var pages = repositories.AsPages($"</acr/v1/_catalog?last=library/alpine&n={pageSize}>");

            int pageCount = 0;
            Page<string> firstPage = null;
            await foreach (var page in pages)
            {
                if (pageCount == 0)
                {
                    firstPage = page;
                }

                Assert.That(page.Values.Count <= pageSize, Is.True);
                pageCount++;
            }

            // Assert
            Assert.That(firstPage, Is.Not.Null);
            Assert.That(firstPage.Values[0], Is.EqualTo("library/busybox"));
            Assert.That(pageCount >= minExpectedPages, Is.True);
        }

        [RecordedTest]
        public async Task CanDeleteRepository()
        {
            // Arrange
            var client = CreateClient();
            var repositoryId = Recording.Random.NewGuid().ToString();

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await CreateRepositoryAsync(repositoryId);
                }

                var repositories = client.GetRepositoryNamesAsync();
                Assert.That(await repositories.ContainsAsync(repositoryId), Is.True, $"Test set-up failed: Repository {repositoryId} was not created.");

                // Act
                await client.DeleteRepositoryAsync(repositoryId);
                await Delay(5000);

                // Assert
                repositories = client.GetRepositoryNamesAsync();
                Assert.That(await repositories.ContainsAsync(repositoryId), Is.False, $"Repository {repositoryId} was not deleted.");
            }
            finally
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await DeleteRepositoryAsync(repositoryId);
                }
            }
        }

        [RecordedTest, NonParallelizable]
        public void CanDeleteRepository_Anonymous()
        {
            // Arrange
            string repository = $"library/hello-world";
            var client = CreateClient(anonymousAccess: true);

            Assert.ThrowsAsync<RequestFailedException>(() => client.DeleteRepositoryAsync(repository));
        }
    }
}
