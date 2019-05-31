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
    public class SmartGroupsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void GetSmartGroupListTest()
        {
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.SmartGroups.GetAll();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetSmartGroupByIdTest()
        {
            string smartGroupId = "249a7944-dabc-4c80-8025-61165619d78f";
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.SmartGroups.GetById(smartGroupId);

            Assert.NotNull(result);
            Assert.Equal(smartGroupId, result.Id);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void SmartGroupStateChangeTest()
        {
            string smartGroupId = "249a7944-dabc-4c80-8025-61165619d78f";

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            alertsManagementClient = GetAlertsManagementClient(handler);

            string updatedState = AlertState.Closed;
            var result = alertsManagementClient.SmartGroups.ChangeState(smartGroupId, updatedState);

            Assert.Equal(smartGroupId, result.Id);
            Assert.Equal(updatedState, result.SmartGroupState);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetSmartGroupHistoryTest()
        {
            string smartGroupId = "249a7944-dabc-4c80-8025-61165619d78f";
            List<SmartGroupModificationItem> modificationitems = new List<SmartGroupModificationItem>
            {
                new SmartGroupModificationItem(SmartGroupModificationEvent.SmartGroupCreated),
                new SmartGroupModificationItem(SmartGroupModificationEvent.AlertAdded, "AddedAlertId"),
                new SmartGroupModificationItem(SmartGroupModificationEvent.AlertRemoved, "RemovedAlertId"),
                new SmartGroupModificationItem(SmartGroupModificationEvent.StateChange, AlertState.New, AlertState.Closed)
            };

            SmartGroupModification expectedParameters = new SmartGroupModification(properties: new SmartGroupModificationProperties(smartGroupId, modificationitems));

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.SmartGroups.GetHistory(smartGroupId);

            ComparisonUtility.AreEqual(expectedParameters.Properties.Modifications, result.Properties.Modifications);
        }

        private List<SmartGroup> GetTestSmartGroupList()
        {
            return new List<SmartGroup>
            {
                CreateTestSmartGroupById(Guid.NewGuid().ToString()),
                CreateTestSmartGroupById(Guid.NewGuid().ToString()),
                CreateTestSmartGroupById(Guid.NewGuid().ToString())
            };
        }

        private SmartGroup CreateTestSmartGroupById(string smartGroupId, string smartGroupState = "New")
        {
            return new SmartGroup(
                id: smartGroupId,
                alertsCount: 10,
                smartGroupState: smartGroupState,
                severity: Severity.Sev2,
                startDateTime: new DateTime(2019, 6, 19, 12, 30, 45),
                lastModifiedDateTime: new DateTime(2019, 6, 20, 11, 45, 9),
                lastModifiedUserName: "System"
            );
        }
    }
}
