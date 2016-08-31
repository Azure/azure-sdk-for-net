// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

namespace Microsoft.Azure.KeyVault.WebKey
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Runtime.Serialization;
    using System.Security.Cryptography;

    /// <summary>
    /// As of http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18
    /// </summary>
    public class JsonWebKey
    {
        /// <summary>
        /// Initializes a new instance of the JsonWebKey class.
        /// </summary>
        public JsonWebKey() { }

        /// <summary>
        /// Initializes a new instance of the JsonWebKey class.
        /// </summary>
        /// <param name="kid">Key Identifier</param>
        /// <param name="kty">Supported JsonWebKey key types (kty) for
        /// Elliptic Curve, RSA, HSM, Octet, usually RSA. Possible values
        /// include: 'EC', 'RSA', 'RSA-HSM', 'oct'</param>
        /// <param name="n">RSA modulus</param>
        /// <param name="e">RSA public exponent</param>
        /// <param name="d">RSA private exponent</param>
        /// <param name="dP">RSA Private Key Parameter</param>
        /// <param name="dQ">RSA Private Key Parameter</param>
        /// <param name="qI">RSA Private Key Parameter</param>
        /// <param name="p">RSA secret prime</param>
        /// <param name="q">RSA secret prime, with p < q</param>
        /// <param name="k">Symmetric key</param>
        /// <param name="t">HSM Token, used with Bring Your Own Key</param>
        public JsonWebKey(string kid = default(string), string kty = default(string), IList<string> keyOps = default(IList<string>), byte[] n = default(byte[]), byte[] e = default(byte[]), byte[] d = default(byte[]), byte[] dp = default(byte[]), byte[] dq = default(byte[]), byte[] qi = default(byte[]), byte[] p = default(byte[]), byte[] q = default(byte[]), byte[] k = default(byte[]), byte[] t = default(byte[]))
        {
            Kid = kid;
            Kty = kty;
            KeyOps = keyOps;
            N = n;
            E = e;
            D = d;
            DP = dp;
            DQ = dq;
            QI = qi;
            P = p;
            Q = q;
            K = k;
            T = t;
        }

        /// <summary>
        /// Gets or sets key Identifier
        /// </summary>
        [JsonProperty(PropertyName = "kid")]
        public string Kid { get; set; }

        /// <summary>
        /// Gets or sets supported JsonWebKey key types (kty) for Elliptic
        /// Curve, RSA, HSM, Octet, usually RSA. Possible values include:
        /// 'EC', 'RSA', 'RSA-HSM', 'oct'
        /// </summary>
        [JsonProperty(PropertyName = "kty")]
        public string Kty { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key_ops")]
        public IList<string> KeyOps { get; set; }

        /// <summary>
        /// Gets or sets RSA modulus
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "n")]
        public byte[] N { get; set; }

        /// <summary>
        /// Gets or sets RSA public exponent
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "e")]
        public byte[] E { get; set; }

        /// <summary>
        /// Gets or sets RSA private exponent
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "d")]
        public byte[] D { get; set; }

        /// <summary>
        /// Gets or sets RSA Private Key Parameter
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "dp")]
        public byte[] DP { get; set; }

        /// <summary>
        /// Gets or sets RSA Private Key Parameter
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "dq")]
        public byte[] DQ { get; set; }

        /// <summary>
        /// Gets or sets RSA Private Key Parameter
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "qi")]
        public byte[] QI { get; set; }

        /// <summary>
        /// Gets or sets RSA secret prime
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "p")]
        public byte[] P { get; set; }

        /// <summary>
        /// Gets or sets RSA secret prime, with p &lt; q
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "q")]
        public byte[] Q { get; set; }

        /// <summary>
        /// Gets or sets symmetric key
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "k")]
        public byte[] K { get; set; }

        /// <summary>
        /// Gets or sets HSM Token, used with Bring Your Own Key
        /// </summary>
        [JsonConverter(typeof(Base64UrlJsonConverter))]
        [JsonProperty(PropertyName = "key_hsm")]
        public byte[] T { get; set; }

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
        /// <param name="rsaProvider">The RSA object to convert</param>
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

            JsonWebKey other = obj as JsonWebKey;

            if ( other == null )
                return false;

            return this.Equals( other );
        }

        public bool Equals( JsonWebKey other )
        {
            if ( other == null )
                return false;

            if ( string.Equals( Kty, other.Kty ) )
            {
                switch ( Kty )
                {
                    case JsonWebKeyType.EllipticCurve:
                        break;

                    case JsonWebKeyType.Octet:
                        return IsEqualOctet( other );

                    case JsonWebKeyType.Rsa:
                        return IsEqualRsa( other );

                    case JsonWebKeyType.RsaHsm:
                        return IsEqualRsaHsm( other );
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            switch ( Kty )
            {
                case JsonWebKeyType.EllipticCurve:
                    return base.GetHashCode();

                case JsonWebKeyType.Octet:
                    return GetHashCode( K );

                case JsonWebKeyType.Rsa:
                    return GetHashCode( N );

                case JsonWebKeyType.RsaHsm:
                    return GetHashCode( T );

                default:
                    return base.GetHashCode();
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

        public virtual bool HasPrivateKey()
        {
            switch ( Kty )
            {
                case JsonWebKeyType.EllipticCurve:
                    return false;

                case JsonWebKeyType.Octet:
                    return K != null;

                case JsonWebKeyType.Rsa:
                case JsonWebKeyType.RsaHsm:
                    // MAY have private key parameters, but only ALL or NONE
                    var privateParameters = new bool[] { D != null, DP != null, DQ != null, QI != null, P != null, Q != null };

                    return privateParameters.All( ( value ) => value );

                default:
                    return false;
            }
        }

        private bool IsEqualOctet( JsonWebKey other )
        {
            return K.SequenceEqual( other.K );
        }

        private bool IsEqualRsa( JsonWebKey other )
        {
            // Public parameters
            if ( !N.SequenceEqual( other.N ) )
                return false;

            if ( !E.SequenceEqual( other.E ) )
                return false;

            // Private parameters
            var privateKey = HasPrivateKey();

            if ( privateKey && privateKey == other.HasPrivateKey() )
            {
                if ( !D.SequenceEqual( other.D ) )
                    return false;

                if ( !DP.SequenceEqual( other.DP ) )
                    return false;

                if ( !DQ.SequenceEqual( other.DQ ) )
                    return false;

                if ( !QI.SequenceEqual( other.QI ) )
                    return false;

                if ( !P.SequenceEqual( other.P ) )
                    return false;

                if ( !Q.SequenceEqual( other.Q ) )
                    return false;
            }

            return true;
        }

        private bool IsEqualRsaHsm( JsonWebKey other )
        {
            if ( ( T != null && other.T == null ) || ( T == null && other.T != null ) )
                return false;

            if ( T != null && !T.SequenceEqual( other.T ) )
                return false;

            return IsEqualRsa( other );
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
            if ( KeyOps != null && KeyOps.Count() != 0 )
            {
                if ( !KeyOps.All( ( op ) => { return JsonWebKeyOperation.AllOperations.Contains( op ); } ) )
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

            // MUST NOT have private key parameters, but only ALL or NONE
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

        /// <summary>
        /// Converts a WebKey of type Octet to an AES object.
        /// </summary>
        /// <param name="key">The WebKey to convert</param>
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
        /// <returns>An initialized RSACryptoServiceProvider instance</returns>
        public RSACryptoServiceProvider ToRSA(bool includePrivateParameters = false)
        {
            var rsaParameters = ToRSAParameters(includePrivateParameters);
            var rsaProvider = new RSACryptoServiceProvider();

            rsaProvider.ImportParameters(rsaParameters);

            return rsaProvider;
        }

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

        [OnDeserialized]
        internal void OnDeserialized( StreamingContext context )
        {
            if ( !IsValid() )
                throw new JsonSerializationException( "JsonWebKey is not valid" );
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
