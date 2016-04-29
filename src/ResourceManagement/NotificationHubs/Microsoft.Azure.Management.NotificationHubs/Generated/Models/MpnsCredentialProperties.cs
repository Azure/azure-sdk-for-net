
namespace Microsoft.Azure.Management.NotificationHubs.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Description of a NotificationHub MpnsCredential.
    /// </summary>
    public partial class MpnsCredentialProperties
    {
        /// <summary>
        /// Initializes a new instance of the MpnsCredentialProperties class.
        /// </summary>
        public MpnsCredentialProperties() { }

        /// <summary>
        /// Initializes a new instance of the MpnsCredentialProperties class.
        /// </summary>
        public MpnsCredentialProperties(string mpnsCertificate = default(string), string certificateKey = default(string), string thumbprint = default(string))
        {
            MpnsCertificate = mpnsCertificate;
            CertificateKey = certificateKey;
            Thumbprint = thumbprint;
        }

        /// <summary>
        /// Gets or sets the MPNS certificate.
        /// </summary>
        [JsonProperty(PropertyName = "mpnsCertificate")]
        public string MpnsCertificate { get; set; }

        /// <summary>
        /// Gets or sets the certificate key for this credential.
        /// </summary>
        [JsonProperty(PropertyName = "certificateKey")]
        public string CertificateKey { get; set; }

        /// <summary>
        /// Gets or sets the Mpns certificate Thumbprint
        /// </summary>
        [JsonProperty(PropertyName = "thumbprint")]
        public string Thumbprint { get; set; }

    }
}
