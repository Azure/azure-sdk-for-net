// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An Azure Key Vault certificate.
    /// </summary>
    public class Certificate : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string SecretIdPropertyName = "sid";
        private const string ContentTypePropertyName = "contentType";
        private const string CERPropertyName = "cer";

        private string _keyId;
        private string _secretId;

        /// <summary>
        /// The Id of the certificate.
        /// </summary>
        public Uri Id => Properties.Id;

        /// <summary>
        /// The name of the certificate.
        /// </summary>
        public string Name => Properties.Name;

        /// <summary>
        /// The Id of the Key Vault Key backing the certifcate.
        /// </summary>
        public Uri KeyId => new Uri(_keyId);

        /// <summary>
        /// The Id of the Key Vault Secret which contains the PEM of PFX formatted content of the certficate and it's private key.
        /// </summary>
        public Uri SecretId => new Uri(_secretId);

        /// <summary>
        /// The content type of the key vault Secret corresponding to the certificate.
        /// </summary>
        public CertificateContentType ContentType { get; private set; }

        /// <summary>
        /// Additional properties of the <see cref="Certificate"/>.
        /// </summary>
        public CertificateProperties Properties { get; } = new CertificateProperties();

        /// <summary>
        /// The CER formatted public X509 certificate
        /// </summary>
        public byte[] CER { get; private set; }

        internal virtual void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case KeyIdPropertyName:
                    _keyId = prop.Value.GetString();
                    break;

                case SecretIdPropertyName:
                    _secretId = prop.Value.GetString();
                    break;

                case ContentTypePropertyName:
                    ContentType = prop.Value.GetString();
                    break;

                case CERPropertyName:
                    CER = Base64Url.Decode(prop.Value.GetString());
                    break;

                default:
                    Properties.ReadProperty(prop);
                    break;
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }
    }
}
