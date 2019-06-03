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

            string updatedState = AlertState.Closed;
            var result = alertsManagementClient.SmartGroups.ChangeState(smartGroupId, updatedState);

            Assert.Equal(smartGroupId, result.Id);
            Assert.Equal(updatedState, result.Properties.SmartGroupState);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetSmartGroupHistoryTest()
        {
            string smartGroupId = "249a7944-dabc-4c80-8025-61165619d78f";
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);
            var result = alertsManagementClient.SmartGroups.GetHistory(smartGroupId);

            Assert.Equal(smartGroupId, result.Properties.SmartGroupId);
            Assert.Equal(4, result.Properties.Modifications.Count);
        }
    }
}
