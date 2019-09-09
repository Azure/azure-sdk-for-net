// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Security.Cryptography;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{

    public abstract class KeyOptions : IJsonSerializable, IJsonDeserializable
    {
        private const string KeyTypePropertyName = "kty";
        private static readonly JsonEncodedText KeyTypePropertyNameBytes = JsonEncodedText.Encode(KeyTypePropertyName);
        private const string ReuseKeyPropertyName = "reuse_key";
        private static readonly JsonEncodedText ReuseKeyPropertyNameBytes = JsonEncodedText.Encode(ReuseKeyPropertyName);
        private const string ExportablePropertyName = "exportable";
        private static readonly JsonEncodedText ExportablePropertyNameBytes = JsonEncodedText.Encode(ExportablePropertyName);

        protected KeyOptions(CertificateKeyType keyType)
        {
            this.KeyType = keyType;
        }

        public CertificateKeyType KeyType { get; private set; }

        public bool? ReuseKey { get; set; }

        public bool? Exportable { get; set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                this.ReadProperty(prop);
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            this.WriteProperties(json);
        }

        internal virtual bool ReadProperty(JsonProperty prop)
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
                default:
                    return false;
            }

            return true;
        }

        internal virtual void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(KeyTypePropertyNameBytes, KeyType);

            if (ReuseKey.HasValue)
            {
                json.WriteBoolean(ReuseKeyPropertyNameBytes, ReuseKey.Value);
            }

            if (Exportable.HasValue)
            {
                json.WriteBoolean(ExportablePropertyNameBytes, Exportable.Value);
            }
        }

        internal static KeyOptions FromJsonObject(JsonElement json)
        {
            KeyOptions ret = null;

            string kty = json.GetProperty(KeyTypePropertyName).GetString();

            switch(kty)
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

            if(ret != null)
            {
                ((IJsonDeserializable)ret).ReadProperties(json);
            }

            return ret;
        }
    }
}
