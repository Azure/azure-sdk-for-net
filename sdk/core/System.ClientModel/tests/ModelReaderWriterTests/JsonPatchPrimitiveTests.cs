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

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.property2"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetBoolean("$.property"u8), Is.EqualTo(true));
            Assert.That(jp.GetBoolean("$.property2"u8), Is.EqualTo(false));
            Assert.That(jp.GetNullableValue<bool>("$.property"u8), Is.EqualTo(true));
            Assert.That(jp.GetNullableValue<bool>("$.property2"u8), Is.EqualTo(false));
            Assert.That(jp.GetNullableValue<bool>("$.nullProperty"u8), Is.EqualTo(null));
            Assert.That(jp.TryGetValue("$.property"u8, out bool property), Is.True);
            Assert.That(property, Is.EqualTo(true));
            Assert.That(jp.TryGetValue("$.property2"u8, out bool property2), Is.True);
            Assert.That(property2, Is.EqualTo(false));
            Assert.That(jp.TryGetNullableValue("$.property"u8, out bool? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(true));
            Assert.That(jp.TryGetNullableValue("$.property2"u8, out bool? nullableProperty2), Is.True);
            Assert.That(nullableProperty2, Is.EqualTo(false));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out bool? nullablePropertyNull), Is.True);
            Assert.That(nullablePropertyNull, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":true,\"property2\":false,\"nullProperty\":null}"));
        }

        [Test]
        public void GetBoolean_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetBoolean("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Boolean."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetBoolean("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Boolean."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<bool>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Boolean]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out bool property), Is.False);
            Assert.That(property, Is.EqualTo(default(bool)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out bool notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(bool)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out bool nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(bool)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out bool? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(default(bool?)));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out bool? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(default(bool?)));
        }

        [Test]
        public void GetByte_Success()
        {
            JsonPatch jp = new();
            byte value = 5;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetByte("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<byte>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<byte>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out byte property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out byte? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out byte? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":5,\"nullProperty\":null}"));
        }

        [Test]
        public void GetByte_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetByte("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Byte."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetByte("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Byte."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<byte>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Byte]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out byte property), Is.False);
            Assert.That(property, Is.EqualTo(default(byte)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out byte notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(byte)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out byte nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(byte)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out byte? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out byte? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetDateTime_Success()
        {
            JsonPatch jp = new();
            DateTime value = new(2025, 12, 25, 6, 7, 8);

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetDateTime("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<DateTime>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<DateTime>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out DateTime property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out DateTime? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out DateTime? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"12/25/2025 06:07:08\",\"nullProperty\":null}"));
        }

        [Test]
        public void GetDateTime_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetDateTime("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.DateTime."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetDateTime("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.DateTime."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<DateTime>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.DateTime]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out DateTime property), Is.False);
            Assert.That(property, Is.EqualTo(default(DateTime)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out DateTime notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(DateTime)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out DateTime nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(DateTime)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out DateTime? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out DateTime? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetDateTimeOffset_Success()
        {
            JsonPatch jp = new();
            DateTimeOffset value = new(2025, 12, 25, 6, 7, 8, new TimeSpan(2, 0, 0));

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetDateTimeOffset("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<DateTimeOffset>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<DateTimeOffset>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out DateTimeOffset property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out DateTimeOffset? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out DateTimeOffset? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"12/25/2025 06:07:08 \\u002B02:00\",\"nullProperty\":null}"));
        }

        [Test]
        public void GetDateTimeOffset_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetDateTimeOffset("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.DateTimeOffset."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetDateTimeOffset("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.DateTimeOffset."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<DateTimeOffset>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.DateTimeOffset]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out DateTimeOffset property), Is.False);
            Assert.That(property, Is.EqualTo(default(DateTimeOffset)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out DateTimeOffset notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(DateTimeOffset)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out DateTimeOffset nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(DateTimeOffset)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out DateTimeOffset? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out DateTimeOffset? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetDecimal_Success()
        {
            JsonPatch jp = new();
            decimal value = (decimal)24.56;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetDecimal("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<decimal>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<decimal>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out decimal property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out decimal? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out decimal? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":24.56,\"nullProperty\":null}"));
        }

        [Test]
        public void GetDecimal_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetDecimal("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Decimal."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetDecimal("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Decimal."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<decimal>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Decimal]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out decimal property), Is.False);
            Assert.That(property, Is.EqualTo(default(decimal)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out decimal notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(decimal)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out decimal nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(decimal)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out decimal? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out decimal? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetDouble_Success()
        {
            JsonPatch jp = new();
            double value = 24.56;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetDouble("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<double>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<double>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out double property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out double? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out double? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":24.56,\"nullProperty\":null}"));
        }

        [Test]
        public void GetDouble_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetDouble("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Double."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetDouble("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Double."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<double>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Double]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out double property), Is.False);
            Assert.That(property, Is.EqualTo(default(double)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out double notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(double)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out double nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(double)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out double? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out double? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetFloat_Success()
        {
            JsonPatch jp = new();
            float value = (float)24.5;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetFloat("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<float>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<float>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out float property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out float? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out float? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":24.5,\"nullProperty\":null}"));
        }

        [Test]
        public void GetFloat_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetFloat("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Single."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetFloat("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Single."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<float>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Single]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out float property), Is.False);
            Assert.That(property, Is.EqualTo(default(float)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out float notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(float)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out float nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(float)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out float? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out float? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetGuid_Success()
        {
            JsonPatch jp = new();
            Guid value = new("12345678-1234-1234-1234-1234567890ab");

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetGuid("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<Guid>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<Guid>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out Guid property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out Guid? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out Guid? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"12345678-1234-1234-1234-1234567890ab\",\"nullProperty\":null}"));
        }

        [Test]
        public void GetGuid_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetGuid("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Guid."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetGuid("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Guid."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<Guid>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Guid]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out Guid property), Is.False);
            Assert.That(property, Is.EqualTo(default(Guid)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out Guid notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(Guid)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out Guid nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(Guid)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out Guid? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out Guid? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetInt32_Success()
        {
            JsonPatch jp = new();
            int value = 123;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetInt32("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<int>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<int>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out int property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out int? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out int? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":123,\"nullProperty\":null}"));
        }

        [Test]
        public void GetInt32_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt32("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Int32."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetInt32("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Int32."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<int>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Int32]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out int property), Is.False);
            Assert.That(property, Is.EqualTo(default(int)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out int notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(int)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out int nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(int)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out int? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out int? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetInt64_Success()
        {
            JsonPatch jp = new();
            long value = (long)int.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetInt64("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<long>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<long>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out long property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out long? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out long? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":2147483648,\"nullProperty\":null}"));
        }

        [Test]
        public void GetInt64_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt64("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Int64."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetInt64("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Int64."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<long>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Int64]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out long property), Is.False);
            Assert.That(property, Is.EqualTo(default(long)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out long notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(long)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out long nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(long)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out long? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out long? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetInt8_Success()
        {
            JsonPatch jp = new();
            sbyte value = 64;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetInt8("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<sbyte>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<sbyte>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out sbyte property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out sbyte? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out sbyte? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":64,\"nullProperty\":null}"));
        }

        [Test]
        public void GetInt8_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt8("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.SByte."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetInt8("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.SByte."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<sbyte>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.SByte]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out sbyte property), Is.False);
            Assert.That(property, Is.EqualTo(default(sbyte)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out sbyte notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(sbyte)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out sbyte nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(sbyte)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out sbyte? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out sbyte? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetInt16_Success()
        {
            JsonPatch jp = new();
            short value = sbyte.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetInt16("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<short>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<short>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out short property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out short? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out short? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":128,\"nullProperty\":null}"));
        }

        [Test]
        public void GetInt16_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetInt16("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Int16."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetInt16("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.Int16."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<short>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.Int16]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out short property), Is.False);
            Assert.That(property, Is.EqualTo(default(short)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out short notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(short)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out short nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(short)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out short? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out short? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetTimeSpan_Success()
        {
            JsonPatch jp = new();
            TimeSpan value = new(1, 1, 1, 1, 1);

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetTimeSpan("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<TimeSpan>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<TimeSpan>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out TimeSpan property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out TimeSpan? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out TimeSpan? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"1.01:01:01.0010000\",\"nullProperty\":null}"));
        }

        [Test]
        public void GetTimeSpan_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetTimeSpan("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.TimeSpan."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetTimeSpan("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.TimeSpan."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<TimeSpan>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.TimeSpan]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out TimeSpan property), Is.False);
            Assert.That(property, Is.EqualTo(default(TimeSpan)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out TimeSpan notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(TimeSpan)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out TimeSpan nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(TimeSpan)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out TimeSpan? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out TimeSpan? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetUInt32_Success()
        {
            JsonPatch jp = new();
            uint value = (uint)int.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetUInt32("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<uint>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<uint>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out uint property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out uint? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out uint? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":2147483648,\"nullProperty\":null}"));
        }

        [Test]
        public void GetUInt32_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt32("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.UInt32."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt32("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.UInt32."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<uint>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.UInt32]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out uint property), Is.False);
            Assert.That(property, Is.EqualTo(default(uint)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out uint notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(uint)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out uint nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(uint)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out uint? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out uint? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetUInt64_Success()
        {
            JsonPatch jp = new();
            ulong value = (ulong)long.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetUInt64("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<ulong>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<ulong>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out ulong property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out ulong? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out ulong? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":9223372036854775808,\"nullProperty\":null}"));
        }

        [Test]
        public void GetUInt64_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt64("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.UInt64."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt64("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.UInt64."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<ulong>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.UInt64]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out ulong property), Is.False);
            Assert.That(property, Is.EqualTo(default(ulong)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out ulong notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(ulong)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out ulong nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(ulong)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out ulong? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out ulong? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }

        [Test]
        public void GetUInt16_Success()
        {
            JsonPatch jp = new();
            ushort value = (ushort)short.MaxValue + 1;

            jp.Set("$.property"u8, value);
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            Assert.That(jp.GetUInt16("$.property"u8), Is.EqualTo(value));

            Assert.That(jp.GetNullableValue<ushort>("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetNullableValue<ushort>("$.nullProperty"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.property"u8, out ushort property), Is.True);
            Assert.That(property, Is.EqualTo(value));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out ushort? nullableProperty), Is.True);
            Assert.That(nullableProperty, Is.EqualTo(value));
            Assert.That(jp.TryGetNullableValue("$.nullProperty"u8, out ushort? nullProperty), Is.True);
            Assert.That(nullProperty, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":32768,\"nullProperty\":null}"));
        }

        [Test]
        public void GetUInt16_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, "nonbool");
            jp.SetNull("$.nullProperty"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.nullProperty"u8), Is.True);

            var formatException = Assert.Throws<FormatException>(() => jp.GetUInt16("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.UInt16."));
            var keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            formatException = Assert.Throws<FormatException>(() => jp.GetUInt16("$.nullProperty"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.nullProperty' is not a System.UInt16."));

            formatException = Assert.Throws<FormatException>(() => jp.GetNullableValue<ushort>("$.property"u8));
            Assert.That(formatException!.Message, Is.EqualTo("Value at '$.property' is not a System.Nullable`1[System.UInt16]."));
            keyNotFoundException = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.notPresent"u8));
            Assert.That(keyNotFoundException!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));

            Assert.That(jp.TryGetValue("$.property"u8, out ushort property), Is.False);
            Assert.That(property, Is.EqualTo(default(ushort)));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out ushort notPresent), Is.False);
            Assert.That(property, Is.EqualTo(default(ushort)));
            Assert.That(jp.TryGetValue("$.nullProperty"u8, out ushort nullProperty), Is.False);
            Assert.That(property, Is.EqualTo(default(ushort)));

            Assert.That(jp.TryGetNullableValue("$.property"u8, out ushort? nullableProperty), Is.False);
            Assert.That(nullableProperty, Is.EqualTo(null));
            Assert.That(jp.TryGetNullableValue("$.notPresent"u8, out ushort? nullableNotPresent), Is.False);
            Assert.That(nullableNotPresent, Is.EqualTo(null));
        }
        [Test]
        public void GetString_Success()
        {
            JsonPatch jp = new();
            string value = "value";

            jp.Set("$.property"u8, value);
            jp.SetNull("$.property2"u8);

            Assert.That(jp.Contains("$.property"u8), Is.True);
            Assert.That(jp.Contains("$.property2"u8), Is.True);

            Assert.That(jp.GetString("$.property"u8), Is.EqualTo(value));
            Assert.That(jp.GetString("$.property2"u8), Is.EqualTo(null));
            Assert.That(jp.TryGetValue("$.property"u8, out string? property), Is.True);
            Assert.That(property, Is.EqualTo(value));
            Assert.That(jp.TryGetValue("$.property2"u8, out property), Is.True);
            Assert.That(property, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"property\":\"value\",\"property2\":null}"));
        }

        [Test]
        public void GetString_Fail()
        {
            JsonPatch jp = new();

            jp.Set("$.property"u8, true);

            Assert.That(jp.Contains("$.property"u8), Is.True);

            Assert.That(jp.GetString("$.property"u8), Is.EqualTo("true"));
            Assert.That(jp.TryGetValue("$.property"u8, out string? property), Is.True);
            Assert.That(property, Is.EqualTo("true"));
            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.notPresent"u8));
            Assert.That(ex!.Message, Is.EqualTo("No value found at JSON path '$.notPresent'."));
            Assert.That(jp.TryGetValue("$.notPresent"u8, out property), Is.False);
        }
    }
}
