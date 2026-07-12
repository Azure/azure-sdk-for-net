// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class AdvancedPlatformMetricsRuleTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private const string namePrefix = "teststoragemgmt";
        public AdvancedPlatformMetricsRuleTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetListDeleteAdvancedPlatformMetricsRule()
        {
            //create storage account
            string rgName = Recording.GenerateAssetName("teststorageRG-");
            _resourceGroup = (await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed, rgName, new Resources.ResourceGroupData(DefaultLocation))).Value;
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var parameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                DefaultLocation);
            StorageAccountResource account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //create a blob container for filter values
            string containerName = Recording.GenerateAssetName("container");
            await account.GetBlobService().GetBlobContainers()
                .CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData());

            //create advanced platform metrics rule
            AdvancedPlatformMetricsRuleCollection ruleCollection = account.GetAdvancedPlatformMetricsRules();
            AdvancedPlatformMetricsRuleType ruleType = AdvancedPlatformMetricsRuleType.ContainerLevelCapacityMetrics;
            var ruleData = new AdvancedPlatformMetricsRuleData()
            {
                Properties = new AdvancedPlatformMetricsRuleProperties(
                    true,
                    new AdvancedPlatformMetricsRuleConfig()
                    {
                        FilterType = AdvancedPlatformMetricsFilterType.AllContainersFilter
                    })
            };
            AdvancedPlatformMetricsRuleResource rule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleType, ruleData)).Value;

            //validate created rule
            Assert.IsNotNull(rule.Data.Properties);
            Assert.AreEqual(ruleType, rule.Data.Properties.RuleType);
            Assert.IsTrue(rule.Data.Properties.Enabled);
            Assert.AreEqual(AdvancedPlatformMetricsFilterType.AllContainersFilter, rule.Data.Properties.RuleConfig.FilterType);
            Assert.IsNotNull(rule.Data.Properties.LastModifiedOn);
            Assert.IsNotNull(rule.Data.Properties.MetricsEmitted);
            Assert.IsTrue(rule.Data.Properties.MetricsEmitted.Contains(MetricsEmitted.ContainerBlobCount));
            Assert.IsTrue(rule.Data.Properties.MetricsEmitted.Contains(MetricsEmitted.ContainerUsedSize));

            //get rule
            AdvancedPlatformMetricsRuleResource retrieved = (await ruleCollection.GetAsync(ruleType)).Value;
            Assert.AreEqual(rule.Data.Properties.RuleType, retrieved.Data.Properties.RuleType);
            Assert.AreEqual(rule.Data.Properties.Enabled, retrieved.Data.Properties.Enabled);
            Assert.AreEqual(rule.Data.Properties.RuleConfig.FilterType, retrieved.Data.Properties.RuleConfig.FilterType);

            //list rules
            List<AdvancedPlatformMetricsRuleResource> allRules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(allRules.Count, 1);
            Assert.IsTrue(allRules.Any(r => r.Data.Properties.RuleType == ruleType));

            //verify exists
            Assert.IsTrue((await ruleCollection.ExistsAsync(ruleType)).Value);

            //update rule with a different filter type and values
            var updatedData = new AdvancedPlatformMetricsRuleData()
            {
                Properties = new AdvancedPlatformMetricsRuleProperties(
                    false,
                    new AdvancedPlatformMetricsRuleConfig()
                    {
                        FilterType = AdvancedPlatformMetricsFilterType.ContainerListFilter
                    })
            };
            updatedData.Properties.RuleConfig.FilterValues.Add(containerName);
            AdvancedPlatformMetricsRuleResource updated = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleType, updatedData)).Value;
            Assert.IsFalse(updated.Data.Properties.Enabled);
            Assert.AreEqual(AdvancedPlatformMetricsFilterType.ContainerListFilter, updated.Data.Properties.RuleConfig.FilterType);
            Assert.AreEqual(1, updated.Data.Properties.RuleConfig.FilterValues.Count);
            Assert.AreEqual(containerName, updated.Data.Properties.RuleConfig.FilterValues[0]);

            //update rule with a container prefix filter
            var prefixData = new AdvancedPlatformMetricsRuleData()
            {
                Properties = new AdvancedPlatformMetricsRuleProperties(
                    true,
                    new AdvancedPlatformMetricsRuleConfig()
                    {
                        FilterType = AdvancedPlatformMetricsFilterType.ContainerPrefixFilter
                    })
            };
            prefixData.Properties.RuleConfig.FilterValues.Add(namePrefix);
            AdvancedPlatformMetricsRuleResource prefixUpdated = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleType, prefixData)).Value;
            Assert.IsTrue(prefixUpdated.Data.Properties.Enabled);
            Assert.AreEqual(AdvancedPlatformMetricsFilterType.ContainerPrefixFilter, prefixUpdated.Data.Properties.RuleConfig.FilterType);
            Assert.AreEqual(1, prefixUpdated.Data.Properties.RuleConfig.FilterValues.Count);
            Assert.AreEqual(namePrefix, prefixUpdated.Data.Properties.RuleConfig.FilterValues[0]);

            //delete rule
            await rule.DeleteAsync(WaitUntil.Completed);

            //verify deleted
            Assert.IsFalse((await ruleCollection.ExistsAsync(ruleType)).Value);
        }
    }
}
