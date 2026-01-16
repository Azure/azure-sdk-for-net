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
                    Assert.That(act.Properties.IsEnabled, Is.EqualTo(exp.Properties.IsEnabled));
                }

                AreEqual(exp.Properties.Scopes, act.Properties.Scopes);
                AreEqual(exp.Properties.Conditions, act.Properties.Conditions);
            }
        }

        public static void AreEqual(IList<string> exp, IList<string> act)
        {
            if (exp != null && act != null)
            {
                Assert.That(act.Count, Is.EqualTo(exp.Count));

                foreach (var value in exp)
                {
                    Assert.That((System.Collections.ICollection)act, Does.Contain(value));
                }
            }
        }

        public static void AreEqual(IList<AlertProcessingRuleCondition> exp, IList<AlertProcessingRuleCondition> act)
        {
            if (exp != null)
            {
                Assert.That(exp == null || act == null, Is.False);
                Assert.That(act.Count, Is.EqualTo(exp.Count));
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
                Assert.That(act.Field, Is.EqualTo(exp.Field));
                Assert.That(act.Operator, Is.EqualTo(exp.Operator));
            }
        }
    }
}
