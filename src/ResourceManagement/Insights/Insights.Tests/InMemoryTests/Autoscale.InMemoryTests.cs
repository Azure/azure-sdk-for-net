//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Insights.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;

namespace Insights.Tests.InMemoryTests
{
    public class AutoscaleInMemoryTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";

        [Fact]
        public void CreateOrUpdateSettingTest()
        {
            var handler = new RecordedDelegatingHandler();
            InsightsManagementClient customClient = this.GetInsightsManagementClient(handler);

            AutoscaleSettingCreateOrUpdateParameters parameters = new AutoscaleSettingCreateOrUpdateParameters
            {
                Properties = CreateAutoscaleSetting(ResourceUri, "CpuPercentage", string.Empty),
                Location = "East US",
                Tags = new Dictionary<string, string> { { "tag1", "value1" } }
            };

            customClient.AutoscaleOperations.CreateOrUpdateSetting("resourceGroup1", "setting1", parameters);
            var actualResponse = JsonExtensions.FromJson<AutoscaleSettingCreateOrUpdateParameters>(handler.Request);
            AreEqual(parameters.Properties, actualResponse.Properties);
        }

        [Fact]
        public void Autoscale_GetSetting()
        {
            var expectedAutoscaleSetting = CreateAutoscaleSetting(ResourceUri, "CpuPercentage", string.Empty);
            var expectedAutoscaleSettingGetResponse = new AutoscaleSettingGetResponse()
            {
                Id = ResourceUri,
                Location = "East US",
                Tags = new Dictionary<string, string> {{"tag1", "value1"}},
                Name = expectedAutoscaleSetting.Name,
                Properties = expectedAutoscaleSetting,
                RequestId = "request id",
                StatusCode = HttpStatusCode.OK
            };

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedAutoscaleSettingGetResponse.ToJson()),
            };

            var handler = new RecordedDelegatingHandler(response);
            InsightsManagementClient customClient = this.GetInsightsManagementClient(handler);
            AutoscaleSettingGetResponse actualResponse = customClient.AutoscaleOperations.GetSetting("resourceGroup1", "setting1");
            AreEqual(expectedAutoscaleSettingGetResponse.Properties, actualResponse.Properties);
        }

        private static AutoscaleSetting CreateAutoscaleSetting(string resourceUri, string metricName, string metricNamespace)
        {
            var capacity = new ScaleCapacity
            {
                Default = "1",
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
                    Hours = new List<int> { 0 },
                    Minutes = new int[] { 10 },
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
                        MetricNamespace = metricNamespace,
                        MetricResourceUri = resourceUri,
                        Operator = ComparisonOperationType.GreaterThan,
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
                        Type = ScaleType.ExactCount,
                        Value = "10"
                    }
                }
            };

            AutoscaleSetting setting = new AutoscaleSetting
            {
                Name = "setting1",
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
                }
            };

            return setting;
        }

        private static void AreEqual(AutoscaleSetting exp, AutoscaleSetting act)
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
                Assert.Equal(exp.Default, act.Default);
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
                Assert.Equal(exp.MetricNamespace, act.MetricNamespace);
                Assert.Equal(exp.MetricResourceUri, act.MetricResourceUri);
                Assert.Equal(exp.Operator, act.Operator);
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
                Assert.Equal(exp.Type, act.Type);
                Assert.Equal(exp.Value, act.Value);
            }
        }
    }
}
