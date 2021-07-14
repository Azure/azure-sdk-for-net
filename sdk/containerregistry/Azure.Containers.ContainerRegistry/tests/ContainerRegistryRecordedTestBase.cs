// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
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

        public ContainerRegistryClient CreateClient(bool anonymousAccess = false)
        {
            return anonymousAccess ? CreateAnonymousClient() : CreateAuthenticatedClient();
        }

        private ContainerRegistryClient CreateAuthenticatedClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            string authenticationScope = GetAuthenticationScope(endpoint);

            return InstrumentClient(new ContainerRegistryClient(
                    new Uri(endpoint),
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new ContainerRegistryClientOptions()
                    {
                        AuthenticationScope = authenticationScope
                    })
                ));
        }

        private ContainerRegistryClient CreateAnonymousClient()
        {
            string endpoint = TestEnvironment.AnonymousAccessEndpoint;
            string authenticationScope = GetAuthenticationScope(endpoint);

            return InstrumentClient(new ContainerRegistryClient(
                    new Uri(endpoint),
                    InstrumentClientOptions(new ContainerRegistryClientOptions()
                    {
                        AuthenticationScope = authenticationScope
                    })
                ));
        }

        private string GetAuthenticationScope(string endpoint)
        {
            if (endpoint.Contains(".azurecr.io"))
            {
                // ACR's authentication scope for Azure Public cloud
                return "https://management.core.windows.net/.default";
            }

            if (endpoint.Contains(".azurecr.cn"))
            {
                // ACR's authentication scope for Azure China cloud
                return "https://management.chinacloudapi.cn/.default";
            }

            if (endpoint.Contains(".azurecr.us"))
            {
                // ACR's authentication scope for US Government cloud
                return "https://management.usgovcloudapi.net/.default";
            }

            if (endpoint.Contains(".azurecr.de"))
            {
                // ACR's authentication scope for Azure Germany cloud
                return "https://management.microsoftazure.de/";
            }

            throw new NotSupportedException($"Cloud for endpoint {endpoint} is not supported.");
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
                GetManagementCloudEnvironment());

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

        /// <summary>
        /// Obtain the track 1 management plane AzureEnvironment value for the
        /// cloud correponding to the configured endpoint.
        /// </summary>
        /// <returns></returns>
        private AzureEnvironment GetManagementCloudEnvironment()
        {
            string endpoint = TestEnvironment.Endpoint;

            if (endpoint.Contains(".azurecr.io"))
            {
                return AzureEnvironment.AzureGlobalCloud;
            }

            if (endpoint.Contains(".azurecr.cn"))
            {
                return AzureEnvironment.AzureChinaCloud;
            }

            if (endpoint.Contains(".azurecr.us"))
            {
                return AzureEnvironment.AzureUSGovernment;
            }

            if (endpoint.Contains(".azurecr.de"))
            {
                return AzureEnvironment.AzureGermanCloud;
            }

            throw new NotSupportedException($"Cloud for endpoint {endpoint} is not supported.");
        }
    }
}
