//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Xunit;

// ReSharper disable InconsistentNaming

namespace Microsoft.Azure.KeyVault.WebKey.Tests
{
    public class WebKeyRsaValidationTest
    {
        // Encrypt and Decrypt methods used by the test cases.
        private static byte[] _plainText = new byte[] { 1, 3, 2, 7 };

        /// <summary>
        /// Decrypts the cipher text using the key.
        /// </summary>
        private static byte[] Decrypt( RSA key, byte[] cipherText )
        {
            byte[] plainText = null;

#if FullNetFx
            if ( key is RSACryptoServiceProvider )
            {
                plainText = ( ( RSACryptoServiceProvider )key ).Decrypt( cipherText, true );
            }
            else
            {
                throw new CryptographicException( string.Format( "{0} is not supported", key.GetType().FullName ) );
            }
#elif NETCOREAPP20
            plainText = key.Decrypt(cipherText, RSAEncryptionPadding.OaepSHA1);
#else
#error Unknown Build Flavor            
#endif

            return plainText;
        }

        /// <summary>
        /// Encrypts a fixed plain text using the key.
        /// </summary>
        private static byte[] Encrypt( RSA key )
        {
            byte[] cipherText = null;

#if FullNetFx
            if ( key is RSACryptoServiceProvider )
            {
                cipherText = ( ( RSACryptoServiceProvider )key ).Encrypt( _plainText, true );
            }
            else
            {
                throw new CryptographicException( string.Format( "{0} is not supported", key.GetType().FullName ) );
            }
#elif NETCOREAPP20
            cipherText = key.Encrypt( _plainText, RSAEncryptionPadding.OaepSHA1 );
#else
            #error Unknown Build Flavor            
#endif

            return cipherText;
        }

        /// <summary>
        /// Performs encrypt and decrypt using the specified key
        /// </summary>
        private static void EncryptDecrypt( RSA key )
        {
            EncryptDecrypt( key, key );
        }

        /// <summary>
        /// Performs encrypt and decrypt with the specified keys
        /// </summary>
        private static void EncryptDecrypt( RSA publicKey, RSA privateKey )
        {
            byte[] cipherText = Encrypt( publicKey );
            byte[] plainText  = Decrypt( privateKey, cipherText );

            if ( !plainText.SequenceEqual( _plainText ) )
                throw new Exception( "EncryptDecrypt sequence failed." );
        }

        private static void EncryptDecrypt( JsonWebKey publicKey, JsonWebKey privateKey )
        {
            EncryptDecrypt( publicKey.ToRSA(), privateKey.ToRSA( true ) );
        }
        
        [Fact]
        public void OrdinaryKeyMustWork()
        {
            foreach ( var ordinary in GetOrdinaryTestKeys().Values )
            {
                var key = JsonConvert.DeserializeObject<JsonWebKey>( ordinary );
                KeyMustWork( key, true );
                KeysMustBeCompatible( key, key );
            }
        }

        [Fact]
        public void PublicKeyMustWork()
        {
            foreach ( var ordinary in GetOrdinaryTestKeys().Values )
            {
                var privateKey = JsonConvert.DeserializeObject<JsonWebKey>( ordinary );

                var rsaParams = privateKey.ToRSAParameters();
                Assert.Null( rsaParams.D );
                Assert.Null( rsaParams.DP );
                Assert.Null( rsaParams.DQ );
                Assert.Null( rsaParams.P );
                Assert.Null( rsaParams.Q );
                Assert.Null( rsaParams.InverseQ );

                var publicKey = new JsonWebKey( rsaParams );

                // Do encrypt and decrypt test
                EncryptDecrypt( publicKey, privateKey );
            }
        }

        [Fact]
        public void D_SmallerThan_N_MustWork()
        {
            foreach ( var D_smallerThan_N in Get_DsmallerThanN_TestKeys().Values )
            {
                var canonical = JsonConvert.DeserializeObject<JsonWebKey>( D_smallerThan_N );
                KeyMustWork( canonical, true );

                var padded = JsonConvert.DeserializeObject<JsonWebKey>( D_smallerThan_N );
                PadParameter( padded, "D", padded.N.Length );
                // Serialization must not canonicalize key
                Assert.NotEqual( canonical.ToString(), padded.ToString() );
                KeyMustWork( padded, true );

                KeysMustBeCompatible( canonical, padded );

                padded.CanonicalizeRSA();
                // Keys should be the equal after canonicalization
                Assert.Equal( canonical, padded );
            }
        }

        [Fact]
        public void StuffedParameterMustWork()
        {
            foreach ( var ordinary in GetOrdinaryTestKeys().Values )
            {
                foreach ( var paramName in _rsaFields )
                {
                    var canonicalKey = JsonConvert.DeserializeObject<JsonWebKey>( ordinary );
                    var stuffedKey = Clone( canonicalKey );
                    PadParameter( stuffedKey, paramName, 1 + GetRequiredLen( GetParameter( stuffedKey, paramName ).Length ) );
                    // Keys with different buffer values are being reported as equals
                    Assert.NotEqual( canonicalKey, stuffedKey );

                    var serialized = stuffedKey.ToString();
                    // Serialization must not canonicalize key
                    Assert.NotEqual( canonicalKey.ToString(), serialized );

                    KeysMustBeCompatible( canonicalKey, stuffedKey );

                    stuffedKey.CanonicalizeRSA();
                    // Keys should be the equal after canonicalization
                    Assert.Equal( canonicalKey, stuffedKey );
                }
            }
        }

        private static void PadParameter( JsonWebKey key, string paramName, int targetLen )
        {
            var data = GetParameter( key, paramName );
            var padded = new byte[targetLen];
            Array.Copy( data, 0, padded, targetLen - data.Length, data.Length );
            SetParameter( key, paramName, padded );
        }

        private static int GetRequiredLen( int len )
        {
            var requiredLen = len;
            var mod16 = requiredLen%16;
            if ( mod16 != 0 )
                requiredLen += 16 - mod16;
            return requiredLen;
        }

        [Fact]
        public void NullOrEmptyParamMustThrowArgumentException()
        {
            foreach ( var ordinary in GetOrdinaryTestKeys().Values )
            {
                foreach ( var paramName in _rsaFields )
                {
                    var key = JsonConvert.DeserializeObject<JsonWebKey>( ordinary );

                    SetParameter( key, paramName, null );
                    KeyMustThrowArgumentException( paramName, key );

                    SetParameter( key, paramName, new byte[0] );
                    KeyMustThrowArgumentException( paramName, key );
                }
            }
        }

