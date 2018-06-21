// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Storage.Tests.Helpers
{
    public static class StorageManagementTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        // These should be filled in only if test tenant is true
#if DNX451
        private static string certName = null;
        private static string certPassword = null;
#endif
        private const string testSubscription = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "eastus2(stage)";
        public static string DefaultRGLocation = IsTestTenant ? null : "eastus2";
        public static SkuName DefaultSkuName = SkuName.StandardGRS;
        public static Kind DefaultKind = Kind.Storage;
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string> 
            {
                {"key1","value1"},
                {"key2","value2"}
            };

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (IsTestTenant)
            {
                return null;
            }
            else
            {
                handler.IsPassThrough = true;
                ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return resourcesClient;
            }
        }

        public static Microsoft.Azure.Management.KeyVault.KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            Microsoft.Azure.Management.KeyVault.KeyVaultManagementClient keyVaultMgmtClient;
            if (IsTestTenant)
            {
                keyVaultMgmtClient = new Microsoft.Azure.Management.KeyVault.KeyVaultManagementClient(new TokenCredentials("xyz"), GetHandler());
                keyVaultMgmtClient.SubscriptionId = testSubscription;
                keyVaultMgmtClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                keyVaultMgmtClient = context.GetServiceClient<Microsoft.Azure.Management.KeyVault.KeyVaultManagementClient>(handlers: handler);
            }
            return keyVaultMgmtClient;
        }

        public static string GetTanentId()
        {
            string tenantId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.AADTenantKey] = environment.Tenant;
                tenantId = environment.Tenant;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                tenantId = HttpMockServer.Variables[ConnectionStringKeys.AADTenantKey];
            }
            return tenantId;
        }

        public static string GetServicePrincipalId()
        {
            string servicePrincipalId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalKey);
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            return servicePrincipalId;
        }

        public static string GetServicePrincipalSecret()
        {
            string servicePrincipalSecret = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                servicePrincipalSecret = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalSecretKey);
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalSecret = "xyz";
            }
            return servicePrincipalSecret;
        }

        public static string GetServicePrincipalObjectId()
        {
            string servicePrincipalObjectId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.AADClientIdKey);
                servicePrincipalObjectId = HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey];
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalObjectId = HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey];
            }
            return servicePrincipalObjectId;
        }

        private class TestKeyVaultCredential : Microsoft.Azure.KeyVault.KeyVaultCredential
        {
            public TestKeyVaultCredential(Microsoft.Azure.KeyVault.KeyVaultClient.AuthenticationCallback authenticationCallback) : base(authenticationCallback)
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

        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            string authClientId = GetServicePrincipalId();
            string authSecret = GetServicePrincipalSecret();
            var clientCredential = new ClientCredential(authClientId, authSecret);
            var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
            return result.AccessToken;
        }

        public static DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server = HttpMockServer.CreateInstance();
            return new DelegatingHandler[] { server };
        }

        public static Microsoft.Azure.KeyVault.KeyVaultClient CreateKeyVaultClient()
        {
            var myclient = new Microsoft.Azure.KeyVault.KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), GetHandlers());
            return myclient;
        }

        public static StorageManagementClient GetStorageManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            StorageManagementClient storageClient;
            if (IsTestTenant)
            {
                storageClient = new StorageManagementClient(new TokenCredentials("xyz"), GetHandler());
                storageClient.SubscriptionId = testSubscription;
                storageClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                storageClient = context.GetServiceClient<StorageManagementClient>(handlers: handler);
            }
            return storageClient;
        }

        private static HttpClientHandler GetHandler() 
        {
#if DNX451
            if (Handler == null)
            {
                //talk to yugangw-msft, if the code doesn't work under dnx451 (same with net451)
                X509Certificate2 cert = new X509Certificate2(certName, certPassword);
                Handler = new System.Net.Http.WebRequestHandler();
                ((WebRequestHandler)Handler).ClientCertificates.Add(cert);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            }
#endif
            return Handler;
        }

        public static StorageAccountCreateParameters GetDefaultStorageAccountParameters()
        {
            StorageAccountCreateParameters account = new StorageAccountCreateParameters
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                Sku = new Sku { Name = DefaultSkuName },
                Kind = DefaultKind,
        };

            return account;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "res";
            var rgname = TestUtilities.GenerateName(testPrefix);

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = DefaultRGLocation
                    });
            }

            return rgname;
        }

        public static string CreateStorageAccount(StorageManagementClient storageMgmtClient, string rgname)
        {
            string accountName = TestUtilities.GenerateName("sto");
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();

            var createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

            return accountName;
        }

        public static void VerifyAccountProperties(StorageAccount account, bool useDefaults)
        {
            Assert.NotNull(account);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);
            Assert.NotNull(account.CreationTime);
            Assert.NotNull(account.Kind);

            Assert.NotNull(account.Sku);
            Assert.NotNull(account.Sku.Name);
            Assert.NotNull(account.Sku.Tier);

            Assert.Equal(AccountStatus.Available, account.StatusOfPrimary);
            Assert.Equal(account.Location, account.PrimaryLocation);

            Assert.NotNull(account.PrimaryEndpoints);
            Assert.NotNull(account.PrimaryEndpoints.Blob);

            if (account.Kind == Kind.Storage || account.Kind == Kind.StorageV2)
            {
                if (account.Sku.Name != SkuName.StandardZRS && account.Sku.Name != SkuName.PremiumLRS)
                {
                    Assert.NotNull(account.PrimaryEndpoints.Queue);
                    Assert.NotNull(account.PrimaryEndpoints.Table);
                    Assert.NotNull(account.PrimaryEndpoints.File);
                }

                if (account.Sku.Name == SkuName.StandardRAGRS)
                {                    
                    Assert.NotNull(account.SecondaryEndpoints.Queue);
                    Assert.NotNull(account.SecondaryEndpoints.Table);
                }
            }

            Assert.Equal(ProvisioningState.Succeeded, account.ProvisioningState);
            Assert.Null(account.LastGeoFailoverTime);

            switch (account.Sku.Name)
            {
                case SkuName.StandardLRS:
                case SkuName.StandardZRS:
                case SkuName.PremiumLRS:
                    Assert.Null(account.SecondaryLocation);
                    Assert.Null(account.StatusOfSecondary);
                    Assert.Null(account.SecondaryEndpoints);
                    break;
                case SkuName.StandardGRS:
                    Assert.Equal(AccountStatus.Available, account.StatusOfSecondary);
                    Assert.NotNull(account.SecondaryLocation);
                    Assert.Null(account.SecondaryEndpoints);
                    break;
                case SkuName.StandardRAGRS:
                    Assert.Equal(AccountStatus.Available, account.StatusOfSecondary);
                    Assert.NotNull(account.SecondaryLocation);
                    Assert.NotNull(account.SecondaryEndpoints);
                    Assert.NotNull(account.SecondaryEndpoints.Blob);
                    break;
            }

            if (useDefaults)
            {
                Assert.Equal(StorageManagementTestUtilities.DefaultLocation, account.Location);
                Assert.Equal(StorageManagementTestUtilities.DefaultSkuName, account.Sku.Name);
                Assert.Equal(SkuTier.Standard, account.Sku.Tier);
                Assert.Equal(StorageManagementTestUtilities.DefaultKind, account.Kind);

                Assert.NotNull(account.Tags);
                Assert.Equal(2, account.Tags.Count);
                Assert.Equal(account.Tags["key1"], "value1");
                Assert.Equal(account.Tags["key2"], "value2");
            }
        }

        public static AccountSasParameters ParseAccountSASToken(string accountSAS)
        {
            string[] sasProperties = accountSAS.Substring(1).Split(new char[] { '&' });
            AccountSasParameters parameters = new AccountSasParameters();
            foreach (var property in sasProperties)
            {
                string[] keyValue = property.Split(new char[] { '=' });
                switch (keyValue[0])
                {
                    case "ss":
                        parameters.Services = keyValue[1];
                        break;
                    case "srt":
                        parameters.ResourceTypes = keyValue[1];
                        break;
                    case "sp":
                        parameters.Permissions = keyValue[1];
                        break;
                    case "st":
                        parameters.SharedAccessStartTime = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "se":
                        parameters.SharedAccessExpiryTime = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "sip":
                        parameters.IPAddressOrRange = keyValue[1];
                        break;
                    case "spr":
                        if (keyValue[1] == "https")
                            parameters.Protocols = HttpProtocol.Https;
                        else if (keyValue[1] == "https,http")
                            parameters.Protocols = HttpProtocol.Httpshttp;
                        break;
                    default:
                        break;
                }
            }
            return parameters;
        }

        public static ServiceSasParameters ParseServiceSASToken(string serviceSAS)
        {
            string[] sasProperties = serviceSAS.Substring(1).Split(new char[] { '&' });
            ServiceSasParameters parameters = new ServiceSasParameters();
            foreach (var property in sasProperties)
            {
                string[] keyValue = property.Split(new char[] { '=' });
                switch (keyValue[0])
                {
                    case "sr":
                        parameters.Resource = keyValue[1];
                        break;
                    case "sp":
                        parameters.Permissions = keyValue[1];
                        break;
                    case "st":
                        parameters.SharedAccessStartTime = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "se":
                        parameters.SharedAccessExpiryTime = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "sip":
                        parameters.IPAddressOrRange = keyValue[1];
                        break;
                    case "spr":
                        if (keyValue[1] == "https")
                            parameters.Protocols = HttpProtocol.Https;
                        else if (keyValue[1] == "https,http")
                            parameters.Protocols = HttpProtocol.Httpshttp;
                        break;
                    case "si":
                        parameters.Identifier = keyValue[1];
                        break;
                    case "spk":
                        parameters.PartitionKeyStart = keyValue[1];
                        break;
                    case "epk":
                        parameters.PartitionKeyEnd = keyValue[1];
                        break;
                    case "srk":
                        parameters.RowKeyStart = keyValue[1];
                        break;
                    case "erk":
                        parameters.RowKeyEnd = keyValue[1];
                        break;
                    case "rscc":
                        parameters.CacheControl = keyValue[1];
                        break;
                    case "rscd":
                        parameters.ContentDisposition = keyValue[1];
                        break;
                    case "rsce":
                        parameters.ContentEncoding = keyValue[1];
                        break;
                    case "rscl":
                        parameters.ContentLanguage = keyValue[1];
                        break;
                    case "rsct":
                        parameters.ContentType = keyValue[1];
                        break;
                    default:
                        break;
                }
            }
            return parameters;
        }
    }
}
