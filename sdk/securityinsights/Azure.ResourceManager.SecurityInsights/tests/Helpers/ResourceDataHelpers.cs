// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using System.IO;

namespace Azure.ResourceManager.SecurityInsights.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region SecurityInsightsAlertRuleData
        public static void AssertSecurityInsightsAlertRuleData(SecurityInsightsAlertRuleData data1, SecurityInsightsAlertRuleData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static SecurityInsightsAlertRuleData GetSecurityInsightsAlertRuleData()
        {
            var data = new MicrosoftSecurityIncidentCreationAlertRule()
            {
                ProductFilter = "Microsoft Cloud App Security",
                IsEnabled = true,
                DisplayName = "SDKTest"
            };
            return data;
        }
        #endregion

        #region AutomationRuleData
        public static void AssertAutomationRuleData(SecurityInsightsAutomationRuleData data1, SecurityInsightsAutomationRuleData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.DisplayName, data2.DisplayName);
            Assert.AreEqual(data1.Order, data2.Order);
        }
        public static SecurityInsightsAutomationRuleData GetAutomationRuleData(string resourcegroup)
        {
            var trigger = new SecurityInsightsAutomationRuleTriggeringLogic(false, TriggersOn.Incidents, TriggersWhen.Created);
            IEnumerable<AutomationRuleModifyPropertiesAction> action = new List<AutomationRuleModifyPropertiesAction>()
            {
                new AutomationRuleModifyPropertiesAction(1)
                {
                    ActionConfiguration = new SecurityInsightsIncidentActionConfiguration()
                    {
                        Labels =
                        {
                            new SecurityInsightsIncidentLabel("testlabel1")
                        }
                    }
                }
            };
            var data = new SecurityInsightsAutomationRuleData("SDK Test", 1, trigger, action)
            {
            };
            return data;
        }
        #endregion
        #region BookmarkData
        public static void AssertBookmarkData(SecurityInsightsBookmarkData data1, SecurityInsightsBookmarkData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.DisplayName, data2.DisplayName);
            Assert.AreEqual(data1.Notes, data2.Notes);
            Assert.AreEqual(data1.Query, data2.Query);
            Assert.AreEqual(data1.QueryResult, data2.QueryResult);
        }
        public static SecurityInsightsBookmarkData GetBookmarkData()
        {
            var data = new SecurityInsightsBookmarkData()
            {
                DisplayName = "SDKTestBookmark",
                Query = "SecurityEvent | take 10",
            };
            return data;
        }
        #endregion

        #region IncidentData
        public static void AssertIncidentData(SecurityInsightsIncidentData data1, SecurityInsightsIncidentData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Title, data2.Title);
            Assert.AreEqual(data1.Classification, data2.Classification);
            Assert.AreEqual(data1.Description, data2.Description);
            Assert.AreEqual(data1.ClassificationComment, data2.ClassificationComment);
        }
        public static SecurityInsightsIncidentData GetIncidentData()
        {
            var data = new SecurityInsightsIncidentData()
            {
                Title = "SDKCreateIncidentTest",
                Status = "Active",
                Severity = "Low"
            };
            return data;
        }
        #endregion

        #region DataConnectorData
        public static void AssertDataConnectorData(SecurityInsightsDataConnectorData data1, SecurityInsightsDataConnectorData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static SecurityInsightsDataConnectorData GetDataConnectorData()
        {
            var data = new SecurityInsightsAscDataConnector()
            {
                SubscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c",
                AlertsState = SecurityInsightsDataTypeConnectionState.Enabled
            };
            return data;
        }
        #endregion

        #region ThreatIntelligenceIndicatorData
        public static void AssertThreatIntelligenceIndicatorData(SecurityInsightsThreatIntelligenceIndicatorBaseData data1, SecurityInsightsThreatIntelligenceIndicatorBaseData data2)
        {
            AssertResource(data1, data2);
        }
        public static SecurityInsightsThreatIntelligenceIndicatorData GetThreatIntelligenceIndicatorData()
        {
            var data = new SecurityInsightsThreatIntelligenceIndicatorData()
            {
                DisplayName = "SDK Test",
                PatternType = "ipv4-addr",
                Pattern = "[ipv4-addr:value = '1.1.1.2']",
                ThreatTypes =
                {
                    "unknown"
                },
                ValidFrom = DateTime.Now,
                Source = "Azure Sentinel"
            };
            return data;
        }
        #endregion
        #region WatchlistItemData
        public static void AssertWatchlistItemData(SecurityInsightsWatchlistItemData data1, SecurityInsightsWatchlistItemData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.IsDeleted, data2.IsDeleted);
            Assert.AreEqual(data1.WatchlistItemId, data2.WatchlistItemId);
            Assert.AreEqual(data1.TenantId, data2.TenantId);
            Assert.AreEqual(data1.WatchlistItemType, data2.WatchlistItemType);
        }
        public static SecurityInsightsWatchlistItemData GetWatchlistItemData()
        {
            return new SecurityInsightsWatchlistItemData()
            {
                ItemsKeyValueDictionary = { { "ipaddress", BinaryData.FromString("\"1.1.1.2\"")} }
            };
        }
        #endregion

        #region WatchlistData
        public static void AssertWatchlistData(SecurityInsightsWatchlistData data1, SecurityInsightsWatchlistData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.IsDeleted, data2.IsDeleted);
            Assert.AreEqual(data1.Source, data2.Source);
            Assert.AreEqual(data1.TenantId, data2.TenantId);
            Assert.AreEqual(data1.Provider, data2.Provider);
        }
        public static SecurityInsightsWatchlistData GetWatchlistData()
        {
            var data = new SecurityInsightsWatchlistData()
            {
                DisplayName = "SDK Test",
                Provider = "SDK Test",
                Source = "sdktest",
                ItemsSearchKey = "ipaddress"
            };
            return data;
        }
        #endregion

        #region SentinelOnboardingStateData
        public static void AssertSentinelOnboardingStateData(SecurityInsightsSentinelOnboardingStateData data1, SecurityInsightsSentinelOnboardingStateData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.IsCustomerManagedKeySet, data2.IsCustomerManagedKeySet);
        }
        public static SecurityInsightsSentinelOnboardingStateData GetSentinelOnboardingStateData()
        {
            return new SecurityInsightsSentinelOnboardingStateData()
            {
                IsCustomerManagedKeySet = false,
            };
        }
        #endregion
    }
}
