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
            Client.Jobs.Get(TestConstants.GatewayResourceName, "job1", TestConstants.DefaultResourceGroupName);
        }
        #endregion Test Methods
    }
}
