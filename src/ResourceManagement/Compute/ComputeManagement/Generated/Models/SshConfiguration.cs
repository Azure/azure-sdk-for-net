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
    public partial class SshConfiguration
    {
        /// <summary>
        /// Gets or sets the list of SSH public keys used to authenticate with
        /// linux based VMs
        /// </summary>
        [JsonProperty(PropertyName = "publicKeys")]
        public IList<SshPublicKey> PublicKeys { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.PublicKeys != null)
            {
                foreach ( var element in this.PublicKeys)
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
