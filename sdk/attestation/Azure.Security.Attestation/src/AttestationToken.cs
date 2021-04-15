// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.ComponentModel;
using Azure.Core.Pipeline;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents an Attestation Token object.
    /// </summary>
    public class AttestationToken
    {
        protected private string _token;
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions();

        private object _deserializedBody;
        private object _statelock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationToken"/> class based on a specified JSON Web Token.
        /// </summary>
        /// <param name="token">string JWT to initialize.</param>
        /// <remarks>
        /// For test purposes, it may be useful to instantiate an AttestationToken object whose payload is a developer
        /// created JSON Web Token. To use this constructor, create a version of the class derived from the <see cref="AttestationToken"/> class and invoke
        /// the constructor through this derived class:
        /// <code snippet="Snippet:CreateTestTokenForMocking">
        /// private class TestAttestationToken : AttestationToken
        /// {
        ///     public TestAttestationToken(string token) : base(token)
        ///     {
        ///     }
        /// }
        /// </code>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal protected AttestationToken(string token)
        {
            _token = token;
            string[] decomposedToken = token.Split('.');
            if (decomposedToken.Length != 3)
            {
                throw new ArgumentException("JSON Web Tokens must have 3 components delimited by '.' characters.");
            }
            TokenHeaderBytes = Base64Url.Decode(decomposedToken[0]);
            TokenBodyBytes = Base64Url.Decode(decomposedToken[1]);
            TokenSignatureBytes = Base64Url.Decode(decomposedToken[2]);
        }

        /// <summary>
        /// Creates a new attestation token, used for mocking.
        /// </summary>
        protected AttestationToken()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationToken"/> class as an unsecured JSON Web Token, with <paramref name="body"/> as the body of the token.
        /// </summary>
        /// <param name="body">Object to be used as the body of the newly created attestation token.</param>
        public AttestationToken(object body)
        {
            _token = CreateUnsecuredJwt(body);
        }

        /// <summary>
        /// Creates a new attestation token based on the supplied body signed with the specified signing key.
        /// </summary>
        /// <param name="body">The body of the generated token.</param>
        /// <param name="signingKey"><see cref="TokenSigningKey"/> which will be used to sign the generated token.</param>
        public AttestationToken(object body, TokenSigningKey signingKey)
        {
            _token = signingKey != null ? GenerateSecuredJsonWebToken(body, signingKey) : CreateUnsecuredJwt(body);
        }

        /// <summary>
        /// Creates a new unsecured attestation token with an empty body. Used for the <see cref="AttestationAdministrationClient.ResetPolicy(AttestationType, TokenSigningKey, System.Threading.CancellationToken)"/> API.
        /// </summary>
        /// <param name="signingKey"><see cref="TokenSigningKey"/> which will be used to sign the generated token.</param>
        public AttestationToken(TokenSigningKey signingKey)
        {
            _token = signingKey != null ? GenerateSecuredJsonWebToken(null, signingKey) : CreateUnsecuredJwt(null);
        }

        /// <summary>
        /// Returns the thumbprint of the X.509 certificate which was used to verify the attestation token.
        ///
        /// Null until the <see cref="AttestationToken.ValidateToken(TokenValidationOptions, IReadOnlyList{AttestationSigner}, CancellationToken)"/> method has been called.
        /// </summary>
        public virtual string CertificateThumbprint { get; private set; }

        /// <summary>
        /// Returns the X.509 certificate which was used to verify the attestation token.
        ///
        /// Null until the <see cref="AttestationToken.ValidateToken(TokenValidationOptions, IReadOnlyList{AttestationSigner}, CancellationToken)"/> method has been called.
        /// </summary>
        public virtual AttestationSigner SigningCertificate { get; private set; }

        /// <summary>
        /// Decoded header for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public virtual ReadOnlyMemory<byte> TokenHeaderBytes { get; }

        /// <summary>
        /// Decoded body for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public virtual ReadOnlyMemory<byte> TokenBodyBytes { get; }

        /// <summary>
        /// Decoded signature for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public virtual ReadOnlyMemory<byte> TokenSignatureBytes { get; }

        // Standard JSON Web Signature/Json Web Token header values.

        /// <summary>
        /// Json Web Token Header "algorithm". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.1 for details.
        /// If the value of <see cref="Algorithm"/> is "none" it indicates that the token is unsecured.
        /// </summary>
        public virtual string Algorithm { get => Header.Algorithm; }

        /// <summary>
        /// Json Web Token Header "type". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.9 for details.
        ///
        /// If present, the value for this field is normally "JWT".
        /// </summary>
        public virtual string Type { get => Header.Type; }

        /// <summary>
        /// Json Web Token Header "content type". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.10 for details.
        /// </summary>
        public virtual string ContentType { get => Header.ContentType; }
        /// <summary>
        /// Json Web Token Header "Key URL". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.2 for details.
        /// </summary>
        public virtual Uri KeyUrl { get => Header.JWKUri; }
        /// <summary>
        /// Json Web Token Header "Key ID". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.4 for details.
        /// </summary>
        public virtual string KeyId { get => Header.KeyId; }

        /// <summary>
        /// Json Web Token Header "X509 URL". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.5 for details.
        /// </summary>
        public virtual Uri X509Url { get => Header.X509Uri; }

        /// <summary>
        /// Json Web Token Body Issuer. See https://www.rfc-editor.org/rfc/rfc7519.html#section-4.1.1 for details.
        /// </summary>
        public virtual string Issuer { get => Payload.Issuer; }

        /// <summary>
        /// An array of X.509Certificates which represent a certificate chain used to sign the token. See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.6 for details.
        /// </summary>
        public virtual X509Certificate2[] X509CertificateChain {
            get
            {
                List<X509Certificate2> certificates = new List<X509Certificate2>();
                foreach (var certificate in Header.X509CertificateChain)
                {
                    certificates.Add(new X509Certificate2(certificate));
                }
                return certificates.ToArray();
            }
        }

        /// <summary>
        /// The "thumbprint" of the certificate used to sign the request. See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.7 for details.
        /// </summary>
        public virtual string X509CertificateThumbprint { get => Header.X509CertificateThumbprint; }

        /// <summary>
        /// The "thumbprint" of the certificate used to sign the request generated using the SHA256 algorithm. See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.8 for details.
        /// </summary>
        public virtual string X509CertificateSha256Thumbprint { get => Header.X509CertificateSha256Thumbprint; }

        /// <summary>
        /// Json Web Token Header "Critical". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.11 for details.
        /// </summary>
        public virtual bool? Critical { get => Header.Critical; }

        /// <summary>
        /// Returns the standard properties in the JSON Web Token header. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        internal JsonWebTokenHeader Header { get => JsonSerializer.Deserialize<JsonWebTokenHeader>(TokenHeaderBytes.ToArray()); }

        /// <summary>
        /// Returns the standard properties in the JSON Web Token header. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        private JsonWebTokenBody Payload { get => JsonSerializer.Deserialize<JsonWebTokenBody>(TokenBodyBytes.ToArray()); }

        /// <summary>
        /// Expiration time for the token.
        /// </summary>
        public virtual DateTimeOffset? ExpirationTime
        {
            get
            {
                if (Payload.ExpirationTime.HasValue)
                {
                    return DateTimeOffset.FromUnixTimeSeconds((long)Payload.ExpirationTime.Value);
                }
                return null;
            }
        }

        /// <summary>
        /// Time before which this token is not valid.
        /// </summary>
        public virtual DateTimeOffset? NotBeforeTime
        {
            get
            {
                if (Payload.NotBeforeTime.HasValue)
                {
                    return DateTimeOffset.FromUnixTimeSeconds((long)Payload.NotBeforeTime.Value);
                }
                return null;
            }
        }

        /// <summary>
        /// Time at which this token was issued.
        /// </summary>
        public virtual DateTimeOffset? IssuedAtTime
        {
            get
            {
                if (Payload.IssuedAtTime.HasValue)
                {
                    return DateTimeOffset.FromUnixTimeSeconds((long)Payload.IssuedAtTime.Value);
                }
                return null;
            }
        }

        /// <summary>
        /// Represents the body of the token encoded as a string.
        /// </summary>
        public virtual string TokenBody  { get => Encoding.UTF8.GetString(TokenBodyBytes.ToArray()); }

        /// <summary>
        /// Represents the body of the token encoded as a string.
        /// </summary>
        public virtual string TokenHeader { get => Encoding.UTF8.GetString(TokenHeaderBytes.ToArray()); }

        /// <summary>
        /// Validate a JSON Web Token returned by the MAA.
        /// <para/>
        /// If the caller provides a set of signers, than that set of signers will be used as the complete set of candidates for signing.
        /// If the caller does not provide a set of signers, then the <see cref="ValidateTokenAsync(TokenValidationOptions, IReadOnlyList{AttestationSigner}, CancellationToken)"/>
        /// API will a set of callers derived from the contents of the attestation token.
        /// </summary>
        /// <param name="options">Options used while validating the attestation token.</param>
        /// <param name="attestationSigningCertificates">Signing Certificates used to validate the token.</param>
        /// <param name="cancellationToken">Token used to cancel this operation if necessary.</param>
        /// <returns>true if the token was valid, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the signing certificates provided are invalid.</exception>
        /// <exception cref="Exception">Thrown if validation fails.</exception>
        public virtual async Task<bool> ValidateTokenAsync(TokenValidationOptions options, IReadOnlyList<AttestationSigner> attestationSigningCertificates, CancellationToken cancellationToken = default)
            => await ValidateTokenInternalAsync(options, attestationSigningCertificates, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Validate a JSON Web Token returned by the MAA.
        /// <para/>
        /// If the caller provides a set of signers, than that set of signers will be used as the complete set of candidates for signing.
        /// If the caller does not provide a set of signers, then the <see cref="ValidateToken(TokenValidationOptions, IReadOnlyList{AttestationSigner}, CancellationToken)"/>
        /// API will a set of callers derived from the contents of the attestation token.
        /// </summary>
        /// <param name="options">Options used while validating the attestation token.</param>
        /// <param name="attestationSigningCertificates">Signing Certificates used to validate the token.</param>
        /// <param name="cancellationToken">Token used to cancel this operation if necessary.</param>
        /// <returns>true if the token was valid, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the signing certificates provided are invalid.</exception>
        /// <exception cref="Exception">Thrown if validation fails.</exception>
        public virtual bool ValidateToken(TokenValidationOptions options, IReadOnlyList<AttestationSigner> attestationSigningCertificates, CancellationToken cancellationToken = default)
            => ValidateTokenInternalAsync(options, attestationSigningCertificates, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Validate a JSON Web Token returned by the MAA.
        /// <para/>
        /// If the caller provides a set of signers, than that set of signers will be used as the complete set of candidates for signing.
        /// If the caller does not provide a set of signers, then the <see cref="ValidateTokenAsync(TokenValidationOptions, IReadOnlyList{AttestationSigner}, CancellationToken)"/>
        /// API will a set of callers derived from the contents of the attestation token.
        /// </summary>
        /// <param name="options">Options used while validating the attestation token.</param>
        /// <param name="attestationSigningCertificates">Signing Certificates used to validate the token.</param>
        /// <param name="async">If true, execute the function asynchronously.</param>
        /// <param name="cancellationToken">Token used to cancel this operation if necessary.</param>
        /// <returns>true if the token was valid, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the signing certificates provided are invalid.</exception>
        /// <exception cref="Exception">Thrown if validation fails.</exception>
        internal async Task<bool> ValidateTokenInternalAsync(TokenValidationOptions options, IReadOnlyList<AttestationSigner> attestationSigningCertificates, bool async, CancellationToken cancellationToken = default)
        {
            // Early out if the caller doesn't want us to validate the token.
            if (!options.ValidateToken)
            {
                return true;
            }

            // Before we waste a lot of time, see if the token is unsecured. If it is, then validation is simple.
            if (Header.Algorithm.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                if (!ValidateCommonProperties(options))
                {
                    return false;
                }
                if (options.ValidationCallback != null)
                {
                    return options.ValidationCallback(this, null);
                }
                return true;
            }

            // This token is a secured attestation token. If the caller provided signing certificates, then
            // they need to have provided at least one certificate.
            if (attestationSigningCertificates != null)
            {
                Argument.AssertNotNull(attestationSigningCertificates[0], nameof(attestationSigningCertificates));
            }

            AttestationSigner[] possibleCertificates = await GetCandidateSigningCertificatesInternalAsync(attestationSigningCertificates, async, cancellationToken).ConfigureAwait(false);
            if (possibleCertificates.Length == 0)
            {
                throw new Exception($"Unable to find any certificates which can be used to validate the token.");
            }

            if (!ValidateTokenSignature(possibleCertificates))
            {
                throw new Exception($"Could not find a certificate which was used to sign the token.");
            }

            if (!ValidateCommonProperties(options))
            {
                return false;
            }
            if (options.ValidationCallback != null)
            {
                return options.ValidationCallback(this, SigningCertificate);
            }
            return true;
        }

        /// <summary>
        /// Returns a set of candidate signing certificates based on the contents of the token.
        /// </summary>
        /// <param name="attestationSigners">The desired set of signers for this token - if present, then this is the exclusive set of signers for the token.</param>
        /// <param name="async">true if this operation is asynchronous.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>The set of <see cref="AttestationSigner"/> which might be used to sign the attestation token.</returns>
        private async Task<AttestationSigner[]> GetCandidateSigningCertificatesInternalAsync(IReadOnlyList<AttestationSigner> attestationSigners, bool async, CancellationToken cancellationToken = default)
        {
            string desiredKeyId = Header.KeyId;

            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            // Reference the async parameter. If/when JKU/X5U support is added, remove this.
            if (async)
            {
                await Task.Yield();
            }

            List<AttestationSigner> candidateCertificates = new List<AttestationSigner>();
            if (desiredKeyId != null)
            {
                // We start looking for candidate signers by looking in the provided attestation signers.
                // The list of attestation signers trumps
                foreach (var signer in attestationSigners)
                {
                    if (signer.CertificateKeyId == desiredKeyId)
                    {
                        candidateCertificates.Add(new AttestationSigner(signer.SigningCertificates.ToArray(), desiredKeyId));
                        break;
                    }
                }

                // We didn't find a certificate from the attestation signers. That means we need to look in the
                // Header to see if we can find one there.
                if (candidateCertificates.Count == 0)
                {
                    if (Header.JsonWebKey != null)
                    {
                        // If the key matches the header's JWK, then the signer is going to be the leaf certificate
                        // of the certificates in the chain.
                        if (desiredKeyId == Header.JsonWebKey.Kid)
                        {
                            candidateCertificates.Add(new AttestationSigner(
                                ConvertBase64CertificateArrayToCertificateChain(Header.JsonWebKey.X5C),
                                desiredKeyId));
                        }
                    }
                }
            }
            else
            {
                // We don't have a desired Key ID, so we need to try all the possible signing certificates :(.

                // Start with the attestationSigners provided by the caller. Remember that attestation signers
                // trump all signers in the header.
                if (attestationSigners != null)
                {
                    // Copy the signers to the candidate certificates.
                    //
                    // Note: because we don't have a KeyID, we neuter the KeyID in the AttestationSigner.
                    foreach (var signer in attestationSigners)
                    {
                        candidateCertificates.Add(new AttestationSigner(signer.SigningCertificates.ToArray(), null));
                    }
                }
                else
                {
                    if (Header.X509CertificateChain != null)
                    {
                        candidateCertificates.Add(new AttestationSigner(ConvertBase64CertificateArrayToCertificateChain(Header.X509CertificateChain), null));
                    }
                    if (Header.JsonWebKey != null)
                    {
                        candidateCertificates.Add(new AttestationSigner(ConvertBase64CertificateArrayToCertificateChain(Header.JsonWebKey.X5C), null));
                    }
                }
            }

            return candidateCertificates.ToArray();
        }

        private static X509Certificate2[] ConvertBase64CertificateArrayToCertificateChain(IList<string> base64certificates)
        {
            X509Certificate2[] jwkCertificates = new X509Certificate2[base64certificates.Count];
            int i = 0;
            foreach (var base64Cert in base64certificates)
            {
                jwkCertificates[i] = new X509Certificate2(Convert.FromBase64String(base64Cert));
                i += 1;
            }
            return jwkCertificates;
        }

        /// <summary>
        /// Iterate over the set of possible signers looking for a signer which can validate the signature
        /// </summary>
        /// <param name="possibleSigners">A set of attestation signers which might have been used to sign the token.</param>
        /// <returns>true if one of the possibleSigners signed the token, false otherwise</returns>
        private bool ValidateTokenSignature(AttestationSigner[] possibleSigners)
        {
            bool signatureValidated = false;
            AttestationSigner actualSigner = null;

            foreach (var signer in possibleSigners)
            {
                // The leaf certificate is defined as the certificate which signed the token, so we just need to look
                // at the first certificate in the chain.
                AsymmetricAlgorithm asymmetricAlgorithm = signer.SigningCertificates[0].PublicKey.Key;
                if (asymmetricAlgorithm is RSA rsaKey)
                {
                    signatureValidated = rsaKey.VerifyData(
                        Encoding.UTF8.GetBytes(Base64Url.Encode(this.TokenHeaderBytes.ToArray()) + "." + Base64Url.Encode(this.TokenBodyBytes.ToArray())),
                        this.TokenSignatureBytes.ToArray(),
                        HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    if (signatureValidated)
                    {
                        actualSigner = signer;
                    }
                    break;
                }
                else if (asymmetricAlgorithm is ECDsa ecdsa)
                {
                    signatureValidated = ecdsa.VerifyData(
                        Encoding.UTF8.GetBytes(Base64Url.Encode(this.TokenHeaderBytes.ToArray()) + "." + Base64Url.Encode(this.TokenBodyBytes.ToArray())),
                        this.TokenSignatureBytes.ToArray(),
                        HashAlgorithmName.SHA256);
                    if (signatureValidated)
                    {
                        actualSigner = signer;
                    }
                    break;
                }
            }

            if (actualSigner != null)
            {
                this.CertificateThumbprint = actualSigner.SigningCertificates[0].Thumbprint;
                this.SigningCertificate = actualSigner;
            }
            return actualSigner != null;
        }

        /// <summary>
        /// Validate the common properties of the attestation token - ensure that the expiration time for the token is "reasonable", if present.
        /// </summary>
        /// <returns>true if the common properties are valid.</returns>
        /// <exception cref="Exception">Thrown if the attestation token is not value.</exception>
        private bool ValidateCommonProperties(TokenValidationOptions options)
        {
            if ((options?.ValidateIssuer).GetValueOrDefault())
            {
                Argument.AssertNotNull(options?.ExpectedIssuer, nameof(options.ExpectedIssuer));
            }
            DateTimeOffset timeNow = DateTimeOffset.Now;
            if (Payload.ExpirationTime.HasValue && (options?.ValidateExpirationTime ?? true))
            {
                if (timeNow.CompareTo(ExpirationTime.Value) > 0)
                {
                    if (options?.TimeValidationSlack != 0)
                    {
                        var delta = timeNow.Subtract(ExpirationTime.Value);
                        if (delta.Seconds > options?.TimeValidationSlack)
                        {
                            throw new Exception("Attestation token expired before the slack time provided.");
                        }
                    }
                    else
                    {
                        throw new Exception("Attestation token expired.");
                    }
                }
            }

            if (Payload.NotBeforeTime.HasValue && (options?.ValidateNotBeforeTime?? true))
            {
                if (DateTimeOffset.Now.CompareTo(NotBeforeTime.Value) < 0)
                {
                    if (options?.TimeValidationSlack != 0)
                    {
                        var delta = timeNow.Subtract(NotBeforeTime.Value);
                        if (Math.Abs(delta.Seconds) > options?.TimeValidationSlack)
                        {
                            throw new Exception("Attestation token will not become valid before the slack time provided.");
                        }
                    }
                    else
                    {
                        throw new Exception("Attestation token is not yet valid.");
                    }
                }
            }

            if (Payload.Issuer != null && (options?.ValidateIssuer ?? true) && options?.ExpectedIssuer != null)
            {
                if (options?.ExpectedIssuer != Payload.Issuer)
                {
                    throw new Exception($"Unknown Issuer for attestation token. Expected {options.ExpectedIssuer}, found {Payload.Issuer}");
                }
            }
            return true;
        }

        /// <summary>
        /// Retrieves the body of the AttestationToken as the specified type.
        /// </summary>
        /// <typeparam name="T">Underlying type for the token body.</typeparam>
        /// <returns>Returns the body of the attestation token.</returns>
        public virtual T GetBody<T>()
            where T: class
        {
            lock (_statelock)
            {
                if (_deserializedBody == null || _deserializedBody.GetType() != typeof(T))
                {
                    _deserializedBody = JsonSerializer.Deserialize<T>(TokenBodyBytes.ToArray(), _serializerOptions);
                }
                return (T)_deserializedBody;
            }
        }

        /// <summary>
        /// Returns the attestation token composed as JSON Web Token
        /// </summary>
        /// <returns>The value of the AttestationToken as a JSON Web Token.</returns>
        public override string ToString()
        {
            return _token ?? GetType().Name;
        }

        /// <summary>
        /// Create an unsecured JSON Web Token based on the specified token body.
        /// </summary>
        /// <param name="body">Object to be embeeded as the body of the attestation token.</param>
        /// <returns>Returns an secured JWT whose body is the serialized value of the <paramref name="body"/> parameter.</returns>
        private static string CreateUnsecuredJwt(object body)
        {
            // Base64Url encoded '{"alg":"none"}'. See https://www.rfc-editor.org/rfc/rfc7515.html#appendix-A.5 for more information.
            string returnValue = "eyJhbGciOiJub25lIn0.";

            string encodedDocument;
            if (body != null)
            {
                string bodyString = JsonSerializer.Serialize(body);
                encodedDocument = Base64Url.EncodeString(bodyString);
            }
            else
            {
                encodedDocument = string.Empty;
            }

            returnValue += encodedDocument;
            returnValue += ".";

            return returnValue;
        }

        /// <summary>
        /// Create a secured JSON Web Token based on the specified token body and the specified signing key.
        /// </summary>
        /// <param name="body">Object to be embeeded as the body of the attestation token.</param>
        /// <param name="signingKey">Key used to sign the attestation token.</param>
        /// <returns>Returns a secured JWT whose body is the serialized value of the <paramref name="body"/> parameter.</returns>
        private static string GenerateSecuredJsonWebToken(object body, TokenSigningKey signingKey)
        {
            Argument.AssertNotNull(signingKey, nameof(signingKey));

            AsymmetricAlgorithm signer;
            if (signingKey.Certificate.HasPrivateKey)
            {
                signer = signingKey.Certificate.PrivateKey;
            }
            else
            {
                signer = signingKey.Signer;
            }

            JsonWebTokenHeader header = new JsonWebTokenHeader
            {
                Algorithm = signingKey.Signer is RSA ? "RSA256" : (signingKey.Signer is ECDsa ? "ECDH256" : null),
                X509CertificateChain = new string[] { Convert.ToBase64String(signingKey.Certificate.Export(X509ContentType.Cert)) },
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
            if (signingKey.Signer is RSA rsaKey)
            {
                signature = rsaKey.SignData(Encoding.UTF8.GetBytes(signedData), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
            else if (signingKey.Signer is ECDsa ecdh)
            {
                signature = ecdh.SignData(Encoding.UTF8.GetBytes(signedData), HashAlgorithmName.SHA256);
            }
            else
            {
                throw new ArgumentException("Signing Key must be either RSA or ECDsa. Unknown signing key found");
            }
            string jwt = signedData + '.' + Base64Url.Encode(signature);

            return jwt;
        }
    }
}
