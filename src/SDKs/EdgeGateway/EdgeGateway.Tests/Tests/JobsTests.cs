using Microsoft.Azure.Management.EdgeGateway;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    public class JobsTests : EdgeGatewayTestBase
    {
        #region Constructor
        public JobsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods
        [Fact]
        public void Test_Jobs()
        {
            // Get a job by name
            Client.Jobs.Get(TestConstants.GatewayResourceName, "d27da901-5e8c-4e53-880a-e6f6fd4af560", TestConstants.DefaultResourceGroupName);
        }
        #endregion Test Methods
    }
}
