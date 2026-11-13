// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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

        private AttestationToken(string token, ClientDiagnostics diagnostics)
        {
            _token = token;
            ConstructFromToken(_token);
            ClientDiagnostics = diagnostics;
        }
        private void ConstructFromToken(string token)
        {
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
        /// <param name="body">Body of the token to be generated, serialized as a byte array.</param>
        public AttestationToken(BinaryData body)
        {
            _token = CreateUnsecuredJwt(body);
            ConstructFromToken(_token);
        }

        /// <summary>
        /// Creates a new attestation token based on the supplied body signed with the specified signing key.
        /// </summary>
        /// <param name="body">The body of the generated token, serialized as a byte array.</param>
        /// <param name="signingKey"><see cref="AttestationTokenSigningKey"/> which will be used to sign the generated token.</param>
        public AttestationToken(BinaryData body, AttestationTokenSigningKey signingKey)
        {
            _token = signingKey != null ? GenerateSecuredJsonWebToken(body, signingKey) : CreateUnsecuredJwt(body);
            ConstructFromToken(_token);
        }

        /// <summary>
        /// Creates a new unsecured attestation token with an empty body. Used for the <see cref="AttestationAdministrationClient.ResetPolicy(AttestationType, AttestationTokenSigningKey, System.Threading.CancellationToken)"/> API.
        /// </summary>
        /// <param name="signingKey"><see cref="AttestationTokenSigningKey"/> which will be used to sign the generated token.</param>
        public AttestationToken(AttestationTokenSigningKey signingKey)
        {
            _token = signingKey != null ? GenerateSecuredJsonWebToken(null, signingKey) : CreateUnsecuredJwt(null);
        }

        internal ClientDiagnostics ClientDiagnostics { get; set; }

        /// <summary>
        /// Returns the thumbprint of the X.509 certificate which was used to verify the attestation token.
        ///
        /// Null until the <see cref="AttestationToken.ValidateToken(AttestationTokenValidationOptions, IReadOnlyList{AttestationSigner}, CancellationToken)"/> method has been called.
        /// </summary>
        public string CertificateThumbprint { get; private set; }

        /// <summary>
        /// Returns the X.509 certificate which was used to verify the attestation token.
        ///
        /// Null until the <see cref="AttestationToken.ValidateToken(AttestationTokenValidationOptions, IReadOnlyList{AttestationSigner}, CancellationToken)"/> method has been called.
        /// </summary>
        public AttestationSigner SigningCertificate { get; private set; }

        /// <summary>
        /// Decoded header for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public ReadOnlyMemory<byte> TokenHeaderBytes { get; private set; }

        /// <summary>
        /// Decoded body for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public ReadOnlyMemory<byte> TokenBodyBytes { get; private set; }

        /// <summary>
        /// Decoded signature for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public ReadOnlyMemory<byte> TokenSignatureBytes { get; private set; }

        // Standard JSON Web Signature/Json Web Token header values.

        /// <summary>
        /// Json Web Token Header "algorithm". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.1 for details.
        /// If the value of <see cref="Algorithm"/> is "none" it indicates that the token is unsecured.
        /// </summary>
        public string Algorithm => Header.Algorithm;

        /// <summary>
        /// Json Web Token Header "type". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.9 for details.
        ///
        /// If present, the value for this field is normally "JWT".
        /// </summary>
        public string Type => Header.Type;

        /// <summary>
        /// Json Web Token Header "content type". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.10 for details.
        /// </summary>
        public string ContentType => Header.ContentType;
        /// <summary>
        /// Json Web Token Header "Key URL". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.2 for details.
        /// </summary>
        public Uri KeyUrl => Header.JWKUri;
        /// <summary>
        /// Json Web Token Header "Key ID". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.4 for details.
        /// </summary>
        public string KeyId => Header.KeyId;

        /// <summary>
        /// Json Web Token Header "X509 URL". See https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.5 for details.
        /// </summary>
        public Uri X509Url => Header.X509Uri;

        /// <summary>
        /// Json Web Token Body Issuer. See https://www.rfc-editor.org/rfc/rfc7519.html#section-4.1.1 for details.
        /// </summary>
        public string Issuer => Payload.Issuer;

        /// <summary>
        /// An array of <see cref="X509Certificate"/> which represent a certificate chain used to sign the token.  <seealso href="https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.6">RFC 7515 section 4.1.6</seealso> for details.
        /// Empty if the token's header has no certificate chain.
        /// </summary>
        /// <remarks>
        /// The certificates are read from the token and are not validated; a token is never trusted because of the certificates it carries.
        /// </remarks>
        public X509Certificate2[] X509CertificateChain
        {
            get
            {
                string[] certificates = Header.X509CertificateChain;
                return certificates == null ? Array.Empty<X509Certificate2>() : ConvertBase64CertificateArrayToCertificateChain(certificates);
            }
        }

        /// <summary>
        /// The "thumbprint" of the certificate used to sign the request. <seealso href="https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.7">RFC 7515 section 4.1.7</seealso> for details.
        /// </summary>
        public string X509CertificateThumbprint => Header.X509CertificateThumbprint;

        /// <summary>
        /// The "thumbprint" of the certificate used to sign the request generated using the SHA256 algorithm. <seealso href="https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.8">RFC 7515 section 4.1.8</seealso> for details.
        /// </summary>
        public string X509CertificateSha256Thumbprint => Header.X509CertificateSha256Thumbprint;

        /// <summary>
        /// JSON Web Token Header "Critical". <seealso href="https://www.rfc-editor.org/rfc/rfc7515.html#section-4.1.11">RFC 7515 section 4.1.11</seealso> for details.
        /// </summary>
        public bool? Critical => Header.Critical;

        /// <summary>
        /// Returns the standard properties in the JSON Web Token header. <seealso href="https://tools.ietf.org/html/rfc7515">RFC 7515</seealso> for more details.
        /// </summary>
        internal JsonWebTokenHeader Header { get => JsonSerializer.Deserialize<JsonWebTokenHeader>(TokenHeaderBytes.ToArray()); }

        /// <summary>
        /// Returns the standard properties in the JSON Web Token header. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        private JsonWebTokenBody Payload { get => JsonSerializer.Deserialize<JsonWebTokenBody>(TokenBodyBytes.ToArray()); }

        /// <summary>
        /// Expiration time for the token.
        /// </summary>
        /// <remarks>A claim beyond the range of <see cref="DateTimeOffset"/> is returned as <see cref="DateTimeOffset.MinValue"/> or <see cref="DateTimeOffset.MaxValue"/>.</remarks>
        public DateTimeOffset? ExpirationTime
        {
            get
            {
                if (Payload.ExpirationTime.HasValue)
                {
                    return FromNumericDate(Payload.ExpirationTime.Value);
                }
                return null;
            }
        }

        /// <summary>
        /// Time before which this token is not valid.
        /// </summary>
        /// <remarks>A claim beyond the range of <see cref="DateTimeOffset"/> is returned as <see cref="DateTimeOffset.MinValue"/> or <see cref="DateTimeOffset.MaxValue"/>.</remarks>
        public DateTimeOffset? NotBeforeTime
        {
            get
            {
                if (Payload.NotBeforeTime.HasValue)
                {
                    return FromNumericDate(Payload.NotBeforeTime.Value);
                }
                return null;
            }
        }

        /// <summary>
        /// Time at which this token was issued.
        /// </summary>
        /// <remarks>A claim beyond the range of <see cref="DateTimeOffset"/> is returned as <see cref="DateTimeOffset.MinValue"/> or <see cref="DateTimeOffset.MaxValue"/>.</remarks>
        public DateTimeOffset? IssuedAtTime
        {
            get
            {
                if (Payload.IssuedAtTime.HasValue)
                {
                    return FromNumericDate(Payload.IssuedAtTime.Value);
                }
                return null;
            }
        }

        private static DateTimeOffset FromNumericDate(double secondsSinceEpoch)
        {
            try
            {
                return DateTimeOffset.FromUnixTimeSeconds(0).AddSeconds(secondsSinceEpoch);
            }
            catch (ArgumentOutOfRangeException)
            {
                return secondsSinceEpoch > 0 ? DateTimeOffset.MaxValue : DateTimeOffset.MinValue;
            }
        }

        /// <summary>
        /// Validate a JSON Web Token returned by the MAA.
        /// <para/>
        /// The token must have been signed by one of <paramref name="attestationSigningCertificates"/>. Certificates and keys carried in
        /// the token itself are never trusted to sign it.
        /// </summary>
        /// <param name="options">Options used while validating the attestation token.</param>
        /// <param name="attestationSigningCertificates">The signing certificates trusted to have signed the token, such as those returned by
        /// <see cref="AttestationClient.GetSigningCertificatesAsync(CancellationToken)"/> for the attestation provider the token must come from.</param>
        /// <param name="cancellationToken">Token used to cancel this operation if necessary.</param>
        /// <returns>true if the token was valid, false otherwise.</returns>
        /// <remarks>
        /// An unsecured token (one whose <see cref="Algorithm"/> is "none") carries no signature and never passes
        /// validation, regardless of any handler attached to <see cref="AttestationTokenValidationOptions.TokenValidated"/>. Neither does a token without an algorithm.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="options"/> or <paramref name="attestationSigningCertificates"/> is null, <paramref name="attestationSigningCertificates"/> contains null, or <see cref="AttestationTokenValidationOptions.ValidateIssuer"/> is true and <see cref="AttestationTokenValidationOptions.ExpectedIssuer"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="attestationSigningCertificates"/> is empty, or one of its signers has no signing certificate.</exception>
        /// <exception cref="Exception">Thrown if validation fails.</exception>
        public virtual async Task<bool> ValidateTokenAsync(AttestationTokenValidationOptions options, IReadOnlyList<AttestationSigner> attestationSigningCertificates, CancellationToken cancellationToken = default)
            => await ValidateTokenInternal(options, attestationSigningCertificates, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Validate a JSON Web Token returned by the MAA.
        /// <para/>
        /// The token must have been signed by one of <paramref name="attestationSigningCertificates"/>. Certificates and keys carried in
        /// the token itself are never trusted to sign it.
        /// </summary>
        /// <param name="options">Options used while validating the attestation token.</param>
        /// <param name="attestationSigningCertificates">The signing certificates trusted to have signed the token, such as those returned by
        /// <see cref="AttestationClient.GetSigningCertificates(CancellationToken)"/> for the attestation provider the token must come from.</param>
        /// <param name="cancellationToken">Token used to cancel this operation if necessary.</param>
        /// <returns>true if the token was valid, false otherwise.</returns>
        /// <remarks>
        /// An unsecured token (one whose <see cref="Algorithm"/> is "none") carries no signature and never passes
        /// validation, regardless of any handler attached to <see cref="AttestationTokenValidationOptions.TokenValidated"/>. Neither does a token without an algorithm.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="options"/> or <paramref name="attestationSigningCertificates"/> is null, <paramref name="attestationSigningCertificates"/> contains null, or <see cref="AttestationTokenValidationOptions.ValidateIssuer"/> is true and <see cref="AttestationTokenValidationOptions.ExpectedIssuer"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="attestationSigningCertificates"/> is empty, or one of its signers has no signing certificate.</exception>
        /// <exception cref="Exception">Thrown if validation fails.</exception>
        public virtual bool ValidateToken(AttestationTokenValidationOptions options, IReadOnlyList<AttestationSigner> attestationSigningCertificates, CancellationToken cancellationToken = default)
            => ValidateTokenInternal(options, attestationSigningCertificates, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Validate a JSON Web Token returned by the MAA.
        /// <para/>
        /// The token must have been signed by one of <paramref name="attestationSigningCertificates"/>.
        /// </summary>
        /// <param name="options">Options used while validating the attestation token.</param>
        /// <param name="attestationSigningCertificates">The signing certificates trusted to have signed the token.</param>
        /// <param name="async">If true, execute the function asynchronously.</param>
        /// <param name="cancellationToken">Token used to cancel this operation if necessary.</param>
        /// <param name="allowUnsecured">True only for the response to a draft-policy attestation, which the service never signs.</param>
        /// <returns>true if the token was valid, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="options"/> or <paramref name="attestationSigningCertificates"/> is null, <paramref name="attestationSigningCertificates"/> contains null, or <see cref="AttestationTokenValidationOptions.ValidateIssuer"/> is true and <see cref="AttestationTokenValidationOptions.ExpectedIssuer"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="attestationSigningCertificates"/> is empty, or one of its signers has no signing certificate.</exception>
        /// <exception cref="Exception">Thrown if validation fails.</exception>
        internal async Task<bool> ValidateTokenInternal(AttestationTokenValidationOptions options, IReadOnlyList<AttestationSigner> attestationSigningCertificates, bool async, CancellationToken cancellationToken = default, bool allowUnsecured = false)
        {
            Argument.AssertNotNull(options, nameof(options));

            // Early out if the caller doesn't want us to validate the token.
            if (!options.ValidateToken)
            {
                return true;
            }

            // Check the caller's options before the token, so a misconfiguration is reported the same way whatever the token.
            AssertIssuerOptions(options);

            // Without an algorithm there is no way to verify the token's signature.
            string algorithm = Header.Algorithm;
            if (algorithm == null)
            {
                return false;
            }

            // An unsecured token carries no signature, so it cannot be trusted (RFC 8725 section 3.1). The one exception
            // is the response to a draft-policy attestation the caller asked for, which the service never signs.
            if (algorithm.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                if (!allowUnsecured || !ValidateCommonProperties(options))
                {
                    return false;
                }
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                return await CallValidationCallbackAsync(options, this, SigningCertificate, ClientDiagnostics, !async, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            }

            // This token is a secured attestation token, so it must have been signed by a signer the caller trusts.
            // A token can't vouch for itself with signing certificates carried in its own header.
            Argument.AssertNotNullOrEmpty(attestationSigningCertificates, nameof(attestationSigningCertificates));
            foreach (AttestationSigner signer in attestationSigningCertificates)
            {
                Argument.AssertNotNull(signer, nameof(attestationSigningCertificates));
                if (signer.SigningCertificates == null || signer.SigningCertificates.Count == 0 || signer.SigningCertificates[0] == null)
                {
                    throw new ArgumentException("Each signer must have a signing certificate.", nameof(attestationSigningCertificates));
                }
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

#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            return await CallValidationCallbackAsync(options, this, SigningCertificate, ClientDiagnostics, !async, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
        }

        private static async Task<bool> CallValidationCallbackAsync(AttestationTokenValidationOptions options, AttestationToken token, AttestationSigner signer, ClientDiagnostics diagnostics, bool isRunningSynchronously, CancellationToken cancellationToken)
        {
            return await options.RaiseValidationCallbackAsync(token, signer, diagnostics, isRunningSynchronously, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the signers, from the trusted set, which might have signed the token.
        /// </summary>
        /// <param name="attestationSigners">The trusted signers; the token's own header is never a source of signers.</param>
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
                // Only the trusted signer with the token's key ID can have signed it.
                foreach (var signer in attestationSigners)
                {
                    if (signer.CertificateKeyId == desiredKeyId)
                    {
                        candidateCertificates.Add(new AttestationSigner(signer.SigningCertificates.ToArray(), desiredKeyId));
                        break;
                    }
                }
            }
            else
            {
                // Without a key ID, any trusted signer might have signed the token.
                //
                // Note: because we don't have a KeyID, we neuter the KeyID in the AttestationSigner.
                foreach (var signer in attestationSigners)
                {
                    candidateCertificates.Add(new AttestationSigner(signer.SigningCertificates.ToArray(), null));
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
#if NET9_0_OR_GREATER
                jwkCertificates[i] = X509CertificateLoader.LoadCertificate(Convert.FromBase64String(base64Cert));
#else
                jwkCertificates[i] = new X509Certificate2(Convert.FromBase64String(base64Cert));
#endif
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
            byte[] signedData = Encoding.UTF8.GetBytes(Base64Url.Encode(this.TokenHeaderBytes.ToArray()) + "." + Base64Url.Encode(this.TokenBodyBytes.ToArray()));
            byte[] signature = this.TokenSignatureBytes.ToArray();
            AttestationSigner actualSigner = null;

            foreach (var signer in possibleSigners)
            {
                // The leaf certificate is defined as the certificate which signed the token, so we just need to look
                // at the first certificate in the chain.
                if (VerifySignature(signer.SigningCertificates[0], signedData, signature))
                {
                    actualSigner = signer;
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

        // Only RSA certificates can verify a token; the service signs tokens with RS256. Other certificates are skipped.
        private static bool VerifySignature(X509Certificate2 certificate, byte[] signedData, byte[] signature)
        {
            using RSA rsa = certificate.GetRSAPublicKey();
            return rsa != null && rsa.VerifyData(signedData, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        private static void AssertIssuerOptions(AttestationTokenValidationOptions options)
        {
            if (options.ValidateIssuer && options.ExpectedIssuer == null)
            {
                throw new ArgumentNullException(
                    $"{nameof(options)}.{nameof(options.ExpectedIssuer)}",
                    "Issuer validation requires ExpectedIssuer to be set to the base URI of the attestation provider the token must come from. To skip issuer validation, set ValidateIssuer to false.");
            }
        }

        /// <summary>
        /// Validate the common properties of the attestation token - ensure that the expiration time for the token is "reasonable", if present.
        /// </summary>
        /// <returns>true if the common properties are valid.</returns>
        /// <exception cref="Exception">Thrown if the attestation token is not value.</exception>
        private bool ValidateCommonProperties(AttestationTokenValidationOptions options)
        {
            DateTimeOffset timeNow = DateTimeOffset.Now;
            if (Payload.ExpirationTime.HasValue && (options?.ValidateExpirationTime ?? true))
            {
                if (timeNow.CompareTo(ExpirationTime.Value) > 0)
                {
                    if (options?.TimeValidationSlack != 0)
                    {
                        var delta = timeNow.Subtract(ExpirationTime.Value);
                        if (delta.TotalSeconds > options?.TimeValidationSlack)
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

            if (Payload.NotBeforeTime.HasValue && (options?.ValidateNotBeforeTime ?? true))
            {
                if (DateTimeOffset.Now.CompareTo(NotBeforeTime.Value) < 0)
                {
                    if (options?.TimeValidationSlack != 0)
                    {
                        var delta = timeNow.Subtract(NotBeforeTime.Value);
                        if (Math.Abs(delta.TotalSeconds) > options?.TimeValidationSlack)
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

            string issuer = Payload.Issuer;
            if (options.ValidateIssuer && !IsExpectedIssuer(options.ExpectedIssuer, issuer))
            {
                throw new Exception($"Unknown Issuer for attestation token. Expected {options.ExpectedIssuer}, found {issuer ?? "no issuer"}");
            }
            return true;
        }

        // Issuers are provider base URIs, whose scheme and host are case-insensitive.
        private static bool IsExpectedIssuer(string expectedIssuer, string issuer)
            => issuer != null && string.Equals(expectedIssuer.TrimEnd('/'), issuer.TrimEnd('/'), StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Retrieves the body of the AttestationToken as the specified type.
        /// </summary>
        /// <typeparam name="T">Underlying type for the token body.</typeparam>
        /// <returns>Returns the body of the attestation token, or null if the token has an empty body.</returns>
        /// <remarks>
        /// The attestation service uses a token with an empty body to represent the absence of a value, for
        /// instance when an attestation type has no policy configured. Such a token has nothing to deserialize,
        /// so null is returned rather than surfacing a deserialization failure to the caller.
        /// </remarks>
        public virtual T GetBody<T>()
            where T : class
        {
            lock (_statelock)
            {
                if (TokenBodyBytes.Length == 0)
                {
                    return null;
                }

                if (_deserializedBody == null || _deserializedBody.GetType() != typeof(T))
                {
                    _deserializedBody = JsonSerializer.Deserialize<T>(TokenBodyBytes.ToArray(), _serializerOptions);
                }
                return (T)_deserializedBody;
            }
        }

        /// <summary>
        /// Serializes the attestation token to a JSON Web Token
        /// </summary>
        /// <returns>The value of the AttestationToken as a JSON Web Token.</returns>
        public string Serialize()
        {
            return _token ?? GetType().Name;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AttestationToken"/> class based on a specified JSON Web Token.
        /// </summary>
        /// <param name="token">string JWT to Deserialize.</param>
        public static AttestationToken Deserialize(string token)
        {
            return new AttestationToken(token, null);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AttestationToken"/> class based on a specified JSON Web Token.
        /// </summary>
        /// <param name="token">string JWT to Deserialize.</param>
        /// <param name="diagnostics">Client Diagnostics object, used when raising Validation events.</param>
        internal static AttestationToken Deserialize(string token, ClientDiagnostics diagnostics)
        {
            return new AttestationToken(token, diagnostics);
        }

        /// <summary>
        /// Create an unsecured JSON Web Token based on the specified token body.
        /// </summary>
        /// <param name="body">Object to be embeeded as the body of the attestation token.</param>
        /// <returns>Returns an secured JWT whose body is the serialized value of the <paramref name="body"/> parameter.</returns>
        private static string CreateUnsecuredJwt(BinaryData body)
        {
            if (body != null)
            {
                JsonDocument parsedBody = JsonDocument.Parse(body);
                if (parsedBody.RootElement.ValueKind != JsonValueKind.Object)
                {
                    throw new ArgumentException("AttestationToken body must be a serialized JSON Object.");
                }
            }
            // Base64Url encoded '{"alg":"none"}'. See https://www.rfc-editor.org/rfc/rfc7515.html#appendix-A.5 for more information.
            string returnValue = "eyJhbGciOiJub25lIn0.";

            string encodedDocument;
            if (body != null)
            {
                encodedDocument = Base64Url.Encode(body.ToArray());
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
        private static string GenerateSecuredJsonWebToken(BinaryData body, AttestationTokenSigningKey signingKey)
        {
            if (body != null)
            {
                JsonDocument parsedBody = JsonDocument.Parse(body);
                if (parsedBody.RootElement.ValueKind != JsonValueKind.Object)
                {
                    throw new ArgumentException("AttestationToken body must be a serialized JSON Object.");
                }
            }

            Argument.AssertNotNull(signingKey, nameof(signingKey));

            JsonWebTokenHeader header = new JsonWebTokenHeader
            {
                // AttestationTokenSigningKey only accepts RSA keys.
                Algorithm = "RS256",
                X509CertificateChain = new string[] { Convert.ToBase64String(signingKey.Certificate.Export(X509ContentType.Cert)) },
            };
            var serializationOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            byte[] jwtHeader = JsonSerializer.SerializeToUtf8Bytes<JsonWebTokenHeader>(header, serializationOptions);
            string encodedHeader = Base64Url.Encode(jwtHeader);

            byte[] jwtBody = null;
            if (body != null)
            {
                jwtBody = body.ToArray();
            }

            string encodedBody = jwtBody != null ? Base64Url.Encode(jwtBody) : string.Empty;

            string signedData = encodedHeader + '.' + encodedBody;

            if (!(signingKey.Signer is RSA rsaKey))
            {
                throw new ArgumentException("The signing key must be an RSA key.", nameof(signingKey));
            }
            byte[] signature = rsaKey.SignData(Encoding.UTF8.GetBytes(signedData), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            string jwt = signedData + '.' + Base64Url.Encode(signature);

            return jwt;
        }
    }
}
