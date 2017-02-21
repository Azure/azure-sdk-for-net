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
    /// IoT Hub capacity information.
    /// </summary>
    public partial class IotHubCapacity
    {
        /// <summary>
        /// Initializes a new instance of the IotHubCapacity class.
        /// </summary>
        public IotHubCapacity() { }

        /// <summary>
        /// Initializes a new instance of the IotHubCapacity class.
        /// </summary>
        public IotHubCapacity(long? minimum = default(long?), long? maximum = default(long?), long? defaultProperty = default(long?), IotHubScaleType? scaleType = default(IotHubScaleType?))
        {
            Minimum = minimum;
            Maximum = maximum;
            DefaultProperty = defaultProperty;
            ScaleType = scaleType;
        }

        /// <summary>
        /// The minimum number of units.
        /// </summary>
        [JsonProperty(PropertyName = "minimum")]
        public long? Minimum { get; private set; }

        /// <summary>
        /// The maximum number of units.
        /// </summary>
        [JsonProperty(PropertyName = "maximum")]
        public long? Maximum { get; private set; }

        /// <summary>
        /// The default number of units.
        /// </summary>
        [JsonProperty(PropertyName = "default")]
        public long? DefaultProperty { get; private set; }

        /// <summary>
        /// The type of the scaling enabled. Possible values include:
        /// 'Automatic', 'Manual', 'None'
        /// </summary>
        [JsonProperty(PropertyName = "scaleType")]
        public IotHubScaleType? ScaleType { get; private set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Minimum > 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Minimum", 1);
            }
            if (this.Minimum < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Minimum", 1);
            }
        }
    }
}
