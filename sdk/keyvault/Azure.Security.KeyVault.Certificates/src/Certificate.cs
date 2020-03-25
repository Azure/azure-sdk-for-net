// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An Azure Key Vault certificate
    /// </summary>
    public class Certificate : CertificateBase
    {
        /// <summary>
        /// The id of the key vault Key backing the certifcate
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// The id of the key vault Secret which contains the PEM of PFX formatted content of the certficate and it's private key
        /// </summary>
        public string SecretId { get; private set; }

        /// <summary>
        /// The content type of the key vault Secret corresponding to the certificate
        /// </summary>
        public CertificateContentType ContentType { get; private set; }

        /// <summary>
        /// The CER formatted public X509 certificate
        /// </summary>
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
