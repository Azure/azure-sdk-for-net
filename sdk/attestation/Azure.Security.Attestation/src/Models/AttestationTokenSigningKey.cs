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
    public class AttestationTokenSigningKey
    {
        /// <summary>
        /// Creates a new instance of a <see cref="AttestationTokenSigningKey"/>
        /// </summary>
        /// <param name="signer">The RSA key which will be used to sign the generated token.</param>
        /// <param name="certificate">An X.509 Certificate which wraps the public key part of the <paramref name="signer"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="signer"/> is not an RSA key, or does not match <paramref name="certificate"/>.</exception>
        public AttestationTokenSigningKey(AsymmetricAlgorithm signer, X509Certificate2 certificate)
        {
            Argument.AssertNotNull(signer, nameof(signer));
            Argument.AssertNotNull(certificate, nameof(certificate));
            if (!(signer is RSA rsaSigner))
            {
                throw new ArgumentException("The signing key must be an RSA key.", nameof(signer));
            }
            Signer = signer;
            Certificate = certificate;
            VerifySignerMatchesCertificate(rsaSigner, certificate);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="AttestationTokenSigningKey"/>
        /// </summary>
        /// <param name="certificate">An X.509 Certificate with an RSA private key.</param>
        /// <exception cref="ArgumentException"><paramref name="certificate"/> does not have an RSA private key.</exception>
        public AttestationTokenSigningKey(X509Certificate2 certificate)
        {
            Argument.AssertNotNull(certificate, nameof(certificate));
            if (!certificate.HasPrivateKey)
            {
                throw new ArgumentException($"Certificate provided {certificate.ToString()} does not have a private key.");
            }
            // Checked before the private key is loaded, which throws for some other key types on .NET Framework.
            GetRsaPublicKey(certificate).Dispose();
#if NET6_0_OR_GREATER
            RSA signer = certificate.GetRSAPrivateKey();
#else
            // On .NET Framework, only PrivateKey returns an RSA key that was assigned to the certificate in memory.
            RSA signer = certificate.PrivateKey as RSA;
#endif
            Signer = signer ?? throw new ArgumentException($"Certificate provided {certificate} does not have an RSA private key.", nameof(certificate));
            Certificate = certificate;
            VerifySignerMatchesCertificate(signer, Certificate);
        }

        /// <summary>
        /// Gets the signer used to sign the attestation token
        /// </summary>
        public AsymmetricAlgorithm Signer { get; }

        /// <summary>
        /// Gets the X.509 Certificate which will be transmitted to the attestation service to validate the signed token.
        /// </summary>
        public X509Certificate2 Certificate { get; }

        private static RSA GetRsaPublicKey(X509Certificate2 certificate)
            => certificate.GetRSAPublicKey() ?? throw new ArgumentException("The certificate must have an RSA key.", nameof(certificate));

        private static void VerifySignerMatchesCertificate(RSA signer, X509Certificate2 certificate)
        {
            using RSA publicKey = GetRsaPublicKey(certificate);

            // Try to match the public key in the certificate and the signer. If the platform
            // supports the ToXmlString API, then use that since it the simplest solution and is relatively fast.
            try
            {
                string signerKey = signer.ToXmlString(false);
                string certificateKey = publicKey.ToXmlString(false);
                if (signerKey != certificateKey)
                {
                    throw new ArgumentException($"Signer key {signerKey} does not match certificate key {certificateKey}");
                }
                return;
            }
            catch (System.PlatformNotSupportedException)
            {
                // Fall back to comparing the keys by signing.
            }

            // Try signing a document with the signer and verifying it with the key in the certificate.
            byte[] testDataToSign = { 1, 2, 3, 4, 5, 6, 7 };
            byte[] signature = signer.SignData(testDataToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            if (!publicKey.VerifyData(testDataToSign, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1))
            {
                throw new ArgumentException("Provided certificate cannot verify buffer signed with signing key.");
            }
        }
    }
}
