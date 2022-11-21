// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Storage.Tests.Helpers
{
    [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/23897")]
    [ClientTestFixture]
    public class StorageTestBase : ManagementRecordedTestBase<StorageManagementTestEnvironment>
    {
        public static AzureLocation DefaultLocation => AzureLocation.EastUS2;
        public static string DefaultLocationString = "eastus2";
        public static bool IsTestTenant = false;
        // These are used to create default accounts
        public static StorageSku DefaultSkuNameStandardGRS = new StorageSku(StorageSkuName.StandardGrs);
        public static StorageKind DefaultKindStorage = StorageKind.Storage;
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected StorageTestBase(bool isAsync) : base(isAsync)
        {
        }

        public StorageTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public static StorageAccountCreateOrUpdateContent GetDefaultStorageAccountParameters(StorageSku sku = null, StorageKind? kind = null, string location = null, ManagedServiceIdentity identity = null)
        {
            StorageSku skuParameters = sku ?? DefaultSkuNameStandardGRS;
            StorageKind kindParameters = kind ?? DefaultKindStorage;
            string locationParameters = location ?? DefaultLocationString;
            StorageAccountCreateOrUpdateContent parameters = new StorageAccountCreateOrUpdateContent(skuParameters, kindParameters, locationParameters);
            parameters.Tags.InitializeFrom(DefaultTags);
            parameters.Identity = identity;
            return parameters;
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        [TearDown]
        public async Task waitForDeletion()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("teststorageRG-");
            ArmOperation<ResourceGroupResource> operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return operation.Value;
        }

        public async Task<string> CreateValidAccountNameAsync(string prefix)
        {
            string accountName = prefix;
            for (int i = 0; i < 10; i++)
            {
                accountName = Recording.GenerateAssetName(prefix);
                StorageAccountNameAvailabilityContent parameter = new StorageAccountNameAvailabilityContent(accountName);
                StorageAccountNameAvailabilityResult result = await DefaultSubscription.CheckStorageAccountNameAvailabilityAsync(parameter);
                if (result.IsNameAvailable ?? false)
                {
                    return accountName;
                }
            }
            return accountName;
        }

        public static void VerifyAccountProperties(StorageAccountResource account, bool useDefaults)
        {
            Assert.NotNull(account);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Id.Name);
            Assert.NotNull(account.Data.Location);
            Assert.NotNull(account.Data);
            Assert.NotNull(account.Data.CreatedOn);
            Assert.NotNull(account.Data.Sku);
            Assert.NotNull(account.Data.Sku.Name);
            Assert.NotNull(account.Data.Sku.Tier);
            Assert.NotNull(account.Data.PrimaryEndpoints);

            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, account.Data.Location);
                Assert.AreEqual(DefaultSkuNameStandardGRS.Name, account.Data.Sku.Name);
                Assert.AreEqual(StorageSkuTier.Standard, account.Data.Sku.Tier);
                Assert.AreEqual(DefaultKindStorage, account.Data.Kind);

                Assert.NotNull(account.Data.Tags);
                Assert.AreEqual(2, account.Data.Tags.Count);
                Assert.AreEqual("value1", account.Data.Tags["key1"]);
                Assert.AreEqual("value2", account.Data.Tags["key2"]);
            }
        }

        public static AccountSasContent ParseAccountSASToken(string accountSasToken)
        {
            string[] sasProperties = accountSasToken.Substring(1).Split(new char[] { '&' });

            string serviceParameters = string.Empty;
            string resourceTypesParameters = string.Empty;
            string permissionsParameters = string.Empty;
            string ipAddressOrRangeParameters = string.Empty;
            DateTimeOffset sharedAccessStartTimeParameters = new DateTimeOffset();
            DateTimeOffset sharedAccessExpiryTimeParameters = new DateTimeOffset();
            StorageAccountHttpProtocol? protocolsParameters = null;

            foreach (var property in sasProperties)
            {
                string[] keyValue = property.Split(new char[] { '=' });
                switch (keyValue[0])
                {
                    case "ss":
                        serviceParameters = keyValue[1];
                        break;
                    case "srt":
                        resourceTypesParameters = keyValue[1];
                        break;
                    case "sp":
                        permissionsParameters = keyValue[1];
                        break;
                    case "st":
                        sharedAccessStartTimeParameters = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "se":
                        sharedAccessExpiryTimeParameters = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "sip":
                        ipAddressOrRangeParameters = keyValue[1];
                        break;
                    case "spr":
                        if (keyValue[1] == "https")
                            protocolsParameters = StorageAccountHttpProtocol.Https;
                        else if (keyValue[1] == "https,http")
                            protocolsParameters = StorageAccountHttpProtocol.HttpsHttp;
                        break;
                    default:
                        break;
                }
            }
            AccountSasContent parameters = new AccountSasContent(serviceParameters, resourceTypesParameters, permissionsParameters, sharedAccessExpiryTimeParameters)
            {
                IPAddressOrRange = ipAddressOrRangeParameters,
                Protocols = protocolsParameters,
                SharedAccessStartOn = sharedAccessStartTimeParameters
            };

            return parameters;
        }

        public static ServiceSasContent ParseServiceSASToken(string serviceSAS, string canonicalizedResource)
        {
            string[] sasProperties = serviceSAS.Substring(1).Split(new char[] { '&' });

            ServiceSasContent parameters = new ServiceSasContent(canonicalizedResource);

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
                        parameters.SharedAccessStartOn = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "se":
                        parameters.SharedAccessExpiryOn = DateTime.Parse(keyValue[1].Replace("%3A", ":").Replace("%3a", ":")).ToUniversalTime();
                        break;
                    case "sip":
                        parameters.IPAddressOrRange = keyValue[1];
                        break;
                    case "spr":
                        if (keyValue[1] == "https")
                            parameters.Protocols = StorageAccountHttpProtocol.Https;
                        else if (keyValue[1] == "https,http")
                            parameters.Protocols = StorageAccountHttpProtocol.HttpsHttp;
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

        public static void AssertStorageAccountEqual(StorageAccountResource account1, StorageAccountResource account2)
        {
            Assert.AreEqual(account1.Id.Name, account2.Id.Name);
            Assert.AreEqual(account1.Id.Location, account2.Id.Location);
        }

        public static void AssertBlobContainerEqual(BlobContainerResource blobContainer1, BlobContainerResource blobContainer2)
        {
            Assert.AreEqual(blobContainer1.Id.Name, blobContainer2.Id.Name);
            Assert.AreEqual(blobContainer1.Id.Location, blobContainer2.Id.Location);
        }

        public static void AssertFileShareEqual(FileShareResource fileShare1, FileShareResource fileShare2)
        {
            Assert.AreEqual(fileShare1.Id.Name, fileShare2.Id.Name);
            Assert.AreEqual(fileShare1.Id.Location, fileShare2.Id.Location);
        }

        public static void AssertStorageQueueEqual(StorageQueueResource storageQueue1, StorageQueueResource storageQueue2)
        {
            Assert.AreEqual(storageQueue1.Id.Name, storageQueue2.Id.Name);
            Assert.AreEqual(storageQueue1.Id.Location, storageQueue2.Id.Location);
        }

        public static void AssertTableEqual(TableResource table1, TableResource table2)
        {
            Assert.AreEqual(table1.Id.Name, table2.Id.Name);
            Assert.AreEqual(table1.Id.Location, table2.Id.Location);
        }
    }
}
