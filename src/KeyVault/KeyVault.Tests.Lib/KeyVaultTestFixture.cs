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
using Microsoft.Azure.KeyVault.Internal;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;

namespace KeyVault.Tests
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
        private string rgName = "", vaultName = "", appObjectId = "";
        private bool fromConfig;
        private TokenCache tokenCache;

        public KeyVaultTestFixture()
        {
            Initialize(string.Empty);

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
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
            HttpMockServer.Initialize(className, "InitialCreation");
            HttpMockServer.CreateInstance();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                fromConfig = FromConfiguration();

                if (!fromConfig)
                {
                    throw new Exception("Please provide the test data in the appsettings.json configuration.\n"+
                        "Graph SDK has a bug for creating applications: https://github.com/Azure/azure-sdk-for-net/issues/1934; so the application cannot be created.");

                    var testEnv = TestEnvironmentFactory.GetTestEnvironment();
                    var context = new MockContext();

                    var secret = Guid.NewGuid().ToString();
                    var mgmtClient = context.GetServiceClient<KeyVaultManagementClient>();
                    var resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                    var tenantId = testEnv.Tenant;
                    var graphClient = context.GetServiceClient<GraphRbacManagementClient>();
                    graphClient.TenantID = testEnv.Tenant;
                    graphClient.BaseUri = new Uri("https://graph.windows.net");

                    var appDisplayName = TestUtilities.GenerateName("sdktestapp");

                    //Setup things in AAD

                    //Create an application
                    var app = CreateApplication(graphClient, appDisplayName, secret);
                    appObjectId = app.ObjectId;

                    //Create a corresponding service principal
                    var servicePrincipal = CreateServicePrincipal(app, graphClient);

                    //Figure out which locations are available for Key Vault
                    var location = GetKeyVaultLocation(resourcesClient);

                    //Create a resource group in that location
                    vaultName = TestUtilities.GenerateName("sdktestvault");
                    rgName = TestUtilities.GenerateName("sdktestrg");

                    resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = location });

                    //Create a key vault in that resource group
                    var createdVault = CreateVault(mgmtClient, location, tenantId, servicePrincipal);

                    vaultAddress = createdVault.Properties.VaultUri;
                    clientCredential = new ClientCredential(app.AppId, secret);

                    //Wait a few seconds before trying to authenticate
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }
            }
        }
        private Vault CreateVault(KeyVaultManagementClient mgmtClient, string location, string tenantId, ServicePrincipal servicePrincipal)
        {
            var createResponse = mgmtClient.Vaults.CreateOrUpdate(
                resourceGroupName: rgName,
                vaultName: vaultName,
                parameters: new VaultCreateOrUpdateParameters
                {
                    Location = location,
                    Tags = new Dictionary<string, string>(),
                    Properties = new VaultProperties
                    {
                        EnabledForDeployment = true,
                        Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku { Family = "A", Name = SkuName.Premium },
                        TenantId = Guid.Parse(tenantId),
                        VaultUri = "",
                        AccessPolicies = new[]
                        {
                            new AccessPolicyEntry
                            {
                                TenantId = Guid.Parse(tenantId),
                                ObjectId = Guid.Parse(servicePrincipal.ObjectId),
                                Permissions = new Permissions {
                                    Keys = new string[]{"all"},
                                    Secrets = new string[]{"all"}
                                }
                            }
                        }
                    }
                }
                );
            return createResponse;
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

                var mgmtClient = context.GetServiceClient<KeyVaultManagementClient>();
                var resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                var graphClient = context.GetServiceClient<GraphRbacManagementClient>();
                graphClient.TenantID = testEnv.Tenant;
                graphClient.BaseUri = new Uri("https://graph.windows.net");

                mgmtClient.Vaults.Delete(rgName, vaultName);
                graphClient.Application.Delete(appObjectId);
                resourcesClient.ResourceGroups.Delete(rgName);
            }
        }
    }
}
