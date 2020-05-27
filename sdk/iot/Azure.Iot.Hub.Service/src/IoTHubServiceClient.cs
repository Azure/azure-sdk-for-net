// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// The IoT Hub Service Client
    /// </summary>
    public class IoTHubServiceClient
    {
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

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        public IoTHubServiceClient()
            : this(new IoTHubServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        public IoTHubServiceClient(IoTHubServiceClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            Devices = new DevicesClient();
            Modules = new ModulesClient();
            Statistics = new StatisticsClient();
            Messages = new CloudToDeviceMessagesClient();
            Files = new FilesClient();
            Jobs = new JobsClient();
        }
    }
}
