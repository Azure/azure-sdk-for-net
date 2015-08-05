namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// </summary>
    public partial class ClientCertAuthentication : HttpAuthentication
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the pfx.
        /// </summary>
        [JsonProperty(PropertyName = "pfx")]
        public string Pfx { get; set; }

        /// <summary>
        /// Gets or sets the certificate thumbprint.
        /// </summary>
        [JsonProperty(PropertyName = "certificateThumbprint")]
        public string CertificateThumbprint { get; set; }

        /// <summary>
        /// Gets or sets the certificate expiration date.
        /// </summary>
        [JsonProperty(PropertyName = "certificateExpirationDate")]
        public DateTime? CertificateExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the certificate subject name.
        /// </summary>
        [JsonProperty(PropertyName = "certificateSubjectName")]
        public string CertificateSubjectName { get; set; }

    }
}
