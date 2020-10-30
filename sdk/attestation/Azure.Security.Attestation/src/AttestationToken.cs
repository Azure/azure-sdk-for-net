// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Security.Attestation.Models;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents an Attestation Token object.
    /// </summary>
    public class AttestationToken
    {
        protected private string _token;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationToken"/> class.
        /// </summary>
        /// <param name="token">string JWT to initialize.</param>
        internal AttestationToken(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Protected token for mocking.
        /// </summary>
        protected AttestationToken()
        {

        }

        /// <summary>
        /// Returns the thumbprint of the X.509 certificate which was used to verify the attestation token.
        ///
        /// Null until the <see cref="AttestationToken.ValidateToken(AttestationSigner[], Func{string, bool})"/> method has been called.
        /// </summary>
        public string VerifyingCertificateThumbprint { get; }

        /// <summary>
        /// Decoded header for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public byte[] TokenHeader { get; }

        /// <summary>
        /// Decoded body for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public byte[] TokenBody { get; }

        /// <summary>
        /// Decoded signature for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public byte[] TokenSignature { get; }

        /// <summary>
        /// Creates a new Attestation token based on the supplied body and certificate.
        /// </summary>
        /// <typeparam name="TBodyType"></typeparam>
        /// <param name="body"></param>
        /// <param name="signingCertificate">Signing certificate used to create the key. Note that the PrivateKey of the certificate must be set.</param>
        /// <returns></returns>
        public static AttestationToken<TBodyType> CreateToken<TBodyType>(TBodyType body, System.Security.Cryptography.X509Certificates.X509Certificate2 signingCertificate)
            where TBodyType : class
        {
            Argument.AssertNotNull(body, nameof(body));
            Argument.AssertNotNull(signingCertificate, nameof(signingCertificate));
            Argument.AssertNotNull(signingCertificate.PrivateKey, nameof(signingCertificate.PrivateKey));
            throw new NotImplementedException();

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationToken{TBodyType}"/> class.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="signingKey"></param>
        /// <param name="signingCertificate"></param>
        public static AttestationToken<TBodyType> CreateToken<TBodyType>(TBodyType body, System.Security.Cryptography.RSA signingKey = null, X509Certificate2 signingCertificate = null)
            where TBodyType : class
        {
            Argument.AssertNotNull(body, nameof(body));
            if (signingKey != null)
            {
                Argument.AssertNotNull(signingCertificate, nameof(signingCertificate));
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationToken"/> class with an empty body.
        /// Used for the <see cref="AttestationAdministrativeClient.ResetPolicy(AttestationType, AttestationToken, System.Threading.CancellationToken)"/> API.
        /// </summary>
        /// <param name="signingKey"></param>
        /// <param name="signingCertificate"></param>
        public static AttestationToken CreateToken(System.Security.Cryptography.AsymmetricAlgorithm signingKey, X509Certificate2 signingCertificate)
        {
            Argument.AssertNotNull(signingKey, nameof(signingKey));
            Argument.AssertNotNull(signingCertificate, nameof(signingCertificate));
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate a JSON Web Token returned by the MAA.
        /// </summary>
        /// <param name="attestationSigningCertificates">Signing Certificates used to validate the token.</param>
        /// <param name="validationCallback">User provided callback which allows the customer to validate the token.</param>
        /// <returns></returns>
        public virtual bool ValidateToken(AttestationSigner[] attestationSigningCertificates, Func<string, bool> validationCallback = default)
        {
            Argument.AssertNotNull(attestationSigningCertificates, nameof(attestationSigningCertificates));
            if (validationCallback != null)
            {
                return validationCallback(_token);
            }
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        internal string GetJsonWebToken()
        {
            return string.Empty;
        }

    }
}
