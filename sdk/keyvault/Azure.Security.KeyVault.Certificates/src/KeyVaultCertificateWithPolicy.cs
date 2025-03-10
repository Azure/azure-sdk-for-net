// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A <see cref="KeyVaultCertificate"/> along with its <see cref="CertificatePolicy"/>.
    /// </summary>
    public class KeyVaultCertificateWithPolicy : KeyVaultCertificate
    {
        private const string PolicyPropertyName = "policy";
        private const string PreserveCertOrderPropertyName = "preserveCertOrder";

        internal KeyVaultCertificateWithPolicy(CertificateProperties properties = null) : base(properties)
        {
        }

        /// <summary>
        /// Gets the current policy for the certificate.
        /// </summary>
        public CertificatePolicy Policy { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the certificate chain preserves its original order.
        /// The default value is false, which sets the leaf certificate at index 0.
        /// </summary>
        public bool? PreserveCertOrder { get; internal set; }

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case PolicyPropertyName:
                    Policy = new CertificatePolicy();
                    ((IJsonDeserializable)Policy).ReadProperties(prop.Value);
                    break;

                case PreserveCertOrderPropertyName:
                    PreserveCertOrder = prop.Value.GetBoolean();
                    break;

                default:
                    base.ReadProperty(prop);
                    break;
            }
        }
    }
}
