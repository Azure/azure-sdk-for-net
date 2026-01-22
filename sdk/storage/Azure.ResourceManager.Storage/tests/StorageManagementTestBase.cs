// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/23897")]
    [ClientTestFixture]
    public class StorageManagementTestBase : ManagementRecordedTestBase<StorageManagementTestEnvironment>
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
        protected StorageManagementTestBase(bool isAsync) : base(isAsync)
        {
            IgnoreNetworkDependencyVersions();
        }

        public StorageManagementTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            IgnoreNetworkDependencyVersions();
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
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Id, Is.Not.Null);
            Assert.That(account.Id.Name, Is.Not.Null);
            Assert.That(account.Data.Location, Is.Not.Null);
            Assert.That(account.Data, Is.Not.Null);
            Assert.That(account.Data.CreatedOn, Is.Not.Null);
            Assert.That(account.Data.Sku, Is.Not.Null);
            Assert.That(account.Data.Sku.Name, Is.Not.Null);
            Assert.That(account.Data.Sku.Tier, Is.Not.Null);
            Assert.That(account.Data.PrimaryEndpoints, Is.Not.Null);

            if (useDefaults)
            {
                Assert.That(account.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(account.Data.Sku.Name, Is.EqualTo(DefaultSkuNameStandardGRS.Name));
                Assert.That(account.Data.Sku.Tier, Is.EqualTo(StorageSkuTier.Standard));
                Assert.That(account.Data.Kind, Is.EqualTo(DefaultKindStorage));

                Assert.That(account.Data.Tags, Is.Not.Null);
                Assert.That(account.Data.Tags.Count, Is.EqualTo(2));
                Assert.That(account.Data.Tags["key1"], Is.EqualTo("value1"));
                Assert.That(account.Data.Tags["key2"], Is.EqualTo("value2"));
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
            Assert.That(account2.Id.Name, Is.EqualTo(account1.Id.Name));
            Assert.That(account2.Id.Location, Is.EqualTo(account1.Id.Location));
        }

        public static void AssertBlobContainerEqual(BlobContainerResource blobContainer1, BlobContainerResource blobContainer2)
        {
            Assert.That(blobContainer2.Id.Name, Is.EqualTo(blobContainer1.Id.Name));
            Assert.That(blobContainer2.Id.Location, Is.EqualTo(blobContainer1.Id.Location));
        }

        public static void AssertFileShareEqual(FileShareResource fileShare1, FileShareResource fileShare2)
        {
            Assert.That(fileShare2.Id.Name, Is.EqualTo(fileShare1.Id.Name));
            Assert.That(fileShare2.Id.Location, Is.EqualTo(fileShare1.Id.Location));
        }

        public static void AssertStorageQueueEqual(StorageQueueResource storageQueue1, StorageQueueResource storageQueue2)
        {
            Assert.That(storageQueue2.Id.Name, Is.EqualTo(storageQueue1.Id.Name));
            Assert.That(storageQueue2.Id.Location, Is.EqualTo(storageQueue1.Id.Location));
        }

        public static void AssertTableEqual(TableResource table1, TableResource table2)
        {
            Assert.That(table2.Id.Name, Is.EqualTo(table1.Id.Name));
            Assert.That(table2.Id.Location, Is.EqualTo(table1.Id.Location));
        }
    }
}
