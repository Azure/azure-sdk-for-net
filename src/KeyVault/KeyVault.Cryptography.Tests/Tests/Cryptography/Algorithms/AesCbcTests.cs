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
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;
using Xunit;

namespace KeyVault.Cryptography.Tests
{

    /// <summary>
    /// Verify AESCBC
    /// </summary>
    public class AesCbcTests : IUseFixture<TestFixture>
    {
        public void SetFixture( TestFixture data )
        {
            // Intentionally empty
        }

        /// <summary>
        /// Testing AES128CBC, vectors from RFC 3602
        /// </summary>
        [Fact]
        public void KeyVault_Aes128CbcOneBlock()
        {
            // Arrange.
            // Note that AES128CBC as implemented in this library uses PKCS7 padding mode where the test
            // vectors do not use padding.
            byte[] CEK   = { 0x06, 0xa9, 0x21, 0x40, 0x36, 0xb8, 0xa1, 0x5b, 0x51, 0x2e, 0x03, 0xd5, 0x34, 0x12, 0x00, 0x06 };
            byte[] PLAIN = System.Text.UTF8Encoding.UTF8.GetBytes( "Single block msg" );
            byte[] IV    = { 0x3d, 0xaf, 0xba, 0x42, 0x9d, 0x9e, 0xb4, 0x30, 0xb4, 0x22, 0xda, 0x80, 0x2c, 0x9f, 0xac, 0x41 };
            byte[] ED    = { 0xe3, 0x53, 0x77, 0x9c, 0x10, 0x79, 0xae, 0xb8, 0x27, 0x08, 0x94, 0x2d, 0xbe, 0x77, 0x18, 0x1a };

            Aes128Cbc algo      = new Aes128Cbc();
            byte[]    encrypted;

            using ( var encryptor = algo.CreateEncryptor( CEK, IV, null ) )
            {
                encrypted = encryptor.TransformFinalBlock( PLAIN, 0, PLAIN.Length );

                // Assert: we only compare the first 16 bytes as this library uses PKCS7 padding
                var unpadded = encrypted.Take( 16 ).ToArray();
                Assert.True( unpadded.SequenceEqual( ED ) );
            }

            using ( var decryptor = algo.CreateDecryptor( CEK, IV, null ) )
            {
                var decrypted = decryptor.TransformFinalBlock( encrypted, 0, encrypted.Length );

                // Assert
                Assert.True( decrypted.SequenceEqual( PLAIN ) );
            }
        }

        /// <summary>
        /// Testing AES128CBC, vectors from RFC 3602
        /// </summary>
        [Fact]
        public void KeyVault_Aes128CbcTwoBlock()
        {
            // Arrange.
            // Note that AES128CBC as implemented in this library uses PKCS7 padding mode where the test
            // vectors do not use padding.
            byte[] CEK   = { 0xc2, 0x86, 0x69, 0x6d, 0x88, 0x7c, 0x9a, 0xa0, 0x61, 0x1b, 0xbb, 0x3e, 0x20, 0x25, 0xa4, 0x5a };
            byte[] PLAIN = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f };
            byte[] IV    = { 0x56, 0x2e, 0x17, 0x99, 0x6d, 0x09, 0x3d, 0x28, 0xdd, 0xb3, 0xba, 0x69, 0x5a, 0x2e, 0x6f, 0x58 };
            byte[] ED    = { 0xd2, 0x96, 0xcd, 0x94, 0xc2, 0xcc, 0xcf, 0x8a, 0x3a, 0x86, 0x30, 0x28, 0xb5, 0xe1, 0xdc, 0x0a, 0x75, 0x86, 0x60, 0x2d, 0x25, 0x3c, 0xff, 0xf9, 0x1b, 0x82, 0x66, 0xbe, 0xa6, 0xd6, 0x1a, 0xb1 };

            Aes128Cbc algo      = new Aes128Cbc();
            byte[]    encrypted;

            using ( var encryptor = algo.CreateEncryptor( CEK, IV, null ) )
            {
                encrypted = encryptor.TransformFinalBlock( PLAIN, 0, PLAIN.Length );

                // Assert: we only compare the first 32 bytes as this library uses PKCS7 padding
                var unpadded = encrypted.Take( 32 ).ToArray();
                Assert.True( unpadded.SequenceEqual( ED ) );
            }

            using ( var decryptor = algo.CreateDecryptor( CEK, IV, null ) )
            {
                var decrypted = decryptor.TransformFinalBlock( encrypted, 0, encrypted.Length );

                // Assert
                Assert.True( decrypted.SequenceEqual( PLAIN ) );
            }
        }

