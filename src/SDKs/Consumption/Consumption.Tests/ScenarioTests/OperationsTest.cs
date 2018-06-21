// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Consumption.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using System.Reflection;

namespace Consumption.Tests.ScenarioTests
{
    /// <summary>
    /// 
    /// </summary>
    public class OperationsTests : TestBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ListOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create client
                var billingMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get operations
                var operations = billingMgmtClient.Operations.List();

                // Verify operations are returned
                Assert.NotNull(operations);
                Assert.True(operations.Any());
            }
        }
    }
}
