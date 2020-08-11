// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal struct IssuerParameters
    {
        private const string IssuerNamePropertyName = "name";
        private const string CertificateTypePropertyName = "cty";
        private const string CertificateTransparencyPropertyName = "cert_transparency";

        private static readonly JsonEncodedText s_issuerNamePropertyNameBytes = JsonEncodedText.Encode(IssuerNamePropertyName);
        private static readonly JsonEncodedText s_certificateTypePropertyNameBytes = JsonEncodedText.Encode(CertificateTypePropertyName);
        private static readonly JsonEncodedText s_certificateTransparencyPropertyNameNameBytes = JsonEncodedText.Encode(CertificateTransparencyPropertyName);

        internal string IssuerName { get; set; }

        internal string CertificateType { get; set; }

        internal bool? CertificateTransparency { get; set; }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case IssuerNamePropertyName:
                        IssuerName = prop.Value.GetString();
                        break;

                    case CertificateTypePropertyName:
                        CertificateType = prop.Value.GetString();
                        break;

                    case CertificateTransparencyPropertyName:
                        CertificateTransparency = prop.Value.GetBoolean();
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (IssuerName != null)
            {
                json.WriteString(s_issuerNamePropertyNameBytes, IssuerName);
            }

            if (CertificateType != null)
            {
                json.WriteString(s_certificateTypePropertyNameBytes, CertificateType);
            }

            if (CertificateTransparency.HasValue)
            {
                json.WriteBoolean(s_certificateTransparencyPropertyNameNameBytes, CertificateTransparency.Value);
            }
        }
    }
}
