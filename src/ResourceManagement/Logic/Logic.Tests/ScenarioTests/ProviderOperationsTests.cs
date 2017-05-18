// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;

    /// <summary>
    /// Scenario tests for the provider operations.
    /// </summary>
    [Collection("ProviderOperationsTests")]
    public class ProviderOperationsTests : ScenarioTestsBase
    {
        /// <summary>
        /// Tests the get operation of provider.
        /// </summary>
        [Fact]
        public void GetProviderOperations()
        {
            using (
                MockContext context = MockContext.Start(className: this.testClassName))
            {
                var client = context.GetServiceClient<LogicManagementClient>();
                var operationList = client.ListOperations();
                Assert.True(operationList.Count() > 0);
            }
        }
    }
}