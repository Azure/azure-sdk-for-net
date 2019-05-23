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
            List<SmartGroup> smartGroupList = GetTestSmartGroupList();
            SmartGroupsList expectedParameters = new SmartGroupsList("", smartGroupList);

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);
            var result = alertsManagementClient.SmartGroups.GetAll();

            ComparisonUtility.AreEqual(expectedParameters, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetSmartGroupByIdTest()
        {
            string smartGroupId = "249a7944-dabc-4c80-8025-61165619d78f";
            SmartGroup expectedParameters = CreateTestSmartGroupById(smartGroupId);

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);
            var result = alertsManagementClient.SmartGroups.GetById(smartGroupId);

            ComparisonUtility.AreEqual(expectedParameters, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void SmartGroupStateChangeTest()
        {
            string smartGroupId = "249a7944-dabc-4c80-8025-61165619d78f";
            SmartGroup expectedParameters = CreateTestSmartGroupById(smartGroupId);

            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, alertsManagementClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            alertsManagementClient = GetAlertsManagementClient(handler);
            string updatedState = "Acknowledged";
            var result = alertsManagementClient.SmartGroups.ChangeState(smartGroupId, updatedState);

            Assert.Equal(updatedState, result.SmartGroupState);
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
