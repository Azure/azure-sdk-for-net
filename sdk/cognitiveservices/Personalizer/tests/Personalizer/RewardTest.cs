using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class RewardTest : BaseTests
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6213")]
        public async Task Reward()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "Reward");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                await client.RewardAsync("123456789", new RewardRequest(0.5));
            }
        }
    }
}
