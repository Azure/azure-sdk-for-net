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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                IPage<Operation> actual = alertsManagementClient.Operations.List();

                if (!this.IsRecording)
                {
                    CheckListedOperations(actual);
                }
            }
        }

        private static void CheckListedOperations(IPage<Operation> operationListResult)
        {
            List<String> supportedOperations = new List<String>
            {
                "Microsoft.AlertsManagement/register/action",
                "Microsoft.AlertsManagement/alerts/read",
                "Microsoft.AlertsManagement/alertsList/read",
                "Microsoft.AlertsManagement/alerts/changestate/action",
                "Microsoft.AlertsManagement/alerts/history/read",
                "Microsoft.AlertsManagement/alertsSummary/read",
                "Microsoft.AlertsManagement/alertsSummaryList/read",
                "Microsoft.AlertsManagement/smartGroups/read",
                "Microsoft.AlertsManagement/smartGroups/changestate/action",
                "Microsoft.AlertsManagement/smartGroups/history/read",
                "Microsoft.AlertsManagement/smartGroups/read",
                "Microsoft.AlertsManagement/alerts/diagnostics/read",
                "Microsoft.AlertsManagement/smartDetectorAlertRules/write",
                "Microsoft.AlertsManagement/smartDetectorAlertRules/read",
                "Microsoft.AlertsManagement/smartDetectorAlertRules/delete",
                "Microsoft.AlertsManagement/actionRules/read",
                "Microsoft.AlertsManagement/actionRules/write",
                "Microsoft.AlertsManagement/actionRules/delete",
                "Microsoft.AlertsManagement/Operations/read"
            };

            string expectedProvider = "Microsoft.AlertsManagement";

            var enumerator = operationListResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Operation current = enumerator.Current;
                Assert.Contains(current.Name, supportedOperations);
                Assert.Equal(expectedProvider, current.Display.Provider);
            }
        }
    }
}
