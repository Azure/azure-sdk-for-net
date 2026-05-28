// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Containers.ContainerRegistry.Perf
{
    public sealed class ListRepositories : ContainerRegistryPerfTest
    {
        private readonly ContainerRegistryClient _client;

        public ListRepositories(PerfOptions options) : base(options)
        {
            _client = new ContainerRegistryClient(new Uri(PerfTestEnvironment.Instance.Endpoint), PerfTestEnvironment.Instance.Credential,
                new ContainerRegistryClientOptions()
                {
                    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
                });
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (var repositoryName in _client.GetRepositoryNames())
            {
                _client.GetRepository(repositoryName);
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var repositoryName in _client.GetRepositoryNamesAsync())
            {
                _client.GetRepository(repositoryName);
            }
        }
    }
}
