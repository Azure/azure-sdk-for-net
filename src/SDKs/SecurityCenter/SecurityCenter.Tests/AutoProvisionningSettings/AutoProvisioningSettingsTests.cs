// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
    public class AutoProvisioningSettingsTests : TestBase
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

        #region Auto Provisioning Settings Tests

        [Fact]
        public void AutoProvisioningSettings_List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var autoProvisioningSettings = securityCenterClient.AutoProvisioningSettings.List();
                ValidateAutoProvisioningSettings(autoProvisioningSettings);
            }
        }

        [Fact]
        public void AutoProvisioningSettings_Get()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var autoProvisioningSetting = securityCenterClient.AutoProvisioningSettings.Get("default");
                ValidateAutoProvisioningSetting(autoProvisioningSetting);
            }
        }

        [Fact]
        public void AutoProvisioningSettings_Create()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var autoProvisioningSetting = securityCenterClient.AutoProvisioningSettings.Create("default", "On");
                ValidateAutoProvisioningSetting(autoProvisioningSetting);
            }
        }

        #endregion

        #region Validations

        private void ValidateAutoProvisioningSettings(IPage<AutoProvisioningSetting> autoProvisioningSettingsPage)
        {
            Assert.True(autoProvisioningSettingsPage.IsAny());

            autoProvisioningSettingsPage.ForEach(ValidateAutoProvisioningSetting);
        }

        private void ValidateAutoProvisioningSetting(AutoProvisioningSetting autoProvisioningSetting)
        {
            Assert.NotNull(autoProvisioningSetting);
        }

        #endregion
    }
}
