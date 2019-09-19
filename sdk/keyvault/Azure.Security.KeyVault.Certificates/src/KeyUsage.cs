// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{

    /// <summary>
    /// Supported usages of a certificate key
    /// </summary>
    public struct KeyUsage
    {
        private readonly string _value;
        internal const string DigitalSignatureValue = "digitalSignature";
        internal const string NonRepudiationValue = "nonRepudiation";
        internal const string KeyEnciphermentValue = "keyEncipherment";
        internal const string DataEnciphermentValue = "dataEncipherment";
        internal const string KeyAgreementValue = "keyAgreement";
        internal const string KeyCertSignValue = "keyCertSign";
        internal const string CrlSignValue = "crlSign";
        internal const string EncipherOnlyValue = "encipherOnly";
        internal const string DecipherOnlyValue = "decipherOnly";

        /// <summary>
        /// Creates a new KeyUsage with the specified value
        /// </summary>
        /// <param name="KeyUsage">The string value of the KeyUsage</param>
        public KeyUsage(string KeyUsage)
        {
            _value = KeyUsage;
        }

        /// <summary>
        /// The certificate key can be used as a digital signatures
        /// </summary>
        public static readonly KeyUsage DigitalSignature = new KeyUsage(DigitalSignatureValue);

        /// <summary>
        /// The certificate key can be used for authentication
        /// </summary>
        public static readonly KeyUsage NonRepudiation = new KeyUsage(NonRepudiationValue);

        /// <summary>
        /// The certificate key can be used for key encryption
        /// </summary>
        public static readonly KeyUsage KeyEncipherment = new KeyUsage(KeyEnciphermentValue);

        /// <summary>
        /// The certificate key can be used for data encryption
        /// </summary>
        public static readonly KeyUsage DataEncipherment = new KeyUsage(DataEnciphermentValue);

        /// <summary>
        /// The certificate key can be used to determine key agreement, such as a key created using the Diffie-Hellman key agreement algorithm.
        /// </summary>
        public static readonly KeyUsage KeyAgreement = new KeyUsage(KeyAgreementValue);

        /// <summary>
        /// The certificate key can be used to sign certificates
        /// </summary>
        public static readonly KeyUsage KeyCertSign = new KeyUsage(KeyCertSignValue);

        /// <summary>
        /// The certificate key can be used to sign a certificate revocation list
        /// </summary>
        public static readonly KeyUsage CrlSign = new KeyUsage(CrlSignValue);

        /// <summary>
        /// The certificate key can be used for encryption only
        /// </summary>
        public static readonly KeyUsage EncipherOnly = new KeyUsage(EncipherOnlyValue);

        /// <summary>
        /// The certificate key can be used for decryption only
        /// </summary>
        public static readonly KeyUsage DecipherOnly = new KeyUsage(DecipherOnlyValue);

        public override bool Equals(object obj)
        {
            return obj is KeyUsage && Equals((KeyUsage)obj);
        }

        public bool Equals(KeyUsage other)
        {
            return string.CompareOrdinal(_value, other._value) == 0;
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return _value;
        }

        public static bool operator ==(KeyUsage a, KeyUsage b) => a.Equals(b);

        public static bool operator !=(KeyUsage a, KeyUsage b) => !a.Equals(b);

        public static implicit operator KeyUsage(string value) => new KeyUsage(value);

        public static implicit operator string(KeyUsage o) => o._value;
    }
}
