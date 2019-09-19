using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Content type of the certificate when downloaded from getSecret.
    /// </summary>
    public struct CertificateContentType
    {
        private readonly string _value;

        public CertificateContentType(string curveName)
        {
            _value = curveName;
        }

        /// <summary>
        /// Content is downloaded in pkcs12 (PFX) format
        /// </summary>
        public static readonly CertificateContentType Pkcs12 = new CertificateContentType("application/x-pkcs12");

        /// <summary>
        /// Content is downloaded in PEM format
        /// </summary>
        public static readonly CertificateContentType Pem = new CertificateContentType("application/x-pem");

        public override bool Equals(object obj)
        {
            return obj is CertificateContentType && Equals((CertificateContentType)obj);
        }

        public bool Equals(CertificateContentType other)
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

        public static bool operator ==(CertificateContentType a, CertificateContentType b) => a.Equals(b);

        public static bool operator !=(CertificateContentType a, CertificateContentType b) => !a.Equals(b);

        public static implicit operator CertificateContentType(string value) => new CertificateContentType(value);

        public static implicit operator string(CertificateContentType o) => o._value;

    }
}
