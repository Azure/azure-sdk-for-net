// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class EntityQueriesTests : TestBase
    {
        #region Test setup

        #endregion

        #region EntityQueries

        [Fact]
        public void EntityQueries_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);

                var EntityQueriesId = Guid.NewGuid().ToString();
                var QueryDefinitions = new ActivityEntityQueriesPropertiesQueryDefinitions()
                { 
                    Query = "let UserConsentToApplication = (Account_Name:string, Account_UPNSuffix:string, Account_AadUserId:string){\nlet account_upn = iff(Account_Name != \"\" and Account_UPNSuffix != \"\"\n, strcat(Account_Name,\"@\",Account_UPNSuffix)\n,\"\" );\nAuditLogs\n| where OperationName == \"Consent to application\"\n| extend Source_Account_UPNSuffix = tostring(todynamic(InitiatedBy) [\"user\"][\"userPrincipalName\"]), Source_Account_AadUserId = tostring(todynamic(InitiatedBy) [\"user\"][\"id\"])\n| where (account_upn != \"\" and account_upn =~ Source_Account_UPNSuffix) \nor (Account_AadUserId != \"\" and Account_AadUserId =~ Source_Account_AadUserId)\n| extend Target_CloudApplication_Name = tostring(todynamic(TargetResources)[0][\"displayName\"]), Target_CloudApplication_AppId = tostring(todynamic(TargetResources)[0][\"id\"])\n};\nUserConsentToApplication('{{Account_Name}}', '{{Account_UPNSuffix}}', '{{Account_AadUserId}}')  \n| project Target_CloudApplication_AppId, Target_CloudApplication_Name, TimeGenerated"
                };
                IList<String> Data1 = new List<String>();
                Data1.Add("Account_AadUserId");
                IList<String> Data2 = new List<String>();
                Data2.Add("Account_Name");
                Data2.Add("Account_UPNSuffix");
                IList<IList<string>> RequiredInputFieldSets = new List<IList<string>>();
                RequiredInputFieldSets.Add(Data1);
                RequiredInputFieldSets.Add(Data2);

                var EntityQueriesProperties = new ActivityCustomEntityQuery()
                {
                    Title = "The user consented to OAuth application",
                    InputEntityType = "Account", 
                    Content = "The user consented to the OAuth application named {{Target_CloudApplication_Name}} {{Count}} time(s)",
                    Description = "This activity lists user's consents to an OAuth applications.",
                    QueryDefinitions = QueryDefinitions,
                    RequiredInputFieldsSets = RequiredInputFieldSets

                };

                SecurityInsightsClient.EntityQueries.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueriesId, EntityQueriesProperties);
                
                var EntityQueries = SecurityInsightsClient.EntityQueries.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateEntityQueries(EntityQueries);
                SecurityInsightsClient.EntityQueries.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueriesId);
            }
        }

        [Fact]
        public void EntityQueries_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var EntityQueryId = Guid.NewGuid().ToString();
                var QueryDefinitions = new ActivityEntityQueriesPropertiesQueryDefinitions()
                {
                    Query = "let UserConsentToApplication = (Account_Name:string, Account_UPNSuffix:string, Account_AadUserId:string){\nlet account_upn = iff(Account_Name != \"\" and Account_UPNSuffix != \"\"\n, strcat(Account_Name,\"@\",Account_UPNSuffix)\n,\"\" );\nAuditLogs\n| where OperationName == \"Consent to application\"\n| extend Source_Account_UPNSuffix = tostring(todynamic(InitiatedBy) [\"user\"][\"userPrincipalName\"]), Source_Account_AadUserId = tostring(todynamic(InitiatedBy) [\"user\"][\"id\"])\n| where (account_upn != \"\" and account_upn =~ Source_Account_UPNSuffix) \nor (Account_AadUserId != \"\" and Account_AadUserId =~ Source_Account_AadUserId)\n| extend Target_CloudApplication_Name = tostring(todynamic(TargetResources)[0][\"displayName\"]), Target_CloudApplication_AppId = tostring(todynamic(TargetResources)[0][\"id\"])\n};\nUserConsentToApplication('{{Account_Name}}', '{{Account_UPNSuffix}}', '{{Account_AadUserId}}')  \n| project Target_CloudApplication_AppId, Target_CloudApplication_Name, TimeGenerated"
                };
                IList<String> Data1 = new List<String>();
                Data1.Add("Account_AadUserId");
                IList<String> Data2 = new List<String>();
                Data2.Add("Account_Name");
                Data2.Add("Account_UPNSuffix");
                IList<IList<string>> RequiredInputFieldSets = new List<IList<string>>();
                RequiredInputFieldSets.Add(Data1);
                RequiredInputFieldSets.Add(Data2);

                var EntityQueriesProperties = new ActivityCustomEntityQuery()
                {
                    Title = "The user consented to OAuth application",
                    InputEntityType = "Account",
                    Content = "The user consented to the OAuth application named {{Target_CloudApplication_Name}} {{Count}} time(s)",
                    Description = "This activity lists user's consents to an OAuth applications.",
                    QueryDefinitions = QueryDefinitions,
                    RequiredInputFieldsSets = RequiredInputFieldSets

                };

                var EntityQuery = SecurityInsightsClient.EntityQueries.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueryId, EntityQueriesProperties);
                ValidateEntityQuery(EntityQuery);
                SecurityInsightsClient.EntityQueries.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueryId);
            }
        }

        [Fact]
        public void EntityQueries_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var EntityQueryId = Guid.NewGuid().ToString();
                var QueryDefinitions = new ActivityEntityQueriesPropertiesQueryDefinitions()
                {
                    Query = "let UserConsentToApplication = (Account_Name:string, Account_UPNSuffix:string, Account_AadUserId:string){\nlet account_upn = iff(Account_Name != \"\" and Account_UPNSuffix != \"\"\n, strcat(Account_Name,\"@\",Account_UPNSuffix)\n,\"\" );\nAuditLogs\n| where OperationName == \"Consent to application\"\n| extend Source_Account_UPNSuffix = tostring(todynamic(InitiatedBy) [\"user\"][\"userPrincipalName\"]), Source_Account_AadUserId = tostring(todynamic(InitiatedBy) [\"user\"][\"id\"])\n| where (account_upn != \"\" and account_upn =~ Source_Account_UPNSuffix) \nor (Account_AadUserId != \"\" and Account_AadUserId =~ Source_Account_AadUserId)\n| extend Target_CloudApplication_Name = tostring(todynamic(TargetResources)[0][\"displayName\"]), Target_CloudApplication_AppId = tostring(todynamic(TargetResources)[0][\"id\"])\n};\nUserConsentToApplication('{{Account_Name}}', '{{Account_UPNSuffix}}', '{{Account_AadUserId}}')  \n| project Target_CloudApplication_AppId, Target_CloudApplication_Name, TimeGenerated"
                };
                IList<String> Data1 = new List<String>();
                Data1.Add("Account_AadUserId");
                IList<String> Data2 = new List<String>();
                Data2.Add("Account_Name");
                Data2.Add("Account_UPNSuffix");
                IList<IList<string>> RequiredInputFieldSets = new List<IList<string>>();
                RequiredInputFieldSets.Add(Data1);
                RequiredInputFieldSets.Add(Data2);

                var EntityQueriesProperties = new ActivityCustomEntityQuery()
                {
                    Title = "The user consented to OAuth application",
                    InputEntityType = "Account",
                    Content = "The user consented to the OAuth application named {{Target_CloudApplication_Name}} {{Count}} time(s)",
                    Description = "This activity lists user's consents to an OAuth applications.",
                    QueryDefinitions = QueryDefinitions,
                    RequiredInputFieldsSets = RequiredInputFieldSets

                };

                SecurityInsightsClient.EntityQueries.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueryId, EntityQueriesProperties);
                var EntityQuery = SecurityInsightsClient.EntityQueries.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueryId);
                ValidateEntityQuery(EntityQuery);
                SecurityInsightsClient.EntityQueries.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueryId);

            }
        }

        [Fact]
        public void EntityQueries_Delete()
        {
            Thread.Sleep(5000);
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var EntityQueryId = Guid.NewGuid().ToString();
                var QueryDefinitions = new ActivityEntityQueriesPropertiesQueryDefinitions()
                {
                    Query = "let UserConsentToApplication = (Account_Name:string, Account_UPNSuffix:string, Account_AadUserId:string){\nlet account_upn = iff(Account_Name != \"\" and Account_UPNSuffix != \"\"\n, strcat(Account_Name,\"@\",Account_UPNSuffix)\n,\"\" );\nAuditLogs\n| where OperationName == \"Consent to application\"\n| extend Source_Account_UPNSuffix = tostring(todynamic(InitiatedBy) [\"user\"][\"userPrincipalName\"]), Source_Account_AadUserId = tostring(todynamic(InitiatedBy) [\"user\"][\"id\"])\n| where (account_upn != \"\" and account_upn =~ Source_Account_UPNSuffix) \nor (Account_AadUserId != \"\" and Account_AadUserId =~ Source_Account_AadUserId)\n| extend Target_CloudApplication_Name = tostring(todynamic(TargetResources)[0][\"displayName\"]), Target_CloudApplication_AppId = tostring(todynamic(TargetResources)[0][\"id\"])\n};\nUserConsentToApplication('{{Account_Name}}', '{{Account_UPNSuffix}}', '{{Account_AadUserId}}')  \n| project Target_CloudApplication_AppId, Target_CloudApplication_Name, TimeGenerated"
                };
                IList<String> Data1 = new List<String>();
                Data1.Add("Account_AadUserId");
                IList<String> Data2 = new List<String>();
                Data2.Add("Account_Name");
                Data2.Add("Account_UPNSuffix");
                IList<IList<string>> RequiredInputFieldSets = new List<IList<string>>();
                RequiredInputFieldSets.Add(Data1);
                RequiredInputFieldSets.Add(Data2);

                var EntityQueriesProperties = new ActivityCustomEntityQuery()
                {
                    Title = "The user consented to OAuth application",
                    InputEntityType = "Account",
                    Content = "The user consented to the OAuth application named {{Target_CloudApplication_Name}} {{Count}} time(s)",
                    Description = "This activity lists user's consents to an OAuth applications.",
                    QueryDefinitions = QueryDefinitions,
                    RequiredInputFieldsSets = RequiredInputFieldSets

                };

                SecurityInsightsClient.EntityQueries.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueryId, EntityQueriesProperties);
                SecurityInsightsClient.EntityQueries.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueryId);
            }
        }

        #endregion

        #region Validations

        private void ValidateEntityQueries(IPage<EntityQuery> EntityQueries)
        {
            Assert.True(EntityQueries.IsAny());

            EntityQueries.ForEach(ValidateEntityQuery);
        }

        private void ValidateEntityQuery(EntityQuery EntityQuery)
        {
            Assert.NotNull(EntityQuery);
        }

        #endregion
    }
}
