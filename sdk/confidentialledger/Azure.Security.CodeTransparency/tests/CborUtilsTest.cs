// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        private static byte[] CborArrayRoot()
        {
            var writer = new CborWriter();
            writer.WriteStartArray(1);
            writer.WriteTextString("not-a-map");
            writer.WriteEndArray();
            return writer.Encode();
        }

        private static byte[] CborTextStringRoot()
        {
            var writer = new CborWriter();
            writer.WriteTextString("not-a-map");
            return writer.Encode();
        }

        private static byte[] CborIntegerRoot()
        {
            var writer = new CborWriter();
            writer.WriteInt32(42);
            return writer.Encode();
        }

        // 0xA1 declares a map of one pair, 0x67 declares a 7-byte text string that is not present.
        private static byte[] TruncatedCborMap() => new byte[] { 0xA1, 0x67 };

        // Major type 7 with an invalid additional-information value.
        private static byte[] GarbageCborBytes() => new byte[] { 0xFF, 0xFF, 0xFF };

        private static IEnumerable<TestCaseData> MalformedPayloads()
        {
            yield return new TestCaseData(CborArrayRoot()).SetName("{m}_ArrayRoot");
            yield return new TestCaseData(CborTextStringRoot()).SetName("{m}_TextStringRoot");
            yield return new TestCaseData(CborIntegerRoot()).SetName("{m}_IntegerRoot");
            yield return new TestCaseData(TruncatedCborMap()).SetName("{m}_TruncatedMap");
            yield return new TestCaseData(GarbageCborBytes()).SetName("{m}_GarbageBytes");
        }

        [TestCaseSource(nameof(MalformedPayloads))]
        public void GetStringValueFromCborMapByStringKey_MalformedPayload_ReturnsEmptyStringAndDoesNotThrow(byte[] cborBytes)
        {
            string result = null;

            Assert.DoesNotThrow(() => result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, "key"));
            Assert.AreEqual(string.Empty, result);
        }

        [TestCaseSource(nameof(MalformedPayloads))]
        public void GetStringValueFromCborMapByIntKey_MalformedPayload_ReturnsEmptyStringAndDoesNotThrow(byte[] cborBytes)
        {
            string result = null;

            Assert.DoesNotThrow(() => result = CborUtils.GetStringValueFromCborMapByKey(cborBytes, 1));
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetStringValueFromCborMapByStringKey_TrailingGarbageAfterMap_DoesNotThrow()
        {
            var writer = new CborWriter();
            writer.WriteStartMap(1);
            writer.WriteTextString("key");
            writer.WriteTextString("value");
            writer.WriteEndMap();
            byte[] valid = writer.Encode();

            byte[] withTrailingGarbage = new byte[valid.Length + 2];
            Buffer.BlockCopy(valid, 0, withTrailingGarbage, 0, valid.Length);
            withTrailingGarbage[valid.Length] = 0xFF;
            withTrailingGarbage[valid.Length + 1] = 0xFF;

            string result = null;
            Assert.DoesNotThrow(() => result = CborUtils.GetStringValueFromCborMapByKey(withTrailingGarbage, "key"));
            Assert.AreEqual("value", result);
        }
    }
}
