// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ResourceManager;
using System.Net;
using Microsoft.Rest.TransientFaultHandling;

namespace KeyVault.TestFramework
{
    public class KeyVaultTestFixture : IDisposable
    {
        // Required in test code
        public string vaultAddress;
        public bool standardVaultOnly;
        public bool softDeleteEnabled;
        public string keyName;
        public string keyVersion;
        public KeyIdentifier keyIdentifier;
        public ClientCredential clientCredential;
        public RetryPolicy retryExecutor;

        // Required for cleaning up at the end of the test
        private string rgName = "", appObjectId = "";
        private bool fromConfig;
        private TokenCache tokenCache;

        public KeyVaultTestFixture()
        {
            Initialize(string.Empty);

            if (vaultAddress != null && HttpMockServer.Mode == HttpRecorderMode.Record)
            { 
                //Create one key to use for testing. Key creation is expensive.
                var myClient = new KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), GetHandlers());
                keyName = "sdktestkey";
                var attributes = new KeyAttributes();
                var createdKey = myClient.CreateKeyAsync(vaultAddress, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, attributes).GetAwaiter().GetResult();
                keyIdentifier = new KeyIdentifier(createdKey.Key.Kid);
                keyName = keyIdentifier.Name;
                keyVersion = keyIdentifier.Version;
                tokenCache = new TokenCache();
                retryExecutor = new RetryPolicy<SoftDeleteErrorDetectionStrategy>(new ExponentialBackoffRetryStrategy(8, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(5)));
            } else
            {
                retryExecutor = new RetryPolicy<SoftDeleteErrorDetectionStrategy>( new FixedIntervalRetryStrategy( 5, TimeSpan.FromSeconds( 5.0 ) ) );
            }
        }

        public void Initialize(string className)
        {
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            HttpMockServer.Initialize(className, "InitialCreation", HttpRecorderMode.Record);
            HttpMockServer.CreateInstance();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                fromConfig = FromConfiguration();
            }
        }

        private static string GetKeyVaultLocation(ResourceManagementClient resourcesClient)
        {
            var providers = resourcesClient.Providers.Get("Microsoft.KeyVault");
            var location = providers.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "vaults")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();
            return location;
        }

        private static ServicePrincipal CreateServicePrincipal(Application app,
            GraphRbacManagementClient graphClient)
        {
            var parameters = new ServicePrincipalCreateParameters
            {
                AccountEnabled = true,
                AppId = app.AppId
            };
            var servicePrincipal = graphClient.ServicePrincipal.Create(parameters);
            return servicePrincipal;
        }

        private static Application CreateApplication(GraphRbacManagementClient graphClient, string appDisplayName, string secret)
        {
            return graphClient.Application.Create(new ApplicationCreateParameters
            {
                DisplayName = appDisplayName,
                IdentifierUris = new List<string>() { "http://" + Guid.NewGuid().ToString() + ".com" },
                Homepage = "http://contoso.com",
                AvailableToOtherTenants = false,
                PasswordCredentials = new[]
                {
                    new PasswordCredential
                    {
                        Value = secret,
                        StartDate = DateTime.Now - TimeSpan.FromDays(1),
                        EndDate = DateTime.Now + TimeSpan.FromDays(1),
                        KeyId = Guid.NewGuid().ToString()
                    }
                }
            });
        }

        private bool FromConfiguration()
        {
            string vault = TestConfigurationManager.TryGetEnvironmentOrAppSetting("VaultUrl");
            string authClientId = TestConfigurationManager.TryGetEnvironmentOrAppSetting("AuthClientId");
            string authSecret = TestConfigurationManager.TryGetEnvironmentOrAppSetting("AuthClientSecret");
            string standardVaultOnlyString = TestConfigurationManager.TryGetEnvironmentOrAppSetting("StandardVaultOnly");
            string softDeleteEnabledString = TestConfigurationManager.TryGetEnvironmentOrAppSetting("SoftDeleteEnabled");
            bool standardVaultOnlyresult;
            if (!bool.TryParse(standardVaultOnlyString, out standardVaultOnlyresult))
            {
                standardVaultOnlyresult = false;
            }

            bool softDeleteEnabledresult;
            if (!bool.TryParse(softDeleteEnabledString, out softDeleteEnabledresult))
            {
                softDeleteEnabledresult = false;
            }

            if (string.IsNullOrWhiteSpace(vault) || string.IsNullOrWhiteSpace(authClientId) || string.IsNullOrWhiteSpace(authSecret))
                return false;
            else
            {
                this.vaultAddress = vault;
                this.clientCredential = new ClientCredential(authClientId, authSecret);
                this.standardVaultOnly = standardVaultOnlyresult;
                this.softDeleteEnabled = softDeleteEnabledresult;
                return true;
            }
        }
        
        public async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            var context = new AuthenticationContext(authority, tokenCache);
            var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);

            return result.AccessToken;
        }

        public KeyVaultClient CreateKeyVaultClient()
        {
            var myclient = new KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), GetHandlers());
            return myclient;
        }

        public void WaitOnDeletedKey(KeyVaultClient client, string vaultAddress, string keyName)
        {
            this.retryExecutor.ExecuteAction(() => client.GetDeletedKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult());
        }

        public void WaitOnDeletedSecret(KeyVaultClient client, string vaultAddress, string secretName)
        {
            this.retryExecutor.ExecuteAction(() => client.GetDeletedSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult());
        }

        public void WaitOnKey(KeyVaultClient client, string vaultAddress, string keyName)
        {
            this.retryExecutor.ExecuteAction(() => client.GetKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult());
        }

        public void WaitOnSecret(KeyVaultClient client, string vaultAddress, string secretName)
        {
            this.retryExecutor.ExecuteAction(() => client.GetSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult());
        }

        public DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server = HttpMockServer.CreateInstance();
            var testHttpHandler = new TestHttpMessageHandler();
            return new DelegatingHandler[] { server, testHttpHandler };
        }
        public void Dispose()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record && !fromConfig)
            {
                var testEnv = TestEnvironmentFactory.GetTestEnvironment();
                var context = new MockContext();
                
                var resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                var graphClient = context.GetServiceClient<GraphRbacManagementClient>();
                graphClient.TenantID = testEnv.Tenant;
                graphClient.BaseUri = new Uri("https://graph.windows.net");
                
                graphClient.Application.Delete(appObjectId);
                resourcesClient.ResourceGroups.Delete(rgName);
            }
        }
    }
}
