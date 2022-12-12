// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Identity;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using NUnit.Framework;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryRecordedTestBase : RecordedTestBase<ContainerRegistryTestEnvironment>
    {
        public ContainerRegistryRecordedTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            InitializeRecordingSanitizers();
        }

        [SetUp]
        public void ContainerRegistryTestSetup()
        {
            if (GetAuthorityHost(TestEnvironment.Endpoint) != AzureAuthorityHosts.AzurePublicCloud &&
                UsingAnonymousClient())
            {
                Assert.Ignore("Anonymous client is not enabled in national clouds.");
            }
        }

        public ContainerRegistryClient CreateClient(bool anonymousAccess = false)
        {
            return anonymousAccess ? CreateAnonymousClient() : CreateAuthenticatedClient();
        }

        public ContainerRegistryBlobClient CreateBlobClient(string repository)
        {
            string endpoint = TestEnvironment.Endpoint;
            Uri authorityHost = GetAuthorityHost(endpoint);
            ContainerRegistryAudience audience = GetAudience(authorityHost);

            return InstrumentClient(new ContainerRegistryBlobClient(
                    new Uri(endpoint),
                    TestEnvironment.Credential,
                    repository,
                    InstrumentClientOptions(new ContainerRegistryClientOptions()
                    {
                        Audience = audience
                    })
                ));
        }

        public async Task ImportImageAsync(string registry, string repository, string tag)
        {
            await ImportImageAsync(registry, repository, new List<string>() { tag });
        }

        public async Task ImportImageAsync(string registry, string repository, List<string> tags)
        {
            AzureEnvironment environment = GetManagementCloudEnvironment();

            var credential = new AzureCredentials(
                new ServicePrincipalLoginInformation
                {
                    ClientId = TestEnvironment.ClientId,
                    ClientSecret = TestEnvironment.ClientSecret,
                },
                TestEnvironment.TenantId,
                environment);

            var managementClient = new ContainerRegistryManagementClient(
                new Uri(environment.ResourceManagerEndpoint),
                credential.WithDefaultSubscription(TestEnvironment.SubscriptionId));
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

        public static Uri GetAuthorityHost(string endpoint)
        {
            if (endpoint.Contains(".azurecr.io"))
            {
                return AzureAuthorityHosts.AzurePublicCloud;
            }

            if (endpoint.Contains(".azurecr.cn"))
            {
                return AzureAuthorityHosts.AzureChina;
            }

            if (endpoint.Contains(".azurecr.us"))
            {
                return AzureAuthorityHosts.AzureGovernment;
            }

            if (endpoint.Contains(".azurecr.de"))
            {
                return AzureAuthorityHosts.AzureGermany;
            }

            throw new NotSupportedException($"Cloud for endpoint {endpoint} is not supported.");
        }

        private void InitializeRecordingSanitizers()
        {
            DateTimeOffset expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromDays(365 * 30); // Never expire in software years

            string encodedBody = Base64Url.EncodeString($"{{\"exp\":{expiresOn.ToUnixTimeSeconds()}}}");
            var jwtSanitizedValue = $"{SanitizeValue}.{encodedBody}.{SanitizeValue}";

            BodyKeySanitizers.Add(new BodyKeySanitizer(jwtSanitizedValue)
            {
                JsonPath = "$..refresh_token"
            });

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"access_token=(?<group>.*?)(?=&|$)", SanitizeValue)
            {
                GroupForReplace = "group"
            });

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"refresh_token=(?<group>.*?)(?=&|$)", SanitizeValue)
            {
                GroupForReplace = "group"
            });
        }

        private ContainerRegistryClient CreateAuthenticatedClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            Uri authorityHost = GetAuthorityHost(endpoint);
            ContainerRegistryAudience audience = GetAudience(authorityHost);

            return InstrumentClient(new ContainerRegistryClient(
                    new Uri(endpoint),
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new ContainerRegistryClientOptions()
                    {
                        Audience = audience
                    })
                ));
        }

        private ContainerRegistryClient CreateAnonymousClient()
        {
            string endpoint = TestEnvironment.AnonymousAccessEndpoint;
            Uri authorityHost = GetAuthorityHost(endpoint);
            ContainerRegistryAudience audience = GetAudience(authorityHost);

            return InstrumentClient(new ContainerRegistryClient(
                    new Uri(endpoint),
                    InstrumentClientOptions(new ContainerRegistryClientOptions()
                    {
                        Audience = audience
                    })
                ));
        }

        private ContainerRegistryAudience GetAudience(Uri authorityHost)
        {
            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return ContainerRegistryAudience.AzureResourceManagerPublicCloud;
            }

            if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return ContainerRegistryAudience.AzureResourceManagerChina;
            }

            if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return ContainerRegistryAudience.AzureResourceManagerGovernment;
            }

            if (authorityHost == AzureAuthorityHosts.AzureGermany)
            {
                return ContainerRegistryAudience.AzureResourceManagerGermany;
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }

        private bool UsingAnonymousClient()
        {
            var args = TestContext.CurrentContext.Test.Arguments;
            if (args != null && args.Length > 0 && args[0].GetType() == typeof(bool))
            {
                return (bool)args[0];
            }

            return false;
        }

        /// <summary>
        /// Obtain the track 1 management plane AzureEnvironment value for the
        /// cloud correponding to the configured endpoint.
        /// </summary>
        /// <returns></returns>
        private AzureEnvironment GetManagementCloudEnvironment()
        {
            string endpoint = TestEnvironment.Endpoint;
            Uri authorityHost = GetAuthorityHost(endpoint);

            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return AzureEnvironment.AzureGlobalCloud;
            }

            if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return AzureEnvironment.AzureChinaCloud;
            }

            if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return AzureEnvironment.AzureUSGovernment;
            }

            if (authorityHost == AzureAuthorityHosts.AzureGermany)
            {
                return AzureEnvironment.AzureGermanCloud;
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }
    }
}
