// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public class ContainerRegistryClientSamples: SamplesBase<ContainerRegistryTestEnvironment>
    {
        [Test]
        public async Task GetRepositories()
        {
            var endpoint = TestEnvironment.Endpoint;
            var userName = TestEnvironment.UserName;
            var password = TestEnvironment.Password;

            #region Snippet:GetSecret
            var client = new ContainerRegistryClient(new Uri(endpoint), userName, password);

            AsyncPageable<string> repositories = client.GetRepositoriesAsync();

            await foreach (string repository in repositories)
            {
                Console.WriteLine(repository);
            }
            #endregion
        }
    }
}
