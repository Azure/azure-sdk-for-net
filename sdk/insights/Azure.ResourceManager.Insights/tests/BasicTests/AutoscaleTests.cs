// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class AutoscaleTests : InsightsManagementClientMockedBase
    {
        public AutoscaleTests(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task CreateOrUpdateSettingTest()
        {
            AutoscaleSettingResource expResponse = CreateAutoscaleSetting(location: "East US", resourceUri: ResourceUri, metricName: "CpuPercentage");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
    'properties': {
        'profiles': [
            {
                'name': 'Profile2',
                'capacity': {
                    'minimum': '1',
                    'maximum': '100',
                    'default': '1'
                },
                'rules': [
                    {
                        'metricTrigger': {
                            'metricName': 'CpuPercentage',
                            'metricNamespace': null,
                            'metricResourceUri': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm',
                            'timeGrain': 'PT1M',
                            'statistic': 'Average',
                            'timeWindow': 'PT1H',
                            'timeAggregation': 'Maximum',
                            'operator': 'Equals',
                            'threshold': 80.0,
                            'dimensions': []
                        },
                        'scaleAction': {
                            'direction': 'Increase',
                            'type': 'ChangeCount',
                            'value': '10',
                            'cooldown': 'PT20M'
                        }
                    }
                ],
                'fixedDate': {
                    'timeZone': null,
                    'start': '2014-04-15T21:06:11.7882792+00:00',
                    'end': '2014-04-16T21:06:11.7882792+00:00'
                },
                'recurrence': {
                    'frequency': 'Week',
                    'schedule': {
                        'timeZone': 'UTC-11',
                        'days': [
                            'Monday'
                        ],
                        'hours': [
                            0
                        ],
                        'minutes': [
                            10
                        ]
                    }
                }
            }
        ],
        'notifications': [],
        'enabled': true,
        'targetResourceUri': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm'
    },
    'id': null,
    'name': 'setting1',
    'type': null,
    'location': '',
    'tags': {}
}".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var actualResponse = (await insightsClient.AutoscaleSettings.CreateOrUpdateAsync(resourceGroupName: "resourceGroup1", autoscaleSettingName: "setting1", parameters: expResponse)).Value;
            AreEqual(expResponse, actualResponse);
        }

        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";
        [Test]
        public async Task Autoscale_GetSetting()
        {
            var expResponse = CreateAutoscaleSetting(ResourceUri, "CpuPercentage", string.Empty);
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
    'properties': {
        'profiles': [
            {
                'name': 'Profile2',
                'capacity': {
                    'minimum': '1',
                    'maximum': '100',
                    'default': '1'
                },
                'rules': [
                    {
                        'metricTrigger': {
                            'metricName': '',
                            'metricNamespace': null,
                            'metricResourceUri': 'CpuPercentage',
                            'timeGrain': 'PT1M',
                            'statistic': 'Average',
                            'timeWindow': 'PT1H',
                            'timeAggregation': 'Maximum',
                            'operator': 'Equals',
                            'threshold': 80.0,
                            'dimensions': []
                        },
                        'scaleAction': {
                            'direction': 'Increase',
                            'type': 'ChangeCount',
                            'value': '10',
                            'cooldown': 'PT20M'
                        }
                    }
                ],
                'fixedDate': {
                    'timeZone': null,
                    'start': '2014-04-15T21:06:11.7882792+00:00',
                    'end': '2014-04-16T21:06:11.7882792+00:00'
                },
                'recurrence': {
                    'frequency': 'Week',
                    'schedule': {
                        'timeZone': 'UTC-11',
                        'days': [
                            'Monday'
                        ],
                        'hours': [
                            0
                        ],
                        'minutes': [
                            10
                        ]
                    }
                }
            }
        ],
        'notifications': [],
        'enabled': true,
        'targetResourceUri': 'CpuPercentage'
    },
    'id': null,
    'name': 'setting1',
    'type': null,
    'location': '',
    'tags': {}
}
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            AutoscaleSettingResource actualResponse =(await insightsClient.AutoscaleSettings.GetAsync(resourceGroupName: "resourceGroup1", autoscaleSettingName: "setting1")).Value;
            AreEqual(expResponse, actualResponse);
        }

        [Test]
        public async Task AutoscaleSettingsDeleteTest()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            await insightsClient.AutoscaleSettings.DeleteAsync("rg1", "AutoscaleSettings1");
        }

        [Test]
        public async Task AutoscaleSettingsListByResourceGroupTest()
        {
            var AutoscaleSettingResourceList = new List<AutoscaleSettingResource>()
            {
                CreateAutoscaleSetting(location: "East US", resourceUri: ResourceUri, metricName: "CpuPercentage")
            };
            var content = @"{
'value':[{'properties': {
        'profiles': [
            {
                'name': 'Profile2',
                'capacity': {
                    'minimum': '1',
                    'maximum': '100',
                    'default': '1'
                },
                'rules': [
                    {
                        'metricTrigger': {
                            'metricName': 'CpuPercentage',
                            'metricNamespace': null,
                            'metricResourceUri': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm',
                            'timeGrain': 'PT1M',
                            'statistic': 'Average',
                            'timeWindow': 'PT1H',
                            'timeAggregation': 'Maximum',
                            'operator': 'Equals',
                            'threshold': 80.0,
                            'dimensions': []
                        },
                        'scaleAction': {
                            'direction': 'Increase',
                            'type': 'ChangeCount',
                            'value': '10',
                            'cooldown': 'PT20M'
                        }
                    }
                ],
                'fixedDate': {
                    'timeZone': null,
                    'start': '2014-04-15T21:06:11.7882792+00:00',
                    'end': '2014-04-16T21:06:11.7882792+00:00'
                },
                'recurrence': {
                    'frequency': 'Week',
                    'schedule': {
                        'timeZone': 'UTC-11',
                        'days': [
                            'Monday'
                        ],
                        'hours': [
                            0
                        ],
                        'minutes': [
                            10
                        ]
                    }
                }
            }
        ],
        'notifications': [],
        'enabled': true,
        'targetResourceUri': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm'
    },
    'id': null,
    'name': 'setting1',
    'type': null,
    'location': '',
    'tags': {}}]
}
            ".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.AutoscaleSettings.ListByResourceGroupAsync("rg1").ToEnumerableAsync();
            AreEqual(AutoscaleSettingResourceList, result);
        }

        [Test]
        public async Task AutoscaleSettingsListBySubscriptionTest()
        {
            var AutoscaleSettingResourceList = new List<AutoscaleSettingResource>()
            {
                CreateAutoscaleSetting(location: "East US", resourceUri: ResourceUri, metricName: "CpuPercentage")
            };
            var content = @"{
'value':[{'properties': {
        'profiles': [
            {
                'name': 'Profile2',
                'capacity': {
                    'minimum': '1',
                    'maximum': '100',
                    'default': '1'
                },
                'rules': [
                    {
                        'metricTrigger': {
                            'metricName': 'CpuPercentage',
                            'metricNamespace': null,
                            'metricResourceUri': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm',
                            'timeGrain': 'PT1M',
                            'statistic': 'Average',
                            'timeWindow': 'PT1H',
                            'timeAggregation': 'Maximum',
                            'operator': 'Equals',
                            'threshold': 80.0,
                            'dimensions': []
                        },
                        'scaleAction': {
                            'direction': 'Increase',
                            'type': 'ChangeCount',
                            'value': '10',
                            'cooldown': 'PT20M'
                        }
                    }
                ],
                'fixedDate': {
                    'timeZone': null,
                    'start': '2014-04-15T21:06:11.7882792+00:00',
                    'end': '2014-04-16T21:06:11.7882792+00:00'
                },
                'recurrence': {
                    'frequency': 'Week',
                    'schedule': {
                        'timeZone': 'UTC-11',
                        'days': [
                            'Monday'
                        ],
                        'hours': [
                            0
                        ],
                        'minutes': [
                            10
                        ]
                    }
                }
            }
        ],
        'notifications': [],
        'enabled': true,
        'targetResourceUri': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm'
    },
    'id': null,
    'name': 'setting1',
    'type': null,
    'location': '',
    'tags': {}}]
}
            ".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.AutoscaleSettings.ListBySubscriptionAsync().ToEnumerableAsync();
            AreEqual(AutoscaleSettingResourceList, result);
        }

        private static AutoscaleSettingResource CreateAutoscaleSetting(string location, string resourceUri, string metricName)
        {
            var capacity = new ScaleCapacity("1","100", "1");

            var fixedDate = new TimeWindow(DateTime.Parse("2014-04-15T21:06:11.7882792Z"), DateTime.Parse("2014-04-16T21:06:11.7882792Z"));

            var recurrence = new Recurrence(RecurrenceFrequency.Week, new RecurrentSchedule("UTC-11",new List<string> { "Monday" },new List<int> { 0 },new List<int> { 10}));

            var rules = new ScaleRule[]
            {
                new ScaleRule(new MetricTrigger(
                    metricName,resourceUri,TimeSpan.FromMinutes(1),MetricStatisticType.Average,TimeSpan.FromHours(1),TimeAggregationType.Maximum,ComparisonOperationType.EqualsValue,threshold:80.0),
                new ScaleAction(ScaleDirection.Increase,ScaleType.ChangeCount,"10",cooldown:TimeSpan.FromMinutes(20))
                )
            };

            AutoscaleSettingResource setting = new AutoscaleSettingResource(null, "setting1", null, "", new Dictionary<string,string>(),
                new AutoscaleProfile[]
                    {
                        //There may have one issue
                        //new AutoscaleProfile("Profile1",capacity,rules,fixedDate,recurrence),
                        new AutoscaleProfile("Profile2",capacity,rules,fixedDate,recurrence)
                    },new List<AutoscaleNotification>(), true, "setting1", resourceUri);
            return setting;
        }

        private void AreEqual(List<AutoscaleSettingResource> exp, IList<AutoscaleSettingResource> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private static void AreEqual(AutoscaleSettingResource exp, AutoscaleSettingResource act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Enabled, act.Enabled);
                Assert.AreEqual(exp.Name, act.Name);
                Assert.AreEqual(exp.TargetResourceUri, act.TargetResourceUri);

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
                Assert.AreEqual(exp.Name, act.Name);
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
                Assert.AreEqual(exp.End.ToUniversalTime(), act.End.ToUniversalTime());
                Assert.AreEqual(exp.Start.ToUniversalTime(), act.Start.ToUniversalTime());
                Assert.AreEqual(exp.TimeZone, act.TimeZone);
            }
        }

        private static void AreEqual(ScaleCapacity exp, ScaleCapacity act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Maximum, act.Maximum);
                Assert.AreEqual(exp.Minimum, act.Minimum);
            }
        }

        private static void AreEqual(Recurrence exp, Recurrence act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Frequency, act.Frequency);
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
                Assert.AreEqual(exp.TimeZone, act.TimeZone);
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
                Assert.AreEqual(exp.MetricName, act.MetricName);
                Assert.AreEqual(exp.MetricResourceUri, act.MetricResourceUri);
                Assert.AreEqual(exp.Statistic, act.Statistic);
                Assert.AreEqual(exp.Threshold, act.Threshold);
                Assert.AreEqual(exp.TimeAggregation, act.TimeAggregation);
                Assert.AreEqual(exp.TimeGrain, act.TimeGrain);
                Assert.AreEqual(exp.TimeWindow, act.TimeWindow);
            }
        }

        private static void AreEqual(ScaleAction exp, ScaleAction act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Cooldown, act.Cooldown);
                Assert.AreEqual(exp.Direction, act.Direction);
                Assert.AreEqual(exp.Value, act.Value);
            }
        }
    }
}
