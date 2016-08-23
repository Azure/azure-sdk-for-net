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
