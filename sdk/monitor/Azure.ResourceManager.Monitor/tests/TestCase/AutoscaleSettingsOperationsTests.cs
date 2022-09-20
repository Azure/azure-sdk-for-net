// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class AutoscaleSettingsOperationsTests : MonitorTestBase
    {
        public AutoscaleSettingsOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        private async Task<AutoscaleSettingResource> CreateAutoscaleSettingAsync(string setting)
        {
            var collection = (await CreateResourceGroupAsync()).GetAutoscaleSettings();
            var input = ResourceDataHelper.GetBasicAutoscaleSettingData("eastus");
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setting, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var settingName = Recording.GenerateAssetName("testAutoscaleSetting-");
            var ssetting = await CreateAutoscaleSettingAsync(settingName);
            await ssetting.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var settingName = Recording.GenerateAssetName("testAutoscaleSetting-");
            var setting = await CreateAutoscaleSettingAsync(settingName);
            AutoscaleSettingResource setting2 = await setting.GetAsync();

            ResourceDataHelper.AssertAutoscaleSetting(setting.Data, setting2.Data);
        }
    }
}
