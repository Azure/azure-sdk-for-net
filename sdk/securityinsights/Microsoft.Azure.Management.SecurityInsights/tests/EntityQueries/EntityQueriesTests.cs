// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
                var EntityQueriesProperties = new CustomEntityQuery()
                {
                };

                SecurityInsightsClient.EntityQueries.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueriesId, EntityQueriesProperties);
                
                var EntityQueries = SecurityInsightsClient.EntityQueries.List(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName);
                ValidateEntityQueries(EntityQueries);
                SecurityInsightsClient.EntityQueries.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueriesId);
            }
        }

        [Fact]
        public void EntityQueries_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var EntityQueryId = Guid.NewGuid().ToString();
                var EntityQueryProperties = new CustomEntityQuery()
                {
                };

                var EntityQuery = SecurityInsightsClient.EntityQueries.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueryId, EntityQueryProperties);
                ValidateEntityQuery(EntityQuery);
                SecurityInsightsClient.EntityQueries.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueryId);
            }
        }

        [Fact]
        public void EntityQueries_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var EntityQueryId = Guid.NewGuid().ToString();
                var EntityQueryProperties = new CustomEntityQuery()
                {
                };

                SecurityInsightsClient.EntityQueries.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueryId, EntityQueryProperties);
                var EntityQuery = SecurityInsightsClient.EntityQueries.Get(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueryId);
                ValidateEntityQuery(EntityQuery);
                SecurityInsightsClient.EntityQueries.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueryId);

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
                var EntityQueryProperties = new CustomEntityQuery()
                {
                };

                SecurityInsightsClient.EntityQueries.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueryId, EntityQueryProperties);
                SecurityInsightsClient.EntityQueries.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, EntityQueryId);
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
