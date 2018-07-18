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
using Microsoft.Azure.KeyVault.Cryptography;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;
using Xunit;

namespace KeyVault.Cryptography.Tests
{

    /// <summary>
    /// Verify AESCBC-HMAC
    /// </summary>
    public class AesCbcHmacTests : IUseFixture<TestFixture>
    {
        public void SetFixture( TestFixture data )
        {
            // Intentionally empty
        }

        /// <summary>
        /// Testing Aes128CbcHmacSha256
        /// </summary>
        [Fact]
        public void KeyVault_Aes128CbcHmacSha256()
        {
            // Arrange
            byte[] CEK   = { 4, 211, 31, 197, 84, 157, 252, 254, 11, 100, 157, 250, 63, 170, 106, 206, 107, 124, 212, 45, 111, 107, 9, 219, 200, 177, 0, 240, 143, 156, 44, 207 };
            byte[] PLAIN = { 76, 105, 118, 101, 32, 108, 111, 110, 103, 32, 97, 110, 100, 32, 112, 114, 111, 115, 112, 101, 114, 46 };
            byte[] IV    = { 3, 22, 60, 12, 43, 67, 104, 105, 108, 108, 105, 99, 111, 116, 104, 101 };
            byte[] AUTH  = { 101, 121, 74, 104, 98, 71, 99, 105, 79, 105, 74, 66, 77, 84, 73, 52, 83, 49, 99, 105, 76, 67, 74, 108, 98, 109, 77, 105, 79, 105, 74, 66, 77, 84, 73, 52, 81, 48, 74, 68, 76, 85, 104, 84, 77, 106, 85, 50, 73, 110, 48 };
            byte[] ED    = { 40, 57, 83, 181, 119, 33, 133, 148, 198, 185, 243, 24, 152, 230, 6, 75, 129, 223, 127, 19, 210, 82, 183, 230, 168, 33, 215, 104, 143, 112, 56, 102 };
            byte[] TAG   = { 83, 73, 191, 98, 104, 205, 211, 128, 201, 189, 199, 133, 32, 38, 194, 85 };

            Aes128CbcHmacSha256 kw = new Aes128CbcHmacSha256();

            using ( var encryptor = kw.CreateEncryptor( CEK, IV, AUTH ) as IAuthenticatedCryptoTransform )
            {
                var encrypted = encryptor.TransformFinalBlock( PLAIN, 0, PLAIN.Length );

                // Assert
                Assert.True( encrypted.SequenceEqual( ED ) );
                Assert.True( encryptor.Tag.SequenceEqual( TAG ) );
            }

            using ( var decryptor = kw.CreateDecryptor( CEK, IV, AUTH ) )
            {
                var decrypted = decryptor.TransformFinalBlock( ED, 0, ED.Length );

                // Assert
                Assert.True( decrypted.SequenceEqual( PLAIN ) );
            }
        }
    }
}
