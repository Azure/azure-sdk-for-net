// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a Policy Get or Set or Reset result.
    /// </summary>
    [JsonConverter(typeof(PolicyModificationResultConverter))]
    [CodeGenType("PolicyResult")]
    public partial class PolicyModificationResult
    {
        /// <summary>
        /// Creates a new instance of a <see cref="PolicyModificationResult"/> object.
        /// </summary>
        public PolicyModificationResult()
        {
        }

        /// <summary>
        /// Resolution of the policy operation.
        /// </summary>
        public PolicyModification PolicyResolution { get => BasePolicyResolution ?? default; }

        /// <summary>
        /// Signing Certificate used to set the policy.
        /// </summary>
        public AttestationSigner PolicySigner
        {
            get
            {
                if (BasePolicySigner != null)
                {
                    return AttestationSigner.FromJsonWebKey(BasePolicySigner);
                }
                else
                {
                    return null;
                }
            }
        }

        [CodeGenMember("PolicyResolution")]
        internal PolicyModification? BasePolicyResolution { get; }

        /// <summary>
        /// JSON Web Token containing the policy retrieved.
        /// </summary>
        [CodeGenMember("Policy")]
        internal string BasePolicy { get; }

        /// <summary>
        /// JSON Web Token containing the policy retrieved.
        /// </summary>
        internal AttestationToken PolicyToken { get => AttestationToken.Deserialize(BasePolicy); }

        /// <summary>
        /// X.509 certificate used to sign the policy document.
        /// </summary>
        [CodeGenMember("PolicySigner")]
        internal JsonWebKey BasePolicySigner { get; }

        internal partial class PolicyModificationResultConverter : System.Text.Json.Serialization.JsonConverter<PolicyModificationResult>
        {
            public override PolicyModificationResult Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
            {
                using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.ParseValue(ref reader);
                return DeserializePolicyModificationResult(document.RootElement, ModelSerializationExtensions.WireOptions);
            }

            public override void Write(System.Text.Json.Utf8JsonWriter writer, PolicyModificationResult value, System.Text.Json.JsonSerializerOptions options)
            {
                ((System.ClientModel.Primitives.IJsonModel<PolicyModificationResult>)value).Write(writer, ModelSerializationExtensions.WireOptions);
            }
        }
    }
}
