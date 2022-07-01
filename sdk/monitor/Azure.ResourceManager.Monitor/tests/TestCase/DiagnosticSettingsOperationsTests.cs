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
    public class DiagnosticSettingsOperationsTests : MonitorTestBase
    {
        public DiagnosticSettingsOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        private async Task<DiagnosticSettingsResource> CreateDiagnosticSettingsAsync(string setting)
        {
            var collection = (await CreateResourceGroupAsync()).GetDiagnosticSettings();
            var input = ResourceDataHelper.GetBasicDiagnosticSettingsData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setting, input);
            return lro.Value;
        }

        [Ignore("Need to Update cleanup")]
        [TestCase]
        public async Task Delete()
        {
            var settingName = Recording.GenerateAssetName("testDiagnosticSettings-");
            var ssetting = await CreateDiagnosticSettingsAsync(settingName);
            await ssetting.DeleteAsync(WaitUntil.Completed);
        }

        [Ignore("Need to Update cleanup")]
        [TestCase]
        public async Task Get()
        {
            var settingName = Recording.GenerateAssetName("testDiagnosticSettings-");
            var setting = await CreateDiagnosticSettingsAsync(settingName);
            DiagnosticSettingsResource setting2 = await setting.GetAsync();

            ResourceDataHelper.AssertDiagnosticSetting(setting.Data, setting2.Data);
        }
    }
}
