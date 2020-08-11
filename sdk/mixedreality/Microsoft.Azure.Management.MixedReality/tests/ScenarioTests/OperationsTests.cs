using Microsoft.Azure.Management.MixedReality.Models;
using System.Collections.Generic;
using Xunit;

namespace MixedReality.Tests
{
    public sealed class OperationsTests : MixedRealityTests
    {
        [Fact]
        [Trait("Name", "TestListMixedRealityOperations")]
        public void TestListMixedRealityOperations()
        {
            using (var context = StartTest())
            {
                var response = Client.Operations.ListWithHttpMessagesAsync().Result;

                var operations = response?.Body as IEnumerable<Operation>;

                Assert.NotNull(operations);
                Assert.NotEmpty(operations);
            }
        }
    }
}

