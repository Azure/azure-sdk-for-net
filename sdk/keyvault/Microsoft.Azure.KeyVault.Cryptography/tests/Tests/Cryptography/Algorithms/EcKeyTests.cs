// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Microsoft.Azure.KeyVault.WebKey;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.KeyVault.Cryptography.Tests
{
    /// <summary>
    /// Verify RSAKey
    /// </summary>
    public class EcKeyTests : IClassFixture<TestFixture>
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

            DoHardCodedKeyTests( P256TestKey, EcKey.P256, 256, "ES256", 32 );
            DoHardCodedKeyTests( P384TestKey, EcKey.P384, 384, "ES384", 48 );
            DoHardCodedKeyTests( P521TestKey, EcKey.P521, 521, "ES512", 64 );
            DoHardCodedKeyTests( Secp256k1TestKey, EcKey.P256K, 256, "ES256K", 32 );
        }

        private static void DoHardCodedKeyTests( string json, string curve, int keySize, string defaultAlgo, int digestSize )
        {
            var privateKey = CreateKeyFromJwk( json, curve, defaultAlgo, true );
            var publicKey = CreateKeyFromJwk( json, curve, defaultAlgo );

            DoSignVerifyTests( digestSize, privateKey, publicKey );
        }

        private static EcKey CreateKeyFromJwk( string json, string curve, string defaultAlgo, bool isPrivateKey = false )
        {
            var jwk = JsonConvert.DeserializeObject<JsonWebKey>( json );
            var kid = new Guid().ToString( "N" );
            var key = new EcKey( kid, curve, jwk.X, jwk.Y, isPrivateKey ? jwk.D : null );
            Assert.Equal( kid, key.Kid );
            Assert.Equal( defaultAlgo, key.DefaultSignatureAlgorithm );
            return key;
        }

        [Fact]
        public static void RandomKeysMustWork()
        {
            if ( !IsCngSupported() )
                return;

            DoRamdomKeyTest( EcKey.P256, 256, "ES256", 32 );
            DoRamdomKeyTest( EcKey.P384, 384, "ES384", 48 );
            DoRamdomKeyTest( EcKey.P521, 521, "ES512", 64 );
            DoRamdomKeyTest( EcKey.P256K, 256, "ES256K", 32 );
        }

        private static void DoRamdomKeyTest( string curve, int keySize, string defaultAlgo, int digestSize )
        {
            var key = CreateRandomKey( curve, defaultAlgo );
            DoSignVerifyTests( digestSize, key, null );
        }

        private static EcKey CreateRandomKey( string curve, string defaultAlgo )
        {
            var kid = new Guid().ToString( "N" );
            var key = new EcKey( kid, curve );
            Assert.Equal( kid, key.Kid );
            Assert.Equal( defaultAlgo, key.DefaultSignatureAlgorithm );
            return key;
        }

        private static void DoSignVerifyTests( int digestSize, EcKey privateKey, EcKey publicKey )
        {
            // Create pseudo-random hash.
            var rnd = new Random( 0 );
            var digest = new byte[digestSize];
            rnd.NextBytes( digest );

            bool verified;

            // Check if private key can sign digest.
            var signatureResult = privateKey.SignAsync( digest, null ).Result;
            var signature = signatureResult.Item1;
            var algorithm = signatureResult.Item2;
            Assert.Equal( algorithm, privateKey.DefaultSignatureAlgorithm );

            // Check if private key can verify digest.
            verified = privateKey.VerifyAsync( digest, signature, algorithm ).Result;
            Assert.True( verified );

            if ( publicKey != null )
            {
                // Check if public key can verify digest.
                verified = publicKey.VerifyAsync( digest, signature, algorithm ).Result;
                Assert.True( verified );
            }

            signature[signature.Length - 1] ^= 1;

            // Check if private key can deny invalid digest.
            verified = privateKey.VerifyAsync( digest, signature, algorithm ).Result;
            Assert.False( verified );

            if ( publicKey != null )
            {
                // Check if public key can deny invalid digest.
                verified = publicKey.VerifyAsync( digest, signature, algorithm ).Result;
                Assert.False( verified );
            }
        }

        /// <summary>
        /// Insures Windows CNG (NCrypt) is supported on this platform.
        /// </summary>
        /// For instance, CNG is not supported on Linux.
        private static bool IsCngSupported()
        {
            try
            {
                var key = CreateRandomKey( EcKey.P256, "ES256" );
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