// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using System.Globalization;

namespace Monitor.Tests.Scenarios
{
    public class MetricAlertsTests : TestBase
    {
        private const string ResourceGroupName = "SanjaychResourceGroup";
        private const string RuleName = "MetricAlertSDKTestRule1";
        private const string ResourceId = "/subscriptions/{0}/resourceGroups/" + ResourceGroupName + "/providers/microsoft.insights/metricAlerts/" + RuleName;
        private const string Location = "southcentralus";

        private RecordedDelegatingHandler handler;

        public MetricAlertsTests() : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void MetricAlertRuleFlow()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateMetricAlertRule(insightsClient);
                GetMetricAlertRule(insightsClient);
                DeleteMetricAlertRule(insightsClient);
            }
        }

        private void CreateOrUpdateMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateRuleParameters();
            MetricAlertResource result = insightsClient.MetricAlerts.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                ruleName: RuleName,
                parameters: expectedParameters);

            Utilities.AreEqual(expectedParameters, result);
        }

        private void GetMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: RuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void DeleteMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: RuleName);
        }

        private MetricAlertResource GetCreateOrUpdateRuleParameters()
        {
            MetricAlertSingleResourceMultipleMetricCriteria metricCriteria = new MetricAlertSingleResourceMultipleMetricCriteria(
                allOf: new List<MetricCriteria>()
                {
                    new MetricCriteria()
                    {
                        MetricName = "Transactions",
                        MetricNamespace="Microsoft.Storage/storageAccounts",
                        Name = "metric1",
                        Dimensions = new MetricDimension[0],
                        Threshold = 100,
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Total",
                        
                    }
                }
            );

            return new MetricAlertResource(
                    description: " This is for Metric Alert SDK Scenario Test",
                    severity: 3,
                    location: "global",
                    enabled: true,
                    scopes: new List<string>()
                    {
                        "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Storage/storageAccounts/metricalertsdktestacc"
                    },
                    evaluationFrequency: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
                    windowSize: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
                    criteria: metricCriteria,
                    actions: new List<MetricAlertAction>()
                    {
                        new MetricAlertAction()
                        {
                            ActionGroupId = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/sanjaychresourcegroup/providers/microsoft.insights/actiongroups/scnewactiongroup"
                        }
                    }
                );
        }

    }
}
