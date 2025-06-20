// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An Azure Key Vault certificate.
    /// </summary>
    public class KeyVaultCertificate : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string SecretIdPropertyName = "sid";
        private const string CERPropertyName = "cer";
        private const string PreserveCertificateOrderPropertyName = "preserveCertOrder";

        private string _keyId;
        private string _secretId;

        internal KeyVaultCertificate(CertificateProperties properties = null)
        {
            Properties = properties ?? new CertificateProperties();
        }

        /// <summary>
        /// Gets the identifier of the certificate.
        /// </summary>
        public Uri Id => Properties.Id;

        /// <summary>
        /// Gets the name of the certificate.
        /// </summary>
        public string Name => Properties.Name;

        /// <summary>
        /// Gets the identifier of the Key Vault Key backing the certificate.
        /// </summary>
        public Uri KeyId
        {
            get => new Uri(_keyId);
            internal set => _keyId = value?.AbsoluteUri;
        }

        /// <summary>
        /// Gets the identifier of the Key Vault Secret which contains the PEM of PFX formatted content of the certificate and its private key.
        /// </summary>
        public Uri SecretId
        {
            get => new Uri(_secretId);
            internal set => _secretId = value?.AbsoluteUri;
        }

        /// <summary>
        /// Gets additional properties of the <see cref="KeyVaultCertificate"/>.
        /// </summary>
        public CertificateProperties Properties { get; }

        /// <summary>
        /// Gets the CER formatted public X509 certificate.
        /// </summary>
        /// <remarks>
        /// This property contains only the public key.
        /// If you must retrieve the key pair including the private key instead of performing cryptographic operations in Azure Key Vault, see the sample:
        /// <see href="https://docs.microsoft.com/samples/azure/azure-sdk-for-net/get-certificate-private-key"/>
        /// </remarks>
        public byte[] Cer { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the certificate chain preserves its original order.
        /// The default value is false, which sets the leaf certificate at index 0.
        /// </summary>
        public bool? PreserveCertificateOrder { get; internal set; }

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

                case CERPropertyName:
                    Cer = prop.Value.GetBytesFromBase64();
                    break;

                case PreserveCertificateOrderPropertyName:
                    PreserveCertificateOrder = prop.Value.GetBoolean();
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
