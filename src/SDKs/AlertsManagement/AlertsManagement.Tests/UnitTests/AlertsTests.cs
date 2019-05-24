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
            List<Alert> alertsList = GetAlerts();
            Page<Alert> expectedParameters = new Page<Alert>();
            expectedParameters.Items = alertsList;

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.Alerts.GetAll();

            ComparisonUtility.AreEqual(alertsList, result.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetAlertByIdTest()
        {
            string alertId = "249a7944-dabc-4c80-8025-61165619d78f";
            Alert expectedParameters = GetAlertById(alertId);

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);
            
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.Alerts.GetById(alertId);

            ComparisonUtility.AreEqual(expectedParameters, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void AlertStateChangeTest()
        {
            string alertID = "249a7944-dabc-4c80-8025-61165619d78f";
            Alert expectedParameters = CreateAlert(alertID);

            string updatedState = AlertState.Acknowledged;
            expectedParameters.Properties.Essentials.AlertState = updatedState;

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);
            
            var result = alertsManagementClient.Alerts.ChangeState(alertID, updatedState);

            ComparisonUtility.AreEqual(expectedParameters, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetAlertHistoryTest()
        {
            string alertID = "249a7944-dabc-4c80-8025-61165619d78f";
            List<AlertModificationItem> modificationitems = new List<AlertModificationItem>
            {
                new AlertModificationItem(AlertModificationEvent.AlertCreated),
                new AlertModificationItem(AlertModificationEvent.StateChange, AlertState.New, AlertState.Closed)
            };

            AlertModification expectedParameters = new AlertModification(properties: new AlertModificationProperties(alertID, modificationitems));

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.Alerts.GetHistory(alertID);

            ComparisonUtility.AreEqual(expectedParameters.Properties.Modifications, result.Properties.Modifications);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetAlertsSummaryTest()
        {
            AlertsSummaryGroup group = GetTestSummaryGroup();
            
            AlertsSummary expectedParameters = new AlertsSummary(properties: group);

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);
            var result = alertsManagementClient.Alerts.GetSummary("Severity");

            ComparisonUtility.AreEqual(expectedParameters.Properties, result.Properties);
        }

        private List<Alert> GetAlerts()
        {
            return new List<Alert>
            {
                CreateAlert(Guid.NewGuid().ToString(), "Alert Name 1"),
                CreateAlert(Guid.NewGuid().ToString(), "Alert Name 2"),
                CreateAlert(Guid.NewGuid().ToString(), "Alert Name 3")
            };
        }

        private Alert GetAlertById(string id)
        {
            return CreateAlert(id);
        }

        private Alert CreateAlert(string id = "Alert ID", string name = "Alert Name")
        {
            Dictionary<string, string> keyValuePair = new Dictionary<string, string>
            {
                {"key1", "value1"},
                {"key2", "value2"}
            };

            Essentials essentials = new Essentials(
                severity: Severity.Sev2,
                signalType: SignalType.Metric,
                alertState: AlertState.New,
                monitorCondition: MonitorCondition.Fired,
                targetResource: "r1",
                targetResourceGroup: "rg1",
                targetResourceName: "target resource",
                monitorService: MonitorService.Platform,
                sourceCreatedId: "ID",
                smartGroupId: "Smart Group ID",
                smartGroupingReason: "Based on Similarity",
                startDateTime: new DateTime(2019, 6, 19, 12, 30, 45),
                lastModifiedDateTime: new DateTime(2019, 6, 20, 11, 45, 9),
                lastModifiedUserName: "System"
                );

            AlertProperties properties = new AlertProperties(essentials);
            return new Alert(
                id: id,
                name: name,
                properties: properties
            );
        }

        AlertsSummaryGroup GetTestSummaryGroup()
        {
            AlertsSummaryGroup group = new AlertsSummaryGroup(
                    total: 7,
                    smartGroupsCount: 2,
                    groupedby: "Severity",
                    values: new List<AlertsSummaryGroupItem>
                    {
                        new AlertsSummaryGroupItem("Sev0", 4, "AlertState", new List<AlertsSummaryGroupItem>{
                            new AlertsSummaryGroupItem("New", 1),
                            new AlertsSummaryGroupItem("Closed", 3)
                        }),
                        new AlertsSummaryGroupItem("Sev2", 3, "AlertState", new List<AlertsSummaryGroupItem>{
                            new AlertsSummaryGroupItem("New", 1),
                            new AlertsSummaryGroupItem("Acknowledged", 2)
                        })
                    }                    
                );
            return group;
        }
    }
}
