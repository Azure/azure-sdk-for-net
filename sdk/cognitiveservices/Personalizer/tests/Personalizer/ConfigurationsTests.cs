using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class ConfigurationsTests : BaseTests
    {
        [Fact]
        public async Task GetServiceConfiguration()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetServiceConfiguration");
                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());
                ServiceConfiguration defaultConfig = await client.ServiceConfiguration.GetAsync();
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
                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());
                TimeSpan newExperimentalUnitDuration = TimeSpan.FromMinutes(1);
                TimeSpan modelExportFrequency = TimeSpan.FromHours(1);
                double newDefaultReward = 1.0;
                string newRewardFuntion = "average";
                double newExplorationPercentage = 0.2f;
                var config = new ServiceConfiguration
                {
                    RewardAggregation = newRewardFuntion,
                    ModelExportFrequency = modelExportFrequency,
                    DefaultReward = newDefaultReward,
                    RewardWaitTime = newExperimentalUnitDuration,
                    ExplorationPercentage = newExplorationPercentage
                };
                ServiceConfiguration result = await client.ServiceConfiguration.UpdateAsync(config);
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
                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());
                PolicyContract policy = await client.Policy.GetAsync();
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
                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());
                var policy = new PolicyContract
                {
                    Name = "app1",
                    Arguments = "--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2"
                };
                var updatedPolicy = await client.Policy.UpdateAsync(policy);
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
                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());
                PolicyContract policy = await client.Policy.ResetAsync();
                Assert.Equal("--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2",
                policy.Arguments);
            }
        }
    }
}
