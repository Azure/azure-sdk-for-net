// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A policy which governs the lifecycle a properties of a certificate managed by Azure Key Vault
    /// </summary>
    public class CertificatePolicy : IJsonSerializable, IJsonDeserializable
    {
        /// <summary>
        /// The properties of the key backing a certificate
        /// </summary>
        public KeyOptions KeyOptions { get; set; }

        /// <summary>
        /// The subject name of a certificate
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The subject alternative names (SAN) of a certificate
        /// </summary>
        public SubjectAlternativeNames SubjectAlternativeNames { get; set; }

        /// <summary>
        /// The name of an issuer for a certificate
        /// </summary>
        public string IssuerName { get; set; }

        /// <summary>
        /// Content type of the certificate when downloaded from getSecret.
        /// </summary>
        public CertificateContentType? ContentType { get; set; }

        /// <summary>
        /// The certificate type of a certificate
        /// </summary>
        public string CertificateType { get; set; }

        /// <summary>
        /// Specifies whether a certificate should be published to the certificate transparency list when created
        /// </summary>
        public bool? CertificateTransparency { get; set; }

        /// <summary>
        /// The validity period for a certificate in months
        /// </summary>
        public int? ValidityInMonths { get; set; }

        /// <summary>
        /// The last updated time in UTC.
        /// </summary>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// The creation time in UTC.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// The allowed usages for the key of the certificate
        /// </summary>
        public IList<KeyUsage> KeyUsage { get; set; }

        /// <summary>
        /// The allowed enhanced key usages (EKUs) of the certificate
        /// </summary>
        public IList<string> EnhancedKeyUsage { get; set; }

        /// <summary>
        /// Actions to be executed at specified points in the certificates lifetime
        /// </summary>
        public IList<LifetimeAction> LifetimeActions { get; set; }

        private const string KeyPropsPropertyName = "key_props";
        private const string SecretPropsPropertyName = "secret_props";
        private const string X509PropsPropertyName = "x509_props";
        private const string LifetimeActionsPropertyName = "lifetime_actions";
        private static readonly JsonEncodedText s_lifetimeActionsPropertyNameBytes = JsonEncodedText.Encode(LifetimeActionsPropertyName);
        private const string IssuerPropertyName = "issuer";
        private static readonly JsonEncodedText s_issuerPropertyNameBytes = JsonEncodedText.Encode(IssuerPropertyName);
        private const string AttributesPropertyName = "attributes";

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyPropsPropertyName:
                        KeyOptions.FromJsonObject(prop.Value);
                        break;
                    case SecretPropsPropertyName:
                        ReadSecretProperties(prop.Value);
                        break;
                    case X509PropsPropertyName:
                        ReadX509CertificateProperties(prop.Value);
                        break;
                    case IssuerPropertyName:
                        ReadIssuerProperties(prop.Value);
                        break;
                    case AttributesPropertyName:
                        ReadAttributesProperties(prop.Value);
                        break;
                    case LifetimeActionsPropertyName:
                        LifetimeActions = new List<LifetimeAction>();
                        foreach (JsonElement actionElem in prop.Value.EnumerateArray())
                        {
                            LifetimeActions.Add(LifetimeAction.FromJsonObject(actionElem));
                        }
                        break;

                }
            }
        }

        private static readonly JsonEncodedText s_keyPropsPropertyNameBytes = JsonEncodedText.Encode(KeyPropsPropertyName);
        private static readonly JsonEncodedText s_secretPropsPropertyNameBytes = JsonEncodedText.Encode(SecretPropsPropertyName);
        private static readonly JsonEncodedText s_x509PropsPropertyNameBytes = JsonEncodedText.Encode(X509PropsPropertyName);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            // Key Props
            if (KeyOptions != null)
            {
                json.WriteStartObject(s_keyPropsPropertyNameBytes);

                KeyOptions.WriteProperties(json);

                json.WriteEndObject();
            }

            // Secret Props
            if (ContentType.HasValue)
            {
                json.WriteStartObject(s_secretPropsPropertyNameBytes);

                WriteSecretProperties(json);

                json.WriteEndObject();
            }

            // X509 Props
            if (Subject != null || SubjectAlternativeNames != null || KeyUsage != null || EnhancedKeyUsage != null || ValidityInMonths.HasValue)
            {
                json.WriteStartObject(s_x509PropsPropertyNameBytes);

                WriteX509CertificateProperties(json);

                json.WriteEndObject();
            }

            // Issuer Props
            if (IssuerName != null || CertificateType != null || CertificateTransparency.HasValue)
            {
                json.WriteStartObject(s_issuerPropertyNameBytes);

                WriteIssuerProperties(json);

                json.WriteEndObject();
            }

            if (LifetimeActions != null)
            {
                json.WriteStartArray(s_lifetimeActionsPropertyNameBytes);

                foreach (LifetimeAction action in LifetimeActions)
                {
                    if (action != null)
                    {
                        json.WriteStartObject();

                        ((IJsonSerializable)action).WriteProperties(json);

                        json.WriteEndObject();
                    }
                }

                json.WriteEndArray();
            }
        }

        private const string ContentTypePropertyName = "contentType";
        private static readonly JsonEncodedText s_contentTypePropertyNameBytes = JsonEncodedText.Encode(ContentTypePropertyName);

        private void ReadSecretProperties(JsonElement json)
        {
            if (json.TryGetProperty(ContentTypePropertyName, out JsonElement contentTypeProp))
            {
                ContentType = contentTypeProp.GetString();
            }
        }

        private void WriteSecretProperties(Utf8JsonWriter json)
        {
            if (ContentType != null)
            {
                json.WriteString(s_contentTypePropertyNameBytes, ContentType);
            }
        }

        private const string SubjectPropertyName = "subject";
        private static readonly JsonEncodedText s_subjectPropertyNameBytes = JsonEncodedText.Encode(SubjectPropertyName);
        private const string SansPropertyName = "sans";
        private static readonly JsonEncodedText s_sansPropertyNameBytes = JsonEncodedText.Encode(SansPropertyName);
        private const string KeyUsagePropertyName = "key_usage";
        private static readonly JsonEncodedText s_keyUsagePropertyNameBytes = JsonEncodedText.Encode(KeyUsagePropertyName);
        private const string EkusPropertyName = "ekus";
        private static readonly JsonEncodedText s_ekusPropertyNameBytes = JsonEncodedText.Encode(EkusPropertyName);
        private const string ValidityMonthsPropertyName = "validity_months";
        private static readonly JsonEncodedText s_validityMonthsPropertyNameBytes = JsonEncodedText.Encode(ValidityMonthsPropertyName);

        private void ReadX509CertificateProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case SubjectPropertyName:
                        Subject = prop.Value.GetString();
                        break;
                    case SansPropertyName:
                        SubjectAlternativeNames = new SubjectAlternativeNames();
                        ((IJsonDeserializable)SubjectAlternativeNames).ReadProperties(prop.Value);
                        break;
                    case KeyUsagePropertyName:
                        KeyUsage = new List<KeyUsage>();
                        foreach (JsonElement usageElem in prop.Value.EnumerateArray())
                        {
                            KeyUsage.Add(usageElem.GetString());
                        }
                        break;
                    case EkusPropertyName:
                        EnhancedKeyUsage = new List<string>();
                        foreach (JsonElement usageElem in prop.Value.EnumerateArray())
                        {
                            EnhancedKeyUsage.Add(usageElem.GetString());
                        }
                        break;
                    case ValidityMonthsPropertyName:
                        ValidityInMonths = prop.Value.GetInt32();
                        break;
                }
            }
        }

        private void WriteX509CertificateProperties(Utf8JsonWriter json)
        {
            if (Subject != null)
            {
                json.WriteString(s_subjectPropertyNameBytes, Subject);
            }

            if (SubjectAlternativeNames != null)
            {
                json.WriteStartObject(s_sansPropertyNameBytes);

                ((IJsonSerializable)SubjectAlternativeNames).WriteProperties(json);

                json.WriteEndObject();
            }

            if (KeyUsage != null)
            {
                json.WriteStartArray(s_keyUsagePropertyNameBytes);
                foreach (KeyUsage usage in KeyUsage)
                {
                    json.WriteStringValue(usage);
                }
                json.WriteEndArray();
            }

            if (EnhancedKeyUsage != null)
            {
                json.WriteStartArray(s_ekusPropertyNameBytes);
                foreach (var usage in EnhancedKeyUsage)
                {
                    json.WriteStringValue(usage);
                }
                json.WriteEndArray();
            }

            if (ValidityInMonths.HasValue)
            {
                json.WriteNumber(s_validityMonthsPropertyNameBytes, ValidityInMonths.Value);
            }
        }

        private const string IssuerNamePropertyName = "name";
        private static readonly JsonEncodedText s_issuerNamePropertyNameBytes = JsonEncodedText.Encode(IssuerNamePropertyName);
        private const string CertificateTypePropertyName = "cty";
        private static readonly JsonEncodedText s_certificateTypePropertyNameBytes = JsonEncodedText.Encode(CertificateTypePropertyName);
        private const string CertificateTransparencyPropertyName = "cert_transparency";
        private static readonly JsonEncodedText s_certificateTransparencyPropertyNameNameBytes = JsonEncodedText.Encode(CertificateTransparencyPropertyName);

        private void ReadIssuerProperties(JsonElement json)
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

        private void WriteIssuerProperties(Utf8JsonWriter json)
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

        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";

        private void ReadAttributesProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case CreatedPropertyName:
                        Created = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case UpdatedPropertyName:
                        Updated = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                }
            }
        }

    }
}
