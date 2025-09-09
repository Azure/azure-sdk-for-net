// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
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
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.property2"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(true, jp.GetBoolean("$.property"u8));
            Assert.AreEqual(false, jp.GetBoolean("$.property2"u8));
            Assert.AreEqual(true, jp.GetNullableValue<bool>("$.property"u8));
            Assert.AreEqual(false, jp.GetNullableValue<bool>("$.property2"u8));
            Assert.AreEqual(null, jp.GetNullableValue<bool>("$.nullProperty"u8));
            Assert.IsTrue(jp.TryGetValue("$.property"u8, out bool property));
            Assert.AreEqual(true, property);
            Assert.IsTrue(jp.TryGetValue("$.property2"u8, out bool property2));
            Assert.AreEqual(false, property2);
            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out bool? nullableProperty));
            Assert.AreEqual(true, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.property2"u8, out bool? nullableProperty2));
            Assert.AreEqual(false, nullableProperty2);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out bool? nullablePropertyNull));
            Assert.AreEqual(null, nullablePropertyNull);

            Assert.AreEqual("{\"property\":true,\"property2\":false,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetBoolean_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetBoolean("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Boolean.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetBoolean("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Boolean.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<bool>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Boolean].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out bool property));
            Assert.AreEqual(default(bool), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out bool notPresent));
            Assert.AreEqual(default(bool), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out bool nullProperty));
            Assert.AreEqual(default(bool), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out bool? nullableProperty));
            Assert.AreEqual(default(bool?), nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out bool? nullableNotPresent));
            Assert.AreEqual(default(bool?), nullableNotPresent);
        }

        [Test]
        public void GetByte_Success()
        {
            JsonPatch jp = new();
            byte value = 5;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetByte("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<byte>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<byte>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out byte property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out byte? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out byte? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":5,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetByte_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetByte("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Byte.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetByte("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Byte.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<byte>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Byte].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out byte property));
            Assert.AreEqual(default(byte), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out byte notPresent));
            Assert.AreEqual(default(byte), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out byte nullProperty));
            Assert.AreEqual(default(byte), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out byte? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out byte? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetDateTime_Success()
        {
            JsonPatch jp = new();
            DateTime value = new(2025, 12, 25, 6, 7, 8);

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetDateTime("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<DateTime>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<DateTime>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out DateTime property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out DateTime? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out DateTime? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":\"12/25/2025 06:07:08\",\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetDateTime_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetDateTime("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.DateTime.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetDateTime("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.DateTime.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<DateTime>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.DateTime].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out DateTime property));
            Assert.AreEqual(default(DateTime), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out DateTime notPresent));
            Assert.AreEqual(default(DateTime), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out DateTime nullProperty));
            Assert.AreEqual(default(DateTime), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out DateTime? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out DateTime? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetDateTimeOffset_Success()
        {
            JsonPatch jp = new();
            DateTimeOffset value = new(2025, 12, 25, 6, 7, 8, new TimeSpan(2, 0, 0));

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetDateTimeOffset("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<DateTimeOffset>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<DateTimeOffset>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out DateTimeOffset property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out DateTimeOffset? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out DateTimeOffset? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":\"12/25/2025 06:07:08 \\u002B02:00\",\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetDateTimeOffset_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetDateTimeOffset("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.DateTimeOffset.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetDateTimeOffset("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.DateTimeOffset.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<DateTimeOffset>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.DateTimeOffset].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out DateTimeOffset property));
            Assert.AreEqual(default(DateTimeOffset), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out DateTimeOffset notPresent));
            Assert.AreEqual(default(DateTimeOffset), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out DateTimeOffset nullProperty));
            Assert.AreEqual(default(DateTimeOffset), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out DateTimeOffset? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out DateTimeOffset? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetDecimal_Success()
        {
            JsonPatch jp = new();
            decimal value = (decimal)24.56;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetDecimal("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<decimal>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<decimal>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out decimal property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out decimal? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out decimal? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":24.56,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetDecimal_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetDecimal("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Decimal.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetDecimal("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Decimal.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<decimal>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Decimal].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out decimal property));
            Assert.AreEqual(default(decimal), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out decimal notPresent));
            Assert.AreEqual(default(decimal), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out decimal nullProperty));
            Assert.AreEqual(default(decimal), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out decimal? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out decimal? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetDouble_Success()
        {
            JsonPatch jp = new();
            double value = 24.56;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetDouble("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<double>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<double>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out double property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out double? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out double? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":24.56,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetDouble_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetDouble("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Double.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetDouble("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Double.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<double>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Double].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out double property));
            Assert.AreEqual(default(double), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out double notPresent));
            Assert.AreEqual(default(double), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out double nullProperty));
            Assert.AreEqual(default(double), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out double? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out double? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetFloat_Success()
        {
            JsonPatch jp = new();
            float value = (float)24.5;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetFloat("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<float>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<float>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out float property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out float? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out float? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":24.5,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetFloat_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetFloat("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Single.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetFloat("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Single.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<float>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Single].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out float property));
            Assert.AreEqual(default(float), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out float notPresent));
            Assert.AreEqual(default(float), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out float nullProperty));
            Assert.AreEqual(default(float), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out float? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out float? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetGuid_Success()
        {
            JsonPatch jp = new();
            Guid value = new("12345678-1234-1234-1234-1234567890ab");

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetGuid("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<Guid>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<Guid>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out Guid property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out Guid? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out Guid? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":\"12345678-1234-1234-1234-1234567890ab\",\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetGuid_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetGuid("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Guid.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetGuid("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Guid.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<Guid>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Guid].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out Guid property));
            Assert.AreEqual(default(Guid), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out Guid notPresent));
            Assert.AreEqual(default(Guid), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out Guid nullProperty));
            Assert.AreEqual(default(Guid), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out Guid? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out Guid? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetInt32_Success()
        {
            JsonPatch jp = new();
            int value = 123;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetInt32("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<int>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<int>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out int property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out int? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out int? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":123,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetInt32_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt32("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Int32.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetInt32("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Int32.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<int>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Int32].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out int property));
            Assert.AreEqual(default(int), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out int notPresent));
            Assert.AreEqual(default(int), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out int nullProperty));
            Assert.AreEqual(default(int), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out int? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out int? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetInt64_Success()
        {
            JsonPatch jp = new();
            long value = (long)int.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetInt64("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<long>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<long>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out long property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out long? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out long? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":2147483648,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetInt64_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt64("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Int64.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetInt64("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Int64.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<long>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Int64].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out long property));
            Assert.AreEqual(default(long), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out long notPresent));
            Assert.AreEqual(default(long), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out long nullProperty));
            Assert.AreEqual(default(long), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out long? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out long? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetInt8_Success()
        {
            JsonPatch jp = new();
            sbyte value = 64;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetInt8("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<sbyte>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<sbyte>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out sbyte property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out sbyte? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out sbyte? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":64,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetInt8_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt8("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.SByte.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetInt8("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.SByte.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<sbyte>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.SByte].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out sbyte property));
            Assert.AreEqual(default(sbyte), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out sbyte notPresent));
            Assert.AreEqual(default(sbyte), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out sbyte nullProperty));
            Assert.AreEqual(default(sbyte), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out sbyte? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out sbyte? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetInt16_Success()
        {
            JsonPatch jp = new();
            short value = sbyte.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetInt16("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<short>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<short>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out short property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out short? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out short? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":128,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetInt16_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt16("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Int16.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetInt16("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.Int16.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<short>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.Int16].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out short property));
            Assert.AreEqual(default(short), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out short notPresent));
            Assert.AreEqual(default(short), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out short nullProperty));
            Assert.AreEqual(default(short), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out short? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out short? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetTimeSpan_Success()
        {
            JsonPatch jp = new();
            TimeSpan value = new(1, 1, 1, 1, 1);

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetTimeSpan("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<TimeSpan>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<TimeSpan>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out TimeSpan property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out TimeSpan? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out TimeSpan? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":\"1.01:01:01.0010000\",\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetTimeSpan_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetTimeSpan("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.TimeSpan.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetTimeSpan("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.TimeSpan.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<TimeSpan>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.TimeSpan].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out TimeSpan property));
            Assert.AreEqual(default(TimeSpan), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out TimeSpan notPresent));
            Assert.AreEqual(default(TimeSpan), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out TimeSpan nullProperty));
            Assert.AreEqual(default(TimeSpan), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out TimeSpan? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out TimeSpan? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetUInt32_Success()
        {
            JsonPatch jp = new();
            uint value = (uint)int.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetUInt32("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<uint>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<uint>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out uint property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out uint? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out uint? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":2147483648,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetUInt32_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt32("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.UInt32.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt32("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.UInt32.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<uint>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.UInt32].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out uint property));
            Assert.AreEqual(default(uint), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out uint notPresent));
            Assert.AreEqual(default(uint), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out uint nullProperty));
            Assert.AreEqual(default(uint), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out uint? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out uint? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetUInt64_Success()
        {
            JsonPatch jp = new();
            ulong value = (ulong)long.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetUInt64("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<ulong>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<ulong>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out ulong property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out ulong? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out ulong? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":9223372036854775808,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetUInt64_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt64("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.UInt64.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt64("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.UInt64.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<ulong>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.UInt64].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out ulong property));
            Assert.AreEqual(default(ulong), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out ulong notPresent));
            Assert.AreEqual(default(ulong), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out ulong nullProperty));
            Assert.AreEqual(default(ulong), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out ulong? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out ulong? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
        }

        [Test]
        public void GetUInt16_Success()
        {
            JsonPatch jp = new();
            ushort value = (ushort)short.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            Assert.AreEqual(value, jp.GetUInt16("$.property"u8));

            Assert.AreEqual(value, jp.GetNullableValue<ushort>("$.property"u8));
            Assert.AreEqual(null, jp.GetNullableValue<ushort>("$.nullProperty"u8));

            Assert.IsTrue(jp.TryGetValue("$.property"u8, out ushort property));
            Assert.AreEqual(value, property);

            Assert.IsTrue(jp.TryGetNullableValue("$.property"u8, out ushort? nullableProperty));
            Assert.AreEqual(value, nullableProperty);
            Assert.IsTrue(jp.TryGetNullableValue("$.nullProperty"u8, out ushort? nullProperty));
            Assert.AreEqual(null, nullProperty);

            Assert.AreEqual("{\"property\":32768,\"nullProperty\":null}", jp.ToString("J"));
        }

        [Test]
        public void GetUInt16_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.IsTrue(jp.Contains("$.property"u8));
            Assert.IsTrue(jp.Contains("$.nullProperty"u8));

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt16("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.UInt16.", formatException!.Message);
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt16("$.nullProperty"u8));
            Assert.AreEqual("Value at '$.nullProperty' is not a System.UInt16.", formatException!.Message);

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<ushort>("$.property"u8));
            Assert.AreEqual("Value at '$.property' is not a System.Nullable`1[System.UInt16].", formatException!.Message);
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", keyNotFoundException!.Message);

            Assert.IsFalse(jp.TryGetValue("$.property"u8, out ushort property));
            Assert.AreEqual(default(ushort), property);
            Assert.IsFalse(jp.TryGetValue("$.notPresent"u8, out ushort notPresent));
            Assert.AreEqual(default(ushort), property);
            Assert.IsFalse(jp.TryGetValue("$.nullProperty"u8, out ushort nullProperty));
            Assert.AreEqual(default(ushort), property);

            Assert.IsFalse(jp.TryGetNullableValue("$.property"u8, out ushort? nullableProperty));
            Assert.AreEqual(null, nullableProperty);
            Assert.IsFalse(jp.TryGetNullableValue("$.notPresent"u8, out ushort? nullableNotPresent));
            Assert.AreEqual(null, nullableNotPresent);
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

            Assert.AreEqual("{\"property\":\"value\",\"property2\":null}", jp.ToString("J"));
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
            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.notPresent"u8));
            Assert.AreEqual("No value found at JSON path '$.notPresent'.", ex!.Message);
        }
    }
}
