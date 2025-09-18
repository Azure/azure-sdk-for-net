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

            Assert.AreEqual(true, jp.GetBoolean("$.array[0]"u8));
            Assert.AreEqual(false, jp.GetBoolean("$.array[1]"u8));

            Assert.AreEqual(true, jp.GetNullableValue<bool>("$.array[0]"u8));
            Assert.AreEqual(false, jp.GetNullableValue<bool>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<bool>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out bool boolValue0));
            Assert.AreEqual(true, boolValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out bool boolValue1));
            Assert.AreEqual(false, boolValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out bool? nullableBoolValue0));
            Assert.AreEqual(true, nullableBoolValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out bool? nullableBoolValue1));
            Assert.AreEqual(false, nullableBoolValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out bool? nullableBoolValue2));
            Assert.AreEqual(null, nullableBoolValue2);

            Assert.AreEqual("{\"array\":[true,false,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_Byte()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, (byte)42);
            jp.Append("$.array"u8, (byte)255);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(42, jp.GetByte("$.array[0]"u8));
            Assert.AreEqual(255, jp.GetByte("$.array[1]"u8));

            Assert.AreEqual(42, jp.GetNullableValue<byte>("$.array[0]"u8));
            Assert.AreEqual(255, jp.GetNullableValue<byte>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<byte>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out byte byteValue0));
            Assert.AreEqual(42, byteValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out byte byteValue1));
            Assert.AreEqual(255, byteValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out byte? nullableByteValue0));
            Assert.AreEqual(42, nullableByteValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out byte? nullableByteValue1));
            Assert.AreEqual(255, nullableByteValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out byte? nullableByteValue2));
            Assert.AreEqual(null, nullableByteValue2);

            Assert.AreEqual("{\"array\":[42,255,null]}", jp.ToString("J"));
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

            Assert.AreEqual(dt1, jp.GetDateTime("$.array[0]"u8));
            Assert.AreEqual(dt2, jp.GetDateTime("$.array[1]"u8));

            Assert.AreEqual(dt1, jp.GetNullableValue<DateTime>("$.array[0]"u8));
            Assert.AreEqual(dt2, jp.GetNullableValue<DateTime>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<DateTime>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out DateTime dateTimeValue0));
            Assert.AreEqual(dt1, dateTimeValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out DateTime dateTimeValue1));
            Assert.AreEqual(dt2, dateTimeValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out DateTime? nullableDateTimeValue0));
            Assert.AreEqual(dt1, nullableDateTimeValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out DateTime? nullableDateTimeValue1));
            Assert.AreEqual(dt2, nullableDateTimeValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out DateTime? nullableDateTimeValue2));
            Assert.AreEqual(null, nullableDateTimeValue2);

            Assert.AreEqual("{\"array\":[\"01/01/2024 12:00:00\",\"12/31/2024 23:59:59\",null]}", jp.ToString("J"));
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

            Assert.AreEqual(dto1, jp.GetDateTimeOffset("$.array[0]"u8));
            Assert.AreEqual(dto2, jp.GetDateTimeOffset("$.array[1]"u8));

            Assert.AreEqual(dto1, jp.GetNullableValue<DateTimeOffset>("$.array[0]"u8));
            Assert.AreEqual(dto2, jp.GetNullableValue<DateTimeOffset>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<DateTimeOffset>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out DateTimeOffset dateTimeOffsetValue0));
            Assert.AreEqual(dto1, dateTimeOffsetValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out DateTimeOffset dateTimeOffsetValue1));
            Assert.AreEqual(dto2, dateTimeOffsetValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out DateTimeOffset? nullableDateTimeOffsetValue0));
            Assert.AreEqual(dto1, nullableDateTimeOffsetValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out DateTimeOffset? nullableDateTimeOffsetValue1));
            Assert.AreEqual(dto2, nullableDateTimeOffsetValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out DateTimeOffset? nullableDateTimeOffsetValue2));
            Assert.AreEqual(null, nullableDateTimeOffsetValue2);

            Assert.AreEqual("{\"array\":[\"01/01/2024 12:00:00 +01:00\",\"12/31/2024 23:59:59 +02:00\",null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_Decimal()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 123.45m);
            jp.Append("$.array"u8, 67890.12m);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(123.45m, jp.GetDecimal("$.array[0]"u8));
            Assert.AreEqual(67890.12m, jp.GetDecimal("$.array[1]"u8));

            Assert.AreEqual(123.45m, jp.GetNullableValue<decimal>("$.array[0]"u8));
            Assert.AreEqual(67890.12m, jp.GetNullableValue<decimal>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<decimal>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out decimal decimalValue0));
            Assert.AreEqual(123.45m, decimalValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out decimal decimalValue1));
            Assert.AreEqual(67890.12m, decimalValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out decimal? nullableDecimalValue0));
            Assert.AreEqual(123.45m, nullableDecimalValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out decimal? nullableDecimalValue1));
            Assert.AreEqual(67890.12m, nullableDecimalValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out decimal? nullableDecimalValue2));
            Assert.AreEqual(null, nullableDecimalValue2);

            Assert.AreEqual("{\"array\":[123.45,67890.12,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_Double()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 123.45);
            jp.Append("$.array"u8, 67890.12);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(123.45, jp.GetDouble("$.array[0]"u8));
            Assert.AreEqual(67890.12, jp.GetDouble("$.array[1]"u8));

            Assert.AreEqual(123.45, jp.GetNullableValue<double>("$.array[0]"u8));
            Assert.AreEqual(67890.12, jp.GetNullableValue<double>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<double>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out double doubleValue0));
            Assert.AreEqual(123.45, doubleValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out double doubleValue1));
            Assert.AreEqual(67890.12, doubleValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out double? nullableDoubleValue0));
            Assert.AreEqual(123.45, nullableDoubleValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out double? nullableDoubleValue1));
            Assert.AreEqual(67890.12, nullableDoubleValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out double? nullableDoubleValue2));
            Assert.AreEqual(null, nullableDoubleValue2);

            Assert.AreEqual("{\"array\":[123.45,67890.12,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_Float()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 123.5f);
            jp.Append("$.array"u8, 67890.5f);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(123.5f, jp.GetFloat("$.array[0]"u8));
            Assert.AreEqual(67890.5f, jp.GetFloat("$.array[1]"u8));

            Assert.AreEqual(123.5f, jp.GetNullableValue<float>("$.array[0]"u8));
            Assert.AreEqual(67890.5f, jp.GetNullableValue<float>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<float>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out float floatValue0));
            Assert.AreEqual(123.5f, floatValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out float floatValue1));
            Assert.AreEqual(67890.5f, floatValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out float? nullableFloatValue0));
            Assert.AreEqual(123.5f, nullableFloatValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out float? nullableFloatValue1));
            Assert.AreEqual(67890.5f, nullableFloatValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out float? nullableFloatValue2));
            Assert.AreEqual(null, nullableFloatValue2);

            Assert.AreEqual("{\"array\":[123.5,67890.5,null]}", jp.ToString("J"));
        }

        public void Append_Guid()
        {
            JsonPatch jp = new();

            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();

            jp.Append("$.array"u8, guid1);
            jp.Append("$.array"u8, guid2);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(guid1, jp.GetGuid("$.array[0]"u8));
            Assert.AreEqual(guid2, jp.GetGuid("$.array[1]"u8));

            Assert.AreEqual(guid1, jp.GetNullableValue<Guid>("$.array[0]"u8));
            Assert.AreEqual(guid2, jp.GetNullableValue<Guid>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<Guid>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out Guid guidValue0));
            Assert.AreEqual(guid1, guidValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out Guid guidValue1));
            Assert.AreEqual(guid2, guidValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out Guid? nullableGuidValue0));
            Assert.AreEqual(guid1, nullableGuidValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out Guid? nullableGuidValue1));
            Assert.AreEqual(guid2, nullableGuidValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out Guid? nullableGuidValue2));
            Assert.AreEqual(null, nullableGuidValue2);

            Assert.AreEqual($"{{\"array\":[\"{guid1}\",\"{guid2}\",null]}}", jp.ToString("J"));
        }

        public void Append_Int32()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 42);
            jp.Append("$.array"u8, 255);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(42, jp.GetInt32("$.array[0]"u8));
            Assert.AreEqual(255, jp.GetInt32("$.array[1]"u8));

            Assert.AreEqual(42, jp.GetNullableValue<int>("$.array[0]"u8));
            Assert.AreEqual(255, jp.GetNullableValue<int>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<int>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out int intValue0));
            Assert.AreEqual(42, intValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out int intValue1));
            Assert.AreEqual(255, intValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out int? nullableIntValue0));
            Assert.AreEqual(42, nullableIntValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out int? nullableIntValue1));
            Assert.AreEqual(255, nullableIntValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out int? nullableIntValue2));
            Assert.AreEqual(null, nullableIntValue2);

            Assert.AreEqual("{\"array\":[42,255,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_Int64()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 42000000000L);
            jp.Append("$.array"u8, 25500000000L);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(42000000000L, jp.GetInt64("$.array[0]"u8));
            Assert.AreEqual(25500000000L, jp.GetInt64("$.array[1]"u8));

            Assert.AreEqual(42000000000L, jp.GetNullableValue<long>("$.array[0]"u8));
            Assert.AreEqual(25500000000L, jp.GetNullableValue<long>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<long>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out long longValue0));
            Assert.AreEqual(42000000000L, longValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out long longValue1));
            Assert.AreEqual(25500000000L, longValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out long? nullableLongValue0));
            Assert.AreEqual(42000000000L, nullableLongValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out long? nullableLongValue1));
            Assert.AreEqual(25500000000L, nullableLongValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out long? nullableLongValue2));
            Assert.AreEqual(null, nullableLongValue2);

            Assert.AreEqual("{\"array\":[42000000000,25500000000,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_Int8()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, (sbyte)42);
            jp.Append("$.array"u8, (sbyte)-100);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual((sbyte)42, jp.GetInt8("$.array[0]"u8));
            Assert.AreEqual((sbyte)-100, jp.GetInt8("$.array[1]"u8));

            Assert.AreEqual((sbyte)42, jp.GetNullableValue<sbyte>("$.array[0]"u8));
            Assert.AreEqual((sbyte)-100, jp.GetNullableValue<sbyte>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<sbyte>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out sbyte sbyteValue0));
            Assert.AreEqual((sbyte)42, sbyteValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out sbyte sbyteValue1));
            Assert.AreEqual((sbyte)-100, sbyteValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out sbyte? nullableSbyteValue0));
            Assert.AreEqual((sbyte)42, nullableSbyteValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out sbyte? nullableSbyteValue1));
            Assert.AreEqual((sbyte)-100, nullableSbyteValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out sbyte? nullableSbyteValue2));
            Assert.AreEqual(null, nullableSbyteValue2);

            Assert.AreEqual("{\"array\":[42,-100,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_Int16()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, (short)32000);
            jp.Append("$.array"u8, (short)-16000);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual((short)32000, jp.GetInt16("$.array[0]"u8));
            Assert.AreEqual((short)-16000, jp.GetInt16("$.array[1]"u8));

            Assert.AreEqual((short)32000, jp.GetNullableValue<short>("$.array[0]"u8));
            Assert.AreEqual((short)-16000, jp.GetNullableValue<short>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<short>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out short shortValue0));
            Assert.AreEqual((short)32000, shortValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out short shortValue1));
            Assert.AreEqual((short)-16000, shortValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out short? nullableShortValue0));
            Assert.AreEqual((short)32000, nullableShortValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out short? nullableShortValue1));
            Assert.AreEqual((short)-16000, nullableShortValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out short? nullableShortValue2));
            Assert.AreEqual(null, nullableShortValue2);

            Assert.AreEqual("{\"array\":[32000,-16000,null]}", jp.ToString("J"));
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

            Assert.AreEqual(ts1, jp.GetTimeSpan("$.array[0]"u8));
            Assert.AreEqual(ts2, jp.GetTimeSpan("$.array[1]"u8));

            Assert.AreEqual(ts1, jp.GetNullableValue<TimeSpan>("$.array[0]"u8));
            Assert.AreEqual(ts2, jp.GetNullableValue<TimeSpan>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<TimeSpan>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out TimeSpan timeSpanValue0));
            Assert.AreEqual(ts1, timeSpanValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out TimeSpan timeSpanValue1));
            Assert.AreEqual(ts2, timeSpanValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out TimeSpan? nullableTimeSpanValue0));
            Assert.AreEqual(ts1, nullableTimeSpanValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out TimeSpan? nullableTimeSpanValue1));
            Assert.AreEqual(ts2, nullableTimeSpanValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out TimeSpan? nullableTimeSpanValue2));
            Assert.AreEqual(null, nullableTimeSpanValue2);

            Assert.AreEqual("{\"array\":[\"01:30:00\",\"2.00:00:00\",null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_UInt32()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 42u);
            jp.Append("$.array"u8, 255u);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(42u, jp.GetUInt32("$.array[0]"u8));
            Assert.AreEqual(255u, jp.GetUInt32("$.array[1]"u8));

            Assert.AreEqual(42u, jp.GetNullableValue<uint>("$.array[0]"u8));
            Assert.AreEqual(255u, jp.GetNullableValue<uint>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<uint>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out uint uintValue0));
            Assert.AreEqual(42u, uintValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out uint uintValue1));
            Assert.AreEqual(255u, uintValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out uint? nullableUintValue0));
            Assert.AreEqual(42u, nullableUintValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out uint? nullableUintValue1));
            Assert.AreEqual(255u, nullableUintValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out uint? nullableUintValue2));
            Assert.AreEqual(null, nullableUintValue2);

            Assert.AreEqual("{\"array\":[42,255,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_UInt64()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, 42000000000UL);
            jp.Append("$.array"u8, 25500000000UL);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual(42000000000UL, jp.GetUInt64("$.array[0]"u8));
            Assert.AreEqual(25500000000UL, jp.GetUInt64("$.array[1]"u8));

            Assert.AreEqual(42000000000UL, jp.GetNullableValue<ulong>("$.array[0]"u8));
            Assert.AreEqual(25500000000UL, jp.GetNullableValue<ulong>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<ulong>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out ulong ulongValue0));
            Assert.AreEqual(42000000000UL, ulongValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out ulong ulongValue1));
            Assert.AreEqual(25500000000UL, ulongValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out ulong? nullableUlongValue0));
            Assert.AreEqual(42000000000UL, nullableUlongValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out ulong? nullableUlongValue1));
            Assert.AreEqual(25500000000UL, nullableUlongValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out ulong? nullableUlongValue2));
            Assert.AreEqual(null, nullableUlongValue2);

            Assert.AreEqual("{\"array\":[42000000000,25500000000,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_UInt16()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, (ushort)32000);
            jp.Append("$.array"u8, (ushort)16000);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual((ushort)32000, jp.GetUInt16("$.array[0]"u8));
            Assert.AreEqual((ushort)16000, jp.GetUInt16("$.array[1]"u8));

            Assert.AreEqual((ushort)32000, jp.GetNullableValue<ushort>("$.array[0]"u8));
            Assert.AreEqual((ushort)16000, jp.GetNullableValue<ushort>("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<ushort>("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out ushort ushortValue0));
            Assert.AreEqual((ushort)32000, ushortValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out ushort ushortValue1));
            Assert.AreEqual((ushort)16000, ushortValue1);

            Assert.IsTrue(jp.TryGetNullableValue("$.array[0]"u8, out ushort? nullableUshortValue0));
            Assert.AreEqual((ushort)32000, nullableUshortValue0);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[1]"u8, out ushort? nullableUshortValue1));
            Assert.AreEqual((ushort)16000, nullableUshortValue1);
            Assert.IsTrue(jp.TryGetNullableValue("$.array[2]"u8, out ushort? nullableUshortValue2));
            Assert.AreEqual(null, nullableUshortValue2);

            Assert.AreEqual("{\"array\":[32000,16000,null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_String()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, "Hello");
            jp.Append("$.array"u8, "World");
            jp.AppendNull("$.array"u8);

            Assert.AreEqual("Hello", jp.GetString("$.array[0]"u8));
            Assert.AreEqual("World", jp.GetString("$.array[1]"u8));
            Assert.AreEqual(null, jp.GetString("$.array[2]"u8));

            Assert.IsTrue(jp.TryGetValue("$.array[0]"u8, out string? stringValue0));
            Assert.AreEqual("Hello", stringValue0);
            Assert.IsTrue(jp.TryGetValue("$.array[1]"u8, out string? stringValue1));
            Assert.AreEqual("World", stringValue1);
            Assert.IsTrue(jp.TryGetValue("$.array[2]"u8, out string? stringValue2));
            Assert.AreEqual(null, stringValue2);

            Assert.AreEqual("{\"array\":[\"Hello\",\"World\",null]}", jp.ToString("J"));
        }

        [Test]
        public void Append_Mixed()
        {
            JsonPatch jp = new();

            jp.Append("$.array"u8, "Hello");
            jp.Append("$.array"u8, 42);
            jp.Append("$.array"u8, true);
            jp.AppendNull("$.array"u8);

            Assert.AreEqual("Hello", jp.GetString("$.array[0]"u8));
            Assert.AreEqual(42, jp.GetInt32("$.array[1]"u8));
            Assert.AreEqual(42, jp.GetNullableValue<int>("$.array[1]"u8));
            Assert.AreEqual(true, jp.GetBoolean("$.array[2]"u8));
            Assert.AreEqual(true, jp.GetNullableValue<bool>("$.array[2]"u8));
            Assert.AreEqual(null, jp.GetString("$.array[3]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<int>("$.array[3]"u8));
            Assert.AreEqual(null, jp.GetNullableValue<bool>("$.array[3]"u8));

            var ex = Assert.Throws<FormatException>(() => jp.GetInt32("$.array[0]"u8));
            Assert.AreEqual("Value at '$.array[0]' is not a System.Int32.", ex!.Message);
            ex = Assert.Throws<FormatException>(() => jp.GetBoolean("$.array[1]"u8));
            Assert.AreEqual("Value at '$.array[1]' is not a System.Boolean.", ex!.Message);

            // string always works
            Assert.AreEqual("Hello", jp.GetString("$.array[0]"u8));
            Assert.AreEqual("42", jp.GetString("$.array[1]"u8));
            Assert.AreEqual("true", jp.GetString("$.array[2]"u8));
            Assert.AreEqual(null, jp.GetString("$.array[3]"u8));

            Assert.AreEqual("{\"array\":[\"Hello\",42,true,null]}", jp.ToString("J"));
        }
    }
}
