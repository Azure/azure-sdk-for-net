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
using ContentType = Azure.ResourceManager.SecurityInsights.Models.ContentType;
using NUnit.Framework.Internal;

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
        public static ActionResponseCreateOrUpdateContent GetActionResponseData()
        {
            var data = new ActionResponseCreateOrUpdateContent()
            {
                TriggerUri = new Uri("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/deleteme1018/providers/Microsoft.Logic/workflows/DotNetSDKTestsPlaybook"),
                LogicAppResourceId = "https://prod-21.westus2.logic.azure.com:443/workflows/e26c9f2e051e40eebaba9ed9b065c491/triggers/When_Azure_Sentinel_incident_creation_rule_was_triggered/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_Azure_Sentinel_incident_creation_rule_was_triggered%2Frun&sv=1.0&sig=6sGE8BueGEYWNZ0mY8-JYrse4mTk3obUBib9BF5PciQ"
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
        public static AutomationRuleData GetAutomationRuleData()
        {
            var trigger = new AutomationRuleTriggeringLogic(false, TriggersOn.Alerts, TriggersWhen.Created);
            IEnumerable<AutomationRuleRunPlaybookAction> action = new List<AutomationRuleRunPlaybookAction>()
            {
                new AutomationRuleRunPlaybookAction(1)
                {
                    ActionConfiguration = new PlaybookActionProperties()
                    {
                        LogicAppResourceId = "/subscriptions/9023f5b5-df22-4313-8fbf-b4b75af8a6d9/resourceGroups/asi-sdk-tests-rg/providers/Microsoft.Logic/workflows/DotNetSDKTestsPlaybook",
                        TenantId = Guid.Parse("d23e3eef-eed0-428f-a2d5-bc48c268e31d")
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
                EventOn = DateTimeOffset.Now
            };
            return data;
        }
        #endregion

        #region RelationData
        public static void AssertRelationData(RelationData data1, RelationData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.RelatedResourceName, data2.RelatedResourceName);
            Assert.AreEqual(data1.RelatedResourceId, data2.RelatedResourceId);
            Assert.AreEqual(data1.RelatedResourceKind, data2.RelatedResourceKind);
            Assert.AreEqual(data1.RelatedResourceType, data2.RelatedResourceType);
        }
        public static RelationData GetRelationData()
        {
            return new RelationData()
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
        public static DataConnectorData GetDataConnectorData(string defaultSubscription)
        {
            var data = new ASCDataConnector()
            {
                Alerts = new DataConnectorDataTypeCommon(DataTypeState.Enabled),
                SubscriptionId = defaultSubscription
            };
            return data;
        }
        #endregion
        #region EntityQueryData
        public static void AssertEntityQueryData(EntityQueryData data1, EntityQueryData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static EntityQueryCreateOrUpdateContent GetEntityQueryData()
        {
            var data = new ActivityCustomEntityQuery()
            {
                Title = "The user consented to OAuth application",
                InputEntityType = "Account",
                Content = "The user consented to the OAuth application named {{Target_CloudApplication_Name}} {{Count}} time(s)",
                Description = "This activity lists user's consents to an OAuth applications.",
                QueryDefinitions = new ActivityEntityQueriesPropertiesQueryDefinitions()
                {
                    Query = "let UserConsentToApplication = (Account_Name:string, Account_UPNSuffix:string, Account_AadUserId:string){\nlet account_upn = iff(Account_Name != \"\" and Account_UPNSuffix != \"\"\n, strcat(Account_Name,\"@\",Account_UPNSuffix)\n,\"\" );\nAuditLogs\n| where OperationName == \"Consent to application\"\n| extend Source_Account_UPNSuffix = tostring(todynamic(InitiatedBy) [\"user\"][\"userPrincipalName\"]), Source_Account_AadUserId = tostring(todynamic(InitiatedBy) [\"user\"][\"id\"])\n| where (account_upn != \"\" and account_upn =~ Source_Account_UPNSuffix) \nor (Account_AadUserId != \"\" and Account_AadUserId =~ Source_Account_AadUserId)\n| extend Target_CloudApplication_Name = tostring(todynamic(TargetResources)[0][\"displayName\"]), Target_CloudApplication_AppId = tostring(todynamic(TargetResources)[0][\"id\"])\n};\nUserConsentToApplication('{{Account_Name}}', '{{Account_UPNSuffix}}', '{{Account_AadUserId}}')  \n| project Target_CloudApplication_AppId, Target_CloudApplication_Name, TimeGenerated"
                },
                RequiredInputFieldsSets =
                {
                    new List<string>()
                    {
                        "Account_AadUserId"
                    },
                    new List<string>()
                    {
                        "Account_Name",
                        "Account_UPNSuffix"
                    }
                }
            };
            return data;
        }
        #endregion
        #region MetadataModelData
        public static void AssertMetadataModelData(MetadataModelData data1, MetadataModelData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ContentId, data2.ContentId);
            Assert.AreEqual(data1.ParentId, data2.ParentId);
            Assert.AreEqual(data1.Version, data2.Version);
            Assert.AreEqual(data1.Icon, data2.Icon);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static MetadataModelData GetMetadataModelData(string defaultSubscription, string resourceGroup, string workspaceName)
        {
            var data = new MetadataModelData()
            {
                Kind = SecurityInsightsKind.AnalyticsRule,
                ParentId = defaultSubscription + "/resourceGroups/"+ resourceGroup + "/providers/" + "Microsoft.OperationalInsights" + "/workspaces/" + workspaceName + "/providers/Microsoft.SecurityInsights/alertRules/" + Guid.NewGuid().ToString(),
                ContentId = Guid.NewGuid().ToString(),
            };
            return data;
        }
        #endregion
        #region SettingData
        public static void AssertSettingData(SettingData data1, SettingData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static SettingData GetSettingData()
        {
            var data = new Ueba()
            {
                DataSources =
                {
                    UebaDataSource.AuditLogs
                },
                ETag = ETag.All
            };
            return data;
        }
        #endregion

        #region SourceControlData(?)
        public static void AssertSourceControlData(SourceControlData data1, SourceControlData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.DisplayName, data2.DisplayName);
            Assert.AreEqual(data1.Description, data2.Description);
            Assert.AreEqual(data1.Version, data2.Version);
            Assert.AreEqual(data1.IdPropertiesId, data2.IdPropertiesId);
            Assert.AreEqual(data1.RepoType, data2.RepoType);
        }
        public static SourceControlData GetSourceControlData()
        {
            var data = new SourceControlData()
            {
                DisplayName = "SDK Test",
                RepoType = RepoType.Github,
                ContentTypes =
                {
                    ContentType.AnalyticRule,
                },
                Repository = new Repository()
                {
                    Branch = "main",
                    Uri = new Uri("https://github.com/SecCxPNinja/Ninja")
                }
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
                ItemsKeyValue =
                {
                }
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
