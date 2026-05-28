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

        private CpuThreshold TestThreshold = CpuThreshold.Twenty;
        private CpuThreshold DefaultThreshold = CpuThreshold.Five;

        [Test]
        public async Task ConfigureSubscriptionTest()
        {
            string configName = "default";
            var configData = new ConfigData
            {
                Exclude = false,
                LowCpuThreshold = TestThreshold
            };

            await DefaultSubscription.CreateConfigurationAsync(configName, configData);
            var data = await DefaultSubscription.GetConfigurationsAsync().ToEnumerableAsync();
            Assert.AreEqual(TestThreshold, data.FirstOrDefault(x => x.Name.Equals(configName)).LowCpuThreshold);
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);

            configData.LowCpuThreshold = DefaultThreshold;
            await DefaultSubscription.CreateConfigurationAsync(configName, configData);
            data = await DefaultSubscription.GetConfigurationsAsync().ToEnumerableAsync();
            Assert.AreEqual(DefaultThreshold, data.FirstOrDefault(x => x.Name.Equals(configName)).LowCpuThreshold);
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);
        }

        [Test]
        public async Task ConfigureResourceGroupTest()
        {
            string configName = "default";
            var configData = new ConfigData { Exclude = true };

            var resourceGroup = await CreateResourceGroupAsync();
            await resourceGroup.CreateConfigurationAsync(configName, configData);
            var data = await resourceGroup.GetConfigurationsAsync().ToEnumerableAsync();
            Assert.IsTrue(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);

            configData.Exclude = false;
            await resourceGroup.CreateConfigurationAsync(configName, configData);
            data = await resourceGroup.GetConfigurationsAsync().ToEnumerableAsync();
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);
        }
    }
}
