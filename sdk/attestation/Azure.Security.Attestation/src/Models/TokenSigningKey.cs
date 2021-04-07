// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// An AttestationSigningKey encapsulates the two pieces of information necessary to sign a token:
    /// <list type="bullet">
    /// <item><term>Signing Key</term><description>the key used to sign the token</description></item>
    /// <item><term>Signing Certificate</term><description>an X.509 certificate which wraps the public key part of the Signing Key.</description></item>
    /// </list>
    /// <para/>
    /// Note that the Attestation Service only supports validation of tokens which are signed with an X.509 certificate, it does not support arbitrary signing keys.
    /// </summary>
    public class TokenSigningKey
    {
        /// <summary>
        /// Creates a new instance of a <see cref="TokenSigningKey"/>
        /// </summary>
        /// <param name="signer">The Signing Key which will be used to sign the generated token.</param>
        /// <param name="certificate">An X.509 Certificate which wraps the public key part of the <paramref name="signer"/>.</param>
        public TokenSigningKey(AsymmetricAlgorithm signer, X509Certificate2 certificate)
        {
            Argument.AssertNotNull(signer, nameof(signer));
            Argument.AssertNotNull(certificate, nameof(certificate));
            Signer = signer;
            Certificate = certificate;
            VerifySignerMatchesCertificate(signer, certificate);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="TokenSigningKey"/>
        /// </summary>
        /// <param name="certificate">An X.509 Certificate with a private key.</param>
        public TokenSigningKey(X509Certificate2 certificate)
        {
            Argument.AssertNotNull(certificate, nameof(certificate));
            if (!certificate.HasPrivateKey)
            {
                throw new ArgumentException($"Certificate provided {certificate.ToString()} does not have a private key.");
            }
            Signer = certificate.PrivateKey;
            Certificate = certificate;
            VerifySignerMatchesCertificate(Signer, Certificate);
        }

        /// <summary>
        /// Gets the signer used to sign the attestation token
        /// </summary>
        public AsymmetricAlgorithm Signer { get; }

        /// <summary>
        /// Gets the X.509 Certificate which will be transmitted to the attestation service to validate the signed token.
        /// </summary>
        public X509Certificate2 Certificate { get; }

        private static void VerifySignerMatchesCertificate(AsymmetricAlgorithm signer, X509Certificate2 certificate)
        {
            if (!signer.KeyExchangeAlgorithm.StartsWith(certificate.PublicKey.Key.KeyExchangeAlgorithm, System.StringComparison.Ordinal))
            {
                throw new ArgumentException($"Signer key algorithm {signer.SignatureAlgorithm} does not match certificate key algorithm {certificate.PublicKey.Key.SignatureAlgorithm}");
            }

            if (signer is RSA rsaKey)
            {
                var certificateKey = certificate.PublicKey.Key as RSA;
                RSAParameters signerParameters = rsaKey.ExportParameters(false);
                RSAParameters certificateParameters = certificateKey.ExportParameters(false);
                if (!signerParameters.Modulus.SequenceEqual(certificateParameters.Modulus) ||
                    !signerParameters.Exponent.SequenceEqual(certificateParameters.Exponent))
                {
                    throw new ArgumentException($"Signer key {signer} does not match certificate key {certificateKey}");
                }
            }
#if false
            else if (signer is ECDsa ecdh)
            {
                var certificateKey = certificate.PublicKey.Key as ECDsa;
                ECParameters signerParameters = ecdh.ExportParameters(false);
                ECParameters certificateParameters = certificateKey.ExportParameters(false);
                if (!signerParameters.Curve.Equals(certificateParameters.Curve) ||
                    !signerParameters.Q.Equals(certificateParameters.Q))
                {
                    throw new ArgumentException($"Signer key {signer} does not match certificate key {certificateKey}");
                }
            }
#endif
            else
            {
                throw new ArgumentException("Unknown crypto algorithm for signer and certificate");
            }
#if false

            string signerKey = signer.ToXmlString(false);
            string certificateKey = certificate.PublicKey.Key.ToXmlString(false);
            if (signerKey != certificateKey)
            {
                throw new ArgumentException($"Signer key {signerKey} does not match certificate key {certificateKey}");
            }
#endif
        }
    }
}
