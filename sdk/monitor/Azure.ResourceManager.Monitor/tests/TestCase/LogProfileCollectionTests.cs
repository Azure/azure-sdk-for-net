// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class LogProfileCollectionTests : MonitorTestBase
    {
        public LogProfileCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<LogProfileCollection> GetLogProfileCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return DefaultSubscription.GetLogProfiles();
        }

        [TearDown]
        protected void CleanUp()
        {
            CleanUpAsync().Wait();
        }

        private async Task CleanUpAsync()
        {
            var collection = DefaultSubscription.GetLogProfiles();
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetLogProfileCollectionAsync();
            var name = Recording.GenerateAssetName("testLogProfile");
            var input = ResourceDataHelper.GetBasicLogProfileData("westus");
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var logProfile = lro.Value;
            Assert.AreEqual(name, logProfile.Data.Name);
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetLogProfileCollectionAsync();
            var logProfileName = Recording.GenerateAssetName("testLogProfile-");
            var input = ResourceDataHelper.GetBasicLogProfileData("westus");
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, logProfileName, input);
            LogProfileResource lgoProfile1 = lro.Value;
            Thread.Sleep(1000);
            LogProfileResource logProfile2 = await collection.GetAsync(logProfileName);
            Assert.AreEqual(lgoProfile1.Data.Name, logProfile2.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetLogProfileCollectionAsync();
            var input = ResourceDataHelper.GetBasicLogProfileData("westus");
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testLogProfile-"), input);
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(list.Count, 1);
        }
    }
}
