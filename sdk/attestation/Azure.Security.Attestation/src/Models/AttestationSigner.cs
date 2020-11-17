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

        internal static AttestationSigner[] FromJsonWebKeySet(JsonWebKeySet keys)
        {
            List<AttestationSigner> returnedCertificates = new List<AttestationSigner>();
            foreach (var key in keys.Keys)
            {
                List<X509Certificate2> certificates = new List<X509Certificate2>();
                string keyId = key.Kid;

                if (key.X5C != null)
                {
                    foreach (string x5c in key.X5C)
                    {
                        certificates.Add(new X509Certificate2(Convert.FromBase64String(x5c)));
                    }
                }

                returnedCertificates.Add(new AttestationSigner(certificates.ToArray(), keyId));

            }
            return returnedCertificates.ToArray();

        }
    }
}
