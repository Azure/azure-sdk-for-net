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
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            PersonalizerServiceProperties  defaultConfig = await client.GetPersonalizerPropertiesAsync();
            Assert.AreEqual(TimeSpan.FromMinutes(1), defaultConfig.RewardWaitTime);
            Assert.AreEqual(TimeSpan.FromHours(1), defaultConfig.ModelExportFrequency);
            Assert.AreEqual(1, defaultConfig.DefaultReward);
            Assert.AreEqual(0.2, defaultConfig.ExplorationPercentage, 0.00000001);
            Assert.AreEqual(0, defaultConfig.LogRetentionDays);
        }

        [Test]
        public async Task ApplyFromEvaluation()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            PersonalizerPolicyReferenceOptions policyReferenceContract = new PersonalizerPolicyReferenceOptions("628a6299-ce45-4a9d-98a6-017c2c9ff008", "Inter-len1");
            await client.ApplyPersonalizerEvaluationAsync(policyReferenceContract);
        }

        [Test]
        public async Task UpdateServiceConfiguration()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            TimeSpan newExperimentalUnitDuration = TimeSpan.FromMinutes(1);
            TimeSpan modelExportFrequency = TimeSpan.FromHours(1);
            double newDefaultReward = 1.0;
            string newRewardFuntion = "average";
            double newExplorationPercentage = 0.2f;
            var config = new PersonalizerServiceProperties (
                rewardAggregation: newRewardFuntion,
                modelExportFrequency: modelExportFrequency,
                defaultReward: (float)newDefaultReward,
                rewardWaitTime: newExperimentalUnitDuration,
                explorationPercentage: (float)newExplorationPercentage,
                logRetentionDays: int.MaxValue
            );
            PersonalizerServiceProperties  result = await client.UpdatePersonalizerConfigurationAsync(config);
            Assert.AreEqual(config.DefaultReward, result.DefaultReward);
            Assert.True(Math.Abs(config.ExplorationPercentage - result.ExplorationPercentage) < 1e-3);
            Assert.AreEqual(config.ModelExportFrequency, result.ModelExportFrequency);
            Assert.AreEqual(config.RewardAggregation, result.RewardAggregation);
            Assert.AreEqual(config.RewardWaitTime, result.RewardWaitTime);
        }

        [Test]
        public async Task GetPolicy()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            PersonalizerPolicy policy = await client.GetPersonalizerPolicyAsync();
            Assert.AreEqual("app1", policy.Name);
            Assert.AreEqual("--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2",
            policy.Arguments);
        }

        [Test]
        public async Task UpdatePolicy()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            var policy = new PersonalizerPolicy(
                name: "app1",
                arguments: "--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2"
            );
            PersonalizerPolicy updatedPolicy = await client.UpdatePersonalizerPolicyAsync(policy);
            Assert.NotNull(updatedPolicy);
            Assert.AreEqual(policy.Arguments, updatedPolicy.Arguments);
        }

        [Test]
        public async Task ResetPolicy()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            PersonalizerPolicy policy = await client.ResetPersonalizerPolicyAsync();
            Assert.AreEqual("--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2",
            policy.Arguments);
        }
    }
}
