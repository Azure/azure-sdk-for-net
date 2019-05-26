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
        public void AlertStateChangeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                string alertId = "a2c9dbe6-9e60-43b7-b88a-47558a325dc3";

                // Get alert by ID
                Alert actualAlert = alertsManagementClient.Alerts.GetById(alertId);

                if (!this.IsRecording)
                {
                    Assert.Equal(AlertState.New, actualAlert.Properties.Essentials.AlertState);
                }

                // Perform state change operation
                string updatedState = AlertState.Closed;
                Alert alertPostStateChange = alertsManagementClient.Alerts.ChangeState(alertId, updatedState);

                // Verify the state change operation was successful
                if (!this.IsRecording)
                {
                    Assert.Equal(updatedState, alertPostStateChange.Properties.Essentials.AlertState);
                }

                // Get History of alerts
                var alertHistory = alertsManagementClient.Alerts.GetHistory(alertId);

                // Check if the history contains the state update event
                if (!this.IsRecording)
                {
                    CheckHistoryContainsStateChangeEvent(alertHistory);
                }

                // Fetch all alerts
                IPage<Alert> allAlerts = alertsManagementClient.Alerts.GetAll();

                // Verify that all alerts contain the updated alert instance
                if (!this.IsRecording)
                {
                    CheckAllAlertsContainsUpdatedAlertObject(allAlerts, alertPostStateChange);
                }
            }
        }

        private void CheckAllAlertsContainsUpdatedAlertObject(IPage<Alert> allAlerts, Alert alertPostStateChange)
        {
            bool alertFound = false;

            var enumerator = allAlerts.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Alert current = enumerator.Current;
                if (current.Properties.Essentials.SourceCreatedId == alertPostStateChange.Properties.Essentials.SourceCreatedId)
                {
                    alertFound = true;
                    ComparisonUtility.AreEqual(alertPostStateChange, current);
                    break;
                }
            }

            if (!alertFound)
            {
                throw new Exception("Test Failed : Alert not found in list of alerts.");
            }
        }

        private void CheckHistoryContainsStateChangeEvent(AlertModification alertHistory)
        {
            bool eventFound = false;

            IList<AlertModificationItem> modifications = alertHistory.Properties.Modifications;
            foreach (var item in modifications)
            {
                if (item.ModificationEvent == AlertModificationEvent.StateChange)
                {
                    Assert.Equal(AlertState.New, item.OldValue);
                    Assert.Equal(AlertState.Closed, item.NewValue);
                    eventFound = true;
                    break;
                }
            }

            if (!eventFound)
            {
                throw new Exception("Test Failed : State update event not found in alert history.");
            }
        }
    }
}
