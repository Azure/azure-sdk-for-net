// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// As of http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18
    /// </summary>
    [JsonObject]
    public class JsonWebKey
    {
        // DataContract property names
        internal const string Property_Kid    = "kid";
        internal const string Property_Kty    = "kty";
        internal const string Property_KeyOps = "key_ops";

        // RSA Key Property Names
        internal const string Property_D  = "d";
        internal const string Property_DP = "dp";
        internal const string Property_DQ = "dq";
        internal const string Property_E  = "e";
        internal const string Property_QI = "qi";
        internal const string Property_N  = "n";
        internal const string Property_P  = "p";
        internal const string Property_Q  = "q";

        // Symmetric Key Property Names
        internal const string Property_K  = "k";

        // HSM Token Property Names
        internal const string Property_T  = "key_hsm";

        /// <summary>
        /// Key Identifier
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_Kid, Required = Required.Default )]
        public string Kid { get; set; }

        /// <summary>
        /// Gets or sets supported JsonWebKey key types (kty) for Elliptic
        /// Curve, RSA, HSM, Octet, usually RSA. Possible values include:
        /// 'EC', 'RSA', 'RSA-HSM', 'oct'
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_Kty, Required = Required.Always )]
        public string Kty { get; set; }

        /// <summary>
        /// Supported Key Operations
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_KeyOps, Required = Required.Default )]
        public IList<string> KeyOps { get; set; }

        #region RSA Public Key Parameters

        /// <summary>
        /// RSA modulus, in Base64.
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_N, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] N { get; set; }

        /// <summary>
        /// RSA public exponent, in Base64.
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_E, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] E { get; set; }

        #endregion

        #region RSA Private Key Parameters

        /// <summary>
        /// RSA private exponent
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_D, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] D { get; set; }

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_DP, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] DP { get; set; }

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_DQ, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] DQ { get; set; }

        /// <summary>
        /// RSA Private Key Parameter
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_QI, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] QI { get; set; }

        /// <summary>
        /// RSA secret prime
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_P, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] P { get; set; }

        /// <summary>
        /// RSA secret prime, with p &lt; q
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_Q, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] Q { get; set; }

        #endregion


        #region Symmetric Key Parameters

        /// <summary>
        /// Symmetric key
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_K, Required = Required.Default)]
        [JsonConverter(typeof( Base64UrlJsonConverter ))]
        public byte[] K { get; set; }

        #endregion

        /// <summary>
        /// HSM Token, used with "Bring Your Own Key"
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_T, Required = Required.Default)]
        [JsonConverter(typeof( Base64UrlJsonConverter ))]
        public byte[] T { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="JsonWebKey"/>
        /// </summary>
        [JsonConstructor]
        public JsonWebKey()
        {
            // Intentionally empty
        }

        /// <summary>
        /// Converts an AES object to a WebKey of type Octet
        /// </summary>
        /// <param name="aesProvider"></param>
        /// <returns></returns>
        public JsonWebKey(Aes aesProvider)
        {
            if (aesProvider == null)
                throw new ArgumentNullException("aesProvider");

            Kty = JsonWebKeyType.Octet;
            K = aesProvider.Key;
        }

        /// <summary>
        /// Converts a RSA object to a WebKey of type RSA.
        /// </summary>
        /// <param name="rsaProvider">The RSA object to convert</param>
        /// <param name="includePrivateParameters">True to include the RSA private key parameters</param>
        /// <returns>A WebKey representing the RSA object</returns>
        public JsonWebKey(RSA rsaProvider, bool includePrivateParameters = false) : this(rsaProvider.ExportParameters(includePrivateParameters))
        {
        }

        /// <summary>
        /// Converts a RSAParameters object to a WebKey of type RSA.
        /// </summary>
        /// <param name="rsaParameters">The RSA object to convert</param>
        /// <returns>A WebKey representing the RSA object</returns>
        public JsonWebKey(RSAParameters rsaParameters)
        {
            Kty = JsonWebKeyType.Rsa;

            E = rsaParameters.Exponent;
            N = rsaParameters.Modulus;

            D = rsaParameters.D;
            DP = rsaParameters.DP;
            DQ = rsaParameters.DQ;
            QI = rsaParameters.InverseQ;
            P = rsaParameters.P;
            Q = rsaParameters.Q;
        }

        public override bool Equals( object obj )
        {
            if ( obj == null )
                return false;

            if (obj == this)
                return true;

            JsonWebKey other = obj as JsonWebKey;

            if ( other == null )
                return false;

            return this.Equals( other );
        }

        /// <summary>
        /// Compares <see cref="JsonWebKey"/> objects
        /// </summary>
        /// <param name="other"> the <see cref="JsonWebKey"/> object to compare with </param>
        /// <returns> whether the <see cref="JsonWebKey"/> objects are equals </returns>
        public bool Equals( JsonWebKey other )
        {
            if ( other == null )
                return false;

            if (!string.Equals(Kid, other.Kid))
                return false;

            if (!string.Equals(Kty, other.Kty))
                return false;

            if (!AreEqual(KeyOps, other.KeyOps))
                return false;

            if (!AreEqual(K, other.K))
                return false;

            // Public parameters
            if (!AreEqual(N, other.N))
                return false;

            if (!AreEqual(E, other.E))
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

        private bool AreEqual<T>(IList<T> item1, IList<T> item2)
        {
            return item1 == item2 || item1 == null ? item2 == null : item1.SequenceEqual(item2);
        }

        public override int GetHashCode()
        {
            var hashCode = 48313; // setting it to a random prime number

            if (Kid != null)
            {
                hashCode += Kid.GetHashCode();
            }

            switch ( Kty )
            {
                case JsonWebKeyType.Octet:
                    return hashCode += GetHashCode( K );

                case JsonWebKeyType.Rsa:
                    return hashCode += GetHashCode( N );

                case JsonWebKeyType.RsaHsm:
                    return hashCode += GetHashCode( T );

                default:
                    return hashCode;
            }
        }


        private int GetHashCode( byte[] obj )
        {
            if ( obj == null || obj.Length == 0 )
                return 0;

            var hashCode = 0;

            // Rotate by 3 bits and XOR the new value.
            for ( var i = 0; i < obj.Length; i++ )
                hashCode = ( hashCode << 3 ) | ( hashCode >> ( 29 ) ) ^ obj[i];
            
            return hashCode;
        }

        /// <summary>
        /// Verifies whether this object has a private key
        /// </summary>
        /// <returns> True if the object has private key; false otherwise.</returns>
        public virtual bool HasPrivateKey()
        {
            switch ( Kty )
            {
                case JsonWebKeyType.Octet:
                    return K != null;

                case JsonWebKeyType.Rsa:
                case JsonWebKeyType.RsaHsm:
                    var privateParameters = new bool[] { D != null, DP != null, DQ != null, QI != null, P != null, Q != null };
                    return privateParameters.All( ( value ) => value );

                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines if the WebKey object is valid according to the rules for
        /// each of the possible WebKeyTypes. For more information, see WebKeyTypes.
        /// </summary>
        /// <returns>true if the WebKey is valid</returns>
        public virtual bool IsValid()
        {
            // MUST have kty
            if ( string.IsNullOrEmpty( Kty ) )
                return false;

            // Validate Key Operations
            if (KeyOps != null && KeyOps.Count != 0)
            {
                if (!KeyOps.All((op) => { return JsonWebKeyOperation.AllOperations.Contains(op); }))
                    return false;
            }

            // Per-kty validation
            switch ( Kty )
            {
                case JsonWebKeyType.EllipticCurve:
                    break;

                case JsonWebKeyType.Octet:
                    return IsValidOctet();

                case JsonWebKeyType.Rsa:
                    return IsValidRsa();

                case JsonWebKeyType.RsaHsm:
                    return IsValidRsaHsm();
            }

            return false;
        }

        private bool IsValidOctet()
        {
            if ( K != null )
                return true;

            return false;
        }

        private bool IsValidRsa()
        {
            // MUST have public key parameters
            if ( N == null || E == null )
                return false;

            // MAY have private key parameters, but only ALL or NONE
            var privateParameters = new bool[] { D != null, DP != null, DQ != null, QI != null, P != null, Q != null };

            if ( privateParameters.All( ( value ) => value ) || privateParameters.All( ( value ) => !value ) )
                return true;

            return false;
        }

        private bool IsValidRsaHsm()
        {
            // MAY have public key parameters
            if ( ( N == null && E != null ) || ( N != null && E == null ) )
                return false;

            // MUST NOT have private key parameters
            var privateParameters = new bool[] { D != null, DP != null, DQ != null, QI != null, P != null, Q != null };

            if ( privateParameters.Any( ( value ) => value ) )
                return false;

            // MUST have ( T || ( N && E ) )
            var tokenParameters  = T != null;
            var publicParameters = ( N != null && E != null );

            if ( tokenParameters && publicParameters )
                return false;

            return ( tokenParameters || publicParameters );
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            if (!IsValid())
                throw new JsonSerializationException("JsonWebKey is not valid");
        }

        /// <summary>
        /// Converts a WebKey of type Octet to an AES object.
        /// </summary>
        /// <returns>An AES object</returns>
        public Aes ToAes()
        {
            if (!Kty.Equals(JsonWebKeyType.Octet))
                throw new InvalidOperationException("key is not an octet key");

            if (K == null)
                throw new InvalidOperationException("key does not contain a value");

            Aes aesProvider = Aes.Create();

            if (aesProvider != null)
                aesProvider.Key = K;

            return aesProvider;
        }

        /// <summary>
        /// Remove leading zeros from all RSA parameters.
        /// </summary>
        public void CanonicalizeRSA()
        {
            N = RemoveLeadingZeros(N);
            E = RemoveLeadingZeros(E);
            D = RemoveLeadingZeros(D);
            DP = RemoveLeadingZeros(DP);
            DQ = RemoveLeadingZeros(DQ);
            QI = RemoveLeadingZeros(QI);
            P = RemoveLeadingZeros(P);
            Q = RemoveLeadingZeros(Q);
        }

        /// <summary>
        /// Converts a WebKey of type RSA or RSAHSM to a RSA object
        /// </summary>
        /// <param name="includePrivateParameters">Determines whether private key material, if available, is included</param>
        /// <returns>An initialized RSA instance</returns>
        public RSA ToRSA(bool includePrivateParameters = false)
        {
            var rsaParameters = ToRSAParameters(includePrivateParameters);
            var rsaProvider   = RSA.Create();

            rsaProvider.ImportParameters(rsaParameters);

            return rsaProvider;
        }

        /// <summary>
        /// Converts a WebKey of type RSA or RSAHSM to a RSA parameter object
        /// </summary>
        /// <param name="includePrivateParameters">Determines whether private key material, if available, is included</param>
        /// <returns>An RSA parameter</returns>
        public RSAParameters ToRSAParameters(bool includePrivateParameters = false)
        {
            if (!string.Equals(JsonWebKeyType.Rsa, Kty) && !string.Equals(JsonWebKeyType.RsaHsm, Kty))
                throw new ArgumentException("JsonWebKey is not a RSA key");

            VerifyNonZero("N", N);
            VerifyNonZero("E", E);

            // Length requirements defined by 2.2.2.9.1 RSA Private Key BLOB (https://msdn.microsoft.com/en-us/library/cc250013.aspx).
            // See KV bugs 190589 and 183469.

            var result = new RSAParameters();
            result.Modulus = RemoveLeadingZeros(N);
            result.Exponent = ForceLength("E", E, 4);

            if (includePrivateParameters)
            {
                var bitlen = result.Modulus.Length * 8;

                result.D = ForceLength("D", D, bitlen / 8);
                result.DP = ForceLength("DP", DP, bitlen / 16);
                result.DQ = ForceLength("DQ", DQ, bitlen / 16);
                result.InverseQ = ForceLength("IQ", QI, bitlen / 16);
                result.P = ForceLength("P", P, bitlen / 16);
                result.Q = ForceLength("Q", Q, bitlen / 16);
            };

            return result;
        }

        private static void VerifyNonZero(string name, byte[] value)
        {
            if (value != null && value.Length > 0)
            {
                for (var i = 0; i < value.Length; ++i)
                    if (value[i] != 0)
                        return;
            }

            throw new ArgumentException("Value of \"" + name + "\" must be non-zero.");
        }

        private static byte[] RemoveLeadingZeros(byte[] value)
        {
            // Do nothing if:
            // 1) value is null.
            // 2) value is empty.
            // 3) value has length of 1 (this is considered a useful zero).
            // 4) first byte is already non-zero (optimization).
            if (value == null || value.Length <= 1 || value[0] != 0)
                return value;

            // We know that value[0] is zero, so we start from 1.
            for (var i = 1; i < value.Length; ++i)
            {
                if (value[i] != 0)
                {
                    var result = new byte[value.Length - i];
                    Array.Copy(value, i, result, 0, result.Length);
                    return result;
                }
            }

            // If all is zero, return an array with a single useful zero.
            return new byte[] { 0 };
        }

        private static byte[] ForceLength(string name, byte[] value, int requiredLength)
        {

            if (value == null || value.Length == 0)
                throw new ArgumentException("Value of \"" + name + "\" is null or empty.");

            if (value.Length == requiredLength)
                return value;

            if (value.Length < requiredLength)
            {
                var padded = new byte[requiredLength];
                Array.Copy(value, 0, padded, requiredLength - value.Length, value.Length);
                return padded;
            }

            // value.Length > requiredLength

            // Make sure the extra bytes are all zeros.
            var extraLen = value.Length - requiredLength;
            for (var i = 0; i < extraLen; ++i)
                if (value[i] != 0)
                    throw new ArgumentException("Invalid length of \"" + name + "\": expected at most " +
                                                 requiredLength + " bytes, found " + (value.Length - i) + " bytes.");

            var trimmed = new byte[requiredLength];
            Array.Copy(value, value.Length - requiredLength, trimmed, 0, requiredLength);
            return trimmed;
        }
       
        public override string ToString()
        {
            return JsonConvert.SerializeObject( this );
        }

        /// <summary>
        /// Best effort to clear private key material 
        /// Not strong guarantee since GC may move the arrays during compact.
        /// </summary>
        public void ClearMemory()
        {
            // We ignore kty and clear everything.

            // Octet keys:
            ZeroArray(K);
            K = null;

            // Rsa keys:

            // We want to clear public key to avoid identification.
            ZeroArray(N);
            ZeroArray(E);

            // Private material of RSA:
            ZeroArray(D);
            ZeroArray(DP);
            ZeroArray(DQ);
            ZeroArray(QI);
            ZeroArray(P);
            ZeroArray(Q);
            N = E = D = DP = DQ = QI = P = Q = null;

            // RsaHsm keys:
            ZeroArray(T);
            T = null;

            switch (Kty)
            {
                case JsonWebKeyType.Octet:
                case JsonWebKeyType.Rsa:
                case JsonWebKeyType.RsaHsm:
                    // Supported types fall here.
                    break;

                default:
                    // Unsupported types fall here.
                    // If someone forgets to implement ClearMemory() for a new kty, this exception will reveal the mistake.
                    // Note that although there is JsonWebKeyType.EllipticCurve, it's not supported yet.
                    throw new NotImplementedException("Unsupported kty: " + Kty);
            }
        }

        private static void ZeroArray(byte[] a)
        {
            if (a == null)
                return;
            Array.Clear(a, 0, a.Length);
        }
    }
}
