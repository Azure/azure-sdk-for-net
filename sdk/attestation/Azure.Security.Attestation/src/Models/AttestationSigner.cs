// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a certificate/key ID pair, used to validate a <see cref="AttestationToken"/>.
    /// </summary>
    [CodeGenModel("AttestationSigner")]
    public class AttestationSigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationSigner"/> class.
        /// </summary>
        /// <param name="signingCertificates"></param>
        /// <param name="certificateKeyId"></param>
        public AttestationSigner(IEnumerable<X509Certificate2> signingCertificates, string certificateKeyId)
        {
            SigningCertificates = signingCertificates switch
            {
                IReadOnlyList<X509Certificate2> certificateList => certificateList,
                _ => signingCertificates.ToList().AsReadOnly()
            };
            CertificateKeyId = certificateKeyId;
        }

        /// <summary>
        /// Returns the X.509 Certificate chain which can be used to sign an attestation token.
        /// <remarks>If this <see cref="AttestationSigner"/> is used to sign a certificate, then the FIRST certificate in the <see cref="AttestationSigner.SigningCertificates"/> list will have been used to sign the token.</remarks>
        /// </summary>
        public IReadOnlyList<X509Certificate2> SigningCertificates {get; internal set; }

        /// <summary>
        /// Returns the Key ID for the returned signing certificate. <seealso href="https://tools.ietf.org/html/rfc7517#section-4.5"/> for more information about the Key ID parameter.
        /// </summary>
        public string CertificateKeyId { get; internal set; }

        internal static IReadOnlyList<AttestationSigner> FromJsonWebKeySet(JsonWebKeySet keys)
        {
            List<AttestationSigner> returnedCertificates = new List<AttestationSigner>();
            foreach (var key in keys.Keys)
            {
                returnedCertificates.Add(FromJsonWebKey(key));
            }
            return returnedCertificates.AsReadOnly();
        }

        internal static AttestationSigner FromJsonWebKey(JsonWebKey key)
        {
            List<X509Certificate2> certificates = new List<X509Certificate2>();
            string keyId = key.Kid;

            if (key.X5C != null)
            {
                foreach (string x5c in key.X5C)
                {
#pragma warning disable SYSLIB0057 // Type or member is obsolete
                    certificates.Add(new X509Certificate2(Convert.FromBase64String(x5c)));
#pragma warning restore SYSLIB0057 // Type or member is obsolete
                }
            }
            return new AttestationSigner(certificates.ToArray(), keyId);
        }
    }
}
