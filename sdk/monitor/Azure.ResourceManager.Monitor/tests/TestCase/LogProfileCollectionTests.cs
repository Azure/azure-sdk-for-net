// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests.TestsCase
{
    public class LogProfileCollectionTests : MonitorTestBase
    {
        public LogProfileCollectionTests(bool isAsync)
           : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<LogProfileCollection> GetLogProfileCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return SubscriptionExtensions.GetLogProfiles(DefaultSubscription);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetLogProfileCollectionAsync();
            var name = Recording.GenerateAssetName("testLogProfile");
            var input = ResourceDataHelper.GetBasicLogProfileData("global");
            var lro = await container.CreateOrUpdateAsync(true, name, input);
            var logProfile = lro.Value;
            Assert.AreEqual(name, logProfile.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetLogProfileCollectionAsync();
            var logProfileName = Recording.GenerateAssetName("testLogProfile-");
            var input = ResourceDataHelper.GetBasicLogProfileData("global");
            var lro = await collection.CreateOrUpdateAsync(true, logProfileName, input);
            LogProfile lgoProfile1 = lro.Value;
            LogProfile logProfile2 = await collection.GetAsync(logProfileName);
            ResourceDataHelper.AssertLogProfile(lgoProfile1.Data, logProfile2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetLogProfileCollectionAsync();
            var input = ResourceDataHelper.GetBasicLogProfileData("global");
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testLogProfile-"), input);
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testLogProfile-"), input);
            int count = 0;
            await foreach (var logProfile in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
