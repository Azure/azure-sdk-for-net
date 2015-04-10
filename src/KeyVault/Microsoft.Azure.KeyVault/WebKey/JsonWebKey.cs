//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.Azure.KeyVault.WebKey.Json;
using Newtonsoft.Json;

namespace Microsoft.Azure.KeyVault.WebKey
{
    // As of http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18
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
        /// Key type, usually RSA
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_Kty, Required = Required.Always )]
        public string Kty { get; set; }

        /// <summary>
        /// Supported Key Operations
        /// </summary>
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_KeyOps, Required = Required.Default )]
        public string[] KeyOps { get; set; }

        #region RSA Public Key Parameters

        // RSA modulus, in Base64.
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_N, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] N { get; set; }

        // RSA public exponent, in Base64.
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_E, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] E { get; set; }

        #endregion

        #region RSA Private Key Parameters

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_D, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] D { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_DP, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] DP { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_DQ, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] DQ { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_QI, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] QI { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_P, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] P { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_Q, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] Q { get; set; }

        #endregion

        #region Symmetric Key Parameters

        // Symmetric key
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_K, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] K { get; set; }

        #endregion

        // HSM Token, used with "Bring Your Own Key"
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = Property_T, Required = Required.Default )]
        [JsonConverter( typeof( Base64UrlConverter ) )]
        public byte[] T { get; set; }

        [JsonConstructor]
        public JsonWebKey()
        {
            // Intentionally empty
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
        /// each of the possible WebKeyTypes
        /// </summary>
        /// <returns>true if the WebKey is valid</returns>
        public virtual bool IsValid()
        {
            // MUST have kty
            if ( string.IsNullOrEmpty( Kty ) )
                return false;

            // Validate Key Operations
            if ( KeyOps != null && KeyOps.Length != 0 )
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
    }
 }
