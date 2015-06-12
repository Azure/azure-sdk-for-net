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
    public partial class Provider
    {
        /// <summary>
        /// Gets or sets the provider id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the namespace of the provider.
        /// </summary>
        [JsonProperty(PropertyName = "namespace")]
        public string NamespaceProperty { get; set; }

        /// <summary>
        /// Gets or sets the registration state of the provider.
        /// </summary>
        [JsonProperty(PropertyName = "registrationState")]
        public string RegistrationState { get; set; }

        /// <summary>
        /// Gets or sets the collection of provider resource types.
        /// </summary>
        [JsonProperty(PropertyName = "resourceTypes")]
        public IList<ProviderResourceType> ResourceTypes { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.ResourceTypes != null)
            {
                foreach ( var element in this.ResourceTypes)
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
