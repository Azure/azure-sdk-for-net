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
    public class HostTests : ConnectedVMwareTestBase
    {
        public HostTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<VMwareHostCollection> GetVMwareHostCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetVMwareHosts();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            var hostName = Recording.GenerateAssetName("testhost");
            var _hostCollection = await GetVMwareHostCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var hostBody = new VMwareHostData(DefaultLocation);
            hostBody.MoRefId = "host-112923";
            hostBody.VCenterId = VcenterId;
            hostBody.ExtendedLocation = _extendedLocation;
            // create host
            VMwareHostResource host1 = (await _hostCollection.CreateOrUpdateAsync(WaitUntil.Completed, hostName, hostBody)).Value;
            Assert.IsNotNull(host1);
            Assert.AreEqual(host1.Id.Name, hostName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var hostName = Recording.GenerateAssetName("testhost");
            var _hostCollection = await GetVMwareHostCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var hostBody = new VMwareHostData(DefaultLocation);
            hostBody.MoRefId = "host-27";
            hostBody.VCenterId = VcenterId;
            hostBody.ExtendedLocation = _extendedLocation;
            // create host
            VMwareHostResource host1 = (await _hostCollection.CreateOrUpdateAsync(WaitUntil.Completed, hostName, hostBody)).Value;
            Assert.IsNotNull(host1);
            Assert.AreEqual(host1.Id.Name, hostName);
            // get host
            host1 = await _hostCollection.GetAsync(hostName);
            Assert.AreEqual(host1.Id.Name, hostName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var hostName = Recording.GenerateAssetName("testhost");
            var _hostCollection = await GetVMwareHostCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var hostBody = new VMwareHostData(DefaultLocation);
            hostBody.MoRefId = "host-111894";
            hostBody.VCenterId = VcenterId;
            hostBody.ExtendedLocation = _extendedLocation;
            // create host
            VMwareHostResource host1 = (await _hostCollection.CreateOrUpdateAsync(WaitUntil.Completed, hostName, hostBody)).Value;
            Assert.IsNotNull(host1);
            Assert.AreEqual(host1.Id.Name, hostName);
            // check for exists host
            bool exists = await _hostCollection.ExistsAsync(hostName);
            Assert.IsTrue(exists);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var hostName = Recording.GenerateAssetName("testhost");
            var _hostCollection = await GetVMwareHostCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var hostBody = new VMwareHostData(DefaultLocation);
            hostBody.MoRefId = "host-33";
            hostBody.VCenterId = VcenterId;
            hostBody.ExtendedLocation = _extendedLocation;
            // create host
            VMwareHostResource host1 = (await _hostCollection.CreateOrUpdateAsync(WaitUntil.Completed, hostName, hostBody)).Value;
            Assert.IsNotNull(host1);
            Assert.AreEqual(host1.Id.Name, hostName);
            int count = 0;
            await foreach (var host in _hostCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var hostName = Recording.GenerateAssetName("testhost");
            var _hostCollection = await GetVMwareHostCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var hostBody = new VMwareHostData(DefaultLocation);
            hostBody.MoRefId = "host-111900";
            hostBody.VCenterId = VcenterId;
            hostBody.ExtendedLocation = _extendedLocation;
            // create host
            VMwareHostResource host1 = (await _hostCollection.CreateOrUpdateAsync(WaitUntil.Completed, hostName, hostBody)).Value;
            Assert.IsNotNull(host1);
            Assert.AreEqual(host1.Id.Name, hostName);
            host1 = null;
            await foreach (var host in DefaultSubscription.GetVMwareHostsAsync())
            {
                if (host.Data.Name == hostName)
                {
                    host1 = host;
                }
            }
            Assert.NotNull(host1);
        }
    }
}
