// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class JsonPatchRemoveTests
    {
        [Test]
        public void Boolean_Empty()
        {
            JsonPatch jp = new();

            jp.Set("$.x"u8, true);
            jp.Set("$.y"u8, false);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(true, jp.GetBoolean("$.x"u8));
            Assert.AreEqual(false, jp.GetBoolean("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Boolean_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":true,\"y\":false}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(true, jp.GetBoolean("$.x"u8));
            Assert.AreEqual(false, jp.GetBoolean("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Byte_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, (byte)1);
            jp.Set("$.y"u8, (byte)2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual((byte)1, jp.GetByte("$.x"u8));
            Assert.AreEqual((byte)2, jp.GetByte("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Byte_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1,\"y\":2}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual((byte)1, jp.GetByte("$.x"u8));
            Assert.AreEqual((byte)2, jp.GetByte("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Decimal_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1.23m);
            jp.Set("$.y"u8, 4.56m);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1.23m, jp.GetDecimal("$.x"u8));
            Assert.AreEqual(4.56m, jp.GetDecimal("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Decimal_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1.23,\"y\":4.56}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1.23m, jp.GetDecimal("$.x"u8));
            Assert.AreEqual(4.56m, jp.GetDecimal("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Double_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1.23);
            jp.Set("$.y"u8, 4.56);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1.23, jp.GetDouble("$.x"u8));
            Assert.AreEqual(4.56, jp.GetDouble("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Double_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1.23,\"y\":4.56}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1.23, jp.GetDouble("$.x"u8));
            Assert.AreEqual(4.56, jp.GetDouble("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Float_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1.23f);
            jp.Set("$.y"u8, 4.56f);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1.23f, jp.GetFloat("$.x"u8));
            Assert.AreEqual(4.56f, jp.GetFloat("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Float_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1.23,\"y\":4.56}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1.23f, jp.GetFloat("$.x"u8));
            Assert.AreEqual(4.56f, jp.GetFloat("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Int32_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1);
            jp.Set("$.y"u8, 2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1, jp.GetInt32("$.x"u8));
            Assert.AreEqual(2, jp.GetInt32("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Int32_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1,\"y\":2}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1, jp.GetInt32("$.x"u8));
            Assert.AreEqual(2, jp.GetInt32("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Int64_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1234567890123L);
            jp.Set("$.y"u8, 9876543210123L);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1234567890123L, jp.GetInt64("$.x"u8));
            Assert.AreEqual(9876543210123L, jp.GetInt64("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Int64_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1234567890123,\"y\":9876543210123}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(1234567890123L, jp.GetInt64("$.x"u8));
            Assert.AreEqual(9876543210123L, jp.GetInt64("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Int8_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, (sbyte)7);
            jp.Set("$.y"u8, (sbyte)-3);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual((sbyte)7, jp.GetInt8("$.x"u8));
            Assert.AreEqual((sbyte)-3, jp.GetInt8("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Int8_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":7,\"y\":-3}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual((sbyte)7, jp.GetInt8("$.x"u8));
            Assert.AreEqual((sbyte)-3, jp.GetInt8("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Int16_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, (short)32000);
            jp.Set("$.y"u8, (short)-123);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual((short)32000, jp.GetInt16("$.x"u8));
            Assert.AreEqual((short)-123, jp.GetInt16("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Int16_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":32000,\"y\":-123}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual((short)32000, jp.GetInt16("$.x"u8));
            Assert.AreEqual((short)-123, jp.GetInt16("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void UInt32_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 10u);
            jp.Set("$.y"u8, 20u);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(10u, jp.GetUInt32("$.x"u8));
            Assert.AreEqual(20u, jp.GetUInt32("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void UInt32_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":10,\"y\":20}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(10u, jp.GetUInt32("$.x"u8));
            Assert.AreEqual(20u, jp.GetUInt32("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void UInt64_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 10000000000UL);
            jp.Set("$.y"u8, 20000000000UL);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(10000000000UL, jp.GetUInt64("$.x"u8));
            Assert.AreEqual(20000000000UL, jp.GetUInt64("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void UInt64_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":10000000000,\"y\":20000000000}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(10000000000UL, jp.GetUInt64("$.x"u8));
            Assert.AreEqual(20000000000UL, jp.GetUInt64("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void UInt16_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, (ushort)60000);
            jp.Set("$.y"u8, (ushort)1234);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual((ushort)60000, jp.GetUInt16("$.x"u8));
            Assert.AreEqual((ushort)1234, jp.GetUInt16("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void UInt16_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":60000,\"y\":1234}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual((ushort)60000, jp.GetUInt16("$.x"u8));
            Assert.AreEqual((ushort)1234, jp.GetUInt16("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void String_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, "foo");
            jp.Set("$.y"u8, "bar");

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual("foo", jp.GetString("$.x"u8));
            Assert.AreEqual("bar", jp.GetString("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void String_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":\"foo\",\"y\":\"bar\"}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual("foo", jp.GetString("$.x"u8));
            Assert.AreEqual("bar", jp.GetString("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Json_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, "{\"a\":1}"u8.ToArray());
            jp.Set("$.y"u8, "{\"b\":2}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual("{\"a\":1}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"b\":2}", jp.GetJson("$.y"u8).ToString());

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetJson("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetJson("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Json_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":{\"a\":1},\"y\":{\"b\":2}}"u8.ToArray());

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual("{\"a\":1}", jp.GetJson("$.x"u8).ToString());
            Assert.AreEqual("{\"b\":2}", jp.GetJson("$.y"u8).ToString());

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetJson("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetJson("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void DateTime_Empty()
        {
            JsonPatch jp = new();
            var dt1 = new DateTime(2024,1,2,3,4,5, DateTimeKind.Utc);
            var dt2 = new DateTime(2025,2,3,4,5,6, DateTimeKind.Utc);

            jp.Set("$.x"u8, dt1);
            jp.Set("$.y"u8, dt2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(dt1, jp.GetDateTime("$.x"u8));
            Assert.AreEqual(dt2, jp.GetDateTime("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void DateTime_NonEmpty()
        {
            // Use numeric placeholders to make initial JSON valid.
            JsonPatch jp = new("{\"x\":0,\"y\":0}"u8.ToArray());
            var dt1 = new DateTime(2024,1,2,3,4,5, DateTimeKind.Utc);
            var dt2 = new DateTime(2025,2,3,4,5,6, DateTimeKind.Utc);

            jp.Set("$.x"u8, dt1);
            jp.Set("$.y"u8, dt2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(dt1, jp.GetDateTime("$.x"u8));
            Assert.AreEqual(dt2, jp.GetDateTime("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void DateTimeOffset_Empty()
        {
            JsonPatch jp = new();
            var dto1 = new DateTimeOffset(2024,1,2,3,4,5, TimeSpan.Zero);
            var dto2 = new DateTimeOffset(2025,2,3,4,5,6, TimeSpan.Zero);

            jp.Set("$.x"u8, dto1);
            jp.Set("$.y"u8, dto2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(dto1, jp.GetDateTimeOffset("$.x"u8));
            Assert.AreEqual(dto2, jp.GetDateTimeOffset("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void DateTimeOffset_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":0,\"y\":0}"u8.ToArray());
            var dto1 = new DateTimeOffset(2024,1,2,3,4,5, TimeSpan.Zero);
            var dto2 = new DateTimeOffset(2025,2,3,4,5,6, TimeSpan.Zero);

            jp.Set("$.x"u8, dto1);
            jp.Set("$.y"u8, dto2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(dto1, jp.GetDateTimeOffset("$.x"u8));
            Assert.AreEqual(dto2, jp.GetDateTimeOffset("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Guid_Empty()
        {
            JsonPatch jp = new();
            var g1 = new Guid("00000000-0000-0000-0000-000000000001");
            var g2 = new Guid("00000000-0000-0000-0000-000000000002");

            jp.Set("$.x"u8, g1);
            jp.Set("$.y"u8, g2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(g1, jp.GetGuid("$.x"u8));
            Assert.AreEqual(g2, jp.GetGuid("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void Guid_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":0,\"y\":0}"u8.ToArray());
            var g1 = new Guid("00000000-0000-0000-0000-000000000001");
            var g2 = new Guid("00000000-0000-0000-0000-000000000002");

            jp.Set("$.x"u8, g1);
            jp.Set("$.y"u8, g2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(g1, jp.GetGuid("$.x"u8));
            Assert.AreEqual(g2, jp.GetGuid("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void TimeSpan_Empty()
        {
            JsonPatch jp = new();
            var t1 = TimeSpan.FromHours(1);
            var t2 = TimeSpan.FromMinutes(90);

            jp.Set("$.x"u8, t1);
            jp.Set("$.y"u8, t2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(t1, jp.GetTimeSpan("$.x"u8));
            Assert.AreEqual(t2, jp.GetTimeSpan("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }

        [Test]
        public void TimeSpan_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":0,\"y\":0}"u8.ToArray());
            var t1 = TimeSpan.FromHours(1);
            var t2 = TimeSpan.FromMinutes(90);

            jp.Set("$.x"u8, t1);
            jp.Set("$.y"u8, t2);

            Assert.IsFalse(jp.IsRemoved("$.x"u8));
            Assert.IsFalse(jp.IsRemoved("$.y"u8));

            Assert.AreEqual(t1, jp.GetTimeSpan("$.x"u8));
            Assert.AreEqual(t2, jp.GetTimeSpan("$.y"u8));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.IsTrue(jp.Contains("$.x"u8));
            Assert.IsTrue(jp.Contains("$.y"u8));
            Assert.IsTrue(jp.IsRemoved("$.x"u8));
            Assert.IsTrue(jp.IsRemoved("$.y"u8));

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.x"u8));
            Assert.AreEqual($"No value found at JSON path '$.x'.", ex!.Message);
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.y"u8));
            Assert.AreEqual($"No value found at JSON path '$.y'.", ex!.Message);

            Assert.AreEqual("{}", jp.ToString("J"));
        }
    }
}
