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
    public partial class ApplicationGatewayHttpListener : SubResource
    {
        /// <summary>
        /// Gets name of the resource that is unique within a resource group.
        /// This name can be used to access the resource
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is
        /// updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets frontend IP configuration resource of application
        /// gateway
        /// </summary>
        [JsonProperty(PropertyName = "frontendIpConfiguration")]
        public SubResource FrontendIpConfiguration { get; set; }

        /// <summary>
        /// Gets or sets frontend port resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "frontendPort")]
        public SubResource FrontendPort { get; set; }

        /// <summary>
        /// Gets or sets the protocol. Possible values for this property
        /// include: 'Http', 'Https'
        /// </summary>
        [JsonProperty(PropertyName = "protocol")]
        public ApplicationGatewayProtocol? Protocol { get; set; }

        /// <summary>
        /// Gets or sets ssl certificate resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "sslCertificate")]
        public SubResource SslCertificate { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.FrontendIpConfiguration != null)
            {
                this.FrontendIpConfiguration.Validate();
            }
            if (this.FrontendPort != null)
            {
                this.FrontendPort.Validate();
            }
            if (this.SslCertificate != null)
            {
                this.SslCertificate.Validate();
            }
        }
    }
}
