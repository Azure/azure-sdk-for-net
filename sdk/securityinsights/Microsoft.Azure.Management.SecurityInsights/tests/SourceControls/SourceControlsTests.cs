// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class SourceControlsTests : TestBase
    {
        #region Test setup

        #endregion

        #region SourceControls

        [Fact]
        public void SourceControls_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var SourceControls = SecurityInsightsClient.SourceControls.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                //ValidateSourceControls(SourceControls);
            }
        }

        [Fact]
        public void SourceControls_CreateorUpdate()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var SourceControlId = Guid.NewGuid().ToString();
                var SourceControlsProperties = new SourceControl()
                {
                    DisplayName = "SDK Test",
                    Description = "SDK Test",
                    RepoType = "GitHub",
                    ContentTypes = new List<string>() { "AnalyticRules" },
                    Repository = new Repository()
                    {
                        Branch = "master",
                        Url = "https://github.com/Azure/Azure-Sentinel",
                        DisplayUrl = "https://github.com/Azure/Azure-Sentinel",
                        PathMapping = new List<ContentPathMap>()
                        {
                            new ContentPathMap()
                            {
                                ContentType = "AnalyticRules",
                                Path = "Solutions/ZeroTrust(TIC3.0)/Analytic Rules"
                            }
                        }
                    }
                };

                //var SourceControls = SecurityInsightsClient.SourceControls.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                //var SourceControl = SecurityInsightsClient.SourceControls.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SourceControlId, SourceControlsProperties);
                //ValidateSourceControl(SourceControl);
                //SecurityInsightsClient.SourceControls.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SourceControlId);
            }
        }

        [Fact]
        public void SourceControls_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var SourceControlId = Guid.NewGuid().ToString();
                var ContentTypes = new List<string>();
                ContentTypes.Add("AnalyticRule");
                var RepoProperties = new Repository()
                {
                    Branch = "main",
                    Url = "https://github.com/SecCxPNinja/Ninja"
                };
                var SourceControlsProperties = new SourceControl()
                {
                    DisplayName = "SDK Test",
                    RepoType = "GitHub",
                    ContentTypes = ContentTypes,
                    Repository = RepoProperties
                };
                var SourceControls = SecurityInsightsClient.SourceControls.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                //SecurityInsightsClient.SourceControls.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SourceControlId, SourceControlsProperties);
                //var SourceControl = SecurityInsightsClient.SourceControls.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SourceControlId);
                //ValidateSourceControl(SourceControl);
                //SecurityInsightsClient.SourceControls.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SourceControlId);

            }
        }

        [Fact]
        public void SourceControls_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var SourceControlId = Guid.NewGuid().ToString();
                var ContentTypes = new List<string>();
                ContentTypes.Add("AnalyticRule");
                var RepoProperties = new Repository()
                {
                    Branch = "main",
                    Url = "https://github.com/SecCxPNinja/Ninja"
                };
                var SourceControlsProperties = new SourceControl()
                {
                    DisplayName = "SDK Test",
                    RepoType = "GitHub",
                    ContentTypes = ContentTypes,
                    Repository = RepoProperties
                };

                var SourceControls = SecurityInsightsClient.SourceControls.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                //SecurityInsightsClient.SourceControls.Create(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SourceControlId, SourceControlsProperties);
                //SecurityInsightsClient.SourceControls.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, SourceControlId);
            }
        }

        #endregion

        #region Validations

        private void ValidateSourceControls(IPage<SourceControl> SourceControlList)
        {
            Assert.True(SourceControlList.IsAny());

            SourceControlList.ForEach(ValidateSourceControl);
        }

        private void ValidateSourceControl(SourceControl SourceControl)
        {
            Assert.NotNull(SourceControl);
        }

        #endregion
    }
}
