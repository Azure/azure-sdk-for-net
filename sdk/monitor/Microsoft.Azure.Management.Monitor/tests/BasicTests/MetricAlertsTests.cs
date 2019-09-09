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
    public class MetricAlertsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void CreateUpdateMetricAlertRuleTest()
        {
            MetricAlertResource expectedParams = GetSampleMetricRuleResourceParams();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParams, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var result = insightClient.MetricAlerts.CreateOrUpdate(resourceGroupName: "rg1", ruleName: "Rule1", parameters: expectedParams);
            Utilities.AreEqual(expectedParams, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void CreateUpdateMultiResourceMetricAlertRuleTest()
        {
            MetricAlertResource expectedParams = GetSampleMultiResourceMetricRuleResourceParams();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParams, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var result = insightClient.MetricAlerts.CreateOrUpdate(resourceGroupName: "rg1", ruleName: "Rule2", parameters: expectedParams);
            Utilities.AreEqual(expectedParams, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void CreateUpdateDynamicMetricAlertRuleTest()
        {
            MetricAlertResource expectedParams = GetSampleDynamicMetricRuleResourceParams();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParams, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var result = insightClient.MetricAlerts.CreateOrUpdate(resourceGroupName: "rg1", ruleName: "Rule1", parameters: expectedParams);
            Utilities.AreEqual(expectedParams, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListMetricAlertRuleByResourceGroupTest()
        {
            var expectedResponseValue = GetSampleMetricAlertCollection();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedResponseValue, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var actualResponse = insightClient.MetricAlerts.ListByResourceGroup(resourceGroupName: "rg1");
            Utilities.AreEqual(expectedResponseValue, actualResponse.ToList<MetricAlertResource>());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void CreateUpdateDynamicMultiResourceMetricAlertRuleTest()
        {
            MetricAlertResource expectedParams = GetSampleMultiResourceDynamicMetricRuleResourceParams();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParams, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var result = insightClient.MetricAlerts.CreateOrUpdate(resourceGroupName: "rg1", ruleName: "Rule2", parameters: expectedParams);
            Utilities.AreEqual(expectedParams, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListMetricAlertsBySubscriptionTest()
        {
            var expectedResponseValue = GetSampleMetricAlertCollection();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedResponseValue, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var actualResponse = insightClient.MetricAlerts.ListBySubscription();
            Utilities.AreEqual(expectedResponseValue, actualResponse.ToList<MetricAlertResource>());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetMetricAlertStatusTest()
        {
            var expectedResponseValue = GetMetricAlertStatus();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedResponseValue, insightClient.SerializationSettings);

            var expcetedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expcetedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var actualResponse = insightClient.MetricAlertsStatus.List(resourceGroupName: "rg1", ruleName: "Rule1");
            Utilities.AreEqual(expectedResponseValue, actualResponse);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetMetricAlertTest()
        {
            MetricAlertResource expectedParams = GetSampleMetricRuleResourceParams();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParams, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var result = insightClient.MetricAlerts.Get(resourceGroupName: "rg1", ruleName: "Rule1");
            Utilities.AreEqual(expectedParams, result);
        }

        [Fact]
        [Trait("Category","Mock")]
        public void GetMultiResourceMetricAlertTest()
        {
            MetricAlertResource expectedParams = GetSampleMultiResourceMetricRuleResourceParams();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParams, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var result = insightClient.MetricAlerts.Get(resourceGroupName: "rg1", ruleName: "Rule1");
            Utilities.AreEqual(expectedParams, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetDynamicMetricAlertTest()
        {
            MetricAlertResource expectedParams = GetSampleDynamicMetricRuleResourceParams();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParams, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var result = insightClient.MetricAlerts.Get(resourceGroupName: "rg1", ruleName: "Rule1");
            Utilities.AreEqual(expectedParams, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetMultiResourceDynamicMetricAlertTest()
        {
            MetricAlertResource expectedParams = GetSampleMultiResourceDynamicMetricRuleResourceParams();
            var handler = new RecordedDelegatingHandler();
            var insightClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParams, insightClient.SerializationSettings);

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightClient = GetMonitorManagementClient(handler);

            var result = insightClient.MetricAlerts.Get(resourceGroupName: "rg1", ruleName: "Rule1");
            Utilities.AreEqual(expectedParams, result);
        }

        private MetricAlertStatusCollection GetMetricAlertStatus()
        {
            MetricAlertStatusProperties statusProps = new MetricAlertStatusProperties()
            {
                Dimensions = new Dictionary<string, string>(),
                Status = "Healthy",
                Timestamp = new System.DateTime()
            };

            return new MetricAlertStatusCollection()
            {
                Value = new List<MetricAlertStatus>()
                {
                    new MetricAlertStatus(properties: statusProps)
                }
            };
        }

        private List<MetricAlertResource> GetSampleMetricAlertCollection()
        {
            return new List<MetricAlertResource>()
            {
                 new MetricAlertResource(
                    description: "alert description",
                    severity: 3,
                    location: "Location",
                    enabled: true,
                    scopes: new List<string>()
                    {
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2"
                    },
                    evaluationFrequency: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    windowSize: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    criteria: GetSampleMetricCriteria(),
                    actions: new List<MetricAlertAction>()
                    {
                        new MetricAlertAction()
                        {
                            ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/custommetricdemo/providers/microsoft.insights/actiongroups/scactiongroup"
                        }
                    }
                ),
                 new MetricAlertResource(
                    description: "alert description",
                    severity: 3,
                    location: "global",
                    enabled: true,
                    targetResourceRegion: "southcentralus",
                    targetResourceType: "Microsoft.Compute/virtualMachines",
                    scopes: new List<string>()
                    {
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2",
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo3"
                    },
                    evaluationFrequency: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    windowSize: new TimeSpan(hours: 0, minutes: 5 ,seconds: 0),
                    criteria: GetSampleMultiResourceMetricCriteria(),
                    actions: new List<MetricAlertAction>()
                    {
                        new MetricAlertAction()
                    {
                        ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/default-activitylogalerts/providers/microsoft.insights/actiongroups/anashah"
                    }
                }),
                 new MetricAlertResource(
                    description: "alert description",
                    severity: 3,
                    location: "Location",
                    enabled: true,
                    scopes: new List<string>()
                    {
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2"
                    },
                    evaluationFrequency: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    windowSize: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    criteria: GetSampleDynamicMetricCriteria(),
                    actions: new List<MetricAlertAction>()
                    {
                        new MetricAlertAction()
                        {
                            ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/custommetricdemo/providers/microsoft.insights/actiongroups/scactiongroup"
                        }
                    }
                ),
                new MetricAlertResource(
                    description: "alert description",
                    severity: 3,
                    location: "global",
                    enabled: true,
                    targetResourceRegion: "southcentralus",
                    targetResourceType: "Microsoft.Compute/virtualMachines",
                    scopes: new List<string>()
                    {
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2",
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo3"
                    },
                    evaluationFrequency: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    windowSize: new TimeSpan(hours: 0, minutes: 5 ,seconds: 0),
                    criteria: GetSampleDynamicMetricCriteria(),
                    actions: new List<MetricAlertAction>()
                    {
                        new MetricAlertAction()
                    {
                        ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/default-activitylogalerts/providers/microsoft.insights/actiongroups/anashah"
                    }
                })
            };
        }

        private MetricAlertResource GetSampleMetricRuleResourceParams()
        {
            MetricAlertSingleResourceMultipleMetricCriteria metricCriteria = GetSampleMetricCriteria();

            return new MetricAlertResource(
                    description: "alert description",
                    severity: 3,
                    location: "Location",
                    enabled: true,
                    scopes: new List<string>()
                    {
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2"
                    },
                    evaluationFrequency: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    windowSize: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    criteria: metricCriteria,
                    actions: new List<MetricAlertAction>()
                    {
                        new MetricAlertAction()
                        {
                            ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/custommetricdemo/providers/microsoft.insights/actiongroups/scactiongroup"
                        }
                    }
                );
        }

        private MetricAlertResource GetSampleDynamicMetricRuleResourceParams()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = GetSampleDynamicMetricCriteria();

            return new MetricAlertResource(
                    description: "alert description",
                    severity: 3,
                    location: "Location",
                    enabled: true,
                    scopes: new List<string>()
                    {
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2"
                    },
                    evaluationFrequency: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    windowSize: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                    criteria: metricCriteria,
                    actions: new List<MetricAlertAction>()
                    {
                        new MetricAlertAction()
                        {
                            ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/custommetricdemo/providers/microsoft.insights/actiongroups/scactiongroup"
                        }
                    }
                );
        }

        private MetricAlertResource GetSampleMultiResourceMetricRuleResourceParams()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = GetSampleMultiResourceMetricCriteria();

            return new MetricAlertResource(
                description: "alert description",
                severity: 3,
                location: "global",
                enabled: true,
                targetResourceRegion: "southcentralus",
                targetResourceType: "Microsoft.Compute/virtualMachines",
                scopes: new List<string>()
                {
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2",
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo3"
                },
                evaluationFrequency: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                windowSize: new TimeSpan(hours: 0, minutes: 5 ,seconds: 0),
                criteria: metricCriteria,
                actions: new List<MetricAlertAction>()
                {
                    new MetricAlertAction()
                    {
                        ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/default-activitylogalerts/providers/microsoft.insights/actiongroups/anashah"
                    }
                }
            );
        }

        private MetricAlertResource GetSampleMultiResourceDynamicMetricRuleResourceParams()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = GetSampleDynamicMetricCriteria();

            return new MetricAlertResource(
                description: "alert description",
                severity: 3,
                location: "global",
                enabled: true,
                targetResourceRegion: "southcentralus",
                targetResourceType: "Microsoft.Compute/virtualMachines",
                scopes: new List<string>()
                {
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2",
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo3"
                },
                evaluationFrequency: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                windowSize: new TimeSpan(hours: 0, minutes: 5, seconds: 0),
                criteria: metricCriteria,
                actions: new List<MetricAlertAction>()
                {
                    new MetricAlertAction()
                    {
                        ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/default-activitylogalerts/providers/microsoft.insights/actiongroups/anashah"
                    }
                }
            );
        }

        private static MetricAlertSingleResourceMultipleMetricCriteria GetSampleMetricCriteria()
        {
            MetricDimension metricDimension = new MetricDimension()
            {
                Name = "name1",
                OperatorProperty = "Include",
                Values = new List<string>()
                {
                    "Primary"
                }
            };

            MetricDimension[] metricDimensions = new MetricDimension[1] { metricDimension };

            return new MetricAlertSingleResourceMultipleMetricCriteria(
                allOf: new List<MetricCriteria>()
                {
                    new MetricCriteria()
                    {
                        MetricName = "Metric Name",
                        Name = "metric1",
                        Dimensions = metricDimensions,
                        Threshold = 100,
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Avergage"
                    }
                }
            );
        }

        private static MetricAlertMultipleResourceMultipleMetricCriteria GetSampleDynamicMetricCriteria()
        {
            MetricDimension metricDimension = new MetricDimension()
            {
                Name = "name1",
                OperatorProperty = "Include",
                Values = new List<string>()
                {
                    "Primary"
                }
            };

            MetricDimension[] metricDimensions = new MetricDimension[1] { metricDimension };

            return new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>()
                {
                    new DynamicMetricCriteria()
                    {
                        MetricName = "Metric Name",
                        Name = "metric1",
                        Dimensions = metricDimensions,
                        MetricNamespace = "Namespace",
                        AlertSensitivity= "High",
                        IgnoreDataBefore = null,
                        FailingPeriods = new DynamicThresholdFailingPeriods()
                        {
                            MinFailingPeriodsToAlert = 4,
                            NumberOfEvaluationPeriods = 4
                        },
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Avergage"
                    }
                }
            ) ;
        }

        private static MetricAlertMultipleResourceMultipleMetricCriteria GetSampleMultiResourceMetricCriteria()
        {
            MetricDimension metricDimension = new MetricDimension()
            {
                Name = "name1",
                OperatorProperty = "Include",
                Values = new List<string>()
                {
                    "Primary"
                }
            };

            MetricDimension[] metricDimensions = new MetricDimension[1] { metricDimension };

            return new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>
                {
                    new MetricCriteria()
                    {
                        MetricName = "Metric Name",
                        Name = "metric1",
                        Dimensions = metricDimensions,
                        Threshold = 100,
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Avergage"
                    }
                }
           );
        }
    }
}

   
            
   

