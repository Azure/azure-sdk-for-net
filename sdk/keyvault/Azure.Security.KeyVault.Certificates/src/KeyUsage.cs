// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{

    //public enum KeyUsage
    //{
    //    DigitalSignature,
    //    NonRepudiation,
    //    KeyEncipherment,
    //    DataEncipherment,
    //    KeyAgreement,
    //    KeyCertSign,
    //    CrlSign,
    //    EncipherOnly,
    //    DecipherOnly,
    //}
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public struct KeyUsage
    {
        private string _value;
        internal const string DigitalSignatureValue = "digitalSignature";
        internal const string NonRepudiationValue = "nonRepudiation";
        internal const string KeyEnciphermentValue = "keyEncipherment";
        internal const string DataEnciphermentValue = "dataEncipherment";
        internal const string KeyAgreementValue = "keyAgreement";
        internal const string KeyCertSignValue = "keyCertSign";
        internal const string CrlSignValue = "crlSign";
        internal const string EncipherOnlyValue = "encipherOnly";
        internal const string DecipherOnlyValue = "decipherOnly";

        public KeyUsage(string KeyUsage)
        {
            _value = KeyUsage;
        }

        public static readonly KeyUsage DigitalSignature = new KeyUsage(DigitalSignatureValue);

        public static readonly KeyUsage NonRepudiation = new KeyUsage(NonRepudiationValue);

        public static readonly KeyUsage KeyEncipherment = new KeyUsage(KeyEnciphermentValue);

        public static readonly KeyUsage DataEncipherment = new KeyUsage(DataEnciphermentValue);

        public static readonly KeyUsage KeyAgreement = new KeyUsage(KeyAgreementValue);

        public static readonly KeyUsage KeyCertSign = new KeyUsage(KeyCertSignValue);

        public static readonly KeyUsage CrlSign = new KeyUsage(CrlSignValue);

        public static readonly KeyUsage EncipherOnly = new KeyUsage(EncipherOnlyValue);

        public static readonly KeyUsage DecipherOnly = new KeyUsage(DecipherOnlyValue);

        public override bool Equals(object obj)
        {
            return obj is KeyUsage && this.Equals((KeyUsage)obj);
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
