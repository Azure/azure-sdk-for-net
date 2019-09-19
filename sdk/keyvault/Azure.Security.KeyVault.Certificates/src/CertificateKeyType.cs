// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public struct CertificateKeyType
    {
        private readonly string _value;
        internal const string EC_KTY = "EC";
        internal const string EC_HSM_KTY = "EC-HSM";
        internal const string RSA_KTY = "RSA";
        internal const string RSA_HSM_KTY = "RSA-HSM";
        internal const string OCT_KTY = "oct";

        /// <summary>
        /// Creats a CertificateKeyType with the specified value
        /// </summary>
        /// <param name="keyType"></param>
        public CertificateKeyType(string keyType)
        {
            _value = keyType;
        }

        /// <summary>
        /// An EC (EllipticCurve) key
        /// </summary>
        public static readonly CertificateKeyType EllipticCurve = new CertificateKeyType(EC_KTY);

        /// <summary>
        /// An HSM protected EC (EllipticCurve) key
        /// </summary>
        public static readonly CertificateKeyType EllipticCurveHsm = new CertificateKeyType(EC_HSM_KTY);

        /// <summary>
        /// A RSA key
        /// </summary>
        public static readonly CertificateKeyType Rsa = new CertificateKeyType(RSA_KTY);

        /// <summary>
        /// An HSM protected RSA key
        /// </summary>
        public static readonly CertificateKeyType RsaHsm = new CertificateKeyType(RSA_HSM_KTY);

        /// <summary>
        /// A octal (Symmetric) key
        /// </summary>
        public static readonly CertificateKeyType Oct = new CertificateKeyType(OCT_KTY);

        public override bool Equals(object obj)
        {
            return obj is CertificateKeyType && Equals((CertificateKeyType)obj);
        }

        public bool Equals(CertificateKeyType other)
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

        public static bool operator ==(CertificateKeyType a, CertificateKeyType b) => a.Equals(b);

        public static bool operator !=(CertificateKeyType a, CertificateKeyType b) => !a.Equals(b);

        public static implicit operator CertificateKeyType(string value) => new CertificateKeyType(value);

        public static implicit operator string(CertificateKeyType o) => o._value;
    }
}
