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
    /// Identity registry statistics.
    /// </summary>
    public partial class RegistryStatistics
    {
        /// <summary>
        /// Initializes a new instance of the RegistryStatistics class.
        /// </summary>
        public RegistryStatistics() { }

        /// <summary>
        /// Initializes a new instance of the RegistryStatistics class.
        /// </summary>
        public RegistryStatistics(long? totalDeviceCount = default(long?), long? enabledDeviceCount = default(long?), long? disabledDeviceCount = default(long?))
        {
            TotalDeviceCount = totalDeviceCount;
            EnabledDeviceCount = enabledDeviceCount;
            DisabledDeviceCount = disabledDeviceCount;
        }

        /// <summary>
        /// The total count of devices in the identity registry.
        /// </summary>
        [JsonProperty(PropertyName = "totalDeviceCount")]
        public long? TotalDeviceCount { get; private set; }

        /// <summary>
        /// The count of enabled devices in the identity registry.
        /// </summary>
        [JsonProperty(PropertyName = "enabledDeviceCount")]
        public long? EnabledDeviceCount { get; private set; }

        /// <summary>
        /// The count of disabled devices in the identity registry.
        /// </summary>
        [JsonProperty(PropertyName = "disabledDeviceCount")]
        public long? DisabledDeviceCount { get; private set; }

    }
}