        /// <summary>
        /// Testing AES128CBC, vectors from RFC 3602
        /// </summary>
        [Fact]
        public void KeyVault_Aes128CbcOneBlock_ExcessKeyMaterial()
        {
            // Arrange.
            // Note that AES128CBC as implemented in this library uses PKCS7 padding mode where the test
            // vectors do not use padding.
            byte[] CEK   = { 0x06, 0xa9, 0x21, 0x40, 0x36, 0xb8, 0xa1, 0x5b, 0x51, 0x2e, 0x03, 0xd5, 0x34, 0x12, 0x00, 0x06, 0xc2, 0x86, 0x69, 0x6d, 0x88, 0x7c, 0x9a, 0xa0, 0x61, 0x1b, 0xbb, 0x3e, 0x20, 0x25, 0xa4, 0x5a };
            byte[] PLAIN = System.Text.UTF8Encoding.UTF8.GetBytes( "Single block msg" );
            byte[] IV    = { 0x3d, 0xaf, 0xba, 0x42, 0x9d, 0x9e, 0xb4, 0x30, 0xb4, 0x22, 0xda, 0x80, 0x2c, 0x9f, 0xac, 0x41 };
            byte[] ED    = { 0xe3, 0x53, 0x77, 0x9c, 0x10, 0x79, 0xae, 0xb8, 0x27, 0x08, 0x94, 0x2d, 0xbe, 0x77, 0x18, 0x1a };

            Aes128Cbc algo      = new Aes128Cbc();
            byte[]    encrypted;

            using ( var encryptor = algo.CreateEncryptor( CEK, IV, null ) )
            {
                encrypted = encryptor.TransformFinalBlock( PLAIN, 0, PLAIN.Length );

                // Assert: we only compare the first 16 bytes as this library uses PKCS7 padding
                var unpadded = encrypted.Take( 16 ).ToArray();
                Assert.True( unpadded.SequenceEqual( ED ) );
            }

            using ( var decryptor = algo.CreateDecryptor( CEK, IV, null ) )
            {
                var decrypted = decryptor.TransformFinalBlock( encrypted, 0, encrypted.Length );

                // Assert
                Assert.True( decrypted.SequenceEqual( PLAIN ) );
            }
        }

        /// <summary>
        /// Testing AES128CBC, vectors from RFC 3602
        /// </summary>
        [Fact]
        public void KeyVault_Aes128CbcTwoBlock_ExcessKeyMaterial()
        {
            // Arrange.
            // Note that AES128CBC as implemented in this library uses PKCS7 padding mode where the test
            // vectors do not use padding.
            byte[] CEK   = { 0xc2, 0x86, 0x69, 0x6d, 0x88, 0x7c, 0x9a, 0xa0, 0x61, 0x1b, 0xbb, 0x3e, 0x20, 0x25, 0xa4, 0x5a, 0xc2, 0x86, 0x69, 0x6d, 0x88, 0x7c, 0x9a, 0xa0, 0x61, 0x1b, 0xbb, 0x3e, 0x20, 0x25, 0xa4, 0x5a };
            byte[] PLAIN = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f };
            byte[] IV    = { 0x56, 0x2e, 0x17, 0x99, 0x6d, 0x09, 0x3d, 0x28, 0xdd, 0xb3, 0xba, 0x69, 0x5a, 0x2e, 0x6f, 0x58 };
            byte[] ED    = { 0xd2, 0x96, 0xcd, 0x94, 0xc2, 0xcc, 0xcf, 0x8a, 0x3a, 0x86, 0x30, 0x28, 0xb5, 0xe1, 0xdc, 0x0a, 0x75, 0x86, 0x60, 0x2d, 0x25, 0x3c, 0xff, 0xf9, 0x1b, 0x82, 0x66, 0xbe, 0xa6, 0xd6, 0x1a, 0xb1 };

            Aes128Cbc algo      = new Aes128Cbc();
            byte[]    encrypted;

            using ( var encryptor = algo.CreateEncryptor( CEK, IV, null ) )
            {
                encrypted = encryptor.TransformFinalBlock( PLAIN, 0, PLAIN.Length );

                // Assert: we only compare the first 32 bytes as this library uses PKCS7 padding
                var unpadded = encrypted.Take( 32 ).ToArray();
                Assert.True( unpadded.SequenceEqual( ED ) );
            }

            using ( var decryptor = algo.CreateDecryptor( CEK, IV, null ) )
            {
                var decrypted = decryptor.TransformFinalBlock( encrypted, 0, encrypted.Length );

                // Assert
                Assert.True( decrypted.SequenceEqual( PLAIN ) );
            }
        }
    }
}
