// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class EncryptParametersTests
    {
        [Test]
        public void RequiresPlaintext()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.Rsa15Parameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.RsaOaepParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.RsaOaep256Parameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A128GcmParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A128GcmParameters(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A192GcmParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A192GcmParameters(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A256GcmParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A256GcmParameters(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A128CbcParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A128CbcParameters(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A128CbcParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A192CbcParameters(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A128CbcParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A256CbcParameters(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A128CbcPadParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A128CbcPadParameters(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A128CbcPadParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A192CbcPadParameters(Array.Empty<byte>(), null));

            ex = Assert.Throws<ArgumentNullException>(() => EncryptParameters.A128CbcPadParameters(null));
            Assert.AreEqual("plaintext", ex.ParamName);

            Assert.DoesNotThrow(() => EncryptParameters.A256CbcPadParameters(Array.Empty<byte>(), null));
        }

        [Test]
        public void InitializesIv([EnumValues] EncryptionAlgorithm algorithm)
        {
            EncryptParameters parameters = new EncryptParameters(algorithm, Array.Empty<byte>());
            parameters.Initialize();

            if (algorithm.GetAesCbcEncryptionAlgorithm() != null)
            {
                byte[] iv = parameters.Iv;

                Assert.IsNotNull(parameters.Iv);
                CollectionAssert.IsNotEmpty(parameters.Iv);

                // Calling it again should not overwrite.
                parameters.Initialize();

                Assert.AreSame(iv, parameters.Iv);
            }
            else
            {
                Assert.IsNull(parameters.Iv);
            }
        }
    }
}
