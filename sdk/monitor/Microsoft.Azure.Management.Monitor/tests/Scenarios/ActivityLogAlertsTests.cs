// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Globalization;

namespace Monitor.Tests.Scenarios
{
    public class ActivityLogAlertsTests : TestBase
    {
        private const string ResourceGroupName = "Default-ActivityLogAlerts";
        private const string ActivityLogRuleName = "andy0307rule";
        private const string Location = "Global";
        private RecordedDelegatingHandler handler;

        public ActivityLogAlertsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateGetListUpdateDeleteActivityLogAlert()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                ActivityLogAlertResource bodyParameter = GetCreateOrUpdateActivityLogAlertParameter(insightsClient.SubscriptionId);
                ActivityLogAlertResource result = insightsClient.ActivityLogAlerts.CreateOrUpdate(
                    resourceGroupName: ResourceGroupName, 
                    activityLogAlertName: ActivityLogRuleName, 
                    activityLogAlert: bodyParameter);

                if (!this.IsRecording)
                {
                    // TODO: Create a Check 
                    Assert.False(string.IsNullOrWhiteSpace(result.Id));
                    Assert.Equal(ActivityLogRuleName, result.Name);
                    Assert.NotNull(result.Actions);
                    Assert.NotNull(result.Condition);
                    Assert.NotNull(result.Scopes);

                    // AreEqual(bodyParameter, result);
                }

                ActivityLogAlertResource activityLogAlert = insightsClient.ActivityLogAlerts.Get(
                    resourceGroupName: ResourceGroupName,
                    activityLogAlertName: ActivityLogRuleName);

                if (!this.IsRecording)
                {
                    Utilities.AreEqual(result, activityLogAlert);
                }

                IEnumerable<ActivityLogAlertResource> actualGroups = insightsClient.ActivityLogAlerts.ListBySubscriptionId();

                if (!this.IsRecording)
                {
                    var listActualGroups = actualGroups.ToList();
                    Assert.NotNull(listActualGroups);
                    Assert.True(listActualGroups.Count > 0);

                    ActivityLogAlertResource similar = listActualGroups.FirstOrDefault(a => string.Equals(a.Id, activityLogAlert.Id, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(similar);

                    // AreEqual(bodyParameter, actualGroups.ToList());
                }

                actualGroups = insightsClient.ActivityLogAlerts.ListByResourceGroup(resourceGroupName: ResourceGroupName);

                if (!this.IsRecording)
                {
                    var listActualGroups = actualGroups.ToList();
                    Assert.NotNull(listActualGroups);
                    Assert.True(listActualGroups.Count > 0);

                    ActivityLogAlertResource similar = listActualGroups.FirstOrDefault(a => string.Equals(a.Id, activityLogAlert.Id, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(similar);

                    // AreEqual(bodyParameter, actualGroups.ToList());
                }

                // TODO: Verify: Actions cannot be null or the request fails with BadRequest
                ActivityLogAlertPatchBody patchBodyParameter = new ActivityLogAlertPatchBody
                {
                    Enabled = true,
                    Tags = null
                };

                ActivityLogAlertResource patchResponse = null;

                Assert.Throws<ErrorResponseException>(
                    () => patchResponse = insightsClient.ActivityLogAlerts.Update(
                    resourceGroupName: ResourceGroupName,
                    activityLogAlertName: ActivityLogRuleName,
                    activityLogAlertPatch: patchBodyParameter));

                if (!this.IsRecording && patchResponse != null)
                {
                    // Use Check here too
                    Assert.False(string.IsNullOrWhiteSpace(patchResponse.Id));
                    Assert.Equal(ActivityLogRuleName, patchResponse.Name);
                    Assert.NotNull(patchResponse.Actions);
                    Assert.NotNull(patchResponse.Condition);
                    Assert.NotNull(patchResponse.Scopes);

                    Assert.True(patchResponse.Enabled);
                    Assert.Null(patchResponse.Tags);
                    Assert.Equal(activityLogAlert.Id, patchResponse.Id);

                    // AreEqual(bodyParameter, response);
                }

                AzureOperationResponse deleteResponse = insightsClient.ActivityLogAlerts.DeleteWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                    activityLogAlertName: ActivityLogRuleName).Result;

                if (!this.IsRecording)
                {
                    Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);
                }
            }
        }

        private static ActivityLogAlertResource GetCreateOrUpdateActivityLogAlertParameter(
            string subscriptionId,
            string name = ActivityLogRuleName)
        {
            // Name and id won't be serialized since they are readonly
            return new ActivityLogAlertResource(
                name: name,
                location: Location,
                tags: new Dictionary<string, string>(),
                enabled: true,
                description: null,
                actions: new ActivityLogAlertActionList(
                    actionGroups: new List<ActivityLogAlertActionGroup>
                        {
                            new ActivityLogAlertActionGroup(
                                actionGroupId: string.Format(
                                    provider: CultureInfo.InvariantCulture, 
                                    format: "/subscriptions/{0}/resourceGroups/{1}/providers/microsoft.insights/actionGroups/andygroup-donotuse", 
                                    args: new [] { subscriptionId, ResourceGroupName }), 
                                webhookProperties: new Dictionary<string, string>())
                        }),
                condition: new ActivityLogAlertAllOfCondition(
                    allOf: new List<ActivityLogAlertLeafCondition>
                        {
                            new ActivityLogAlertLeafCondition(field: "category", equals: "Administrative"),
                            new ActivityLogAlertLeafCondition(field: "resourceGroup", equals: "andy0307"),
                        }),
                scopes: new List<string> { string.Format(CultureInfo.InvariantCulture, "/subscriptions/{0}", subscriptionId) }
            );
        }
    }
}
