namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Describes Protocol and thumbprint of Windows Remote Management listener
    /// </summary>
    public partial class WinRMListener
    {
        /// <summary>
        /// Gets or sets the Protocol used by WinRM listener. Currently only
        /// Http and Https are supported. Possible values for this property
        /// include: 'Http', 'Https'
        /// </summary>
        [JsonProperty(PropertyName = "protocol")]
        public ProtocolTypes? Protocol { get; set; }

        /// <summary>
        /// Gets or sets the Certificate URL in KMS for Https listeners.
        /// Should be null for Http listeners.
        /// </summary>
        [JsonProperty(PropertyName = "certificateUrl")]
        public string CertificateUrl { get; set; }

    }
}
