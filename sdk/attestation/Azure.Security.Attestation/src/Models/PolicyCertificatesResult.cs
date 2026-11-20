// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    [JsonConverter(typeof(PolicyCertificatesResultConverter))]
    [CodeGenType("PolicyCertificatesResult")]
    internal partial class PolicyCertificatesResult
    {
        private IReadOnlyList<X509Certificate2> _certificateList;
        private object _statelock = new object();

        /// <summary>
        /// Returns the list of policy management certificates for this attestation instance.
        /// </summary>
        /// <returns>A list of <see cref="X509Certificate2"/> certificates which are used to sign incoming requests.</returns>
        public IReadOnlyList<X509Certificate2> GetPolicyCertificates()
        {
            lock (_statelock)
            {
                if (_certificateList == null)
                {
                    List<X509Certificate2> certificates = new List<X509Certificate2>();
                    foreach (var key in PolicyCertificates.Keys)
                    {
                        if (key.X5c == null)
                        {
                            // the key returned must have a X5c property.
                            throw new InvalidOperationException(Azure_Security_Attestation.PolicyCertificatesRequireX5C);
                        }
#if NET9_0_OR_GREATER
                        certificates.Add(X509CertificateLoader.LoadCertificate(Convert.FromBase64String(key.X5c[0])));
#else
                        certificates.Add(new X509Certificate2(Convert.FromBase64String(key.X5c[0])));
#endif
                    }
                    _certificateList = certificates;
                }
                return _certificateList;
            }
        }

        internal partial class PolicyCertificatesResultConverter : System.Text.Json.Serialization.JsonConverter<PolicyCertificatesResult>
        {
            public override PolicyCertificatesResult Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
            {
                using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.ParseValue(ref reader);
                return DeserializePolicyCertificatesResult(document.RootElement, ModelSerializationExtensions.WireOptions);
            }

            public override void Write(System.Text.Json.Utf8JsonWriter writer, PolicyCertificatesResult value, System.Text.Json.JsonSerializerOptions options)
            {
                ((System.ClientModel.Primitives.IJsonModel<PolicyCertificatesResult>)value).Write(writer, ModelSerializationExtensions.WireOptions);
            }
        }
    }
}
