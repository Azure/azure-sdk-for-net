namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class SecurityRulePutResponse
    {
        /// <summary>
        /// Gets the security rule in a network security group
        /// </summary>
        [JsonProperty(PropertyName = "SecurityRule")]
        public SecurityRule SecurityRule { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public Error Error { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.SecurityRule != null)
            {
                this.SecurityRule.Validate();
            }
            if (this.Error != null)
            {
                this.Error.Validate();
            }
        }
    }
}
