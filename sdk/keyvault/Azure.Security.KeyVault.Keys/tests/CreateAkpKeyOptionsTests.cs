// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class CreateAkpKeyOptionsTests
    {
        [Test]
        public void NullNameThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new CreateAkpKeyOptions(null, AkpAlgorithm.MLDsa65));
            Assert.AreEqual("name", ex.ParamName);
        }

        [Test]
        public void EmptyNameThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new CreateAkpKeyOptions(string.Empty, AkpAlgorithm.MLDsa65));
            Assert.AreEqual("name", ex.ParamName);
        }

        [Test]
        public void UnsetAlgorithmThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new CreateAkpKeyOptions("test", default(AkpAlgorithm)));
            Assert.AreEqual("algorithm", ex.ParamName);
        }

        [Test]
        public void UsesAkpKeyType()
        {
            CreateAkpKeyOptions options = new CreateAkpKeyOptions("test", AkpAlgorithm.MLDsa65);

            Assert.AreEqual("test", options.Name);
            Assert.AreEqual(AkpAlgorithm.MLDsa65, options.Algorithm);
            Assert.IsFalse(options.HardwareProtected);
            Assert.AreEqual(KeyType.Akp, options.KeyType);
        }

        [Test]
        public void HardwareProtectedKeyUsesAkpHsmKeyType()
        {
            CreateAkpKeyOptions options = new CreateAkpKeyOptions("test", AkpAlgorithm.MLDsa87, hardwareProtected: true);

            Assert.IsTrue(options.HardwareProtected);
            Assert.AreEqual(KeyType.AkpHsm, options.KeyType);
            Assert.AreEqual(AkpAlgorithm.MLDsa87, options.Algorithm);
        }

        [TestCase(false, "AKP", "ML-DSA-44")]
        [TestCase(true, "AKP-HSM", "ML-DSA-87")]
        public void SerializesKeyTypeAndAlgorithm(bool hardwareProtected, string expectedKeyType, string algorithm)
        {
            CreateAkpKeyOptions options = new CreateAkpKeyOptions("test", algorithm, hardwareProtected);
            KeyRequestParameters parameters = new KeyRequestParameters(options);

            using JsonDocument json = JsonDocument.Parse(parameters.Serialize());
            JsonElement root = json.RootElement;

            Assert.AreEqual(expectedKeyType, root.GetProperty("kty").GetString());
            Assert.AreEqual(algorithm, root.GetProperty("alg").GetString());
        }
    }
}
