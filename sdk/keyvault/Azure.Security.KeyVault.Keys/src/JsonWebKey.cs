// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public class JsonWebKey : Model
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
        public KeyType KeyType { get; set; }

        /// <summary>
        /// Supported Key Operations
        /// </summary>
        public IList<KeyOperations> KeyOps { get; set; }

        public JsonWebKey()
        {
            KeyOps = new List<KeyOperations>();
        }

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

        internal override void ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty("kid", out JsonElement kid))
            {
                KeyId = kid.GetString();
            }
            if (json.TryGetProperty("kty", out JsonElement kty))
            {
                KeyType = KeyTypeExtensions.ParseFromString(kty.GetString());
            }
            if (json.TryGetProperty("key_ops", out JsonElement key_ops))
            {
                foreach (var element in key_ops.EnumerateObject())
                {
                    KeyOps.Add(KeyOperationsExtensions.ParseFromString(element.Value.ToString()));
                }
            }
            if (json.TryGetProperty("curveName", out JsonElement curveName))
            {
                CurveName = curveName.GetString();
            }
            if (json.TryGetProperty("n", out JsonElement n))
            {
                N = Encoding.ASCII.GetBytes(n.GetString());
            }
            if (json.TryGetProperty("e", out JsonElement e))
            {
                E = Encoding.ASCII.GetBytes(e.GetString());
            }
            if (json.TryGetProperty("dp", out JsonElement dp))
            {
                DP = Encoding.ASCII.GetBytes(dp.GetString());
            }
            if (json.TryGetProperty("dq", out JsonElement dq))
            {
                DQ = Encoding.ASCII.GetBytes(dq.GetString());
            }
            if (json.TryGetProperty("qi", out JsonElement qi))
            {
                QI = Encoding.ASCII.GetBytes(qi.GetString());
            }
            if (json.TryGetProperty("p", out JsonElement p))
            {
                P = Encoding.ASCII.GetBytes(p.GetString());
            }
            if (json.TryGetProperty("q", out JsonElement q))
            {
                Q = Encoding.ASCII.GetBytes(q.GetString());
            }
            if (json.TryGetProperty("x", out JsonElement x))
            {
                X = Encoding.ASCII.GetBytes(x.GetString());
            }
            if (json.TryGetProperty("y", out JsonElement y))
            {
                Y = Encoding.ASCII.GetBytes(y.GetString());
            }
            if (json.TryGetProperty("d", out JsonElement d))
            {
                D = Encoding.ASCII.GetBytes(d.GetString());
            }
            if (json.TryGetProperty("k", out JsonElement k))
            {
                K = Encoding.ASCII.GetBytes(k.GetString());
            }
            if (json.TryGetProperty("t", out JsonElement t))
            {
                T = Encoding.ASCII.GetBytes(t.GetString());
            }
        }

        internal override void WriteProperties(ref Utf8JsonWriter json) { }

        public bool Equals(JsonWebKey other)
        {
            if (other == this)
                return true;

            if (other == null)
                return false;

            if (!string.Equals(KeyId, other.KeyId))
                return false;

            if (!string.Equals(KeyType, other.KeyType))
                return false;

            if (KeyOps != other.KeyOps)
                return false;

            if (!string.Equals(CurveName, other.CurveName))
                return false;

            if (!AreEqual(K, other.K))
                return false;

            // Public parameters
            if (!AreEqual(N, other.N))
                return false;

            if (!AreEqual(E, other.E))
                return false;

            if (!AreEqual(X, other.X))
                return false;

            if (!AreEqual(Y, other.Y))
                return false;

            // Private parameters
            if (!AreEqual(D, other.D))
                return false;

            if (!AreEqual(DP, other.DP))
                return false;

            if (!AreEqual(DQ, other.DQ))
                return false;

            if (!AreEqual(QI, other.QI))
                return false;

            if (!AreEqual(P, other.P))
                return false;

            if (!AreEqual(Q, other.Q))
                return false;

            // HSM token
            if (!AreEqual(T, other.T))
                return false;

            return true;
        }

        private static bool AreEqual(byte[] a, byte[] b)
        {
            if (a == b)
                return true;

            if (a == null)
                // b can't be null because otherwise we would return true above.
                return b.Length == 0;

            if (b == null)
                // Likewise, a can't be null.
                return a.Length == 0;

            if (a.Length != b.Length)
                return false;

            for (var i = 0; i < a.Length; ++i)
                if (a[i] != b[i])
                    return false;

            return true;
        }

        private static bool AreEqual(IList<string> a, IList<string> b)
        {
            if (a == b)
                return true;

            if ((a == null) != (b == null))
                return false;

            if (a.Count != b.Count)
                return false;

            for (var i = 0; i < a.Count; ++i)
                if (a[i] != b[i])
                    return false;

            return true;
        }

    }
}

