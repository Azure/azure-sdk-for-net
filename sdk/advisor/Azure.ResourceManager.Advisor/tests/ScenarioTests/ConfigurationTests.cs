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
            var configData = new AdvisorConfigData
            {
                Exclude = false,
                LowCpuThreshold = TestThreshold
            };

            await DefaultSubscription.CreateAdvisorConfigurationAsync(configName, configData);
            var data = await DefaultSubscription.GetAdvisorConfigurationsAsync().ToEnumerableAsync();
            Assert.AreEqual(TestThreshold, data.FirstOrDefault(x => x.Name.Equals(configName)).LowCpuThreshold);
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);

            configData.LowCpuThreshold = DefaultThreshold;
            await DefaultSubscription.CreateAdvisorConfigurationAsync(configName, configData);
            data = await DefaultSubscription.GetAdvisorConfigurationsAsync().ToEnumerableAsync();
            Assert.AreEqual(DefaultThreshold, data.FirstOrDefault(x => x.Name.Equals(configName)).LowCpuThreshold);
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);
        }

        [Test]
        public async Task ConfigureResourceGroupTest()
        {
            string configName = "default";
            var configData = new AdvisorConfigData { Exclude = true };

            var resourceGroup = await CreateResourceGroupAsync();
            await resourceGroup.CreateAdvisorConfigurationAsync(configName, configData);
            var data = await resourceGroup.GetAdvisorConfigurationsAsync().ToEnumerableAsync();
            Assert.IsTrue(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);

            configData.Exclude = false;
            await resourceGroup.CreateAdvisorConfigurationAsync(configName, configData);
            data = await resourceGroup.GetAdvisorConfigurationsAsync().ToEnumerableAsync();
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).Exclude);
        }
    }
}
