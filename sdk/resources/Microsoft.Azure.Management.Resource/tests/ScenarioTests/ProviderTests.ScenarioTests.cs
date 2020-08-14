// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace ResourceGroups.Tests
{
    public class LiveProviderTests : TestBase
    {
        private const string ProviderName = "microsoft.insights";
        public ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClientWithHandler(context, handler);
        }

        [Fact]
        public void ProviderGetValidateMessage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

                var client = GetResourceManagementClient(context, handler);

                var reg = client.Providers.Register(ProviderName);
                Assert.NotNull(reg);

                var result = client.Providers.Get(ProviderName);

                // Validate headers
                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

                // Validate result
                Assert.NotNull(result);
                Assert.NotEmpty(result.Id);
                Assert.Equal(ProviderName, result.NamespaceProperty);
                Assert.True("Registered" == result.RegistrationState ||
                    "Registering" == result.RegistrationState,
                    string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", result.RegistrationState));
                Assert.NotEmpty(result.ResourceTypes);
                Assert.NotEmpty(result.ResourceTypes[0].Locations);
            }
        }

        [Fact]
        public void ProviderListValidateMessage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

                var client = GetResourceManagementClient(context, handler);

                var reg = client.Providers.Register(ProviderName);
                Assert.NotNull(reg);

                var result = client.Providers.List(null);

                // Validate headers
                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

                // Validate result
                Assert.True(result.Any());
                var websiteProvider =
                    result.First(
                        p => p.NamespaceProperty.Equals(ProviderName, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(ProviderName, websiteProvider.NamespaceProperty);
                Assert.True("Registered" == websiteProvider.RegistrationState ||
                    "Registering" == websiteProvider.RegistrationState,
                    string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", websiteProvider.RegistrationState));
                Assert.NotEmpty(websiteProvider.ResourceTypes);
                Assert.NotEmpty(websiteProvider.ResourceTypes[0].Locations);
            }
        }

        [Fact]
        public void GetProviderWithAliases()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var storageNamespace = "Microsoft.Storage";
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

                var client = GetResourceManagementClient(context, handler);

                var reg = client.Providers.Register(storageNamespace);
                Assert.NotNull(reg);

                var result = client.Providers.ListAtTenantScope(expand: "resourceTypes/aliases");

                // Validate headers
                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

                // Validate result
                Assert.True(result.Any());
                var storageProvider = result.First(
                    provider => string.Equals(provider.NamespaceProperty, storageNamespace, StringComparison.OrdinalIgnoreCase));

                Assert.NotEmpty(storageProvider.ResourceTypes);
                var storageAccountsType = storageProvider.ResourceTypes
                    .FirstOrDefault(resourceType => string.Equals(resourceType.ResourceType, "storageAccounts", StringComparison.OrdinalIgnoreCase));

                Assert.NotNull(storageAccountsType);
                Assert.NotNull(storageAccountsType.Aliases);
                Assert.NotEmpty(storageAccountsType.Aliases);

                var httpsOnlyAlias = storageAccountsType.Aliases.FirstOrDefault(alias => string.Equals(alias.Name, "Microsoft.Storage/storageAccounts/supportsHttpsTrafficOnly", StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(httpsOnlyAlias);

                // Validate alias defaults
                Assert.NotNull(httpsOnlyAlias.DefaultPath);
                Assert.Equal("properties.supportsHttpsTrafficOnly", httpsOnlyAlias.DefaultPath, ignoreCase: true);
                Assert.NotNull(httpsOnlyAlias.DefaultMetadata);
                Assert.Equal(AliasPathAttributes.Modifiable, httpsOnlyAlias.DefaultMetadata.Attributes, ignoreCase: false);
                Assert.Equal(AliasPathTokenType.Boolean, httpsOnlyAlias.DefaultMetadata.Type, ignoreCase: false);
                Assert.Null(httpsOnlyAlias.DefaultPattern);

                // Validate alias paths
                Assert.NotNull(httpsOnlyAlias.Paths);
                Assert.Equal(1, httpsOnlyAlias.Paths.Count);

                var aliasPath = httpsOnlyAlias.Paths.Single();
                Assert.Equal("properties.supportsHttpsTrafficOnly", aliasPath.Path, ignoreCase: true);
                Assert.NotNull(aliasPath.ApiVersions);
                Assert.True(aliasPath.ApiVersions.Count() > 0);
                Assert.NotNull(aliasPath.Metadata);
                Assert.Equal(AliasPathAttributes.None, aliasPath.Metadata.Attributes, ignoreCase: false);
                Assert.Equal(AliasPathTokenType.NotSpecified, aliasPath.Metadata.Type, ignoreCase: false);
                Assert.Null(aliasPath.Pattern);
            }
        }

        [Fact]
        public void VerifyProviderRegister()
        {
            var handler = new RecordedDelegatingHandler() {StatusCodeToReturn = HttpStatusCode.OK};
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);

                client.Providers.Register(ProviderName);

                var provider = client.Providers.Get(ProviderName);
                Assert.True(provider.RegistrationState == "Registered" ||
                            provider.RegistrationState == "Registering");
            }
        }

        [Fact]
        public void VerifyProviderUnregister()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);

                var registerResult = client.Providers.Register(ProviderName);

                var provider = client.Providers.Get(ProviderName);
                Assert.True(provider.RegistrationState == "Registered" ||
                            provider.RegistrationState == "Registering");

                var unregisterResult = client.Providers.Unregister(ProviderName);

                provider = client.Providers.Get(ProviderName);
                Assert.True(provider.RegistrationState == "NotRegistered" ||
                            provider.RegistrationState == "Unregistering",
                            "RegistrationState is expected NotRegistered or Unregistering. Actual value " +
                            provider.RegistrationState);
            }
        }
    }
}

