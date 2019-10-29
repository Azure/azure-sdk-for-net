// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;

namespace Monitor.Tests.BasicTests
{
    public class AutoscaleTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";

        [Fact]
        [Trait("Category", "Mock")]
        public void CreateOrUpdateSettingTest()
        {
            AutoscaleSettingResource expResponse = CreateAutoscaleSetting(location: "East US", resourceUri: ResourceUri, metricName: "CpuPercentage");
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expResponse.Name + "\",\"id\":\"" + expResponse.Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualResponse = insightsClient.AutoscaleSettings.CreateOrUpdate(resourceGroupName: "resourceGroup1", autoscaleSettingName: "setting1", parameters: expResponse);
            Utilities.AreEqual(expResponse, actualResponse);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void UpdateSettingTest()
        {
            AutoscaleSettingResource resource = CreateAutoscaleSetting(location: "East US", resourceUri: ResourceUri, metricName: "CpuPercentage");
            resource.Tags = new Dictionary<string, string>
            {
                { "key2", "val2" }
            };
            resource.Enabled = false;

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

            AutoscaleSettingResourcePatch pathResource = new AutoscaleSettingResourcePatch(
                name: resource.Name,
                tags: new Dictionary<string, string>
                {
                    { "key2", "val2" }
                },
                notifications: resource.Notifications,
                enabled: false,
                profiles: resource.Profiles,
                targetResourceUri: resource.TargetResourceUri
            );

            var actualResponse = monitorManagementClient.AutoscaleSettings.Update(resourceGroupName: "resourceGroup1", autoscaleSettingName: "setting1", autoscaleSettingResource: pathResource);
            Utilities.AreEqual(resource, actualResponse);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void Autoscale_GetSetting()
        {
            var expResponse = CreateAutoscaleSetting(ResourceUri, "CpuPercentage", string.Empty);
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expResponse.Name + "\",\"id\":\"" + expResponse.Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            AutoscaleSettingResource actualResponse = insightsClient.AutoscaleSettings.Get(resourceGroupName: "resourceGroup1", autoscaleSettingName: "setting1");
            Utilities.AreEqual(expResponse, actualResponse);
        }

        private static AutoscaleSettingResource CreateAutoscaleSetting(string location, string resourceUri, string metricName)
        {
            var capacity = new ScaleCapacity()
            {
                DefaultProperty = "1",
                Maximum = "100",
                Minimum = "1"
            };

            var fixedDate = new TimeWindow()
            {
                End = DateTime.Parse("2014-04-16T21:06:11.7882792Z"),
                Start = DateTime.Parse("2014-04-15T21:06:11.7882792Z"),
                TimeZone = TimeZoneInfo.Utc.Id.ToString()
            };

            var recurrence = new Recurrence()
            {
                Frequency = RecurrenceFrequency.Week,
                Schedule = new RecurrentSchedule()
                {
                    Days = new List<string> { "Monday" },
                    Hours = new List<int?> { 0 },
                    Minutes = new List<int?> { 10 },
                    TimeZone = "UTC-11"
                }
            };

            var rules = new ScaleRule[]
            {
                new ScaleRule()
                {
                    MetricTrigger = new MetricTrigger
                    {
                        MetricName = metricName,
                        MetricResourceUri = resourceUri,
                        Statistic = MetricStatisticType.Average,
                        Threshold = 80.0,
                        TimeAggregation = TimeAggregationType.Maximum,
                        TimeGrain = TimeSpan.FromMinutes(1),
                        TimeWindow = TimeSpan.FromHours(1)
                    },
                    ScaleAction = new ScaleAction
                    {
                        Cooldown = TimeSpan.FromMinutes(20),
                        Direction = ScaleDirection.Increase,
                        Value = "10"
                    }
                }
            };

            var profiles = new AutoscaleProfile[]
            {
                new AutoscaleProfile()
                {
                    Name = "Profile1",
                    Capacity = capacity,
                    FixedDate = fixedDate,
                    Recurrence = null,
                    Rules = rules
                },
                new AutoscaleProfile()
                {
                    Name = "Profile2",
                    Capacity = capacity,
                    FixedDate = null,
                    Recurrence = recurrence,
                    Rules = rules
                }
            };

            AutoscaleSettingResource setting = new AutoscaleSettingResource(location: "", profiles: profiles, name: "setting1")
            {
                AutoscaleSettingResourceName = "setting1",
                TargetResourceUri = resourceUri,
                Enabled = true,
                Tags = null,
                Notifications = null
            };

            return setting;
        }
    }
}
