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

        protected override Microsoft.Azure.Management.Search.Models.Identity SearchServiceIdentity => 
            new Microsoft.Azure.Management.Search.Models.Identity(Management.Search.Models.IdentityType.SystemAssigned);

        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            RegisterRequiredProvider(context);

            List<AccessPolicyEntry> keyVaultAccessPolicies = new List<AccessPolicyEntry>();

            // Creating an access policy with key management capabilities to the sdk test account
            // so it can later create a new key vault key
            keyVaultAccessPolicies.Add(CreateReadAndWriteAccess(GetSdkTestAccountAADClientID()));

            // Creating an access policy with "read" key access to the search service so we can use
            // encryption with MSI (managed service identity)
            keyVaultAccessPolicies.Add(CreateReadOnlyAccess(GetSearchServicePrincipalId()));

            // Creating an access policy with "read" key access to our test registered azure
            // active directory application so we can use encryption with AAD credentials
            keyVaultAccessPolicies.Add(CreateReadOnlyAccess(TestAADApplicationObjectId));

            Vault keyVault = CreateKeyVault(keyVaultAccessPolicies);
            KeyVaultUri = keyVault.Properties.VaultUri;
            KeyVaultName = keyVault.Name;

            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                // it may take a second before we can create a key in a freshly created Key Vault
                TestUtilities.Wait(TimeSpan.FromSeconds(3));
            }

            KeyBundle key = CreateKeyVaultKey(keyVault);
            KeyName = key.KeyIdentifier.Name;
            KeyVersion = key.KeyIdentifier.Version;
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

        private string GetSearchServicePrincipalId()
        {
            SearchManagementClient searchManagementClient = this.MockContext.GetServiceClient<SearchManagementClient>();
            return searchManagementClient.Services.Get(this.ResourceGroupName, this.SearchServiceName).Identity.PrincipalId;
        }

        private string GetSdkTestAccountAADClientID()
        {
            return TestEnvironmentFactory.GetTestEnvironment().ConnectionString.KeyValuePairs[ConnectionStringKeys.AADClientIdKey];
        }

        private static void RegisterRequiredProvider(MockContext context)
        {
            ResourceManagementClient client = context.GetServiceClient<ResourceManagementClient>();
            Provider provider = client.Providers.Register("Microsoft.KeyVault");
        }

        private AccessPolicyEntry CreateReadOnlyAccess(string securityPrincipalId)
        {
            return new AccessPolicyEntry
            {
                TenantId = Guid.Parse(TestEnvironmentFactory.GetTestEnvironment().Tenant),
                ObjectId = securityPrincipalId,
                Permissions = new Permissions()
                {
                    Keys = new List<string>()
                    {
                        KeyPermissions.Get,
                        KeyPermissions.WrapKey,
                        KeyPermissions.UnwrapKey,
                    }
                }
            };
        }

        private AccessPolicyEntry CreateReadAndWriteAccess(string securityPrincipalId)
        {
            return new AccessPolicyEntry
            {
                TenantId = Guid.Parse(TestEnvironmentFactory.GetTestEnvironment().Tenant),
                ObjectId = securityPrincipalId,
                Permissions = new Permissions()
                {
                    Keys = new List<string>()
                    {
                         KeyPermissions.Get,
                        KeyPermissions.WrapKey,
                        KeyPermissions.UnwrapKey,
                        KeyPermissions.Create,
                        KeyPermissions.Delete,
                        KeyPermissions.Get,
                        KeyPermissions.List
                    }
                }
            };
        }

        private Vault CreateKeyVault(List<AccessPolicyEntry> accessPolicies)
        {
            KeyVaultManagementClient keyVaultMgmtClient = this.MockContext.GetServiceClient<KeyVaultManagementClient>();
            string keyVaultName = TestUtilities.GenerateName("keyvault");
            return keyVaultMgmtClient.Vaults.CreateOrUpdate(ResourceGroupName, keyVaultName, new VaultCreateOrUpdateParameters
            {
                Location = "northcentralus",
                Properties = new VaultProperties
                {
                    TenantId = Guid.Parse(TestEnvironmentFactory.GetTestEnvironment().Tenant),
                    AccessPolicies = accessPolicies,
                    Sku = new Management.KeyVault.Models.Sku(SkuName.Standard)
                }
            });
        }

        private KeyBundle CreateKeyVaultKey(Vault keyVault)
        {
            string keyName = TestUtilities.GenerateName("keyvaultkey");

            KeyVaultClient keyVaultClient = GetKeyVaultClient();

            int keySize = 2048;
            return keyVaultClient.CreateKeyAsync(
                keyVault.Properties.VaultUri, 
                keyName, 
                JsonWebKeyType.Rsa, 
                keySize,
                JsonWebKeyOperation.AllOperations, 
                new KeyAttributes()
           ).GetAwaiter().GetResult();
        }

        private static KeyVaultClient GetKeyVaultClient()
        {
            return new KeyVaultClient(
                new TestKeyVaultCredential(GetAccessToken), 
                new DelegatingHandler[] { HttpMockServer.CreateInstance() });
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
            public TestKeyVaultCredential(KeyVaultClient.AuthenticationCallback authenticationCallback) : base(authenticationCallback)
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
                    return Task.Run(() => {});
                }
            }
        }
    }
}