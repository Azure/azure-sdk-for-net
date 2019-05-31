// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace AlertsManagement.Tests.Helpers
{
    public class ComparisonUtility
    {
        #region Alerts Test
        public static void AreEqual(IList<Alert> exp, IList<Alert> act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(Alert exp, Alert act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                AreEqual(exp.Properties.Essentials, act.Properties.Essentials);
            }
        }

        public static void AreEqual(Essentials exp, Essentials act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Severity, act.Severity);
                Assert.Equal(exp.SignalType, act.SignalType);
                Assert.Equal(exp.AlertState, act.AlertState);
                Assert.Equal(exp.MonitorCondition, act.MonitorCondition);
                Assert.Equal(exp.TargetResource, act.TargetResource);
                Assert.Equal(exp.TargetResourceGroup, act.TargetResourceGroup);
                Assert.Equal(exp.TargetResourceName, act.TargetResourceName);
                Assert.Equal(exp.MonitorService, act.MonitorService);
                Assert.Equal(exp.SourceCreatedId, act.SourceCreatedId);
                Assert.Equal(exp.SmartGroupId, act.SmartGroupId);
                Assert.Equal(exp.SmartGroupingReason, act.SmartGroupingReason);
                Assert.Equal(exp.StartDateTime, act.StartDateTime);
                Assert.Equal(exp.LastModifiedDateTime, act.LastModifiedDateTime);
                Assert.Equal(exp.LastModifiedUserName, act.LastModifiedUserName);
            }
        }

        public static void AreEqual(IList<AlertModificationItem> exp, IList<AlertModificationItem> act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(AlertModificationItem exp, AlertModificationItem act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ModificationEvent, act.ModificationEvent);
                Assert.Equal(exp.NewValue, act.NewValue);
                Assert.Equal(exp.OldValue, act.OldValue);
            }
        }

        public static void AreEqual(AlertsSummaryGroup exp, AlertsSummaryGroup act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Total, act.Total);
                Assert.Equal(exp.SmartGroupsCount, act.SmartGroupsCount);
                Assert.Equal(exp.Groupedby, act.Groupedby);
                AreEqual(exp.Values, act.Values);
            }
        }

        public static void AreEqual(IList<AlertsSummaryGroupItem> exp, IList<AlertsSummaryGroupItem> act)
        {
            if (exp == null && act == null)
            {
                return;
            }
            if (exp != null)
            {
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(AlertsSummaryGroupItem exp, AlertsSummaryGroupItem act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Count, act.Count);
                Assert.Equal(exp.Groupedby, act.Groupedby);
                AreEqual(exp.Values, act.Values);
            }
        }

        #endregion

        #region Smart Groups Tests
        /*
        public static void AreEqual(SmartGroupsList exp, SmartGroupsList act)
        {
            if (exp != null)
            {
                AreEqual(exp.Value, act.Value);
            }
        }*/

        public static void AreEqual(IList<SmartGroup> exp, IList<SmartGroup> act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(SmartGroup exp, SmartGroup act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.AlertsCount, act.AlertsCount);
                Assert.Equal(exp.SmartGroupState, act.SmartGroupState);
                Assert.Equal(exp.Severity, act.Severity);
                Assert.Equal(exp.StartDateTime, act.StartDateTime);
                Assert.Equal(exp.LastModifiedDateTime, act.LastModifiedDateTime);
                Assert.Equal(exp.LastModifiedUserName, act.LastModifiedUserName);
            }
        }

        public static void AreEqual(IList<SmartGroupModificationItem> exp, IList<SmartGroupModificationItem> act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(SmartGroupModificationItem exp, SmartGroupModificationItem act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ModificationEvent, act.ModificationEvent);
                Assert.Equal(exp.NewValue, act.NewValue);
                Assert.Equal(exp.OldValue, act.OldValue);
            }
        }
        #endregion

        #region Operations Tests
        public static void AreEqual(IList<Operation> exp, IList<Operation> act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        public static void AreEqual(Operation exp, Operation act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Display.Operation, act.Display.Operation);
                Assert.Equal(exp.Display.Resource, act.Display.Resource);
                Assert.Equal(exp.Display.Provider, act.Display.Provider);
                Assert.Equal(exp.Display.Description, act.Display.Description);
            }
        }
        #endregion

        #region Extraction Methods

        public static string ExtractIdFromLocalPath(string localPath)
        {
            return localPath.Split("/")[6];
        }

        public static string ExtractStateFromQuery(string query)
        {
            return query.Split("&")[1].Split("=")[1];
        }
        #endregion
    }
}
