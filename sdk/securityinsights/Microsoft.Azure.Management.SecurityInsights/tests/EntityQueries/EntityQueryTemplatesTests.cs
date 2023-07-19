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
    public class EntityQueryTemplatesTests : TestBase
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

                var EntityQueryTemplates = SecurityInsightsClient.EntityQueryTemplates.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateEntityQueryTemplates(EntityQueryTemplates);
            }
        }

        [Fact]
        public void EntityQueries_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
             
                var EntityQueryTemplates = SecurityInsightsClient.EntityQueryTemplates.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                var EntityQueryTemplate = SecurityInsightsClient.EntityQueryTemplates.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, EntityQueryTemplates.First().Name);
                ValidateEntityQueryTemplate(EntityQueryTemplate);
            }
        }

        #endregion

        #region Validations

        private void ValidateEntityQueryTemplates(IPage<EntityQueryTemplate> EntityQueryTemplates)
        {
            Assert.True(EntityQueryTemplates.IsAny());

            EntityQueryTemplates.ForEach(ValidateEntityQueryTemplate);
        }

        private void ValidateEntityQueryTemplate(EntityQueryTemplate EntityQueryTemplate)
        {
            Assert.NotNull(EntityQueryTemplate);
        }

        #endregion
    }
}
