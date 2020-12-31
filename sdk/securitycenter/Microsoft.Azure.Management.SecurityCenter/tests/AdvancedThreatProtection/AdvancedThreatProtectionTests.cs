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
    public class AdvancedThreatProtectionTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "7e5c35c3-c2d0-43c7-ab12-2528b6b8dada"; // Rome-DataProtection-StorageAnalytics-Test1
        private static string RgName = "NetSdkTests";
        private static string StorageAccountName = "netsdkstorage";

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

        #region AdvancThreatProtection Tests

        [Fact]
        public void AdvancedThreatProtection_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var resourceId = $"/subscriptions/{SubscriptionId}/resourceGroups/{RgName}/providers/Microsoft.Storage/storageAccounts/{StorageAccountName}";
                var setting = securityCenterClient.AdvancedThreatProtection.Get(resourceId);
                ValidateAdvancedThreatProtectionSetting(setting);
            }
        }

        [Fact]
        public void AdvancedThreatProtection_CreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var resourceId = $"/subscriptions/{SubscriptionId}/resourceGroups/{RgName}/providers/Microsoft.Storage/storageAccounts/{StorageAccountName}";
                var setting = securityCenterClient.AdvancedThreatProtection.Create(resourceId, isEnabled: true);
                ValidateAdvancedThreatProtectionSetting(setting);
            }
        }

        #endregion

        #region Validations

        private void ValidateAdvancedThreatProtections(IPage<AdvancedThreatProtectionSetting> AdvancedThreatProtectionPage)
        {
            Assert.True(AdvancedThreatProtectionPage.IsAny());

            AdvancedThreatProtectionPage.ForEach(ValidateAdvancedThreatProtectionSetting);
        }

        private void ValidateAdvancedThreatProtectionSetting(AdvancedThreatProtectionSetting setting)
        {
            Assert.NotNull(setting);
        }

        #endregion
    }
}
