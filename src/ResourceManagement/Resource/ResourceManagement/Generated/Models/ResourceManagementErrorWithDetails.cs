using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Resources.Models
{
    /// <summary>
    /// </summary>
    public partial class ResourceManagementErrorWithDetails
    {
        /// <summary>
        /// Gets or sets validation error.
        /// </summary>
        [JsonProperty(PropertyName = "details")]
        public IList<ResourceManagementError> Details { get; set; }

        /// <summary>
        /// Gets or sets the error code returned from the server.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the error message returned from the server.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the target of the error.
        /// </summary>
        [JsonProperty(PropertyName = "target")]
        public string Target { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Details != null)
            {
                foreach ( var element in this.Details)
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
