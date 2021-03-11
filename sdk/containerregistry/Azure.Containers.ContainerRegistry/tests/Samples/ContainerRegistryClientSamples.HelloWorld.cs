// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using System.Linq;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public class ContainerRegistryClientSamples: SamplesBase<ContainerRegistryTestEnvironment>
    {
        [Test]
        public void GetRepositories()
        {
            var endpoint = TestEnvironment.Endpoint;

            #region Snippet:GetSecret
            var client = new ContainerRegistryClient(new Uri(endpoint));

            AsyncPageable<string> repositories = client.GetRepositoriesAsync();

            Console.WriteLine(/* first repo name */);
            #endregion
        }
    }
}
