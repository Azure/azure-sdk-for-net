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
        /// DEPRECATED: Private preview version of x-ms-sgx-ehd claim.
        /// </summary>
        [Obsolete("DeprecatedEnclaveHeldData is deprecated, use EnclaveHeldData instead"]
        public byte[] DeprecatedEnclaveHeldData { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-ver claim. </summary>
        [Obsolete("DeprecatedVersion is deprecated, use Version instead")]
        public string DeprecatedVersion { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-is-debuggable claim. </summary>
        [Obsolete("DeprecatedIsDebuggable is deprecated, use IsDebuggable instead")]
        public bool? DeprecatedIsDebuggable { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-collateral claim. </summary>
        [Obsolete("DeprecatedSgxCollateral is deprecated, use SgxCollateral instead")]
        public object DeprecatedSgxCollateral { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-ehd claim. </summary>
        [Obsolete("DeprecatedEnclaveHeldData2 is deprecated, use EnclaveHeldData instead")]
        public byte[] DeprecatedEnclaveHeldData2 { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-product-id. </summary>
        [Obsolete("DeprecatedProductId is deprecated, use ProductId instead")]
        public float? DeprecatedProductId { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-mrenclave. </summary>
        [Obsolete("DeprecatedMrEnclave is deprecated, use MrEnclave instead")]
        public string DeprecatedMrEnclave { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-mrsigner. </summary>
        [Obsolete("DeprecatedMrSigner is deprecated, use MrSigner instead")]
        public string DeprecatedMrSigner { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-svn. </summary>
        [Obsolete("DeprecatedSvn is deprecated, use Svn instead")]
        public float? DeprecatedSvn { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-tee. </summary>
        [Obsolete("DeprecatedTee is deprecated, use Tee instead")]
        public string DeprecatedTee { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-policy-hash. </summary>
        [Obsolete("DeprecatedPolicyHash is deprecated, use PolicyHash instead")]
        public BinaryData DeprecatedPolicyHash { get; }
        /// <summary> DEPRECATED: Private Preview version of nonce. </summary>

        public string DeprecatedRpData { get; }
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
