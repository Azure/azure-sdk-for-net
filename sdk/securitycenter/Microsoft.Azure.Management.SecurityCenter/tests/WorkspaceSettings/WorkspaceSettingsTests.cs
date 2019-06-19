// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class WorkspaceSettingsTests : TestBase
    {
        #region Test setup

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = "centralus";

            return securityCenterClient;
        }

        #endregion

        #region WorkspaceSettings

        private static string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";

        [Fact]
        public void WorkspaceSettings_List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var workspaceSettings = securityCenterClient.WorkspaceSettings.List();
                ValidateWorkspaceSettings(workspaceSettings);
            }
        }

        [Fact]
        public void WorkspaceSettings_Get()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var workspaceSettings = securityCenterClient.WorkspaceSettings.Get("default");
                ValidateWorkspaceSettings(workspaceSettings);
            }
        }

        [Fact]
        public void WorkspaceSettings_Create()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var workspaceId = $"/subscriptions/{SubscriptionId}/resourceGroups/mainWS/providers/Microsoft.OperationalInsights/workspaces/securityUserWs";

                var workspaceSettings = securityCenterClient.WorkspaceSettings.Create("default", workspaceId, $"/subscriptions/{SubscriptionId}");
                ValidateWorkspaceSettings(workspaceSettings);
            }
        }

        [Fact]
        public void WorkspaceSettings_Update()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var workspaceId = $"/subscriptions/{SubscriptionId}/resourceGroups/mainWS/providers/Microsoft.OperationalInsights/workspaces/securityUserWs";

                var workspaceSettings = securityCenterClient.WorkspaceSettings.Update("default", workspaceId, $"/subscriptions/{SubscriptionId}");
                ValidateWorkspaceSettings(workspaceSettings);
            }
        }

        [Fact]
        public void WorkspaceSettings_Delete()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.WorkspaceSettings.Delete("default");
            }
        }

        #endregion

        #region Validations

        private void ValidateWorkspaceSettings(IPage<WorkspaceSetting> workspaceSettingsPage)
        {
            Assert.True(workspaceSettingsPage.IsAny());

            workspaceSettingsPage.ForEach(ValidateWorkspaceSettings);
        }

        private void ValidateWorkspaceSettings(WorkspaceSetting workspaceSettings)
        {
            Assert.NotNull(workspaceSettings);
        }

        #endregion
    }
}
