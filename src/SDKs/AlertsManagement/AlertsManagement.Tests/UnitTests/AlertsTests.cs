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

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);
            string updatedState = AlertState.Closed;
            var result = alertsManagementClient.Alerts.ChangeState(alertID, updatedState);

            Assert.Equal(updatedState, result.Properties.Essentials.AlertState);
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
    }
}
