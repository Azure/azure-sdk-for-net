﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            _client = new ContainerRegistryClient(new Uri(PerfTestEnvironment.Instance.Endpoint), PerfTestEnvironment.Instance.Credential);
        }

        public override async Task GlobalSetupAsync()
        {
            // Global setup code that runs once at the beginning of test execution.
            await base.GlobalSetupAsync();

            string repository = $"library/node";
            string tag = "test-perf";

            await ImportImageAsync(PerfTestEnvironment.Instance.Registry, repository, tag);
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            _repository = _client.GetRepository($"library/node");
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (var manifest in _repository.GetManifests())
            {
                 _client.GetArtifact($"library/node", manifest.Digest);
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var manifest in _repository.GetManifestsAsync())
            {
                _client.GetArtifact($"library/node", manifest.Digest);
            }
        }
    }
}
