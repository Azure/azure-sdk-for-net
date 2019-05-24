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
    public class SmartGroupsTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        public SmartGroupsTests() : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetSmartGroupListTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                SmartGroupsList actual = alertsManagementClient.SmartGroups.GetAll();

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetSmartGroupByIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                SmartGroup actual = alertsManagementClient.SmartGroups.GetById("720dd30b-ed61-446b-bcd3-cf1793236916");

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void SmartGroupStateChangeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                SmartGroup actual = alertsManagementClient.SmartGroups.ChangeState("720dd30b-ed61-446b-bcd3-cf1793236916", AlertState.Closed);

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void SmartGroupHistoryTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                var actual = alertsManagementClient.SmartGroups.GetHistory("720dd30b-ed61-446b-bcd3-cf1793236916");

                if (!this.IsRecording)
                {
                    Check(alertsManagementClient, actual);
                }
            }
        }

        private void Check(AlertsManagementClient alertsManagementClient, SmartGroupsList actual)
        {
            throw new NotImplementedException();
        }

        private void Check(AlertsManagementClient alertsManagementClient, SmartGroup actual)
        {
            throw new NotImplementedException();
        }

        private void Check(AlertsManagementClient alertsManagementClient, SmartGroupModification actual)
        {
            throw new NotImplementedException();
        }
    }
}
