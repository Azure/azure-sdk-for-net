// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Insights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests
{
    public static class AssertHelpers
    {
        public static void AreEqual(Incident exp, Incident act)
        {
            if (exp != null)
            {
                Assert.True(exp.ActivatedTime.HasValue);
                Assert.True(act.ActivatedTime.HasValue);
                Assert.AreEqual(exp.ActivatedTime.Value.ToUniversalTime(), act.ActivatedTime.Value.ToUniversalTime());
                Assert.AreEqual(exp.IsActive, act.IsActive);
                Assert.AreEqual(exp.Name, act.Name);

                Assert.True(exp.ResolvedTime.HasValue);
                Assert.True(act.ResolvedTime.HasValue);
                Assert.AreEqual(exp.ResolvedTime.Value.ToUniversalTime(), act.ResolvedTime.Value.ToUniversalTime());
                Assert.AreEqual(exp.RuleName, act.RuleName);
            }
        }

        public static void AreEqual(List<Incident> exp, IList<Incident> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(AlertRuleResource exp, AlertRuleResource act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Location, act.Location);
                AreEqual(exp.Tags, act.Tags);
                Assert.AreEqual(exp.Name, act.Name);
                Assert.AreEqual(exp.Description, act.Description);
                Assert.AreEqual(exp.IsEnabled, act.IsEnabled);
                AreEqual(exp.Condition, act.Condition);
                AreEqual(exp.Actions, act.Actions);
                //Assert.AreEqual(exp.LastUpdatedTime, act.LastUpdatedTime);
            }
        }

        public static void AreEqual(RuleCondition exp, RuleCondition act)
        {
            if (exp is LocationThresholdRuleCondition)
            {
                var expRuleCondition = exp as LocationThresholdRuleCondition;
                var actRuleCondition = act as LocationThresholdRuleCondition;

                AreEqual(expRuleCondition.DataSource, actRuleCondition.DataSource);
                Assert.AreEqual(expRuleCondition.FailedLocationCount, actRuleCondition.FailedLocationCount);
                Assert.AreEqual(expRuleCondition.WindowSize, actRuleCondition.WindowSize);
            }
        }

        public static void AreEqual(RuleDataSource exp, RuleDataSource act)
        {
            if (exp is RuleMetricDataSource)
            {
                var expMetricDataSource = exp as RuleMetricDataSource;
                var actMetricDataSource = act as RuleMetricDataSource;

                Assert.AreEqual(expMetricDataSource.MetricName, actMetricDataSource.MetricName);
                Assert.AreEqual(expMetricDataSource.ResourceUri, actMetricDataSource.ResourceUri);
            }
        }

        public static void AreEqual(IList<RuleAction> exp, IList<RuleAction> act)
        {
            Assert.NotNull(exp);
            Assert.NotNull(act);

            Assert.AreEqual(exp.Count, act.Count);

            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        public static void AreEqual(RuleAction exp, RuleAction act)
        {
            if (exp is RuleEmailAction)
            {
                var expEmailRuleAction = exp as RuleEmailAction;
                var actEmailRuleAction = act as RuleEmailAction;

                AreEqual(expEmailRuleAction.CustomEmails, actEmailRuleAction.CustomEmails);
                Assert.AreEqual(expEmailRuleAction.SendToServiceOwners, actEmailRuleAction.SendToServiceOwners);
            }
        }

        public static void AreEqual(IList<AlertRuleResource> exp, IList<AlertRuleResource> act)
        {
            if (exp != null)
            {
                Assert.True(exp.Count == act.Count);

                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(IDictionary<string, string> exp, IDictionary<string, string> act)
        {
            if (exp != null)
            {
                foreach (var key in exp.Keys)
                {
                    Assert.AreEqual(exp[key], act[key]);
                }
            }
        }

        public static void AreEqual(IList<string> exp, IList<string> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(IList<LocalizableString> exp, IList<LocalizableString> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.AreEqual(exp[i].LocalizedValue, act[i].LocalizedValue);
                    Assert.AreEqual(exp[i].Value, act[i].Value);
                }
            }
        }

        public static void AreEqual(IList<int> exp, IList<int> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(LocalizableString exp, LocalizableString act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.LocalizedValue, act.LocalizedValue);
                Assert.AreEqual(exp.Value, act.Value);
            }
        }
    }
}
