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
using System.Runtime.InteropServices;

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

        public ContainerRegistryClient CreateClient(bool anonymousAccess = false, string authenticationScope = null)
        {
            return anonymousAccess ?

                InstrumentClient(new ContainerRegistryClient(
                    new Uri(TestEnvironment.AnonymousAccessEndpoint),
                    InstrumentClientOptions(new ContainerRegistryClientOptions())
                )) :

                InstrumentClient(new ContainerRegistryClient(
                    new Uri(TestEnvironment.Endpoint),
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new ContainerRegistryClientOptions())
                ));
        }

        protected string GetPlatformSuffix()
        {
            var os = FormatIdentifier(RuntimeInformation.OSDescription);
            var dotnetVersion = FormatIdentifier(RuntimeInformation.FrameworkDescription);
            return $"-{os}-{dotnetVersion}";
        }

        private string FormatIdentifier(string value)
        {
            List<string> invalidCharacters = new List<string> { " ", ".", "#", "~", ":", ";", "/", "\\" };
            foreach (var invalid in invalidCharacters)
            {
                value = value.Replace(invalid, string.Empty);
            }

            int maxLength = 25;
            if (value.Length > maxLength)
            {
                value = value.Substring(0, maxLength);
            }

            return value.ToLower();
        }

        public async Task ImportImageAsync(string registry, string repository, string tag, string targetRepository = default)
        {
            await ImportImageAsync(registry, repository, new List<string>() { tag }, targetRepository);
        }

        public async Task ImportImageAsync(string registry, string repository, List<string> tags, string targetRepository = default)
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

            var target = targetRepository ?? repository;
            var targetTags = tags.Select(tag => $"{target}:{tag}");

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

        public async Task ImportImageByDigestAsync(string registry, string repository, string digest, string targetRepository, string targetTag)
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
                SourceImage = $"{repository}@{digest}",
                RegistryUri = "registry.hub.docker.com"
            };

            var targetImage = $"{targetRepository}:{targetTag}";

            await managementClient.Registries.ImportImageAsync(
                resourceGroupName: TestEnvironment.ResourceGroup,
                registryName: registry,
                parameters:
                    new ImportImageParameters
                    {
                        Mode = ImportMode.Force,
                        Source = importSource,
                        TargetTags = new List<string>() { targetImage }
                    });
            ;
        }
    }
}
