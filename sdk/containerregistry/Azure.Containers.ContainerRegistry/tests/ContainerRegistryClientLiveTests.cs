// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryClientLiveTests: RecordedTestBase<ContainerRegistryTestEnvironment>
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
            throw new Exception($"Endpoint value is {TestEnvironment.Endpoint}");

            //var client = CreateClient();

            //AsyncPageable<string> repositories = client.GetRepositoriesAsync();
            //bool getsHelloWorld = await repositories.ContainsAsync("library/hello-world");

            //Assert.IsTrue(getsHelloWorld);
        }
    }
}
