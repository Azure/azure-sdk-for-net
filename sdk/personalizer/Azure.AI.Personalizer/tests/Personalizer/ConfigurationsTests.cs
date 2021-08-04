// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class ConfigurationsTests : PersonalizerTestBase
    {
        public ConfigurationsTests(bool isAsync): base(isAsync)
        {
        }

        [Test]
        public async Task GetServiceConfiguration()
        {
            PersonalizerAdministrationClient client = await GetPersonalizerAdministrationClientAsync(isSingleSlot: true);
            PersonalizerServiceProperties  defaultConfig = await client.GetPersonalizerPropertiesAsync();
            Assert.AreEqual(TimeSpan.FromSeconds(5), defaultConfig.RewardWaitTime);
            Assert.AreEqual(TimeSpan.FromMinutes(5), defaultConfig.ModelExportFrequency);
            Assert.AreEqual(0, defaultConfig.DefaultReward);
            Assert.AreEqual(0.2, defaultConfig.ExplorationPercentage, 0.00000001);
            Assert.AreEqual(90, defaultConfig.LogRetentionDays);
        }

        [Test]
        public async Task UpdateServiceConfiguration()
        {

            PersonalizerAdministrationClient client = await GetPersonalizerAdministrationClientAsync(isSingleSlot: true);
            TimeSpan newExperimentalUnitDuration = TimeSpan.FromMinutes(1);
            TimeSpan modelExportFrequency = TimeSpan.FromHours(1);
            double newDefaultReward = 1.0;
            string newRewardFuntion = "average";
            float newExplorationPercentage = 0.2f;
            var config = new PersonalizerServiceProperties (
                rewardAggregation: newRewardFuntion,
                modelExportFrequency: modelExportFrequency,
                defaultReward: (float)newDefaultReward,
                rewardWaitTime: newExperimentalUnitDuration,
                explorationPercentage: newExplorationPercentage,
                logRetentionDays: int.MaxValue
            );
            PersonalizerServiceProperties  result = await client.UpdatePersonalizerPropertiesAsync(config);
            Assert.AreEqual(config.DefaultReward, result.DefaultReward);
            Assert.True(Math.Abs(config.ExplorationPercentage - result.ExplorationPercentage) < 1e-3);
            Assert.AreEqual(config.ModelExportFrequency, result.ModelExportFrequency);
            Assert.AreEqual(config.RewardAggregation, result.RewardAggregation);
            Assert.AreEqual(config.RewardWaitTime, result.RewardWaitTime);
        }

        [Test]
        public async Task UpdateAndGetPolicy()
        {
            PersonalizerAdministrationClient client = await GetPersonalizerAdministrationClientAsync(isSingleSlot: true);
            var newPolicy = new PersonalizerPolicy(
                name: "app1",
                arguments: "--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2"
            );
            PersonalizerPolicy updatedPolicy = await client.UpdatePersonalizerPolicyAsync(newPolicy);
            Assert.NotNull(updatedPolicy);
            Assert.AreEqual(newPolicy.Arguments, updatedPolicy.Arguments);
            PersonalizerPolicy policy = await client.GetPersonalizerPolicyAsync();
            Assert.AreEqual(newPolicy.Arguments, policy.Arguments);
        }

        [Test]
        public async Task ResetPolicy()
        {
            PersonalizerAdministrationClient client = await GetPersonalizerAdministrationClientAsync(isSingleSlot: true);
            PersonalizerPolicy policy = await client.ResetPersonalizerPolicyAsync();
            Assert.AreEqual("--cb_explore_adf --epsilon 0.2 --power_t 0 -l 0.001 --cb_type mtr -q ::",
            policy.Arguments);
        }
    }
}
