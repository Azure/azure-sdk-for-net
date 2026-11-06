// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// The <see href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID Connect discovery document</see> of an attestation provider.
    /// </summary>
    // Makes the generated OpenIDConfigurationResult public under a descriptive name.
    [CodeGenType("OpenIDConfigurationResult")]
    public partial class AttestationOpenIdMetadata
    {
        /// <summary>
        /// Gets the issuer of the tokens the attestation provider returns: the "issuer" metadata value.
        /// It matches the "iss" claim of those tokens exactly, so it can be used as <see cref="AttestationTokenValidationOptions.ExpectedIssuer"/>.
        /// </summary>
        // A string, not a Uri: OpenID Connect requires an exact match with "iss", and Uri adds a trailing slash to host-only values.
        public string Issuer { get; }

        /// <summary>
        /// Gets the URI of the keys that sign the tokens the attestation provider returns: the "jwks_uri" metadata value.
        /// </summary>
        [CodeGenMember("JwksUri")]
        public Uri JsonWebKeySetUri { get; }

        /// <summary>
        /// Gets the response types the attestation provider supports: the "response_types_supported" metadata value.
        /// </summary>
        public IReadOnlyList<string> ResponseTypesSupported { get; }

        /// <summary>
        /// Gets the algorithms the attestation provider signs tokens with: the "id_token_signing_alg_values_supported" metadata value.
        /// </summary>
        [CodeGenMember("IdTokenSigningAlgValuesSupported")]
        public IReadOnlyList<string> TokenSigningAlgorithmsSupported { get; }

        /// <summary>
        /// Gets the names of the claims the attestation provider can issue: the "claims_supported" metadata value.
        /// </summary>
        [CodeGenMember("ClaimsSupported")]
        public IReadOnlyList<string> SupportedClaims { get; }

        // Not exposed: the service advertises this address but serves nothing there. Declared so it is generated internal.
        internal string RevocationEndpoint { get; }
    }
}
