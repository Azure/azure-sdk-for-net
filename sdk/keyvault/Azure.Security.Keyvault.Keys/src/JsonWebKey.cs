using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public class JsonWebKey
    {
        /// <summary>
        /// Key Identifier
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// Gets or sets supported JsonWebKey key types (kty) for Elliptic
        /// Curve, RSA, HSM, Octet, usually RSA. Possible values include:
        /// 'EC', 'RSA', 'RSA-HSM', 'oct'
        /// </summary>
        public string KeyType { get; set; }

        /// <summary>
        /// Supported Key Operations
        /// </summary>
        public IList<string> KeyOps { get; set; }

        #region RSA Public Key Parameters

        /// <summary>
        /// RSA modulus, in Base64.
        /// </summary>
        public byte[] N { get; set; }

        /// <summary>
        /// RSA public exponent, in Base64.
        /// </summary>
        public byte[] E { get; set; }

        #endregion

        #region RSA Private Key Parameters

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        public byte[] DP { get; set; }

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        public byte[] DQ { get; set; }

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        public byte[] QI { get; set; }

        /// <summary>
        /// RSA secret prime
        /// </summary>
        public byte[] P { get; set; }

        /// <summary>
        /// RSA secret prime, with p &lt; q
        /// </summary>
        public byte[] Q { get; set; }

        #endregion

        #region EC Public Key Parameters

        /// <summary>
        /// The curve for Elliptic Curve Cryptography (ECC) algorithms
        /// </summary>
        public string CurveName { get; set; }

        /// <summary>
        /// X coordinate for the Elliptic Curve point.
        /// </summary>
        public byte[] X { get; set; }

        /// <summary>
        /// Y coordinate for the Elliptic Curve point.
        /// </summary>
        public byte[] Y { get; set; }

        #endregion

        #region EC and RSA Private Key Parameters

        /// <summary>
        /// RSA private exponent or ECC private key.
        /// </summary>
        public byte[] D { get; set; }

        #endregion

        #region Symmetric Key Parameters

        /// <summary>
        /// Symmetric key
        /// </summary>
        public byte[] K { get; set; }

        #endregion

        /// <summary>
        /// HSM Token, used with "Bring Your Own Key"
        /// </summary>
        public byte[] T { get; set; }
    }
}

