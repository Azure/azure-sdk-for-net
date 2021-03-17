// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRepositoryClientLiveTests : RecordedTestBase<ContainerRegistryTestEnvironment>
    {
        private readonly string _repositoryName = "library/hello-world";

        public ContainerRepositoryClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private ContainerRepositoryClient CreateClient()
        {
            return InstrumentClient(new ContainerRepositoryClient(
                new Uri(TestEnvironment.Endpoint),
                _repositoryName,
                TestEnvironment.UserName,
                TestEnvironment.Password,
                InstrumentClientOptions(new ContainerRegistryClientOptions())
            ));
        }

        [RecordedTest]
        public async Task CanGetRepositoryProperties()
        {
            var client = CreateClient();

            RepositoryProperties properties = await client.GetPropertiesAsync();

            Assert.AreEqual(_repositoryName, properties.Name);
            Assert.AreEqual(new Uri(TestEnvironment.Endpoint).Host, properties.Registry);
        }

        [RecordedTest]
        public async Task CanSetRepositoryProperties()
        {
            var client = CreateClient();

            await client.SetPropertiesAsync(
                new ContentProperties()
                {
                    CanWrite = false,
                    CanDelete = false
                });

            RepositoryProperties properties = await client.GetPropertiesAsync();

            Assert.IsTrue(properties.ModifiableProperties.CanList);
            Assert.IsTrue(properties.ModifiableProperties.CanRead);
            Assert.IsFalse(properties.ModifiableProperties.CanWrite);
            Assert.IsFalse(properties.ModifiableProperties.CanDelete);

            await client.SetPropertiesAsync(new ContentProperties());

            properties = await client.GetPropertiesAsync();

            Assert.IsTrue(properties.ModifiableProperties.CanList);
            Assert.IsTrue(properties.ModifiableProperties.CanRead);
            Assert.IsTrue(properties.ModifiableProperties.CanWrite);
            Assert.IsTrue(properties.ModifiableProperties.CanDelete);
        }
    }
}
