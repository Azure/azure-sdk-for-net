
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Represents available provider operation.
    /// </summary>
    public partial class AvailableProviderOperation
    {
        /// <summary>
        /// Initializes a new instance of the AvailableProviderOperation class.
        /// </summary>
        public AvailableProviderOperation() { }

        /// <summary>
        /// Initializes a new instance of the AvailableProviderOperation class.
        /// </summary>
        /// <param name="name">The name of the operation being performed on a
        /// particular object. Name format:
        /// "{resourceProviderNamespace}/{resourceType}/{read|write|delete|action}".
        /// Eg. Microsoft.StorSimple/managers/devices/volumeContainers/read,
        /// Microsoft.StorSimple/managers/devices/alerts/clearAlerts/action</param>
        /// <param name="display">Contains the localized display information
        /// for this particular operation/action.</param>
        /// <param name="origin">The intended executor of the operation;
        /// governs the display of the operation in the RBAC UX and the audit
        /// logs UX. Default value is "user,system"</param>
        /// <param name="properties">Reserved for future use.</param>
        public AvailableProviderOperation(string name = default(string), AvailableProviderOperationDisplay display = default(AvailableProviderOperationDisplay), string origin = default(string), object properties = default(object))
        {
            Name = name;
            Display = display;
            Origin = origin;
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets the name of the operation being performed on a
        /// particular object. Name format:
        /// "{resourceProviderNamespace}/{resourceType}/{read|write|delete|action}".
        /// Eg. Microsoft.StorSimple/managers/devices/volumeContainers/read,
        /// Microsoft.StorSimple/managers/devices/alerts/clearAlerts/action
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets contains the localized display information for this
        /// particular operation/action.
        /// </summary>
        [JsonProperty(PropertyName = "display")]
        public AvailableProviderOperationDisplay Display { get; set; }

        /// <summary>
        /// Gets or sets the intended executor of the operation; governs the
        /// display of the operation in the RBAC UX and the audit logs UX.
        /// Default value is "user,system"
        /// </summary>
        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; set; }

        /// <summary>
        /// Gets or sets reserved for future use.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public object Properties { get; set; }

    }
}

