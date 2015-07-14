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
    public partial class VaultSecretGroup
    {
        /// <summary>
        /// Gets or sets the Relative URL of the Key Vault containing all of
        /// the certificates in VaultCertificates.
        /// </summary>
        [JsonProperty(PropertyName = "sourceVault")]
        public SubResource SourceVault { get; set; }

        /// <summary>
        /// Gets or sets the list of key vault references in SourceVault which
        /// contain certificates
        /// </summary>
        [JsonProperty(PropertyName = "vaultCertificates")]
        public IList<VaultCertificate> VaultCertificates { get; set; }

    }
}
