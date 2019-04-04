using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Search;
using Microsoft.Azure.Management.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Search.Tests.Utilities
{
    public class EncryptionFixture : SearchServiceFixture
    {
        public string KeyVaultUri { get; private set; }

        public string KeyVaultName { get; private set; }

        public string KeyName { get; private set; }

        public string KeyVersion { get; private set; }

        public string TestAADApplicationId => "872239e7-b3ab-469e-85d6-ab96f8dc2ca8";

        public string TestAADApplicationSecret => "";

        protected override Microsoft.Azure.Management.Search.Models.SkuName SearchServiceSkuName => 
            Microsoft.Azure.Management.Search.Models.SkuName.Basic;

        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            RegisterRequiredProvider(context);

            Vault keyVault = CreateKeyVault(context, this.ResourceGroupName, TestEnvironmentFactory.GetTestEnvironment().Tenant, this.TestAADApplicationId);
            this.KeyVaultUri = keyVault.Properties.VaultUri;
            this.KeyVaultName = keyVault.Name;


            KeyBundle key = CreateKey(context, keyVault);
            this.KeyName = key.KeyIdentifier.Name;
            this.KeyVersion = key.KeyIdentifier.Version;
        }


        public override void Cleanup()
        {
            if (ResourceGroupName != null && this.KeyVaultName != null)
            {
                KeyVaultManagementClient keyVaultMgmtClient = MockContext.GetServiceClient<KeyVaultManagementClient>();
                keyVaultMgmtClient.Vaults.Delete(this.ResourceGroupName, this.KeyVaultName);
            }

            base.Cleanup();
        }

        private static void RegisterRequiredProvider(MockContext context)
        {
            ResourceManagementClient client = context.GetServiceClient<ResourceManagementClient>();
            Provider provider = client.Providers.Register("Microsoft.KeyVault");
        }

        private static Vault CreateKeyVault(MockContext context, string resourceGroupName, string tenantId, string testApplicationId)
        {
            
            var accessPolicies = new List<AccessPolicyEntry>();
            accessPolicies.Add(new AccessPolicyEntry
            {
                TenantId = System.Guid.Parse(tenantId),
                ObjectId = testApplicationId,
                Permissions = new Permissions(new List<string> { "wrapkey", "unwrapkey" })
            });

            KeyVaultManagementClient keyVaultMgmtClient = context.GetServiceClient<KeyVaultManagementClient>();
            string keyVaultName = TestUtilities.GenerateName("keyvault");
            return keyVaultMgmtClient.Vaults.CreateOrUpdate(resourceGroupName, keyVaultName, new Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters
            {
                Location = "northcentralus",
                Properties = new Microsoft.Azure.Management.KeyVault.Models.VaultProperties
                {
                    TenantId = System.Guid.Parse(tenantId),
                    AccessPolicies = accessPolicies,
                    Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku(Microsoft.Azure.Management.KeyVault.Models.SkuName.Standard),
                    EnabledForDiskEncryption = false,
                    EnabledForDeployment = false,
                    EnabledForTemplateDeployment = false
                }
            });
        }

        private static KeyBundle CreateKey(MockContext context, Vault keyVault)
        {
            string keyName = TestUtilities.GenerateName("keyvaultkey");
            return context.GetServiceClient<KeyVaultClient>().CreateKeyAsync(keyVault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, new Microsoft.Azure.KeyVault.Models.KeyAttributes()).GetAwaiter().GetResult();
        }

        //private GraphRbacManagementClient GetGraphClient(MockContext context, string tenantId)
        //{
        //    var client = context.GetGraphServiceClient<GraphRbacManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            
        //    client.TenantID = tenantId;
        //    return client;
        //}

        //private static Application CreateAADApplication(MockContext context)
        //{
        //    GraphRbacManagementClient graphClient = context.GetGraphServiceClient<GraphRbacManagementClient>();

        //    PasswordCredential applicationPassword = CreatePasswordCredential();

        //    var appName = TestUtilities.GenerateName("adApplication");
        //    string url = string.Format("http://{0}/home", appName);

        //    return graphClient.Applications.Create(new ApplicationCreateParameters()
        //    {
        //        DisplayName = appName,
        //        PasswordCredentials = new PasswordCredential[] { applicationPassword },
        //        Homepage = url,
        //        IdentifierUris = new[] { url },
        //        ReplyUrls = new[] { url },
        //        AvailableToOtherTenants = false,

        //    });
        //}

        //private static PasswordCredential CreatePasswordCredential(string keyId = null)
        //{
        //    var bytes = new byte[32] { 1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
        //                                1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
        //                                1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
        //                                1, 2 };
        //    PasswordCredential cred = new PasswordCredential();
        //    cred.StartDate = DateTime.Now;
        //    cred.EndDate = DateTime.Now.AddMonths(12);
        //    cred.KeyId = keyId ?? Guid.NewGuid().ToString();
        //    cred.Value = Convert.ToBase64String(bytes);
        //    return cred;
        //}
    }
}