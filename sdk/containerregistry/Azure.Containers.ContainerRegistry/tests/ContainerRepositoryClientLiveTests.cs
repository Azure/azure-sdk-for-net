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
        private ContainerRepositoryClient _client;

        public ContainerRepositoryClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        protected void CreateClient()
        {
            _client = InstrumentClient(new ContainerRepositoryClient(
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
            RepositoryProperties properties = await _client.GetPropertiesAsync();

            Assert.AreEqual(_repositoryName, properties.Name);
            Assert.AreEqual(new Uri(TestEnvironment.Endpoint).Host, properties.Registry);
        }

        [RecordedTest]
        public async Task CanSetRepositoryProperties([Values(true, false)] bool canList,
                                                     [Values(true, false)] bool canRead,
                                                     [Values(true, false)] bool canWrite,
                                                     [Values(true, false)] bool canDelete)
        {
            await _client.SetPropertiesAsync(
                new ContentProperties()
                {
                    CanList = canList,
                    CanRead = canRead,
                    CanWrite = canWrite,
                    CanDelete = canDelete
                });

            RepositoryProperties properties = await _client.GetPropertiesAsync();

            Assert.AreEqual(canList, properties.ModifiableProperties.CanList);
            Assert.AreEqual(canRead, properties.ModifiableProperties.CanRead);
            Assert.AreEqual(canWrite, properties.ModifiableProperties.CanWrite);
            Assert.AreEqual(canDelete, properties.ModifiableProperties.CanDelete);
        }

        [TearDown]
        public async Task ResetRepositoryProperties()
        {
            await _client.SetPropertiesAsync(new ContentProperties());

            RepositoryProperties properties = await _client.GetPropertiesAsync();

            Assert.IsTrue(properties.ModifiableProperties.CanList);
            Assert.IsTrue(properties.ModifiableProperties.CanRead);
            Assert.IsTrue(properties.ModifiableProperties.CanWrite);
            Assert.IsTrue(properties.ModifiableProperties.CanDelete);
        }
    }
}
