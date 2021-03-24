// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryClientLiveTests : RecordedTestBase<ContainerRegistryTestEnvironment>
    {
        public ContainerRegistryClientLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ContainerRegistryRecordedTestSanitizer();
        }

        private ContainerRegistryClient CreateClient()
        {
            return InstrumentClient(new ContainerRegistryClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ContainerRegistryClientOptions())
            ));
        }

        [RecordedTest]
        public async Task CanGetRepositories()
        {
            // Arrange
            var client = CreateClient();

            // Act
            AsyncPageable<string> repositories = client.GetRepositoriesAsync();

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
        public async Task CanGetRepositoriesWithCustomPageSize()
        {
            // Arrange
            var client = CreateClient();
            int pageSize = 2;

            // Act
            AsyncPageable<string> repositories = client.GetRepositoriesAsync();
            var pages = repositories.AsPages(pageSizeHint: pageSize);

            // Assert
            int pageCount = 0;
            await foreach (var page in pages)
            {
                Assert.IsTrue(page.Values.Count <= pageSize);
                pageCount++;
            }

            Assert.IsTrue(pageCount > 2);
        }
    }
}
