// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.MixedReality;
using Azure.ResourceManager.MixedReality.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.MixedReality.Tests
{
    public class RemoteRenderingAccountTests : MixedRealityManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        private RemoteRenderingAccountCollection _accountcollection;
        public RemoteRenderingAccountTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        { }

        [SetUp]
        public async Task SetUp()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "RemoteRendering-test", _location);
            _accountcollection = _resourceGroup.GetRemoteRenderingAccounts();
        }

        [Test]
        public async Task RemoteRenderingAccountCollection_Create()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            Assert.That(remoteRenderingAccountResource, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(remoteRenderingAccountResource.Data.Location, Is.EqualTo(_location));
                Assert.That(remoteRenderingAccountResource.Data.Name, Is.EqualTo(resourceName));
            });
        }

        [Test]
        public async Task RemoteRenderingAccoountCollection_Exists()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            var collection = _resourceGroup.GetRemoteRenderingAccounts();
            var exist = await collection.ExistsAsync(remoteRenderingAccountResource.Data.Name);
            Assert.That(exist, Is.Not.Null);
            Assert.That(exist.Value, Is.True);
        }

        [Test]
        public async Task RemoteRenderingAccoountCollection_Get()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            RemoteRenderingAccountResource getData = await _accountcollection.GetAsync(remoteRenderingAccountResource.Data.Name);
            Assert.Multiple(() =>
            {
                Assert.That((string)getData.Data.Id, Is.Not.Empty);
                Assert.That(remoteRenderingAccountResource.Data.Name, Is.EqualTo(getData.Data.Name));
            });
        }

        [Test]
        public async Task RemoteRenderingAccoountCollection_GetAll()
        {
            var resourceName1 = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource1 = await CreateRemoteRenderingAccount(resourceName1);
            var resourceName2 = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource2 = await CreateRemoteRenderingAccount(resourceName2);
            var collection = _resourceGroup.GetRemoteRenderingAccounts();
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Has.Count.GreaterThanOrEqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(list.Exists(item => item.Data.Name == remoteRenderingAccountResource1.Data.Name), Is.True);
                Assert.That(list.Exists(item => item.Data.Name == remoteRenderingAccountResource2.Data.Name), Is.True);
            });
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_Get()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            RemoteRenderingAccountResource result = await remoteRenderingAccountResource.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That((string)result.Data.Id, Is.Not.Empty);
                Assert.That(remoteRenderingAccountResource.Data.Name, Is.EqualTo(result.Data.Name));
            });
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_Update()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            Assert.That(remoteRenderingAccountResource.Data.StorageAccountName, Is.Null);
            var storage = await CreateStorage(_resourceGroup);
            var data = new RemoteRenderingAccountData(_location)
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                Tags =
                {
                    ["key1"]="RemoteRender",
                    ["key2"]="updateTest"
                },
                StorageAccountName = storage.Data.Name
            };
            RemoteRenderingAccountResource result = await remoteRenderingAccountResource.UpdateAsync(data);
            Assert.Multiple(() =>
            {
                Assert.That(result.Data.Tags, Is.Not.Empty);
                Assert.That(result.Data.StorageAccountName, Is.Not.Null);
                Assert.That(data.Tags, Is.EqualTo(result.Data.Tags));
                Assert.That(data.StorageAccountName, Is.EqualTo(result.Data.StorageAccountName));
            });
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_KeysOperation()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            MixedRealityAccountKeys result = await remoteRenderingAccountResource.GetKeysAsync();
            Assert.Multiple(() =>
            {
                Assert.That(result.PrimaryKey, Is.Not.Empty);
                Assert.That(result.SecondaryKey, Is.Not.Empty);
            });
            var regeneratePrm = new MixedRealityAccountKeyRegenerateContent()
            {
                Serial = MixedRealityAccountKeySerial.Primary
            };
            MixedRealityAccountKeys RegenPrm = await remoteRenderingAccountResource.RegenerateKeysAsync(regeneratePrm);
            Assert.That(RegenPrm.PrimaryKey, Is.Not.Null);
            var regenerateSec = new MixedRealityAccountKeyRegenerateContent()
            {
                Serial = MixedRealityAccountKeySerial.Secondary
            };
            MixedRealityAccountKeys RegenSec = await remoteRenderingAccountResource.RegenerateKeysAsync(regenerateSec);
            Assert.That(RegenSec, Is.Not.Null);
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_TagsOperation()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            RemoteRenderingAccountResource addTags = await remoteRenderingAccountResource.AddTagAsync("key1", "AddTags");
            Assert.Multiple(() =>
            {
                Assert.That(addTags.Data.Tags.ContainsKey("key1"), Is.True);
                Assert.That(addTags.Data.Tags, Is.Not.Empty);
            });
            var setTags = new Dictionary<string, string>()
            {
                ["key1"] = "RemoteRendertest",
                ["key2"] = "TagsOperate",
                ["key3"] = "SetTags"
            };
            RemoteRenderingAccountResource Set = await remoteRenderingAccountResource.SetTagsAsync(setTags);
            Assert.That(Set.Data.Tags["key1"], Is.EqualTo(setTags["key1"]));
            Assert.That(Set.Data.Tags["key1"], Is.Not.EqualTo("AddTags"));
            string removekey = "key3";
            RemoteRenderingAccountResource Remove = await remoteRenderingAccountResource.RemoveTagAsync(removekey);
            Assert.That(Remove.Data.Tags, Is.Not.Empty);
            var verifyDic = new Dictionary<string, string>();
            foreach (var item in Remove.Data.Tags)
            {
                verifyDic.Add(item.Key, item.Value);
            }
            Assert.That(verifyDic.ContainsKey(removekey), Is.False);
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_CreateResourceIdentifier()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            var remoteRenderingAccountResourceId = RemoteRenderingAccountResource.CreateResourceIdentifier(_subscription.Id.SubscriptionId, _resourceGroup.Data.Name, remoteRenderingAccountResource.Data.Name);
            var remoteRenderingAccount = Client.GetRemoteRenderingAccountResource(remoteRenderingAccountResourceId);
            RemoteRenderingAccountResource result = await remoteRenderingAccount.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That((string)result.Data.Id, Is.Not.Empty);
                Assert.That(remoteRenderingAccountResource.Data.Id, Is.EqualTo(result.Data.Id));
                Assert.That(remoteRenderingAccountResource.Data.Name, Is.EqualTo(result.Data.Name));
            });
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_Delete()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            var deleted = await remoteRenderingAccountResource.DeleteAsync(WaitUntil.Completed);
            Assert.That(deleted.HasCompleted, Is.True);
            var collection = _resourceGroup.GetRemoteRenderingAccounts();
            var exist = await collection.ExistsAsync(resourceName);
            Assert.That(exist.Value, Is.False);
        }

        public async Task<RemoteRenderingAccountResource> CreateRemoteRenderingAccount(string resourceName)
        {
            var data = new RemoteRenderingAccountData(_location)
            {
                Identity = new ManagedServiceIdentity("SystemAssigned")
            };
            return (await _accountcollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data)).Value;
        }

        public async Task<StorageAccountResource> CreateStorage(ResourceGroupResource resourceGroup)
        {
            var collection = resourceGroup.GetStorageAccounts();
            string storageAccountName = Recording.GenerateAssetName("storagerer");
            return (await collection.CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs)))).Value;
        }

        public StorageAccountCreateOrUpdateContent GetDefaultStorageAccountParameters(StorageSku sku = null, StorageKind? kind = null, ManagedServiceIdentity identity = null)
        {
            var DefaultTags = new Dictionary<string, string>()
            {
                {"key1","value1"},
                {"key2","value2"}
            };
            StorageSku skuParameter = new StorageSku(StorageSkuName.StandardGrs);
            StorageKind kindParameters = StorageKind.Storage;
            AzureLocation locationParameters = _location;
            StorageAccountCreateOrUpdateContent content = new StorageAccountCreateOrUpdateContent(skuParameter, kindParameters, locationParameters);
            content.Tags.InitializeFrom(DefaultTags);
            content.Identity = identity;
            return content;
        }
    }
}
