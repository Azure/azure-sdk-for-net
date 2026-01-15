// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchAppendPrimitiveTests
    {
        [Test]
        public void Append_Boolean()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, true);
            jp.Append("$.array"u8, false);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetBoolean("$.array[0]"u8), Is.EqualTo(true));
            Assert.That(jp.GetBoolean("$.array[1]"u8), Is.EqualTo(false));

            Assert.That(jp.GetNullableValue<bool>("$.array[0]"u8), Is.EqualTo(true));
            Assert.That(jp.GetNullableValue<bool>("$.array[1]"u8), Is.EqualTo(false));
            Assert.That(jp.GetNullableValue<bool>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out bool boolValue0), Is.True);
            Assert.That(boolValue0, Is.EqualTo(true));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out bool boolValue1), Is.True);
            Assert.That(boolValue1, Is.EqualTo(false));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out bool? nullableBoolValue0), Is.True);
            Assert.That(nullableBoolValue0, Is.EqualTo(true));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out bool? nullableBoolValue1), Is.True);
            Assert.That(nullableBoolValue1, Is.EqualTo(false));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out bool? nullableBoolValue2), Is.True);
            Assert.That(nullableBoolValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[true,false,null]}"));
        }

        [Test]
        public void Append_Byte()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, (byte)42);
            jp.Append("$.array"u8, (byte)255);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetByte("$.array[0]"u8), Is.EqualTo(42));
            Assert.That(jp.GetByte("$.array[1]"u8), Is.EqualTo(255));

            Assert.That(jp.GetNullableValue<byte>("$.array[0]"u8), Is.EqualTo(42));
            Assert.That(jp.GetNullableValue<byte>("$.array[1]"u8), Is.EqualTo(255));
            Assert.That(jp.GetNullableValue<byte>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out byte byteValue0), Is.True);
            Assert.That(byteValue0, Is.EqualTo(42));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out byte byteValue1), Is.True);
            Assert.That(byteValue1, Is.EqualTo(255));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out byte? nullableByteValue0), Is.True);
            Assert.That(nullableByteValue0, Is.EqualTo(42));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out byte? nullableByteValue1), Is.True);
            Assert.That(nullableByteValue1, Is.EqualTo(255));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out byte? nullableByteValue2), Is.True);
            Assert.That(nullableByteValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[42,255,null]}"));
        }

        [Test]
        public void Append_DateTime()
        {
            JsonPatch jp = new();

            DateTime dt1 = new(2024, 1, 1, 12, 0, 0);
            DateTime dt2 = new(2024, 12, 31, 23, 59, 59);

            jp.Append("$.array"u8, dt1);
            jp.Append("$.array"u8, dt2);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetDateTime("$.array[0]"u8), Is.EqualTo(dt1));
            Assert.That(jp.GetDateTime("$.array[1]"u8), Is.EqualTo(dt2));

            Assert.That(jp.GetNullableValue<DateTime>("$.array[0]"u8), Is.EqualTo(dt1));
            Assert.That(jp.GetNullableValue<DateTime>("$.array[1]"u8), Is.EqualTo(dt2));
            Assert.That(jp.GetNullableValue<DateTime>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out DateTime dateTimeValue0), Is.True);
            Assert.That(dateTimeValue0, Is.EqualTo(dt1));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out DateTime dateTimeValue1), Is.True);
            Assert.That(dateTimeValue1, Is.EqualTo(dt2));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out DateTime? nullableDateTimeValue0), Is.True);
            Assert.That(nullableDateTimeValue0, Is.EqualTo(dt1));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out DateTime? nullableDateTimeValue1), Is.True);
            Assert.That(nullableDateTimeValue1, Is.EqualTo(dt2));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out DateTime? nullableDateTimeValue2), Is.True);
            Assert.That(nullableDateTimeValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[\"01/01/2024 12:00:00\",\"12/31/2024 23:59:59\",null]}"));
        }

        [Test]
        public void Append_DateTimeOffset()
        {
            JsonPatch jp = new();

            DateTimeOffset dto1 = new(2024, 1, 1, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset dto2 = new(2024, 12, 31, 23, 59, 59, TimeSpan.FromHours(2));

            jp.Append("$.array"u8, dto1);
            jp.Append("$.array"u8, dto2);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetDateTimeOffset("$.array[0]"u8), Is.EqualTo(dto1));
            Assert.That(jp.GetDateTimeOffset("$.array[1]"u8), Is.EqualTo(dto2));

            Assert.That(jp.GetNullableValue<DateTimeOffset>("$.array[0]"u8), Is.EqualTo(dto1));
            Assert.That(jp.GetNullableValue<DateTimeOffset>("$.array[1]"u8), Is.EqualTo(dto2));
            Assert.That(jp.GetNullableValue<DateTimeOffset>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out DateTimeOffset dateTimeOffsetValue0), Is.True);
            Assert.That(dateTimeOffsetValue0, Is.EqualTo(dto1));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out DateTimeOffset dateTimeOffsetValue1), Is.True);
            Assert.That(dateTimeOffsetValue1, Is.EqualTo(dto2));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out DateTimeOffset? nullableDateTimeOffsetValue0), Is.True);
            Assert.That(nullableDateTimeOffsetValue0, Is.EqualTo(dto1));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out DateTimeOffset? nullableDateTimeOffsetValue1), Is.True);
            Assert.That(nullableDateTimeOffsetValue1, Is.EqualTo(dto2));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out DateTimeOffset? nullableDateTimeOffsetValue2), Is.True);
            Assert.That(nullableDateTimeOffsetValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[\"01/01/2024 12:00:00 +01:00\",\"12/31/2024 23:59:59 +02:00\",null]}"));
        }

        [Test]
        public void Append_Decimal()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 123.45m);
            jp.Append("$.array"u8, 67890.12m);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetDecimal("$.array[0]"u8), Is.EqualTo(123.45m));
            Assert.That(jp.GetDecimal("$.array[1]"u8), Is.EqualTo(67890.12m));

            Assert.That(jp.GetNullableValue<decimal>("$.array[0]"u8), Is.EqualTo(123.45m));
            Assert.That(jp.GetNullableValue<decimal>("$.array[1]"u8), Is.EqualTo(67890.12m));
            Assert.That(jp.GetNullableValue<decimal>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out decimal decimalValue0), Is.True);
            Assert.That(decimalValue0, Is.EqualTo(123.45m));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out decimal decimalValue1), Is.True);
            Assert.That(decimalValue1, Is.EqualTo(67890.12m));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out decimal? nullableDecimalValue0), Is.True);
            Assert.That(nullableDecimalValue0, Is.EqualTo(123.45m));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out decimal? nullableDecimalValue1), Is.True);
            Assert.That(nullableDecimalValue1, Is.EqualTo(67890.12m));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out decimal? nullableDecimalValue2), Is.True);
            Assert.That(nullableDecimalValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[123.45,67890.12,null]}"));
        }

        [Test]
        public void Append_Double()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 123.45);
            jp.Append("$.array"u8, 67890.12);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetDouble("$.array[0]"u8), Is.EqualTo(123.45));
            Assert.That(jp.GetDouble("$.array[1]"u8), Is.EqualTo(67890.12));

            Assert.That(jp.GetNullableValue<double>("$.array[0]"u8), Is.EqualTo(123.45));
            Assert.That(jp.GetNullableValue<double>("$.array[1]"u8), Is.EqualTo(67890.12));
            Assert.That(jp.GetNullableValue<double>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out double doubleValue0), Is.True);
            Assert.That(doubleValue0, Is.EqualTo(123.45));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out double doubleValue1), Is.True);
            Assert.That(doubleValue1, Is.EqualTo(67890.12));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out double? nullableDoubleValue0), Is.True);
            Assert.That(nullableDoubleValue0, Is.EqualTo(123.45));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out double? nullableDoubleValue1), Is.True);
            Assert.That(nullableDoubleValue1, Is.EqualTo(67890.12));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out double? nullableDoubleValue2), Is.True);
            Assert.That(nullableDoubleValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[123.45,67890.12,null]}"));
        }

        [Test]
        public void Append_Float()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 123.5f);
            jp.Append("$.array"u8, 67890.5f);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetFloat("$.array[0]"u8), Is.EqualTo(123.5f));
            Assert.That(jp.GetFloat("$.array[1]"u8), Is.EqualTo(67890.5f));

            Assert.That(jp.GetNullableValue<float>("$.array[0]"u8), Is.EqualTo(123.5f));
            Assert.That(jp.GetNullableValue<float>("$.array[1]"u8), Is.EqualTo(67890.5f));
            Assert.That(jp.GetNullableValue<float>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out float floatValue0), Is.True);
            Assert.That(floatValue0, Is.EqualTo(123.5f));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out float floatValue1), Is.True);
            Assert.That(floatValue1, Is.EqualTo(67890.5f));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out float? nullableFloatValue0), Is.True);
            Assert.That(nullableFloatValue0, Is.EqualTo(123.5f));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out float? nullableFloatValue1), Is.True);
            Assert.That(nullableFloatValue1, Is.EqualTo(67890.5f));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out float? nullableFloatValue2), Is.True);
            Assert.That(nullableFloatValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[123.5,67890.5,null]}"));
        }

        [Test]
        public void Append_Guid()
        {
            JsonPatch jp = new();

            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();

            jp.Append("$.array"u8, guid1);
            jp.Append("$.array"u8, guid2);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetGuid("$.array[0]"u8), Is.EqualTo(guid1));
            Assert.That(jp.GetGuid("$.array[1]"u8), Is.EqualTo(guid2));

            Assert.That(jp.GetNullableValue<Guid>("$.array[0]"u8), Is.EqualTo(guid1));
            Assert.That(jp.GetNullableValue<Guid>("$.array[1]"u8), Is.EqualTo(guid2));
            Assert.That(jp.GetNullableValue<Guid>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out Guid guidValue0), Is.True);
            Assert.That(guidValue0, Is.EqualTo(guid1));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out Guid guidValue1), Is.True);
            Assert.That(guidValue1, Is.EqualTo(guid2));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out Guid? nullableGuidValue0), Is.True);
            Assert.That(nullableGuidValue0, Is.EqualTo(guid1));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out Guid? nullableGuidValue1), Is.True);
            Assert.That(nullableGuidValue1, Is.EqualTo(guid2));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out Guid? nullableGuidValue2), Is.True);
            Assert.That(nullableGuidValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo($"{{\"array\":[\"{guid1}\",\"{guid2}\",null]}}"));
        }

        [Test]
        public void Append_Int32()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 42);
            jp.Append("$.array"u8, 255);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetInt32("$.array[0]"u8), Is.EqualTo(42));
            Assert.That(jp.GetInt32("$.array[1]"u8), Is.EqualTo(255));

            Assert.That(jp.GetNullableValue<int>("$.array[0]"u8), Is.EqualTo(42));
            Assert.That(jp.GetNullableValue<int>("$.array[1]"u8), Is.EqualTo(255));
            Assert.That(jp.GetNullableValue<int>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out int intValue0), Is.True);
            Assert.That(intValue0, Is.EqualTo(42));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out int intValue1), Is.True);
            Assert.That(intValue1, Is.EqualTo(255));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out int? nullableIntValue0), Is.True);
            Assert.That(nullableIntValue0, Is.EqualTo(42));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out int? nullableIntValue1), Is.True);
            Assert.That(nullableIntValue1, Is.EqualTo(255));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out int? nullableIntValue2), Is.True);
            Assert.That(nullableIntValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[42,255,null]}"));
        }

        [Test]
        public void Append_Int64()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 42000000000L);
            jp.Append("$.array"u8, 25500000000L);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetInt64("$.array[0]"u8), Is.EqualTo(42000000000L));
            Assert.That(jp.GetInt64("$.array[1]"u8), Is.EqualTo(25500000000L));

            Assert.That(jp.GetNullableValue<long>("$.array[0]"u8), Is.EqualTo(42000000000L));
            Assert.That(jp.GetNullableValue<long>("$.array[1]"u8), Is.EqualTo(25500000000L));
            Assert.That(jp.GetNullableValue<long>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out long longValue0), Is.True);
            Assert.That(longValue0, Is.EqualTo(42000000000L));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out long longValue1), Is.True);
            Assert.That(longValue1, Is.EqualTo(25500000000L));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out long? nullableLongValue0), Is.True);
            Assert.That(nullableLongValue0, Is.EqualTo(42000000000L));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out long? nullableLongValue1), Is.True);
            Assert.That(nullableLongValue1, Is.EqualTo(25500000000L));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out long? nullableLongValue2), Is.True);
            Assert.That(nullableLongValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[42000000000,25500000000,null]}"));
        }

        [Test]
        public void Append_Int8()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, (sbyte)42);
            jp.Append("$.array"u8, (sbyte)-100);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetInt8("$.array[0]"u8), Is.EqualTo((sbyte)42));
            Assert.That(jp.GetInt8("$.array[1]"u8), Is.EqualTo((sbyte)-100));

            Assert.That(jp.GetNullableValue<sbyte>("$.array[0]"u8), Is.EqualTo((sbyte)42));
            Assert.That(jp.GetNullableValue<sbyte>("$.array[1]"u8), Is.EqualTo((sbyte)-100));
            Assert.That(jp.GetNullableValue<sbyte>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out sbyte sbyteValue0), Is.True);
            Assert.That(sbyteValue0, Is.EqualTo((sbyte)42));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out sbyte sbyteValue1), Is.True);
            Assert.That(sbyteValue1, Is.EqualTo((sbyte)-100));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out sbyte? nullableSbyteValue0), Is.True);
            Assert.That(nullableSbyteValue0, Is.EqualTo((sbyte)42));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out sbyte? nullableSbyteValue1), Is.True);
            Assert.That(nullableSbyteValue1, Is.EqualTo((sbyte)-100));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out sbyte? nullableSbyteValue2), Is.True);
            Assert.That(nullableSbyteValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[42,-100,null]}"));
        }

        [Test]
        public void Append_Int16()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, (short)32000);
            jp.Append("$.array"u8, (short)-16000);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetInt16("$.array[0]"u8), Is.EqualTo((short)32000));
            Assert.That(jp.GetInt16("$.array[1]"u8), Is.EqualTo((short)-16000));

            Assert.That(jp.GetNullableValue<short>("$.array[0]"u8), Is.EqualTo((short)32000));
            Assert.That(jp.GetNullableValue<short>("$.array[1]"u8), Is.EqualTo((short)-16000));
            Assert.That(jp.GetNullableValue<short>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out short shortValue0), Is.True);
            Assert.That(shortValue0, Is.EqualTo((short)32000));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out short shortValue1), Is.True);
            Assert.That(shortValue1, Is.EqualTo((short)-16000));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out short? nullableShortValue0), Is.True);
            Assert.That(nullableShortValue0, Is.EqualTo((short)32000));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out short? nullableShortValue1), Is.True);
            Assert.That(nullableShortValue1, Is.EqualTo((short)-16000));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out short? nullableShortValue2), Is.True);
            Assert.That(nullableShortValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[32000,-16000,null]}"));
        }

        [Test]
        public void Append_TimeSpan()
        {
            JsonPatch jp = new();

            TimeSpan ts1 = TimeSpan.FromHours(1.5);
            TimeSpan ts2 = TimeSpan.FromDays(2);

            jp.Append("$.array"u8, ts1);
            jp.Append("$.array"u8, ts2);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetTimeSpan("$.array[0]"u8), Is.EqualTo(ts1));
            Assert.That(jp.GetTimeSpan("$.array[1]"u8), Is.EqualTo(ts2));

            Assert.That(jp.GetNullableValue<TimeSpan>("$.array[0]"u8), Is.EqualTo(ts1));
            Assert.That(jp.GetNullableValue<TimeSpan>("$.array[1]"u8), Is.EqualTo(ts2));
            Assert.That(jp.GetNullableValue<TimeSpan>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out TimeSpan timeSpanValue0), Is.True);
            Assert.That(timeSpanValue0, Is.EqualTo(ts1));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out TimeSpan timeSpanValue1), Is.True);
            Assert.That(timeSpanValue1, Is.EqualTo(ts2));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out TimeSpan? nullableTimeSpanValue0), Is.True);
            Assert.That(nullableTimeSpanValue0, Is.EqualTo(ts1));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out TimeSpan? nullableTimeSpanValue1), Is.True);
            Assert.That(nullableTimeSpanValue1, Is.EqualTo(ts2));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out TimeSpan? nullableTimeSpanValue2), Is.True);
            Assert.That(nullableTimeSpanValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[\"01:30:00\",\"2.00:00:00\",null]}"));
        }

        [Test]
        public void Append_UInt32()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 42u);
            jp.Append("$.array"u8, 255u);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetUInt32("$.array[0]"u8), Is.EqualTo(42u));
            Assert.That(jp.GetUInt32("$.array[1]"u8), Is.EqualTo(255u));

            Assert.That(jp.GetNullableValue<uint>("$.array[0]"u8), Is.EqualTo(42u));
            Assert.That(jp.GetNullableValue<uint>("$.array[1]"u8), Is.EqualTo(255u));
            Assert.That(jp.GetNullableValue<uint>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out uint uintValue0), Is.True);
            Assert.That(uintValue0, Is.EqualTo(42u));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out uint uintValue1), Is.True);
            Assert.That(uintValue1, Is.EqualTo(255u));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out uint? nullableUintValue0), Is.True);
            Assert.That(nullableUintValue0, Is.EqualTo(42u));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out uint? nullableUintValue1), Is.True);
            Assert.That(nullableUintValue1, Is.EqualTo(255u));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out uint? nullableUintValue2), Is.True);
            Assert.That(nullableUintValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[42,255,null]}"));
        }

        [Test]
        public void Append_UInt64()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 42000000000UL);
            jp.Append("$.array"u8, 25500000000UL);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetUInt64("$.array[0]"u8), Is.EqualTo(42000000000UL));
            Assert.That(jp.GetUInt64("$.array[1]"u8), Is.EqualTo(25500000000UL));

            Assert.That(jp.GetNullableValue<ulong>("$.array[0]"u8), Is.EqualTo(42000000000UL));
            Assert.That(jp.GetNullableValue<ulong>("$.array[1]"u8), Is.EqualTo(25500000000UL));
            Assert.That(jp.GetNullableValue<ulong>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out ulong ulongValue0), Is.True);
            Assert.That(ulongValue0, Is.EqualTo(42000000000UL));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out ulong ulongValue1), Is.True);
            Assert.That(ulongValue1, Is.EqualTo(25500000000UL));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out ulong? nullableUlongValue0), Is.True);
            Assert.That(nullableUlongValue0, Is.EqualTo(42000000000UL));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out ulong? nullableUlongValue1), Is.True);
            Assert.That(nullableUlongValue1, Is.EqualTo(25500000000UL));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out ulong? nullableUlongValue2), Is.True);
            Assert.That(nullableUlongValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[42000000000,25500000000,null]}"));
        }

        [Test]
        public void Append_UInt16()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, (ushort)32000);
            jp.Append("$.array"u8, (ushort)16000);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetUInt16("$.array[0]"u8), Is.EqualTo((ushort)32000));
            Assert.That(jp.GetUInt16("$.array[1]"u8), Is.EqualTo((ushort)16000));

            Assert.That(jp.GetNullableValue<ushort>("$.array[0]"u8), Is.EqualTo((ushort)32000));
            Assert.That(jp.GetNullableValue<ushort>("$.array[1]"u8), Is.EqualTo((ushort)16000));
            Assert.That(jp.GetNullableValue<ushort>("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out ushort ushortValue0), Is.True);
            Assert.That(ushortValue0, Is.EqualTo((ushort)32000));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out ushort ushortValue1), Is.True);
            Assert.That(ushortValue1, Is.EqualTo((ushort)16000));

            Assert.That(jp.TryGetNullableValue("$.array[0]"u8, out ushort? nullableUshortValue0), Is.True);
            Assert.That(nullableUshortValue0, Is.EqualTo((ushort)32000));
            Assert.That(jp.TryGetNullableValue("$.array[1]"u8, out ushort? nullableUshortValue1), Is.True);
            Assert.That(nullableUshortValue1, Is.EqualTo((ushort)16000));
            Assert.That(jp.TryGetNullableValue("$.array[2]"u8, out ushort? nullableUshortValue2), Is.True);
            Assert.That(nullableUshortValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[32000,16000,null]}"));
        }

        [Test]
        public void Append_String()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, "Hello");
            jp.Append("$.array"u8, "World");
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetString("$.array[0]"u8), Is.EqualTo("Hello"));
            Assert.That(jp.GetString("$.array[1]"u8), Is.EqualTo("World"));
            Assert.That(jp.GetString("$.array[2]"u8), Is.EqualTo(null));

            Assert.That(jp.TryGetValue("$.array[0]"u8, out string? stringValue0), Is.True);
            Assert.That(stringValue0, Is.EqualTo("Hello"));
            Assert.That(jp.TryGetValue("$.array[1]"u8, out string? stringValue1), Is.True);
            Assert.That(stringValue1, Is.EqualTo("World"));
            Assert.That(jp.TryGetValue("$.array[2]"u8, out string? stringValue2), Is.True);
            Assert.That(stringValue2, Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[\"Hello\",\"World\",null]}"));
        }

        [Test]
        public void Append_Mixed()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, "Hello");
            jp.Append("$.array"u8, 42);
            jp.Append("$.array"u8, true);
            jp.AppendNull("$.array"u8);

            Assert.That(jp.GetString("$.array[0]"u8), Is.EqualTo("Hello"));
            Assert.That(jp.GetInt32("$.array[1]"u8), Is.EqualTo(42));
            Assert.That(jp.GetNullableValue<int>("$.array[1]"u8), Is.EqualTo(42));
            Assert.That(jp.GetBoolean("$.array[2]"u8), Is.EqualTo(true));
            Assert.That(jp.GetNullableValue<bool>("$.array[2]"u8), Is.EqualTo(true));
            Assert.That(jp.GetString("$.array[3]"u8), Is.EqualTo(null));
            Assert.That(jp.GetNullableValue<int>("$.array[3]"u8), Is.EqualTo(null));
            Assert.That(jp.GetNullableValue<bool>("$.array[3]"u8), Is.EqualTo(null));

            var ex = Assert.Throws<FormatException>(() => jp.GetInt32("$.array[0]"u8));
            Assert.That(ex!.Message, Is.EqualTo("Value at '$.array[0]' is not a System.Int32."));
            ex = Assert.Throws<FormatException>(() => jp.GetBoolean("$.array[1]"u8));
            Assert.That(ex!.Message, Is.EqualTo("Value at '$.array[1]' is not a System.Boolean."));

            // string always works
            Assert.That(jp.GetString("$.array[0]"u8), Is.EqualTo("Hello"));
            Assert.That(jp.GetString("$.array[1]"u8), Is.EqualTo("42"));
            Assert.That(jp.GetString("$.array[2]"u8), Is.EqualTo("true"));
            Assert.That(jp.GetString("$.array[3]"u8), Is.EqualTo(null));

            Assert.That(jp.ToString("J"), Is.EqualTo("{\"array\":[\"Hello\",42,true,null]}"));
        }
    }
}
