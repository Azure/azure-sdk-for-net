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
    public sealed class ListRepositories : ContainerRegistryPerfTest<PerfOptions>
    {
        private readonly ContainerRegistryClient _client;

        public ListRepositories(PerfOptions options) : base(options)
        {
            _client = new ContainerRegistryClient(new Uri(PerfTestEnvironment.Instance.Endpoint), PerfTestEnvironment.Instance.Credential);
        }

        public override async Task GlobalSetupAsync()
        {
            // Global setup code that runs once at the beginning of test execution.
            await base.GlobalSetupAsync();
        }

        public override async Task SetupAsync()
        {
            // Individual test-level setup code that runs for each instance of the test.
            await base.SetupAsync();
        }

        public override async Task CleanupAsync()
        {
            // Individual test-level cleanup code that runs for each instance of the test.
            await base.CleanupAsync();
        }

        public override async Task GlobalCleanupAsync()
        {
            // Global cleanup code that runs once at the end of test execution.
            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            var names = new List<string>();
            foreach (var repositoryName in _client.GetRepositoryNames())
            {
                names.Add(repositoryName);
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var names = new List<string>();
            await foreach (var repositoryName in _client.GetRepositoryNamesAsync())
            {
                names.Add(repositoryName);
            }
        }
    }
}
