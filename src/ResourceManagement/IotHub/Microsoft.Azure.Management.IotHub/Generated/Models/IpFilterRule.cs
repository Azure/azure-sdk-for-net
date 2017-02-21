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
    /// The IP filter rules for the IoT hub.
    /// </summary>
    public partial class IpFilterRule
    {
        /// <summary>
        /// Initializes a new instance of the IpFilterRule class.
        /// </summary>
        public IpFilterRule() { }

        /// <summary>
        /// Initializes a new instance of the IpFilterRule class.
        /// </summary>
        public IpFilterRule(string filterName, IpFilterActionType action, string ipMask)
        {
            FilterName = filterName;
            Action = action;
            IpMask = ipMask;
        }

        /// <summary>
        /// The name of the IP filter rule.
        /// </summary>
        [JsonProperty(PropertyName = "filterName")]
        public string FilterName { get; set; }

        /// <summary>
        /// The desired action for requests captured by this rule. Possible
        /// values include: 'Accept', 'Reject'
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public IpFilterActionType Action { get; set; }

        /// <summary>
        /// A string that contains the IP address range in CIDR notation for
        /// the rule.
        /// </summary>
        [JsonProperty(PropertyName = "ipMask")]
        public string IpMask { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (FilterName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FilterName");
            }
            if (IpMask == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "IpMask");
            }
        }
    }
}
