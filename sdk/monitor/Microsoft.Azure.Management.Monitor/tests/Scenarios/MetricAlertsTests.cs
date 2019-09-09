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
        private const string MultiResResourceLevelRuleName = "MultiResResourceMetricAlert";
        private const string MultiResResourceGroupLevelRuleName = "MultiResRGMetricAlert";
        private const string MultiResSubscriptionLevelRuleName = "MultiResSubsMetricAlert";
        private const string DynamicRuleName = "DynamicMetricAlertSDKTestRule1";
        private const string MultiResResourceLevelDynamicRuleName = "MultiResResourceDynamicMetricAlert";
        private const string MultiResResourceGroupLevelDynamicRuleName = "MultiResRGMDynamicetricAlert";
        private const string MultiResSubscriptionLevelDynamicRuleName = "MultiResSubsDynamicMetricAlert";
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateMetricAlertRule(insightsClient);
                GetMetricAlertRule(insightsClient);
                DeleteMetricAlertRule(insightsClient);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void DynamicMetricAlertRuleFlow()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateDynamicMetricAlertRule(insightsClient);
                GetDynamicMetricAlertRule(insightsClient);
                DeleteDynamicMetricAlertRule(insightsClient);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void MultiResResourceLevelMetricAlertRuleFlow()
        {
            using(MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateMultiResResourceLevelMetricAlertRule(insightsClient);
                GetMultiResResourceLevelMetricAlertRule(insightsClient);
                DeleteMultiResResourceLevelMetricAlertRule(insightsClient);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void MultiResResourceLevelDynamicMetricAlertRuleFlow()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateMultiResResourceLevelDynamicMetricAlertRule(insightsClient);
                GetMultiResResourceLevelDynamicMetricAlertRule(insightsClient);
                DeleteMultiResResourceLevelDynamicMetricAlertRule(insightsClient);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        private void MultiResResourceGroupLevelMetricAlertRule()
        {
            using(MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateMultiResResourceGroupLevelMetricAlertRule(insightsClient);
                GetMultiResResourceGroupLevelMetricAlertRule(insightsClient);
                DeleteMultiResResourceGroupLevelMetricAlertRule(insightsClient);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        private void MultiResResourceGroupLevelDynamicMetricAlertRule()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateMultiResResourceGroupLevelDynamicMetricAlertRule(insightsClient);
                GetMultiResResourceGroupLevelDynamicMetricAlertRule(insightsClient);
                DeleteMultiResResourceGroupLevelDynamicMetricAlertRule(insightsClient);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        private void MultiResSubscriptionLevelMetricAlertRule()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateMultiResSubscriptionLevelMetricAlertRule(insightsClient);
                GetMultiResSubscriptionLevelMetricAlertRule(insightsClient);
                DeleteMultiResSubscriptionLevelMetricAlertRule(insightsClient);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        private void MultiResSubscriptionLevelDynamicMetricAlertRule()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                MonitorManagementClient insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: Location);

                CreateOrUpdateMultiResSubscriptionLevelDynamicMetricAlertRule(insightsClient);
                GetMultiResSubscriptionLevelDynamicMetricAlertRule(insightsClient);
                DeleteMultiResSubscriptionLevelDynamicMetricAlertRule(insightsClient);
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

        private void CreateOrUpdateDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateDynamicRuleParameters();
            MetricAlertResource result = insightsClient.MetricAlerts.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                ruleName: DynamicRuleName,
                parameters: expectedParameters);

            Utilities.AreEqual(expectedParameters, result);
        }

        private void CreateOrUpdateMultiResResourceLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResResourceLevelRuleParameters();
            MetricAlertResource result = insightsClient.MetricAlerts.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                ruleName: MultiResResourceLevelRuleName,
                parameters: expectedParameters
                );
            Utilities.AreEqual(expectedParameters, result);
        }

        private void CreateOrUpdateMultiResResourceLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResResourceLevelDynamicRuleParameters();
            MetricAlertResource result = insightsClient.MetricAlerts.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                ruleName: MultiResResourceLevelDynamicRuleName,
                parameters: expectedParameters
                );
            Utilities.AreEqual(expectedParameters, result);
        }

        private void CreateOrUpdateMultiResResourceGroupLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResResourceGroupLevelRuleParameters();
            MetricAlertResource result = insightsClient.MetricAlerts.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                ruleName: MultiResResourceGroupLevelRuleName,
                parameters: expectedParameters
            );
            Utilities.AreEqual(expectedParameters, result);
        }

        private void CreateOrUpdateMultiResResourceGroupLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResResourceGroupLevelDynamicRuleParameters();
            MetricAlertResource result = insightsClient.MetricAlerts.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                ruleName: MultiResResourceGroupLevelDynamicRuleName,
                parameters: expectedParameters
            );
            Utilities.AreEqual(expectedParameters, result);
        }

        private void CreateOrUpdateMultiResSubscriptionLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResSubscriptionLevelRuleParameters();
            MetricAlertResource result = insightsClient.MetricAlerts.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                ruleName: MultiResSubscriptionLevelRuleName,
                parameters: expectedParameters
            );
            Utilities.AreEqual(expectedParameters, result);
        }

        private void CreateOrUpdateMultiResSubscriptionLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResSubscriptionLevelDynamicRuleParameters();
            MetricAlertResource result = insightsClient.MetricAlerts.CreateOrUpdate(
                resourceGroupName: ResourceGroupName,
                ruleName: MultiResSubscriptionLevelDynamicRuleName,
                parameters: expectedParameters
            );
            Utilities.AreEqual(expectedParameters, result);
        }

        private void GetMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: RuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void GetDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateDynamicRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: DynamicRuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void GetMultiResResourceLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResResourceLevelRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: MultiResResourceLevelRuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void GetMultiResResourceLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResResourceLevelDynamicRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: MultiResResourceLevelDynamicRuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void GetMultiResResourceGroupLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResResourceGroupLevelRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: MultiResResourceGroupLevelRuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void GetMultiResResourceGroupLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResResourceGroupLevelDynamicRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: MultiResResourceGroupLevelDynamicRuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void GetMultiResSubscriptionLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResSubscriptionLevelRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: MultiResSubscriptionLevelRuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void GetMultiResSubscriptionLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            MetricAlertResource expectedParameters = GetCreateOrUpdateMultiResSubscriptionLevelDynamicRuleParameters();
            MetricAlertResource alertRule = insightsClient.MetricAlerts.Get(resourceGroupName: ResourceGroupName, ruleName: MultiResSubscriptionLevelDynamicRuleName);
            Utilities.AreEqual(expectedParameters, alertRule);
        }

        private void DeleteMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: RuleName);
        }

        private void DeleteDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: DynamicRuleName);
        }

        private void DeleteMultiResResourceLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: MultiResResourceLevelRuleName);
        }

        private void DeleteMultiResResourceLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: MultiResResourceLevelDynamicRuleName);
        }

        private void DeleteMultiResResourceGroupLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: MultiResResourceGroupLevelRuleName);
        }

        private void DeleteMultiResResourceGroupLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: MultiResResourceGroupLevelDynamicRuleName);
        }

        private void DeleteMultiResSubscriptionLevelMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: MultiResSubscriptionLevelRuleName);
        }

        private void DeleteMultiResSubscriptionLevelDynamicMetricAlertRule(MonitorManagementClient insightsClient)
        {
            insightsClient.MetricAlerts.Delete(resourceGroupName: ResourceGroupName, ruleName: MultiResSubscriptionLevelDynamicRuleName);
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

        private MetricAlertResource GetCreateOrUpdateDynamicRuleParameters()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>()
                {
                    new DynamicMetricCriteria
                    {
                        MetricName = "Transactions",
                        MetricNamespace = "Microsoft.Storage/storageAccounts",
                        Name = "metric1",
                        Dimensions = new MetricDimension[0],
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Total",
                        AlertSensitivity = "High",
                        IgnoreDataBefore = null,
                        FailingPeriods = new DynamicThresholdFailingPeriods()
                        {
                            MinFailingPeriodsToAlert = 4,
                            NumberOfEvaluationPeriods = 4
                        },
                    }
                }
            );

            return new MetricAlertResource(
                    description: " This is for Dynamic Metric Alert SDK Scenario Test",
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

        private MetricAlertResource GetCreateOrUpdateMultiResResourceLevelRuleParameters()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>()
                {
                    new MetricCriteria()
                    {
                        MetricName = "Percentage CPU",
                        MetricNamespace="microsoft.compute/virtualmachines",
                        Name = "metric1",
                        Dimensions = new MetricDimension[0],
                        Threshold = 100,
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Average",
                    }
                }
            );

            return new MetricAlertResource(
                description: " This is for Multi Resource Metric Alert SDK Scenario Test",
                severity: 3,
                location: "global",
                enabled: true,
                scopes: new List<string>()
                {
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2",
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo3"
                },
                targetResourceRegion: "southcentralus",
                targetResourceType: "Microsoft.Compute/virtualMachines",
                evaluationFrequency: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
                windowSize: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
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

        private MetricAlertResource GetCreateOrUpdateMultiResResourceLevelDynamicRuleParameters()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>()
                {
                    this.GetDynamicMetricCriteria()
                }
            );

            return new MetricAlertResource(
                description: " This is for Multi Resource Dynamic Metric Alert SDK Scenario Test",
                severity: 3,
                location: "global",
                enabled: true,
                scopes: new List<string>()
                {
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2",
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo3"
                },
                targetResourceRegion: "southcentralus",
                targetResourceType: "Microsoft.Compute/virtualMachines",
                evaluationFrequency: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
                windowSize: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
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

        private MetricAlertResource GetCreateOrUpdateMultiResResourceGroupLevelRuleParameters()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>()
                {
                    new MetricCriteria()
                    {
                        MetricName = "Percentage CPU",
                        MetricNamespace="microsoft.compute/virtualmachines",
                        Name = "metric1",
                        Dimensions = new MetricDimension[0],
                        Threshold = 100,
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Average",
                    }
                }
            );

            return new MetricAlertResource(
                description: " This is for Multi Resource Metric Alert SDK Scenario Test (ResourceGroup Level)",
                severity: 3,
                location: "global",
                enabled: true,
                scopes: new List<string>()
                {
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup",
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/RG2"

                },
                targetResourceRegion: "southcentralus",
                targetResourceType: "Microsoft.Compute/virtualMachines",
                evaluationFrequency: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
                windowSize: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
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

        private MetricAlertResource GetCreateOrUpdateMultiResResourceGroupLevelDynamicRuleParameters()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>()
                {
                    this.GetDynamicMetricCriteria()
                }
            );

            return new MetricAlertResource(
                description: " This is for Multi Resource Metric Alert SDK Scenario Test (ResourceGroup Level)",
                severity: 3,
                location: "global",
                enabled: true,
                scopes: new List<string>()
                {
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/SanjaychResourceGroup",
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/RG2"

                },
                targetResourceRegion: "southcentralus",
                targetResourceType: "Microsoft.Compute/virtualMachines",
                evaluationFrequency: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
                windowSize: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
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

        private MetricAlertResource GetCreateOrUpdateMultiResSubscriptionLevelRuleParameters()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>()
                {
                    new MetricCriteria()
                    {
                        MetricName = "Percentage CPU",
                        MetricNamespace="microsoft.compute/virtualmachines",
                        Name = "metric1",
                        Dimensions = new MetricDimension[0],
                        Threshold = 100,
                        OperatorProperty = "GreaterThan",
                        TimeAggregation = "Average",
                    }
                }
            );

            return new MetricAlertResource(
                description: " This is for Multi Resource Metric Alert SDK Scenario Test (ResourceGroup Level)",
                severity: 3,
                location: "global",
                enabled: true,
                scopes: new List<string>()
                {
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6"

                },
                targetResourceRegion: "southcentralus",
                targetResourceType: "Microsoft.Compute/virtualMachines",
                evaluationFrequency: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
                windowSize: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
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

        private MetricAlertResource GetCreateOrUpdateMultiResSubscriptionLevelDynamicRuleParameters()
        {
            MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = new MetricAlertMultipleResourceMultipleMetricCriteria(
                allOf: new List<MultiMetricCriteria>()
                {
                    this.GetDynamicMetricCriteria()
                }
            );

            return new MetricAlertResource(
                description: " This is for Multi Resource Metric Alert SDK Scenario Test (ResourceGroup Level)",
                severity: 3,
                location: "global",
                enabled: true,
                scopes: new List<string>()
                {
                    "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6"

                },
                targetResourceRegion: "southcentralus",
                targetResourceType: "Microsoft.Compute/virtualMachines",
                evaluationFrequency: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
                windowSize: new TimeSpan(hours: 0, minutes: 15, seconds: 0),
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

        private DynamicMetricCriteria GetDynamicMetricCriteria()
        {
            return new DynamicMetricCriteria()
            {
                MetricName = "Percentage CPU",
                MetricNamespace = "microsoft.compute/virtualmachines",
                Name = "metric1",
                Dimensions = new MetricDimension[0],
                OperatorProperty = "GreaterThan",
                AlertSensitivity = "High",
                IgnoreDataBefore = null,
                FailingPeriods = new DynamicThresholdFailingPeriods()
                {
                    MinFailingPeriodsToAlert = 4,
                    NumberOfEvaluationPeriods = 4
                },
                TimeAggregation = "Average",
            };
        }
    }
}
