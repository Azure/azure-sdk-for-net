// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    /// <summary>
    /// Represents the standardized claims in the header of a JSON Web Token.
    /// </summary>
    internal partial class JsonWebTokenHeader
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("alg")]
        public string Algorithm { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("jwk")]
        internal JsonWebKey JsonWebKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("typ")]
        public string Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("cty")]
        public string ContentType { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("jku")]
        public Uri JWKUri { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("kid")]
        public string KeyId{ get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("x5u")]
        public Uri X509Uri { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("x5c")]
        public string[] X509CertificateChain { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("x5t")]
        public string X509CertificateThumbprint { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("x5t#S256")]
        public string X509CertificateSha256Thumbprint { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("crit")]
        public bool? Critical { get; set; }
    }
}
