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
                Enabled = true,
                DisplayName = "SDKTest"
            };
            return data;
        }
        #endregion

        #region ActionResponseData
        public static void AssertActionResponseData(ActionResponseData data1, ActionResponseData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.LogicAppResourceId, data2?.LogicAppResourceId);
            Assert.AreEqual(data1.WorkflowId, data2.WorkflowId);
        }
        public static ActionResponseCreateOrUpdateContent GetActionResponseData(string resourcegroup)
        {
            var data = new ActionResponseCreateOrUpdateContent()
            {
                TriggerUri = new Uri("https://prod-21.westus2.logic.azure.com:443/workflows/e26c9f2e051e40eebaba9ed9b065c491/triggers/When_Azure_Sentinel_incident_creation_rule_was_triggered/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_Azure_Sentinel_incident_creation_rule_was_triggered%2Frun&sv=1.0&sig=6sGE8BueGEYWNZ0mY8-JYrse4mTk3obUBib9BF5PciQ"),
                LogicAppResourceId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/" + resourcegroup + "/providers/Microsoft.Logic/workflows/DotNetSDKTestsPlaybook"
            };
            return data;
        }
        #endregion

        #region AutomationRuleData
        public static void AssertAutomationRuleData(AutomationRuleData data1, AutomationRuleData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.DisplayName, data2.DisplayName);
            Assert.AreEqual(data1.Order, data2.Order);
            Assert.AreEqual(data1.LastModifiedTimeUtc, data2.LastModifiedTimeUtc);
        }
        public static AutomationRuleData GetAutomationRuleData(string resourcegroup)
        {
            var trigger = new AutomationRuleTriggeringLogic(false, TriggersOn.Incidents, TriggersWhen.Created);
            IEnumerable<AutomationRuleModifyPropertiesAction> action = new List<AutomationRuleModifyPropertiesAction>()
            {
                new AutomationRuleModifyPropertiesAction(1)
                {
                    ActionConfiguration = new IncidentPropertiesAction()
                    {
                        Labels =
                        {
                            new IncidentLabel("testlabel1")
                        }
                    }
                }
            };
            var data = new AutomationRuleData("SDK Test", 1, trigger, action)
            {
            };
            return data;
        }
        #endregion
        #region BookmarkData
        public static void AssertBookmarkData(BookmarkData data1, BookmarkData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.DisplayName, data2.DisplayName);
            Assert.AreEqual(data1.Notes, data2.Notes);
            Assert.AreEqual(data1.Query, data2.Query);
            Assert.AreEqual(data1.QueryResult, data2.QueryResult);
        }
        public static BookmarkData GetBookmarkData()
        {
            var data = new BookmarkData()
            {
                DisplayName = "SDKTestBookmark",
                Query = "SecurityEvent | take 10",
            };
            return data;
        }
        #endregion

        #region RelationData
        public static void AssertRelationData(IncidentRelationData data1, IncidentRelationData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.RelatedResourceName, data2.RelatedResourceName);
            Assert.AreEqual(data1.RelatedResourceId, data2.RelatedResourceId);
            Assert.AreEqual(data1.RelatedResourceKind, data2.RelatedResourceKind);
            Assert.AreEqual(data1.RelatedResourceType, data2.RelatedResourceType);
        }
        public static IncidentRelationData GetRelationData()
        {
            return new IncidentRelationData()
            {
            };
        }
        #endregion

        #region IncidentData
        public static void AssertIncidentData(IncidentData data1, IncidentData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Title, data2.Title);
            Assert.AreEqual(data1.Classification, data2.Classification);
            Assert.AreEqual(data1.Description, data2.Description);
            Assert.AreEqual(data1.ClassificationComment, data2.ClassificationComment);
        }
        public static IncidentData GetIncidentData()
        {
            var data = new IncidentData()
            {
                Title = "SDKCreateIncidentTest",
                Status = "Active",
                Severity = "Low"
            };
            return data;
        }
        #endregion

        #region DataConnectorData
        public static void AssertDataConnectorData(DataConnectorData data1, DataConnectorData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static DataConnectorData GetDataConnectorData()
        {
            var data = new ASCDataConnector()
            {
                SubscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c",
                DataTypes = new AlertsDataTypeOfDataConnector(new DataConnectorDataTypeCommon(DataTypeState.Enabled))
            };
            return data;
        }
        #endregion

        #region ThreatIntelligenceIndicatorData
        public static void AssertThreatIntelligenceIndicatorData(ThreatIntelligenceIndicatorData data1, ThreatIntelligenceIndicatorData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.DisplayName, data2.DisplayName);
            Assert.AreEqual(data1.Description, data2.Description);
            Assert.AreEqual(data1.Source, data2.Source);
            Assert.AreEqual(data1.FriendlyName, data2.FriendlyName);
            Assert.AreEqual(data1.Pattern, data2.Pattern);
        }
        public static ThreatIntelligenceIndicatorData GetThreatIntelligenceIndicatorData()
        {
            var data = new ThreatIntelligenceIndicatorData()
            {
                DisplayName = "SDK Test",
                PatternType = "ipv4-addr",
                Pattern = "[ipv4-addr:value = '1.1.1.2']",
                ThreatTypes =
                {
                    "unknown"
                },
                ValidFrom = DateTime.Now.ToString(),
                Source = "Azure Sentinel"
            };
            return data;
        }
        #endregion
        #region WatchlistItemData
        public static void AssertWatchlistItemData(WatchlistItemData data1, WatchlistItemData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.IsDeleted, data2.IsDeleted);
            Assert.AreEqual(data1.WatchlistItemId, data2.WatchlistItemId);
            Assert.AreEqual(data1.TenantId, data2.TenantId);
            Assert.AreEqual(data1.WatchlistItemType, data2.WatchlistItemType);
        }
        public static WatchlistItemData GetWatchlistItemData()
        {
            return new WatchlistItemData()
            {
                ItemsKeyValue = BinaryData.FromString("{\"ipaddress\":\"1.1.1.2\"}")
            };
        }
        #endregion

        #region WatchlistData
        public static void AssertWatchlistData(WatchlistData data1, WatchlistData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.IsDeleted, data2.IsDeleted);
            Assert.AreEqual(data1.Source, data2.Source);
            Assert.AreEqual(data1.TenantId, data2.TenantId);
            Assert.AreEqual(data1.Provider, data2.Provider);
        }
        public static WatchlistData GetWatchlistData()
        {
            var data = new WatchlistData()
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
        public static void AssertSentinelOnboardingStateData(SentinelOnboardingStateData data1, SentinelOnboardingStateData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.CustomerManagedKey, data2.CustomerManagedKey);
        }
        public static SentinelOnboardingStateData GetSentinelOnboardingStateData()
        {
            return new SentinelOnboardingStateData()
            {
                CustomerManagedKey = false,
            };
        }
        #endregion
    }
}
