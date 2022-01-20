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

namespace Azure.ResourceManager.Monitor.Tests
{
    public static class ResourceDataHelper
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        // Temporary solution since the one in Azure.ResourceManager.AppService is internal
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertTrackedResource(TrackedResource r1, TrackedResource r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.Type, r2.Type);
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
                    new EmailReceiver("name", "a@b.c")
                },
                Enabled = true,
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
            IEnumerable<ActivityLogAlertLeafCondition> allOf;
            allOf = new List<ActivityLogAlertLeafCondition>()
            {
                new ActivityLogAlertLeafCondition( "category", "Administrative"),
                new ActivityLogAlertLeafCondition( "level", "Error")
            };
            var data = new ActivityLogAlertData(location)
            {
                Scopes =
                {
                    subID
                },
                Condition = new ActivityLogAlertAllOfCondition(allOf),
                Actions =
                {
                    ActionGroups = {}
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

        public static AlertRuleData GetBasicAlertRuleData(AzureLocation location, string subID)
        {
            RuleDataSource ruleDataSource = new RuleMetricDataSource("Microsoft.Azure.Management.Insights.Models.RuleMetricDataSource", subID, "id", location, "CpuPercentage", "Requests");
            {
                //ResourceUri = subID,
                //MetricNamespace = "CpuPercentage",
                //OdataType = "Microsoft.Azure.Management.Insights.Models.RuleMetricDataSource",
            };
            var ruleCondition = new ThresholdRuleCondition(ConditionOperator.GreaterThan, 3.0)
            {
                DataSource = ruleDataSource,
                OdataType = "Microsoft.Azure.Management.Insights.Models.ThresholdRuleCondition",
                WindowSize = TimeSpan.FromMinutes(5),
                TimeAggregation = TimeAggregationOperator.Total,
            };
            var data = new AlertRuleData(location, "alertRule", true, ruleCondition)
            {
            };
            return data;
        }
        #endregion

        #region AutoscaleSetting
        public static void AssertAutoscaleSetting(AutoscaleSettingData setting1, AutoscaleSettingData setting2)
        {
            AssertTrackedResource(setting1, setting2);
            Assert.AreEqual(setting1.NamePropertiesName, setting2.NamePropertiesName);
        }

        public static AutoscaleSettingData GetBasicAutoscaleSettingData(AzureLocation location)
        {
            var fixDate = new TimeWindow("UTC", DateTime.Parse("2014-04-15T21:06:11.7882792Z"), DateTime.Parse("2014-04-15T21:06:11.7882792Z"));
            var Schedule = new RecurrentSchedule("UTC-11", new List<string> { "Monday" }, new List<int> { 0 }, new List<int> { 10 });
            var recurrence = new Recurrence(RecurrenceFrequency.Week, Schedule);
            ScaleCapacity scaleCapacity = new ScaleCapacity("1", "1", "1");
            IEnumerable<ScaleRule> rules = new List<ScaleRule>()
            {
                new ScaleRule(new MetricTrigger("CpuPercentage", "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892", TimeSpan.FromMinutes(1), MetricStatisticType.Average, TimeSpan.FromHours(1), TimeAggregationType.Maximum, ComparisonOperationType.GreaterThan, 80.0), new ScaleAction(ScaleDirection.Increase, ScaleType.ChangeCount, "1", TimeSpan.FromMinutes(20)))
            };
            IEnumerable<AutoscaleProfile> profiles = new List<AutoscaleProfile>()
            {
                //new AutoscaleProfile("Profiles1", scaleCapacity, rules),
                new AutoscaleProfile("Profiles2", scaleCapacity, rules)
                {
                    FixedDate = fixDate,
                    //Recurrence = recurrence,
                },
                new AutoscaleProfile("Profiles3", scaleCapacity, rules)
                {
                    Recurrence = recurrence,
                    FixedDate = null,
                },
            };
            var data = new AutoscaleSettingData(location, profiles)
            {
                Enabled = true,
                TargetResourceLocation = location,
                TargetResourceUri = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892",
                Notifications =
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
                },
                Tags = {},
            };
            return data;
        }
        #endregion

        #region DiagnosticSettings
        public static void AssertDiagnosticSetting(DiagnosticSettingsData data1, DiagnosticSettingsData data2)
        {
            //AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.Id, data2.Id);
            Assert.AreEqual(data1.Name, data2.Name);
        }

        public static DiagnosticSettingsData GetBasicDiagnosticSettingsData()
        {
            IList<MetricSettings> metricSettings = new List<MetricSettings>()
            {
                new MetricSettings(true)
                {
                    Category = "WorkflowMetrics",
                    RetentionPolicy = new RetentionPolicy(false, 0),
                }
            };
            IList<LogSettings> logSettings = new List<LogSettings>()
            {
                new LogSettings(true)
                {
                    Category = "allLogs",
                    RetentionPolicy= new RetentionPolicy(false, 0)
                }
            };
            //var data = new DiagnosticSettingsData();
            var data = new DiagnosticSettingsData(ResourceIdentifier.Root, "mysetting", "", "", "", "", "myeventhub", metricSettings, logSettings, "WsId", "Dedicated");
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
            IEnumerable<string> locations = new List<string>()
            {
                "global",
                "eastus"
            };
            IEnumerable<string> categories = new List<string>()
            {
                "Delete",
                "write"
            };
            RetentionPolicy retentionPolicy = new RetentionPolicy(true, 4);
            var data = new LogProfileData(location, locations, categories, retentionPolicy)
            {
                ServiceBusRuleId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892",
                //StorageAccountId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/teststorageRG-6327/providers/Microsoft.Storage/storageAccounts/teststoragemgmt2325"
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

        public static MetricAlertData GetBasicMetricAlertData(AzureLocation location, string subID)
        {
            IEnumerable<string> scopes = new List<string>()
            {
                "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo2",
                "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/SanjaychResourceGroup/providers/Microsoft.Compute/virtualMachines/SCCMDemo3"
            };

            var data = new MetricAlertData(location, 3, true, scopes, new TimeSpan(0, 5, 0), new TimeSpan(0, 5, 0), null)
            {
            };
            return data;
        }
        #endregion
    }
}
