using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the tests for Sku API
    /// </summary>
    public class SkuTests : DataBoxEdgeTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to test share APIs
        /// </summary>
        public SkuTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor
    }
}
