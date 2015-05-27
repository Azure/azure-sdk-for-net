using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Storage.Models
{
    /// <summary>
    /// </summary>
    public partial class StorageAccountCreateParameters
    {
        /// <summary>
        /// Gets or sets the location of the resource. This will be one of the
        /// supported and registered Azure Geo Regions (e.g. West US, East
        /// US, Southeast Asia, etc.). The geo region of a resource cannot be
        /// changed once it is created.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource.
        /// These tags can be used in viewing and grouping this resource
        /// (across resource groups). A maximum of 15 tags can be provided
        /// for a resource. Each tag must have a key no greater than 128
        /// characters and value no greater than 256 characters.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public StorageAccountPropertiesCreateParametersJson Properties { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Properties != null)
            {
                this.Properties.Validate();
            }
        }
    }
}
