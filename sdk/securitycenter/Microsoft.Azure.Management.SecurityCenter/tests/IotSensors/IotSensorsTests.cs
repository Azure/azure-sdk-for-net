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
    public class IotSensorsTests : TestBase
    {
        #region Test setup

        private static readonly string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static readonly string ResourceGroupName = "IOT-ResourceGroup-CUS";
        private static readonly string IotHubName = "SDK-IotHub-CUS";
        private static readonly string SensorName = "iotSensor";
        private static readonly string SensorNameToDelete = "iotSensorToDelete";
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
        public void IotSensors_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var scope = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Devices/IotHubs/{IotHubName}";
                var ret = securityCenterClient.IotSensors.Get(scope, SensorName);
                Validate(ret);
            }
        }

        [Fact]
        public void IotSensors_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var scope = $"/subscriptions/{SubscriptionId}";
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSensors.List(scope);
                Validate(ret);
            }
        }

        [Fact]
        public void IotSensors_CreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var scope = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Devices/IotHubs/{IotHubName}";
                securityCenterClient.IotSensors.CreateOrUpdate(scope, SensorName);
            }
        }

        [Fact]
        public async void IotSensors_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var scope = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Devices/IotHubs/{IotHubName}";
                var sensorToDelete =
                    await securityCenterClient.IotSensors.CreateOrUpdateAsync(scope, SensorNameToDelete);

                Validate(sensorToDelete);

                securityCenterClient.IotSensors.Delete(scope, SensorNameToDelete);

                Assert.Throws<CloudException>(() =>
                {
                    securityCenterClient.IotSensors.Get(scope, SensorNameToDelete);
                });
            }
        }

        [Fact]
        public void IotSensors_DownloadActivation()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var scope = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Devices/IotHubs/{IotHubName}";
                var ret = securityCenterClient.IotSensors.DownloadActivation(scope, SensorName);
                Validate(ret);
            }
        }
        #endregion

        #region Validations
        private static void Validate(IotSensorsList sensors)
        {
            var iotSensors = sensors.Value;
            Assert.True(iotSensors.IsAny());
            foreach (var sensor in iotSensors)
            {
                Validate(sensor);
            }
        }
        private static void Validate(IotSensor sensor)
        {
            Assert.NotNull(sensor);
        }

        private static void Validate(Stream sensorStream)
        {
            Assert.NotNull(sensorStream); 
            Assert.True(sensorStream.CanRead);
        }
        #endregion
    }
}