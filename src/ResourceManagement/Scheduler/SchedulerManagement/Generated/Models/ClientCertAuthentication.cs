
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class ClientCertAuthentication : HttpAuthentication
    {
        /// <summary>
        /// Initializes a new instance of the ClientCertAuthentication class.
        /// </summary>
        public ClientCertAuthentication() { }

        /// <summary>
        /// Initializes a new instance of the ClientCertAuthentication class.
        /// </summary>
        public ClientCertAuthentication(HttpAuthenticationType? type = default(HttpAuthenticationType?), string password = default(string), string pfx = default(string), string certificateThumbprint = default(string), DateTime? certificateExpirationDate = default(DateTime?), string certificateSubjectName = default(string))
            : base(type)
        {
            Password = password;
            Pfx = pfx;
            CertificateThumbprint = certificateThumbprint;
            CertificateExpirationDate = certificateExpirationDate;
            CertificateSubjectName = certificateSubjectName;
        }

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
