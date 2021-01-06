// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    /// <summary>
    /// Represents the standard claims in the body of an RFC 7515 Json Web Token.
    /// </summary>
    internal partial class JsonWebTokenBody
    {
        /// <summary>
        /// Issuer for the token.
        /// </summary>
        [JsonPropertyName("iss")]
        public string Issuer { get; set; }

        /// <summary>
        /// Subject for the token.
        /// </summary>
        [JsonPropertyName("sub")]
        public string Subject { get; set; }

        /// <summary>
        /// Audience of the token.
        /// </summary>
        [JsonPropertyName("aud")]
        public string Audience{ get; set; }

        /// <summary>
        /// Expiration time for the token.
        /// </summary>
        [JsonPropertyName("exp")]
        public long ExpirationTime{ get; set; }

        /// <summary>
        /// Time before which this token is not valid.
        /// </summary>
        [JsonPropertyName("nbf")]
        public long NotBeforeTime { get; set; }

        /// <summary>
        /// Time at which this token was issued.
        /// </summary>
        [JsonPropertyName("iat")]
        public long IssuedAtTime { get; set; }

        /// <summary>
        /// Unique identifier for this token.
        /// </summary>
        [JsonPropertyName("jti")]
        public string UniqueIdentifier { get; set; }
    }
}
