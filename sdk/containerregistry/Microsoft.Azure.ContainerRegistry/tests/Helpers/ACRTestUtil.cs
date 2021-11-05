// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.Management.ContainerRegistry;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using static Microsoft.Azure.ContainerRegistry.AuthToken;
    using static Microsoft.Azure.ContainerRegistry.ContainerRegistryCredentials;

    public static class ACRTestUtil
    {
        private static readonly string _testResourceGroup = "ereyTest";

        // Sample Repos for fetching
        public static readonly string ProdRepository = "prod/bash";
        public static readonly string TestRepository = "test/bash";

        //Repo for update or create-delete operations
        public static readonly string changeableRepository = "doundo/bash";

        //Repository with multiple hello-world# tags for deletion testing
        public static readonly string deleteableRepository = "deleteable";

        //Prod Test registry
        public static readonly string ManagedTestRegistry = "azuresdkunittest";
        public static readonly string ManagedTestRegistryFullName = "azuresdkunittest.azurecr.io";

        //Prod Test registry for updates and deletions (contains many hello-world# images)
        public static readonly string ManagedTestRegistryForChanges = "azuresdkunittestupdateable";
        public static readonly string ManagedTestRegistryForChangesFullName = "azuresdkunittestupdateable.azurecr.io";

        internal static readonly string Scope = "registry:catalog:*";
        internal static readonly string MediatypeV2Manifest = "application/vnd.docker.distribution.manifest.v2+json";
        internal static readonly string MediatypeV1Manifest = "application/vnd.docker.container.image.v1+json";
        internal static readonly string MediatypeOCIManifest = "application/vnd.oci.image.manifest.v1+json";
        internal static readonly string MediatypeOCIIndex = "application/vnd.oci.image.index.v1+json";
        internal static readonly string MediatypeManifestList = "application/vnd.docker.distribution.manifest.list.v2+json";
        internal static readonly string OCIIndexTestRepository = "";
        internal static readonly string ManifestListTestRepository = "multi-hello-world";
        internal static readonly string BlobTestRepository = "blobland";
        internal static string OCITestRepository = "oras";

        internal static string ACRJWTIssuer = "Azure Container Registry";

        /// <summary>
        /// Acquires an ACR client setup for the testing network. Note acquisition of credentials from registry
        /// must be possible for this to work in this way.
        /// </summary>
        /// <param name="registryName"> Registry to be used </param>
        /// <returns></returns>
        public static async Task<AzureContainerRegistryClient> GetACRClientAsync(MockContext context, string registryName, LoginMode loginMode = ContainerRegistryCredentials.LoginMode.Basic)
        {
            var registryManagementClient = context.GetServiceClient<ContainerRegistryManagementClient>(handlers: CreateNewRecordedDelegatingHandler());
            var registry = await registryManagementClient.Registries.GetAsync(_testResourceGroup, registryName);

            ContainerRegistryCredentials credential = null;

            switch (loginMode)
            {
                case LoginMode.Basic:
                case LoginMode.TokenAuth:
                    var registryCredentials = await registryManagementClient.Registries.ListCredentialsAsync(_testResourceGroup, registryName);
                    string username = registryCredentials.Username;
                    string password = registryCredentials.Passwords[0].Value;
                    credential = new ContainerRegistryCredentials(loginMode, registry.LoginServer, username, password);
                    break;
                case LoginMode.TokenAad:
                    var aadToken = await GetAADAccessToken();
                    AcquireCallback newAADCallback = () => GetAADAccessToken().GetAwaiter().GetResult();
                    credential = new ContainerRegistryCredentials(aadToken, registry.LoginServer, newAADCallback);
                    break;
                default:
                    throw new ArgumentException($"Unkown {nameof(LoginMode)}. Expected one of ['{LoginMode.Basic}', '{LoginMode.TokenAuth}', '{LoginMode.TokenAad}'] but got '{loginMode}'");
            }

            var acrClient = context.GetServiceClientWithCredentials<AzureContainerRegistryClient>(credential, CreateNewRecordedDelegatingHandler());
            return acrClient;
        }

        /// <summary>
        /// Acquires registry credentials for the testing network. 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="registryName"></param>
        /// <param name="loginMode"></param>
        /// <returns></returns>
        public static async Task<ContainerRegistryCredentials> GetCredentialsAsync(MockContext context, string registryName, LoginMode loginMode = ContainerRegistryCredentials.LoginMode.TokenAuth)
        {
            var registryManagementClient = context.GetServiceClient<ContainerRegistryManagementClient>(handlers: CreateNewRecordedDelegatingHandler());
            var registry = await registryManagementClient.Registries.GetAsync(_testResourceGroup, registryName);

            ContainerRegistryCredentials credential = null;

            switch (loginMode)
            {
                case LoginMode.Basic:
                case LoginMode.TokenAuth:
                    var registryCredentials = await registryManagementClient.Registries.ListCredentialsAsync(_testResourceGroup, registryName);
                    string username = registryCredentials.Username;
                    string password = registryCredentials.Passwords[0].Value;
                    credential = new ContainerRegistryCredentials(loginMode, registry.LoginServer, username, password);                    
                    break;
                case LoginMode.TokenAad:
                    var aadToken = await GetAADAccessToken();
                    AcquireCallback newAADCallback = () => GetAADAccessToken().GetAwaiter().GetResult();
                    credential = new ContainerRegistryCredentials(aadToken, registry.LoginServer, newAADCallback);
                    break;
                default:
                    throw new ArgumentException($"Unkown {nameof(LoginMode)}. Expected one of ['{LoginMode.Basic}', '{LoginMode.TokenAuth}', '{LoginMode.TokenAad}'] but got '{loginMode}'");
            }

            return credential;
        }

        /// <summary>
        /// Acquires an AAD access token from the connection string setup in the environment variables.
        /// In order to run the tests outside of playback mode (where it replays the session recording files)
        /// you must first do the following:
        /// 
        /// Add environment variables:
        /// AZURE_TEST_MODE | set it to "record"
        /// 
        /// TEST_CSM_ORGID_AUTHENTICATION | set it to:
        /// SubscriptionId={subscription id for service principal};ServicePrincipal={servicePrincipal};ServicePrincipalSecret={serviceprincipalsecret};AADTenant={tenant of service principal};Environment=Prod;HttpRecorderMode=Record
        /// 
        /// Note that the the service principal in question must have access to the azuresdkunittest registry or any specified as prod in the future.
        /// </summary>

        public static async Task<string> GetAADAccessToken()
        {
            TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.AADTenantKey];
            string authClientId = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];
            string authSecret = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey];

            // Addresses issues from pipeline having no credentials to obtain AAD token. 
            // Return Dummy token.
            if (String.IsNullOrEmpty(tenantId) || String.IsNullOrEmpty(authClientId) || String.IsNullOrEmpty(authSecret)) {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateJwtSecurityToken(ACRJWTIssuer, ManagedTestRegistryFullName, null, null, DateTime.UtcNow.AddHours(5), null, null);
                return tokenHandler.WriteToken(token);

            }

            var context = new AuthenticationContext("https://login.microsoftonline.com/" + tenantId + "/oauth2/v2.0/token");
            var clientCredential = new ClientCredential(authClientId, authSecret);
            var result = await context.AcquireTokenAsync("https://management.core.windows.net", clientCredential).ConfigureAwait(false);
            return result.AccessToken;
        }

        private static RecordedDelegatingHandler CreateNewRecordedDelegatingHandler()
        {
            return new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };
        }
    }
}
