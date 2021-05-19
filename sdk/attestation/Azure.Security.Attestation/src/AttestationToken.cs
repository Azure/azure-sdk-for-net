// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Security.Attestation.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents an Attestation Token object.
    /// </summary>
    public class AttestationToken
    {
        protected private string _token;
        private JsonSerializerOptions _options = new JsonSerializerOptions();

        private object _deserializedBody;
        private object _statelock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationToken"/> class.
        /// </summary>
        /// <param name="token">string JWT to initialize.</param>
        internal AttestationToken(string token)
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

            _options.Converters.Add(new PolicyResultConverter());
            _options.Converters.Add(new AttestationResultConverter());
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
        /// Null until the <see cref="AttestationToken.ValidateToken(IReadOnlyList{AttestationSigner}, Func{AttestationToken, AttestationSigner, bool})"/> method has been called.
        /// </summary>
        public string CertificateThumbprint { get; }

        /// <summary>
        /// Decoded header for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public ReadOnlyMemory<byte> TokenHeaderBytes { get; }

        /// <summary>
        /// Decoded body for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public ReadOnlyMemory<byte> TokenBodyBytes { get; }

        /// <summary>
        /// Decoded signature for the attestation token. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        public ReadOnlyMemory<byte> TokenSignatureBytes { get; }

        /// <summary>
        /// Returns the standard properties in the JSON Web Token header. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        private JsonWebTokenHeader Header { get => JsonSerializer.Deserialize<JsonWebTokenHeader>(TokenHeaderBytes.ToArray()); }

        /// <summary>
        /// Returns the standard properties in the JSON Web Token header. See https://tools.ietf.org/html/rfc7515 for more details.
        /// </summary>
        private JsonWebTokenBody Payload { get => JsonSerializer.Deserialize<JsonWebTokenBody>(TokenBodyBytes.ToArray()); }

        /// <summary>
        /// Expiration time for the token.
        /// </summary>
        public DateTimeOffset ExpirationTime { get => DateTimeOffset.FromUnixTimeSeconds(Payload.ExpirationTime); }

        /// <summary>
        /// Time before which this token is not valid.
        /// </summary>
        public DateTimeOffset NotBeforeTime { get => DateTimeOffset.FromUnixTimeSeconds(Payload.NotBeforeTime); }

        /// <summary>
        /// Time at which this token was issued.
        /// </summary>
        public DateTimeOffset IssuedAtTime { get => DateTimeOffset.FromUnixTimeSeconds(Payload.IssuedAtTime); }

        /// <summary>
        /// Represents the body of the token encoded as a string.
        /// </summary>
        public string TokenBody  { get => Encoding.UTF8.GetString(TokenBodyBytes.ToArray()); }

        /// <summary>
        /// Represents the body of the token encoded as a string.
        /// </summary>
        public string TokenHeader { get => Encoding.UTF8.GetString(TokenHeaderBytes.ToArray()); }

        /// <summary>
        /// Validate a JSON Web Token returned by the MAA.
        /// </summary>
        /// <param name="attestationSigningCertificates">Signing Certificates used to validate the token.</param>
        /// <param name="validationCallback">User provided callback which allows the customer to validate the token.</param>
        /// <returns></returns>
        public virtual bool ValidateToken(IReadOnlyList<AttestationSigner> attestationSigningCertificates, Func<AttestationToken, AttestationSigner, bool> validationCallback = default)
        {
            Argument.AssertNotNull(attestationSigningCertificates, nameof(attestationSigningCertificates));
            Argument.AssertNotNull(attestationSigningCertificates[0], nameof(attestationSigningCertificates));
            Argument.AssertNotNullOrEmpty(attestationSigningCertificates, nameof(attestationSigningCertificates));

            if (validationCallback != null)
            {
                return validationCallback(this, attestationSigningCertificates[0]);
            }
            return true;
        }

        /// <summary>
        /// Retrieves the body of the AttestationToken as the specified type.
        /// </summary>
        /// <typeparam name="T">Underlying type for the token body.</typeparam>
        /// <returns></returns>
        public T GetBody<T>()
            where T: class
        {
            lock (_statelock)
            {
                if (_deserializedBody == null || _deserializedBody.GetType() != typeof(T))
                {
                    _deserializedBody = JsonSerializer.Deserialize<T>(TokenBodyBytes.ToArray(), _options);
                }
                return (T)_deserializedBody;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _token ??  GetType().Name;
        }
    }
}
