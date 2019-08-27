// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StreamAnalytics.Tests
{
    public class OperationTests : TestBase
    {
        [Fact]
        public void OperationTest_List()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                // Get operations for Stream Analytics resource provider
                var operationListResult = streamAnalyticsManagementClient.Operations.List();

                // Verify operations are returned
                Assert.NotNull(operationListResult);
                Assert.True(operationListResult.Count() > 0);
            }
        }
    }
}
