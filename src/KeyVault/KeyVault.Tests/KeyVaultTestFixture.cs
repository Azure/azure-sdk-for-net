using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;

namespace KeyVault.Tests
{
    public class KeyVaultTestFixture : IDisposable
    {
        // Required in test code
        public string vaultAddress;
        public ClientCredential _ClientCredential;

        // Required for cleaning up at the end of the test
        private string rgName, vaultName, appObjectId;
        private bool fromConfig;
        private bool initialized = false;
        
        public KeyVaultTestFixture()
        {}

        public void Initialize(string className)
        {
            if (initialized)
                return;

            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch (ApplicationException)
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize(className, "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }
            
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                fromConfig = FromConfiguration();

                if (!fromConfig)
                {
                    var testFactory = new CSMTestEnvironmentFactory();
                    var testEnv = testFactory.GetTestEnvironment();
                    var secret = Guid.NewGuid().ToString();
                    var mgmtClient = TestBase.GetServiceClient<KeyVaultManagementClient>(testFactory);
                    var resourcesClient = TestBase.GetServiceClient<ResourceManagementClient>(testFactory);
                    var tenantId = testEnv.AuthorizationContext.TenantId;
                    var graphClient = TestBase.GetGraphServiceClient<GraphRbacManagementClient>(testFactory, tenantId);
                    var appDisplayName = TestUtilities.GenerateName("sdktestapp");

                    //Setup things in AAD

                    //Create an application
                    var app = CreateApplication(graphClient, appDisplayName, secret);
                    appObjectId = app.Application.ObjectId;

                    //Create a corresponding service principal
                    var servicePrincipal = CreateServicePrincipal(app, graphClient);

                    //Figure out which locations are available for Key Vault
                    var location = GetKeyVaultLocation(resourcesClient);

                    //Create a resource group in that location
                    vaultName = TestUtilities.GenerateName("sdktestvault");
                    rgName = TestUtilities.GenerateName("sdktestrg");

                    resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup {Location = location});

                    //Create a key vault in that resource group
                    var createResponse = CreateVault(mgmtClient, location, tenantId, servicePrincipal);

                    vaultAddress = createResponse.Vault.Properties.VaultUri;
                    _ClientCredential = new ClientCredential(app.Application.AppId, secret);

                    //Wait a few seconds before trying to authenticate
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                }
            }

            initialized = true;
        }

        private VaultGetResponse CreateVault(KeyVaultManagementClient mgmtClient, string location, string tenantId,
            ServicePrincipalGetResult servicePrincipal)
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
                        Sku = new Sku {Family = "A", Name = "Premium"},
                        TenantId = Guid.Parse(tenantId),
                        VaultUri = "",
                        AccessPolicies = new[]
                        {
                            new AccessPolicyEntry
                            {
                                TenantId = Guid.Parse(tenantId),
                                ObjectId = Guid.Parse(servicePrincipal.ServicePrincipal.ObjectId),
                                PermissionsToKeys = new string[]{"all"},
                                PermissionsToSecrets = new string[]{"all"}
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
            var location = providers.Provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.Name == "vaults")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();
            return location;
        }

        private static ServicePrincipalGetResult CreateServicePrincipal(ApplicationGetResult app,
            GraphRbacManagementClient graphClient)
        {
            var parameters = new ServicePrincipalCreateParameters
            {
                AccountEnabled = true,
                AppId = app.Application.AppId
            };
            var servicePrincipal = graphClient.ServicePrincipal.Create(parameters);
            return servicePrincipal;
        }

        private static ApplicationGetResult CreateApplication(GraphRbacManagementClient graphClient, string appDisplayName, string secret)
        {
            return graphClient.Application.Create(new ApplicationCreateParameters
            {
                DisplayName = appDisplayName,
                IdentifierUris = new List<string>() {"http://" + Guid.NewGuid().ToString() + ".com"},
                Homepage = "http://contoso.com",
                AvailableToOtherTenants = false,
                PasswordCredentials = new[]
                {
                    new PasswordCredential
                    {
                        Value = secret,
                        StartDate = DateTime.Now - TimeSpan.FromDays(1),
                        EndDate = DateTime.Now + TimeSpan.FromDays(1),
                        KeyId = Guid.NewGuid()
                    }
                }
            });
        }

        private bool FromConfiguration()
        {
            string vault = TestConfigurationManager.TryGetEnvironmentOrAppSetting("VaultUrl");
            string authClientId = TestConfigurationManager.TryGetEnvironmentOrAppSetting("AuthClientId");
            string authSecret = TestConfigurationManager.TryGetEnvironmentOrAppSetting("AuthClientSecret");

            if (string.IsNullOrWhiteSpace(vault) || string.IsNullOrWhiteSpace(authClientId) || string.IsNullOrWhiteSpace(authSecret))
                return false;
            else
            {
                this.vaultAddress = vault;
                this._ClientCredential = new ClientCredential(authClientId, authSecret);
                return true;
            }
        }

        public void Dispose()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record && !fromConfig)
            {
                var testFactory = new CSMTestEnvironmentFactory();
                var testEnv = testFactory.GetTestEnvironment();
                var mgmtClient = TestBase.GetServiceClient<KeyVaultManagementClient>(testFactory);
                var resourcesClient = TestBase.GetServiceClient<ResourceManagementClient>(testFactory);
                var tenantId = testEnv.AuthorizationContext.TenantId;
                var graphClient = TestBase.GetGraphServiceClient<GraphRbacManagementClient>(testFactory, tenantId);

                mgmtClient.Vaults.Delete(rgName, vaultName);
                graphClient.Application.Delete(appObjectId);
                resourcesClient.ResourceGroups.Delete(rgName);
            }
        }
    }
}
