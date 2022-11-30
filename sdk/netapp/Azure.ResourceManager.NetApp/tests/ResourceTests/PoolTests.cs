// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.Resources;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class PoolTests : NetAppTestBase
    {
        public PoolTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            _netAppAccount = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;
        }

        [TearDown]
        public async Task ClearCapacityPools()
        {
            //remove all CapacityPool accounts under current netAppAccound and remove netAppAccount
            if (_resourceGroup != null)
            {
                List<CapacityPoolResource> capacityPoolList = await _capacityPoolCollection.GetAllAsync().ToEnumerableAsync();
                //remove capacityPools
                foreach (CapacityPoolResource capacityPool in capacityPoolList)
                {
                    await capacityPool.DeleteAsync(WaitUntil.Completed);
                }
                //remove account
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeletePool()
        {
            //create CapacityPool
            var poolName = Recording.GenerateAssetName("pool-");
            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            CapacityPoolResource capactiyPoolResource1 = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, poolName, capactiyPoolData)).Value;
            Assert.AreEqual(poolName, capactiyPoolResource1.Id.Name);
            VerifyCapacityPoolProperties(capactiyPoolResource1, true);
            (await capactiyPoolResource1.GetAsync()).Value.Should().BeEquivalentTo(capactiyPoolResource1);

            //validate if created successfully
            CapacityPoolResource capactiyPoolResource2 = await _capacityPoolCollection.GetAsync(poolName);
            VerifyCapacityPoolProperties(capactiyPoolResource2, true);
            capactiyPoolResource2.Should().BeEquivalentTo(capactiyPoolResource1);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(poolName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _capacityPoolCollection.ExistsAsync(poolName));
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(poolName + "1"));

            //delete CapacityPool
            await capactiyPoolResource1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(poolName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(poolName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task DeleteAccountWithPoolPresent()
        {
            //create CapacityPool
            var poolName = Recording.GenerateAssetName("pool-");
            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            CapacityPoolResource capactiyPoolResource1 = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, poolName, capactiyPoolData)).Value;
            Assert.AreEqual(poolName, capactiyPoolResource1.Id.Name);

            //Delete Account
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _netAppAccount.DeleteAsync(WaitUntil.Completed); });
            Assert.AreEqual(409, exception.Status);
            Assert.IsTrue(await _capacityPoolCollection.ExistsAsync(poolName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllPoolsByNetAppAccount()
        {
            var poolName1 = Recording.GenerateAssetName("pool-");
            var poolName2 = Recording.GenerateAssetName("pool-");
            //create two capacity pools
            CapacityPoolResource pool1 = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize, poolName1);
            CapacityPoolResource pool2 = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize, poolName2);

            //validate two capacityPools
            int count = 0;
            CapacityPoolResource pool3 = null;
            CapacityPoolResource pool4 = null;
            await foreach (CapacityPoolResource pool in _capacityPoolCollection.GetAllAsync())
            {
                count++;
                if (pool.Id.Name == poolName1)
                    pool3 = pool;
                if (pool.Id.Name == poolName2)
                    pool4 = pool;
            }
            Assert.AreEqual(count, 2);
            VerifyCapacityPoolProperties(pool3, true);
            VerifyCapacityPoolProperties(pool4, true);
            pool3.Should().BeEquivalentTo(pool1);
            pool4.Should().BeEquivalentTo(pool2);
        }

        [Test]
        [RecordedTest]
        public async Task PatchPool()
        {
            //create capacity pool
            CapacityPoolResource pool1 = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize);

            //Update with patch
            CapacityPoolPatch parameters = new(DefaultLocation);
            var keyValue = new KeyValuePair<string, string>("Tag2", "value2");
            parameters.Tags.InitializeFrom(DefaultTags);
            parameters.Tags.Add(keyValue);
            pool1 = (await pool1.UpdateAsync(WaitUntil.Completed, parameters)).Value;
            pool1.Data.Tags.Should().Contain(keyValue);

            // validate
            CapacityPoolResource pool2 = await _capacityPoolCollection.GetAsync(pool1.Data.Name.Split('/').Last());
            pool2.Data.Tags.Should().Contain(keyValue);
            KeyValuePair<string, string> keyValuePair = new("key1", DefaultTags["key1"]);
            pool2.Data.Tags.Should().Contain(keyValuePair);

            //service level should not change
            Assert.AreEqual(pool1.Data.ServiceLevel, pool2.Data.ServiceLevel);
        }

        [RecordedTest]
        public async Task UpdatePoolWithPut()
        {
            //create capacity pool
            CapacityPoolResource pool1 = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize);

            //update
            var keyValue = new KeyValuePair<string, string>("Tag2", "value2");
            pool1.Data.Tags.Add(keyValue);
            CapacityPoolResource pool2 = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, pool1.Data.Name.Split('/').Last(), pool1.Data)).Value;
            pool2.Data.Tags.Should().Contain(keyValue);
            KeyValuePair<string, string> keyValuePair = new("key1", DefaultTags["key1"]);
            pool2.Data.Tags.Should().Contain(keyValuePair);

            // validate
            CapacityPoolResource pool3 = await _capacityPoolCollection.GetAsync(pool1.Data.Name.Split('/').Last());
            pool3.Data.Tags.Should().Contain(keyValue);
        }

        [RecordedTest]
        public async Task GetPoolByNameFound()
        {
            //create capacity pool
            CapacityPoolResource pool1 = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize);

            // validate
            CapacityPoolResource pool2 = await _capacityPoolCollection.GetAsync(pool1.Data.Name.Split('/').Last());
            pool1.Should().BeEquivalentTo(pool2);
        }

        [RecordedTest]
        public async Task GetPoolByNameNotFound()
        {
            //create capacity pool
            CapacityPoolResource pool1 = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize);

            // validate
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync("poolName2");});
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task GetPoolByNameAccountNotFound()
        {
            //create capacity pool
            CapacityPoolResource pool1 = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize);

            // validate
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await netAppAccountCollection.GetAsync(_netAppAccount.Id.Name + "1"); });
            Assert.AreEqual(404, exception.Status);
        }
    }
}
