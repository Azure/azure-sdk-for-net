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

                string alertId = "63d67c2c-7a2e-4da1-bb90-da475144ac62";

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
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void FilterByParametersGetAlertsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                // Get alerts filtered for particular target resource
                string targetResource = "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourcegroups/alertslab/providers/microsoft.apimanagement/service/aig-test";
                string severity = Severity.Sev3;
                string monitorService = MonitorService.Platform;
                IPage<Alert> alerts = alertsManagementClient.Alerts.GetAll(targetResource: targetResource, severity: severity, monitorService: monitorService);

                if (!this.IsRecording)
                {
                    IEnumerator<Alert> enumerator = alerts.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Alert current = enumerator.Current;
                        Assert.Equal(targetResource, current.Properties.Essentials.TargetResource);
                        Assert.Equal(monitorService, current.Properties.Essentials.MonitorService);
                        Assert.Equal(severity, current.Properties.Essentials.Severity);
                    }
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
