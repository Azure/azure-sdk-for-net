
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The collection of network adapters on the device.
    /// </summary>
    public partial class NetworkAdapterList
    {
        /// <summary>
        /// Initializes a new instance of the NetworkAdapterList class.
        /// </summary>
        public NetworkAdapterList() { }

        /// <summary>
        /// Initializes a new instance of the NetworkAdapterList class.
        /// </summary>
        /// <param name="value">The value.</param>
        public NetworkAdapterList(IList<NetworkAdapters> value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<NetworkAdapters> Value { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Value == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Value");
            }
            if (Value != null)
            {
                foreach (var element in Value)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}

