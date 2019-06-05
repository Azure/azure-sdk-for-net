
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The hardware component group.
    /// </summary>
    [JsonTransformation]
    public partial class HardwareComponentGroup : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the HardwareComponentGroup class.
        /// </summary>
        public HardwareComponentGroup() { }

        /// <summary>
        /// Initializes a new instance of the HardwareComponentGroup class.
        /// </summary>
        /// <param name="displayName">The display name the hardware component
        /// group.</param>
        /// <param name="lastUpdatedTime">The last updated time.</param>
        /// <param name="components">The list of hardware components.</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        public HardwareComponentGroup(string displayName, System.DateTime lastUpdatedTime, IList<HardwareComponent> components, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?))
            : base(id, name, type, kind)
        {
            DisplayName = displayName;
            LastUpdatedTime = lastUpdatedTime;
            Components = components;
        }

        /// <summary>
        /// Gets or sets the display name the hardware component group.
        /// </summary>
        [JsonProperty(PropertyName = "properties.displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the last updated time.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastUpdatedTime")]
        public System.DateTime LastUpdatedTime { get; set; }

        /// <summary>
        /// Gets or sets the list of hardware components.
        /// </summary>
        [JsonProperty(PropertyName = "properties.components")]
        public IList<HardwareComponent> Components { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (DisplayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DisplayName");
            }
            if (Components == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Components");
            }
            if (Components != null)
            {
                foreach (var element in Components)
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