        private void KeyMustThrowArgumentException( string paramName, JsonWebKey key )
        {
            // We sill must be able to serialize...
            var serialized = key.ToString();
            try
            {
                // ...and deserialize
                var deserialized = JsonConvert.DeserializeObject<JsonWebKey>( serialized );
                Assert.Equal( key, deserialized );
            }
            catch ( TargetInvocationException ex )
            {
                // TODO: This key is failing the serialization roundtrip, but this behavior is kept for compatibility.
                Console.WriteLine( string.Format( "WARNING: Key with bad value on {0} can be serialized, but not deserialized. {1}", paramName, ex.Message ) );
            }

            KeyMustThrowArgumentException( key, true );

            if ( paramName == "E" || paramName == "N" )
            {
                KeyMustThrowArgumentException( key, false );
            }
            else
            {
                // Test only public parameters, which should work.
                KeyMustWork( key );
            }
        }


        private static void KeyMustThrowArgumentException( JsonWebKey badKey, bool includePrivate )
        {
            try
            {
                badKey.ToRSAParameters( includePrivate );
                throw new Exception( "ToRSAParameters should throw exception." );
            }
            catch ( ArgumentException )
            {
            }

            try
            {
                badKey.ToRSA( includePrivate );
                throw new Exception( "ToRSA should throw exception." );
            }
            catch ( ArgumentException )
            {
            }
        }

        private static void KeyMustWork( JsonWebKey key, bool includePrivateParameters = false )
        {
            var rsa = key.ToRSA( includePrivateParameters );

            if ( includePrivateParameters )
            {
                // Perform encrypt and decrypt with the key
                EncryptDecrypt( rsa );
            }
            else
            {
                // Perform encrypt with the public key
                Encrypt( rsa );
            }
        }

        private static void KeysMustBeCompatible( JsonWebKey publicKey, JsonWebKey privateKey, bool bidirectional = true )
        {
            try
            {
                EncryptDecrypt( publicKey, privateKey );

                if ( bidirectional )
                    EncryptDecrypt( privateKey, publicKey );
            }
            catch ( Exception e )
            {
                throw new Exception( "KeysMustBeCompatible failed", e );
            }
        }

        internal static void EmitTestData( int keySize )
        {
            EmitOrdinary( keySize );
            EmitDSmallerThanN( keySize );
        }

        private static void EmitOrdinary( int keySize )
        {
            for ( var i = 0; i < 10*256; ++i )
            {
                var csp = RSA.Create(); csp.KeySize = keySize;
                var rsaParams = csp.ExportParameters( true );
                csp.Dispose();
                var key = new JsonWebKey( rsaParams );
                key.CanonicalizeRSA();
                if ( rsaParams.D.Length == rsaParams.Modulus.Length )
                {
                    EmitVariable( "ordinary", keySize, key );
                    return;
                }
            }
            throw new Exception( "Unable to generate ordinary key." );
        }

        private static void EmitDSmallerThanN( int keySize )
        {
            for ( var i = 0; i < 10*256; ++i )
            {
                var csp = RSA.Create(); csp.KeySize = keySize;
                var rsaParams = csp.ExportParameters( true );
                csp.Dispose();
                var key = new JsonWebKey( rsaParams );
                key.CanonicalizeRSA();
                if ( key.D.Length < key.N.Length )
                {
                    EmitVariable( "D_smallerThan_N", keySize, key );
                    return;
                }
            }
            throw new Exception( "Unable to generate key with D < N." );
        }

        internal static void EmitVariable( string collectionName, int keySize, JsonWebKey key )
        {
            var text = key.ToString();
            text = text.Replace( "\"", "\\\"" );
            text = text.Replace( "\r\n", "\\r\\n" );
            Console.WriteLine( "{0}.Add({1}, \"{2}\");", collectionName, keySize, text );
        }

        private static JsonWebKey Clone( JsonWebKey key )
        {
            return JsonConvert.DeserializeObject<JsonWebKey>( key.ToString() );
        }

        private static readonly string[] _rsaFields = {"E", "N", "D", "DP", "DQ", "QI", "P", "Q"};

        private static byte[] GetParameter( JsonWebKey key, string paramName )
        {
            // Hacky but better than reflection.
            switch ( paramName )
            {
                case "D":
                    return key.D;
                case "DP":
                    return key.DP;
                case "DQ":
                    return key.DQ;
                case "E":
                    return key.E;
                case "N":
                    return key.N;
                case "P":
                    return key.P;
                case "Q":
                    return key.Q;
                case "QI":
                    return key.QI;
                default:
                    // Intentionally not ArgumentException to avoid interfere with tests.
                    throw new Exception( "Invalid parameter name: " + paramName );
            }
        }

        private static void SetParameter( JsonWebKey key, string paramName, byte[] value )
        {
            // Hacky but better than reflection.
            switch ( paramName )
            {
                case "D":
                    key.D = value;
                    break;
                case "DP":
                    key.DP = value;
                    break;
                case "DQ":
                    key.DQ = value;
                    break;
                case "E":
                    key.E = value;
                    break;
                case "N":
                    key.N = value;
                    break;
                case "P":
                    key.P = value;
                    break;
                case "Q":
                    key.Q = value;
                    break;
                case "QI":
                    key.QI = value;
                    break;
                default:
                    // Intentionally not ArgumentException to avoid interfere with tests.
                    throw new Exception( "Invalid parameter name: " + paramName );
            }
        }

