// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class AkpAlgorithmTests
    {
        [Test]
        public void Equality()
        {
            AkpAlgorithm left = AkpAlgorithm.MLDsa65;
            AkpAlgorithm right = new AkpAlgorithm("ML-DSA-65");

            Assert.IsTrue(left == right);
            Assert.IsFalse(left != right);
            Assert.IsTrue(left.Equals(right));
            Assert.IsTrue(left.Equals((object)right));
            Assert.AreEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Test]
        public void Inequality()
        {
            AkpAlgorithm left = AkpAlgorithm.MLDsa44;
            AkpAlgorithm right = AkpAlgorithm.MLDsa87;

            Assert.IsFalse(left == right);
            Assert.IsTrue(left != right);
            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(left.Equals("not an AkpAlgorithm"));
        }

        [Test]
        public void NullValueThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new AkpAlgorithm(null));
        }
    }
}
