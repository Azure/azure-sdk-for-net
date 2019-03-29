using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.Search;
using Microsoft.Azure.Management.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Search.Tests.Utilities
{
    public class EncryptionFixture : ResourceGroupFixture
    {
        private string KeyVaultName;
        private string KeyName;
        public MockContext MockContext { get; private set; }

        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            this.MockContext = context;
            //SearchService searchService = CreateService(
            //    DefineServiceWithSku(Microsoft.Azure.Management.Search.Models.SkuName.Basic, Location),
            //    context,
            //    ResourceGroupName);


            this.KeyVaultName = TestUtilities.GenerateName("keyvault");
            this.KeyName = TestUtilities.GenerateName("keyvaultkey");

            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();

            Dictionary<TokenAudience, TokenCredentials> tokens = currentEnvironment.TokenInfo;

            PasswordCredential applicationPassword = CreatePasswordCredential();

            var appName = TestUtilities.GenerateName("adApplication");
            string url = string.Format("http://{0}/home", appName);

            KeyVaultManagementClient keyVaultMgmtClient = GetKeyVaultManagementClient(context);
            GraphRbacManagementClient graphClient = GetGraphClient(MockContext, currentEnvironment.Tenant);
            SearchManagementClient searchManagementClient = context.GetServiceClient<SearchManagementClient>();

            ServiceClientCredentials graphCredentials = graphClient.Credentials;
            ServiceClientCredentials keyVaultCredentials = keyVaultMgmtClient.Credentials;
            ServiceClientCredentials searchCredentials = searchManagementClient.Credentials;

            string test = currentEnvironment.Tenant;

            Application application = graphClient.Applications.Create(new ApplicationCreateParameters()
            {
                DisplayName = appName,
                PasswordCredentials = new PasswordCredential[] { applicationPassword },
                Homepage = url,
                IdentifierUris = new[] { url },
                ReplyUrls = new[] { url },
                AvailableToOtherTenants = false
            });


            //var accessPolicies = new List<AccessPolicyEntry>();
            //accessPolicies.Add(new AccessPolicyEntry
            //{
            //    TenantId = System.Guid.Parse(currentEnvironment.Tenant),
            //    ObjectId = application.ObjectId,
            //    Permissions = new Permissions(new List<string> { "wrapkey", "unwrapkey" })
            //});



            var keyVault = keyVaultMgmtClient.Vaults.CreateOrUpdate(this.ResourceGroupName, this.KeyVaultName, new Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters
            {
                Location = "northcentralus",
                Properties = new Microsoft.Azure.Management.KeyVault.Models.VaultProperties
                {
                    TenantId = System.Guid.Parse(currentEnvironment.Tenant),
                    AccessPolicies = null,
                    Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku(Microsoft.Azure.Management.KeyVault.Models.SkuName.Standard),
                    EnabledForDiskEncryption = false,
                    EnabledForDeployment = false,
                    EnabledForTemplateDeployment = false
                }
            });


            //var keyVault = keyVaultMgmtClient.Vaults.CreateOrUpdate(this.ResourceGroupName, vaultName, new VaultCreateOrUpdateParameters
            //{
            //    Location = this.Location,
            //    Properties = new VaultProperties
            //    {
            //        TenantId = System.Guid.Parse(account.Identity.TenantId),
            //        AccessPolicies = accessPolicies,
            //        Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku(Microsoft.Azure.Management.KeyVault.Models.SkuName.Standard),
            //        EnabledForDiskEncryption = false,
            //        EnabledForDeployment = false,
            //        EnabledForTemplateDeployment = false
            //    }
            //});

            //var keyVaultKey = keyVaultClient.CreateKeyAsync(keyVault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa, 2048,
            //        JsonWebKeyOperation.AllOperations, new Microsoft.Azure.KeyVault.Models.KeyAttributes()).GetAwaiter().GetResult();

        }

        public override void Cleanup()
        {
            // Normally we could just rely on resource group deletion to clean things up for us. However, resource
            // group deletion is asynchronous and can be slow, especially when we're running in test environments that
            // aren't 100% reliable. To avoid interfering with other tests by exhausting free service quota, we
            // eagerly delete the search service here.
            //if (ResourceGroupName != null && SearchServiceName != null)
            //{
            //    SearchManagementClient client = MockContext.GetServiceClient<SearchManagementClient>();
            //    client.Services.Delete(ResourceGroupName, SearchServiceName);
            //}

            base.Cleanup();
        }

        private static KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context)
        {
            return context.GetServiceClient<KeyVaultManagementClient>();
        }

        public GraphRbacManagementClient GetGraphClient(MockContext context, string tenantId)
        {
            var client = context.GetServiceClient<GraphRbacManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            
            client.TenantID = tenantId;
            return client;
        }

        //public static KeyVaultClient CreateKeyVaultClient()
        //{
        //    return new KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), GetHandlers());
        //}

        //public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        //{
        //    var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
        //    string authClientId = GetServicePrincipalId();
        //    string authSecret = GetServicePrincipalSecret();
        //    var clientCredential = new ClientCredential(authClientId, authSecret);
        //    var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
        //    return result.AccessToken;
        //}



        private SearchService DefineServiceWithSku(Microsoft.Azure.Management.Search.Models.SkuName sku, string location)
        {
            return new SearchService()
            {
                Location = location,
                Sku = new Microsoft.Azure.Management.Search.Models.Sku() { Name = sku },
                ReplicaCount = 1,
                PartitionCount = 1
                //,Identity = new Identity(IdentityType.SystemAssigned)
            };
        }

        private static SearchService CreateService(SearchService service, MockContext context, string resourceGroupName)
        {
            SearchManagementClient searchMgmt = context.GetServiceClient<SearchManagementClient>();

            string serviceName = SearchTestUtilities.GenerateServiceName();

            service = searchMgmt.Services.BeginCreateOrUpdate(resourceGroupName, serviceName, service);
            service = WaitForProvisioningToComplete(searchMgmt, service, resourceGroupName);

            return service;

        }

        private static SearchService WaitForProvisioningToComplete(
            SearchManagementClient searchMgmt,
            SearchService service,
            string resourceGroupName)
        {
            while (service.ProvisioningState == ProvisioningState.Provisioning)
            {
                SearchTestUtilities.WaitForServiceProvisioning();
                service = searchMgmt.Services.Get(resourceGroupName, service.Name);
            }

            return service;
        }

        public PasswordCredential CreatePasswordCredential(string keyId = null)
        {
            var bytes = new byte[32] { 1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
                                        1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
                                        1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
                                        1, 2 };
            PasswordCredential cred = new PasswordCredential();
            cred.StartDate = DateTime.Now;
            cred.EndDate = DateTime.Now.AddMonths(12);
            cred.KeyId = keyId ?? Guid.NewGuid().ToString();
            cred.Value = Convert.ToBase64String(bytes);
            return cred;
        }
    }
}