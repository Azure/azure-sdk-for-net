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
    public class MetricAlertsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void CreateUpdateAlertRuleTest()
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


        private MetricAlertResource GetCreateOrUpdateRuleParameters()
        {
            MetricAlertSingleResourceMultipleMetricCriteria metricCriteria = new MetricAlertSingleResourceMultipleMetricCriteria(
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
    }

}

   
            
   