        /// <summary>
        /// Test keys where D.Length == N.Length (majority of cases).
        /// </summary>
        private static Dictionary<int, string> GetOrdinaryTestKeys()
        {
            var result = new Dictionary<int, string>();
            result.Add( 512, "{\"kty\":\"RSA\",\"n\":\"uOXIpiH9L0h_byTuP3fcMvKbfS85eTKvxW2skw4oIU2TM3ceFvlDwDK4gKHl4qE4z18bz0qrv9ElstOrT96piQ\",\"e\":\"AQAB\",\"d\":\"And2KMA5uQ1r9MwuvZCODi0D2lcFvz7oBbenyxqmuhTYfdGcuGE9FZg5V6ZcNwBK_eYGZqSwL1Gh2EmzG6AxwQ\",\"dp\":\"CEh8kzQnCRK97NKQeV_wGgWsLYlmgis7Cms85_DIqwE\",\"dq\":\"TAi0G0iE5pvMpiEN2y189hjSRSqE6Unc1lXaE3hcnWE\",\"qi\":\"2HhNqW3QBv1R_iEpu44KVMQs0DdnY5oWp1lH6hgPhXU\",\"p\":\"5BblSoMJmO5Afa-urQFzFpBfACt1175NMUs4tHUYEkE\",\"q\":\"z4Xdf_FU-51wTkW5mFJ6QoDK-GrkMXSdct9hdW26NUk\"}" );
            result.Add( 1024, "{\"kty\":\"RSA\",\"n\":\"zicSNMeAUYwp6V6UQlJ8gW04o6O4ZJBIefsLnV6-to1YkzgDu6vDBWb83DcDgB2x63W-ZVK23F4dcJcULu1VM-jX83Sfg0b_ZrugiiXCnZ4iidLNcY5QOS1dSHjfI1eWH6QdLPSIE3sHk-BILrIXqoyIJH-LFxzMu--4bDlej2M\",\"e\":\"AQAB\",\"d\":\"A4h7F2YT6bhG2TXcJ9OiFQj6LFPLmG2gnSnGssiQHDDWXWLB-mvT-9O4CBr2ETJxFvsw0cVV8CqGXQrTaodGxOuCGNmYoczodvlhUBJyMBxAI2or5eZUF9jRiECvigoxNVWKsqWxypvq_X1pMfQbh9ot7F6KOJAEg6wlLTc-fIE\",\"dp\":\"v2JbDaZfi3OCCLMtNMjOxfNsBOPb1IqerGux4IR17fLIzG6JlcyaR4uasILdjE4VufqnppZ6FIlFCZUiyIP0GQ\",\"dq\":\"m6NTbNOxN2qnont_qttyqg6WvOA6zWK55-ZnX8hShmlv0ySgtw1PfOWso3wpRMHAujTOfUSeI14DgOLHLNkKtQ\",\"qi\":\"HOcBZfyxW1dSnghCvdTuKL3jLSww6k_v0jhYET32gyKe8od7uxP7w0dXZ8al4zQ3xGxrip9y7jJi0pjG-Z4uGw\",\"p\":\"6dlyTUBrwxLyLbr0X3yqmNu3VrHSt2zbW8jueZFWXPELlbuQ6EKrHoR39BM8MSjFN5PfZbsBhcqNBkqhitj6xw\",\"q\":\"4a4DOrnZt4423myMKmhgDINvIdNmLCHG0aE8UWcSPKO6RFhzHX46NJSoOuk9gvccMKEXOpcJC6P8b8ypN-OKhQ\"}" );
            result.Add( 2048, "{\"kty\":\"RSA\",\"n\":\"rZ8pnmXkhfmmgNWVVdtNcYy2q0OAcCGIpeFzsN9URqJsiBEiWQfxlUxFTbM4kVWPqjauKt6byvApBGEeMA7Qs8kxwRVP-BD4orXRe9VPgliM92rH0UxQWHmCHUe7G7uUAFPwbiDVhWuFzELxNa6Kljg6Z9DuUKoddmQvlYWj8uSunofCtDi_zzlZKGYTOYJma5IYScHNww1yjLp8-b-Be2UdHbrPkCv6Nuwi6MVIKjPpEeRQgfefRmxDBJQKY3OfydMXZmEwukYXVkUcdIP8XwG2OxnfdRK0oAo0NDebNNVuT89k_3AyZLTr1KbDmx1nnjwa8uB8k-uLtcOC9igbTw\",\"e\":\"AQAB\",\"d\":\"H-z7hy_vVJ9yeZBMtIvt8qpQUK_J51STPwV085otcgud72tPKJXoW2658664ASl9kGwbnLBwb2G3-SEunuGqiNS_PGUB3niob6sFSUMRKsPDsB9HfPoOcCZvwZiWFGRqs6C7vlR1TuJVqRjKJ_ffbf4K51oo6FZPspx7j4AShLAwLUSQ60Ld5QPuxYMYZIMpdVbMVIVHJ26pR4Y18e_0GYmEGnbF5N0HkwqQmfmTiIK5aoGnD3GGgqHeHmWBwh6_WAq90ITLcX_zBeqQUgBSj-Z5v61SroO9Eang36T9mMoYrcPpYwemtAOb4HhQYDj8dCCfbeOcVmvZ9UJKWCX2oQ\",\"dp\":\"HW87UpwPoj3lPI9B9K1hJFeuGgarpakvtHuk1HpZ5hXWFGAJiXoWRV-jvYyjoM2k7RpSxPyuuFFmYHcIxiGFp2ES4HnP0BIhKVa2DyugUxIEcMK53C43Ub4mboJPZTSC3sapKgAmA2ue624sapWmshTPpx9qnUP2Oj3cSMkgMGE\",\"dq\":\"RhwEwb5FYio0GS2tmul8FAYsNH7JDehwI1yUApnTiakhSenFetml4PYyVkKR4csgLZEi3RY6J3R8Tg-36zrZuF7hxhVJn80L5_KETSpfEI3jcrXMVg4SRaMsWLY9Ahxflt2FJgUnHOmWRLmP6_hmaTcxxSACjbyUd_HhwNavD5E\",\"qi\":\"wYPZ4lKIslA1w3FaAzQifnNLABYXXUZ_KAA3a8T8fuxkdE4OP3xIFX7WHhnmBd6uOFiEcGoeq2jNQqDg91rV5661-5muQKcvp4uUsNId5rQw9EZw-kdDcwMtVFTEBfvVuyp83X974xYAHn1Jd8wWohSwrpi1QuH5cQMR5Fm6I1A\",\"p\":\"74Ot7MgxRu4euB31UWnGtrqYPjJmvbjYESS43jfDfo-s62ggV5a39P_YPg6oosgtGHNw0QDxunUOXNu9iriaYPf_imptRk69bKN8Nrl727Y-AaBYdLf1UZuwz8X07FqHAH5ghYpk79djld8QvkUUJLpx6rzcW8BJLTOi46DtzZE\",\"q\":\"uZJu-qenARIt28oj_Jlsk-p_KLnqdczczZfbRDd7XNp6csGLa8R0EyYqUB4xLWELQZsX4tAu9SaAO62tuuEy5wbOAmOVrq2ntoia1mGQSJdoeVq6OqtN300xVnaBc3us0rm8C6-824fEQ1PWXoulXLKcSqBhFT-hQahsYi-kat8\"}" );
            result.Add( 3072, "{\"kty\":\"RSA\",\"n\":\"03u6K67VN18OzIRZdvCC8F9iOVojF-0kk03JQ7rfwumQMqgxLYOmLkrqLcyJV69XYt32LeEesuwuz_zJbQo9gg4T1pnKJSb-l5xoH1rfnihdc9PyMAH___d_zv3Zg9vdusg668eO1oqS5DtAe517suzwhcMIyCsFNx4aBxCDiPlEwzYISwMQHylt-4d6mbFsqJoGK14WqxTOyv0mLoeeDPs9gmQulGbyjYdZJgqjeRBMuHpXgjs_eMwHuqYmWr-jmbRMzBJpKoAgAJkDxkJzJ7wdf4Bq9HrutVspXqw9ZWh4ImIq65Rm5Mx3JDlUNdlYB0jMyDHpuwAZfr8shACty2d5bvlMnk7aYKngCbX2ZSm6BFInA4mz1eey9Iz8uxnfyEjwaYJCFRDy44P_8aymW4tsLoLYgWnF9NodxcLVbhJjBqsipYiUbvW6PUUB4SVtql4yI3EEcZsFFVAVOnms1sXGXK8vm9V9KU1RSWqF268jMD8s-QHg3a1WmooX6sw5\",\"e\":\"AQAB\",\"d\":\"WKU3m6DcmamcK-jcEUluMTBiHTUlmZ1a4-3Ki7vUmEBLo5gxiOjyatwW_dyKwzjpkbUFQCTpN8ldM-w7SBvvPUkGUsFC5MDMHaO_V0lBi2tTBL6V-T6VXmcRaSOpnaY28liErhkHS_Fo8gbOGCKiW5UKmp7uWu0BciGJemWXJP6LLqJC5qJhixZUFgcrQioHKELrjBkTumFt7tMewokxHDLhjPrONYFTcTSHDzWNYS0OY5NQg_OuvsUTBk8nq4lA2GSQqXyM-B2gbwG6pLSwccwu0x3Fd8qurxg6TSGQAjh69Iyb9ZwiHMsx3XLV95Jmqc0rcEbCzLZUBxX3daGjshw3Yd3pzEXqM8Mz-58p835VPhSMlZB_yvtP72o2QiKybhq1ob5Ygt7hqlqe08K5StN2rzJJoFkwivhfC3_KDX7XSLEK9PzqPaTOkkJu7y7tJgi6aC6Fq-X3fgeLy20LsBKV_SF4Zd323IZ713iGJFJo0f4mDUXfQmU3wrILk40L\",\"dp\":\"V5SlApD1a0ng5XrzEmOV2EVKVLcS7Z2j1WYLVa4BMxSsi8zJal_v8nllEN8ylDTWKCZt6Dg3fcHtOWKYGe7e2fBMwSsKcjPI2aFVHjI18ZMbC1m6eHWK81zlTQ-ZhgiRMXQvsRCX6Qt8PPvqfV4j-YILYfgJbQ_DRYEfJzq9JCQjFwGUiSoZvOBl9jQMM1u4NmOnvodwf8Jk4Oi1DC65U-CjOC7D07eDPNv74Pog6h6x3u7Z9S-ITvP1NX4h0_ot\",\"dq\":\"rg2IrHzp59w8nZbtd4NDk_stRB8xT6T2pxpH3LhNhEbLrmy0sF4Xemm8frlgRWeEn9dUV2nzveorEJF57bZ3cclEqBGtD72y_IRPZTPgDcYhc9l4xKJkJJuA3yWcQ6eHZHjLAZHi9PszYvFiUx1veHU2S_f7aGKjO14n05wb9r-YUmIKt7AVwK94HksflvNIREa867E2OL1lIJiX3azkyMgTnSHvi0bwgdIGp6uPdDwVW_qvvUmlFinDWflgq58\",\"qi\":\"Dw0f0UwU2KN98stNeuk2UVtG-GyKjCxSSYocGBlShsXzxeLn2faLSkkqhUVicW4o2PmedPDpxanDW2Gl7osamaPb25CodPS3JJxeHWrJ6hGBfKqvJnysZ-0zL8wVzwuNLc3VL-jlCudFfGK03MBapA9h3qjAFFhHZRgLH8y64MimARfh2gLldZ0FgNF9zB4yxmVzvpOng4XRJGzSBKdf9QbuL60Tia2rWR7QU2GtbrXlp4KiNZspZuzmBLZPaa82\",\"p\":\"3lnk-l3lG3ahUzPzhInjwTJEDRrAt0YMhpLmO444TNs0MD__RxRQO8EAhLGCuKaNJmKOg-D5-Fup34KBAcFKw1vCh06PNxoIbHmcY1KwrlA3M_47pK74sK532429sM2N0JH9ti4QjtcD85__THeS6I5g8x8xdSH6sm6ubOiUWUQ96fN10pDv-9D7PuoHGEGlndvsRE0GwWmBIjCnIbxXN4kQsE5YXbrY_WTdPXxwTb8F6Cqc2WXIuhZLlSqd8NjD\",\"q\":\"83zNQcd3dTEpO-j6e7hHeKYghVBhIViD6bXDzD3IX--maTnllGMD-xxHNzOURwl_VzwWo1Al_QQSKDMeEnNDXhSU50qbdhdyVDyRXQuR2Fb9hN5SACX-SiPgfs-2buJVZh8JD-VFSI7ou6eMQ9h-uIGnhoxH3vCs7dJgy-mHGPsvqTypaIo3LHGfM21z8h0yqgyYwaanv5UllaustjvRFId_2oWqNtrn6q410s9W5-6Q6xqkrW2m_lUffu7ViRdT\"}" );
            result.Add( 4096, "{\"kty\":\"RSA\",\"n\":\"mmpRerSZYY4Xx_s89Qn3NMAmJOW0TXtddwjdTedA2CITP_BQW9Q6K7ZEKcAk5W8KwfvAYEIDkWN0iKtoSiBmTJxgCqpDI2MO1D_JJXFP6Tovbtgj1FJ8Ai90w04wmxoCdS9mFC2tE51qUWO7frJpTGrZqVAB8UMH031c3pUPzWedGRvKwj7J-Awtg_IoByaK-qoyRlwfqm8WpHjg6R6Fn1aJY3Fp62l1F3XGayUgqoJmg0_YzYxKpz9WDqIJo15sbyQEpTG6kRybD8T5O8908JU2d3KPp7GOKDNpai5wdaK50QyvaU3BtvKI35IaK367FSVPEZPEoAGgUBCoLXx8N16XHVgjspSMV6NnjBEoehr4xU3nw4cZ-09yZSXJv5FGKmg4pkJGCHQwUfA3XlWNZSPYIgBByyjpMe6gJt_RDBhkkYGVddkwn4HPlMIk3Gi9wzMLuVcLNVeq5k4Us3YsaXdSPI6LSfoosu7mi8qm2JMYlFzbB9_FaxJWqgHlTRSiXX0XNuHPMJoBHtKwh_7VXxiosim8EvszF_Is1ttF77l5lC198slQ5zsZ2XM90Ln9UV04kAyI1jEegDiW37uVSikt-VKyVKSZg5lgmp16CevLnqD2g_YD6fJMmbU4QmeVELhZeQc7Z_XGH7lM1bSeiAJ0dKlDKDURnA0h2LQfquM\",\"e\":\"AQAB\",\"d\":\"D_CvEz5WzGihW9Y7p1qtV5deWKtoaXc1YXcGIWdLR68nfY-OkWw0dRQOWqD92LwVyDX3g02ilfzw_WAfFp0xnPGnmHJAbAQVy83_MwuiIYQNfCEj0bnnbfJS2LaBngFEBQTXl3hU8ulqcuxwtoDZuIxvMQ3pUBaIqvRjWeGEDW2Hch1vA45ScHYRXMWVYZJBAToAkUgr8f7LFOoa4vXGUCSGxOqNnJejrBWkXfsp3BrfVOmGipwo42BOae71lRUc7HwzXo-Q9YSWcpJK3Y8U60umoRNacQfgkkB8aVGnRP1_YRfbeRYQdpT4PDFrh4Hq83aJKwSuD4vGGNMfXqgIdSWhREajFDN653gDIIrt1BPh-snE9HIr0QWJmGQTlKTFfXMEoHx6mxJgUmzZSdQ9BkfCYyInpevh2piUrdpoAEEBapYyTmEHetutMm6cpPd4EK7-yHf3f1k1Rx-HIkiN-pLPiy6x6sRS-272pRNJUjEyRr7QIxgv2rVmQpFd3HZIsmTA9e5HnEH88pbwzqckWeA8nCpe6vr9uJ5MkIMaZq1Exw2bL8TjezbQdRvFm6eO25ECBE_YRuTm72hWfkn1Aocz5_RrSvW6gjwXpgTB6ScNyDrrmo9Kz8DQA7uvRvwhS48fceGGqEt_02qtj_FY1e8Q-XLVsPz-oafqbrTPI0E\",\"dp\":\"D9PGN8qEoUjBFIDKfuilcKwpU25pLnGsgnlzXxORZYB2T1y_DzHVXoSFkcOcFfn2L-AWFSUQmFlt37ULSoSTi2J5KzeydzXfkz4CauzqyEEyv1Uu_FBM6ZDb14ZkYoS8B_vWx7ow99fopwwObs5LH9vtGmiAJczVTNuwUQd_8uRXsWdoy2Ku8XLmNBaxvpXjzbs3ooKIw450PWB1qk455OrQ0k2dqrbY5VlOjgBEk317yCamGbPy2AgC4EnXnAZ0qJ5gN-mJNbjBCjkS0MImMWphJCrXkKMxl1OURKW_ujb7B5EGXcTmJuFxu8uE6_SxDrhmbCfdrwnfVdQXIGyGsw\",\"dq\":\"xEmqiGWKIuuyMX3wElvw2E_qJfuJ58lyAqQOYrM8ROsk4iaV9yc9G57pHsLRdiCYYrYDoisi96LdJ6kScAcS8j5TAuAdHq2riI0MOd-lZr6I4S_3pnjO3SuHYmCoFagnpIo7QM9-l2ZguDrfCjs7PtQZqMWSg-ncHYrHDsbynhe9GPdes01u4XZ3Y2xoYBDJX2iCXVNKJBUeYwlLd01p4eE1O_UkI8GdxQDMOr0ifOjWa9HtmY13Q8yvWoDtA4UX9Ec83mB3F2RWi4b-0C1pxSifCzeo4VZ0uOZ_aR4ZKfx7npWseE6F-Ue2vPx3qnfZQAkXaqJPsR15ZU0ZtJqAEQ\",\"qi\":\"fzpgNvwBpXBjLkqVkKnGD20kTR1lnMfXKJHk_iGE3UY7FVRSGXiUWpRWo-Gh0Lq8jJVXddX3looqv-v_9uKHja2JkHToWSkJajRznFHvz1pMfs7d3Nr4puumuNxJC1rgktnOIK4eikNxxHJ5Rs6TeQOwWxRbmywMiEeUQAwVvgaaF91g8FmNUE4C2BCpav-1fKkr_ydo1j4AgcSaCcKuywPBvp2Fznf4UcND_1vyZVKhSBbqbu6ql8vb9zEo3E8AKsrn9REji0BnA5kHk1Ps7GiQcMSCdazwBq1kw3DYD5Mt4CuyOdg6Btg-MVDXLLS0Dw0VEvcPhi7ypUlpl0RWcQ\",\"p\":\"uFaIjld13k5EkpQtTJ6zw9Zq5QJwaVBu1RiyXTdji8ysU6rxk07HAsUt049BuKqFv2jdKVDsdL25WkIao93hstdl8Kl_7XQX491_1np1hW-NvapNUYo5UUn-SeT4zseoIu8n-GarEAI00U8Xj2M4pewd82zlCQHTCXZiwbWGF2XMfPqvpYhFtEoMyJUf8z6qCvcZgp-neJJNbLgesspHke8--GwYN-QjrUynkmUGZ14BQdnLsmNLeaWY7A92sLSOFYVK8XnXSzOUld2P5JCgTenS5Na5UpuaY1K8od8rci3TE23Gtma5VhqBiPOFgPXmlkpkBe1uRn84iV5avYQfdw\",\"q\":\"1nHaNzR3mE6cyzPqsqNxT_FDDzMXHCmxW8cO_9GzmFBW6MhNArPEIV9BFAo-NRjDKMYKPin67MlyiLCMN-TWTayeNeuvw_WYwKfI_t9xuyf1nsW-TsNoK4n2d0kwoB5OEH9pAtQKv9rSZl4WULePldJBF4lPBhQb0lmRu-HB_SRskZe8CdDcm-gjwLhoP76gstWN5PNzgrPTpxBC6tHdWD-ZbkzIGWzCjxNHAnJkUAEsy3FVllCtO4pMVXz3zupaVzmDlUQ34weWXqkA-C7QgUPNoCD_M7PTNJKQpnTwlgk1Jvn8v4FDrpmYvv5l8B9swMPtlIi9xADuuEg8gO5i9Q\"}" );
            return result;
        }

