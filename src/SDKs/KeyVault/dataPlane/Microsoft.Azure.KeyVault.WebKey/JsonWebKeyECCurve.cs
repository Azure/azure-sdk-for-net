
using System.Security.Cryptography;
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// The curve for Elliptic Curve Cryptography (ECC) algorithms.
    /// </summary>
    public static class JsonWebKeyECCurve
    {
        public const string P256 = "P-256";
        public const string P384 = "P-384";
        public const string P521 = "P-521";

        private static Dictionary<string, CngAlgorithm> cngAlgorithms;

        static JsonWebKeyECCurve()
        {
            cngAlgorithms = new Dictionary<string, CngAlgorithm>()
            {
                { P256, CngAlgorithm.ECDsaP256 },
                { P384, CngAlgorithm.ECDsaP384 },
                { P521, CngAlgorithm.ECDsaP521 }
            };
        }

        public static CngAlgorithm GetECDsaCngAlgorithm(string curve)
        {
            if (!cngAlgorithms.ContainsKey(curve))
                throw new CryptographicException(string.Format("Unknown curve {0}", curve));
            return cngAlgorithms[curve];
        }

        /// <summary>
        /// All curves for EC. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllCurves => (string[])_allCurves.Clone();

        private static readonly string[] _allCurves = { P256, P384, P521 };
    }
}
