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
            Assert.That(r2.Name, Is.EqualTo(r1.Name));
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
        }

        #region SecurityInsightsAlertRuleData
        public static void AssertSecurityInsightsAlertRuleData(SecurityInsightsAlertRuleData data1, SecurityInsightsAlertRuleData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
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
            Assert.That(data2.DisplayName, Is.EqualTo(data1.DisplayName));
            Assert.That(data2.Order, Is.EqualTo(data1.Order));
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
            Assert.That(data2.DisplayName, Is.EqualTo(data1.DisplayName));
            Assert.That(data2.Notes, Is.EqualTo(data1.Notes));
            Assert.That(data2.Query, Is.EqualTo(data1.Query));
            Assert.That(data2.QueryResult, Is.EqualTo(data1.QueryResult));
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
            Assert.That(data2.Title, Is.EqualTo(data1.Title));
            Assert.That(data2.Classification, Is.EqualTo(data1.Classification));
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.ClassificationComment, Is.EqualTo(data1.ClassificationComment));
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
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
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
            Assert.That(data2.IsDeleted, Is.EqualTo(data1.IsDeleted));
            Assert.That(data2.WatchlistItemId, Is.EqualTo(data1.WatchlistItemId));
            Assert.That(data2.TenantId, Is.EqualTo(data1.TenantId));
            Assert.That(data2.WatchlistItemType, Is.EqualTo(data1.WatchlistItemType));
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
            Assert.That(data2.IsDeleted, Is.EqualTo(data1.IsDeleted));
            Assert.That(data2.Source, Is.EqualTo(data1.Source));
            Assert.That(data2.TenantId, Is.EqualTo(data1.TenantId));
            Assert.That(data2.Provider, Is.EqualTo(data1.Provider));
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
            Assert.That(data2.IsCustomerManagedKeySet, Is.EqualTo(data1.IsCustomerManagedKeySet));
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
