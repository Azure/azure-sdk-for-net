// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchPrimitiveTests
    {
        [Test]
        public void GetBoolean_Success()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, true);
            jp.Set("$.property2"u8, false);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.property2"u8));

            Assert.AreEqual(true, jp.GetBoolean("$.property"u8));
            Assert.AreEqual(false, jp.GetBoolean("$.property2"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out bool property));
            Assert.AreEqual(true, property);
            Assert.IsTrue(jp.TryGetValue("$.property2"u8, out bool property2));
            Assert.AreEqual(false, property2);

            Assert.AreEqual("{\"property\":true,\"property2\":false}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetBoolean_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetBoolean("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a boolean.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out bool property));
            Assert.AreEqual(default(bool), property);
        }

        [Test]
        public void GetByte_Success()
        {
            JsonPatch jp = new();
            byte value = 5;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetByte("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out byte property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":5}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetByte_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetByte("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a byte.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out byte property));
            Assert.AreEqual(default(byte), property);
        }

        [Test]
        public void GetDateTime_Success()
        {
            JsonPatch jp = new();
            DateTime value = new(2025, 12, 25, 6, 7, 8);

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetDateTime("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out DateTime property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":\"12/25/2025 06:07:08\"}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetDateTime_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetDateTime("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a DateTime.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out DateTime property));
            Assert.AreEqual(default(DateTime), property);
        }

        [Test]
        public void GetDateTimeOffset_Success()
        {
            JsonPatch jp = new();
            DateTimeOffset value = new(2025, 12, 25, 6, 7, 8, new TimeSpan(2, 0, 0));

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetDateTimeOffset("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out DateTimeOffset property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":\"12/25/2025 06:07:08 +02:00\"}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetDateTimeOffset_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetDateTimeOffset("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a DateTimeOffset.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out DateTimeOffset property));
            Assert.AreEqual(default(DateTimeOffset), property);
        }

        [Test]
        public void GetDecimal_Success()
        {
            JsonPatch jp = new();
            decimal value = (decimal)24.56;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetDecimal("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out decimal property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":24.56}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetDecimal_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetDecimal("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a decimal.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out decimal property));
            Assert.AreEqual(default(decimal), property);
        }

        [Test]
        public void GetDouble_Success()
        {
            JsonPatch jp = new();
            double value = 24.56;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetDouble("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out double property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":24.56}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetDouble_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetDouble("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a double.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out double property));
            Assert.AreEqual(default(double), property);
        }

        [Test]
        public void GetFloat_Success()
        {
            JsonPatch jp = new();
            float value = (float)24.5;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetFloat("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out float property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":24.5}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetFloat_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetFloat("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a float.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out float property));
            Assert.AreEqual(default(float), property);
        }

        [Test]
        public void GetGuid_Success()
        {
            JsonPatch jp = new();
            Guid value = new("12345678-1234-1234-1234-1234567890ab");

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetGuid("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out Guid property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":\"12345678-1234-1234-1234-1234567890ab\"}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetFuid_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetGuid("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a Guid.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out Guid property));
            Assert.AreEqual(default(Guid), property);
        }

        [Test]
        public void GetInt32_Success()
        {
            JsonPatch jp = new();
            int value = 123;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetInt32("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out int property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":123}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetInt32_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetInt32("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a Int32.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out int property));
            Assert.AreEqual(default(int), property);
        }

        [Test]
        public void GetInt64_Success()
        {
            JsonPatch jp = new();
            long value = (long)int.MaxValue + 1;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetInt64("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out long property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":2147483648}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetInt64_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetInt64("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a Int64.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out long property));
            Assert.AreEqual(default(long), property);
        }

        [Test]
        public void GetInt8_Success()
        {
            JsonPatch jp = new();
            sbyte value = 64;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetInt8("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out sbyte property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":64}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetInt8_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetInt8("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a Int8.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out sbyte property));
            Assert.AreEqual(default(sbyte), property);
        }

        [Test]
        public void GetInt16_Success()
        {
            JsonPatch jp = new();
            short value = sbyte.MaxValue + 1;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetInt16("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out short property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":128}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetInt16_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetInt16("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a Int16.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out short property));
            Assert.AreEqual(default(short), property);
        }

        [Test]
        public void GetTimeSpan_Success()
        {
            JsonPatch jp = new();
            TimeSpan value = new(1, 1, 1, 1, 1);

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetTimeSpan("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out TimeSpan property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":\"1.01:01:01.0010000\"}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetTimeSpan_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetTimeSpan("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a TimeSpan.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out TimeSpan property));
            Assert.AreEqual(default(TimeSpan), property);
        }

        [Test]
        public void GetUInt32_Success()
        {
            JsonPatch jp = new();
            uint value = (uint)int.MaxValue + 1;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetUInt32("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out uint property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":2147483648}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetUInt32_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetUInt32("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a UInt32.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out uint property));
            Assert.AreEqual(default(uint), property);
        }

        [Test]
        public void GetUInt64_Success()
        {
            JsonPatch jp = new();
            ulong value = (ulong)long.MaxValue + 1;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetUInt64("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out ulong property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":9223372036854775808}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetUInt64_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetUInt64("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a UInt64.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out ulong property));
            Assert.AreEqual(default(ulong), property);
        }

        [Test]
        public void GetUInt16_Success()
        {
            JsonPatch jp = new();
            ushort value = (ushort)short.MaxValue + 1;

            jp.Set("$.property"u8, value);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual(value, jp.GetUInt16("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out ushort property));
            Assert.AreEqual(value, property);

            Assert.AreEqual("{\"property\":32768}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetUInt16_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");

            Assert.IsTrue(jp.Contains("$.property"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetUInt16("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a UInt16.", ex!.Message);
            Assert.IsFalse(jp.TryGetValue("$.property"u8, out ushort property));
            Assert.AreEqual(default(ushort), property);
        }

        [Test]
        public void GetString_Success()
        {
            JsonPatch jp = new();
            string value = "value";

            jp.Set("$.property"u8, value);
            jp.SetNull("$.property2"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.property2"u8));

            Assert.AreEqual(value, jp.GetString("$.property"u8));
            Assert.AreEqual(null, jp.GetString("$.property2"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out string? property));
            Assert.AreEqual(value, property);
            Assert.IsTrue(jp.TryGetValue("$.property2"u8, out property));
            Assert.AreEqual(null, property);

            Assert.AreEqual("{\"property\":\"value\",\"property2\":null}", JsonPatchTests.GetJsonString(jp));
        }

        [Test]
        public void GetString_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, true);

            Assert.IsTrue(jp.Contains("$.property"u8));

            Assert.AreEqual("true", jp.GetString("$.property"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out string? property));
            Assert.AreEqual("true", property);
        }
    }
}
