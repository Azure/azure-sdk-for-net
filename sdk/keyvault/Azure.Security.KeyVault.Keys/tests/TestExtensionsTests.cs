// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class TestExtensionsTests
    {
        [TestCase(new byte[] { 0xec }, 236)]
        [TestCase(new byte[] { 0x00, 0x10 }, 4_096)]
        [TestCase(new byte[] { 0x01, 0x00, 0x01 }, 65_537)]
        public void ConvertToInt32Tests(byte[] buffer, int expected)
        {
            int actual = buffer.ToInt32();
            Assert.AreEqual(expected, actual);
        }
    }
}
