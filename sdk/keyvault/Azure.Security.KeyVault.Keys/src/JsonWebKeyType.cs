using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public struct JsonWebKeyType
    {
        public const string EllipticCurve = "EC";
        public const string EllipticCurveHsm  = "EC-HSM";
        public const string Rsa  = "RSA";
        public const string RsaHsm= "RSA-HSM";
        public const string Octet  = "oct";

        public static IReadOnlyList<string> AllTypes => _allTypes;

        private static readonly string[] _allTypes = { EllipticCurve, EllipticCurveHsm, Rsa, RsaHsm, Octet };
    }
}
