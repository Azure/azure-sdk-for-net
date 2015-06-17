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
    public partial class ConnectionResetSharedKeyPutResponse
    {
        /// <summary>
        /// Puts the virtual network gateway connection reset shared key that
        /// exists in a resource group
        /// </summary>
        [JsonProperty(PropertyName = "ConnectionResetSharedKey")]
        public ConnectionResetSharedKey ConnectionResetSharedKey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public Error Error { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.ConnectionResetSharedKey != null)
            {
                this.ConnectionResetSharedKey.Validate();
            }
            if (this.Error != null)
            {
                this.Error.Validate();
            }
        }
    }
}
