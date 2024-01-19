// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework.Models;
using System.Linq;
using NUnit.Framework;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement.Tests.Helpers
{
    public class AlertsManagementTestUtilities
    {
        public static void AreEqual(AlertProcessingRuleData exp, AlertProcessingRuleData act)
        {
            if (exp != null)
            {
                if (exp.Properties.Description != null && act.Properties.Description != null)
                {
                    Assert.Equals(exp.Properties.Description, act.Properties.Description);
                }

                if (exp.Properties.IsEnabled != null && act.Properties.IsEnabled != null)
                {
                    Assert.AreEqual(exp.Properties.IsEnabled, act.Properties.IsEnabled);
                }

                AreEqual(exp.Properties.Scopes, act.Properties.Scopes);
                AreEqual(exp.Properties.Conditions, act.Properties.Conditions);
            }
        }

        public static void AreEqual(IList<string> exp, IList<string> act)
        {
            if (exp != null && act != null)
            {
                Assert.AreEqual(exp.Count, act.Count);

                foreach (var value in exp)
                {
                    Assert.Contains(value, (System.Collections.ICollection)act);
                }
            }
        }

        public static void AreEqual(IList<AlertProcessingRuleCondition> exp, IList<AlertProcessingRuleCondition> act)
        {
            if (exp != null)
            {
                Assert.False(exp == null || act == null);
                Assert.AreEqual(exp.Count, act.Count);
                foreach (AlertProcessingRuleCondition actCond in act)
                {
                    AlertProcessingRuleCondition expCond = exp.Where(condition => condition.Field.Equals(actCond.Field)).FirstOrDefault();
                    AreEqual(actCond, expCond);
                }
            }
        }

        public static void AreEqual(AlertProcessingRuleCondition exp, AlertProcessingRuleCondition act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Field, act.Field);
                Assert.AreEqual(exp.Operator, act.Operator);
            }
        }
    }
}
