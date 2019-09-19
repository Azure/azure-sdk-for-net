// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Propeties of an RSA key backing a certificate
    /// </summary>
    public class RsaKeyOptions : KeyOptions
    {
        private const string KeySizePropertyName = "key_size";
        private static readonly JsonEncodedText s_keySizePropertyNameBytes = JsonEncodedText.Encode(KeySizePropertyName);

        /// <summary>
        /// The size of the RSA key, the value must be a valid RSA key length such as 2048 or 4092
        /// </summary>
        public int? KeySize { get; set; }

        /// <summary>
        /// Create RsaKeyOptions specifying whether the certificate key should be stored in the HSM
        /// </summary>
        /// <param name="hsm">Specifies whether the certificate key should be stored in the HSM</param>
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
            if (!base.ReadProperty(prop) && string.CompareOrdinal(prop.Name, KeySizePropertyName) == 0)
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
                json.WriteNumber(s_keySizePropertyNameBytes, KeySize.Value);
            }
        }
    }
}
