// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Elliptic Curve Cryptography (ECC) curve names.
    /// </summary>
    public struct KeyCurveName
    {
        private readonly string _value;

        public KeyCurveName(string curveName)
        {
            _value = curveName;
        }

        public static readonly KeyCurveName P256 = new KeyCurveName("P-256");

        public static readonly KeyCurveName P384 = new KeyCurveName("P-384");

        public static readonly KeyCurveName P521 = new KeyCurveName("P-521");

        public static readonly KeyCurveName P256K = new KeyCurveName("P-256K");

        public override bool Equals(object obj)
        {
            return obj is KeyCurveName && string.CompareOrdinal(_value, ((KeyCurveName)obj)._value) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
        }

        public static bool operator ==(KeyCurveName a, KeyCurveName b) => a.Equals(b);

        public static bool operator !=(KeyCurveName a, KeyCurveName b) => !a.Equals(b);

        public static implicit operator KeyCurveName(string value) => new KeyCurveName(value);

        public static implicit operator string(KeyCurveName o) => o._value;

    }
}
