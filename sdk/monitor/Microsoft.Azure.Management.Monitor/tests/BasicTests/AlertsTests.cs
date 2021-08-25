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

namespace Monitor.Tests.BasicTests
{
    public class AlertsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void CreateOrUpdateRuleTest()
        {
            AlertRuleResource expectedParameters = GetCreateOrUpdateRuleParameter();

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

            var result = insightsClient.AlertRules.CreateOrUpdate(resourceGroupName: "rg1", ruleName: expectedParameters.Name, parameters: expectedParameters);

            Utilities.AreEqual(expectedParameters, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetIncidentTest()
        {
            var expectedIncident = GetIncidents().First();

            var serializedObject = expectedIncident.ToJson();
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            var handler = new RecordedDelegatingHandler(expectedResponse);
            var insightsClient = GetMonitorManagementClient(handler);

            var actualIncident = insightsClient.AlertRuleIncidents.Get(
                resourceGroupName: "rg1",
                ruleName: "r1",
                incidentName: "i1");

            Utilities.AreEqual(expectedIncident, actualIncident);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListIncidentsTest()
        {
            var expectedIncidentsResponse = new List<Incident>
            {
                new Incident(
                    activatedTime: DateTime.Parse("2014-08-01T00:00:00Z"),
                    isActive: false,
                    name: "i1",
                    resolvedTime: DateTime.Parse("2014-08-01T00:00:00Z"),
                    ruleName: "r1"
                    )
            };

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", expectedIncidentsResponse.ToJson(), "}"))
            };

            var handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetMonitorManagementClient(handler);

            var actualIncidents = insightsClient.AlertRuleIncidents.ListByAlertRule(
                resourceGroupName: "rg1",
                ruleName: "r1");

            Utilities.AreEqual(expectedIncidentsResponse, actualIncidents.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListRulesTest()
        {
            var expResponse = GetRuleResourceCollection();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expResponse[0].Name + "\",\"id\":\"" + expResponse[0].Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualResponse = insightsClient.AlertRules.ListByResourceGroup(resourceGroupName: "rg1");
            Utilities.AreEqual(expResponse, actualResponse.ToList<AlertRuleResource>());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void UpdateRulesTest()
        {
            AlertRuleResource resource = GetRuleResourceCollection().FirstOrDefault();
            resource.IsEnabled = false;
            resource.Tags = new Dictionary<string, string>()
            {
                {"key2", "val2"}
            };

            var handler = new RecordedDelegatingHandler();
            var monitorManagementClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(resource, monitorManagementClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + resource.Name + "\",\"id\":\"" + resource.Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            monitorManagementClient = GetMonitorManagementClient(handler);

            AlertRuleResourcePatch pathResource = new AlertRuleResourcePatch(
                name: resource.Name,
                isEnabled: false,
                tags: new Dictionary<string, string>()
                {
                    {"key2", "val2"}
                },
                actions: resource.Actions,
                condition: resource.Condition,
                description: resource.Description,
                lastUpdatedTime: resource.LastUpdatedTime
            );

            var actualResponse = monitorManagementClient.AlertRules.Update(resourceGroupName: "rg1", ruleName: resource.Name, alertRulesResource: pathResource);
            Utilities.AreEqual(resource, actualResponse);
        }

        private static List<Incident> GetIncidents()
        {
            return new List<Incident>
            {
                new Incident(
                    activatedTime: DateTime.UtcNow,
                    isActive: false,
                    name: "i1",
                    resolvedTime: DateTime.UtcNow,
                    ruleName: "r1"
                )
            };
        }

        private AlertRuleResource GetCreateOrUpdateRuleParameter()
        {
            List<RuleAction> actions = new List<RuleAction>
            {
                new RuleEmailAction()
                {
                    CustomEmails = new List<string>()
                        {
                            "emailid1"
                        },
                    SendToServiceOwners = true
                }
            };

            // Name and id won't be serialized since thwy are readonly
            return new AlertRuleResource(
                id: "long name",
                name: "name1",
                location: "location",
                alertRuleResourceName: "name1",
                actions: actions,
                condition: new LocationThresholdRuleCondition()
                {
                    DataSource = new RuleMetricDataSource()
                    {
                        MetricName = "CPUPercentage",
                        ResourceUri = "resourceUri"
                    },
                    FailedLocationCount = 1,
                    WindowSize = TimeSpan.FromMinutes(30)
                },
                description: "description",
                isEnabled: true,
                lastUpdatedTime: DateTime.UtcNow,
                tags: new Dictionary<string, string>()
                {
                    {"key1", "val1"}
                }
            );
        }

        private List<AlertRuleResource> GetRuleResourceCollection()
        {
            List<RuleAction> actions = new List<RuleAction>
            {
                new RuleEmailAction()
                {
                    CustomEmails = new List<string>()
                        {
                            "eamil1"
                        },
                    SendToServiceOwners = true
                }
            };
            return new List<AlertRuleResource>
            {
                new AlertRuleResource(
                    id: "id1",
                    location: "location1",
                    name: "name1",
                    alertRuleResourceName: "name1",
                    actions: actions,
                    condition: new LocationThresholdRuleCondition()
                    {
                        DataSource = new RuleMetricDataSource()
                        {
                            MetricName = "CpuPercentage",
                            ResourceUri = "resUri1"
                        },
                        FailedLocationCount = 1,
                        WindowSize = TimeSpan.FromMinutes(30)
                    },
                    description: "description1",
                    isEnabled: true,
                    lastUpdatedTime: DateTime.UtcNow,
                    tags: new Dictionary<string, string>()
                    {
                        {"key1", "val1"}
                    }
                )
            };
        }
    }
}
