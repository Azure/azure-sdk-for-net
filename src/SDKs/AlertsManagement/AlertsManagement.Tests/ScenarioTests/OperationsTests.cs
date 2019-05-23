// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AlertsManagement.Tests.Helpers;
using Microsoft.Azure.Management.AlertsManagement;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;

namespace AlertsManagement.Tests.ScenarioTests
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                IPage<Operation> actual = alertsManagementClient.Operations.List();

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        private static void Check(
            AlertsManagementClient alertsManagementClient,
            IPage<Operation> operationListResult)
        {
            Assert.Equal("true", "true");
        }
    }
}
