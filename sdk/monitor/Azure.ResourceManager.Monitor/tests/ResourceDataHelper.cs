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
        public static void AssertActivityLogAlert(ActivityLogAlertData alert1, ActivityLogAlertData alert2)
        {
            AssertTrackedResource(alert1, alert2);
            Assert.AreEqual(alert1.Description, alert2.Description);
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
        public static void AssertAlertRule(AlertRuleData alert1, AlertRuleData alert2)
        {
            AssertTrackedResource(alert1, alert2);
            Assert.AreEqual(alert1.Description, alert2.Description);
        }

        public static AlertRuleData GetBasicAlertRuleData(AzureLocation location)
        {
            RuleDataSource ruleDataSource = new RuleDataSource()
            {
                ResourceUri = "resUri1",
                MetricNamespace = "CpuPercentage"
            };
            var ruleCondition = new RuleCondition()
            {
                DataSource = ruleDataSource,
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
            var fixDate = new TimeWindow(DateTime.Parse("2014-04-15T21:06:11.7882792Z"), DateTime.Parse("2014-04-15T21:06:11.7882792Z"));
            var Schedule = new RecurrentSchedule("UTC-11", new List<string> { "Monday" }, new List<int> { 0 }, new List<int> { 10 });
            var recurrence = new Recurrence(RecurrenceFrequency.Week, Schedule);
            ScaleCapacity scaleCapacity = new ScaleCapacity("1", "100", "1");
            IEnumerable<ScaleRule> rules = new List<ScaleRule>()
            {
                new ScaleRule(new MetricTrigger("CpuPercentage", "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm", TimeSpan.FromMinutes(1), MetricStatisticType.Average, TimeSpan.FromHours(1), TimeAggregationType.Maximum, ComparisonOperationType.NotEquals, 80.0), new ScaleAction(ScaleDirection.Increase, ScaleType.ServiceAllowedNextValue, TimeSpan.FromMinutes(20)))
            };
            IEnumerable<AutoscaleProfile> profiles = new List<AutoscaleProfile>()
            {
                new AutoscaleProfile("Profiles1", scaleCapacity, rules),
                //new AutoscaleProfile("Profiles2", scaleCapacity, rules, fixDate, null),
            };
            var data = new AutoscaleSettingData(location, profiles)
            {
            };
            return data;
        }
        #endregion
    }
}
