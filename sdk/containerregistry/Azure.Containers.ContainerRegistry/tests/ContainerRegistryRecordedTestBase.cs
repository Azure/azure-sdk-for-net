// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Identity;
using NUnit.Framework;

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

        public ContainerRegistryContentClient CreateBlobClient(string repository, int? chunkSize = default)
        {
            string endpoint = TestEnvironment.Endpoint;
            Uri authorityHost = GetAuthorityHost(endpoint);
            ContainerRegistryAudience audience = GetAudience(authorityHost);

            ContainerRegistryClientOptions options = InstrumentClientOptions(new ContainerRegistryClientOptions()
            {
                Audience = audience
            });

            return InstrumentClient(new ContainerRegistryContentClient(
                    new Uri(endpoint),
                    repository,
                    TestEnvironment.Credential,
                    options));
        }

        public async Task CreateRepositoryAsync(string repository)
        {
            await CreateImageAsync(repository, null);
        }

        public async Task<string> CreateImageAsync(string repository, string tag)
        {
            return await CreateImageAsync(new Uri(TestEnvironment.Endpoint), repository, tag);
        }

        public async Task<string> CreateImageAsync(Uri endpoint, string repository, string tag)
        {
            var client = GetUploadClient(endpoint, repository);
            return await client.UploadTestImageAsync(tag);
        }

        public async Task AddTagAsync(Uri endpoint, string repository, string reference, string tag)
        {
            var client = GetUploadClient(endpoint, repository);
            await client.AddTagAsync(reference, tag);
        }

        public async Task DeleteRepositoryAsync(string repository)
        {
            await DeleteRepositoryAsync(new Uri(TestEnvironment.Endpoint), repository);
        }

        public async Task DeleteRepositoryAsync(Uri endpoint, string repository)
        {
            var client = GetSetupClient(endpoint);
            await client.GetRepository(repository).DeleteAsync();
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

            throw new NotSupportedException($"Cloud for endpoint {endpoint} is not supported.");
        }

        private void InitializeRecordingSanitizers()
        {
            DateTimeOffset expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromDays(365 * 30); // Never expire in software years

            string encodedBody = Base64Url.EncodeString($"{{\"exp\":{expiresOn.ToUnixTimeSeconds()}}}");
            var jwtSanitizedValue = $"{SanitizeValue}.{encodedBody}.{SanitizeValue}";

            BodyKeySanitizers.Add(new BodyKeySanitizer("$..refresh_token")
            {
                Value = jwtSanitizedValue
            });

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"access_token=(?<group>.*?)(?=&|$)")
            {
                GroupForReplace = "group"
            });

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"refresh_token=(?<group>.*?)(?=&|$)")
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

        private ContainerRegistryClient GetSetupClient(Uri endpoint)
        {
            Uri authorityHost = GetAuthorityHost(endpoint.ToString());

            // We won't record the set-up calls, so don't instrument this client.
            return new ContainerRegistryClient(endpoint,
                TestEnvironment.Credential,
                new ContainerRegistryClientOptions()
                {
                    Audience = GetAudience(authorityHost)
                });
        }

        private ContainerRegistryContentClient GetUploadClient(Uri endpoint, string repository)
        {
            Uri authorityHost = GetAuthorityHost(endpoint.ToString());

            // We won't record the set-up calls, so don't instrument this client.
            return new ContainerRegistryContentClient(endpoint,
                repository,
                TestEnvironment.Credential,
                new ContainerRegistryClientOptions()
                {
                    Audience = GetAudience(authorityHost)
                });
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
    }
}
