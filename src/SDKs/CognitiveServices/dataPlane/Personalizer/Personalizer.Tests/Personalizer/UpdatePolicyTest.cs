using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class UpdatePolicyTest : BaseTests
    {
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

                var updatedPolicy = await client.UpdatePolicyAsync(policy);

                Assert.NotNull(updatedPolicy);
                Assert.Equal(policy.Arguments, updatedPolicy.Arguments);

            }
        }
    }
}
