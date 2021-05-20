// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry;
using Azure.Test.Perf;

namespace Azure.Containers.ContainerRegistry.Perf
{
    public sealed class ListArtifacts : ContainerRegistryPerfTest<PerfOptions>
    {
        private readonly ContainerRegistryClient _client;

        public ListArtifacts(PerfOptions options) : base(options)
        {
            _client = new ContainerRegistryClient(new Uri(PerfTestEnvironment.Instance.Endpoint), PerfTestEnvironment.Instance.Credential);
        }

        public override async Task GlobalSetupAsync()
        {
            // Global setup code that runs once at the beginning of test execution.
            await base.GlobalSetupAsync();

            string repository = $"library/node";
            string tag = "test-perf";

            await ImportImage(PerfTestEnvironment.Instance.Registry, repository, tag);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            var repository = _client.GetRepository($"library/node");
            foreach (var manifest in repository.GetManifests())
            {
                 _client.GetArtifact($"library/node", manifest.Digest);
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var repository = _client.GetRepository($"library/node");
            await foreach (var manifest in repository.GetManifestsAsync())
            {
                _client.GetArtifact($"library/node", manifest.Digest);
            }
        }
    }
}
