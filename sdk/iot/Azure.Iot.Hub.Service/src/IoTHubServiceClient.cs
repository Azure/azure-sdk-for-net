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
        public Devices Devices;
        /// <summary>
        /// 
        /// </summary>
        public Modules Modules;
        /// <summary>
        /// 
        /// </summary>
        public Statistics Statistics;
        /// <summary>
        /// 
        /// </summary>
        public Messages Messages;
        /// <summary>
        /// 
        /// </summary>
        public Files Files;


        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        public IoTHubServiceClient(Uri endpoint, IoTHubServiceClientOptions options)
        {
            FaultInjectionClient = new FaultInjectionClient();
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        protected IoTHubServiceClient()
        {

        }
    }
}
