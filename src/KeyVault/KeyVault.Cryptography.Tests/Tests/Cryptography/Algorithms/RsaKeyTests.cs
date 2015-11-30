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

using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;
using Xunit;

namespace KeyVault.Cryptography.Tests
{

    /// <summary>
    /// Verify RSAKey
    /// </summary>
    public class RsaKeyTests : IUseFixture<TestFixture>
    {

        static RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();

        public void SetFixture( TestFixture data )
        {
            // Intentionally empty
        }

        /// <summary>
        /// Testing RSA1_5
        /// </summary>
        [Fact]
        public async Task KeyVault_RsaKeyRSA15()
        {
            // Arrange
            byte[] KEK = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            byte[] CEK = { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };
            byte[] EK  = { 0x1F, 0xA6, 0x8B, 0x0A, 0x81, 0x12, 0xB4, 0x47, 0xAE, 0xF3, 0x4B, 0xD8, 0xFB, 0x5A, 0x7B, 0x82, 0x9D, 0x3E, 0x86, 0x23, 0x71, 0xD2, 0xCF, 0xE5 };

            RsaKey key = new RsaKey( "KEK" );


            var wrapped   = await key.WrapKeyAsync( CEK, Rsa15.AlgorithmName ).ConfigureAwait( false );
            var unwrapped = await key.UnwrapKeyAsync( wrapped.Item1, Rsa15.AlgorithmName ).ConfigureAwait( false );

            // Assert
            Assert.True( wrapped.Item2.Equals( "RSA_15" ) );
            Assert.True( unwrapped.SequenceEqual( CEK ) );

            var encrypted = await key.EncryptAsync( CEK, null, null, Rsa15.AlgorithmName ).ConfigureAwait( false );
            var decrypted = await key.DecryptAsync( encrypted.Item1, null, null, null, Rsa15.AlgorithmName ).ConfigureAwait( false );

            // Assert
            Assert.True( encrypted.Item3.Equals( "RSA_15" ) );
            Assert.True( decrypted.SequenceEqual( CEK ) );
        }

        /// <summary>
        /// Testing RSA_OAEP
        /// </summary>
        [Fact]
        public async Task KeyVault_RsaKeyRSAOAEP()
        {
            // Arrange
            byte[] KEK = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17 };
            byte[] CEK = { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };
            byte[] EK  = { 0x96, 0x77, 0x8B, 0x25, 0xAE, 0x6C, 0xA4, 0x35, 0xF9, 0x2B, 0x5B, 0x97, 0xC0, 0x50, 0xAE, 0xD2, 0x46, 0x8A, 0xB8, 0xA1, 0x7A, 0xD8, 0x4E, 0x5D };

            RsaKey key = new RsaKey( "KEK" );

            var wrapped   = await key.WrapKeyAsync( CEK, RsaOaep.AlgorithmName ).ConfigureAwait( false );
            var unwrapped = await key.UnwrapKeyAsync( wrapped.Item1, RsaOaep.AlgorithmName ).ConfigureAwait( false );

            // Assert
            Assert.True( wrapped.Item2.Equals( "RSA-OAEP" ) );
            Assert.True( unwrapped.SequenceEqual( CEK ) );

            var encrypted = await key.EncryptAsync( CEK, null, null, RsaOaep.AlgorithmName ).ConfigureAwait( false );
            var decrypted = await key.DecryptAsync( encrypted.Item1, null, null, null, RsaOaep.AlgorithmName ).ConfigureAwait( false );

            // Assert
            Assert.True( encrypted.Item3.Equals( "RSA-OAEP" ) );
            Assert.True( decrypted.SequenceEqual( CEK ) );
        }
    }
}
