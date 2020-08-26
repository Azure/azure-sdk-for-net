// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample goes through the usage of statistics on the IoT Hub.
    /// </summary>
    internal class StatisticsSamples
    {

        public readonly IotHubServiceClient IoTHubServiceClient;

        public StatisticsSamples(IotHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            await GetDeviceStatisticsAsync();
            await GetServiceStatisticsAsync();
        }

        /// <summary>
        /// Gets device statistics on the IoT Hub.
        /// </summary>
        public async Task GetDeviceStatisticsAsync()
        {
            SampleLogger.PrintHeader("GET DEVICE STATISTICS");
            try
            {
                #region Snippet:IotHubGetDeviceStatistics

                Response<Models.DevicesStatistics> statistics = await IoTHubServiceClient.Statistics.GetDevicesStatisticsAsync();
                Console.WriteLine($"Total device count: {statistics.Value.TotalDeviceCount}");
                Console.WriteLine($"Total enabled device count: {statistics.Value.EnabledDeviceCount}");
                Console.WriteLine($"Total disabled device count: {statistics.Value.DisabledDeviceCount}");

                #endregion Snippet:IotHubGetDeviceStatistics
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to get device statistics due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Gets service statistics on the IoT Hub.
        /// </summary>
        public async Task GetServiceStatisticsAsync()
        {
            SampleLogger.PrintHeader("GET SERVICE STATISTICS");
            try
            {
                #region Snippet:IotHubGetServiceStatistics

                Response<Models.ServiceStatistics> statistics = await IoTHubServiceClient.Statistics.GetServiceStatisticsAsync();
                Console.WriteLine($"Total connected device count: {statistics.Value.ConnectedDeviceCount}");

                #endregion Snippet:IotHubGetServiceStatistics
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to get service statistics due to:\n{ex}");
                throw;
            }
        }
    }
}
