// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Advisor.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Advisor.Tests
{
    public class ConfigurationTests : AdvisorManagementTestBase
    {
        public ConfigurationTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private CpuThreshold TestThreshold = CpuThreshold.Twenty;
        private CpuThreshold DefaultThreshold = CpuThreshold.Five;

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync();
        }

        [Test]
        public async Task ConfigureSubscriptionTest()
        {
            string configName = "default";
            var configData = new ConfigData
            {
                Exclude = false,
                LowCpuThreshold = TestThreshold
            };

            await DefaultSubscription.CreateInSubscriptionConfigurationAsync(configName, configData);
            var data = await DefaultSubscription.GetConfigurationsBySubscriptionAsync().ToEnumerableAsync();
            Assert.AreEqual(TestThreshold, data.FirstOrDefault(x => x.Name.Equals(configName)).LowCpuThreshold);
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);

            configData.LowCpuThreshold = DefaultThreshold;
            await DefaultSubscription.CreateInSubscriptionConfigurationAsync(configName, configData);
            data = await DefaultSubscription.GetConfigurationsBySubscriptionAsync().ToEnumerableAsync();
            Assert.AreEqual(DefaultThreshold, data.FirstOrDefault(x => x.Name.Equals(configName)).LowCpuThreshold);
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);
        }

        [Test]
        public async Task ConfigureResourceGroupTest()
        {
            await SetCollection();

            string configName = "default";
            var configData = new ConfigData { Exclude = true };

            await ResourceGroup.CreateInResourceGroupConfigurationAsync(configName, configData);
            var data = await ResourceGroup.GetConfigurationsByResourceGroupAsync().ToEnumerableAsync();
            Assert.IsTrue(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);

            configData.Exclude = false;
            await ResourceGroup.CreateInResourceGroupConfigurationAsync(configName, configData);
            data = await ResourceGroup.GetConfigurationsByResourceGroupAsync().ToEnumerableAsync();
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);
        }
    }
}
