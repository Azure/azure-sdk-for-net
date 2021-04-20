// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using NUnit.Framework;
using System.Linq;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryRecordedTestBase : RecordedTestBase<ContainerRegistryTestEnvironment>
    {
        protected ContainerRegistryRecordedTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ContainerRegistryRecordedTestSanitizer();
        }

        public ContainerRegistryRecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            Sanitizer = new ContainerRegistryRecordedTestSanitizer();
        }

        public async Task ImportImage(string repository, string tag)
        {
            await ImportImage(repository, new List<string>() { tag });
        }

        public async Task ImportImage(string repository, List<string> tags)
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
                registryName: TestEnvironment.Registry,
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
