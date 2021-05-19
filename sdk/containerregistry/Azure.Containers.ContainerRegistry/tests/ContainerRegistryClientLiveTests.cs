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
        }

        private ContainerRegistryClient CreateClient()
        {
            return InstrumentClient(new ContainerRegistryClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.UserName,
                TestEnvironment.Password,
                InstrumentClientOptions(new ContainerRegistryClientOptions())
            ));
        }

        [RecordedTest]
        public async Task CanGetRepositories()
        {
            var client = CreateClient();

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

            Assert.IsTrue(gotHelloWorld);
        }
    }
}
