// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using WorkloadMonitor.Tests.Helpers;
using Microsoft.Azure.Management.WorkloadMonitor;
using Microsoft.Azure.Management.WorkloadMonitor.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;

namespace WorkloadMonitor.Tests.ScenarioTests
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
                var workloadMonitorClient = GetWorkloadMonitorAPIClient(context, handler);
                IPage<Operation> actual = workloadMonitorClient.Operations.List();

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
                "Microsoft.WorkloadMonitor/operations/read",
                "Microsoft.WorkloadMonitor/monitors/read",
                "Microsoft.WorkloadMonitor/monitors/history/read",
                "Microsoft.WorkloadMonitor/register/action",
                "Microsoft.WorkloadMonitor/unregister/action"
            };

            string expectedProvider = "Microsoft.WorkloadMonitor";

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
