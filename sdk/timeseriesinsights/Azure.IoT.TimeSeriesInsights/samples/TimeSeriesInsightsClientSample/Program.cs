// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            SamplesOptions options = null;
            ParserResult<SamplesOptions> result = Parser.Default.ParseArguments<SamplesOptions>(args)
                .WithParsed(parsedOptions =>
                    {
                        options = parsedOptions;
                    })
                .WithNotParsed(errors =>
                    {
                        Environment.Exit(1);
                    });

            // Instantiate the Time Series Insights client
            TimeSeriesInsightsClient tsiClient = GetTimeSeriesInsightsClient(options.TsiEnvironmentFqdn);

            // Instantiate an IoT Hub device client client in order to send telemetry to the hub
            DeviceClient deviceClient = await GetDeviceClientAsync(options.IoTHubConnectionString).ConfigureAwait(false);

            // Figure out what keys make up the Time Series Id
            TimeSeriesInsightsModelSettings modelSettingsClient = tsiClient.GetModelSettingsClient();
            TimeSeriesModelSettings modelSettings = await modelSettingsClient.GetAsync();

            TimeSeriesId tsId = TimeSeriesIdHelper.CreateTimeSeriesId(modelSettings);

            // In order to query for data, let's first send events to the IoT Hub
            await SendEventsToIotHubAsync(deviceClient, tsId, modelSettings.TimeSeriesIdProperties.ToArray());

            // Run the samples

            var tsiInstancesSamples = new InstancesSamples();
            await tsiInstancesSamples.RunSamplesAsync(tsiClient);

            var tsiTypesSamples = new TypesSamples();
            await tsiTypesSamples.RunSamplesAsync(tsiClient);

            var tsiHierarchiesSamples = new HierarchiesSamples();
            await tsiHierarchiesSamples.RunSamplesAsync(tsiClient);

            var tsiModelSettingsSamples = new ModelSettingsSamples();
            await tsiModelSettingsSamples.RunSamplesAsync(tsiClient);

            var querySamples = new QuerySamples();
            await querySamples.RunSamplesAsync(tsiClient, tsId);
        }

        /// <summary>
        /// Illustrates how to construct a <see cref="TimeSeriesInsightsClient"/>, using the <see cref="DefaultAzureCredential"/>
        /// implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <param name="tsiEndpoint">The endpoint of the Time Series Insights instance.</param>
        private static TimeSeriesInsightsClient GetTimeSeriesInsightsClient(string tsiEndpoint)
        {
            #region Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret

            // DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based on the environment it is executing in.
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

        private static async Task SendEventsToIotHubAsync(
            DeviceClient deviceClient,
            TimeSeriesId tsId,
            TimeSeriesIdProperty[] timeSeriesIdProperties)
        {
            IDictionary<string, object> messageBase = BuildMessageBase(timeSeriesIdProperties, tsId);
            double minTemperature = 20;
            double minHumidity = 60;
            var rand = new Random();

            Console.WriteLine("\n\nSending temperature and humidity events to the IoT Hub.\n");

            // Build the message base that is used as the base for every event going out
            for (int i = 0; i < 10; i++)
            {
                double currentTemperature = minTemperature + rand.NextDouble() * 15;
                double currentHumidity = minHumidity + rand.NextDouble() * 20;
                messageBase["Temperature"] = currentTemperature;
                messageBase["Humidity"] = currentHumidity;
                string messageBody = JsonSerializer.Serialize(messageBase);
                var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageBody))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                };

                await deviceClient.SendEventAsync(message);

                Console.WriteLine($"{DateTime.UtcNow} - Temperature: {currentTemperature}. " +
                    $"Humidity: {currentHumidity}.");

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private static IDictionary<string, object> BuildMessageBase(TimeSeriesIdProperty[] timeSeriesIdProperties, TimeSeriesId tsiId)
        {
            var messageBase = new Dictionary<string, object>();
            string[] tsiIdArray = tsiId.ToStringArray();
            for (int i = 0; i < timeSeriesIdProperties.Count(); i++)
            {
                TimeSeriesIdProperty idProperty = timeSeriesIdProperties[i];
                string tsiIdValue = tsiIdArray[i];
                messageBase[idProperty.Name] = tsiIdValue;
            }

            return messageBase;
        }
    }
}
