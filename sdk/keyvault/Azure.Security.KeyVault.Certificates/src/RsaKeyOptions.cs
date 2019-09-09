// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class RsaKeyOptions : KeyOptions
    {
        private const string KeySizePropertyName = "key_size";
        private static readonly JsonEncodedText KeySizePropertyNameBytes = JsonEncodedText.Encode(KeySizePropertyName);

        public int? KeySize { get; set; }

        public RsaKeyOptions(bool hsm)
            : base(hsm ? CertificateKeyType.RsaHsm : CertificateKeyType.Rsa)
        {
        }

        internal RsaKeyOptions(CertificateKeyType keyType)
            : base(keyType)
        {

        }

        internal override bool ReadProperty(JsonProperty prop)
        {
            if(!base.ReadProperty(prop) && string.CompareOrdinal(prop.Name, KeySizePropertyName) == 0)
            {
                KeySize = prop.Value.GetInt32();

                return true;
            }

            return false;
        }

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            base.WriteProperties(json);

            if (KeySize.HasValue)
            {
                json.WriteNumber(KeySizePropertyNameBytes, KeySize.Value);
            }
        }
    }
}
