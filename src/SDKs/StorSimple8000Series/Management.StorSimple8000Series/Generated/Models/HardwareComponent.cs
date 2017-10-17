
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The hardware component.
    /// </summary>
    public partial class HardwareComponent
    {
        /// <summary>
        /// Initializes a new instance of the HardwareComponent class.
        /// </summary>
        public HardwareComponent() { }

        /// <summary>
        /// Initializes a new instance of the HardwareComponent class.
        /// </summary>
        /// <param name="componentId">The component ID.</param>
        /// <param name="displayName">The display name of the hardware
        /// component.</param>
        /// <param name="status">The status of the hardware component. Possible
        /// values include: 'Unknown', 'NotPresent', 'PoweredOff', 'Ok',
        /// 'Recovering', 'Warning', 'Failure'</param>
        /// <param name="statusDisplayName">The display name of the status of
        /// hardware component.</param>
        public HardwareComponent(string componentId, string displayName, HardwareComponentStatus status, string statusDisplayName)
        {
            ComponentId = componentId;
            DisplayName = displayName;
            Status = status;
            StatusDisplayName = statusDisplayName;
        }

        /// <summary>
        /// Gets or sets the component ID.
        /// </summary>
        [JsonProperty(PropertyName = "componentId")]
        public string ComponentId { get; set; }

        /// <summary>
        /// Gets or sets the display name of the hardware component.
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the status of the hardware component. Possible values
        /// include: 'Unknown', 'NotPresent', 'PoweredOff', 'Ok', 'Recovering',
        /// 'Warning', 'Failure'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public HardwareComponentStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the display name of the status of hardware component.
        /// </summary>
        [JsonProperty(PropertyName = "statusDisplayName")]
        public string StatusDisplayName { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ComponentId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ComponentId");
            }
            if (DisplayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DisplayName");
            }
            if (StatusDisplayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "StatusDisplayName");
            }
        }
    }
}

