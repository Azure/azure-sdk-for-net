namespace StorSimple1200Series.Tests
{
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using System;

    /// <summary>
    /// Class represents Operations
    /// </summary>
    public class OperationTests : StorSimpleTestBase
    {
        #region Constructor

        public OperationTests(ITestOutputHelper testOutputHelper) :
            base(testOutputHelper)
        { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Test method to enumerate all service operations
        /// </summary>
        [Fact]
        public void TestGetOperationsAPI()
        {
            try
            {
                var operations = this.Client.AvailableProviderOperations.List();
                Assert.True(
                    operations != null && operations.Any(),
                    "List call for Operations was not successful.");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Test Methods
    }
}
