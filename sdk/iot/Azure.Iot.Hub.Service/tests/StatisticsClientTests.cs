// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    /// <summary>
    /// Test all APIs of the StatisticsClient.
    /// </summary>
    public class StatisticsClientTests : E2eTestBase
    {
        /// <summary>
        /// All this test class does is to make sure the call comes back with a response.
        /// This test is not responsible to make sure the values that come back are accurate as that would be testing the service logic.
        /// </summary>
        public StatisticsClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task StatisticsClient_Device_SuccessfulResponse()
        {
            IotHubServiceClient client = GetClient();

            Response<DevicesStatistics> stat = await client.Statistics.GetDevicesStatisticsAsync().ConfigureAwait(false);

            Assert.IsNotNull(stat.Value, "Statistics response should not be null");
            Assert.IsNotNull(stat.Value.TotalDeviceCount, "TotalDeviceCount should not be null");
            Assert.IsNotNull(stat.Value.EnabledDeviceCount, "EnabledDeviceCount should not be null");
            Assert.IsNotNull(stat.Value.DisabledDeviceCount, "DisabledDeviceCount should not be null");
        }

        [Test]
        public async Task StatisticsClient_Service_SuccessfulResponse()
        {
            IotHubServiceClient client = GetClient();

            Response<ServiceStatistics> stat = await client.Statistics.GetServiceStatisticsAsync().ConfigureAwait(false);

            Assert.IsNotNull(stat.Value, "Statistics response should not be null");
            Assert.IsNotNull(stat.Value.ConnectedDeviceCount, "ConnectedDeviceCount should not be null");
        }
    }
}
