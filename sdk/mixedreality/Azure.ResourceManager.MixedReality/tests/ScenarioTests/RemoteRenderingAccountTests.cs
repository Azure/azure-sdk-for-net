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
            Assert.IsNotNull(remoteRenderingAccountResource);
            Assert.AreEqual(_location, remoteRenderingAccountResource.Data.Location);
            Assert.AreEqual(resourceName, remoteRenderingAccountResource.Data.Name);
        }

        [Test]
        public async Task RemoteRenderingAccoountCollection_Exists()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            var collection = _resourceGroup.GetRemoteRenderingAccounts();
            var exist = await collection.ExistsAsync(remoteRenderingAccountResource.Data.Name);
            Assert.IsNotNull(exist);
            Assert.IsTrue(exist.Value);
        }

        [Test]
        public async Task RemoteRenderingAccoountCollection_Get()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            RemoteRenderingAccountResource getData = await _accountcollection.GetAsync(remoteRenderingAccountResource.Data.Name);
            Assert.IsNotEmpty(getData.Data.Id);
            Assert.AreEqual(getData.Data.Name, remoteRenderingAccountResource.Data.Name);
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
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count >= 2);
            Assert.IsTrue(list.Exists(item => item.Data.Name == remoteRenderingAccountResource1.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == remoteRenderingAccountResource2.Data.Name));
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_Get()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            RemoteRenderingAccountResource result = await remoteRenderingAccountResource.GetAsync();
            Assert.IsNotEmpty(result.Data.Id);
            Assert.AreEqual(result.Data.Name, remoteRenderingAccountResource.Data.Name);
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_Update()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            Assert.IsNull(remoteRenderingAccountResource.Data.StorageAccountName);
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
            Assert.IsNotEmpty(result.Data.Tags);
            Assert.IsNotNull(result.Data.StorageAccountName);
            Assert.AreEqual(result.Data.Tags, data.Tags);
            Assert.AreEqual(result.Data.StorageAccountName, data.StorageAccountName);
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_KeysOperation()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            MixedRealityAccountKeys result = await remoteRenderingAccountResource.GetKeysAsync();
            Assert.IsNotEmpty(result.PrimaryKey);
            Assert.IsNotEmpty(result.SecondaryKey);
            var regeneratePrm = new MixedRealityAccountKeyRegenerateContent()
            {
                Serial = MixedRealityAccountKeySerial.Primary
            };
            MixedRealityAccountKeys RegenPrm = await remoteRenderingAccountResource.RegenerateKeysAsync(regeneratePrm);
            Assert.IsNotNull(RegenPrm.PrimaryKey);
            var regenerateSec = new MixedRealityAccountKeyRegenerateContent()
            {
                Serial = MixedRealityAccountKeySerial.Secondary
            };
            MixedRealityAccountKeys RegenSec = await remoteRenderingAccountResource.RegenerateKeysAsync(regenerateSec);
            Assert.IsNotNull(RegenSec);
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_TagsOperation()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            RemoteRenderingAccountResource addTags = await remoteRenderingAccountResource.AddTagAsync("key1", "AddTags");
            Assert.IsTrue(addTags.Data.Tags.ContainsKey("key1"));
            Assert.IsNotEmpty(addTags.Data.Tags);
            var setTags = new Dictionary<string, string>()
            {
                ["key1"] = "RemoteRendertest",
                ["key2"] = "TagsOperate",
                ["key3"] = "SetTags"
            };
            RemoteRenderingAccountResource Set = await remoteRenderingAccountResource.SetTagsAsync(setTags);
            Assert.AreEqual(setTags["key1"], Set.Data.Tags["key1"]);
            Assert.IsTrue(Set.Data.Tags["key1"] != "AddTags");
            string removekey = "key3";
            RemoteRenderingAccountResource Remove = await remoteRenderingAccountResource.RemoveTagAsync(removekey);
            Assert.IsNotEmpty(Remove.Data.Tags);
            var verifyDic = new Dictionary<string, string>();
            foreach (var item in Remove.Data.Tags)
            {
                verifyDic.Add(item.Key, item.Value);
            }
            Assert.IsFalse(verifyDic.ContainsKey(removekey));
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_CreateResourceIdentifier()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            var remoteRenderingAccountResourceId = RemoteRenderingAccountResource.CreateResourceIdentifier(_subscription.Id.SubscriptionId, _resourceGroup.Data.Name, remoteRenderingAccountResource.Data.Name);
            var remoteRenderingAccount = Client.GetRemoteRenderingAccountResource(remoteRenderingAccountResourceId);
            RemoteRenderingAccountResource result = await remoteRenderingAccount.GetAsync();
            Assert.IsNotEmpty(result.Data.Id);
            Assert.AreEqual(result.Data.Id, remoteRenderingAccountResource.Data.Id);
            Assert.AreEqual(result.Data.Name, remoteRenderingAccountResource.Data.Name);
        }

        [Test]
        public async Task RemoteRenderingAccoountResource_Delete()
        {
            var resourceName = Recording.GenerateAssetName("remoteRenderingAccoount");
            var remoteRenderingAccountResource = await CreateRemoteRenderingAccount(resourceName);
            var deleted = await remoteRenderingAccountResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleted.HasCompleted);
            var collection = _resourceGroup.GetRemoteRenderingAccounts();
            var exist = await collection.ExistsAsync(resourceName);
            Assert.IsFalse(exist.Value);
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
