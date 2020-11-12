// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    public class IotSecuritySolutionsDeviceSecurityGroupsTests : TestBase
    {
        #region Test setup
        private static readonly string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static readonly string ResourceGroupName = "IOT-ResourceGroup-CUS";
        private static readonly string IotHubName = "SDK-IotHub-CUS";
        private static readonly string AscLocation = "centralus";
        private static readonly string IotHubResourceId =
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Devices/IotHubs/{IotHubName}";
        private static readonly string DeviceSecurityGroupName = "TestDeviceSecurityGroupName";
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
        public void IotSecuritySolutionsDeviceSecurityGroups_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.DeviceSecurityGroups.Get(IotHubResourceId, DeviceSecurityGroupName);
                Assert.NotNull(ret);
            }
        }

        [Fact]
        public void IotSecuritySolutionsDeviceSecurityGroups_Create()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.DeviceSecurityGroups.CreateOrUpdate(IotHubResourceId, DeviceSecurityGroupName, new DeviceSecurityGroup());
                Assert.NotNull(ret);
            }
        }

        [Fact]
        public void IotSecuritySolutionsDeviceSecurityGroups_Delete()
        {
            string IotHubResourceId =
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Devices/IotHubs/{IotHubName}";
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.DeviceSecurityGroups.Delete(IotHubResourceId, DeviceSecurityGroupName);
            }
        }

        [Fact]
        public void IotSecuritySolutionsDeviceSecurityGroups_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.DeviceSecurityGroups.List(IotHubResourceId);
                Validate(ret);
            }
        }
        #endregion

        #region Validations
        private static void Validate(IPage<DeviceSecurityGroup> ret)
        {
            Assert.True(ret.IsAny());
            foreach (var item in ret)
            {
                Assert.NotNull(item);
            }
        }
        #endregion
    }
}
