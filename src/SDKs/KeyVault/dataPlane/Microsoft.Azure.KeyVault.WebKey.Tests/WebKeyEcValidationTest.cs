// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.KeyVault.WebKey.Tests
{
    public static class WebKeyEcValidationTest
    {
        private static readonly string P256TestKey = "{\"kty\":\"EC\",\"key_ops\":[\"sign\",\"verify\"],\"crv\":\"P-256\",\"x\":\"IzSTOwCKbS-BEdPwVT0xGnW18zzgyG7CwnMDKLULyQo\",\"y\":\"K7m-pJxgWIjHGHMF5IZpWLasH6TizES9eidg--wQkSE\",\"d\":\"9hY6iHNcR-IuyacHOelfiCvjRWyfOscFVL05zJM4Ne4\"}";
        private static readonly string P384TestKey = "{\"kty\":\"EC\",\"key_ops\":[\"sign\",\"verify\"],\"crv\":\"P-384\",\"x\":\"5XN86Y1xhKo1GuohlWzcvoJmZs36USIFopOU1wha6qbtZzM2C1OK01lh8DJYwQsi\",\"y\":\"ZsI5YcBKzo-0d5lS3106nYPshOi9LcCecNJebIina6fw7Ab7TD3f3fhNxEaAE6ja\",\"d\":\"6g0maM_o7vcYWJzPMwqE3l0v2vsyjWtOsvRyAch44aZLg9IGaVEUu6Ol718ICyWX\"}";
        private static readonly string P521TestKey = "{\"kty\":\"EC\",\"key_ops\":[\"sign\",\"verify\"],\"crv\":\"P-521\",\"x\":\"ASggRFEA2L_FxGjnU5FNplPHBi8tU0e2L89ZWro4ZpDYvBvel0gjao_S23fuNFlhufLp5kePdGbqujy45wHKMjMR\",\"y\":\"AFDVBsQZN2V1lox2kMCmqWL5Kn4f3X0mtqnBLWgPlOSl6l-tMDHj8gcLnMGJZNarCKVGVrdjhmK9BpbYy0Q8Omnm\",\"d\":\"AJC_2pp8DO_LxfFuC7yMfd7TGD51f8ydJgHy-Tf-37NBToBjGPo6njEcrppW1QSVWTMJpjfVWJb6x24YZQ73PP04\"}";
        private static readonly string Secp256k1TestKey = "{\"kty\":\"EC\",\"key_ops\":[\"sign\",\"verify\"],\"crv\":\"P-256K\",\"x\":\"yBMUvQwthIjbdvYUC2DDDs6I45dqG0B1GQ3-Eg5RxXM\",\"y\":\"KGf5oIzA7QNhZ8gXP8LSQfZKSMsGrmcUphyWpD2ingg\",\"d\":\"qmWUH9HNAAYzeNrVYbtoVlrnbiRIa2jDZW5YJh7OoUs\"}";

        [Fact]
        public static void HardCodedKeysMustWork()
        {
            if ( !IsCngSupported() )
                return;

            DoHardCodedKeyTests( P256TestKey, JsonWebKeyCurveName.P256, 256, 32 );
            DoHardCodedKeyTests( P384TestKey, JsonWebKeyCurveName.P384, 384, 48 );
            DoHardCodedKeyTests( P521TestKey, JsonWebKeyCurveName.P521, 521, 64 );
            DoHardCodedKeyTests( Secp256k1TestKey, JsonWebKeyCurveName.P256K, 256, 32 );
        }

        private static void DoHardCodedKeyTests( string json, string curve, int keySize, int digestSize )
        {
            var jwk = DoSerializationTests( json, curve, keySize );
            DoECDsaTests( jwk, digestSize );
        }

        [Fact]
        public static void RandomKeysMustWork()
        {
            if ( !IsCngSupported() )
                return;

            DoRamdomKeyTest( JsonWebKeyCurveName.P256, 256, 32 );
            DoRamdomKeyTest( JsonWebKeyCurveName.P384, 384, 48 );
            DoRamdomKeyTest( JsonWebKeyCurveName.P521, 521, 64 );
            DoRamdomKeyTest( JsonWebKeyCurveName.P256K, 256, 32 );
        }

        private static void DoRamdomKeyTest( string curve, int keySize, int digestSize )
        {
            var ecdsa = CreateRandomKey( curve );

            // The constructor must accept a random key.
            var jwk = new JsonWebKey( ecdsa, true );
            VerifyAttributes( jwk, curve, keySize, true );

            var ecdsa2 = jwk.ToECDsa( true );
            Assert.True( ecdsa2.KeySize == keySize, $"Expected key size to be {keySize}, but found {ecdsa2.KeySize}" );

            // This call insures JsonWebKey is not using dummy or constant-result methods.
            DoSignVerifyTests( digestSize, ecdsa, jwk.ToECDsa() );

            // Do normal tests.
            DoSerializationTests( JsonConvert.SerializeObject( jwk ), curve, keySize );
            DoECDsaTests( jwk, digestSize );
        }

        private static ECDsa CreateRandomKey( string curve )
        {
            CngAlgorithm algo;
            switch ( curve )
            {
                case JsonWebKeyCurveName.P256:
                    algo = CngAlgorithm.ECDsaP256;
                    break;

                case JsonWebKeyCurveName.P384:
                    algo = CngAlgorithm.ECDsaP384;
                    break;

                case JsonWebKeyCurveName.P521:
                    algo = CngAlgorithm.ECDsaP521;
                    break;

                case JsonWebKeyCurveName.P256K:
                    algo = new CngAlgorithm( "ECDSA" );
                    break;

                default:
                    throw new NotImplementedException( $"Curve tests not implemented: {curve}" );
            }

            var kcp = new CngKeyCreationParameters
            {
                ExportPolicy = CngExportPolicies.AllowPlaintextExport,
                KeyUsage = CngKeyUsages.Signing,
            };

            if ( curve == JsonWebKeyCurveName.P256K )
                kcp.Parameters.Add( new CngProperty( "ECCCurveName", Encoding.Unicode.GetBytes( "secP256k1\0" ), CngPropertyOptions.None ) );

            return new ECDsaCng( CngKey.Create( algo, null, kcp ) );
        }

        private static JsonWebKey DoSerializationTests( string json, string curve, int keySize )
        {
            var jwk = JsonConvert.DeserializeObject<JsonWebKey>( json );
            VerifyAttributes( jwk, curve, keySize, true );

            // Serialization round-trip.
            var json2 = JsonConvert.SerializeObject( jwk );
            Assert.True( json2 == json, $"Expected: {json}\r\nFound: {json2}" );

            var jwk2 = JsonConvert.DeserializeObject<JsonWebKey>( json );

            // Equals method.
            Assert.True( jwk.Equals( jwk2 ) );

            // Equals must consider curve.
            jwk2.CurveName = null;
            Assert.False( jwk.Equals( jwk2 ) );
            jwk2.CurveName = jwk.CurveName;

            // Equals must consider X.
            jwk2.X = null;
            Assert.False( jwk.Equals( jwk2 ) );
            jwk2.X = (byte[]) jwk.X.Clone();

            // Equals must consider Y.
            jwk2.Y = null;
            Assert.False( jwk.Equals( jwk2 ) );
            jwk2.Y = (byte[]) jwk.Y.Clone();

            // Equals must consider D.
            jwk2.D = null;
            Assert.False( jwk.Equals( jwk2 ) );
            jwk2.D = (byte[]) jwk.D.Clone();

            return jwk;
        }

        private static void DoECDsaTests( JsonWebKey jwk, int digestSize )
        {
            var privateEcdsa = jwk.ToECDsa( true );
            var publicEcdsa = jwk.ToECDsa();

            // Round-trip with private Ecdsa.
            var jwk2 = new JsonWebKey( privateEcdsa );
            var publicEcdsa2 = jwk2.ToECDsa();

            DoSignVerifyTests( digestSize, privateEcdsa, publicEcdsa2 );

            // Round-trip with public Ecdsa.
            jwk2 = new JsonWebKey( publicEcdsa );
            publicEcdsa2 = jwk2.ToECDsa();

            DoSignVerifyTests( digestSize, privateEcdsa, publicEcdsa2 );
        }

        private static void DoSignVerifyTests( int digestSize, ECDsa privateEcdsa, ECDsa publicEcdsa )
        {
            // Create pseudo-random hash.
            var rnd = new Random( 0 );
            var digest = new byte[digestSize];
            rnd.NextBytes( digest );

            bool verified;

            // Check if private key can sign digest.
            var signature = privateEcdsa.SignHash( digest );

            // Check if private key can verify digest.
            verified = privateEcdsa.VerifyHash( digest, signature );
            Assert.True( verified );

            // Check if public key can verify digest.
            verified = publicEcdsa.VerifyHash( digest, signature );
            Assert.True( verified );

            signature[signature.Length - 1] ^= 1;

            // Check if private key can deny invalid digest.
            verified = privateEcdsa.VerifyHash( digest, signature );
            Assert.False( verified );

            // Check if public key can deny invalid digest.
            verified = publicEcdsa.VerifyHash( digest, signature );
            Assert.False( verified );
        }

        [Fact]
        public static void PrivateKeyMustBeProtected()
        {
            if ( !IsCngSupported() )
                return;

            DoPrivateKeyMustBeProtectedTests( P256TestKey, 32 );
            DoPrivateKeyMustBeProtectedTests( Secp256k1TestKey, 32 );
        }

        private static void DoPrivateKeyMustBeProtectedTests( string json, int digestSize )
        {
            // Create pseudo-random hash.
            var rnd = new Random( 0 );
            var digest = new byte[digestSize];
            rnd.NextBytes( digest );

            // Get the key.
            var jwk = JsonConvert.DeserializeObject<JsonWebKey>( json );
            var privateEcdsa = jwk.ToECDsa( true );

            // Exporting ECDsa must not include private key.
            var ecdsa = jwk.ToECDsa();
            Assert.ThrowsAny<CryptographicException>( () => ecdsa.SignHash( digest ) );

            // Exporting ECParameters must not include private key.
            var ecParams = jwk.ToEcParameters();
            Assert.Null( ecParams.D );

            // Importing ECDsa with private key must not include private key.
            var jwk2 = new JsonWebKey( privateEcdsa );
            Assert.Null( jwk2.D );

            // Importing ECParameters without private key must work.
            ecParams.D = null;
            jwk2 = new JsonWebKey( ecParams );
            jwk2.ToECDsa();

            jwk.D = null;

            // Exporting ECDsa when WebKey lacks private key, must work.
            var publicEcdsa = jwk.ToECDsa();
            DoSignVerifyTests( digestSize, privateEcdsa, publicEcdsa );

            // Exporting ECDsa demanding private key when WebKey lacks private key, must throw exception.
            Assert.Throws<ArgumentException>( () => jwk.ToECDsa( true ) );

            // Exporting ECParameters demanding private key when WebKey lacks private key, must throw exception.
            Assert.Throws<ArgumentException>( () => jwk.ToEcParameters( true ) );
        }

        private static void VerifyAttributes( JsonWebKey jwk, string curve, int keySize, bool expectPrivateKey )
        {
            var keySizeInBytes = ( keySize + 7 ) / 8;
            Assert.Equal( JsonWebKeyType.EllipticCurve, jwk.Kty );
            Assert.Equal( curve, jwk.CurveName );
            Assert.Equal( keySizeInBytes, jwk.X.Length );
            Assert.Equal( keySizeInBytes, jwk.Y.Length );
            if ( expectPrivateKey )
                Assert.Equal( keySizeInBytes, jwk.D.Length );
            var operations = new[] {JsonWebKeyOperation.Sign, JsonWebKeyOperation.Verify};
            Assert.Equal( operations, jwk.KeyOps );
        }

        /// <summary>
        /// Insures Windows CNG (NCrypt) is supported on this platform.
        /// </summary>
        /// For instance, CNG is not supported on Linux.
        private static bool IsCngSupported()
        {
            try
            {
                var key = CreateRandomKey( JsonWebKeyCurveName.P256 );
                key.Dispose();
                return true;
            }
            catch ( PlatformNotSupportedException )
            {
                return false;
            }
        }
    }
}