// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// The IoT Hub Service Client
    /// </summary>
    public class IoTHubServiceClient
    {
        private readonly HttpPipeline _httpPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly RegistryManagerRestClient _registryManagerRestClient;
        private readonly TwinRestClient _twinRestClient;
        private readonly DeviceMethodRestClient _deviceMethodRestClient;

        /// <summary>
        /// place holder for Devices
        /// </summary>
        public DevicesClient Devices { get; private set; }
        /// <summary>
        /// place holder for Modules
        /// </summary>
        public ModulesClient Modules { get; private set; }
        /// <summary>
        /// place holder for Statistics
        /// </summary>
        public StatisticsClient Statistics { get; private set; }
        /// <summary>
        /// place holder for Messages
        /// </summary>
        public CloudToDeviceMessagesClient Messages { get; private set; }
        /// <summary>
        /// place holder for Files
        /// </summary>
        public FilesClient Files { get; private set; }
        /// <summary>
        /// place holder for Jobs
        /// </summary>
        public JobsClient Jobs { get; private set; }

        protected IoTHubServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        public IoTHubServiceClient(Uri endpoint)
            : this(endpoint, new IoTHubServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        public IoTHubServiceClient(Uri endpoint, IoTHubServiceClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            _registryManagerRestClient  = new RegistryManagerRestClient(_clientDiagnostics, _httpPipeline, endpoint, options.GetVersionString());
            _twinRestClient = new TwinRestClient(_clientDiagnostics, _httpPipeline, null, options.GetVersionString());
            _deviceMethodRestClient = new DeviceMethodRestClient(_clientDiagnostics, _httpPipeline, endpoint, options.GetVersionString());

            Devices = new DevicesClient(_registryManagerRestClient, _twinRestClient, _deviceMethodRestClient);
            Modules = new ModulesClient(_registryManagerRestClient, _twinRestClient, _deviceMethodRestClient);

            Statistics = new StatisticsClient();
            Messages = new CloudToDeviceMessagesClient();
            Files = new FilesClient();
            Jobs = new JobsClient();
        }
    }
}
