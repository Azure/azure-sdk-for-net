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
            Assert.IsTrue(gotHelloWorld);
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
                Assert.IsTrue(page.Values.Count <= pageSize);
                pageCount++;
            }

            // Assert
            Assert.GreaterOrEqual(pageCount, minExpectedPages);
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

                Assert.IsTrue(page.Values.Count <= pageSize);
                pageCount++;
            }

            // Assert
            Assert.NotNull(firstPage);
            Assert.AreEqual("library/busybox", firstPage.Values[0]);
            Assert.IsTrue(pageCount >= minExpectedPages);
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
                Assert.IsTrue(await repositories.ContainsAsync(repositoryId), $"Test set-up failed: Repository {repositoryId} was not created.");

                // Act
                await client.DeleteRepositoryAsync(repositoryId);
                await Delay(5000);

                // Assert
                repositories = client.GetRepositoryNamesAsync();
                Assert.IsFalse(await repositories.ContainsAsync(repositoryId), $"Repository {repositoryId} was not deleted.");
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
