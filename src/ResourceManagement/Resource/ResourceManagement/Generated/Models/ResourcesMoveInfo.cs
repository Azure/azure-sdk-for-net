namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class ResourcesMoveInfo
    {
        /// <summary>
        /// Gets or sets the ids of the resources.
        /// </summary>
        [JsonProperty(PropertyName = "resources")]
        public IList<string> Resources { get; set; }

        /// <summary>
        /// The target resource group.
        /// </summary>
        [JsonProperty(PropertyName = "targetResourceGroup")]
        public string TargetResourceGroup { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
