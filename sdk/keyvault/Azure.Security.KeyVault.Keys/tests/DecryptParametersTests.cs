// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class DecryptParametersTests
    {
        [Test]
        public void RequiresCiphertext()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.Rsa15Parameters(null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.RsaOaepParameters(null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.RsaOaep256Parameters(null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));
        }

        [Test]
        public void RequiresOnlyCiphertextIvAuthenticationTag()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A128GcmParameters(null, null, null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A128GcmParameters(Array.Empty<byte>(), null, null, null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A128GcmParameters(Array.Empty<byte>(), Array.Empty<byte>(), null, null));
            Assert.That(ex.ParamName, Is.EqualTo("authenticationTag"));

            Assert.DoesNotThrow(() => DecryptParameters.A128GcmParameters(Array.Empty<byte>(), Array.Empty<byte>(), Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A192GcmParameters(null, null, null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A192GcmParameters(Array.Empty<byte>(), null, null, null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A192GcmParameters(Array.Empty<byte>(), Array.Empty<byte>(), null, null));
            Assert.That(ex.ParamName, Is.EqualTo("authenticationTag"));

            Assert.DoesNotThrow(() => DecryptParameters.A192GcmParameters(Array.Empty<byte>(), Array.Empty<byte>(), Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A256GcmParameters(null, null, null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A256GcmParameters(Array.Empty<byte>(), null, null, null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A256GcmParameters(Array.Empty<byte>(), Array.Empty<byte>(), null, null));
            Assert.That(ex.ParamName, Is.EqualTo("authenticationTag"));

            Assert.DoesNotThrow(() => DecryptParameters.A256GcmParameters(Array.Empty<byte>(), Array.Empty<byte>(), Array.Empty<byte>(), null));
        }

        [Test]
        public void RequiresCiphertextIv()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A128CbcParameters(null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A128CbcParameters(Array.Empty<byte>(), null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A192CbcParameters(null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A192CbcParameters(Array.Empty<byte>(), null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A256CbcParameters(null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A256CbcParameters(Array.Empty<byte>(), null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A128CbcPadParameters(null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A128CbcPadParameters(Array.Empty<byte>(), null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A192CbcPadParameters(null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A192CbcPadParameters(Array.Empty<byte>(), null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A256CbcPadParameters(null, null));
            Assert.That(ex.ParamName, Is.EqualTo("ciphertext"));

            ex = Assert.Throws<ArgumentNullException>(() => DecryptParameters.A256CbcPadParameters(Array.Empty<byte>(), null));
            Assert.That(ex.ParamName, Is.EqualTo("iv"));
        }
    }
}
