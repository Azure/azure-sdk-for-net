using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using Azure.AI.Personalizer;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public class ConfigurationsTests : BaseTests
    {
        [Fact]
        public async Task GetServiceConfiguration()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetServiceConfiguration");
                ServiceConfigurationRestClient client = GetServiceConfigurationClient(HttpMockServer.CreateInstance());
                ServiceConfiguration defaultConfig = await client.GetAsync();
                Assert.Equal(TimeSpan.FromMinutes(1), defaultConfig.RewardWaitTime);
                Assert.Equal(TimeSpan.FromHours(1), defaultConfig.ModelExportFrequency);
                Assert.Equal(1, defaultConfig.DefaultReward);
                Assert.Equal(0.2, defaultConfig.ExplorationPercentage);
                Assert.Equal(0, defaultConfig.LogRetentionDays);
            }
        }

        [Fact]
        public async Task UpdateServiceConfiguration()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "UpdateServiceConfiguration");
                ServiceConfigurationRestClient client = GetServiceConfigurationClient(HttpMockServer.CreateInstance());
                TimeSpan newExperimentalUnitDuration = TimeSpan.FromMinutes(1);
                TimeSpan modelExportFrequency = TimeSpan.FromHours(1);
                double newDefaultReward = 1.0;
                string newRewardFuntion = "average";
                double newExplorationPercentage = 0.2f;
                var config = new ServiceConfiguration(
                    rewardAggregation: newRewardFuntion,
                    modelExportFrequency: modelExportFrequency,
                    defaultReward: (float)newDefaultReward,
                    rewardWaitTime: newExperimentalUnitDuration,
                    explorationPercentage: (float)newExplorationPercentage,
                    logRetentionDays: int.MaxValue
                );
                ServiceConfiguration result = await client.UpdateAsync(config);
                Assert.Equal(config.DefaultReward, result.DefaultReward);
                Assert.True(Math.Abs(config.ExplorationPercentage - result.ExplorationPercentage) < 1e-3);
                Assert.Equal(config.ModelExportFrequency, result.ModelExportFrequency);
                Assert.Equal(config.RewardAggregation, result.RewardAggregation);
                Assert.Equal(config.RewardWaitTime, result.RewardWaitTime);
            }
        }

        [Fact]
        public async Task GetPolicy()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetPolicy");
                PolicyRestClient client = GetPolicyClient(HttpMockServer.CreateInstance());
                PolicyContract policy = await client.GetAsync();
                Assert.Equal("app1", policy.Name);
                Assert.Equal("--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2",
                policy.Arguments);
            }
        }

        [Fact]
        public async Task UpdatePolicy()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "UpdatePolicy");
                PolicyRestClient client = GetPolicyClient(HttpMockServer.CreateInstance());
                var policy = new PolicyContract(
                    name: "app1",
                    arguments: "--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2"
                );
                PolicyContract updatedPolicy = await client.UpdateAsync(policy);
                Assert.NotNull(updatedPolicy);
                Assert.Equal(policy.Arguments, updatedPolicy.Arguments);
            }
        }

        [Fact]
        public async Task ResetPolicy()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ResetPolicy");
                PolicyRestClient client = GetPolicyClient(HttpMockServer.CreateInstance());
                PolicyContract policy = await client.ResetAsync();
                Assert.Equal("--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2",
                policy.Arguments);
            }
        }
    }
}
