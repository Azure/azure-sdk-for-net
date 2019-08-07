// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using global::ContainerRegistry.Tests;
    using Microsoft.Azure.Management.ContainerRegistry;
    using Microsoft.Rest;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.ContainerRegistry;
    using System.Threading;
    using System.Net.Http;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System.Dynamic;

    public static class ACRTestUtil
    {
        private static readonly string _testResourceGroup = "ereyTest";

        public static readonly string ProdRepository = "prod/bash";
        public static readonly string TestRepository = "test/bash";
        public static readonly string changeableRepository = "doundo/bash";
        public static readonly string deleteableRepository = "deleteable";

        public static readonly string ManagedTestRegistry = "azuresdkunittest";
        public static readonly string ManagedTestRegistryFullName = "azuresdkunittest.azurecr.io";
        public static readonly string ManagedTestRegistryForChanges = "azuresdkunittestupdateable";
        public static readonly string Scope = "registry:catalog:*";

        private class TokenCredentials : ServiceClientCredentials
        {
            /*To be used for exchanging AAD Tokens for ACR Tokens*/
            public TokenCredentials() {}
            public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                await base.ProcessHttpRequestAsync(request, cancellationToken);
            }
        }

        public static async Task<AzureContainerRegistryClient> GetACRClientAsync(MockContext context, string registryName)
        {
            var registryManagementClient = context.GetServiceClient<ContainerRegistryManagementClient>(handlers: CreateNewRecordedDelegatingHandler());
            var registry = await registryManagementClient.Registries.GetAsync(_testResourceGroup, registryName);
            var registryCredentials = await registryManagementClient.Registries.ListCredentialsAsync(_testResourceGroup, registryName);
            string username = registryCredentials.Username;
            string password = registryCredentials.Passwords[0].Value;
            AcrClientCredentials credential = new AcrClientCredentials(AcrClientCredentials.LoginMode.Basic, registry.LoginServer, username, password);
            var acrClient = context.GetServiceClientWithCredentials<AzureContainerRegistryClient>(credential, CreateNewRecordedDelegatingHandler());
            acrClient.LoginUri = "https://" + registry.LoginServer;

            return acrClient;
        }

        public static async Task<string> getAADaccessToken() {
                TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                var context = new AuthenticationContext("https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47/oauth2/v2.0/token");
                string authClientId = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];
                string authSecret = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey];
                var clientCredential = new ClientCredential(authClientId, authSecret);
                var result = await context.AcquireTokenAsync(authClientId, clientCredential).ConfigureAwait(false);
                return result.AccessToken;
        }

        public static ContainerRegistryManagementClient GetACRManagementClient(MockContext context, string registryName)
        {
            var registryManagementClient = context.GetServiceClient<ContainerRegistryManagementClient>(handlers: CreateNewRecordedDelegatingHandler());
            return registryManagementClient;
        }

        private static RecordedDelegatingHandler CreateNewRecordedDelegatingHandler()
        {
            return new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };
        }

    }
}
