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
    /// Information about the SKU of the IoT hub.
    /// </summary>
    public partial class IotHubSkuInfo
    {
        /// <summary>
        /// Initializes a new instance of the IotHubSkuInfo class.
        /// </summary>
        public IotHubSkuInfo() { }

        /// <summary>
        /// Initializes a new instance of the IotHubSkuInfo class.
        /// </summary>
        public IotHubSkuInfo(string name, long capacity, IotHubSkuTier? tier = default(IotHubSkuTier?))
        {
            Name = name;
            Tier = tier;
            Capacity = capacity;
        }

        /// <summary>
        /// The name of the SKU. Possible values include: 'F1', 'S1', 'S2',
        /// 'S3'
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The billing tier for the IoT hub. Possible values include: 'Free',
        /// 'Standard'
        /// </summary>
        [JsonProperty(PropertyName = "tier")]
        public IotHubSkuTier? Tier { get; private set; }

        /// <summary>
        /// The number of provisioned IoT Hub units. See:
        /// https://docs.microsoft.com/azure/azure-subscription-service-limits#iot-hub-limits.
        /// </summary>
        [JsonProperty(PropertyName = "capacity")]
        public long Capacity { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
        }
    }
}
