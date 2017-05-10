// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Xunit;

namespace Monitor.Tests.BasicTests
{
    public class ActivityLogAlertsTests : TestBase
    {
        [Fact]
        public void CreateOrUpdateTest()
        {
            ActivityLogAlertResource expectedParameters = GetActivityLogAlertResource();

            var serializedObject = SerializeResponse(expectedParameters);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetMonitorManagementClient(handler);
            var result = insightsClient.ActivityLogAlerts.CreateOrUpdate(resourceGroupName: "rg1", activityLogAlertName: expectedParameters.Name, activityLogAlert: expectedParameters);

            AreEqual(expectedParameters, result);
        }

        [Fact]
        public void GetTest()
        {
            var activityLogAlertResource = GetActivityLogAlertResource();
            var serializedObject = SerializeResponse(activityLogAlertResource);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetMonitorManagementClient(handler);
            var actualActivityLogResource = insightsClient.ActivityLogAlerts.Get(
                resourceGroupName: "rg1",
                activityLogAlertName: "r1");

            AreEqual(activityLogAlertResource, actualActivityLogResource);
        }

        [Fact]
        public void ListBySubscriptionTest()
        {
            var activityLogAlertResource = GetActivityLogAlertResource();
            var expectedResponseContent = new List<ActivityLogAlertResource>
            {
                activityLogAlertResource,
                activityLogAlertResource
            };

            var serializedObject = SerializeResponse(expectedResponseContent);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetMonitorManagementClient(handler);

            var actualResources = insightsClient.ActivityLogAlerts.ListBySubscriptionId();

            AreEqual(expectedResponseContent, actualResources.ToList());
        }

        [Fact]
        public void ListByResourceGroupTest()
        {
            var activityLogAlertResource = GetActivityLogAlertResource();
            var expectedResponseContent = new List<ActivityLogAlertResource>
            {
                activityLogAlertResource,
                activityLogAlertResource
            };

            var serializedObject = SerializeResponse(expectedResponseContent);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetMonitorManagementClient(handler);

            var actualResources = insightsClient.ActivityLogAlerts.ListByResourceGroup(resourceGroupName: "myGroup");

            AreEqual(expectedResponseContent, actualResources.ToList());
        }

        [Fact]
        public void DeleteTest()
        {
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);
            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetMonitorManagementClient(handler);

            insightsClient.ActivityLogAlerts.Delete(resourceGroupName: "any", activityLogAlertName: "r1");
        }

        [Fact]
        public void PatchTest()
        {
            ActivityLogAlertResource expectedParameters = GetActivityLogAlertResource();
            expectedParameters.Enabled = false;
            expectedParameters.Tags = new Dictionary<string, string>() { {"key3", "val3"} };

            var serializedObject = SerializeResponse(expectedParameters);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            ActivityLogAlertResourcePatch patchParams = new ActivityLogAlertResourcePatch
            {
                Enabled = expectedParameters.Enabled,
                Tags = expectedParameters.Tags
            };

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetMonitorManagementClient(handler);
            var result = insightsClient.ActivityLogAlerts.Update(resourceGroupName: "rg1", activityLogAlertName: expectedParameters.Name, activityLogAlertPatch: patchParams);

            AreEqual(expectedParameters, result);
        }

        #region Helpers

        private string SerializeResponse(ActivityLogAlertResource resource)
        {
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(resource, insightsClient.DeserializationSettings);

            var location = QuoteIfNotNull(resource.Location);
            return serializedObject = serializedObject.Replace(
                        string.Format("\"location\":{0},", location),
                        string.Format("\"location\":{0},\"name\":{1},\"id\":{2},\"type\":{3},", location, QuoteIfNotNull(resource.Name), QuoteIfNotNull(resource.Id), QuoteIfNotNull(resource.Type)));
        }

        private string SerializeResponse(IEnumerable<ActivityLogAlertResource> resources)
        {
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(resources, insightsClient.DeserializationSettings);

            foreach (var resource in resources)
            {
                var location = QuoteIfNotNull(resource.Location);
                serializedObject = serializedObject.Replace(
                        string.Format("\"location\":{0},", location),
                        string.Format("\"location\":{0},\"name\":{1},\"id\":{2},\"type\":{3},", location, QuoteIfNotNull(resource.Name), QuoteIfNotNull(resource.Id), QuoteIfNotNull(resource.Type)));
            }

            return string.Concat("{\"value\":",serializedObject,"}");
        }

        private static string QuoteIfNotNull(string str)
        {
            if (str != null)
            {
                return "\"" + str + "\"";
            }
            else
            {
                return "null";
            }
        }

        private static void AreEqual(ActivityLogAlertResource exp, ActivityLogAlertResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Enabled, act.Enabled);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Type, act.Type);

                // Comparing Scopes
                foreach (var str in exp.Scopes)
                {
                    Assert.True(act.Scopes.Contains(str));
                }

                foreach (var str in act.Scopes)
                {
                    Assert.True(exp.Scopes.Contains(str));
                }

                // Comparing Conditions (2DO: compare structure too)
                Assert.NotNull(exp.Condition);
                Assert.NotNull(act.Condition);

                // Comparing Actions  (2DO: compare structure too)
                Assert.NotNull(exp.Actions);
                Assert.NotNull(act.Actions);
            }
        }

        private void AreEqual(IList<ActivityLogAlertResource> exp, IList<ActivityLogAlertResource> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private ActivityLogAlertResource GetActivityLogAlertResource()
        {
            return new ActivityLogAlertResource(
                location: "location",
                scopes: new string[] { "str1", "str2" },
                condition: new ActivityLogAlertAllOfCondition { AllOf = new List<ActivityLogAlertLeafCondition> { new ActivityLogAlertLeafCondition { Field = "f1", Equals = "eq1" } } },
                actions: new ActivityLogAlertActionList(),
                description: "description",
                enabled: true,
                name: "name1",
                tags: new Dictionary<string, string>()
                {
                    {"key1", "val1"}
                }
            );
        }

        #endregion
    }
}
