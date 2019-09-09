using Microsoft.Azure.Management.EdgeGateway;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for jobs APIs
    /// </summary>
    public class JobsTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to test jobs API
        /// </summary>
        public JobsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Test job get API
        /// </summary>
        [Fact]
        public void Test_Jobs()
        {
            // Get a job by name
            Client.Jobs.Get(TestConstants.GatewayResourceName, "d27da901-5e8c-4e53-880a-e6f6fd4af560", TestConstants.DefaultResourceGroupName);
        }
        #endregion Test Methods
    }
}

