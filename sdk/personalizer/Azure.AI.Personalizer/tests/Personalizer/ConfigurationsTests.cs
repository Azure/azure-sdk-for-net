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
        public async Task ConfigurationTests()
        {
            TimeSpan newExperimentalUnitDuration = TimeSpan.FromHours(4);
            TimeSpan modelExportFrequency = TimeSpan.FromMinutes(3);
            double newDefaultReward = 1.0;
            string newRewardFuntion = "average";
            float newExplorationPercentage = 0.2f;
            var properties = new PersonalizerServiceProperties(
                rewardAggregation: newRewardFuntion,
                modelExportFrequency: modelExportFrequency,
                defaultReward: (float)newDefaultReward,
                rewardWaitTime: newExperimentalUnitDuration,
                explorationPercentage: newExplorationPercentage,
                logRetentionDays: int.MaxValue
            );
            PersonalizerAdministrationClient client = GetAdministrationClient(isSingleSlot: true);
            await UpdateProperties(client, properties);
            await GetProperties(client, properties);
            await UpdateAndGetPolicy(client);
            await ResetPolicy(client);
        }

        private async Task GetProperties(PersonalizerAdministrationClient client, PersonalizerServiceProperties properties)
        {
            PersonalizerServiceProperties result = await client.GetPersonalizerPropertiesAsync();
            Assert.AreEqual(properties.DefaultReward, result.DefaultReward);
            Assert.True(Math.Abs(properties.ExplorationPercentage - result.ExplorationPercentage) < 1e-3);
            Assert.AreEqual(properties.ModelExportFrequency, result.ModelExportFrequency);
            Assert.AreEqual(properties.RewardAggregation, result.RewardAggregation);
            Assert.AreEqual(properties.RewardWaitTime, result.RewardWaitTime);
        }

        private async Task UpdateProperties(PersonalizerAdministrationClient client, PersonalizerServiceProperties properties)
        {
            PersonalizerServiceProperties result = await client.UpdatePersonalizerPropertiesAsync(properties);
            Assert.AreEqual(properties.DefaultReward, result.DefaultReward);
            Assert.True(Math.Abs(properties.ExplorationPercentage - result.ExplorationPercentage) < 1e-3);
            Assert.AreEqual(properties.ModelExportFrequency, result.ModelExportFrequency);
            Assert.AreEqual(properties.RewardAggregation, result.RewardAggregation);
            Assert.AreEqual(properties.RewardWaitTime, result.RewardWaitTime);
            await Delay(60000);
        }

        private async Task UpdateAndGetPolicy(PersonalizerAdministrationClient client)
        {
            var newPolicy = new PersonalizerPolicy(
                name: "app1",
                arguments: "--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2"
            );
            PersonalizerPolicy updatedPolicy = await client.UpdatePersonalizerPolicyAsync(newPolicy);
            Assert.NotNull(updatedPolicy);
            Assert.AreEqual(newPolicy.Arguments, updatedPolicy.Arguments);
            await Delay(30000);
            PersonalizerPolicy policy = await client.GetPersonalizerPolicyAsync();
            // Only checking the first 190 chars because the epsilon has a float rounding addition when applied
            Assert.AreEqual(newPolicy.Arguments, policy.Arguments.Substring(0,190));
        }

        private async Task ResetPolicy(PersonalizerAdministrationClient client)
        {
            PersonalizerPolicy policy = await client.ResetPersonalizerPolicyAsync();
            Assert.AreEqual("--cb_explore_adf --epsilon 0.2 --power_t 0 -l 0.001 --cb_type mtr -q ::",
            policy.Arguments);
        }
    }
}
