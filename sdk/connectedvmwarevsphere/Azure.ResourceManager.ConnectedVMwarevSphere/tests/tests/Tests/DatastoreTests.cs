// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class DatastoreTests : ConnectedVMwareTestBase
    {
        public DatastoreTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<VMwareDatastoreCollection> GetVMwareDatastoreCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetVMwareDatastores();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            var datastoreName = Recording.GenerateAssetName("testdatastore");
            var _datastoreCollection = await GetVMwareDatastoreCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var datastoreBody = new VMwareDatastoreData(DefaultLocation);
            datastoreBody.MoRefId = "datastore-11";
            datastoreBody.VCenterId = VcenterId;
            datastoreBody.ExtendedLocation = _extendedLocation;
            // create datastore
            VMwareDatastoreResource datastore1 = (await _datastoreCollection.CreateOrUpdateAsync(WaitUntil.Completed, datastoreName, datastoreBody)).Value;
            Assert.IsNotNull(datastore1);
            Assert.AreEqual(datastore1.Id.Name, datastoreName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var datastoreName = Recording.GenerateAssetName("testdatastore");
            var _datastoreCollection = await GetVMwareDatastoreCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var datastoreBody = new VMwareDatastoreData(DefaultLocation);
            datastoreBody.MoRefId = "datastore-11";
            datastoreBody.VCenterId = VcenterId;
            datastoreBody.ExtendedLocation = _extendedLocation;
            // create datastore
            VMwareDatastoreResource datastore1 = (await _datastoreCollection.CreateOrUpdateAsync(WaitUntil.Completed, datastoreName, datastoreBody)).Value;
            Assert.IsNotNull(datastore1);
            Assert.AreEqual(datastore1.Id.Name, datastoreName);
            // get datastore
            datastore1 = await _datastoreCollection.GetAsync(datastoreName);
            Assert.AreEqual(datastore1.Id.Name, datastoreName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var datastoreName = Recording.GenerateAssetName("testdatastore");
            var _datastoreCollection = await GetVMwareDatastoreCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var datastoreBody = new VMwareDatastoreData(DefaultLocation);
            datastoreBody.MoRefId = "datastore-11";
            datastoreBody.VCenterId = VcenterId;
            datastoreBody.ExtendedLocation = _extendedLocation;
            // create datastore
            VMwareDatastoreResource datastore1 = (await _datastoreCollection.CreateOrUpdateAsync(WaitUntil.Completed, datastoreName, datastoreBody)).Value;
            Assert.IsNotNull(datastore1);
            Assert.AreEqual(datastore1.Id.Name, datastoreName);
            // check for exists datastore
            bool exists = await _datastoreCollection.ExistsAsync(datastoreName);
            Assert.IsTrue(exists);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var datastoreName = Recording.GenerateAssetName("testdatastore");
            var _datastoreCollection = await GetVMwareDatastoreCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var datastoreBody = new VMwareDatastoreData(DefaultLocation);
            datastoreBody.MoRefId = "datastore-11";
            datastoreBody.VCenterId = VcenterId;
            datastoreBody.ExtendedLocation = _extendedLocation;
            // create datastore
            VMwareDatastoreResource datastore1 = (await _datastoreCollection.CreateOrUpdateAsync(WaitUntil.Completed, datastoreName, datastoreBody)).Value;
            Assert.IsNotNull(datastore1);
            Assert.AreEqual(datastore1.Id.Name, datastoreName);
            int count = 0;
            await foreach (var cluster in _datastoreCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var datastoreName = Recording.GenerateAssetName("testdatastore");
            var _datastoreCollection = await GetVMwareDatastoreCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var datastoreBody = new VMwareDatastoreData(DefaultLocation);
            datastoreBody.MoRefId = "datastore-11";
            datastoreBody.VCenterId = VcenterId;
            datastoreBody.ExtendedLocation = _extendedLocation;
            // create datastore
            VMwareDatastoreResource datastore1 = (await _datastoreCollection.CreateOrUpdateAsync(WaitUntil.Completed, datastoreName, datastoreBody)).Value;
            Assert.IsNotNull(datastore1);
            Assert.AreEqual(datastore1.Id.Name, datastoreName);
            datastore1 = null;
            await foreach (var datastore in DefaultSubscription.GetVMwareDatastoresAsync())
            {
                if (datastore.Data.Name == datastoreName)
                {
                    datastore1 = datastore;
                }
            }
            Assert.NotNull(datastore1);
        }
    }
}
