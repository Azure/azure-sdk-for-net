// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Properties of a key backing a certificate managed by Azure Key vault
    /// </summary>
    public abstract class KeyOptions : IJsonSerializable, IJsonDeserializable
    {
        private const string KeyTypePropertyName = "kty";
        private const string ReuseKeyPropertyName = "reuse_key";
        private const string ExportablePropertyName = "exportable";

        private static readonly JsonEncodedText s_keyTypePropertyNameBytes = JsonEncodedText.Encode(KeyTypePropertyName);
        private static readonly JsonEncodedText s_reuseKeyPropertyNameBytes = JsonEncodedText.Encode(ReuseKeyPropertyName);
        private static readonly JsonEncodedText s_exportablePropertyNameBytes = JsonEncodedText.Encode(ExportablePropertyName);

        /// <summary>
        /// Creates key options for the specified type of key
        /// </summary>
        /// <param name="keyType">The type of backing key to be generated when issuing new certificates</param>
        protected KeyOptions(CertificateKeyType keyType)
        {
            KeyType = keyType;
        }

        /// <summary>
        /// The type of backing key to be generated when issuing new certificates
        /// </summary>
        public CertificateKeyType KeyType { get; private set; }

        /// <summary>
        /// Specifies whether the certificate key should be reused when rotating the certificate
        /// </summary>
        public bool? ReuseKey { get; set; }

        /// <summary>
        /// Specifies whether the certificate key is exportable from the vault or secure certificate store
        /// </summary>
        public bool? Exportable { get; set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            WriteProperties(json);
        }

        internal virtual void ReadProperty(JsonProperty prop)
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
            }
        }

        internal virtual void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(s_keyTypePropertyNameBytes, KeyType.ToString());

            if (ReuseKey.HasValue)
            {
                json.WriteBoolean(s_reuseKeyPropertyNameBytes, ReuseKey.Value);
            }

            if (Exportable.HasValue)
            {
                json.WriteBoolean(s_exportablePropertyNameBytes, Exportable.Value);
            }
        }

        internal static KeyOptions FromJsonObject(JsonElement json)
        {
            KeyOptions ret = null;

            string kty = json.GetProperty(KeyTypePropertyName).GetString();

            switch (kty)
            {
                case CertificateKeyType.EC_HSM_KTY:
                case CertificateKeyType.EC_KTY:
                    ret = new EcKeyOptions(kty);
                    break;
                case CertificateKeyType.RSA_HSM_KTY:
                case CertificateKeyType.RSA_KTY:
                    ret = new RsaKeyOptions(kty);
                    break;
            }

            if (ret != null)
            {
                ((IJsonDeserializable)ret).ReadProperties(json);
            }

            return ret;
        }
    }
}
