// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class SettingResourceTests : SecurityInsightsManagementTestBase
    {
        public SettingResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<SettingResource> CreateSettingAsync(string alertRulesName)
        {
            var collection = (await CreateResourceGroupAsync()).GetSettings(workspaceName);
            var input = ResourceDataHelpers.GetSettingData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, alertRulesName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task SettingResourceApiTests()
        {
            //1.Get
            var applicationName = Recording.GenerateAssetName("testSettings-");
            var setting1 = await CreateSettingAsync(applicationName);
            SettingResource setting2 = await setting1.GetAsync();

            ResourceDataHelpers.AssertSettingData(setting1.Data, setting2.Data);
            //2.Delete
            await setting1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
