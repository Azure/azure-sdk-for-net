namespace Microsoft.Azure.Subscriptions.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class TenantListResult
    {
        /// <summary>
        /// Gets or sets tenant Ids.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<TenantIdDescription> Value { get; set; }

        /// <summary>
        /// Gets or sets the URL to get the next set of results.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; set; }

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
