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
            Assert.That(result.DefaultReward, Is.EqualTo(properties.DefaultReward));
            Assert.That(Math.Abs(properties.ExplorationPercentage - result.ExplorationPercentage) < 1e-3, Is.True);
            Assert.That(result.ModelExportFrequency, Is.EqualTo(properties.ModelExportFrequency));
            Assert.That(result.RewardAggregation, Is.EqualTo(properties.RewardAggregation));
            Assert.That(result.RewardWaitTime, Is.EqualTo(properties.RewardWaitTime));
        }

        private async Task UpdateProperties(PersonalizerAdministrationClient client, PersonalizerServiceProperties properties)
        {
            PersonalizerServiceProperties result = await client.UpdatePersonalizerPropertiesAsync(properties);
            Assert.That(result.DefaultReward, Is.EqualTo(properties.DefaultReward));
            Assert.That(Math.Abs(properties.ExplorationPercentage - result.ExplorationPercentage) < 1e-3, Is.True);
            Assert.That(result.ModelExportFrequency, Is.EqualTo(properties.ModelExportFrequency));
            Assert.That(result.RewardAggregation, Is.EqualTo(properties.RewardAggregation));
            Assert.That(result.RewardWaitTime, Is.EqualTo(properties.RewardWaitTime));
            await Delay(60000);
        }

        private async Task UpdateAndGetPolicy(PersonalizerAdministrationClient client)
        {
            var newPolicy = new PersonalizerPolicy(
                name: "app1",
                arguments: "--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2"
            );
            PersonalizerPolicy updatedPolicy = await client.UpdatePersonalizerPolicyAsync(newPolicy);
            Assert.That(updatedPolicy, Is.Not.Null);
            Assert.That(updatedPolicy.Arguments, Is.EqualTo(newPolicy.Arguments));
            await Delay(30000);
            PersonalizerPolicy policy = await client.GetPersonalizerPolicyAsync();
            // Only checking the first 190 chars because the epsilon has a float rounding addition when applied
            Assert.That(policy.Arguments.Substring(0, 190), Is.EqualTo(newPolicy.Arguments));
        }

        private async Task ResetPolicy(PersonalizerAdministrationClient client)
        {
            PersonalizerPolicy policy = await client.ResetPersonalizerPolicyAsync();
            Assert.That(policy.Arguments,
            Is.EqualTo("--cb_explore_adf --epsilon 0.2 --power_t 0 -l 0.001 --cb_type mtr -q ::"));
        }
    }
}
