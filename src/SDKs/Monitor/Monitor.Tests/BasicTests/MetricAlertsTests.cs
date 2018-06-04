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
            MetricAlertResource expectedParams = GetCreateOrUpdateRuleParameters();
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
            var expectedResponseValue = GetMetricAlertCollection();
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
        public void ListMetricAlertsBySubscriptionTest()
        {
            var expectedResponseValue = GetMetricAlertCollection();
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

        private List<MetricAlertResource> GetMetricAlertCollection()
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
                    criteria: GetMetricCriteria(),
                    actions: new List<Microsoft.Azure.Management.Monitor.Models.Action>()
                    {
                        new Microsoft.Azure.Management.Monitor.Models.Action()
                        {
                            ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/custommetricdemo/providers/microsoft.insights/actiongroups/scactiongroup"
                        }
                    }
                )
            };
        }

        private MetricAlertResource GetCreateOrUpdateRuleParameters()
        {
            MetricAlertSingleResourceMultipleMetricCriteria metricCriteria = GetMetricCriteria();

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
                    actions: new List<Microsoft.Azure.Management.Monitor.Models.Action>()
                    {
                        new Microsoft.Azure.Management.Monitor.Models.Action()
                        {
                            ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/custommetricdemo/providers/microsoft.insights/actiongroups/scactiongroup"
                        }
                    }
                );
        }

        private static MetricAlertSingleResourceMultipleMetricCriteria GetMetricCriteria()
        {
            return new MetricAlertSingleResourceMultipleMetricCriteria(
                allOf: new List<MetricCriteria>()
                {
                    new MetricCriteria()
                    {
                        MetricName = "Metric Name",
                        Name = "metric1",
                        Dimensions = new MetricDimension[0],
                        Threshold = 100,
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Avergage"
                    }
                }
            );
        }
    }
}

   
            
   

