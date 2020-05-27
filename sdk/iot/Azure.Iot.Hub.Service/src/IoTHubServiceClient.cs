// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

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
        public DevicesClient Devices;
        /// <summary>
        /// place holder for Modules
        /// </summary>
        public ModulesClient Modules;
        /// <summary>
        /// place holder for Statistics
        /// </summary>
        public StatisticsClient Statistics;
        /// <summary>
        /// place holder for Messages
        /// </summary>
        public CloudToDeviceMessagesClient Messages;
        /// <summary>
        /// place holder for Files
        /// </summary>
        public FilesClient Files;
        /// <summary>
        /// place holder for Jobs
        /// </summary>
        public JobsClient Jobs;

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        protected IoTHubServiceClient()
        {

        }
    }
}
