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

        private AdvisorCpuThreshold TestThreshold = AdvisorCpuThreshold.Twenty;
        private AdvisorCpuThreshold DefaultThreshold = AdvisorCpuThreshold.Five;

        [Test]
        public async Task ConfigureSubscriptionTest()
        {
            string configName = "default";
            var configData = new AdvisorConfigurationData
            {
                IsExcluded = false,
                LowCpuThreshold = TestThreshold
            };

            await DefaultSubscription.CreateAdvisorConfigurationInSubscriptionAsync(configName, configData);
            var data = await DefaultSubscription.GetAdvisorConfigurationsBySubscriptionAsync().ToEnumerableAsync();
            Assert.AreEqual(TestThreshold, data.FirstOrDefault(x => x.Name.Equals(configName)).LowCpuThreshold);
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).IsExcluded);

            configData.LowCpuThreshold = DefaultThreshold;
            await DefaultSubscription.CreateAdvisorConfigurationInSubscriptionAsync(configName, configData);
            data = await DefaultSubscription.GetAdvisorConfigurationsBySubscriptionAsync().ToEnumerableAsync();
            Assert.AreEqual(DefaultThreshold, data.FirstOrDefault(x => x.Name.Equals(configName)).LowCpuThreshold);
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).IsExcluded);
        }

        [Test]
        public async Task ConfigureResourceGroupTest()
        {
            string configName = "default";
            var configData = new AdvisorConfigurationData { IsExcluded = true };

            var resourceGroup = await CreateResourceGroupAsync();
            await resourceGroup.CreateAdvisorConfigurationInResourceGroupAsync(configName, configData);
            var data = await resourceGroup.GetAdvisorConfigurationsByResourceGroupAsync().ToEnumerableAsync();
            Assert.IsTrue(data.FirstOrDefault(x => x.Name.Equals(configName)).IsExcluded);

            configData.IsExcluded = false;
            await resourceGroup.CreateAdvisorConfigurationInResourceGroupAsync(configName, configData);
            data = await resourceGroup.GetAdvisorConfigurationsByResourceGroupAsync().ToEnumerableAsync();
            Assert.IsFalse(data.FirstOrDefault(x => x.Name.Equals(configName)).IsExcluded);
        }
    }
}
