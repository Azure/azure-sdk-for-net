// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AlertsManagement.Tests.Helpers;
using Microsoft.Azure.Management.AlertsManagement;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Xunit;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlertsManagement.Tests.UnitTests
{
    public class AlertsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void GetAlertsListTest()
        {
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.Alerts.GetAll();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetAlertByIdTest()
        {
            string alertID = "249a7944-dabc-4c80-8025-61165619d78f";
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.Alerts.GetById(alertID);

            Assert.NotNull(result);
            Assert.Equal(alertID, result.Id);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void AlertStateChangeTest()
        {
            string alertID = "249a7944-dabc-4c80-8025-61165619d78f";
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);

            string updatedState = AlertState.Closed;
            var result = alertsManagementClient.Alerts.ChangeState(alertID, updatedState);

            Assert.Equal(alertID, result.Id);
            Assert.Equal(updatedState, result.Properties.Essentials.AlertState);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetAlertHistoryTest()
        {
            string alertID = "249a7944-dabc-4c80-8025-61165619d78f";
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var result = alertsManagementClient.Alerts.GetHistory(alertID);

            Assert.Equal(alertID, result.Properties.AlertId);
            Assert.Equal(2, result.Properties.Modifications.Count);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetAlertsSummaryTest()
        {
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.Alerts.GetSummary("Severity");
            Assert.Equal(2, result.Properties.Values.Count);
        }
    }
}
