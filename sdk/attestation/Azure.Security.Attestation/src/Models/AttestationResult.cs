// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.Attestation
{
    [CodeGenModel("AttestationResult")]
    public partial class AttestationResult
    {
        internal AttestationResult()
        {
        }

        /// <summary>
        /// Gets the time when this attestation token was issued.
        /// </summary>
        public DateTimeOffset IssuedAt
        {
            get => DateTimeOffset.FromUnixTimeSeconds((long)InternalIat.Value);
        }

        /// <summary>
        /// Gets the time when this attestation token will expire.
        /// </summary>
        public DateTimeOffset Expiration
        {
            get => DateTimeOffset.FromUnixTimeSeconds((long)InternalExp.Value);
        }

        /// <summary>
        /// Gets the time before which this token is invalid.
        /// </summary>
        public DateTimeOffset NotBefore
        {
            get => DateTimeOffset.FromUnixTimeSeconds((long)InternalNbf.Value);
        }

        /// <summary>
        /// Gets the base URI which issued this token.
        /// </summary>
        public Uri Issuer
        {
            get => new Uri(InternalIss);
        }

        /// <summary>
        /// Gets the RFC 7800 (https://tools.ietf.org/html/rfc7800) "cnf" claim (see also https://tools.ietf.org/html/rfc7800#section-3.1).
        /// </summary>
        public object Confirmation
        {
            get => InternalCnf;
        }

        /// <summary>
        /// Gets the RFC 7519 "jti" claim name (https://tools.ietf.org/html/rfc7519#section-4)
        /// </summary>
        public string UniqueIdentifier { get => InternalJti; }

        [CodeGenMember("Jti")]
        internal string InternalJti { get; }

        [CodeGenMember("Cnf")]
        internal object InternalCnf { get; }

        [CodeGenMember("Iss")]
        internal string InternalIss { get; }

        [CodeGenMember("Iat")]
        internal double? InternalIat { get; }
        [CodeGenMember("Nbf")]
        internal double? InternalNbf { get; }

        [CodeGenMember("Exp")]
        internal double? InternalExp { get; }

        [CodeGenMember("PolicySigner")]
        internal JsonWebKey InternalPolicySigner { get; }

        [CodeGenMember("DeprecatedPolicySigner")]
        internal JsonWebKey InternalDeprecatedPolicySigner { get; }
    }
}
