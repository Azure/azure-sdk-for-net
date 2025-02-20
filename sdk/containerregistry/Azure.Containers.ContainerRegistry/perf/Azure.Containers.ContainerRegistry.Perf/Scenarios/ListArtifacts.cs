// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Containers.ContainerRegistry.Perf
{
    public sealed class ListArtifacts : ContainerRegistryPerfTest
    {
        private readonly ContainerRegistryClient _client;
        private ContainerRepository _repository;

        public ListArtifacts(PerfOptions options) : base(options)
        {
            _client = new ContainerRegistryClient(new Uri(PerfTestEnvironment.Instance.Endpoint), PerfTestEnvironment.Instance.Credential,
                new ContainerRegistryClientOptions()
                {
                    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
                });
        }

        public override async Task GlobalSetupAsync()
        {
            // Global setup code that runs once at the beginning of test execution.
            await base.GlobalSetupAsync();

            await ImportImageAsync(PerfTestEnvironment.Instance.Registry, RepositoryName, TagName);
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            _repository = _client.GetRepository(RepositoryName);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (var manifest in _repository.GetAllManifestProperties())
            {
                 _client.GetArtifact(RepositoryName, manifest.Digest);
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var manifest in _repository.GetAllManifestPropertiesAsync())
            {
                _client.GetArtifact(RepositoryName, manifest.Digest);
            }
        }
    }
}
