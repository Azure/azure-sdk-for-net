﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using CommandLine;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    public class Program
    {
        /// <summary>
        /// Main entry point to the sample.
        /// </summary>
        public static async Task Main(string[] args)
        {
            // Parse and validate paramters
            Options options = null;
            ParserResult<Options> result = Parser.Default.ParseArguments<Options>(args)
                .WithParsed(parsedOptions =>
                    {
                        options = parsedOptions;
                    })
                .WithNotParsed(errors =>
                    {
                        Environment.Exit(1);
                    });

            // Instantiate the Time Series Insights client
            TimeSeriesInsightsClient tsiClient = GetTimeSeriesInsightsClient(
                options.TenantId,
                options.ClientId,
                options.ClientSecret,
                options.TsiEnvironmentFqdn);

            // Instantiate an IoT Hub device client client in order to send telemetry to the hub
            DeviceClient deviceClient = await GetDeviceClientAsync(options.IoTHubConnectionString).ConfigureAwait(false);

            // Run the samples

            var tsiLifecycleSamples = new TimeSeriesInsightsLifecycleSamples(tsiClient, options.TsiEnvironmentFqdn);
            await tsiLifecycleSamples.RunSamplesAsync();

            var tsiInstancesSamples = new InstancesSamples();
            await tsiInstancesSamples.RunSamplesAsync(tsiClient);

            var tsiTypesSamples = new TypesSamples();
            await tsiTypesSamples.RunSamplesAsync(tsiClient);

            var tsiHierarchiesSamples = new HierarchiesSamples();
            await tsiHierarchiesSamples.RunSamplesAsync(tsiClient);
            
            var tsiModelSettingsSamples = new ModelSettingsSamples();
            await tsiModelSettingsSamples.RunSamplesAsync(tsiClient);

            var querySamples = new QuerySamples();
            await querySamples.RunSamplesAsync(tsiClient, deviceClient);
        }

        /// <summary>
        /// Illustrates how to construct a <see cref="TimeSeriesInsightsClient"/>, using the <see cref="DefaultAzureCredential"/>
        /// implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <param name="tsiEndpoint">The endpoint of the Time Series Insights instance.</param>
        private static TimeSeriesInsightsClient GetTimeSeriesInsightsClient(string tenantId, string clientId, string clientSecret, string tsiEndpoint)
        {
            // These environment variables are necessary for DefaultAzureCredential to use application Id and client secret to login.
            Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", clientSecret);
            Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", clientId);
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantId);

            #region Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret

            // DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
            // It attempts to use multiple credential types in an order until it finds a working credential.
            var tokenCredential = new DefaultAzureCredential();

            var client = new TimeSeriesInsightsClient(
                tsiEndpoint,
                tokenCredential);

            #endregion Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret

            return client;
        }

        private static async Task<DeviceClient> GetDeviceClientAsync(string iotHubConnectionString)
        {
            // Create a device
            using var registryManager = RegistryManager.CreateFromConnectionString(iotHubConnectionString);
            string deviceId = Guid.NewGuid().ToString();
            var requestDevice = new Device(deviceId);

            // Add the device to the device manager
            Device device = await registryManager.AddDeviceAsync(requestDevice).ConfigureAwait(false);
            await Task.Delay(5000).ConfigureAwait(false);
            await registryManager.CloseAsync().ConfigureAwait(false);

            // Create a device client
            string iotHubHostName = HostNameHelper.GetHostName(iotHubConnectionString);
            string deviceConnectinString = $"HostName={iotHubHostName};DeviceId={device.Id};SharedAccessKey={device.Authentication.SymmetricKey.PrimaryKey}";
            DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectinString, Microsoft.Azure.Devices.Client.TransportType.Mqtt);
            await deviceClient.OpenAsync().ConfigureAwait(false);

            return deviceClient;
        }
    }
}
