using System;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class GetServiceConfigurationTest : BaseTests
    {
        [Fact]
        public async Task GetServiceConfiguration()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetServiceConfiguration");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                ServiceConfiguration defaultConfig = await client.GetServiceConfigurationAsync();
                Assert.Equal("00:01:00", defaultConfig.RewardWaitTime);
                Assert.Equal("01:00:00", defaultConfig.ModelExportFrequency);
                Assert.Equal(0D, defaultConfig.DefaultReward);
                Assert.Equal(0.2, defaultConfig.ExplorationPercentage);
                Assert.Equal(0, defaultConfig.LogRetentionDays);
            }
        }
    }
}
