// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;
using Microsoft.Azure.KeyVault.WebKey;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.KeyVault.Cryptography.Tests
{

    /// <summary>
    /// Verify RSAKey
    /// </summary>
    public class RsaKeyTests : IClassFixture<TestFixture>
    {
        static byte[] CEK                    = { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };
        static string CrossPlatformSignature = "RaNc+8WcWxplS8I7ynJLSoLJKz+dgBvrZhIGH3VFlTTyzu7b9d+lpaV9IKhzCNBsgSysKhgL7EZwVCOTBZ4m6xvKSXqVFXYaBPyBTD7VoKPMYMW6ai5x6xV5XAMaZPfMkff3Deg/RXcc8xQ28FhYuUa8yly01GySY4Hk55anEvb2wBxSy1UGun/0LE1lYH3C3XEgSry4cEkJHDJl1hp+wB4J/noXOqn5ECGU+/4ehBJOyW1gtUH0/gRe8yXnDH0AXepHRyH8iBHLWlKX1r+1/OrMulqOoi82RZzJlTyEz9X+bsQhllqGF6n3hdLS6toH9o7wUtwYNqSx82JuQT6iMg==";

        static RandomNumberGenerator RNG = RandomNumberGenerator.Create();

        internal void SetFixture( TestFixture data )
        {
            // Intentionally empty
        }

        /// <summary>
        /// Testing RSA1_5
        /// </summary>
        [Fact]
        public async Task KeyVault_RsaKeyRSA15()
        {
            RsaKey key = GetTestRsaKey();

            // Wrap and Unwrap
            var wrapped   = await key.WrapKeyAsync( CEK, Rsa15.AlgorithmName ).ConfigureAwait( false );
            var unwrapped = await key.UnwrapKeyAsync( wrapped.Item1, Rsa15.AlgorithmName ).ConfigureAwait( false );

            // Assert
            Assert.Equal("RSA_15", wrapped.Item2);
            Assert.True( unwrapped.SequenceEqual( CEK ) );

            // Encrypt and Decrypt
            var encrypted = await key.EncryptAsync( CEK, null, null, Rsa15.AlgorithmName ).ConfigureAwait( false );
            var decrypted = await key.DecryptAsync( encrypted.Item1, null, null, null, Rsa15.AlgorithmName ).ConfigureAwait( false );

            // Assert
            Assert.Equal("RSA_15", encrypted.Item3);
            Assert.True( decrypted.SequenceEqual( CEK ) );
        }

        /// <summary>
        /// Testing RSA_OAEP
        /// </summary>
        [Fact]
        public async Task KeyVault_RsaKeyRSAOAEP()
        {
            RsaKey key = GetTestRsaKey();

            var wrapped   = await key.WrapKeyAsync( CEK, RsaOaep.AlgorithmName ).ConfigureAwait( false );
            var unwrapped = await key.UnwrapKeyAsync( wrapped.Item1, RsaOaep.AlgorithmName ).ConfigureAwait( false );

            // Assert
            Assert.Equal("RSA-OAEP", wrapped.Item2);
            Assert.True( unwrapped.SequenceEqual( CEK ) );

            var encrypted = await key.EncryptAsync( CEK, null, null, RsaOaep.AlgorithmName ).ConfigureAwait( false );
            var decrypted = await key.DecryptAsync( encrypted.Item1, null, null, null, RsaOaep.AlgorithmName ).ConfigureAwait( false );

            // Assert
            Assert.Equal("RSA-OAEP", encrypted.Item3);
            Assert.True( decrypted.SequenceEqual( CEK ) );
        }

        /// <summary>
        /// Testing RSA_OAEP
        /// </summary>
        [Fact]
        public async Task KeyVault_RsaKeyDefaultAlgorithm()
        {
            RsaKey key = GetTestRsaKey();

            Assert.Equal("RSA-OAEP", key.DefaultEncryptionAlgorithm);
            Assert.Equal("RSA-OAEP", key.DefaultKeyWrapAlgorithm);
            Assert.Equal("RS256", key.DefaultSignatureAlgorithm);

            var wrapped   = await key.WrapKeyAsync( CEK, null ).ConfigureAwait( false );
            var unwrapped = await key.UnwrapKeyAsync( wrapped.Item1, null ).ConfigureAwait( false );

            // Assert
            Assert.Equal("RSA-OAEP", wrapped.Item2);
            Assert.True( unwrapped.SequenceEqual( CEK ) );

            var encrypted = await key.EncryptAsync( CEK, null, null, null ).ConfigureAwait( false );
            var decrypted = await key.DecryptAsync( encrypted.Item1, null, null, null, null ).ConfigureAwait( false );

            // Assert
            Assert.Equal("RSA-OAEP", encrypted.Item3);
            Assert.True( decrypted.SequenceEqual( CEK ) );
        }

        [Fact]
        public async Task KeyVault_RsaKeyRS256()
        {
            var key    = GetTestRsaKey();
            var hash   = SHA256.Create();

            var digest = hash.ComputeHash( CEK, 0, CEK.Length );

            Assert.NotNull( digest );
            Assert.True( digest.Length == 32 );

            var signature = await key.SignAsync( digest, "RS256" ).ConfigureAwait( false );

            Assert.Equal("RS256", signature.Item2);
            Assert.NotNull( signature.Item1 );

            var verify = await key.VerifyAsync( digest, signature.Item1, signature.Item2 ).ConfigureAwait( false );

            Assert.True( verify );

            // Now prove we can verify the cross platform signature
            verify = await key.VerifyAsync( digest, Convert.FromBase64String( CrossPlatformSignature ), "RS256" ).ConfigureAwait( false );

            Assert.True( verify );
        }

        public RsaKey GetTestRsaKey()
        {
            var jwkString = "{\"kty\":\"RSA\",\"n\":\"rZ8pnmXkhfmmgNWVVdtNcYy2q0OAcCGIpeFzsN9URqJsiBEiWQfxlUxFTbM4kVWPqjauKt6byvApBGEeMA7Qs8kxwRVP-BD4orXRe9VPgliM92rH0UxQWHmCHUe7G7uUAFPwbiDVhWuFzELxNa6Kljg6Z9DuUKoddmQvlYWj8uSunofCtDi_zzlZKGYTOYJma5IYScHNww1yjLp8-b-Be2UdHbrPkCv6Nuwi6MVIKjPpEeRQgfefRmxDBJQKY3OfydMXZmEwukYXVkUcdIP8XwG2OxnfdRK0oAo0NDebNNVuT89k_3AyZLTr1KbDmx1nnjwa8uB8k-uLtcOC9igbTw\",\"e\":\"AQAB\",\"d\":\"H-z7hy_vVJ9yeZBMtIvt8qpQUK_J51STPwV085otcgud72tPKJXoW2658664ASl9kGwbnLBwb2G3-SEunuGqiNS_PGUB3niob6sFSUMRKsPDsB9HfPoOcCZvwZiWFGRqs6C7vlR1TuJVqRjKJ_ffbf4K51oo6FZPspx7j4AShLAwLUSQ60Ld5QPuxYMYZIMpdVbMVIVHJ26pR4Y18e_0GYmEGnbF5N0HkwqQmfmTiIK5aoGnD3GGgqHeHmWBwh6_WAq90ITLcX_zBeqQUgBSj-Z5v61SroO9Eang36T9mMoYrcPpYwemtAOb4HhQYDj8dCCfbeOcVmvZ9UJKWCX2oQ\",\"dp\":\"HW87UpwPoj3lPI9B9K1hJFeuGgarpakvtHuk1HpZ5hXWFGAJiXoWRV-jvYyjoM2k7RpSxPyuuFFmYHcIxiGFp2ES4HnP0BIhKVa2DyugUxIEcMK53C43Ub4mboJPZTSC3sapKgAmA2ue624sapWmshTPpx9qnUP2Oj3cSMkgMGE\",\"dq\":\"RhwEwb5FYio0GS2tmul8FAYsNH7JDehwI1yUApnTiakhSenFetml4PYyVkKR4csgLZEi3RY6J3R8Tg-36zrZuF7hxhVJn80L5_KETSpfEI3jcrXMVg4SRaMsWLY9Ahxflt2FJgUnHOmWRLmP6_hmaTcxxSACjbyUd_HhwNavD5E\",\"qi\":\"wYPZ4lKIslA1w3FaAzQifnNLABYXXUZ_KAA3a8T8fuxkdE4OP3xIFX7WHhnmBd6uOFiEcGoeq2jNQqDg91rV5661-5muQKcvp4uUsNId5rQw9EZw-kdDcwMtVFTEBfvVuyp83X974xYAHn1Jd8wWohSwrpi1QuH5cQMR5Fm6I1A\",\"p\":\"74Ot7MgxRu4euB31UWnGtrqYPjJmvbjYESS43jfDfo-s62ggV5a39P_YPg6oosgtGHNw0QDxunUOXNu9iriaYPf_imptRk69bKN8Nrl727Y-AaBYdLf1UZuwz8X07FqHAH5ghYpk79djld8QvkUUJLpx6rzcW8BJLTOi46DtzZE\",\"q\":\"uZJu-qenARIt28oj_Jlsk-p_KLnqdczczZfbRDd7XNp6csGLa8R0EyYqUB4xLWELQZsX4tAu9SaAO62tuuEy5wbOAmOVrq2ntoia1mGQSJdoeVq6OqtN300xVnaBc3us0rm8C6-824fEQ1PWXoulXLKcSqBhFT-hQahsYi-kat8\"}";

            JsonWebKey jwk = JsonConvert.DeserializeObject<JsonWebKey>( jwkString );

            return new RsaKey( "foo", jwk.ToRSA( true ) );
        }

}
}
