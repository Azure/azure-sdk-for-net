using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using Azure.AI.Personalizer;
using NUnit.Framework;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public class RewardTest : PersonalizerTestBase
    {
        public RewardTest(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Reward()
        {
            PersonalizerClient client = GetPersonalizerClient();
            await client.Events.RewardAsync("123456789", new RewardRequest((float)0.5));
        }
    }
}
