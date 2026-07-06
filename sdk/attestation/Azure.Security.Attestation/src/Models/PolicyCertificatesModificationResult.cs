// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    [JsonConverter(typeof(PolicyCertificatesModificationResultConverter))]
    [CodeGenType("PolicyCertificatesModificationResult")]
    public partial class PolicyCertificatesModificationResult
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PolicyCertificatesModificationResult"/>.
        /// </summary>
        public PolicyCertificatesModificationResult()
        {
        }

        /// <summary> SHA256 Hash of the binary representation certificate which was added or removed. </summary>
        [CodeGenMember("CertificateThumbprint")]
        public string CertificateThumbprint { get; set; }

        /// <summary> The result of the operation. </summary>
        [CodeGenMember("CertificateResolution")]
        public PolicyCertificateResolution? CertificateResolution { get; set; }

        internal partial class PolicyCertificatesModificationResultConverter : System.Text.Json.Serialization.JsonConverter<PolicyCertificatesModificationResult>
        {
            public override PolicyCertificatesModificationResult Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
            {
                using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.ParseValue(ref reader);
                return DeserializePolicyCertificatesModificationResult(document.RootElement, ModelSerializationExtensions.WireOptions);
            }

            public override void Write(System.Text.Json.Utf8JsonWriter writer, PolicyCertificatesModificationResult value, System.Text.Json.JsonSerializerOptions options)
            {
                ((System.ClientModel.Primitives.IJsonModel<PolicyCertificatesModificationResult>)value).Write(writer, ModelSerializationExtensions.WireOptions);
            }
        }
    }
}
