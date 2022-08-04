// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class MetadataTests : TestBase
    {
        #region Test setup

        #endregion

        #region Metadata

        [Fact]
        public void Metadata_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);

                var MetadataId = Guid.NewGuid().ToString();
                var MetadataProperties = new MetadataModel()
                {
                    Kind = "AnalyticsRule",
                    ParentId = "/subscriptions/" + TestHelper.TestEnvironment.SubscriptionId.ToString() + "/resourceGroups/" + TestHelper.ResourceGroup + "/providers/" + TestHelper.OperationalInsightsResourceProvider + "/workspaces/" + TestHelper.WorkspaceName + "/providers/Microsoft.SecurityInsights/alertRules/" + Guid.NewGuid().ToString(),
                    ContentId = Guid.NewGuid().ToString()
                };

                SecurityInsightsClient.Metadata.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId, MetadataProperties);

                var Metadatas = SecurityInsightsClient.Metadata.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateMetadatas(Metadatas);
                SecurityInsightsClient.Metadata.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId);
            }
        }

        [Fact]
        public void Metadata_CreateorUpdate()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                
                var MetadataId = Guid.NewGuid().ToString();
                var MetadataProperties = new MetadataModel()
                {
                   Kind = "AnalyticsRule",
                   ParentId = "/subscriptions/" + TestHelper.TestEnvironment.SubscriptionId.ToString() + "/resourceGroups/" + TestHelper.ResourceGroup + "/providers/" + TestHelper.OperationalInsightsResourceProvider + "/workspaces/" + TestHelper.WorkspaceName + "/providers/Microsoft.SecurityInsights/alertRules/" + Guid.NewGuid().ToString(),
                   ContentId = Guid.NewGuid().ToString()
                };

                var Metadata = SecurityInsightsClient.Metadata.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId, MetadataProperties);
                ValidateMetadata(Metadata);
                SecurityInsightsClient.Metadata.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId);
            }
        }

        [Fact]
        public void Metadata_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var MetadataId = Guid.NewGuid().ToString();
                var MetadataProperties = new MetadataModel()
                {
                    Kind = "AnalyticsRule",
                    ParentId = "/subscriptions/" + TestHelper.TestEnvironment.SubscriptionId.ToString() + "/resourceGroups/" + TestHelper.ResourceGroup + "/providers/" + TestHelper.OperationalInsightsResourceProvider + "/workspaces/" + TestHelper.WorkspaceName + "/providers/Microsoft.SecurityInsights/alertRules/" + Guid.NewGuid().ToString(),
                    ContentId = Guid.NewGuid().ToString()
                };

                SecurityInsightsClient.Metadata.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId, MetadataProperties);
                var Metadata = SecurityInsightsClient.Metadata.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId);
                ValidateMetadata(Metadata);
                SecurityInsightsClient.Metadata.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId);
            }
        }

        [Fact]
        public void Metadata_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var MetadataId = Guid.NewGuid().ToString();
                var MetadataProperties = new MetadataModel()
                {
                    Kind = "AnalyticsRule",
                    ParentId = "/subscriptions/" + TestHelper.TestEnvironment.SubscriptionId.ToString() + "/resourceGroups/" + TestHelper.ResourceGroup + "/providers/" + TestHelper.OperationalInsightsResourceProvider + "/workspaces/" + TestHelper.WorkspaceName + "/providers/Microsoft.SecurityInsights/alertRules/" + Guid.NewGuid().ToString(),
                    ContentId = Guid.NewGuid().ToString()
                };

                var Metadata = SecurityInsightsClient.Metadata.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId, MetadataProperties);
                SecurityInsightsClient.Metadata.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, MetadataId);
            }
        }

        #endregion

        #region Validations

        private void ValidateMetadatas(IPage<MetadataModel> Metadatas)
        {
            Assert.True(Metadatas.IsAny());

        Metadatas.ForEach(ValidateMetadata);
        }

        private void ValidateMetadata(MetadataModel Metadata)
        {
            Assert.NotNull(Metadata);
        }

        #endregion
    }
}
