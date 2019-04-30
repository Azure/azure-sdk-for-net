using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class ConfigurationsTests : BaseTests
    {
        [Fact]
        public async Task GetServiceConfiguration()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetServiceConfiguration");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                ServiceConfiguration defaultConfig = await client.ServiceConfiguration.GetAsync();
                Assert.Equal("00:01:00", defaultConfig.RewardWaitTime);
                Assert.Equal("01:00:00", defaultConfig.ModelExportFrequency);
                Assert.Equal(0D, defaultConfig.DefaultReward);
                Assert.Equal(0.2, defaultConfig.ExplorationPercentage);
                Assert.Equal(0, defaultConfig.LogRetentionDays);
            }
        }

        [Fact]
        public async Task UpdateServiceConfiguration()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "UpdateServiceConfiguration");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                TimeSpan newExperimentalUnitDuration = TimeSpan.FromMinutes(1);
                TimeSpan modelExportFrequency = TimeSpan.FromHours(1);
                double newDefaultReward = 1.0;
                string newRewardFuntion = "average";
                double newExplorationPercentage = 0.2f;


                var config = new ServiceConfiguration
                {
                    RewardAggregation = newRewardFuntion,
                    ModelExportFrequency = modelExportFrequency.ToString(),
                    DefaultReward = newDefaultReward,
                    RewardWaitTime = newExperimentalUnitDuration.ToString(),
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
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetPolicy");

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
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "UpdatePolicy");

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
        public async Task DeletePolicy()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DeletePolicy");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                PolicyContract policy = await client.Policy.DeleteAsync();

                Assert.Equal("--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2",
                policy.Arguments);

            }
        }
    }
}
