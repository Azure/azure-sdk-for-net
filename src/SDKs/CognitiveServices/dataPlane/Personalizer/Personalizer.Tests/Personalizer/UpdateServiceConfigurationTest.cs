using System;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class UpdateServiceConfigurationTest : BaseTests
    {

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


                ServiceConfiguration result = await client.UpdateServiceConfigurationAsync(config);

                Assert.Equal(config.DefaultReward, result.DefaultReward);
                Assert.True(Math.Abs(config.ExplorationPercentage - result.ExplorationPercentage) < 1e-3);
                Assert.Equal(config.ModelExportFrequency, result.ModelExportFrequency);
                Assert.Equal(config.RewardAggregation, result.RewardAggregation);
                Assert.Equal(config.RewardWaitTime, result.RewardWaitTime);
            }
        }
    }
}
