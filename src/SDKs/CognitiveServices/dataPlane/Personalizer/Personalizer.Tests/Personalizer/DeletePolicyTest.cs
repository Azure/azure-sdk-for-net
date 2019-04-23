using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class GetPolicyTest : BaseTests
    {
        [Fact]
        public async Task GetPolicy()
        {
            using (MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "GetPolicy");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                PolicyContract policy = await client.GetPolicyAsync();

                Assert.Equal("app1", policy.Name);
                Assert.Equal("--cb_explore_adf --quadratic GT --quadratic MR --quadratic GR --quadratic ME --quadratic OT --quadratic OE --quadratic OR --quadratic MS --quadratic GX --ignore A --cb_type ips --epsilon 0.2",
                policy.Arguments);
                
            }
        }
    }
}
