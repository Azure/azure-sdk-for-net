// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Azure.Core.Testing;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Test
{
    public class KeyTypeTests
    {
        [Test]
        public void EnsureOperatorWorks()
        {
            KeyType ec = KeyType.EllipticCurve;
            KeyType ecesm = KeyType.EllipticCurveHsm;

            Assert.IsTrue(ec != ecesm);
            Assert.AreNotEqual(ec, ecesm);
        }

        [TestCaseSource(nameof(KeyTypeCombinationsToTest))]
        public void ValidateKeyType(string keyName, KeyType expectedKeyType)
        {
            KeyType kt = new KeyType(keyName);

            // using the equals method
            Assert.AreEqual(expectedKeyType, kt);

            // using the operators
            Assert.IsTrue(kt == expectedKeyType);
            Assert.IsFalse(kt != expectedKeyType);
        }

        static readonly object[] KeyTypeCombinationsToTest =
        {
            new object[]{"rsa", KeyType.Rsa},
            new object[]{"rsa-HSM", KeyType.RsaHsm},
            new object[]{"EC", KeyType.EllipticCurve},
            new object[]{"EC-hsm", KeyType.EllipticCurveHsm},
            new object[]{"ocTet", KeyType.Octet},
            new object[]{"UnknownValue", new KeyType("UnknownValue")},
        };
    }
}