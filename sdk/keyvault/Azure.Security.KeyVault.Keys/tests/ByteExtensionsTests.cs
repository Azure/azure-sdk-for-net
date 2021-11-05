// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using static Azure.Security.KeyVault.Keys.Cryptography.ByteExtensions;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class ByteExtensionsTests
    {
        [Test]
        public void TakeThrowsArgumentNullException()
        {
            byte[] original = null;
            Assert.Throws<ArgumentNullException>(() => original.Take(0, 0));
        }

        [Test]
        public void TakeThrowsArgumentExceptions()
        {
            byte[] original = Array.Empty<byte>();
            Assert.Throws<ArgumentException>(() => original.Take(-1, 0));
            Assert.Throws<ArgumentException>(() => original.Take(0, -1));
            Assert.Throws<ArgumentException>(() => original.Take(0, 1));
        }

        [Test]
        public void TakeReturnsSameArray()
        {
            byte[] original = new byte[] { 0, 1, 2, 3 };
            byte[] actual = original.Take(original.Length);

            Assert.AreSame(original, actual);
        }

        [Test]
        public void TakeReturnsCopiedArrayFromLength()
        {
            byte[] original = new byte[] { 0, 1, 2, 3 };
            byte[] actual = original.Take(original.Length - 1);

            Assert.AreNotSame(original, actual);
            CollectionAssert.AreEqual(new byte[] { 0, 1, 2 }, actual);
        }

        [Test]
        public void TakeReturnsCopiedArrayFromOffset()
        {
            byte[] original = new byte[] { 0, 1, 2, 3 };
            byte[] actual = original.Take(1, original.Length - 1);

            Assert.AreNotSame(original, actual);
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3 }, actual);
        }
    }
}
