﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public class ContainerRegistrySamplesBase : SamplesBase<ContainerRegistryTestEnvironment>
    {
        public void ImportImage(string registry, string repository, List<string> tags)
        {
            var credential = new AzureCredentials(
                new ServicePrincipalLoginInformation
                {
                    ClientId = TestEnvironment.ClientId,
                    ClientSecret = TestEnvironment.ClientSecret,
                },
                TestEnvironment.TenantId,
                AzureEnvironment.AzureGlobalCloud);

            var managementClient = new ContainerRegistryManagementClient(credential.WithDefaultSubscription(TestEnvironment.SubscriptionId));
            managementClient.SubscriptionId = TestEnvironment.SubscriptionId;

            var importSource = new ImportSource
            {
                SourceImage = repository,
                RegistryUri = "registry.hub.docker.com"
            };

            var targetTags = tags.Select(tag => $"{repository}:{tag}");

            managementClient.Registries.ImportImage(
                resourceGroupName: TestEnvironment.ResourceGroup,
                registryName: registry,
                parameters:
                    new ImportImageParameters
                    {
                        Mode = ImportMode.Force,
                        Source = importSource,
                        TargetTags = targetTags.ToList()
                    });
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
                    ClientId = TestEnvironment.ClientId,
                    ClientSecret = TestEnvironment.ClientSecret,
                },
                TestEnvironment.TenantId,
                AzureEnvironment.AzureGlobalCloud);

            var managementClient = new ContainerRegistryManagementClient(credential.WithDefaultSubscription(TestEnvironment.SubscriptionId));
            managementClient.SubscriptionId = TestEnvironment.SubscriptionId;

            var importSource = new ImportSource
            {
                SourceImage = repository,
                RegistryUri = "registry.hub.docker.com"
            };

            var targetTags = tags.Select(tag => $"{repository}:{tag}");

            await managementClient.Registries.ImportImageAsync(
                resourceGroupName: TestEnvironment.ResourceGroup,
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
