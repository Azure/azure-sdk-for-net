// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;
using Azure.ResourceManager.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.AlertsManagement.Tests.Scenario
{
    [TestFixture]
    public class AlertsTests : AlertsManagementManagementTestBase
    {
        public AlertsTests() : base(true)
        {
        }

        [TestCase]
        public async Task AlertStateChangeTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ServiceAlertResource alertWithStateNew = null;
            AsyncPageable<ServiceAlertResource> alertsWithStateNew = subscription.GetServiceAlerts().GetAllAsync(alertState: new ServiceAlertState("New"));
            await foreach (ServiceAlertResource alert in alertsWithStateNew)
            {
                Console.WriteLine(alert.Data.Name);
                // Perform state change operation
                var alertPostStateChange = await alert.ChangeStateAsync(new ServiceAlertState("Closed"));

                // Verify the state change operation was successful
                var alertPostStateChangeContent = alertPostStateChange.GetRawResponse().Content;
                string arraystring = alertPostStateChangeContent.ToString();
                var alertchange = JsonConvert.DeserializeObject<JObject>(arraystring);
                string state = alertchange["properties"]["essentials"]["alertState"].ToString();
                Assert.That(state, Is.EqualTo("Closed"));

                alertWithStateNew = alert;
                break;
            }

            // Get History of alerts
            Response<ServiceAlertModification> history = await alertWithStateNew.GetHistoryAsync();
            CheckHistoryContainsStateChangeEvent(history);
        }

        [TestCase]
        public async Task FilterByParametersGetAlertsTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            // Get alerts filtered
            ServiceAlertSeverity severityFilter = ServiceAlertSeverity.Sev3;
            MonitorServiceSourceForAlert monitorServiceFilter = MonitorServiceSourceForAlert.LogAnalytics;
            AsyncPageable<ServiceAlertResource> alerts = subscription.GetServiceAlerts().GetAllAsync(alertState: new ServiceAlertState("New"), monitorService: monitorServiceFilter, severity: severityFilter);
            await foreach (ServiceAlertResource alert in alerts)
            {
                Assert.Multiple(() =>
                {
                    // Verify the state change operation was successful
                    Assert.That(monitorServiceFilter, Is.EqualTo(alert.Data.Properties.Essentials.MonitorService));
                    Assert.That(severityFilter, Is.EqualTo(alert.Data.Properties.Essentials.Severity));
                    Assert.That(alert.Data.Properties.Essentials.AlertState.ToString(), Is.EqualTo("New"));
                });
            }
        }

        [TestCase]
        public async Task AlertsSummaryTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            // Get alerts summary grouped by severity and state
            string groupBy = "severity,alertState";
            var summary = await subscription.GetServiceAlertSummaryAsync(groupBy);
            Assert.Multiple(() =>
            {
                //summary.GetRawResponse().Content
                Assert.That(summary.Value.Properties.Total, Is.Not.Null);
                Assert.That(summary.Value.Properties.GroupedBy, Is.EqualTo("severity"));
            });
            IEnumerator<ServiceAlertSummaryGroupItemInfo> enumerator = summary.Value.Properties.Values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ServiceAlertSummaryGroupItemInfo current = enumerator.Current;
                IsValidSeverity(current.Name);
                Assert.That(current.Count, Is.Not.Null);
                Assert.That(current.GroupedBy, Is.EqualTo("alertState"));
                IEnumerator<ServiceAlertSummaryGroupItemInfo> stateEnumerator = current.Values.GetEnumerator();
                while (stateEnumerator.MoveNext())
                {
                    ServiceAlertSummaryGroupItemInfo currentstate = stateEnumerator.Current;
                    IsValidAlertState(currentstate.Name);
                    Assert.That(currentstate.Count, Is.Not.Null);
                }
            }
        }

        private void CheckHistoryContainsStateChangeEvent(Response<ServiceAlertModification> alertHistory)
        {
            bool eventFound = false;

            IList<ServiceAlertModificationItemInfo> modifications = alertHistory.Value.Properties.Modifications;
            foreach (var item in modifications)
            {
                if (item.ModificationEvent == ServiceAlertModificationEvent.StateChange)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(item.OldValue, Is.EqualTo(ServiceAlertState.New.ToString()));
                        Assert.That(item.NewValue, Is.EqualTo(ServiceAlertState.Closed.ToString()));
                    });
                    eventFound = true;
                    break;
                }
            }

            if (!eventFound)
            {
                throw new Exception("Test Failed : State update event not found in alert history.");
            }
        }

        private void IsValidAlertState(string name)
        {
            List<string> validStates = new List<string>
            {
                ServiceAlertState.New.ToString(),
                ServiceAlertState.Acknowledged.ToString(),
                ServiceAlertState.Closed.ToString()
            };

            Assert.That(validStates, Does.Contain(name));
        }

        private void IsValidSeverity(string name)
        {
            List<string> validSeverity = new List<string>
            {
                ServiceAlertSeverity.Sev0.ToString(),
                ServiceAlertSeverity.Sev1.ToString(),
                ServiceAlertSeverity.Sev2.ToString(),
                ServiceAlertSeverity.Sev3.ToString(),
                ServiceAlertSeverity.Sev4.ToString()
            };

            Assert.That(validSeverity, Does.Contain(name));
        }
    }
}
