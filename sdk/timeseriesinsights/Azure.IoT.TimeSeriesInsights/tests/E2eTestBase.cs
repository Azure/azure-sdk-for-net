// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using NUnit.Framework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    /// <summary>
    /// This class will initialize all the settings and create and instance of the Time Series Insights client.
    /// </summary>
    [Parallelizable(ParallelScope.Self)]
    public abstract class E2eTestBase : RecordedTestBase<TimeSeriesInsightsTestEnvironment>
    {
        protected static readonly int MaxTries = 1000;

        // Based on testing, the max length of models can be 27 only and works well for other resources as well. This can be updated when required.
        protected static readonly int MaxIdLength = 27;

        private static readonly SemaphoreSlim s_semaphore = new SemaphoreSlim(1, 1);

        internal const string FAKE_HOST = "fakeHost.api.wus2.timeseriesinsights.azure.com";

        public E2eTestBase(bool isAsync)
         : base(isAsync, TestSettings.Instance.TestMode)
        {
            ReplacementHost = FAKE_HOST;
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            TestDiagnostics = false;

            // TODO: set via client options and pipeline instead
#pragma warning disable SYSLIB0014 // ServicePointManager is obsolete, there's already a TODO to fix this above
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#pragma warning restore SYSLib0014
        }

        protected TimeSeriesInsightsClient GetClient(TimeSeriesInsightsClientOptions options = null)
        {
            if (options == null)
            {
                options = new TimeSeriesInsightsClientOptions();
            }

            return InstrumentClient(
                new TimeSeriesInsightsClient(
                    TestEnvironment.TimeSeriesInsightsHostname,
                    TestEnvironment.Credential,
                    InstrumentClientOptions(options)));
        }

        protected TimeSeriesInsightsClient GetFakeClient()
        {
            return InstrumentClient(
                new TimeSeriesInsightsClient(
                    TestEnvironment.TimeSeriesInsightsHostname,
                    new FakeTokenCredential(),
                    InstrumentClientOptions(new TimeSeriesInsightsClientOptions())));
        }

        protected async Task<DeviceClient> GetDeviceClient()
        {
            try
            {
                await s_semaphore.WaitAsync().ConfigureAwait(false);

                // Create a device
                string iotHubConnectionString = TestEnvironment.IoTHubConnectionString;
                using var registryManager = RegistryManager.CreateFromConnectionString(iotHubConnectionString);
                string deviceId = await GetUniqueDeviceIdAsync((deviceId) => registryManager.GetDeviceAsync(deviceId)).ConfigureAwait(false);
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
            finally
            {
                s_semaphore.Release();
            }
        }

        protected async Task<TimeSeriesId> GetUniqueTimeSeriesInstanceIdAsync(TimeSeriesInsightsInstances instancesClient, int numOfIdKeys)
        {
            numOfIdKeys.Should().BeInRange(1, 3);

            for (int tryNumber = 0; tryNumber < MaxTries; ++tryNumber)
            {
                var id = new List<string>();
                for (int i = 0; i < numOfIdKeys; i++)
                {
                    id.Add(Recording.GenerateAlphaNumericId(string.Empty));
                }

                TimeSeriesId tsId = numOfIdKeys switch
                {
                    1 => new TimeSeriesId(id[0]),
                    2 => new TimeSeriesId(id[0], id[1]),
                    3 => new TimeSeriesId(id[0], id[1], id[2]),
                    _ => throw new Exception($"Invalid number of Time Series Insights Id properties."),
                };

                Response<InstancesOperationResult[]> getInstancesResult = await instancesClient
                    .GetByIdAsync(new List<TimeSeriesId> { tsId })
                    .ConfigureAwait(false);

                if (getInstancesResult.Value?.First()?.Error != null)
                {
                    return tsId;
                }
            }

            throw new Exception($"Unique Id could not be found");
        }

        protected async Task<string> getDefaultTypeIdAsync(TimeSeriesInsightsModelSettings modelSettingsClient)
        {
            Response<TimeSeriesModelSettings> currentSettings = await modelSettingsClient.GetAsync().ConfigureAwait(false);
            return currentSettings.Value.DefaultTypeId;
        }

        private async Task<string> GetUniqueDeviceIdAsync(Func<string, Task<Device>> getDevice)
        {
            string id = Recording.GenerateAlphaNumericId("TSI_E2E_");

            for (int i = 0; i < MaxTries; i++)
            {
                Device device = await getDevice(id).ConfigureAwait(false);
                if (device == null)
                {
                    return id;
                }
                id = Recording.GenerateAlphaNumericId("TSI_E2E_");
            }

            throw new Exception($"Unique Id could not be found.");
        }
    }
}
