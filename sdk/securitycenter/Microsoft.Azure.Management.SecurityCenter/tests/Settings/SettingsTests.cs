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
    public class SettingsTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static string SettingName = "MCAS";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                TestEnvironment.SubscriptionId = SubscriptionId;
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = "centralus";

            return securityCenterClient;
        }

        #endregion

        #region Settings Tests

        [Fact]
        public void Settings_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var settings = securityCenterClient.Settings.List();
                ValidateSettings(settings);
            }
        }

        [Fact]
        public void Settings_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var setting = securityCenterClient.Settings.Get(SettingName);
                ValidateSetting(setting);
            }
        }

        [Fact]
        public void Settings_Update()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var setting = securityCenterClient.Settings.Get(SettingName);
                ValidateSetting(setting);

                var updatedSetting = securityCenterClient.Settings.Update(SettingName, setting);
                ValidateSetting(updatedSetting);
            }
        }

        #endregion

        #region Validations

        private void ValidateSettings(IPage<Setting> SettingsPage)
        {
            Assert.True(SettingsPage.IsAny());

            SettingsPage.ForEach(ValidateSetting);
        }

        private void ValidateSetting(Setting setting)
        {
            Assert.NotNull(setting);
        }

        #endregion
    }
}
