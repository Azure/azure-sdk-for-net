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
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new DecryptOptions(null));
            Assert.AreEqual("ciphertext", ex.ParamName);
        }

        [Test]
        public void RequiresAll()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new DecryptOptions(null, null, null));
            Assert.AreEqual("ciphertext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new DecryptOptions(Array.Empty<byte>(), null, null));
            Assert.AreEqual("iv", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new DecryptOptions(Array.Empty<byte>(), Array.Empty<byte>(), null));
            Assert.AreEqual("authenticationTag", ex.ParamName);
        }
    }
}
