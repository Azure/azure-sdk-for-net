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

namespace Monitor.Tests.BasicTests
{
    public class ActivityLogAlertsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void CreateOrUpdateActivityLogAlertsTest()
        {
            ActivityLogAlertResource expectedParameters = GetCreateOrUpdateActivityLogAlertParameter();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedParameters.Name + "\",\"id\":\"" + expectedParameters.Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var result = insightsClient.ActivityLogAlerts.CreateOrUpdate(resourceGroupName: "rg1", activityLogAlertName: expectedParameters.Name, activityLogAlert: expectedParameters);

            AreEqual(expectedParameters, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetActivityLogAlertTest()
        {
            var expectedActionGroup = GetCreateOrUpdateActivityLogAlertParameter(name: "name4");

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedActionGroup, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedActionGroup.Name + "\",\"id\":\"" + expectedActionGroup.Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var activityLogAlert = insightsClient.ActivityLogAlerts.Get(
                resourceGroupName: "rg1",
                activityLogAlertName: "name4");

            AreEqual(expectedActionGroup, activityLogAlert);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListActivityLogAlertsBySusbscriptionTest()
        {
            List<ActivityLogAlertResource> expectedParameters = GetActionGroups();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedParameters[0].Name + "\",\"id\":\"" + expectedParameters[0].Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualGroups = insightsClient.ActivityLogAlerts.ListBySubscriptionId();

            AreEqual(expectedParameters, actualGroups.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListActivityLogAlertsByResourceGroupTest()
        {
            List<ActivityLogAlertResource> expectedParameters = GetActionGroups();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedParameters[0].Name + "\",\"id\":\"" + expectedParameters[0].Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualGroups = insightsClient.ActivityLogAlerts.ListByResourceGroup(resourceGroupName: "rg1");

            AreEqual(expectedParameters, actualGroups.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void DeleteActivityLogAlertTest()
        {
            var handler = new RecordedDelegatingHandler();
            var monitorManagementClient = GetMonitorManagementClient(handler);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            handler = new RecordedDelegatingHandler(expectedResponse);
            monitorManagementClient = GetMonitorManagementClient(handler);

            AzureOperationResponse response = monitorManagementClient.ActivityLogAlerts.DeleteWithHttpMessagesAsync(
                resourceGroupName: "rg1",
                activityLogAlertName: "name1").Result;

            Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void UpdateActivityLogAlertTest()
        {
            ActivityLogAlertResource expectedParameters = GetCreateOrUpdateActivityLogAlertParameter();

            var handler = new RecordedDelegatingHandler();
            var monitorManagementClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, monitorManagementClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedParameters.Name + "\",\"id\":\"" + expectedParameters.Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            monitorManagementClient = GetMonitorManagementClient(handler);

            ActivityLogAlertPatchBody bodyParameter = new ActivityLogAlertPatchBody
            {
                Enabled = true,
                Tags = null
            };

            ActivityLogAlertResource response = monitorManagementClient.ActivityLogAlerts.Update(
                resourceGroupName: "rg1",
                activityLogAlertName: "name1",
                activityLogAlertPatch: bodyParameter);

            AreEqual(expectedParameters, response);
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
                Utilities.AreEqual(exp.Tags, act.Tags);
                Utilities.AreEqual(exp.Scopes, act.Scopes);
                AreEqual(exp.Condition, act.Condition);
                AreEqual(exp.Actions, act.Actions);
            }
        }

        private static void AreEqual(IList<ActivityLogAlertResource> exp, IList<ActivityLogAlertResource> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
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
