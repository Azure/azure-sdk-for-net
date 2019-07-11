// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// As of http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18
    /// </summary>
    [JsonObject]
    public sealed class JsonWebKey
    {
        // DataContract property names
        internal const string Property_Kid = "kid";

        internal const string Property_Kty = "kty";
        internal const string Property_KeyOps = "key_ops";

        // RSA Key Property Names
        internal const string Property_D = "d";

        internal const string Property_DP = "dp";
        internal const string Property_DQ = "dq";
        internal const string Property_E = "e";
        internal const string Property_QI = "qi";
        internal const string Property_N = "n";
        internal const string Property_P = "p";
        internal const string Property_Q = "q";

        // ECC Key Property Names
        internal const string Property_Crv = "crv";

        internal const string Property_X = "x";

        internal const string Property_Y = "y";
        // Property_D the same as RSA Key

        // Symmetric Key Property Names
        internal const string Property_K = "k";

        // HSM Token Property Names
        internal const string Property_T = "key_hsm";

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

        #region EC Public Key Parameters

        /// <summary>
        /// The curve for Elliptic Curve Cryptography (ECC) algorithms
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_Crv, Required = Required.Default )]
        public string CurveName { get; set; }

        /// <summary>
        /// X coordinate for the Elliptic Curve point.
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_X, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] X { get; set; }

        /// <summary>
        /// Y coordinate for the Elliptic Curve point.
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_Y, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] Y { get; set; }

        #endregion

        #region EC and RSA Private Key Parameters

        /// <summary>
        /// RSA private exponent or ECC private key.
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_D, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] D { get; set; }

        #endregion

        #region Symmetric Key Parameters

        /// <summary>
        /// Symmetric key
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_K, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] K { get; set; }

        #endregion

        /// <summary>
        /// HSM Token, used with "Bring Your Own Key"
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_T, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlJsonConverter ) )]
        public byte[] T { get; set; }

        /// <summary>
        /// Holds properties that are not part of current schema.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> ExtensionData;

        /// <summary>
        /// Iterates over all JSON properties of this object, calling the specified visitor.
        /// </summary>
        /// All JSON properties are visited. This includes normal properties, properties that are not useful for the
        /// key type, and properties that are not part of current schema (extension data).
        /// Users must assume the properties are visited in random order.
        /// <param name="visitor">A visitor that will be called for each property.</param>
        public void VisitProperties( Action<string, object> visitor )
        {
            if ( visitor == null )
                throw new ArgumentNullException( nameof( visitor ) );

            visitor( Property_Crv, CurveName );
            visitor( Property_D, D );
            visitor( Property_DP, DP );
            visitor( Property_DQ, DQ );
            visitor( Property_E, E );
            visitor( Property_K, K );
            visitor( Property_KeyOps, KeyOps );
            visitor( Property_Kid, Kid );
            visitor( Property_Kty, Kty );
            visitor( Property_N, N );
            visitor( Property_P, P );
            visitor( Property_Q, Q );
            visitor( Property_T, T );
            visitor( Property_X, X );
            visitor( Property_Y, Y );

            if ( ExtensionData != null )
                foreach ( var entry in ExtensionData )
                    visitor( entry.Key, entry.Value );
        }

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
        public JsonWebKey( Aes aesProvider )
        {
            if ( aesProvider == null )
                throw new ArgumentNullException( "aesProvider" );

            Kty = JsonWebKeyType.Octet;
            K = aesProvider.Key;
        }

        /// <summary>
        /// Initializes a new instance with the key provided by the ECDsa object.
        /// </summary>
        /// <param name="ecsda">The ECDsa object previously initialized with the desired key.</param>
        /// <param name="includePrivateParameters">Tells if the instance must inclue private parameters.
        /// This requires the key in the ECDsa object to include private material and be marked as exportable.</param>
        public JsonWebKey(ECDsa ecsda, bool includePrivateParameters = false )
            : this( ecParameters: EccExtension.ExportParameters( ecsda, includePrivateParameters ) )
        {
            KeyOps = ecsda.GetKeyOperations();
        }

        /// <summary>
        /// Converts a ECParameters object to a WebKey of type EC.
        /// </summary>
        /// <param name="ecParameters">The EC object to convert</param>
        /// <returns>A WebKey representing the EC object</returns>
        public JsonWebKey( ECParameters ecParameters )
        {
            Kty = JsonWebKeyType.EllipticCurve;

            CurveName = ecParameters.Curve;
            D = ecParameters.D;
            X = ecParameters.X;
            Y = ecParameters.Y;
        }

        /// <summary>
        /// Converts a RSA object to a WebKey of type RSA.
        /// </summary>
        /// <param name="rsaProvider">The RSA object to convert</param>
        /// <param name="includePrivateParameters">True to include the RSA private key parameters</param>
        /// <returns>A WebKey representing the RSA object</returns>
        public JsonWebKey( RSA rsaProvider, bool includePrivateParameters = false ) : this( rsaProvider.ExportParameters( includePrivateParameters ) )
        {
        }

        /// <summary>
        /// Converts a RSAParameters object to a WebKey of type RSA.
        /// </summary>
        /// <param name="rsaParameters">The RSA object to convert</param>
        /// <returns>A WebKey representing the RSA object</returns>
        public JsonWebKey( RSAParameters rsaParameters )
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
            if ( obj == this )
                return true;

            var other = obj as JsonWebKey;

            if ( other == null )
                return false;

            return Equals( other );
        }

        /// <summary>
        /// Compares <see cref="JsonWebKey"/> objects
        /// </summary>
        /// <param name="other"> the <see cref="JsonWebKey"/> object to compare with </param>
        /// <returns> whether the <see cref="JsonWebKey"/> objects are equals </returns>
        public bool Equals( JsonWebKey other )
        {
            if ( other == this )
                return true;

            if ( other == null )
                return false;

            if ( !string.Equals( Kid, other.Kid ) )
                return false;

            if ( !string.Equals( Kty, other.Kty ) )
                return false;

            if ( !AreEqual( KeyOps, other.KeyOps ) )
                return false;

            if ( !string.Equals( CurveName, other.CurveName ) )
                return false;

            if ( !AreEqual( K, other.K ) )
                return false;

            // Public parameters
            if ( !AreEqual( N, other.N ) )
                return false;

            if ( !AreEqual( E, other.E ) )
                return false;

            if ( !AreEqual( X, other.X ) )
                return false;

            if ( !AreEqual( Y, other.Y ) )
                return false;

            // Private parameters
            if ( !AreEqual( D, other.D ) )
                return false;

            if ( !AreEqual( DP, other.DP ) )
                return false;

            if ( !AreEqual( DQ, other.DQ ) )
                return false;

            if ( !AreEqual( QI, other.QI ) )
                return false;

            if ( !AreEqual( P, other.P ) )
                return false;

            if ( !AreEqual( Q, other.Q ) )
                return false;

            // HSM token
            if ( !AreEqual( T, other.T ) )
                return false;

            return true;
        }

        private static bool AreEqual( byte[] a, byte[] b )
        {
            if ( a == b )
                return true;

            if ( a == null )
                // b can't be null because otherwise we would return true above.
                return b.Length == 0;

            if ( b == null )
                // Likewise, a can't be null.
                return a.Length == 0;

            if ( a.Length != b.Length )
                return false;

            for ( var i = 0; i < a.Length; ++i )
                if ( a[i] != b[i] )
                    return false;

            return true;
        }

        private static bool AreEqual( IList<string> a, IList<string> b )
        {
            if ( a == b )
                return true;

            if ( ( a == null ) != ( b == null ) )
                return false;

            if ( a.Count != b.Count )
                return false;

            for ( var i = 0; i < a.Count; ++i )
                if ( a[i] != b[i] )
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 48313; // setting it to a random prime number

            if ( Kid != null )
            {
                hashCode += Kid.GetHashCode();
            }

            switch ( Kty )
            {
                case JsonWebKeyType.Octet:
                    return hashCode + GetHashCode( K );

                case JsonWebKeyType.EllipticCurve:
                    return hashCode + GetHashCode( X );

                case JsonWebKeyType.Rsa:
                    return hashCode + GetHashCode( N );

                case JsonWebKeyType.EllipticCurveHsm:
                case JsonWebKeyType.RsaHsm:
                    return hashCode + GetHashCode( T );

                default:
                    return hashCode;
            }
        }

        private static int GetHashCode( byte[] obj )
        {
            if ( obj == null || obj.Length == 0 )
                return 0;

            var hashCode = 0;

            // Rotate by 3 bits and XOR the new value.
            foreach ( var v in obj )
                hashCode = ( hashCode << 3 ) | ( hashCode >> 29 ) ^ v;

            return hashCode;
        }

        /// <summary>
        /// Verifies whether this object has a private key
        /// </summary>
        /// <returns> True if the object has private key; false otherwise.</returns>
        public bool HasPrivateKey()
        {
            switch ( Kty )
            {
                case JsonWebKeyType.Octet:
                    return K != null;

                case JsonWebKeyType.EllipticCurve:
                case JsonWebKeyType.EllipticCurveHsm:
                    return D != null;

                case JsonWebKeyType.Rsa:
                case JsonWebKeyType.RsaHsm:
                    return D != null && DP != null && DQ != null && QI != null && P != null && Q != null;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines if the WebKey object is valid according to the rules for
        /// each of value of JsonWebKeyType.
        /// </summary>
        /// <returns>true if the WebKey is valid</returns>
        public bool IsValid()
        {
            var verifierOptions =
                JsonWebKeyVerifier.Options.DenyIncompatibleOperations |
                JsonWebKeyVerifier.Options.DenyExtraneousFields;

            string unused = null;
            return JsonWebKeyVerifier.VerifyByKeyType( this, verifierOptions, ref unused );
        }

        /// <summary>
        /// Converts a WebKey of type Octet to an AES object.
        /// </summary>
        /// <returns>An AES object</returns>
        public Aes ToAes()
        {
            if ( !Kty.Equals( JsonWebKeyType.Octet ) )
                throw new InvalidOperationException( "key is not an octet key" );

            if ( K == null )
                throw new InvalidOperationException( "key does not contain a value" );

            var result = Aes.Create();

            if ( result != null )
                result.Key = K;

            return result;
        }

        /// <summary>
        /// Remove leading zeros from all RSA parameters.
        /// </summary>
        public void CanonicalizeRSA()
        {
            N = RemoveLeadingZeros( N );
            E = RemoveLeadingZeros( E );
            D = RemoveLeadingZeros( D );
            DP = RemoveLeadingZeros( DP );
            DQ = RemoveLeadingZeros( DQ );
            QI = RemoveLeadingZeros( QI );
            P = RemoveLeadingZeros( P );
            Q = RemoveLeadingZeros( Q );
        }

        /// <summary>
        /// Converts a WebKey of type RSA or RSAHSM to a RSA object
        /// </summary>
        /// <param name="includePrivateParameters">Tells if private material must be included.</param>
        /// <returns>An initialized RSA instance</returns>
        public RSA ToRSA( bool includePrivateParameters = false )
        {
            var rsaParameters = ToRSAParameters( includePrivateParameters );
            var result = RSA.Create();
            result.ImportParameters( rsaParameters );
            return result;
        }

        /// <summary>
        /// Converts a WebKey of type RSA or RSAHSM to a RSA parameter object
        /// </summary>
        /// <param name="includePrivateParameters">Tells if private material must be included.</param>
        /// <returns>An RSA parameter</returns>
        public RSAParameters ToRSAParameters( bool includePrivateParameters = false )
        {
            if ( Kty != JsonWebKeyType.Rsa && Kty != JsonWebKeyType.RsaHsm )
                throw new ArgumentException( "JsonWebKey is not a RSA key" );

            VerifyNonZero( nameof( N ), N );
            VerifyNonZero( nameof( E ), E );

            // Length requirements defined by 2.2.2.9.1 RSA Private Key BLOB (https://msdn.microsoft.com/en-us/library/cc250013.aspx).
            // See KV bugs 190589 and 183469.

            var result = new RSAParameters();
            result.Modulus = RemoveLeadingZeros( N );
            result.Exponent = ForceLength( nameof( E ), E, 4 );

            if ( includePrivateParameters )
            {
                var bitlen = result.Modulus.Length * 8;

                result.D = ForceLength( nameof( D ), D, bitlen / 8 );
                result.DP = ForceLength( nameof( DP ), DP, bitlen / 16 );
                result.DQ = ForceLength( nameof( DQ ), DQ, bitlen / 16 );
                result.InverseQ = ForceLength( nameof( QI ), QI, bitlen / 16 );
                result.P = ForceLength( nameof( P ), P, bitlen / 16 );
                result.Q = ForceLength( nameof( Q ), Q, bitlen / 16 );
            }

            return result;
        }

        /// <summary>
        /// Converts a WebKey of type EC or EC-HSM to an ECDsa object
        /// </summary>
        /// <param name="includePrivateParameters">Tells if private material must be included.</param>
        /// <returns>An initialized ECDsa instance</returns>
        public ECDsa ToECDsa( bool includePrivateParameters = false )
        {
            return ToEcParameters( includePrivateParameters ).ToEcdsa( includePrivateParameters );
        }

        /// <summary>
        /// Converts a WebKey of type EC or EC-HSM to an EC parameter object.
        /// </summary>
        /// <param name="includePrivateParameters">Tells if private material must be included.</param>
        /// <returns>An EC parameter object</returns>
        public ECParameters ToEcParameters( bool includePrivateParameters = false )
        {
            if ( Kty != JsonWebKeyType.EllipticCurve && Kty != JsonWebKeyType.EllipticCurveHsm )
                throw new ArgumentException( "JsonWebKey is not an EC key" );

            VerifyNonZero( nameof( X ), X );
            VerifyNonZero( nameof( Y ), Y );

            var requiredSize = JsonWebKeyCurveName.GetKeyParameterSize( CurveName );
            if ( requiredSize < 0 )
            {
                var curveDesc = CurveName == null ? "null" : $"\"{CurveName}\"";
                throw new ArgumentException( $"Invalid curve type: {curveDesc}" );
            }

            var result = new ECParameters();
            result.Curve = CurveName;
            result.X = ForceLength( nameof( X ), X, requiredSize );
            result.Y = ForceLength( nameof( Y ), Y, requiredSize );

            if ( includePrivateParameters )
            {
                VerifyNonZero( nameof( D ), D );
                result.D = ForceLength( nameof( D ), D, requiredSize );
            }

            return result;
        }

        private static void VerifyNonZero( string name, byte[] value )
        {
            if ( value != null )
                foreach ( var t in value )
                    if ( t != 0 )
                        return;

            throw new ArgumentException( $"Value of \"{name}\" must be non-zero." );
        }

        private static byte[] RemoveLeadingZeros( byte[] value )
        {
            // Do nothing if:
            // 1) value is null.
            // 2) value is empty.
            // 3) value has length of 1 (this is considered a useful zero).
            // 4) first byte is already non-zero (optimization).
            if ( value == null || value.Length <= 1 || value[0] != 0 )
                return value;

            // We know that value[0] is zero, so we start from 1.
            for ( var i = 1; i < value.Length; ++i )
            {
                if ( value[i] != 0 )
                {
                    var result = new byte[value.Length - i];
                    Array.Copy( value, i, result, 0, result.Length );
                    return result;
                }
            }

            // If all is zero, return an array with a single useful zero.
            return new byte[] {0};
        }

        private static byte[] ForceLength( string name, byte[] value, int requiredLength )
        {
            if ( value == null || value.Length == 0 )
                throw new ArgumentException( $"Value of \"{name}\" is null or empty." );

            if ( value.Length == requiredLength )
                return value;

            if ( value.Length < requiredLength )
            {
                var padded = new byte[requiredLength];
                Array.Copy( value, 0, padded, requiredLength - value.Length, value.Length );
                return padded;
            }

            // value.Length > requiredLength

            // Make sure the extra bytes are all zeros.
            var extraLen = value.Length - requiredLength;
            for ( var i = 0; i < extraLen; ++i )
                if ( value[i] != 0 )
                    throw new ArgumentException( $"Invalid length of \"{name}\": expected at most {requiredLength} bytes, found {value.Length - i} bytes." );

            var trimmed = new byte[requiredLength];
            Array.Copy( value, value.Length - requiredLength, trimmed, 0, requiredLength );
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
            ZeroArray( K );
            K = null;

            // Rsa keys:

            // We want to clear public key to avoid identification.
            ZeroArray( N );
            ZeroArray( E );

            // Private material of RSA:
            ZeroArray( D );
            ZeroArray( DP );
            ZeroArray( DQ );
            ZeroArray( QI );
            ZeroArray( P );
            ZeroArray( Q );
            N = E = D = DP = DQ = QI = P = Q = null;

            // RsaHsm keys:
            ZeroArray( T );
            T = null;

            // Elliptic curve
            ZeroArray( X );
            ZeroArray( Y );
            ZeroArray( D ); // D is intentionally repeated.
            X = Y = D = null;

            switch ( Kty )
            {
                case JsonWebKeyType.Octet:
                case JsonWebKeyType.EllipticCurve:
                case JsonWebKeyType.EllipticCurveHsm:
                case JsonWebKeyType.Rsa:
                case JsonWebKeyType.RsaHsm:
                    // Supported types fall here.
                    break;

                default:
                    // Unsupported types fall here.
                    // If someone forgets to implement ClearMemory() for a new kty, this exception will reveal the mistake.
                    throw new NotImplementedException( $"Unsupported kty: {Kty}" );
            }
        }

        private static void ZeroArray( byte[] a )
        {
            if ( a == null )
                return;
            Array.Clear( a, 0, a.Length );
        }
    }
}