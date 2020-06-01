// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.Management.Storage.Models;
using NUnit.Framework;
using Sku = Azure.Management.Storage.Models.Sku;

namespace Azure.Management.Storage.Tests.Helpers
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
        //private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "eastus2(stage)";
        public static string DefaultRGLocation = IsTestTenant ? null : "eastus2";
        public static Sku DefaultSkuNameStandardGRS = new Sku(SkuName.StandardGRS);
        public static Kind DefaultKindStorage = Kind.Storage;

        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };

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

        public static StorageAccountCreateParameters GetDefaultStorageAccountParameters(Sku Sku = null, Kind? Kind = null, string Location = null)
        {
            Sku skuParameters = Sku ?? DefaultSkuNameStandardGRS;
            Kind kindParameters = Kind ?? DefaultKindStorage;
            string locationParameters = Location ?? DefaultLocation;

            StorageAccountCreateParameters account = new StorageAccountCreateParameters(skuParameters, kindParameters, locationParameters)
            {
                Tags = DefaultTags,
            };
            return account;
        }

        public static async Task<string> CreateResourceGroup(ResourceGroupsClient ResourceGroupsClient, TestRecording Recording)
        {
            string name = Recording.GenerateAssetName("res");
            if (!IsTestTenant)
            {
                await ResourceGroupsClient.CreateOrUpdateAsync(name, new ResourceGroup(DefaultRGLocation));
            }
            return name;
        }

        public static async Task<string> CreateStorageAccount(StorageAccountsClient StorageAccountsClient, string rgname, TestRecording Recording)
        {
            string accountName = Recording.GenerateAssetName("sto");
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            Operation<StorageAccount> account = await StorageAccountsClient.StartCreateAsync(rgname, accountName, parameters);
            await account.WaitForCompletionAsync();
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

            Assert.AreEqual(AccountStatus.Available, account.StatusOfPrimary);
            Assert.AreEqual(account.Location, account.PrimaryLocation);

            Assert.NotNull(account.PrimaryEndpoints);
            if (account.Kind != Kind.FileStorage)
            {
                Assert.NotNull(account.PrimaryEndpoints.Blob);
            }

            if (account.Kind == Kind.Storage || account.Kind == Kind.StorageV2)
            {
                if (account.Sku.Name != SkuName.StandardZRS && account.Sku.Name != SkuName.PremiumLRS)
                {
                    Assert.NotNull(account.PrimaryEndpoints.Queue);
                    Assert.NotNull(account.PrimaryEndpoints.Table);
                    Assert.NotNull(account.PrimaryEndpoints.File);
                }

                if (account.Sku.Name == SkuName.StandardRagzrs)
                {
                    Assert.NotNull(account.SecondaryEndpoints.Queue);
                    Assert.NotNull(account.SecondaryEndpoints.Table);
                }
            }

            Assert.AreEqual(Models.ProvisioningState.Succeeded, account.ProvisioningState);
            Assert.Null(account.LastGeoFailoverTime);

            if (account.Sku.Name == SkuName.StandardLRS || account.Sku.Name == SkuName.StandardZRS || account.Sku.Name == SkuName.PremiumLRS)
            {
                Assert.Null(account.SecondaryLocation);
                Assert.Null(account.StatusOfSecondary);
                Assert.Null(account.SecondaryEndpoints);
            }
            else if (account.Sku.Name == SkuName.StandardGRS)
            {
                Assert.AreEqual(AccountStatus.Available, account.StatusOfSecondary);
                Assert.NotNull(account.SecondaryLocation);
                Assert.Null(account.SecondaryEndpoints);
            }
            else if (account.Sku.Name == SkuName.StandardRagzrs)
            {
                Assert.AreEqual(AccountStatus.Available, account.StatusOfSecondary);
                Assert.NotNull(account.SecondaryLocation);
                Assert.NotNull(account.SecondaryEndpoints);
                Assert.NotNull(account.SecondaryEndpoints.Blob);
            }

            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, account.Location);
                Assert.AreEqual(DefaultSkuNameStandardGRS.Name, account.Sku.Name);
                Assert.AreEqual(SkuTier.Standard, account.Sku.Tier);
                Assert.AreEqual(DefaultKindStorage, account.Kind);

                Assert.NotNull(account.Tags);
                Assert.AreEqual(2, account.Tags.Count);
                Assert.AreEqual("value1", account.Tags["key1"]);
                Assert.AreEqual("value2", account.Tags["key2"]);
            }
        }

        public static AccountSasParameters ParseAccountSASToken(string accountSasToken)
        {
            string[] sasProperties = accountSasToken.Substring(1).Split(new char[] { '&' });

            string ServiceParameters = string.Empty;
            string ResourceTypesParameters = string.Empty;
            string PermissionsParameters = string.Empty;
            string IPAddressOrRangeParameters = string.Empty;
            DateTimeOffset SharedAccessStartTimeParameters = new DateTimeOffset();
            DateTimeOffset SharedAccessExpiryTimeParameters = new DateTimeOffset();
            HttpProtocol? ProtocolsParameters = null;

            foreach (var property in sasProperties)
            {
                string[] keyValue = property.Split(new char[] { '=' });
                switch (keyValue[0])
                {
                    case "ss":
                        ServiceParameters = keyValue[1];
                        break;
                    case "srt":
                        ResourceTypesParameters = keyValue[1];
                        break;
                    case "sp":
                        PermissionsParameters = keyValue[1];
                        break;
                    case "st":
                        SharedAccessStartTimeParameters = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "se":
                        SharedAccessExpiryTimeParameters = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "sip":
                        IPAddressOrRangeParameters = keyValue[1];
                        break;
                    case "spr":
                        if (keyValue[1] == "https")
                            ProtocolsParameters = HttpProtocol.Https;
                        else if (keyValue[1] == "https,http")
                            ProtocolsParameters = HttpProtocol.HttpsHttp;
                        break;
                    default:
                        break;
                }
            }

            AccountSasParameters parameters = new AccountSasParameters(ServiceParameters, ResourceTypesParameters, PermissionsParameters, SharedAccessExpiryTimeParameters)
            {
                IPAddressOrRange = IPAddressOrRangeParameters,
                Protocols = ProtocolsParameters,
                SharedAccessStartTime = SharedAccessStartTimeParameters
            };

            return parameters;
        }

        public static ServiceSasParameters ParseServiceSASToken(string serviceSAS, string canonicalizedResource)
        {
            string[] sasProperties = serviceSAS.Substring(1).Split(new char[] { '&' });

            ServiceSasParameters parameters = new ServiceSasParameters(canonicalizedResource);

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
                            parameters.Protocols = HttpProtocol.HttpsHttp;
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
