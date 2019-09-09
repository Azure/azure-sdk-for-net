// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    public class OperationsTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        public OperationsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var insightsClient = GetMonitorManagementClient(context, handler);

                OperationListResult actual = insightsClient.Operations.List();

                if (!this.IsRecording)
                {
                    Check(insightsClient, actual);
                }
            }
        }

        private static void Check(
            MonitorManagementClient insightsClient, 
            OperationListResult operationListResult)
        {
            Assert.Equal(46, operationListResult.Value.Count);
            Assert.Equal("Microsoft.Insights/Operations/Read", operationListResult.Value[0].Name);
            Assert.Equal("Operations read", operationListResult.Value[0].Display.Operation);
            Assert.Equal("Microsoft Monitoring Insights", operationListResult.Value[0].Display.Provider);
            Assert.Equal("Operations", operationListResult.Value[0].Display.Resource);

            Assert.Equal("Microsoft.Insights/Webtests/Read", operationListResult.Value[45].Name);
            Assert.Equal("Webtest read", operationListResult.Value[45].Display.Operation);
            Assert.Equal("Microsoft Monitoring Insights", operationListResult.Value[45].Display.Provider);
            Assert.Equal("Web tests", operationListResult.Value[45].Display.Resource);
        }
    }
}
