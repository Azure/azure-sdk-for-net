// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class LogProfileOperationsTests : MonitorTestBase
    {
        public LogProfileOperationsTests(bool isAsync)
            : base(isAsync)
        {
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

        private async Task<LogProfileResource> CreateLogProfileAsync(string logProfileName)
        {
            var collection = DefaultSubscription.GetLogProfiles();
            var input = ResourceDataHelper.GetBasicLogProfileData("Global");
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, logProfileName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var logProfileName = Recording.GenerateAssetName("test LogProfile-");
            var logProfile = await CreateLogProfileAsync(logProfileName);
            await logProfile.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var logProfileName = Recording.GenerateAssetName("testLogProfile-");
            var logProfile = await CreateLogProfileAsync(logProfileName);
            Thread.Sleep(1000);
            LogProfileResource logProfile2 = await logProfile.GetAsync();

            Assert.AreEqual(logProfile.Data.Name, logProfile2.Data.Name);
        }
    }
}
