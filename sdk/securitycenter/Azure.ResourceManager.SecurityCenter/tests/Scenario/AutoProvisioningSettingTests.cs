// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class AutoProvisioningSettingTests : SecurityCenterManagementTestBase
    {
        private AutoProvisioningSettingCollection _autoProvisioningSettingCollection => DefaultSubscription.GetAutoProvisioningSettings();
        private const string _automationName = "default";

        public AutoProvisioningSettingTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        private async Task<AutoProvisioningSettingResource> CreateAutoProvisioningSetting()
        {
            var data = new AutoProvisioningSettingData()
            {
                AutoProvision = AutoProvisionState.Off,
            };
            var autoProvisioningSetting = await _autoProvisioningSettingCollection.CreateOrUpdateAsync(WaitUntil.Completed, _automationName, data);
            return autoProvisioningSetting.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var autoProvisioningSetting = await CreateAutoProvisioningSetting();
            ValidateAutoProvisioningSetting(autoProvisioningSetting);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var autoProvisioningSetting = await CreateAutoProvisioningSetting();
            bool flag = await _autoProvisioningSettingCollection.ExistsAsync(_automationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            await CreateAutoProvisioningSetting();
            var autoProvisioningSetting = await _autoProvisioningSettingCollection.GetAsync(_automationName);
            ValidateAutoProvisioningSetting(autoProvisioningSetting);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var autoProvisioningSetting = await CreateAutoProvisioningSetting();
            var list = await _autoProvisioningSettingCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAutoProvisioningSetting(list.First(item => item.Data.Name == _automationName));
        }

        private void ValidateAutoProvisioningSetting(AutoProvisioningSettingResource autoProvisioningSetting, string automationName = "default")
        {
            Assert.IsNotNull(autoProvisioningSetting);
            Assert.IsNotNull(autoProvisioningSetting.Data.Id);
            Assert.AreEqual(automationName, autoProvisioningSetting.Data.Name);
            Assert.AreEqual("Microsoft.Security/autoProvisioningSettings", autoProvisioningSetting.Data.ResourceType.ToString());
        }
    }
}
