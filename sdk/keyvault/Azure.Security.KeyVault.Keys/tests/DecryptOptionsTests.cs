// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class DecryptOptionsTests
    {
        [Test]
        public void RequiresCiphertext()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.Rsa15Options(null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.RsaOaepOptions(null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.RsaOaep256Options(null));
            Assert.AreEqual("ciphertext", ex.ParamName);
        }

        [Test]
        public void RequiresOnlyCiphertextIvAuthenticationTag()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A128GcmOptions(null, null, null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A128GcmOptions(Array.Empty<byte>(), null, null, null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A128GcmOptions(Array.Empty<byte>(), Array.Empty<byte>(), null, null));
            Assert.AreEqual("authenticationTag", ex.ParamName);

            Assert.DoesNotThrow(() => DecryptOptions.A128GcmOptions(Array.Empty<byte>(), Array.Empty<byte>(), Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A192GcmOptions(null, null, null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A192GcmOptions(Array.Empty<byte>(), null, null, null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A192GcmOptions(Array.Empty<byte>(), Array.Empty<byte>(), null, null));
            Assert.AreEqual("authenticationTag", ex.ParamName);

            Assert.DoesNotThrow(() => DecryptOptions.A192GcmOptions(Array.Empty<byte>(), Array.Empty<byte>(), Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A256GcmOptions(null, null, null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A256GcmOptions(Array.Empty<byte>(), null, null, null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A256GcmOptions(Array.Empty<byte>(), Array.Empty<byte>(), null, null));
            Assert.AreEqual("authenticationTag", ex.ParamName);

            Assert.DoesNotThrow(() => DecryptOptions.A256GcmOptions(Array.Empty<byte>(), Array.Empty<byte>(), Array.Empty<byte>(), null));
        }

        [Test]
        public void RequiresCiphertextIv()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A128CbcOptions(null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A128CbcOptions(Array.Empty<byte>(), null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A192CbcOptions(null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A192CbcOptions(Array.Empty<byte>(), null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A256CbcOptions(null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A256CbcOptions(Array.Empty<byte>(), null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A128CbcPadOptions(null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A128CbcPadOptions(Array.Empty<byte>(), null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A192CbcPadOptions(null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A192CbcPadOptions(Array.Empty<byte>(), null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A256CbcPadOptions(null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => DecryptOptions.A256CbcPadOptions(Array.Empty<byte>(), null));
            Assert.AreEqual("iv", ex.ParamName);
        }
    }
}
