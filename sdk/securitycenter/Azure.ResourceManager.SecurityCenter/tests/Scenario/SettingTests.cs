// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class SettingTests : SecurityCenterManagementTestBase
    {
        private const string _existSettingName = "WDATP_EXCLUDE_LINUX_PUBLIC_PREVIEW";
        private SecuritySettingCollection _settingCollection;

        public SettingTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
            _settingCollection = DefaultSubscription.GetSecuritySettings();
        }

        [RecordedTest]
        [Ignore("Do not support delete")]
        public async Task CreateOrUpdate()
        {
            string settingName = "JUST_FOR_TEST";
            SecuritySettingData data = new SecuritySettingData()
            {
                Kind = SettingKind.DataExportSettings,
            };
            var setting = await _settingCollection.CreateOrUpdateAsync(WaitUntil.Completed, settingName, data);
            ValidateSetting(setting.Value, _existSettingName);
        }

        [RecordedTest]
        public async Task Get()
        {
            var setting = await _settingCollection.GetAsync(_existSettingName);
            ValidateSetting(setting, _existSettingName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _settingCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateSetting(list.First(item => item.Data.Name == _existSettingName), _existSettingName);
        }

        private void ValidateSetting(SecuritySettingResource setting, string settingName)
        {
            Assert.That(setting, Is.Not.Null);
            Assert.That(setting.Data.Id, Is.Not.Null);
            Assert.That(setting.Data.Name, Is.EqualTo(settingName));
            Assert.That(setting.Data.Kind.ToString(), Is.EqualTo("DataExportSettings"));
            Assert.That(setting.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/settings"));
        }
    }
}
