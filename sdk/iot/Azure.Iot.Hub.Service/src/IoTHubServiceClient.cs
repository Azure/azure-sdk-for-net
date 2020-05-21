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
        /// 
        /// </summary>
        public DevicesClient Devices;
        /// <summary>
        /// 
        /// </summary>
        public ModulesClient Modules;
        /// <summary>
        /// 
        /// </summary>
        public StatisticsClient Statistics;
        /// <summary>
        /// 
        /// </summary>
        public MessagesClient Messages;
        /// <summary>
        /// 
        /// </summary>
        public FilesClient Files;
        /// <summary>
        /// 
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
