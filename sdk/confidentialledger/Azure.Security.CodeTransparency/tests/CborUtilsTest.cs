// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Formats.Cbor;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CborUtilsTest : ClientTestBase
    {
        public CborUtilsTest(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_ValidInput_ReturnsValue()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(2);
            writer.WriteTextString("key1");
            writer.WriteTextString("value1");
            writer.WriteTextString("key2");
            writer.WriteTextString("value2");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, "key1");

            // Assert
            Assert.AreEqual("value1", result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_KeyNotFound_ReturnsEmptyString()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(1);
            writer.WriteTextString("key1");
            writer.WriteTextString("value1");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, "nonexistent");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_NullBytes_ReturnsEmptyString()
        {
            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey((byte[])null, "key");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_EmptyBytes_ReturnsEmptyString()
        {
            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(Array.Empty<byte>(), "key");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_NullKey_ReturnsEmptyString()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(1);
            writer.WriteTextString("key1");
            writer.WriteTextString("value1");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, null);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_EmptyKey_ReturnsEmptyString()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(1);
            writer.WriteTextString("key1");
            writer.WriteTextString("value1");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, string.Empty);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_ValueNotString_ReturnsEmptyString()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(1);
            writer.WriteTextString("key1");
            writer.WriteInt32(42);
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, "key1");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_NonTextKey_SkipsAndContinues()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(2);
            writer.WriteInt32(1);
            writer.WriteTextString("value1");
            writer.WriteTextString("key2");
            writer.WriteTextString("value2");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, "key2");

            // Assert
            Assert.AreEqual("value2", result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_ValidInput_ReturnsValue()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(2);
            writer.WriteInt32(1);
            writer.WriteTextString("value1");
            writer.WriteInt32(2);
            writer.WriteTextString("value2");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, 1);

            // Assert
            Assert.AreEqual("value1", result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_NegativeIntKey_ReturnsValue()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(1);
            writer.WriteInt32(-5);
            writer.WriteTextString("negative_value");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, -5);

            // Assert
            Assert.AreEqual("negative_value", result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_KeyNotFound_ReturnsEmptyString()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(1);
            writer.WriteInt32(1);
            writer.WriteTextString("value1");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, 99);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_NullBytes_ReturnsEmptyString()
        {
            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey((byte[])null, 1);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_EmptyBytes_ReturnsEmptyString()
        {
            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(Array.Empty<byte>(), 1);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_ValueNotString_ReturnsEmptyString()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(1);
            writer.WriteInt32(1);
            writer.WriteInt32(42);
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, 1);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_MixedKeyTypes_ReturnsCorrectValue()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(3);
            writer.WriteTextString("stringKey");
            writer.WriteTextString("stringValue");
            writer.WriteInt32(10);
            writer.WriteTextString("intValue");
            writer.WriteByteString(new byte[] { 1, 2, 3 });
            writer.WriteTextString("byteValue");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, 10);

            // Assert
            Assert.AreEqual("intValue", result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_UnsupportedKeyType_SkipsAndContinues()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(2);
            writer.WriteByteString(new byte[] { 1, 2 });
            writer.WriteTextString("byteKeyValue");
            writer.WriteInt32(5);
            writer.WriteTextString("intKeyValue");
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, 5);

            // Assert
            Assert.AreEqual("intKeyValue", result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_EmptyMap_ReturnsEmptyString()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(0);
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, "key");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByIntKey_EmptyMap_ReturnsEmptyString()
        {
            // Arrange
            var writer = new CborWriter();
            writer.WriteStartMap(0);
            writer.WriteEndMap();
            byte[] cborBytes = writer.Encode();

            // Act
            string result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, 1);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }
    }
}