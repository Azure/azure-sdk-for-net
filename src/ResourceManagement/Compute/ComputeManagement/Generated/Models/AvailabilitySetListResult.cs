namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class AvailabilitySetListResult
    {
        /// <summary>
        /// Gets or sets the list of availability sets
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<AvailabilitySet> Value { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Value != null)
            {
                foreach ( var element in this.Value)
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