        /// <summary>
        /// Test keys where sizeof(D) is smaller than sizeof(N) (this is a valid RSA key, but invalid for Windows crypto libraries).
        /// </summary>
        private static Dictionary<int, string> Get_DsmallerThanN_TestKeys()
        {
            var result = new Dictionary<int, string>();
            result.Add( 512, "{\"kty\":\"RSA\",\"n\":\"vhpdXBXrNY-eM6UrzDP2c3CvAfnaaU5srQt3VXtu2FiST7Yj2Ajb9HbLCp81Hda9gTgOdCDnZbNce8JTIYTqxw\",\"e\":\"AQAB\",\"d\":\"4KFGsAk2ZZPO3DfQCPtdvArqwOr7qnOA9vkViWzRDdGN1QVBVhfWy2W727wEDF_X4eZwjBvEoK15y-kPRjgJ\",\"dp\":\"LeCYlBJq8X_Fk21TROnIN5LE8BChx3PWfd_B6Cq_OhE\",\"dq\":\"igsxJ-2iGrvYhO5jSWrVZi9D4X3hpZQD9XaaOvJ8HEs\",\"qi\":\"pdI9RLvUe1H71_NGrtWlEPVL0hEOtKqiTZA6QnmBW0g\",\"p\":\"w0NfzrSJdWNfQEGMp-91srUpC7J9OZWg_zTEDAw579k\",\"q\":\"-TwWyZ-bLfYFvwnW_sRDg5kTZIvcHOYe-Jd8fsgLq58\"}" );
            result.Add( 1024, "{\"kty\":\"RSA\",\"n\":\"p-WITYuYitN7QwNxqxHj7LaWUBPr50GzaILe6zxPFMgebyYDhq4OWfs6eQPIhAhWYQENXG_NEyGcgfClBPM4u-iuT3zI31UntUadu_tbiqfbDElDWBHvYz5x04BDu-7EiGt1T_-dL1Ahpl6guh-1pZuQooxGjY2OJ6WAiEmbE6E\",\"e\":\"AQAB\",\"d\":\"vflPQRmzK2IfwV55lMJUI9kgO3ukcbGQTwZwixCyanwFSRQPk_9ePcexYec7UNTI6E9IeaSyEUj2zhB8qB03vY8s96cww_dbpPNpi4KdpqDo5cWxJWhNwSR8vAmxRGcrNQcun771t6v0vw43ZnFrX6hyrfQ5Vm27h6RygGWAAQ\",\"dp\":\"NCUmt0nKQu8xRYPUbSIgRwfLdPS49Q2ERYRELAl21xfYfj2xcZQNEpxn9clUGjwx0s_SBK0UO6hm5CCiGOrJAQ\",\"dq\":\"wAgkLAxQ15hBfCrGhHfBIryS9Nl8GuprxGpItcIXNcPXEEMWEv1ZuDKzzEXsJJCh2PwQlBT1UN9U-YAUVOzEAQ\",\"qi\":\"hp6-iy4epeZaM_TqirDWWueAQaRbsR-NOQ2xCXN5cN1TTm81hTK5uD7QmaXQyY8iS0qjzh6KezDvZlAWp152dA\",\"p\":\"uaZBl20p5eAESw62eSM7bUEejNpBVPp0o3FINZeukYEplUfBdslaxCozpzxTtsw2Dnxzi9YRsy_DpqejWGe3oQ\",\"q\":\"54UVtOfb4z1uIc43EYs97Teoybw8W6N7UgZAAFouRjG-sxJ3nrNPbCUI8qNVn92E_OL7rqDVa9W8oXthsUXcAQ\"}" );
            result.Add( 2048, "{\"kty\":\"RSA\",\"n\":\"stpKx8TkLLmaX-VflCo3uR5DIHd7ILTYvCD2vxRzP4ppdnbrafkP9syHmPZfX9RfhJtojgEWyZm894bakipbdYQa2EC_UCzJATRU_QBjcDyMFz38JwVYmtS1Wr2lxnt-92vKlSc-J_IEKV_xeq6LnnSw8q86ztvXVR2J6HcTemYiKjZPm3bFo-GxeqNnigIkbPsVo04bqxbvF1VSU5y5pkFazifbRcGZhT0NlqHOefMNWoSUoj5JDD4Lt5weK-wbvTBZFgqlFruw59zg7AaZk7fVcsbj0SDqqS_EYHu8nWyQ3qd3W8iBAoniHbO2DEQVN7Vy0jmJ-87TbekNK-M3_Q\",\"e\":\"AQAB\",\"d\":\"9q_tDp1qGxMYjcXrjvF46lxTOif4-T1EgJ4qHmQwK42kHHTqDI3IKlO95vBRnFvQlsoqUoAuB6_rp34MlPTXZIxRrcIG63VAlk8YHXhSFcltcKFbEBDPpYvw_reV1hSziypuwX54vNMstxfrRzISYWLFelzQ2edgAOyjl3_Zd3dLel57fhfZmMU6x3RfyjfiKgX_UTX_F9k5lnf-8rlsEXouAXiJ35RD1p2ujcTkyev6csKBQHrIfXsvVKjp91aAnNnPe3YLce6sGHodOhMT10Yjlwb2qY_yEeAG2TFoIqaRPPoXo1KHi-SkmiTVmb3geg6tpx1oerym7ifQt_Hz\",\"dp\":\"fEUUucGcayxlSTxQTC3_isJlbyQxnNTRsX6EbLq03UjbKApPgaJzDvv6NumcfO6kv_tq_dPtsehTg0MprZsFL022rBG1SaGWumuL85pzNmT2ZSDkO-YExjcz8D8mvhmfUhUcRm0SsWgWzY7-rNBUzzmrj7E5AX0cyc0KwxnRRvc\",\"dq\":\"D37gjlNvSiCa7huyaG9XlsnM9xEKPMF62O0n8OoihCk-IxQl1E0X2PcXpk6kyq5GwH8kTybzi_F7MtPqGocBIub3oCuGArIfixMmfb4y2iLjKJLwYswt-uD8mfoPplWBUjUH_52F8MmwFN-bP4KIl4b8MRl9X2C8dmxhRsyef-E\",\"qi\":\"m1GWHHlmCwFM5TI1S8T1TEtp14mXv_KWX_TTl6dV3AghbW3aR5KoQwwyR4u12dxE_cMCVZLUjGMcwLQ6L3qMY9ybVkOSGj5CkD031onLbDsibhzrInfEou7fPKnrk498jk65aopKAzY5_yiewjcpSua41rw804F4aqPQtvPqnUQ\",\"p\":\"5Kzke7UlRnvo5SoVEHhEb17CtGpqk47ZvZlThrB59zMspqgfp82aVEAnd-p14wa0QBbZtEYmukiuQzK3zV90dG_5Zl3mML2mex4kUmuYeGoSUM1bKA95LxLtVC-xMzAw9mDeKa-EWxPN7Q0P7zOkmCxMSeXpotg3bQiFlR5t8Es\",\"q\":\"yDlXE5VHwDJTHWgz5KGD8YirP7KJ-774cxQ7qbHWulW38MV_Nw_0__JNZUOWrchZlBU9Sg6sKKHf6iabyFViN1LnU1a42AgwUBXiKjr7k0SByjNURuSU8wbWj0a-m1BV_eXdgkwxLTSJNuYp8veGkIiqzjelMSqXYIwZMfaTm9c\"}" );
            result.Add( 3072, "{\"kty\":\"RSA\",\"n\":\"nonCaPtv_9mDM5G_AJUbn02E_hSsMHAqjX2A6altPr8ZQSPmXfr7MLstgf0I_kJfMTJnZ5XCHILRXmcyvm1Tb0iB7Wq7P4DNavYW2sg7iZxKYSvi-SFbKPV5DMn-pyOXCrDa86pQez7jwTgwlh6sTmrZhHsEPZY_UvgIu28roVp176gP5h0ZCXJM7y1Qj3xQ4GQjPrJe0NwlK80JvQx9UucUKGEnrpedOm8lpPMKKZSGUW6pZ49psOvhHAVjk2cSBR341-h7-AQvOG03dkjRgqPdvo1qM4xvOCdiDQ74dmWac6fpWmVfhBHMLqqyVpdXzZydlSQH8fkTPxY2F7JvGHCZATh-U_1x7B7YRkm2K1Cj_6Jww6lCXir5ptXcPCMYiMc0NwzWZC2FUDcMZOjOZNmFC3Mbyqo2fzbjWol7BTJc2MO3xSX0vcfu2rsa_qyiDvV3LE7ZhfTkSwhknsdKHSY0wiSaUEOeHZgPV0acc1V4FqaDYxn6KdI58345KgCx\",\"e\":\"AQAB\",\"d\":\"tbUEiM78eiy-SUetuOfYgP2YhfRWZtjTQi2r_iRH0g21ebPBQHYpm_DtInpM6cmo0U-0CkWF9fz6JflMxSBeQMNvfMPtWcYxqtE5Ngke3tpYuzGnNA5x2BWBvebGuJ_8vi7Lb_wFF-fnoyOD4eEbccWFtGegCfaVyG1WP34Wbm6q6G73ygdlFYQBfyEGShlyQ73Xp5nz5-8VAN7rX9gGIWmORmRp1vJvLZ-2xcLKIwjYlP0BAnFH8j--Ax_UwV2fZn4GqrwEZgFIfZdljNBTuVIh1Opi7GDEV6N-HeBLnm2iS2FzVlrgDOec9qaZA-nW1Jij6fJRip8NMiFwn-KY8yGKGW451kSDGhkZPCswR2EAzUCvJ-aY1qpyWGI25JAqdt_BAC7Pak43S9LK9EhxWsNXyuSUeT26Ww7bc_WFhfvp3oqcKeoSAsv1bphIyba9-E8_hwOJx98XAeeEUJZeL9LUxK2hH9P_w6sReH3ZWFBQ-biyYs7H7xqUMf8UrtU\",\"dp\":\"HDS-_oISd7caBv93rVoS2hUG-xGg5NfQEWFHdFtvBxZmYOVqAEdJXpJ0zrd4mbAaDFfU34gHeqT2ykTaX43ws3LUNLsuh44Xpm_7_mMTybnQ-RDb60uHqO1bx9IxE0yYJsEn5624_ffy1hvBPfYJH3v9TstkKAgb4UIClQt9dcW8pl2YQ8cs1dZWh5bf5iTqozJEpU2ioE5U33NqyAKRGfKK20VRuJTbAAQuAIdnDhbCVaVXtCq2KRzu-4MmCX-V\",\"dq\":\"bUCyYwav_PAEfJofifHi2bqE9gcSvidaKl6tSPjSmUbW8nwYCzhL4MvctkVzlURoM_ypB7gkqYlDSmJvZ3A6hnz_DHqzYM64UUzvRJT1pOxkKzsR5HhLKFHGG1oS3QEdNVA16aUzL0IzWOCe7QoVKwf1j5uK4UOU662T28AghtCtwnvfIh3iwdDwD8vh6uXuq0rQO4IBSdWvhqF6RPxZ299G801M--43dINC8sO91o4rGtyEperNxviQU0w4rLOB\",\"qi\":\"xd9gGpIq-6kASoh450PHT53_X4qS9M5tyjrZ3NYEGQvgtrf7KLhmSiLA4NRWbQkagXxIvxJy2noenO3-GJqUbAO9tHUlKJsp8Q6Hrh72UQb28aofOLBU0jL0WUna_W9M8kkCQANUo-c3fJGEvn12fhvemJKK8mkgl7Rm_MWPwmhOvzQOn6HSIQn392i2wKUzhuuQ9d3waulGLottx1ZVc6aK0QU5AFYb2huybAB-i3YX0CExb_KDQeWN1rfBmKVN\",\"p\":\"zd-lUFiGn2vK6liEbaVl38d27Af7ZQjV-vakyHUbA8aQTW4Mpm0-dqheO9Lu5eAeAZfbCBgmKrjZWIQx9nx8diLUn01FrF3V4Dp1tDD8oU3E807Ny-xayr3106LaCZH9L_bWmOwXBy7d0SUTAjtVbwZhanONtioFzFXBpehLE62dhqoOsZt84N73W-5PASKbKPBmZjD61nygZYHfxCpXixhJJ2Dv43LNPy94pm4Y9gtcBDXeAD1sBeeKUcXwVmCd\",\"q\":\"xSOibDcrGxDtJIeHW-wEJEuM3DjmjLO1sXU6PvjAS_bd5RFxDWwzmjfrQ64xzzl_YexbJ0ELvY-KZqp49vmyy9aJpxbHlKcVpyuJCGALPALFTDsS8Wk3fWJxF-jeVH8rdrv2e8r5JvIIwwQ6SdGNV_HLYyMlpPq-Pyv6pwxhCSSvKZG3lYTiOad8DtuV7RvsRd_wtQUqQuzICZfNS_HIO_K2YDoxr6uOHbxGTS97j8Kpc8LfT_QvQ-95NE2sfxIl\"}" );
            result.Add( 4096, "{\"kty\":\"RSA\",\"n\":\"ooDd5qAbThO1HQttQ40iV6yTQSXjyegzUSrknOe9dd0efeoZHxmkaNrWZt5ZbOV9tDZaTdHx8XctrA7_lfhi1UcRLrhhncGQXHZrqrdA6W6LIXSZCMHPnWvkWq-HCDR58Ntn-oO5iUD0BVRXPDRzM9fMNoBcaHerOanKHJ03Y1esmhxEUTDVsWyJ5K0d7EgEok7Tyr1_T9ycxyfh3qR8rqLokYRDvikYu9BIevFp5jM4KoJ4q4NwekSXFuvwrPzDLoxQaQwR4mZ3FOl9tDiA-rz4AV2yrwLuTL1zBCi6CfB41oScOzerCU0RB-adu2zvW6mrJu6IY4x_aU5Z9W-RsOS-hnc4OHFq3FLf1eY8lZDR1ZjrRrjDFbIVgi-87QaBXio0CXmFLdcSV3sXWKDMPLdwVCZXhSounwHmJSD7rte6cFZfY5iTQvg446aau4LH3pBIbuj7RvgEEh07qugCOQNipGoDXq13CFX5LnEqGKON5w8S0MRP-zcNyK6BjHBy1N1cMVUoH7EtFMkRegM9G0ELunaYMKzsefJQtDqUi5jPr24mswz7oWAhLh_uCm-IAQKKrBiZxAbfrfz-0gAmEgXHZfMdaqC7FIAQnFhNAhblZFxo_tJZuJ60Cj2_bOJ15WfVSQb51JfTm_OAvZepM9BhUT_cJ9hoySgWTNTDIFc\",\"e\":\"AQAB\",\"d\":\"iKpx9NB-8xFswE1b4_Pn1G4CNq6NZFrKzcVesjCZ2WydhRSpC_7Rk12rjKTZkG8KldHtIIWKQaLf3-3wbBaTCDIJWvS2V0NZcmm_Iu2VKe_nrIgWLC2gIRGCeyiKTkKgsaMHtfTfLqkk9vAROndIa9FeOnfs2SIx-DNTeonxV-fkWurRVqo7dEi6fH3oX7Vk_RvoAubCRRsrJYZLiQ0ANXiZhcg2ymn44y6U-Z11Jdgg5Gw8dmjHr6YzBPpo7xM-Rpq7BZ2hBnomRbzlrl8KGjw5JCApDNO2_J_xZ9rYm1AiUEdp6f00J7f1gS-MEcfYuSSrssWC7wK6JO_ZuEPPwhxopFi7059X65McjSiC2seQ86fWzjoRoxhrlw_zhZAKvI6_KJIswFroYc4dxFJ32DULco8SBceqO8K6goQ9Ck_2okxbK2mjzIkXqrLDSxOIBzDVeFsbSuC1LJFVFsVcDz2cfeo1zjeobfMp6vjm-fNb6fyRPVsR2mWDMO7-emQEGBqM7LYU1TZL3tUYrZ29_DMf3TQqMXkpzg9qb76PV8SiHxVBn2rlS8paIgEaPM_scLS96Zp4svsGJeCymxqhl_4zmvmyh3NVuto1XxUzfkmtjJttpe_0f1ev1yj9IETa1CYIkgofWKuSQQbbj_ZcBmAZ2A6nC6kR6DQJ7puj4Q\",\"dp\":\"IBPEt1HvFz0MTx7xJVok9tHcqw1eFfh1oav9RJqk1lkKr65O678TbodplvnCQTnX6iLpUZhi2xQqmLkl-Gb7H2F0aC5r96c-UmZroJAxYbY9fLSTA98bPe9dGcGTC6eaEC6dC2zotJd5vKsq9t0dZBqXT4zJPSk9qdQjdZV43VIbG2Kjs5xHFsQ7SNH0AqIbXuougZ8nQ9TRJc6iATCODCZPRRH72RE8Sx-o44E2GImoWCMj2esze9szh9aCTsXcTswvmRzi3XWnBuojcJCY3QyrtKR0T32-wPqN-JW2e53MzCnSgI1iADuLG3edKpbOV3hDXUiksDfo3LmC5ZPP-Q\",\"dq\":\"jSa-u_J-FBwzAzLSFbAhvWMbZmFFQaWbSmn5ZbUrpLU1q3X10YPMprHT6UKugxlGv8AntWskIueqgKtKSxIGrV7ptLQlAFRrgggV_oLK48bwjQ5or3TXx4QlK0mvuz_GeHIEhVEZ-EdGLDKknQau0p6ElOGJCcl3DLy7IHzSNqviPCZWIe-tjS6Zsx6IBnW0e_f94JhJ-UZv7rEvH1Up-Uxv5gRhQ7RhjrcT7dxcYg8x_rS0XMfsm7fN00hbuNtGsPvKmq9pieHnILl2P930C0J_OFan0_Ff1VJ05tZ0fNb9ERv1H3zhC2I9Z0j2_PEaUHocdXW9RY6WikzXtFn54Q\",\"qi\":\"eer3S9jxQ4K4dcllCWE2So0uoQTiApD3t8srtrfn4fzxRGIZfVHcWrV3vf72pZG6Uqg0D8x2EZ0MmrQo2VSv_oH1KKgS4u3NzTPt0-_MZ1c4Nhu3Pk8Xc42OT1AWItLJ5gINW-UwlApfkw95b_UMyUnJBJ0SWQHxjTLsxjIA82krl5CClFylyU8ZobZ7f0bFrvEDv5IRczHJQIUDaP9CjOCV6uMlgrb8xnSLUK05XjfAG_SJKDnIHi7sFlKDVTJTVRdQfXEnNXcUA69D7JAEvxJtx4aGZJyw7A1JPeIUC7QPPghY4CU3FaE-9BitTXYdSvq4p6fU-8bts-ijaWAS6A\",\"p\":\"4tQMPSxC_OkBjS6-YODLxBVPWvzTyWD_SRO_fdfSgadq3I-Ya1a1y-2pjdkkbtJma-n_diiPus7EzZxN03_uf2iD965ai_dTdq8t0wbLIQZ_JGhK7EgDdDHNpgbDC3QPPcgEQT3gcST3m17mF2zyqiaLRg1HwqMoaa0PLzQ3w1BWHHGOXsxBfih-wik8HxsDrJ_qOn5sI7CWHWI35uEnIdGwis6jKgPnl5Z8Dfq9pSwb5Hls-Fmk7p37AGNG9_BlVdzSEq-QeONJYSagD5Rsp6b3v-vq5TVRLFd6LPWy6pK9NYxknAFleOqMEjH1O6mf0_zDftcQQ_dpbDunJIkodw\",\"q\":\"t2cGlhtytojRtsqBnn3l_bM2bnR_76a86wT8-n778bEMZH3lzETqRkl-01LtKfe8ha50jNkDZ-X1wmx6JbZNqUoFRDAQGgi4Adhr_4l8SP577pibYPa-XHbEysnTKxfRTp2truSAsyYiUUMLqrA_tqgVk-TOLl8rMBvk16pMulcRk4-kMmXsHmms0oKQ_W9_NtUWHd1eO8KiSauqY-A8ARFjsvoAlDs_NcHW3P8FjLGuYu8ZYTDmE_LU_b4LcjpQggZnMjtQDSHk0bMke-HfKwb4lDEmwQZmJEKpdIN4gKZH8JNsHoYQuEZ93lI-aDgxBDWuvXT6MfjYGKnayGWfIQ\"}" );
            return result;
        }
    }
}