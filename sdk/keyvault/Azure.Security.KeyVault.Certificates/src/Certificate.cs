// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateWithPolicy : Certificate
    {
        public CertificatePolicy Policy { get; private set; }

        private const string PolicyPropertyName = "policy";

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case PolicyPropertyName:
                    Policy = new CertificatePolicy();
                    ((IJsonDeserializable)Policy).ReadProperties(prop.Value);
                    break;
                default:
                    base.ReadProperty(prop);
                    break;
            }
        }
    }

    public class Certificate : CertificateBase
    {
        public string KeyId { get; private set; }

        public string SecretId { get; private set; }

        public CertificateContentType ContentType { get; private set; }

        public byte[] CER { get; private set; }

        private const string KeyIdPropertyName = "kid";
        private const string SecretIdPropertyName = "sid";
        private const string ContentTypePropertyName = "contentType";
        private const string CERPropertyName = "cer";

        internal override void ReadProperty(JsonProperty prop)
        {
            switch(prop.Name)
            {
                case KeyIdPropertyName:
                    KeyId = prop.Value.GetString();
                    break;
                case SecretIdPropertyName:
                    SecretId = prop.Value.GetString();
                    break;
                case ContentTypePropertyName:
                    ContentType = prop.Value.GetString();
                    break;
                case CERPropertyName:
                    CER = Base64Url.Decode(prop.Value.GetString());
                    break;
                default:
                    base.ReadProperty(prop);
                    break;
            }
        }
    }
}
