// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Azure.Security.Attestation.Models
{
    /// <summary>
    /// Represents a certificate/key ID pair, used to validate a <see cref="AttestationToken{TBodyType}"/>.
    /// </summary>
    public class AttestationSigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationSigner"/> class.
        /// </summary>
        /// <param name="signingCertificates"></param>
        /// <param name="certificateKeyId"></param>
        public AttestationSigner(X509Certificate2[] signingCertificates, string certificateKeyId)
        {
            SigningCertificates = signingCertificates;
            CertificateKeyId = certificateKeyId;
        }

        /// <summary>
        /// Returns the actual signing certificate.
        /// </summary>
        public X509Certificate2[] SigningCertificates {get; internal set; }

        /// <summary>
        /// Returns the Key ID for the returned signing certificate.
        /// </summary>
        public string CertificateKeyId { get; internal set; }
    }
}
