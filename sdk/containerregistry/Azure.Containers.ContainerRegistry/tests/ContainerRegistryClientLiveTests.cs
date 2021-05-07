// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryClientLiveTests : ContainerRegistryRecordedTestBase
    {
        public ContainerRegistryClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        private ContainerRegistryClient CreateClient(bool anonymousAccess = false)
        {
            return anonymousAccess ?

                InstrumentClient(new ContainerRegistryClient(
                    new Uri(TestEnvironment.Endpoint),
                    InstrumentClientOptions(new ContainerRegistryClientOptions())
                )) :

                InstrumentClient(new ContainerRegistryClient(
                    new Uri(TestEnvironment.Endpoint),
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new ContainerRegistryClientOptions())
                ));
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

        [RecordedTest, NonParallelizable]
        public async Task CanDeleteRepostitory()
        {
            // Arrange
            string repository = $"library/hello-world";
            List<string> tags = new List<string>()
            {
                "latest",
                "v1",
                "v2",
                "v3",
                "v4",
            };
            var client = CreateClient();

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImage(repository, tags);
                }

                // Act
                await client.DeleteRepositoryAsync(repository);

                // Assert
                // This will be removed, pending investigation into potential race condition.
                // https://github.com/azure/azure-sdk-for-net/issues/19699
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(5000);
                }

                var repositories = client.GetRepositoryNamesAsync();

                await foreach (var item in repositories)
                {
                    if (item.Contains(repository))
                    {
                        Assert.Fail($"Repository {repository} was not deleted.");
                    }
                }
            }
            finally
            {
                // Clean up - put the repository with tags back.
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImage(repository, tags);
                }
            }
        }
    }
}
