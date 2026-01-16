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
using Azure.ResourceManager.MixedReality.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.MixedReality.Tests
{
    public class SpatialAnchorsAccountTests: MixedRealityManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        private SpatialAnchorsAccountCollection _accountcollection;
        public SpatialAnchorsAccountTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        { }

        [SetUp]
        public async Task SetUp()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "SpatialAnchors-test",_location);
            _accountcollection = _resourceGroup.GetSpatialAnchorsAccounts();
        }

        [Test]
        public async Task SpatialAnchorsAccountCollection_Create()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            Assert.That(spatialAnchorsAccountResource, Is.Not.Null);
            Assert.That(spatialAnchorsAccountResource.Data.Name, Is.EqualTo(resourceName));
            Assert.That(spatialAnchorsAccountResource.Data.Location, Is.EqualTo(_location));
        }

        [Test]
        public async Task SpatialAnchorsAccountCollection_Exist()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            var collection = _resourceGroup.GetSpatialAnchorsAccounts();
            var exist = await collection.ExistsAsync(spatialAnchorsAccountResource.Data.Name);
            Assert.That(exist, Is.Not.Null);
            Assert.That(exist.Value, Is.True);
        }

        [Test]
        public async Task SpatialAnchorsAccountCollection_Get()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            SpatialAnchorsAccountResource getData = await _accountcollection.GetAsync(spatialAnchorsAccountResource.Data.Name);
            Assert.That(getData.Data.Id, Is.Not.Null);
            Assert.That(getData.Data.Name, Is.EqualTo(resourceName));
        }

        [Test]
        public async Task SpatialAnchorsAccountCollection_GetAll()
        {
            var resourceName1 = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource1 = await CreateSpatialAnchorsAccount(resourceName1);
            var resourceName2 = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource2 = await CreateSpatialAnchorsAccount(resourceName2);
            var collection = _resourceGroup.GetSpatialAnchorsAccounts();
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.Count >= 2, Is.True);
            Assert.That(list.Exists(item => item.Data.Name == spatialAnchorsAccountResource1.Data.Name), Is.True);
            Assert.That(list.Exists(item => item.Data.Name == spatialAnchorsAccountResource2.Data.Name), Is.True);
        }

        [Test]
        public async Task SpatialAnchorsAccountResource_Get()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            SpatialAnchorsAccountResource getData = await spatialAnchorsAccountResource.GetAsync();
            Assert.That((string)getData.Data.Id, Is.Not.Empty);
            Assert.That(spatialAnchorsAccountResource.Data.Id, Is.EqualTo(getData.Data.Id));
            Assert.That(spatialAnchorsAccountResource.Data.Name, Is.EqualTo(getData.Data.Name));
        }

        [Test]
        public async Task SpatialAnchorsAccountResource_Update()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            Assert.That(spatialAnchorsAccountResource.Data.StorageAccountName, Is.Null);
            var storage = await CreateStorage(_resourceGroup);
            var data = new SpatialAnchorsAccountData(_location)
            {
                Tags =
                {
                    ["key1"]="SpatialAnchors",
                    ["key2"]="updateTest"
                },
                StorageAccountName = storage.Data.Name
            };
            SpatialAnchorsAccountResource result = await spatialAnchorsAccountResource.UpdateAsync(data);
            Assert.That(result.Data.Tags, Is.Not.Empty);
            Assert.That(result.Data.StorageAccountName, Is.Not.Null);
            Assert.That(data.Tags, Is.EqualTo(result.Data.Tags));
            Assert.That(data.StorageAccountName, Is.EqualTo(result.Data.StorageAccountName));
        }

        [Test]
        public async Task SpatialAnchorsAccountResource_KeysOperation()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            MixedRealityAccountKeys result = await spatialAnchorsAccountResource.GetKeysAsync();
            Assert.That(result.PrimaryKey, Is.Not.Empty);
            Assert.That(result.SecondaryKey, Is.Not.Empty);
            var regeneratePrm = new MixedRealityAccountKeyRegenerateContent()
            {
                Serial = MixedRealityAccountKeySerial.Primary
            };
            MixedRealityAccountKeys RegenPrm = await spatialAnchorsAccountResource.RegenerateKeysAsync(regeneratePrm);
            Assert.That(RegenPrm, Is.Not.Null);
            var regenerateSec = new MixedRealityAccountKeyRegenerateContent()
            {
                Serial = MixedRealityAccountKeySerial.Secondary
            };
            MixedRealityAccountKeys RegenSec = await spatialAnchorsAccountResource.RegenerateKeysAsync(regenerateSec);
            Assert.That(RegenSec, Is.Not.Null);
        }

        [Test]
        public async Task SpatialAnchorsAccountResource_TagsOperation()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            SpatialAnchorsAccountResource addTags = await spatialAnchorsAccountResource.AddTagAsync("key1", "AddTags");
            Assert.That(addTags.Data.Tags.ContainsKey("key1"), Is.True);
            Assert.That(addTags.Data.Tags["key1"], Is.EqualTo("AddTags"));
            Assert.That(addTags.Data.Tags, Is.Not.Empty);
            var setTags = new Dictionary<string, string>()
            {
                ["key1"] = "SpatialAnchorstset",
                ["key2"] = "TagsOperate",
                ["key3"] = "SetTags"
            };
            SpatialAnchorsAccountResource Set = await spatialAnchorsAccountResource.SetTagsAsync(setTags);
            Assert.That(Set.Data.Tags["key1"], Is.EqualTo(setTags["key1"]));
            Assert.That(Set.Data.Tags["key1"] != "AddTags", Is.True);
            string removekey = "key3";
            SpatialAnchorsAccountResource Remove = await spatialAnchorsAccountResource.RemoveTagAsync(removekey);
            Assert.That(Remove.Data.Tags, Is.Not.Empty);
            var verifyDic = new Dictionary<string, string>();
            foreach (var item in Remove.Data.Tags)
            {
                verifyDic.Add(item.Key, item.Value);
            }
            Assert.That(verifyDic.ContainsKey(removekey), Is.False);
        }

        [Test]
        public async Task SpatialAnchorsAccountResource_CreateResourceIdentifier()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            var spatialAnchorsAccountResourceId = SpatialAnchorsAccountResource.CreateResourceIdentifier(_subscription.Id.SubscriptionId, _resourceGroup.Data.Name, spatialAnchorsAccountResource.Data.Name);
            var spatialAnchorsAccount = Client.GetSpatialAnchorsAccountResource(spatialAnchorsAccountResourceId);
            SpatialAnchorsAccountResource result = await spatialAnchorsAccount.GetAsync();
            Assert.That((string)result.Data.Id, Is.Not.Empty);
            Assert.That(spatialAnchorsAccountResource.Data.Id, Is.EqualTo(result.Data.Id));
            Assert.That(spatialAnchorsAccountResource.Data.Name, Is.EqualTo(result.Data.Name));
        }

        [Test]
        public async Task SpatialAnchorsAccountResource_Delete()
        {
            var resourceName = Recording.GenerateAssetName("spatialAnchorsAccount");
            var spatialAnchorsAccountResource = await CreateSpatialAnchorsAccount(resourceName);
            var deleted = await spatialAnchorsAccountResource.DeleteAsync(WaitUntil.Completed);
            Assert.That(deleted.HasCompleted, Is.True);
            var collection = _resourceGroup.GetSpatialAnchorsAccounts();
            var exist = await collection.ExistsAsync(resourceName);
            Assert.That((bool)exist, Is.False);
        }

        public async Task<SpatialAnchorsAccountResource> CreateSpatialAnchorsAccount(string accountName)
        {
            var data = new SpatialAnchorsAccountData(_location)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
            };
            return (await _accountcollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data)).Value;
        }

        public async Task<StorageAccountResource> CreateStorage(ResourceGroupResource resourceGroup)
        {
            var collection = resourceGroup.GetStorageAccounts();
            string storageAccountName = Recording.GenerateAssetName("storagespa");
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
