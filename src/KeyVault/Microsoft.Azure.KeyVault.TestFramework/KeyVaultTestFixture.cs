//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

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
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;

namespace KeyVault.TestFramework
{
    public class KeyVaultTestFixture : IDisposable
    {
        // Required in test code
        public string vaultAddress;
        public bool standardVaultOnly;
        public string keyName;
        public string keyVersion;
        public KeyIdentifier keyIdentifier;
        public ClientCredential clientCredential;

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
            bool result;
            if (!bool.TryParse(standardVaultOnlyString, out result))
            {
                result = false;
            }

            if (string.IsNullOrWhiteSpace(vault) || string.IsNullOrWhiteSpace(authClientId) || string.IsNullOrWhiteSpace(authSecret))
                return false;
            else
            {
                this.vaultAddress = vault;
                this.clientCredential = new ClientCredential(authClientId, authSecret);
                this.standardVaultOnly = result;
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

        private DelegatingHandler[] GetHandlers()
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
