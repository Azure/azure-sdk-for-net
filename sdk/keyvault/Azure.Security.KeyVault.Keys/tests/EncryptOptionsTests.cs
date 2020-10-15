// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class EncryptOptionsTests
    {
        [Test]
        public void RequiresPlaintext()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new EncryptOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);
        }

        [Test]
        public void InitializesIv([EnumValues] EncryptionAlgorithm algorithm)
        {
            EncryptOptions options = new EncryptOptions(Array.Empty<byte>());
            options.Initialize(algorithm);

            if (algorithm.RequiresIv())
            {
                byte[] iv = options.Iv;

                Assert.IsNotNull(options.Iv);
                CollectionAssert.IsNotEmpty(options.Iv);

                // Calling it again should not overwrite.
                options.Initialize(algorithm);

                Assert.AreSame(iv, options.Iv);
            }
            else
            {
                Assert.IsNull(options.Iv);
            }
        }

        [Test]
        public void DoesNotOverwriteIv()
        {
            byte[] iv = new byte[12] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            EncryptOptions options = new EncryptOptions(Array.Empty<byte>(), iv);
            options.Initialize(EncryptionAlgorithm.A256Gcm);

            Assert.AreSame(iv, options.Iv);
        }
    }
}
