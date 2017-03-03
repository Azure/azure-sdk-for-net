// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Xunit;

namespace Monitor.Tests.BasicTests
{
    public class AutoscaleTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";

        [Fact]
        public void CreateOrUpdateSettingTest()
        {
            AutoscaleSettingResource expResponse = CreateAutoscaleSetting(location: "East US", resourceUri: ResourceUri, metricName: "CpuPercentage");
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualResponse = insightsClient.AutoscaleSettings.CreateOrUpdate(resourceGroupName: "resourceGroup1", autoscaleSettingName: "setting1", parameters: expResponse);
            AreEqual(expResponse, actualResponse);
        }

        [Fact]
        public void Autoscale_GetSetting()
        {
            var expResponse = CreateAutoscaleSetting(ResourceUri, "CpuPercentage", string.Empty);
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            AutoscaleSettingResource actualResponse = insightsClient.AutoscaleSettings.Get(resourceGroupName: "resourceGroup1", autoscaleSettingName: "setting1");
            AreEqual(expResponse, actualResponse);
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

            AutoscaleSettingResource setting = new AutoscaleSettingResource
            {
                Name = "setting1",
                AutoscaleSettingResourceName = "setting1",
                TargetResourceUri = resourceUri,
                Enabled = true,
                Profiles = new AutoscaleProfile[]
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
                },
                Location = "",
                Tags = null,
                Notifications = null
            };

            return setting;
        }

        private static void AreEqual(AutoscaleSettingResource exp, AutoscaleSettingResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Enabled, act.Enabled);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.TargetResourceUri, act.TargetResourceUri);

                for (int i = 0; i < exp.Profiles.Count; i++)
                {
                    var expectedProfile = exp.Profiles[i];
                    var actualProfile = act.Profiles[i];
                    AreEqual(expectedProfile, actualProfile);
                }
            }
        }

        private static void AreEqual(AutoscaleProfile exp, AutoscaleProfile act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Name, act.Name);
                AreEqual(exp.Capacity, act.Capacity);
                AreEqual(exp.FixedDate, act.FixedDate);
                AreEqual(exp.Recurrence, act.Recurrence);
                for (int i = 0; i < exp.Rules.Count; i++)
                {
                    AreEqual(exp.Rules[i], act.Rules[i]);
                }
            }
        }

        private static void AreEqual(TimeWindow exp, TimeWindow act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.End.ToUniversalTime(), act.End.ToUniversalTime());
                Assert.Equal(exp.Start.ToUniversalTime(), act.Start.ToUniversalTime());
                Assert.Equal(exp.TimeZone, act.TimeZone);
            }
        }

        private static void AreEqual(ScaleCapacity exp, ScaleCapacity act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.DefaultProperty, act.DefaultProperty);
                Assert.Equal(exp.Maximum, act.Maximum);
                Assert.Equal(exp.Minimum, act.Minimum);
            }
        }

        private static void AreEqual(Recurrence exp, Recurrence act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Frequency, act.Frequency);
                AreEqual(exp.Schedule, act.Schedule);
            }
        }

        private static void AreEqual(RecurrentSchedule exp, RecurrentSchedule act)
        {
            if (exp != null)
            {
                AreEqual(exp.Days, act.Days);
                AreEqual(exp.Hours, act.Hours);
                AreEqual(exp.Minutes, act.Minutes);
                Assert.Equal(exp.TimeZone, act.TimeZone);
            }
        }

        private static bool AreEqual(IList<int?> exp, IList<int?> act)
        {
            if (exp != null)
            {
                if (act == null || exp.Count != act.Count)
                {
                    return false;
                }

                for (int i = 0; i < exp.Count; i++)
                {
                    if (exp[i] != act[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return act == null;
        }

        private static void AreEqual(ScaleRule exp, ScaleRule act)
        {
            if (exp != null)
            {
                AreEqual(exp.MetricTrigger, act.MetricTrigger);
                AreEqual(exp.ScaleAction, act.ScaleAction);
            }
        }

        private static void AreEqual(MetricTrigger exp, MetricTrigger act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.MetricName, act.MetricName);
                Assert.Equal(exp.MetricResourceUri, act.MetricResourceUri);
                Assert.Equal(exp.Statistic, act.Statistic);
                Assert.Equal(exp.Threshold, act.Threshold);
                Assert.Equal(exp.TimeAggregation, act.TimeAggregation);
                Assert.Equal(exp.TimeGrain, act.TimeGrain);
                Assert.Equal(exp.TimeWindow, act.TimeWindow);
            }
        }

        private static void AreEqual(ScaleAction exp, ScaleAction act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Cooldown, act.Cooldown);
                Assert.Equal(exp.Direction, act.Direction);
                Assert.Equal(exp.Value, act.Value);
            }
        }
    }
}
