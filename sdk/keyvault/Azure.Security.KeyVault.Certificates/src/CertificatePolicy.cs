﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A policy which governs the lifecycle a properties of a certificate managed by Azure Key Vault.
    /// </summary>
    public class CertificatePolicy : IJsonSerializable, IJsonDeserializable
    {
        private const string DefaultSubject = "CN=DefaultPolicy";
        private const string DefaultIssuerName = "Self";

        private const string KeyTypePropertyName = "kty";
        private const string ReuseKeyPropertyName = "reuse_key";
        private const string ExportablePropertyName = "exportable";
        private const string CurveNamePropertyName = "crv";
        private const string KeySizePropertyName = "key_size";
        private const string KeyPropsPropertyName = "key_props";
        private const string SecretPropsPropertyName = "secret_props";
        private const string X509PropsPropertyName = "x509_props";
        private const string LifetimeActionsPropertyName = "lifetime_actions";
        private const string IssuerPropertyName = "issuer";
        private const string AttributesPropertyName = "attributes";
        private const string ContentTypePropertyName = "contentType";
        private const string SubjectPropertyName = "subject";
        private const string SansPropertyName = "sans";
        private const string KeyUsagePropertyName = "key_usage";
        private const string EkusPropertyName = "ekus";
        private const string ValidityMonthsPropertyName = "validity_months";
        private const string IssuerNamePropertyName = "name";
        private const string CertificateTypePropertyName = "cty";
        private const string CertificateTransparencyPropertyName = "cert_transparency";
        private const string EnabledPropertyName = "enabled";
        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";

        private static readonly JsonEncodedText s_keyTypePropertyNameBytes = JsonEncodedText.Encode(KeyTypePropertyName);
        private static readonly JsonEncodedText s_reuseKeyPropertyNameBytes = JsonEncodedText.Encode(ReuseKeyPropertyName);
        private static readonly JsonEncodedText s_exportablePropertyNameBytes = JsonEncodedText.Encode(ExportablePropertyName);
        private static readonly JsonEncodedText s_curveNamePropertyNameBytes = JsonEncodedText.Encode(CurveNamePropertyName);
        private static readonly JsonEncodedText s_keySizePropertyNameBytes = JsonEncodedText.Encode(KeySizePropertyName);
        private static readonly JsonEncodedText s_lifetimeActionsPropertyNameBytes = JsonEncodedText.Encode(LifetimeActionsPropertyName);
        private static readonly JsonEncodedText s_issuerPropertyNameBytes = JsonEncodedText.Encode(IssuerPropertyName);
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_keyPropsPropertyNameBytes = JsonEncodedText.Encode(KeyPropsPropertyName);
        private static readonly JsonEncodedText s_secretPropsPropertyNameBytes = JsonEncodedText.Encode(SecretPropsPropertyName);
        private static readonly JsonEncodedText s_x509PropsPropertyNameBytes = JsonEncodedText.Encode(X509PropsPropertyName);
        private static readonly JsonEncodedText s_contentTypePropertyNameBytes = JsonEncodedText.Encode(ContentTypePropertyName);
        private static readonly JsonEncodedText s_subjectPropertyNameBytes = JsonEncodedText.Encode(SubjectPropertyName);
        private static readonly JsonEncodedText s_sansPropertyNameBytes = JsonEncodedText.Encode(SansPropertyName);
        private static readonly JsonEncodedText s_keyUsagePropertyNameBytes = JsonEncodedText.Encode(KeyUsagePropertyName);
        private static readonly JsonEncodedText s_ekusPropertyNameBytes = JsonEncodedText.Encode(EkusPropertyName);
        private static readonly JsonEncodedText s_validityMonthsPropertyNameBytes = JsonEncodedText.Encode(ValidityMonthsPropertyName);
        private static readonly JsonEncodedText s_issuerNamePropertyNameBytes = JsonEncodedText.Encode(IssuerNamePropertyName);
        private static readonly JsonEncodedText s_certificateTypePropertyNameBytes = JsonEncodedText.Encode(CertificateTypePropertyName);
        private static readonly JsonEncodedText s_certificateTransparencyPropertyNameNameBytes = JsonEncodedText.Encode(CertificateTransparencyPropertyName);
        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificatePolicy"/> class.
        /// </summary>
        /// <param name="subject">The subject name of the certificate, such as "CN=contoso.com".</param>
        /// <param name="issuerName">The name of an issuer for the certificate, including values from <see cref="WellKnownIssuerNames"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="subject"/> or <paramref name="issuerName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="subject"/> or <paramref name="issuerName"/> is null.</exception>
        public CertificatePolicy(string subject, string issuerName)
        {
            Argument.AssertNotNullOrEmpty(subject, nameof(subject));
            Argument.AssertNotNullOrEmpty(issuerName, nameof(issuerName));

            Subject = subject;
            IssuerName = issuerName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificatePolicy"/> class.
        /// </summary>
        /// <param name="subjectAlternativeNames">The subject alternative names (SANs) of the certificate.</param>
        /// <param name="issuerName">The name of an issuer for the certificate, including values from <see cref="WellKnownIssuerNames"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="issuerName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="subjectAlternativeNames"/> or <paramref name="issuerName"/> is null.</exception>
        public CertificatePolicy(SubjectAlternativeNames subjectAlternativeNames, string issuerName)
        {
            Argument.AssertNotNull(subjectAlternativeNames, nameof(subjectAlternativeNames));
            Argument.AssertNotNullOrEmpty(issuerName, nameof(issuerName));

            SubjectAlternativeNames = subjectAlternativeNames;
            IssuerName = issuerName;
        }

        internal CertificatePolicy()
        {
        }

        /// <summary>
        /// Gets a new <see cref="CertificatePolicy"/> suitable for self-signed certificate requests.
        /// You should change the <see cref="Subject"/> before passing this policy to create a certificate.
        /// </summary>
        public static CertificatePolicy Default => new CertificatePolicy(DefaultSubject, DefaultIssuerName);

        /// <summary>
        /// Gets or sets the type of backing key to be generated when issuing new certificates.
        /// </summary>
        public CertificateKeyType? KeyType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the certificate key should be reused when rotating the certificate.
        /// </summary>
        public bool? ReuseKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the certificate key is exportable from the vault or secure certificate store.
        /// </summary>
        public bool? Exportable { get; set; }

        /// <summary>
        /// Gets or sets the curve which back an Elliptic Curve (EC) key.
        /// </summary>
        public CertificateKeyCurveName? KeyCurveName { get; set; }

        /// <summary>
        /// Gets or sets the size of the RSA key. The value must be a valid RSA key length such as 2048 or 4092.
        /// </summary>
        public int? KeySize { get; set; }

        /// <summary>
        /// Gets the subject name of a certificate.
        /// </summary>
        public string Subject { get; internal set; }

        /// <summary>
        /// Gets the subject alternative names (SANs) of a certificate.
        /// </summary>
        public SubjectAlternativeNames SubjectAlternativeNames { get; internal set; }

        /// <summary>
        /// Gets the name of an issuer for a certificate.
        /// </summary>
        public string IssuerName { get; internal set; }

        /// <summary>
        /// Gets or sets the <see cref="CertificateContentType"/> of the certificate when downloaded from GetSecret.
        /// </summary>
        public CertificateContentType? ContentType { get; set; }

        /// <summary>
        /// Gets or sets the certificate type of a certificate.
        /// </summary>
        public string CertificateType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a certificate should be published to the certificate transparency list when created.
        /// </summary>
        public bool? CertificateTransparency { get; set; }

        /// <summary>
        /// Gets or sets the validity period for a certificate in months.
        /// </summary>
        public int? ValidityInMonths { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the certificate is currently enabled. If null, the server default will be used.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate was updated.
        /// </summary>
        public DateTimeOffset? UpdatedOn { get; internal set; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; internal set; }

        /// <summary>
        /// Gets the allowed usages for the key of the certificate.
        /// </summary>
        public IList<CertificateKeyUsage> KeyUsage { get; } = new List<CertificateKeyUsage>();

        /// <summary>
        /// Gets the allowed enhanced key usages (EKUs) of the certificate.
        /// </summary>
        public IList<string> EnhancedKeyUsage { get; } = new List<string>();

        /// <summary>
        /// Gets the actions to be executed at specified times in the certificates lifetime.
        /// </summary>
        public IList<LifetimeAction> LifetimeActions { get; } = new List<LifetimeAction>();

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyPropsPropertyName:
                        ReadKeyProperties(prop.Value);
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
                        foreach (JsonElement actionElem in prop.Value.EnumerateArray())
                        {
                            LifetimeActions.Add(LifetimeAction.FromJsonObject(actionElem));
                        }
                        break;

                }
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            // Key Props
            if (KeyType.HasValue || KeyCurveName.HasValue || KeySize.HasValue)
            {
                json.WriteStartObject(s_keyPropsPropertyNameBytes);

                WriteKeyProperties(json);

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
            if (Subject != null || SubjectAlternativeNames != null || !KeyUsage.IsNullOrEmpty() || !EnhancedKeyUsage.IsNullOrEmpty() || ValidityInMonths.HasValue)
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

            if (Enabled.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                WriteAttributesProperties(json);

                json.WriteEndObject();
            }

            if (!LifetimeActions.IsNullOrEmpty())
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

        private void ReadKeyProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyTypePropertyName:
                        KeyType = prop.Value.GetString();
                        break;

                    case ReuseKeyPropertyName:
                        ReuseKey = prop.Value.GetBoolean();
                        break;

                    case ExportablePropertyName:
                        Exportable = prop.Value.GetBoolean();
                        break;

                    case CurveNamePropertyName:
                        KeyCurveName = prop.Value.GetString();
                        break;

                    case KeySizePropertyName:
                        KeySize = prop.Value.GetInt32();
                        break;
                }
            }
        }

        private void WriteKeyProperties(Utf8JsonWriter json)
        {
            if (KeyType.HasValue)
            {
                json.WriteString(s_keyTypePropertyNameBytes, KeyType.ToString());
            }

            if (ReuseKey.HasValue)
            {
                json.WriteBoolean(s_reuseKeyPropertyNameBytes, ReuseKey.Value);
            }

            if (Exportable.HasValue)
            {
                json.WriteBoolean(s_exportablePropertyNameBytes, Exportable.Value);
            }

            if (KeyCurveName.HasValue)
            {
                json.WriteString(s_curveNamePropertyNameBytes, KeyCurveName.ToString());
            }

            if (KeySize.HasValue)
            {
                json.WriteNumber(s_keySizePropertyNameBytes, KeySize.Value);
            }
        }

        private void ReadSecretProperties(JsonElement json)
        {
            if (json.TryGetProperty(ContentTypePropertyName, out JsonElement contentTypeProp))
            {
                ContentType = contentTypeProp.GetString();
            }
        }

        private void WriteSecretProperties(Utf8JsonWriter json)
        {
            if (ContentType.HasValue)
            {
                json.WriteString(s_contentTypePropertyNameBytes, ContentType.ToString());
            }
        }

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
                        foreach (JsonElement usageElem in prop.Value.EnumerateArray())
                        {
                            KeyUsage.Add(usageElem.GetString());
                        }
                        break;

                    case EkusPropertyName:
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

            if (!KeyUsage.IsNullOrEmpty())
            {
                json.WriteStartArray(s_keyUsagePropertyNameBytes);
                foreach (CertificateKeyUsage usage in KeyUsage)
                {
                    json.WriteStringValue(usage.ToString());
                }
                json.WriteEndArray();
            }

            if (!EnhancedKeyUsage.IsNullOrEmpty())
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

        private void ReadAttributesProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case EnabledPropertyName:
                        Enabled = prop.Value.GetBoolean();
                        break;

                    case CreatedPropertyName:
                        CreatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;

                    case UpdatedPropertyName:
                        UpdatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                }
            }
        }

        private void WriteAttributesProperties(Utf8JsonWriter json)
        {
            if (Enabled.HasValue)
            {
                json.WriteBoolean(s_enabledPropertyNameBytes, Enabled.Value);
            }
        }
    }
}
