// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Test.Perf;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Perf
{
    public abstract class ContainerRegistryPerfTest : PerfTest<PerfOptions>
    {
        public const string RepositoryName = $"library/node";
        public const string TagName = "test-perf";

        public const int BlobSize = 10 * 1024;

        public ContainerRegistryPerfTest(PerfOptions options) : base(options)
        {
        }

        public async Task ImportImageAsync(string registry, string repository, string tag)
        {
            await ImportImageAsync(registry, repository, new List<string>() { tag });
        }

        public async Task ImportImageAsync(string registry, string repository, List<string> tags)
        {
            var credential = new AzureCredentials(
                new ServicePrincipalLoginInformation
                {
                    ClientId = PerfTestEnvironment.Instance.ClientId,
                    ClientSecret = PerfTestEnvironment.Instance.ClientSecret,
                },
                PerfTestEnvironment.Instance.TenantId,
                AzureEnvironment.AzureGlobalCloud);

            var managementClient = new ContainerRegistryManagementClient(credential.WithDefaultSubscription(PerfTestEnvironment.Instance.SubscriptionId));
            managementClient.SubscriptionId = PerfTestEnvironment.Instance.SubscriptionId;

            var importSource = new ImportSource
            {
                SourceImage = repository,
                RegistryUri = "registry.hub.docker.com"
            };

            var targetTags = tags.Select(tag => $"{repository}:{tag}");

            await managementClient.Registries.ImportImageAsync(
                resourceGroupName: PerfTestEnvironment.Instance.ResourceGroup,
                registryName: registry,
                parameters:
                    new ImportImageParameters
                    {
                        Mode = ImportMode.Force,
                        Source = importSource,
                        TargetTags = targetTags.ToList()
                    });
        }
    }
}
