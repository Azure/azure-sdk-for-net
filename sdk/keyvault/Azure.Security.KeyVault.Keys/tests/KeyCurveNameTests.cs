// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyCurveNameTests
    {
        [TestCase("P-256", "1.2.840.10045.3.1.7", 256, 32)]
        [TestCase("P-256K", "1.3.132.0.10", 256, 32)]
        [TestCase("P-384", "1.3.132.0.34", 384, 48)]
        [TestCase("P-521", "1.3.132.0.35", 521, 66)]
        [TestCase("p-256", null, 0, 0)]
        [TestCase("p-256k", null, 0, 0)]
        [TestCase("p-384", null, 0, 0)]
        [TestCase("p-521", null, 0, 0)]
        [TestCase("p256", null, 0, 0)]
        [TestCase("p256k", null, 0, 0)]
        [TestCase("p384", null, 0, 0)]
        [TestCase("p521", null, 0, 0)]
        [TestCase("ShouldNotExist", null, 0, 0)]
        public void StringCastLooksUpValueOrDefaults(string name, string expectedOidValue, int expectedKeySize, int expectedKeyParameterSize)
        {
            KeyCurveName actual = name;

            Assert.AreEqual(name, actual.ToString());
            Assert.AreEqual(expectedOidValue, actual.Oid?.Value);
            Assert.AreEqual(expectedKeySize, actual.KeySize);
            Assert.AreEqual(expectedKeyParameterSize, actual.KeyParameterSize);
        }

        [TestCase("1.2.840.10045.3.1.7", "P-256")]
        [TestCase("1.3.132.0.10", "P-256K")]
        [TestCase("1.3.132.0.34", "P-384")]
        [TestCase("1.3.132.0.35", "P-521")]
        [TestCase("1.2.3.4", null)]
        public void FindsOidValue(string oidValue, string expectedName)
        {
            Oid oid = new Oid(oidValue);
            KeyCurveName actual = KeyCurveName.FromOid(oid, 0);

            Assert.AreEqual(expectedName, actual.ToString());
        }

        [TestCase("nistP521", 521, "P-521")]
        [TestCase("secp521r1", 521, "P-521")]
        [TestCase("ECDSA_P521", 521, "P-521")]
        [TestCase("nistP384", 384, "P-384")]
        [TestCase("secp384r1", 384, "P-384")]
        [TestCase("ECDSA_P384", 384, "P-384")]
        [TestCase("secp256k1", 256, "P-256K")]
        [TestCase("nistP256", 256, "P-256")]
        [TestCase("secp256r1", 256, "P-256")]
        [TestCase("ECDSA_P256", 256, "P-256")]
        [TestCase("ecdsa_p256", 256, "P-256")]
        [TestCase("ecdsa_p256", 0, null)]
        [TestCase(null, 256, null)]
        [TestCase("", 256, null)]
        public void FindsOidFriendName(string oidFriendlyName, int keySize, string expectedName)
        {
            Oid oid = new Oid(null, oidFriendlyName);
            KeyCurveName actual = KeyCurveName.FromOid(oid, keySize);

            Assert.AreEqual(expectedName, actual.ToString());
        }
    }
}
