// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Cdn.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The JSON object that contains the properties to secure a domain.
    /// </summary>
    public partial class AFDDomainHttpsParameters
    {
        /// <summary>
        /// Initializes a new instance of the AFDDomainHttpsParameters class.
        /// </summary>
        public AFDDomainHttpsParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AFDDomainHttpsParameters class.
        /// </summary>
        /// <param name="certificateType">Defines the source of the SSL
        /// certificate. Possible values include: 'CustomerCertificate',
        /// 'ManagedCertificate'</param>
        /// <param name="minimumTlsVersion">TLS protocol version that will be
        /// used for Https. Possible values include: 'TLS10', 'TLS12'</param>
        /// <param name="secret">Resource reference to the secret. ie.
        /// subs/rg/profile/secret</param>
        public AFDDomainHttpsParameters(string certificateType, AfdMinimumTlsVersion? minimumTlsVersion = default(AfdMinimumTlsVersion?), ResourceReference secret = default(ResourceReference))
        {
            CertificateType = certificateType;
            MinimumTlsVersion = minimumTlsVersion;
            Secret = secret;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets defines the source of the SSL certificate. Possible
        /// values include: 'CustomerCertificate', 'ManagedCertificate'
        /// </summary>
        [JsonProperty(PropertyName = "certificateType")]
        public string CertificateType { get; set; }

        /// <summary>
        /// Gets or sets TLS protocol version that will be used for Https.
        /// Possible values include: 'TLS10', 'TLS12'
        /// </summary>
        [JsonProperty(PropertyName = "minimumTlsVersion")]
        public AfdMinimumTlsVersion? MinimumTlsVersion { get; set; }

        /// <summary>
        /// Gets or sets resource reference to the secret. ie.
        /// subs/rg/profile/secret
        /// </summary>
        [JsonProperty(PropertyName = "secret")]
        public ResourceReference Secret { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (CertificateType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "CertificateType");
            }
        }
    }
}
