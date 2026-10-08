// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    [JsonConverter(typeof(AttestationResultConverter))]
    [CodeGenType("AttestationResult")]
    // The spec types policy_hash as standard Base64; like 1.0.0 and the other hash claims, it is Base64Url.
    [CodeGenSerialization(nameof(DeprecatedPolicyHash), SerializationValueHook = nameof(SerializeDeprecatedPolicyHash), DeserializationValueHook = nameof(DeserializeDeprecatedPolicyHash))]
    // client.tsp renames these claims for C#, and the generator then uses the C# names on the wire.
    [CodeGenSerialization(nameof(Svn), "x-ms-sgx-svn")]
    [CodeGenSerialization(nameof(DeprecatedSvn), "svn")]
    public partial class AttestationResult
    {
        internal AttestationResult()
        {
        }

        // Raw JWT claims; exposed publicly through the typed properties below, as in 1.0.0.
        internal string Jti { get; }
        internal string Iss { get; }
        internal DateTimeOffset? Iat { get; }
        internal DateTimeOffset? Exp { get; }
        internal DateTimeOffset? Nbf { get; }

        /// <summary>
        /// Gets the time when this attestation token was issued.
        /// </summary>
        public DateTimeOffset IssuedAt
        {
            get => Iat.Value;
        }

        /// <summary>
        /// Gets the time when this attestation token will expire.
        /// </summary>
        public DateTimeOffset Expiration
        {
            get => Exp.Value;
        }

        /// <summary>
        /// Gets the time before which this token is invalid.
        /// </summary>
        public DateTimeOffset NotBefore
        {
            get => Nbf.Value;
        }

        /// <summary>
        /// Gets the base URI which issued this token.
        /// </summary>
        public Uri Issuer
        {
            get => new Uri(Iss);
        }

        /// <summary>
        /// Gets the RFC 7800 (https://tools.ietf.org/html/rfc7800) "cnf" claim (see also https://tools.ietf.org/html/rfc7800#section-3.1).
        /// </summary>
        public object Confirmation
        {
            get => InternalCnf;
        }

        // object, as in 1.0.0: RFC 7800 cnf is usually a nested object, which Record<string> cannot hold.
        [CodeGenMember("Cnf")]
        internal object InternalCnf { get; }

        /// <summary>
        /// Gets the RFC 7519 "jti" claim name (https://tools.ietf.org/html/rfc7519#section-4)
        /// </summary>
        public string UniqueIdentifier { get => Jti; }

        /// <summary>
        /// Gets the token's claims that have no dedicated property on this type, keyed by claim name; each value is the claim's JSON value.
        /// These include the TDX (<c>tdx_*</c>) and SEV-SNP (<c>x-ms-sevsnpvm-*</c>) claims and any claims issued by attestation policy.
        /// Values are raw JSON, so read a string claim with <c>ToObjectFromJson&lt;string&gt;()</c> rather than <c>ToString()</c>.
        /// </summary>
        public IReadOnlyDictionary<string, BinaryData> AdditionalClaims
            => _additionalClaims ??= new ReadOnlyDictionary<string, BinaryData>(_additionalBinaryDataProperties ?? new Dictionary<string, BinaryData>());

        private IReadOnlyDictionary<string, BinaryData> _additionalClaims;

        /// <summary>
        /// A copy of the RuntimeData specified as an input to the attest call, if the <see cref="AttestationRequest.RuntimeData"/>'s <see cref="AttestationData"/> was specified as binary.
        /// </summary>
        public BinaryData EnclaveHeldData { get; }

        /// <summary>
        /// The SHA256 hash of the BASE64URL encoded policy text used for attestation.
        /// </summary>
        public BinaryData PolicyHash { get; }

        /// <summary> If not null, represents the <see cref="AttestationSigner"/> which was used to sign the policy used in validating the attestation evidence.</summary>
        public AttestationSigner PolicySigner { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-ehd claim. </summary>
        [Obsolete("DeprecatedEnclaveHeldData2 is deprecated, use EnclaveHeldData instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData DeprecatedEnclaveHeldData2 { get; }

        /// <summary>
        /// DEPRECATED: Private preview version of x-ms-sgx-ehd claim.
        /// </summary>
        [Obsolete("DeprecatedEnclaveHeldData is deprecated, use EnclaveHeldData instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData DeprecatedEnclaveHeldData { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-policy-hash. </summary>
        [Obsolete("DeprecatedPolicyHash is deprecated, use PolicyHash instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData DeprecatedPolicyHash { get; }

        private void SerializeDeprecatedPolicyHash(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(Base64Url.Encode(DeprecatedPolicyHash.ToArray()));

        private static void DeserializeDeprecatedPolicyHash(JsonProperty property, ref BinaryData deprecatedPolicyHash)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                deprecatedPolicyHash = BinaryData.FromBytes(Base64Url.Decode(property.Value.GetString()));
            }
        }

        /// <summary>
        /// DEPRECATED: Private Preview version of nonce.
        /// </summary>
        [Obsolete("DeprecatedRpData is deprecated, use Nonce instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeprecatedRpData { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-tee. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("DeprecatedTee is deprecated, use Tee instead")]
        public string DeprecatedTee { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-svn. </summary>
        [Obsolete("DeprecatedSvn is deprecated, use Svn instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? DeprecatedSvn { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-mrsigner. </summary>
        [Obsolete("DeprecatedMrSigner is deprecated, use MrSigner instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeprecatedMrSigner { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-mrenclave. </summary>
        [Obsolete("DeprecatedMrEnclave is deprecated, use MrEnclave instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeprecatedMrEnclave { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-product-id. </summary>
        [Obsolete("DeprecatedProductId is deprecated, use ProductId instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? DeprecatedProductId { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-collateral claim. </summary>
        [Obsolete("DeprecatedSgxCollateral is deprecated, use SgxCollateral instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object DeprecatedSgxCollateral { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-ver claim. </summary>
        [Obsolete("DeprecatedVersion is deprecated, use Version instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeprecatedVersion { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-sgx-is-debuggable claim. </summary>
        [Obsolete("DeprecatedIsDebuggable is deprecated, use IsDebuggable instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DeprecatedIsDebuggable { get; }

        /// <summary> DEPRECATED: Private Preview version of x-ms-policy-signer claim. </summary>
        [Obsolete("DeprecatedPolicySigner is deprecated, use PolicySigner instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttestationSigner DeprecatedPolicySigner { get; }

        internal partial class AttestationResultConverter : System.Text.Json.Serialization.JsonConverter<AttestationResult>
        {
            // "J" rather than the wire format, so claims without a dedicated property are kept for AdditionalClaims.
            public override AttestationResult Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
            {
                using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.ParseValue(ref reader);
                return DeserializeAttestationResult(document.RootElement, ModelReaderWriterOptions.Json);
            }

            public override void Write(System.Text.Json.Utf8JsonWriter writer, AttestationResult value, System.Text.Json.JsonSerializerOptions options)
            {
                ((System.ClientModel.Primitives.IJsonModel<AttestationResult>)value).Write(writer, ModelReaderWriterOptions.Json);
            }
        }
    }
}
