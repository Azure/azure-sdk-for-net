// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class IotDefenderSettingsTests : TestBase
    {
        #region Test setup

        private static readonly string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static readonly string AscLocation = "centralus";
        private static TestEnvironment TestEnvironment { get; set; }

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

            securityCenterClient.AscLocation = AscLocation;

            return securityCenterClient;
        }

        #endregion

        #region Tests

        [Fact]
        public void IotDefenderSettings_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotDefenderSettings.Get();
                ret.Validate();
            }
        }

        [Fact]
        public void IotDefenderSettings_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var scope = $"/subscriptions/{SubscriptionId}";
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotDefenderSettings.List();
                Validate(ret);
            }
        }

        [Fact]
        public void IotDefenderSettings_CreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotDefenderSettings.CreateOrUpdate(deviceQuota:1000, sentinelWorkspaceResourceIds: new List<string>());
                ret.Validate();
            }
        }

        [Fact]
        public void IotDefenderSettings_PackageDownloads()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var packageDownloads = securityCenterClient.IotDefenderSettings.PackageDownloadsMethod();

                Validate(packageDownloads);
            }
        }
        #endregion

        #region Validations
        private static void Validate(IotDefenderSettingsList settingsList)
        {
            var iotDefenderSettingsModels = settingsList.Value;
            Assert.True(iotDefenderSettingsModels.IsAny());
            foreach (var setting in iotDefenderSettingsModels)
            {
                setting.Validate();
            }
        }

        private static void Validate(PackageDownloads packageDownloads)
        {
            Assert.NotNull(packageDownloads);
        }
        #endregion
    }
}