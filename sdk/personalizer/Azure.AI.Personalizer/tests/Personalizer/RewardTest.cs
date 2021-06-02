using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using Xunit;
using Azure.AI.Personalizer;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public class RewardTest : BaseTests
    {
        [Fact]
        public async Task Reward()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "Reward");
                EventsRestClient client = GetEventsClient(HttpMockServer.CreateInstance());
                await client.RewardAsync("123456789", new RewardRequest((float)0.5));
            }
        }
    }
}
