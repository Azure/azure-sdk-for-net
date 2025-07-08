// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal struct KeyAttributes
    {
        private const string EnabledPropertyName = "enabled";
        private const string NotBeforePropertyName = "nbf";
        private const string ExpiresPropertyName = "exp";
        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";
        private const string RecoverableDaysPropertyName = "recoverableDays";
        private const string RecoveryLevelPropertyName = "recoveryLevel";
        private const string ExportablePropertyName = "exportable";
        private const string HsmPlatformPropertyName = "hsmPlatform";
        private const string KeyAttestationPropertyName = "attestation";

        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private static readonly JsonEncodedText s_notBeforePropertyNameBytes = JsonEncodedText.Encode(NotBeforePropertyName);
        private static readonly JsonEncodedText s_expiresPropertyNameBytes = JsonEncodedText.Encode(ExpiresPropertyName);
        private static readonly JsonEncodedText s_exportablePropertyNameBytes = JsonEncodedText.Encode(ExportablePropertyName);
        private static readonly JsonEncodedText s_keyAttestationPropertyNameBytes = JsonEncodedText.Encode(KeyAttestationPropertyName);

        public bool? Enabled { get; set; }

        public DateTimeOffset? NotBefore { get; set; }

        public DateTimeOffset? ExpiresOn { get; set; }

        public bool? Exportable { get; set; }

        public DateTimeOffset? CreatedOn { get; internal set; }

        public DateTimeOffset? UpdatedOn { get; internal set; }

        public int? RecoverableDays { get; internal set; }

        public string RecoveryLevel { get; internal set; }

        public string HsmPlatform { get; internal set; }

        public KeyAttestation Attestation { get; set; }

        internal bool ShouldSerialize =>
            Enabled.HasValue ||
            NotBefore.HasValue ||
            ExpiresOn.HasValue ||
            Exportable.HasValue ||
            Attestation != null;

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case EnabledPropertyName:
                        Enabled = prop.Value.GetBoolean();
                        break;
                    case NotBeforePropertyName:
                        NotBefore = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case ExpiresPropertyName:
                        ExpiresOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case CreatedPropertyName:
                        CreatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case UpdatedPropertyName:
                        UpdatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case RecoverableDaysPropertyName:
                        RecoverableDays = prop.Value.GetInt32();
                        break;
                    case RecoveryLevelPropertyName:
                        RecoveryLevel = prop.Value.GetString();
                        break;
                    case ExportablePropertyName:
                        Exportable = prop.Value.GetBoolean();
                        break;
                    case HsmPlatformPropertyName:
                        HsmPlatform = prop.Value.GetString();
                        break;
                    case KeyAttestationPropertyName:
                        if (prop.Value.ValueKind == JsonValueKind.Null)
                        {
                            Attestation = null;
                        }
                        else
                        {
                            Attestation = new KeyAttestation();
                            // Read attestation properties
                            foreach (JsonProperty attestProp in prop.Value.EnumerateObject())
                            {
                                switch (attestProp.Name)
                                {
                                    case "cert":
                                        Attestation.CertificatePemFile = Convert.FromBase64String(attestProp.Value.GetString());
                                        break;
                                    case "priv":
                                        Attestation.PrivateKeyAttestation = Convert.FromBase64String(attestProp.Value.GetString());
                                        break;
                                    case "pub":
                                        Attestation.PublicKeyAttestation = Convert.FromBase64String(attestProp.Value.GetString());
                                        break;
                                    case "ver":
                                        Attestation.Version = attestProp.Value.GetString();
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (Enabled.HasValue)
            {
                json.WriteBoolean(s_enabledPropertyNameBytes, Enabled.Value);
            }

            if (NotBefore.HasValue)
            {
                json.WriteNumber(s_notBeforePropertyNameBytes, NotBefore.Value.ToUnixTimeSeconds());
            }

            if (ExpiresOn.HasValue)
            {
                json.WriteNumber(s_expiresPropertyNameBytes, ExpiresOn.Value.ToUnixTimeSeconds());
            }

            if (Exportable.HasValue)
            {
                json.WriteBoolean(s_exportablePropertyNameBytes, Exportable.Value);
            }

            if (Attestation != null)
            {
                json.WriteStartObject(s_keyAttestationPropertyNameBytes);
                if (!Attestation.CertificatePemFile.IsEmpty)
                {
                    json.WriteString("certificatePemFile", Convert.ToBase64String(Attestation.CertificatePemFile.ToArray()));
                }
                if (!Attestation.PrivateKeyAttestation.IsEmpty)
                {
                    json.WriteString("privateKeyAttestation", Convert.ToBase64String(Attestation.PrivateKeyAttestation.ToArray()));
                }
                if (!Attestation.PublicKeyAttestation.IsEmpty)
                {
                    json.WriteString("publicKeyAttestation", Convert.ToBase64String(Attestation.PublicKeyAttestation.ToArray()));
                }
                if (Attestation.Version != null)
                {
                    json.WriteString("version", Attestation.Version);
                }
                json.WriteEndObject();
            }

            // Created is read-only don't serialize
            // Updated is read-only don't serialize
            // RecoverableDays is read-only don't serialize
            // RecoveryLevel is read-only don't serialize
            // HsmPlatform is read-only don't serialize
        }
    }
}
