// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;

namespace Monitor.Tests.Helpers
{
    public static class Utilities
    {
        #region Autoscale
        public static void AreEqual(AutoscaleSettingResource exp, AutoscaleSettingResource act)
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
                Assert.Equal(exp.DefaultProperty, act.DefaultProperty);
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
                Assert.Equal(exp.MetricName, act.MetricName);
                Assert.Equal(exp.MetricResourceUri, act.MetricResourceUri);
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
                Assert.Equal(exp.Value, act.Value);
            }
        }
        #endregion 

        #region General
        public static void AreEqual(IList<string> exp, IList<string> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(IList<LocalizableString> exp, IList<LocalizableString> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i].LocalizedValue, act[i].LocalizedValue);
                    Assert.Equal(exp[i].Value, act[i].Value);
                }
            }
        }

        private static void AreEqual(IList<int> exp, IList<int> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(LocalizableString exp, LocalizableString act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.LocalizedValue, act.LocalizedValue);
                Assert.Equal(exp.Value, act.Value);
            }
        }

        public static void AreEqual(IDictionary<string, string> exp, IDictionary<string, string> act)
        {
            if (exp != null)
            {
                foreach (var key in exp.Keys)
                {
                    Assert.Equal(exp[key], act[key]);
                }
            }
        }
        #endregion

        #region AlertRules
        public static void AreEqual(Incident exp, Incident act)
        {
            if (exp != null)
            {
                Assert.True(exp.ActivatedTime.HasValue);
                Assert.True(act.ActivatedTime.HasValue);
                //Assert.Equal(exp.ActivatedTime.Value.ToUniversalTime(), act.ActivatedTime.Value.ToUniversalTime());
                //Assert.Equal(exp.IsActive, act.IsActive);
                Assert.Equal(exp.Name, act.Name);

                Assert.True(exp.ResolvedTime.HasValue);
                Assert.True(act.ResolvedTime.HasValue);
                //Assert.Equal(exp.ResolvedTime.Value.ToUniversalTime(), act.ResolvedTime.Value.ToUniversalTime());
                Assert.Equal(exp.RuleName, act.RuleName);
            }
        }

        public static void AreEqual(IList<Incident> exp, IList<Incident> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(List<Incident> exp, IList<Incident> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(IList<AlertRuleResource> exp, IList<AlertRuleResource> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    Utilities.AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(AlertRuleResource exp, AlertRuleResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Location, act.Location);
                AreEqual(exp.Tags, act.Tags);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.IsEnabled, act.IsEnabled);
                AreEqual(exp.Condition, act.Condition);
                AreEqual(exp.Actions, act.Actions);
                //Assert.Equal(exp.LastUpdatedTime, act.LastUpdatedTime);
            }
            else
            {
                Assert.Null(act);
            }
        }

        private static void AreEqual(RuleCondition exp, RuleCondition act)
        {
            if (exp is LocationThresholdRuleCondition)
            {
                var expRuleCondition = exp as LocationThresholdRuleCondition;
                var actRuleCondition = act as LocationThresholdRuleCondition;

                AreEqual(expRuleCondition.DataSource, actRuleCondition.DataSource);
                Assert.Equal(expRuleCondition.FailedLocationCount, actRuleCondition.FailedLocationCount);
                Assert.Equal(expRuleCondition.WindowSize, actRuleCondition.WindowSize);
            }
            else if (exp is ThresholdRuleCondition)
            {
                var expRuleCondition = exp as ThresholdRuleCondition;
                var actRuleCondition = act as ThresholdRuleCondition;

                AreEqual(expRuleCondition.DataSource, actRuleCondition.DataSource);
                Assert.Equal(expRuleCondition.Threshold, actRuleCondition.Threshold);
                Assert.Equal(expRuleCondition.OperatorProperty, actRuleCondition.OperatorProperty);
                Assert.Equal(expRuleCondition.TimeAggregation, actRuleCondition.TimeAggregation);
                Assert.Equal(expRuleCondition.WindowSize, actRuleCondition.WindowSize);
            }
        }

        private static void AreEqual(RuleDataSource exp, RuleDataSource act)
        {
            if (exp is RuleMetricDataSource)
            {
                var expMetricDataSource = exp as RuleMetricDataSource;
                var actMetricDataSource = act as RuleMetricDataSource;

                Assert.Equal(expMetricDataSource.MetricName, actMetricDataSource.MetricName);
                Assert.Equal(expMetricDataSource.ResourceUri, actMetricDataSource.ResourceUri);
            }
        }

        private static void AreEqual(IList<RuleAction> exp, IList<RuleAction> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private static void AreEqual(RuleAction exp, RuleAction act)
        {
            if (exp is RuleEmailAction)
            {
                var expEmailRuleAction = exp as RuleEmailAction;
                var actEmailRuleAction = act as RuleEmailAction;

                AreEqual(expEmailRuleAction.CustomEmails, actEmailRuleAction.CustomEmails);
                Assert.Equal(expEmailRuleAction.SendToServiceOwners, actEmailRuleAction.SendToServiceOwners);
            }
        }
        #endregion

        #region Action Groups

        public static void AreEqual(ActionGroupResource exp, ActionGroupResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.GroupShortName, act.GroupShortName);
                Assert.Equal(exp.Enabled, act.Enabled);
                AreEqual(exp.Tags, act.Tags);
                AreEqual(exp.EmailReceivers, act.EmailReceivers);
                AreEqual(exp.SmsReceivers, act.SmsReceivers);
                AreEqual(exp.WebhookReceivers, act.WebhookReceivers);
            }
        }

        private static void AreEqual(IList<EmailReceiver> exp, IList<EmailReceiver> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(IList<ActionGroupResource> exp, IList<ActionGroupResource> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private static void AreEqual(IList<SmsReceiver> exp, IList<SmsReceiver> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(IList<WebhookReceiver> exp, IList<WebhookReceiver> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(EmailReceiver exp, EmailReceiver act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.EmailAddress, act.EmailAddress);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Status, act.Status);
            }
        }

        private static void AreEqual(SmsReceiver exp, SmsReceiver act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.PhoneNumber, act.PhoneNumber);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Status, act.Status);
            }
        }

        private static void AreEqual(WebhookReceiver exp, WebhookReceiver act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ServiceUri, act.ServiceUri);
                Assert.Equal(exp.Name, act.Name);
            }
        }

        #endregion

        #region ActivityLogAlerts
        public static void AreEqual(ActivityLogAlertResource exp, ActivityLogAlertResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Enabled, act.Enabled);
                AreEqual(exp.Tags, act.Tags);
                AreEqual(exp.Scopes, act.Scopes);
                AreEqual(exp.Condition, act.Condition);
                AreEqual(exp.Actions, act.Actions);
            }
        }

        private static void AreEqual(IList<ActivityLogAlertResource> exp, IList<ActivityLogAlertResource> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.True(exp.Count == act.Count, "List of activities' lengths are different");
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(ActivityLogAlertAllOfCondition exp, ActivityLogAlertAllOfCondition act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.NotNull(act.AllOf);
                for (int i = 0; i < exp.AllOf.Count; i++)
                {
                    AreEqual(exp.AllOf[i], act.AllOf[i]);
                }
            }
        }

        private static void AreEqual(ActivityLogAlertActionList exp, ActivityLogAlertActionList act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.NotNull(act.ActionGroups);
                for (int i = 0; i < exp.ActionGroups.Count; i++)
                {
                    AreEqual(exp.ActionGroups[i], act.ActionGroups[i]);
                }
            }
        }

        private static void AreEqual(ActivityLogAlertActionGroup exp, ActivityLogAlertActionGroup act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ActionGroupId, act.ActionGroupId);
                Assert.Equal(exp.WebhookProperties, act.WebhookProperties);
            }
        }

        private static void AreEqual(ActivityLogAlertLeafCondition exp, ActivityLogAlertLeafCondition act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Field, act.Field);
                Assert.Equal(exp.Equals, act.Equals);
            }
        }

        #endregion

        #region LogProfiles
        public static void AreEqual(LogProfileResource exp, LogProfileResource act)
        {
            if (exp != null)
            {
                CompareListString(exp.Categories, act.Categories);
                CompareListString(exp.Locations, act.Locations);

                Assert.Equal(exp.RetentionPolicy.Enabled, act.RetentionPolicy.Enabled);
                Assert.Equal(exp.RetentionPolicy.Days, act.RetentionPolicy.Days);
                Assert.Equal(exp.ServiceBusRuleId, act.ServiceBusRuleId);
                Assert.Equal(exp.StorageAccountId, act.StorageAccountId);
            }
        }

        private static void CompareListString(IList<string> exp, IList<string> act)
        {
            if (exp == act)
            {
                return;
            }

            if (exp == null)
            {
                Assert.Null(act);
            }

            Assert.False(act == null, "List can't be null");

            for (int i = 0; i < exp.Count; i++)
            {
                if (i >= act.Count)
                {
                    Assert.Equal(exp.Count, act.Count);
                }

                string cat1 = exp[i];
                string cat2 = act[i];
                Assert.Equal(cat1, cat2);
            }

            Assert.Equal(exp.Count, act.Count);
        }
        #endregion

        #region ServiceDiagnosticsSettings
        public static void AreEqual(DiagnosticSettingsResource exp, DiagnosticSettingsResource act)
        {
            if (exp == act)
            {
                return;
            }

            if (exp == null)
            {
                Assert.Null(act);
            }

            Assert.False(act == null, "Actual value can't be null");

            CompareLists(exp.Logs, act.Logs);
            CompareLists(exp.Metrics, act.Metrics);

            Assert.Equal(exp.StorageAccountId, act.StorageAccountId);
            Assert.Equal(exp.WorkspaceId, act.WorkspaceId);
            Assert.Equal(exp.EventHubAuthorizationRuleId, act.EventHubAuthorizationRuleId);
        }

        private static void Compare<T>(T exp, T act)
        {
            Type t = typeof(T);
            if (t == typeof(LogSettings))
            {
                Compare(exp as LogSettings, act as LogSettings);
            }
            else if (t == typeof(LogSettings))
            {
                Compare(exp as MetricSettings, act as MetricSettings);
            }
        }

        private static void Compare(LogSettings exp, LogSettings act)
        {
            Assert.Equal(exp.Enabled, act.Enabled);
            Assert.Equal(exp.Category, act.Category);
            Compare(exp.RetentionPolicy, act.RetentionPolicy);
        }

        private static void Compare(RetentionPolicy exp, RetentionPolicy act)
        {
            Assert.Equal(exp.Enabled, act.Enabled);
            Assert.Equal(exp.Days, act.Days);
        }

        private static void CompareLists<T>(IList<T> exp, IList<T> act)
        {
            if (exp == act)
            {
                return;
            }

            if (exp == null)
            {
                Assert.True(act == null || act.Count == 0);
            }
            else
            {

                Assert.False(act == null, "Actual value can't be null");

                for (int i = 0; i < exp.Count; i++)
                {
                    if (i >= act.Count)
                    {
                        Assert.Equal(exp.Count, act.Count);
                    }

                    T cat1 = exp[i];
                    T cat2 = act[i];
                    Compare<T>(cat1, cat2);
                }

                Assert.Equal(exp.Count, act.Count);
            }
        }
        #endregion

        #region MetricAlerts
        public static void AreEqual(IList<MetricAlertResource> exp, IList<MetricAlertResource> act)
        {
            if(exp != null)
            {
                for(int i=0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(MetricAlertResource exp, MetricAlertResource act)
        {
            if(exp != null)
            {
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.Severity, act.Severity);
                Assert.Equal(exp.Enabled, act.Enabled);
                AreEqual(exp.Scopes, act.Scopes);
                Assert.Equal(exp.EvaluationFrequency, act.EvaluationFrequency);
                Assert.Equal(exp.WindowSize, act.WindowSize);
                AreEqual(exp.Criteria, act.Criteria);
                Assert.Equal(exp.AutoMitigate, act.AutoMitigate);
                AreEqual(exp.Actions, act.Actions);
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(IList<MetricAlertAction> exp, IList<MetricAlertAction> act)
        {
            if(exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(MetricAlertAction exp, MetricAlertAction act)
        {
            if(exp != null)
            {
                Assert.Equal(exp.ActionGroupId, act.ActionGroupId);
                AreEqual(exp.WebhookProperties, act.WebhookProperties);

            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(MetricAlertCriteria exp, MetricAlertCriteria act)
        {
            if(exp != null)
            {
                if (exp.GetType() == typeof(MetricAlertSingleResourceMultipleMetricCriteria))
                {
                    Compare(exp as MetricAlertSingleResourceMultipleMetricCriteria, act as MetricAlertSingleResourceMultipleMetricCriteria);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void Compare(MetricAlertSingleResourceMultipleMetricCriteria exp, MetricAlertSingleResourceMultipleMetricCriteria act)
        {
            if(exp != null)
            {
                for (int i = 0; i < exp.AllOf.Count; i++)
                {
                    AreEqual(exp.AllOf[i], act.AllOf[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(MetricCriteria exp, MetricCriteria act)
        {
            if(exp != null)
            {
                Assert.Equal(exp.MetricName, act.MetricName);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.MetricNamespace, act.MetricNamespace);
                AreEqual(exp.Dimensions, act.Dimensions);
                Assert.Equal(exp.OperatorProperty, act.OperatorProperty);
                Assert.Equal(exp.TimeAggregation, act.TimeAggregation);
                Assert.Equal(exp.Threshold, act.Threshold);
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(IList<MetricDimension> exp, IList<MetricDimension> act)
        {   
            if(exp != null)
            {
                for(int i = 0; i < exp.Count; i++ )
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(MetricDimension exp, MetricDimension act)
        {
            if(exp != null)
            {
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.OperatorProperty, act.OperatorProperty);
                AreEqual(exp.Values, act.Values);
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(MetricAlertStatusCollection exp, MetricAlertStatusCollection act)
        {
            if(exp != null)
            {
                for (int i = 0; i < exp.Value.Count; i++)
                {
                    AreEqual(exp.Value[i], act.Value[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(MetricAlertStatus exp, MetricAlertStatus act)
        {
            if(exp != null)
            {
                AreEqual(exp.Properties, act.Properties);
            }
            else
            {
                Assert.Null(act);
            }
        }

        public static void AreEqual(MetricAlertStatusProperties exp, MetricAlertStatusProperties act)
        {
            if(exp != null)
            {
                Assert.Equal(exp.Status, act.Status);
                AreEqual(exp.Dimensions, act.Dimensions);
            }
            else
            {
                Assert.Null(act);
            }
        }
        #endregion
    }
}
