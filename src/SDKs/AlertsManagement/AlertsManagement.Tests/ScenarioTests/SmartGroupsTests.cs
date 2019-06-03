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
        public void SmartGroupStateChangeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var alertsManagementClient = GetAlertsManagementClient(context, handler);

                string smartGroupId = "9587da05-0fb6-44a0-a757-e242968c7c57";

                // Get smart group by ID
                SmartGroup actualSmartGroup = alertsManagementClient.SmartGroups.GetById(smartGroupId);

                if (!this.IsRecording)
                {
                    Assert.Equal(AlertState.New, actualSmartGroup.Properties.SmartGroupState);
                }

                // Perform state change operation
                string updatedState = AlertState.Closed;
                SmartGroup smartGroupPostStateChange = alertsManagementClient.SmartGroups.ChangeState(smartGroupId, updatedState);

                // Verify the state change operation was successful
                if (!this.IsRecording)
                {
                    Assert.Equal(updatedState, smartGroupPostStateChange.Properties.SmartGroupState);
                }

                // Get History of smart group
                var smartGroupHistory = alertsManagementClient.SmartGroups.GetHistory(smartGroupId);

                // Check if the history contains the state update event
                if (!this.IsRecording)
                {
                    CheckHistoryContainsStateChangeEvent(smartGroupHistory);
                }
            }
        }

        private void CheckHistoryContainsStateChangeEvent(SmartGroupModification smartGroupHistory)
        {
            bool eventFound = false;

            IList<SmartGroupModificationItem> modifications = smartGroupHistory.Properties.Modifications;
            foreach (var item in modifications)
            {
                if (item.ModificationEvent == SmartGroupModificationEvent.StateChange)
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