// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
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
        /// A copy of the RuntimeData specified as an input to the attest call, if the <see cref="AttestationRequest.RuntimeData"/>'s <see cref="AttestationData"/> was specified as binary.
        /// </summary>
        public BinaryData EnclaveHeldData { get => InternalEnclaveHeldData != null ? BinaryData.FromBytes(Base64Url.Decode(InternalEnclaveHeldData)) : null; }

        [CodeGenMember("EnclaveHeldData")]
        private string InternalEnclaveHeldData { get; }

        /// <summary>
        /// The SHA256 hash of the BASE64URL encoded policy text used for attestation.
        /// </summary>
        public BinaryData PolicyHash { get => InternalPolicyHash != null ? BinaryData.FromBytes(Base64Url.Decode(InternalPolicyHash)) : null; }
        [CodeGenMember("PolicyHash")]
        private string InternalPolicyHash { get; }

        /// <summary> If not null, represents the <see cref="AttestationSigner"/> which was used to sign the policy used in validating the attestation evidence.</summary>
        public AttestationSigner PolicySigner { get => AttestationSigner.FromJsonWebKey(InternalPolicySigner); }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-ehd claim. </summary>
        [Obsolete("DeprecatedEnclaveHeldData2 is deprecated, use EnclaveHeldData instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData DeprecatedEnclaveHeldData2 => InternalDeprecatedEnclaveHeldData2 != null ? BinaryData.FromBytes(Base64Url.Decode(InternalDeprecatedEnclaveHeldData2)) : null;

        [CodeGenMember("DeprecatedEnclaveHeldData2")]
        private string InternalDeprecatedEnclaveHeldData2{ get; }

        /// <summary>
        /// DEPRECATED: Private preview version of x-ms-sgx-ehd claim.
        /// </summary>
        [Obsolete("DeprecatedEnclaveHeldData is deprecated, use EnclaveHeldData instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData DeprecatedEnclaveHeldData => InternalDeprecatedEnclaveHeldData != null ? BinaryData.FromBytes(Base64Url.Decode(InternalDeprecatedEnclaveHeldData)) : null;

        [CodeGenMember("DeprecatedEnclaveHeldData")]
        private string InternalDeprecatedEnclaveHeldData { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-policy-hash. </summary>
        [Obsolete("DeprecatedPolicyHash is deprecated, use PolicyHash instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData DeprecatedPolicyHash => InternalDeprecatedPolicyHash != null ? BinaryData.FromBytes(Base64Url.Decode(InternalDeprecatedPolicyHash)) : null;

        [CodeGenMember("DeprecatedPolicyHash")]
        internal string InternalDeprecatedPolicyHash { get; }

        /// <summary>
        /// DEPRECATED: Private Preview version of nonce.
        /// </summary>
        [Obsolete("DeprecatedRpData is deprecated, use Nonce instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeprecatedRpData { get => InternalDeprecatedRpData; }

        [CodeGenMember("DeprecatedRpData")]
        private string InternalDeprecatedRpData { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-tee. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("DeprecatedTee is deprecated, use Tee instead")]
        public string DeprecatedTee { get => InternalDeprecatedTee; }

        [CodeGenMember("DeprecatedTee")]
        private string InternalDeprecatedTee { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-svn. </summary>
        [Obsolete("DeprecatedSvn is deprecated, use Svn instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? DeprecatedSvn { get => InternalDeprecatedSvn; }

        [CodeGenMember("DeprecatedSvn")]
        private float? InternalDeprecatedSvn{ get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-mrsigner. </summary>
        [Obsolete("DeprecatedMrSigner is deprecated, use MrSigner instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeprecatedMrSigner { get => InternalDeprecatedMrSigner; }

        [CodeGenMember("DeprecatedMrSigner")]
        private string InternalDeprecatedMrSigner { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-mrenclave. </summary>
        [Obsolete("DeprecatedMrEnclave is deprecated, use MrEnclave instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeprecatedMrEnclave { get => InternalDeprecatedMrEnclave; }

        [CodeGenMember("DeprecatedMrEnclave")]
        private string InternalDeprecatedMrEnclave { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-product-id. </summary>
        [Obsolete("DeprecatedProductId is deprecated, use ProductId instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? DeprecatedProductId { get => InternalDeprecatedProductId; }

        [CodeGenMember("DeprecatedProductId")]
        private float? InternalDeprecatedProductId { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-collateral claim. </summary>
        [Obsolete("DeprecatedSgxCollateral is deprecated, use SgxCollateral instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object DeprecatedSgxCollateral { get; }

        [CodeGenMember("DeprecatedSgxCollateral")]
        private object InternalDeprecatedSgxCollateral { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-ver claim. </summary>
        [Obsolete("DeprecatedVersion is deprecated, use Version instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeprecatedVersion { get => InternalDeprecatedVersion; }

        [CodeGenMember("DeprecatedVersion")]
        private string InternalDeprecatedVersion { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-is-debuggable claim. </summary>
        [Obsolete("DeprecatedIsDebuggable is deprecated, use IsDebuggable instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DeprecatedIsDebuggable { get => InternalDeprecatedIsDebuggable; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-policy-signer claim. </summary>
        [Obsolete("DeprecatedPolicySigner is deprecated, use PolicySigner instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttestationSigner DeprecatedPolicySigner { get => AttestationSigner.FromJsonWebKey(InternalDeprecatedPolicySigner); }

        [CodeGenMember("DeprecatedIsDebuggable")]
        private bool? InternalDeprecatedIsDebuggable { get; }

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
