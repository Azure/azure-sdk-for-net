// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Xunit;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    public class ActivityLogAlertsTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        public ActivityLogAlertsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateOrUpdateActivityLogAlertsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ActivityLogAlertResource expectedParameters = GetCreateOrUpdateActivityLogAlertParameter();
                var insightsClient = GetMonitorManagementClient(context, handler);

                var result = insightsClient.ActivityLogAlerts.CreateOrUpdate(
                    resourceGroupName: "rg1", 
                    activityLogAlertName: expectedParameters.Name, 
                    activityLogAlert: expectedParameters);

                if (!this.IsRecording)
                {
                    AreEqual(expectedParameters, result);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetActivityLogAlertTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var expectedActionGroup = GetCreateOrUpdateActivityLogAlertParameter(name: "name4");
                var insightsClient = GetMonitorManagementClient(context, handler);

                var activityLogAlert = insightsClient.ActivityLogAlerts.Get(
                    resourceGroupName: "rg1",
                    activityLogAlertName: "name4");

                if (!this.IsRecording)
                {
                    AreEqual(expectedActionGroup, activityLogAlert);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListActivityLogAlertsBySusbscriptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                List<ActivityLogAlertResource> expectedParameters = GetActionGroups();
                var insightsClient = GetMonitorManagementClient(context, handler);

                var actualGroups = insightsClient.ActivityLogAlerts.ListBySubscriptionId();

                if (!this.IsRecording)
                {
                    AreEqual(expectedParameters, actualGroups.ToList());
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListActivityLogAlertsByResourceGroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                List<ActivityLogAlertResource> expectedParameters = GetActionGroups();
                var insightsClient = GetMonitorManagementClient(context, handler);

                var actualGroups = insightsClient.ActivityLogAlerts.ListByResourceGroup(resourceGroupName: "rg1");

                if (!this.IsRecording)
                {
                    AreEqual(expectedParameters, actualGroups.ToList());
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void DeleteActivityLogAlertTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = GetMonitorManagementClient(context, handler);
                var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

                AzureOperationResponse response = insightsClient.ActivityLogAlerts.DeleteWithHttpMessagesAsync(
                    resourceGroupName: "rg1",
                    activityLogAlertName: "name4").Result;

                if (!this.IsRecording)
                {
                    Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void UpdateActivityLogAlertTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, "UpdateActivityLogAlertTest"))
            {
                ActivityLogAlertResource expectedParameters = GetCreateOrUpdateActivityLogAlertParameter();
                var insightsClient = GetMonitorManagementClient(context, handler);

                ActivityLogAlertPatchBody bodyParameter = new ActivityLogAlertPatchBody
                {
                    Enabled = true,
                    Tags = null
                };

                ActivityLogAlertResource response = insightsClient.ActivityLogAlerts.Update(
                    resourceGroupName: "rg1",
                    activityLogAlertName: "name1",
                    activityLogAlertPatch: bodyParameter);

                if (!this.IsRecording)
                {
                    AreEqual(expectedParameters, response);
                }
            }
        }

        private static List<ActivityLogAlertResource> GetActionGroups()
        {
            return new List<ActivityLogAlertResource>
            {
                GetCreateOrUpdateActivityLogAlertParameter(),
                GetCreateOrUpdateActivityLogAlertParameter(),
                GetCreateOrUpdateActivityLogAlertParameter()
            };
        }

        private static void AreEqual(ActivityLogAlertResource exp, ActivityLogAlertResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Enabled, act.Enabled);
                AreEqual(exp.Tags, act.Tags);
                AreEqual(exp.Scopes, act.Scopes);
                AreEqual(exp.Condition, act.Condition);
                AreEqual(exp.Actions, act.Actions);
            }
        }

        private static void AreEqual(IList<ActivityLogAlertResource> exp, IList<ActivityLogAlertResource> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.True(exp.Count == act.Count, "List of activities' lengths are different");
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(ActivityLogAlertAllOfCondition exp, ActivityLogAlertAllOfCondition act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.NotNull(act.AllOf);
                for (int i = 0; i < exp.AllOf.Count; i++)
                {
                    AreEqual(exp.AllOf[i], act.AllOf[i]);
                }
            }
        }

        private static void AreEqual(ActivityLogAlertActionList exp, ActivityLogAlertActionList act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.NotNull(act.ActionGroups);
                for (int i = 0; i < exp.ActionGroups.Count; i++)
                {
                    AreEqual(exp.ActionGroups[i], act.ActionGroups[i]);
                }
            }
        }

        private static void AreEqual(ActivityLogAlertActionGroup exp, ActivityLogAlertActionGroup act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ActionGroupId, act.ActionGroupId);
                Assert.Equal(exp.WebhookProperties, act.WebhookProperties);
            }
        }

        private static void AreEqual(ActivityLogAlertLeafCondition exp, ActivityLogAlertLeafCondition act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Field, act.Field);
                Assert.Equal(exp.Equals, act.Equals);
            }
        }

        private static ActivityLogAlertResource GetCreateOrUpdateActivityLogAlertParameter(
            string name = "name1")
        {
            // Name and id won't be serialized since they are readonly
            return new ActivityLogAlertResource(
                id: "long name",
                name: name,
                location: "location",
                tags: new Dictionary<string, string>()
                {
                    {"name", "name1"},
                    {"id", "long name"},
                    {"key1", "val1"}
                },
                enabled: true,
                description: "",
                actions: new ActivityLogAlertActionList(new List<ActivityLogAlertActionGroup> { }),
                condition: new ActivityLogAlertAllOfCondition(allOf: new List<ActivityLogAlertLeafCondition> { }),
                scopes: new List<string> { "s1" }
            );
        }
    }
}
