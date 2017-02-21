// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The operations monitoring properties for the IoT hub. The possible
    /// keys to the dictionary are Connections, DeviceTelemetry, C2DCommands,
    /// DeviceIdentityOperations, FileUploadOperations.
    /// </summary>
    public partial class OperationsMonitoringProperties
    {
        /// <summary>
        /// Initializes a new instance of the OperationsMonitoringProperties
        /// class.
        /// </summary>
        public OperationsMonitoringProperties() { }

        /// <summary>
        /// Initializes a new instance of the OperationsMonitoringProperties
        /// class.
        /// </summary>
        public OperationsMonitoringProperties(IDictionary<string, string> events = default(IDictionary<string, string>))
        {
            Events = events;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "events")]
        public IDictionary<string, string> Events { get; set; }

    }
}
