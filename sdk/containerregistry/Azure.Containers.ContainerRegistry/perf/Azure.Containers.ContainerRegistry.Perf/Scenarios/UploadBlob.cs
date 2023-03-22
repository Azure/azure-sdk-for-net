// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Containers.ContainerRegistry.Perf
{
    public sealed class UploadBlob : ContainerRegistryPerfTest
    {
        private readonly ContainerRegistryContentClient _client;
        private ContainerRepository _repository;

        public UploadBlob(PerfOptions options) : base(options)
        {
            _client = new ContainerRegistryClient(new Uri(PerfTestEnvironment.Instance.Endpoint), PerfTestEnvironment.Instance.Credential);
        }

        public override async Task GlobalSetupAsync()
        {
            // Global setup code that runs once at the beginning of test execution.
            await base.GlobalSetupAsync();

            await ImportImageAsync(PerfTestEnvironment.Instance.Registry, RepositoryName, "latest");
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            _repository = _client.GetRepository($"library/node");
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _clie
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var manifest in _repository.GetAllManifestPropertiesAsync())
            {
                _client.GetArtifact($"library/node", manifest.Digest);
            }
        }
    }
}
