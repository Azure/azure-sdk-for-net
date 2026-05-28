// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Monitor.Tests
{
    public static class ResourceDataHelper
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        // Temporary solution since the one in Azure.ResourceManager.Monitor is internal
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }
        #region ActionGroup
        public static void AssertActionGroup(ActionGroupData group1, ActionGroupData group2)
        {
            AssertTrackedResource(group1, group2);
            Assert.AreEqual(group1.AzureFunctionReceivers, group2.AzureFunctionReceivers);
        }

        public static ActionGroupData GetBasicActionGroupData(AzureLocation location)
        {
            var data = new ActionGroupData(location)
            {
                EmailReceivers =
                {
                    new MonitorEmailReceiver("name", "a@b.c")
                },
                IsEnabled = true,
                GroupShortName = "name"
            };
            return data;
        }
        #endregion

        #region ActivityLogAlert
        public static void AssertActivityLogAlert(ActivityLogAlertData data1, ActivityLogAlertData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.Description, data2.Description);
        }

        public static ActivityLogAlertData GetBasicActivityLogAlertData(AzureLocation location, string subID)
        {
            var data = new ActivityLogAlertData(location)
            {
                Scopes =
                {
                    subID
                },
                ConditionAllOf = new List<ActivityLogAlertAnyOfOrLeafCondition>()
                {
                    new()
                    {
                        Field = "category",
                        EqualsValue = "Administrative"
                    },
                    new()
                    {
                        Field = "level",
                        EqualsValue = "Error"
                    }
                }
            };
            return data;
        }
        #endregion

        #region AlertRule
        public static void AssertAlertRule(AlertRuleData data1, AlertRuleData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.Description, data2.Description);
        }

        public static AlertRuleData GetBasicAlertRuleData(AzureLocation location)
        {
            var ruleWebhookAction = new RuleWebhookAction()
            {
                ServiceUri = new Uri("https://www.contoso.com/alerts?type=HighCPU"),
                Properties = { new KeyValuePair<string, string>("key1", "value1") }
            };
            //RuleMetricDataSource ruleDataSource = new RuleMetricDataSource(
            //    "Microsoft.Azure.Management.Insights.Models.RuleMetricDataSource",
            //    "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/Default-EventHub-1375/providers/Microsoft.EventHub/namespaces/sdk-eventhub-Namespace-8280",
            //    "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/Default-EventHub-1375/providers/microsoft.insights/metricalerts/testAlertRule",
            //    "global",
            //    "Microsoft.EventHub/namespaces",
            //    "ActiveConnections");
            RuleMetricDataSource ruleDataSource = new RuleMetricDataSource()
            {
                //LegacyResourceId = "",
                MetricName = "testrulemetric",
                MetricNamespace = "Microsoft.Compute/virtualMachines",
                ResourceLocation = location,
                ResourceId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/deleteme0122/providers/Microsoft.Compute/virtualMachines/MetricAlertActionTestVM01")
            };
            //var ruleCondition = new ThresholdRuleCondition(
            //    "Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria",
            //    ruleDataSource,
            //    ConditionOperator.GreaterThan,
            //    3.0,
            //    TimeSpan.FromMinutes(15),
            //    TimeAggregationOperator.Average);
            var ruleCondition = new ThresholdRuleCondition(MonitorConditionOperator.GreaterThan, 3.0)
            {
                WindowSize = TimeSpan.FromMinutes(15),
                TimeAggregation = ThresholdRuleConditionTimeAggregationType.Average,
                DataSource = ruleDataSource
            };
            var data = new AlertRuleData(location, "testAlertRule", true, ruleCondition)
            {
                Actions = { ruleWebhookAction }
            };
            return data;
        }
        #endregion

        #region AutoscaleSetting
        public static void AssertAutoscaleSetting(AutoscaleSettingData setting1, AutoscaleSettingData setting2)
        {
            AssertTrackedResource(setting1, setting2);
            Assert.AreEqual(setting1.AutoscaleSettingName, setting2.AutoscaleSettingName);
        }

        public static AutoscaleSettingData GetBasicAutoscaleSettingData(AzureLocation location)
        {
            var fixDate = new MonitorTimeWindow(DateTime.Parse("2014-04-15T21:06:11.7882792Z"), DateTime.Parse("2014-04-15T21:06:11.7882792Z"))
            {
                TimeZone = "UTC"
            };
            var Schedule = new RecurrentSchedule("UTC-11", new MonitorDayOfWeek[] { "Monday" }, new[] { 0 }, new[] { 10 });
            var recurrence = new MonitorRecurrence(RecurrenceFrequency.Week, Schedule);
            var scaleCapacity = new MonitorScaleCapacity(1, 1, 1);
            var metricTrigger = new MetricTrigger("AbandonMessage", new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892"), TimeSpan.FromMinutes(1), MetricStatisticType.Average, TimeSpan.FromMinutes(10), MetricTriggerTimeAggregationType.Average, MetricTriggerComparisonOperation.GreaterThan, 70)
            {
                MetricNamespace = "microsoft.servicebus/namespaces",
                MetricResourceLocation = AzureLocation.EastUS2,
                IsDividedPerInstance = false
            };
            var rules = new List<AutoscaleRule>()
                {
                    new(
                        metricTrigger,
                        new MonitorScaleAction(MonitorScaleDirection.Increase, MonitorScaleType.ServiceAllowedNextValue, TimeSpan.FromMinutes(5)) { Value = "1" }
                    )
                };
            var profiles = new List<AutoscaleProfile>()
                {
                    //new AutoscaleProfile("Profiles2", scaleCapacity, rules)
                    new AutoscaleProfile("Profiles2", scaleCapacity, rules, fixDate, null, null),
                    new AutoscaleProfile("Profiles3", scaleCapacity, rules,null, recurrence, null),
                };
            var data = new AutoscaleSettingData(location, profiles)
            {
                IsEnabled = true,
                TargetResourceLocation = location,
                TargetResourceId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892"),
                /*Notifications =
                {
                    new AutoscaleNotification()
                    {
                        Operation = "Scale",
                        Email = new EmailNotification()
                        {
                            SendToSubscriptionAdministrator = true,
                            SendToSubscriptionCoAdministrators = true,
                            CustomEmails =
                            {
                                "gu@ms.com",
                                "ge@ns.net"
                            }
                        },
                        Webhooks =
                        {
                            new WebhookNotification()
                            {
                                ServiceUri = "http://myservice.com",
                                Properties = {}
                            }
                        }
                    },
                },*/
                Tags = { },
            };
            return data;
        }
        #endregion

        #region DiagnosticSettings
        public static void AssertDiagnosticSetting(DiagnosticSettingData data1, DiagnosticSettingData data2)
        {
            //AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.Id, data2.Id);
            Assert.AreEqual(data1.Name, data2.Name);
        }

        public static DiagnosticSettingData GetBasicDiagnosticSettingsData()
        {
            var data = new DiagnosticSettingData()
            {
                StorageAccountId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/lockformonitor/providers/Microsoft.Storage/storageAccounts/testaccountforlog2"),
                //ServiceBusRuleId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892/AuthorizationRules/testfordiagnostic",
                //EventHubAuthorizationRuleId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/Default-EventHub-1375/providers/Microsoft.EventHub/namespaces/sdk-eventhub-Namespace-8280/eventhubs/testfordiagnosticsetting/authorizationRules/testfordiagonst",
                //EventHubName = "myeventhub",
                //WorkspaceId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/default-eventhub-1375/providers/microsoft.operationalinsights/workspaces/myworkspace",
                LogAnalyticsDestinationType = "Dedicated",
                Metrics =
                {
                    new MetricSettings(true)
                {
                    Category = "WorkflowMetrics",
                    RetentionPolicy = new RetentionPolicy(false, 0),
                }
                },
                Logs =
                {
                    new LogSettings(true)
                {
                    Category = "Alert",
                    RetentionPolicy= new RetentionPolicy(false, 0)
                }
                }
            };
            //var data = new DiagnosticSettingsData(ResourceIdentifier.Root, "mysetting", "Microsoft.Insights/diagnosticSettings", "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/teststorageRG-5335/providers/Microsoft.Storage/storageAccounts/teststoragemgmt8010", "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892", "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/default-eventhub-1375/providers/microsoft.eventhub/namespaces/testnamespacemgmt1412", "myeventhub", metricSettings, logSettings, "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c", "Dedicated");
            return data;
        }
        #endregion

        #region LogProfile
        public static void AssertLogProfile(LogProfileData data1, LogProfileData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.ServiceBusRuleId, data2.ServiceBusRuleId);
        }

        public static LogProfileData GetBasicLogProfileData(AzureLocation location)
        {
            var locations = new List<AzureLocation>()
            {
                "global",
                "eastus"
            };
            var categories = new List<string>()
            {
                "Delete",
                "write"
            };
            RetentionPolicy retentionPolicy = new RetentionPolicy(true, 4);
            var data = new LogProfileData(location, locations, categories, retentionPolicy)
            {
                //ServiceBusRuleId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892",
                StorageAccountId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/deleteme0122/providers/Microsoft.Storage/storageAccounts/testlogaccount0129")
            };
            return data;
        }
        #endregion

        #region MetricAlert
        public static void AssertMetricAlert(MetricAlertData data1, MetricAlertData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.Description, data2.Description);
        }

        public static MetricAlertData GetBasicMetricAlertData(AzureLocation location, ActionGroupResource actionGroup, string storageAccountId)
        {
            IEnumerable<string> scopes = new List<string>()
            {
                storageAccountId,
                // "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/deleteme0122/providers/Microsoft.Compute/virtualMachines/MetricAlertActionTestVM02"
            };
            var metricAlertAction = new MetricAlertAction()
            {
                ActionGroupId = actionGroup.Id,
                WebHookProperties = { new KeyValuePair<string, string>("key1", "value1") }
            };
            var metricCriteria = new MetricCriteria("High_CPU_80", "Transactions", MetricCriteriaTimeAggregationType.Total, MetricCriteriaOperator.GreaterThan, 80.50) { };
            return new MetricAlertData(
                location,
                3,
                true,
                scopes,
                new TimeSpan(0, 1, 0),
                new TimeSpan(0, 5, 0),
                new MetricAlertSingleResourceMultipleMetricCriteria() { AllOf = { metricCriteria } })
            { Actions = { metricAlertAction } };
        }
        #endregion

        #region storage account
        public static StorageAccountData GetStorageAccountData()
        {
            var data = new StorageAccountData(AzureLocation.EastUS)
            {
            };
            return data;
        }
        public static StorageAccountCreateOrUpdateContent GetContent()
        {
            var content = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.BlobStorage, AzureLocation.EastUS)
            {
                AccessTier = StorageAccountAccessTier.Hot
            };
            return content;
        }
        #endregion
    }
}
