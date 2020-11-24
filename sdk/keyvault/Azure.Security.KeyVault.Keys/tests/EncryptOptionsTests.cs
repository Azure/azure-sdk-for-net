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
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.Rsa15Options(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.RsaOaepOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.RsaOaep256Options(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A128GcmOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A128GcmOptions(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A192GcmOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A192GcmOptions(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A256GcmOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A256GcmOptions(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A128CbcOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A128CbcOptions(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A128CbcOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A192CbcOptions(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A128CbcOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A256CbcOptions(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A128CbcPadOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A128CbcPadOptions(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A128CbcPadOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A192CbcPadOptions(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptOptions.A128CbcPadOptions(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptOptions.A256CbcPadOptions(Array.Empty<byte>(), null));
        }

        [Test]
        public void InitializesIv([EnumValues] EncryptionAlgorithm algorithm)
        {
            EncryptOptions options = new EncryptOptions(algorithm, Array.Empty<byte>());
            options.Initialize();

            if (algorithm.GetAesCbcEncryptionAlgorithm() != null)
            {
                byte[] iv = options.Iv;

                Assert.IsNotNull(options.Iv);
                CollectionAssert.IsNotEmpty(options.Iv);

                // Calling it again should not overwrite.
                options.Initialize();

                Assert.AreSame(iv, options.Iv);
            }
            else
            {
                Assert.IsNull(options.Iv);
            }
        }
    }
}
