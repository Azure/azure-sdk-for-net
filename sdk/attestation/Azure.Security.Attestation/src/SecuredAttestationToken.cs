// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Security.Attestation.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Security.Cryptography;
using System.Text.Json;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a Secured JSON Web Token object. See http://tools.ietf.org/html/rfc7515 for more information.
    /// </summary>
    public class SecuredAttestationToken : AttestationToken
    {
        /// <summary>
        /// Creates a new Attestation token based on the supplied body and certificate.
        /// </summary>
        /// <param name="body">Body of the newly created token.</param>
        /// <param name="signingCertificate">Signing certificate used to create the key. Note that the PrivateKey of the certificate must be set.</param>
        /// <returns></returns>
        public SecuredAttestationToken(object body, X509Certificate2 signingCertificate)
            : base(GenerateSecuredJsonWebToken(body, signingCertificate))
        {
        }

        /// <summary>
        /// Creates a new Attestation token with an empty body, signed by the private key embedded in the certificate.
        /// </summary>
        /// <param name="signingCertificate">Signing certificate used to create the key. Note that the PrivateKey of the certificate must be set.</param>
        /// <returns></returns>
        public SecuredAttestationToken(X509Certificate2 signingCertificate)
            : base(GenerateSecuredJsonWebToken(null, signingCertificate))
        {
        }

        /// <summary>
        /// Creates a new attestation token based on the supplied body, certificate, and private key.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="signingKey"></param>
        /// <param name="signingCertificate"></param>
        public SecuredAttestationToken(object body, AsymmetricAlgorithm signingKey, X509Certificate2 signingCertificate)
            : base(GenerateSecuredJsonWebToken(body, signingKey, signingCertificate))
        {
        }

        /// <summary>
        /// Creates a new attestation token with an empty body based on the supplied body and certificate
        /// </summary>
        /// <param name="signingKey"></param>
        /// <param name="signingCertificate"></param>
        public SecuredAttestationToken(AsymmetricAlgorithm signingKey, X509Certificate2 signingCertificate)
            : base(GenerateSecuredJsonWebToken(null, signingKey, signingCertificate))
        {
        }

        /// <summary>
        /// Create a secured JSON Web TOken based on the specified token body and the specified X.509 signing certificate with an embedded private key.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="signingCertificate"></param>
        /// <returns></returns>
        private static string GenerateSecuredJsonWebToken(object body, X509Certificate2 signingCertificate)
        {
            Argument.AssertNotNull(signingCertificate, nameof(signingCertificate));
            Argument.AssertNotNull(signingCertificate.PrivateKey, nameof(signingCertificate.PrivateKey));

            return GenerateSecuredJsonWebToken(body, signingCertificate.PrivateKey, signingCertificate);
        }

        /// <summary>
        /// Create a secured JSON Web TOken based on the specified token body and the specified X.509 signing certificate with an embedded private key.
        /// </summary>
        /// <param name="body">Object to be embeeded as the body of the attestation token.</param>
        /// <param name="signingKey">Key used to sign the attestation token.</param>
        /// <param name="signingCertificate">Signing Certificate to be included in the token.</param>
        /// <returns></returns>
        private static string GenerateSecuredJsonWebToken(object body, AsymmetricAlgorithm signingKey, X509Certificate2 signingCertificate)
        {
            Argument.AssertNotNull(signingCertificate, nameof(signingCertificate));
            Argument.AssertNotNull(signingKey, nameof(signingKey));

            JsonWebTokenHeader header = new JsonWebTokenHeader
            {
                Algorithm = signingKey is RSA ? "RSA256" : (signingKey is ECDsa ? "ECDH256" : null),
                X509CertificateChain = new string[] { Convert.ToBase64String(signingCertificate.Export(X509ContentType.Cert)) },
            };
            var serializationOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
            };
            byte[] jwtHeader = JsonSerializer.SerializeToUtf8Bytes<JsonWebTokenHeader>(header, serializationOptions);
            string encodedHeader = Base64Url.Encode(jwtHeader);

            byte[] jwtBody = null;
            if (body != null)
            {
                jwtBody = JsonSerializer.SerializeToUtf8Bytes(body, serializationOptions);
            }

            string encodedBody = jwtBody != null ? Base64Url.Encode(jwtBody) : string.Empty;

            string signedData = encodedHeader + '.' + encodedBody;

            byte[] signature;
            if (signingKey is RSA rsaKey)
            {
                signature = rsaKey.SignData(Encoding.UTF8.GetBytes(signedData), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
            else if (signingKey is ECDsa ecdh)
            {
                signature = ecdh.SignData(Encoding.UTF8.GetBytes(signedData), HashAlgorithmName.SHA256);
            }
            else
            {
                throw new JsonException();
            }

            string jwt = signedData + '.' + Base64Url.Encode(signature);

            return jwt;
        }
    }
}
