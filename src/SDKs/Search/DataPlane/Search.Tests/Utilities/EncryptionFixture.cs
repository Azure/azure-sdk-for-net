// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.KeyVault.WebKey;
    using Microsoft.Azure.Management.KeyVault;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.Search;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using static Microsoft.Azure.KeyVault.KeyVaultClient;

    public class EncryptionFixture : SearchServiceFixture
    {
        public string KeyVaultUri { get; private set; }

        public string KeyVaultName { get; private set; }

        public string KeyName { get; private set; }

        public string KeyVersion { get; private set; }

        public string TestAADApplicationId => "c74474ff-dae3-4e4a-be9a-6fa626a5e314";

        public string TestAADApplicationObjectId => "55a05423-7beb-4a7b-8511-d355a08a28f8";

        public string TestAADApplicationSecret => "G(#0i^]?[T&l?X!:p+(@>!*/.N)>*#)+_"; // [SuppressMessage("Microsoft.Security", "CS001:SecretInline", Justification = "This is a public secret with no assigned security role.")]

        protected override Microsoft.Azure.Management.Search.Models.SkuName SearchServiceSkuName => 
            Microsoft.Azure.Management.Search.Models.SkuName.Basic;

        protected override string SearchServiceLocation => "EastUS";

        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            RegisterRequiredProvider(context);

            Vault keyVault = CreateKeyVault(context, this.ResourceGroupName, TestEnvironmentFactory.GetTestEnvironment().Tenant, TestAADApplicationObjectId);
            this.KeyVaultUri = keyVault.Properties.VaultUri;
            this.KeyVaultName = keyVault.Name;

            // Create a key
            // This can be flaky if attempted immediately after creating the vault. Adding short sleep to improve robustness.
            TestUtilities.Wait(TimeSpan.FromSeconds(3));

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

        private static Vault CreateKeyVault(MockContext context, string resourceGroupName, string tenantId, string testApplicationObjectId)
        {
            string authClientId = TestEnvironmentFactory.GetTestEnvironment().ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];
            string servicePrincipalObjectId = TestEnvironmentFactory.GetTestEnvironment().ConnectionString.KeyValuePairs[ConnectionStringKeys.AADClientIdKey];

            var accessPolicies = new List<AccessPolicyEntry>();
            accessPolicies.Add(new AccessPolicyEntry
            {
                TenantId = System.Guid.Parse(tenantId),
                ObjectId = testApplicationObjectId,
                Permissions = new Permissions()
                {
                    Keys = new List<string>()
                    {
                        KeyPermissions.Get,
                        KeyPermissions.WrapKey,
                        KeyPermissions.UnwrapKey
                    }
                }
            });

            accessPolicies.Add(new AccessPolicyEntry
            {
                TenantId = System.Guid.Parse(tenantId),
                ObjectId = servicePrincipalObjectId,
                Permissions = new Permissions()
                {
                    Keys = new List<string>()
                    {
                        KeyPermissions.Create,
                        KeyPermissions.Delete,
                        KeyPermissions.Get,
                        KeyPermissions.List
                    }
                }
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
                    Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku(Microsoft.Azure.Management.KeyVault.Models.SkuName.Standard)
                }
            });
        }

        private static KeyBundle CreateKey(MockContext context, Vault keyVault)
        {
            string keyName = TestUtilities.GenerateName("keyvaultkey");

            KeyVaultClient keyVaultClient = GetKeyVaultClient();

            return keyVaultClient.CreateKeyAsync(keyVault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, new KeyAttributes()).GetAwaiter().GetResult();
        }

        private static DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server = HttpMockServer.CreateInstance();
            return new DelegatingHandler[] { server };
        }

        private static KeyVaultClient GetKeyVaultClient()
        {
            return new KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), GetHandlers());
        }

        private static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();

            var context = new AuthenticationContext(authority, null);
            string authClientId = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];
            string authSecret = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey];

            var clientCredential = new ClientCredential(authClientId, authSecret);
            var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
            return result.AccessToken;
        }

        private class TestKeyVaultCredential : KeyVaultCredential
        {
            public TestKeyVaultCredential(AuthenticationCallback authenticationCallback) : base(authenticationCallback)
            {
            }

            public override Task ProcessHttpRequestAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    return base.ProcessHttpRequestAsync(request, cancellationToken);
                }
                else
                {
                    return Task.Run(() => { return; });
                }
            }
        }
    }
}