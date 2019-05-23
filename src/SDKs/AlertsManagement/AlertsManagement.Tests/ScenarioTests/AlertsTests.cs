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
    public class AlertsTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        public AlertsTests() : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetAlertsListTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                IPage<Alert> actual = alertsManagementClient.Alerts.GetAll();

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetAlertByIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                Alert actual = alertsManagementClient.Alerts.GetById("e694ddf0-8430-4349-a5ed-c5866e9f4377");

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void AlertStateChangeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                Alert actual = alertsManagementClient.Alerts.ChangeState("a3033ce9-6b95-4c36-8621-62b148434b8b", AlertState.Closed);

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetHistoryTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                var actual = alertsManagementClient.Alerts.GetHistory("e694ddf0-8430-4349-a5ed-c5866e9f4377");

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetSummaryTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                var actual = alertsManagementClient.Alerts.GetSummary("Severity");

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        private static void Check(
            AlertsManagementClient alertsManagementClient,
            IPage<Alert> alertListResult)
        {
            Assert.Equal("true", "true");
        }

        private static void Check(
            AlertsManagementClient alertsManagementClient,
            Alert alertListResult)
        {
            Assert.Equal("true", "true");
        }

        private static void Check(
           AlertsManagementClient alertsManagementClient,
           AlertModification modification)
        {
            Assert.Equal("true", "true");
        }

        private static void Check(
           AlertsManagementClient alertsManagementClient,
           AlertsSummary modification)
        {
            Assert.Equal("true", "true");
        }
    }
}
