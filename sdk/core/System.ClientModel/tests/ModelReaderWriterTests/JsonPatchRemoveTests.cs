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

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetBoolean("$.x"u8), Is.EqualTo(true));
            Assert.That(jp.GetBoolean("$.y"u8), Is.EqualTo(false));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Boolean_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":true,\"y\":false}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetBoolean("$.x"u8), Is.EqualTo(true));
            Assert.That(jp.GetBoolean("$.y"u8), Is.EqualTo(false));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetBoolean("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<bool>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Byte_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, (byte)1);
            jp.Set("$.y"u8, (byte)2);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetByte("$.x"u8), Is.EqualTo((byte)1));
            Assert.That(jp.GetByte("$.y"u8), Is.EqualTo((byte)2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Byte_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1,\"y\":2}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetByte("$.x"u8), Is.EqualTo((byte)1));
            Assert.That(jp.GetByte("$.y"u8), Is.EqualTo((byte)2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetByte("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<byte>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Decimal_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1.23m);
            jp.Set("$.y"u8, 4.56m);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetDecimal("$.x"u8), Is.EqualTo(1.23m));
            Assert.That(jp.GetDecimal("$.y"u8), Is.EqualTo(4.56m));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Decimal_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1.23,\"y\":4.56}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetDecimal("$.x"u8), Is.EqualTo(1.23m));
            Assert.That(jp.GetDecimal("$.y"u8), Is.EqualTo(4.56m));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDecimal("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<decimal>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Double_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1.23);
            jp.Set("$.y"u8, 4.56);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetDouble("$.x"u8), Is.EqualTo(1.23));
            Assert.That(jp.GetDouble("$.y"u8), Is.EqualTo(4.56));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Double_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1.23,\"y\":4.56}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetDouble("$.x"u8), Is.EqualTo(1.23));
            Assert.That(jp.GetDouble("$.y"u8), Is.EqualTo(4.56));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDouble("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<double>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Float_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1.23f);
            jp.Set("$.y"u8, 4.56f);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetFloat("$.x"u8), Is.EqualTo(1.23f));
            Assert.That(jp.GetFloat("$.y"u8), Is.EqualTo(4.56f));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Float_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1.23,\"y\":4.56}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetFloat("$.x"u8), Is.EqualTo(1.23f));
            Assert.That(jp.GetFloat("$.y"u8), Is.EqualTo(4.56f));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetFloat("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<float>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Int32_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1);
            jp.Set("$.y"u8, 2);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetInt32("$.x"u8), Is.EqualTo(1));
            Assert.That(jp.GetInt32("$.y"u8), Is.EqualTo(2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Int32_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1,\"y\":2}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetInt32("$.x"u8), Is.EqualTo(1));
            Assert.That(jp.GetInt32("$.y"u8), Is.EqualTo(2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt32("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<int>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Int64_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 1234567890123L);
            jp.Set("$.y"u8, 9876543210123L);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetInt64("$.x"u8), Is.EqualTo(1234567890123L));
            Assert.That(jp.GetInt64("$.y"u8), Is.EqualTo(9876543210123L));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Int64_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":1234567890123,\"y\":9876543210123}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetInt64("$.x"u8), Is.EqualTo(1234567890123L));
            Assert.That(jp.GetInt64("$.y"u8), Is.EqualTo(9876543210123L));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt64("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<long>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Int8_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, (sbyte)7);
            jp.Set("$.y"u8, (sbyte)-3);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetInt8("$.x"u8), Is.EqualTo((sbyte)7));
            Assert.That(jp.GetInt8("$.y"u8), Is.EqualTo((sbyte)-3));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Int8_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":7,\"y\":-3}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetInt8("$.x"u8), Is.EqualTo((sbyte)7));
            Assert.That(jp.GetInt8("$.y"u8), Is.EqualTo((sbyte)-3));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt8("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<sbyte>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Int16_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, (short)32000);
            jp.Set("$.y"u8, (short)-123);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetInt16("$.x"u8), Is.EqualTo((short)32000));
            Assert.That(jp.GetInt16("$.y"u8), Is.EqualTo((short)-123));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Int16_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":32000,\"y\":-123}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetInt16("$.x"u8), Is.EqualTo((short)32000));
            Assert.That(jp.GetInt16("$.y"u8), Is.EqualTo((short)-123));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetInt16("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<short>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void UInt32_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 10u);
            jp.Set("$.y"u8, 20u);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetUInt32("$.x"u8), Is.EqualTo(10u));
            Assert.That(jp.GetUInt32("$.y"u8), Is.EqualTo(20u));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void UInt32_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":10,\"y\":20}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetUInt32("$.x"u8), Is.EqualTo(10u));
            Assert.That(jp.GetUInt32("$.y"u8), Is.EqualTo(20u));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt32("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<uint>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void UInt64_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, 10000000000UL);
            jp.Set("$.y"u8, 20000000000UL);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetUInt64("$.x"u8), Is.EqualTo(10000000000UL));
            Assert.That(jp.GetUInt64("$.y"u8), Is.EqualTo(20000000000UL));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void UInt64_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":10000000000,\"y\":20000000000}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetUInt64("$.x"u8), Is.EqualTo(10000000000UL));
            Assert.That(jp.GetUInt64("$.y"u8), Is.EqualTo(20000000000UL));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt64("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ulong>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void UInt16_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, (ushort)60000);
            jp.Set("$.y"u8, (ushort)1234);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetUInt16("$.x"u8), Is.EqualTo((ushort)60000));
            Assert.That(jp.GetUInt16("$.y"u8), Is.EqualTo((ushort)1234));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void UInt16_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":60000,\"y\":1234}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetUInt16("$.x"u8), Is.EqualTo((ushort)60000));
            Assert.That(jp.GetUInt16("$.y"u8), Is.EqualTo((ushort)1234));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetUInt16("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<ushort>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void String_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, "foo");
            jp.Set("$.y"u8, "bar");

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetString("$.x"u8), Is.EqualTo("foo"));
            Assert.That(jp.GetString("$.y"u8), Is.EqualTo("bar"));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void String_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":\"foo\",\"y\":\"bar\"}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetString("$.x"u8), Is.EqualTo("foo"));
            Assert.That(jp.GetString("$.y"u8), Is.EqualTo("bar"));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetString("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Json_Empty()
        {
            JsonPatch jp = new();
            jp.Set("$.x"u8, "{\"a\":1}"u8.ToArray());
            jp.Set("$.y"u8, "{\"b\":2}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"a\":1}"));
            Assert.That(jp.GetJson("$.y"u8).ToString(), Is.EqualTo("{\"b\":2}"));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetJson("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetJson("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Json_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":{\"a\":1},\"y\":{\"b\":2}}"u8.ToArray());

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetJson("$.x"u8).ToString(), Is.EqualTo("{\"a\":1}"));
            Assert.That(jp.GetJson("$.y"u8).ToString(), Is.EqualTo("{\"b\":2}"));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetJson("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetJson("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void DateTime_Empty()
        {
            JsonPatch jp = new();
            var dt1 = new DateTime(2024, 1, 2, 3, 4, 5, DateTimeKind.Utc);
            var dt2 = new DateTime(2025, 2, 3, 4, 5, 6, DateTimeKind.Utc);

            jp.Set("$.x"u8, dt1);
            jp.Set("$.y"u8, dt2);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetDateTime("$.x"u8), Is.EqualTo(dt1));
            Assert.That(jp.GetDateTime("$.y"u8), Is.EqualTo(dt2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void DateTime_NonEmpty()
        {
            // Use numeric placeholders to make initial JSON valid.
            JsonPatch jp = new("{\"x\":\"12/25/2025 06:07:08\",\"y\":\"12/26/2025 06:07:08\"}"u8.ToArray());
            var dt1 = new DateTime(2025, 12, 25, 6, 7, 8);
            var dt2 = new DateTime(2025, 12, 26, 6, 7, 8);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetDateTime("$.x"u8), Is.EqualTo(dt1));
            Assert.That(jp.GetDateTime("$.y"u8), Is.EqualTo(dt2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTime("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTime>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void DateTimeOffset_Empty()
        {
            JsonPatch jp = new();
            var dto1 = new DateTimeOffset(2024, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var dto2 = new DateTimeOffset(2025, 2, 3, 4, 5, 6, TimeSpan.Zero);

            jp.Set("$.x"u8, dto1);
            jp.Set("$.y"u8, dto2);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetDateTimeOffset("$.x"u8), Is.EqualTo(dto1));
            Assert.That(jp.GetDateTimeOffset("$.y"u8), Is.EqualTo(dto2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void DateTimeOffset_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":\"12/25/2025 06:07:08 +02:00\",\"y\":\"12/26/2025 06:07:08 +02:00\"}"u8.ToArray());
            var dto1 = new DateTimeOffset(2025, 12, 25, 6, 7, 8, TimeSpan.FromHours(2));
            var dto2 = new DateTimeOffset(2025, 12, 26, 6, 7, 8, TimeSpan.FromHours(2));

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetDateTimeOffset("$.x"u8), Is.EqualTo(dto1));
            Assert.That(jp.GetDateTimeOffset("$.y"u8), Is.EqualTo(dto2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetDateTimeOffset("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<DateTimeOffset>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Guid_Empty()
        {
            JsonPatch jp = new();
            var g1 = new Guid("00000000-0000-0000-0000-000000000001");
            var g2 = new Guid("00000000-0000-0000-0000-000000000002");

            jp.Set("$.x"u8, g1);
            jp.Set("$.y"u8, g2);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetGuid("$.x"u8), Is.EqualTo(g1));
            Assert.That(jp.GetGuid("$.y"u8), Is.EqualTo(g2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void Guid_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":\"00000000-0000-0000-0000-000000000001\",\"y\":\"00000000-0000-0000-0000-000000000002\"}"u8.ToArray());
            var g1 = new Guid("00000000-0000-0000-0000-000000000001");
            var g2 = new Guid("00000000-0000-0000-0000-000000000002");

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetGuid("$.x"u8), Is.EqualTo(g1));
            Assert.That(jp.GetGuid("$.y"u8), Is.EqualTo(g2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetGuid("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<Guid>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void TimeSpan_Empty()
        {
            JsonPatch jp = new();
            var t1 = TimeSpan.FromHours(1);
            var t2 = TimeSpan.FromMinutes(90);

            jp.Set("$.x"u8, t1);
            jp.Set("$.y"u8, t2);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetTimeSpan("$.x"u8), Is.EqualTo(t1));
            Assert.That(jp.GetTimeSpan("$.y"u8), Is.EqualTo(t2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void TimeSpan_NonEmpty()
        {
            JsonPatch jp = new("{\"x\":\"1.01:01:01.0010000\",\"y\":\"2.01:01:01.0010000\"}"u8.ToArray());
            var t1 = new TimeSpan(1, 1, 1, 1, 1);
            var t2 = new TimeSpan(2, 1, 1, 1, 1);

            Assert.That(jp.IsRemoved("$.x"u8), Is.False);
            Assert.That(jp.IsRemoved("$.y"u8), Is.False);

            Assert.That(jp.GetTimeSpan("$.x"u8), Is.EqualTo(t1));
            Assert.That(jp.GetTimeSpan("$.y"u8), Is.EqualTo(t2));

            jp.Remove("$.x"u8);
            jp.Remove("$.y"u8);

            Assert.That(jp.Contains("$.x"u8), Is.True);
            Assert.That(jp.Contains("$.y"u8), Is.True);
            Assert.That(jp.IsRemoved("$.x"u8), Is.True);
            Assert.That(jp.IsRemoved("$.y"u8), Is.True);

            var ex = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetTimeSpan("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.x"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.x'."));
            ex = Assert.Throws<KeyNotFoundException>(() => jp.GetNullableValue<TimeSpan>("$.y"u8));
            Assert.That(ex!.Message, Is.EqualTo($"No value found at JSON path '$.y'."));

            Assert.That(jp.ToString("J"), Is.EqualTo("{}"));
        }

        [Test]
        public void RemoveFromMixedArray_Seed()
        {
            JsonPatch jp = new("[1, \"two\", {\"three\":3}, [4]]"u8.ToArray());

            jp.Remove("$[1]"u8);

            Assert.That(jp.Contains("$[1]"u8), Is.True);

            Assert.That(jp.IsRemoved("$[1]"u8), Is.True);

            Assert.That(jp.ToString("J"), Is.EqualTo("[1, {\"three\":3}, [4]]"));
        }

        [Test]
        public void RemoveFromMixedArray_New()
        {
            JsonPatch jp = new();

            jp.Set("$"u8, "[1, \"two\", {\"three\":3}, [4]]"u8);

            jp.Remove("$[1]"u8);

            Assert.That(jp.ToString("J"), Is.EqualTo("[1, {\"three\":3}, [4]]"));
        }

        [Test]
        public void RemoveThenSetFromMixedArray_New()
        {
            JsonPatch jp = new();

            jp.Set("$"u8, "[1,\"two\",{\"three\":3},[4]]"u8);

            jp.Remove("$[1]"u8);
            jp.Set("$[1]"u8, "new");

            Assert.That(jp.ToString("J"), Is.EqualTo("[1,\"new\",[4]]"));
        }

        [Test]
        public void RemoveFromMixedArray_Append()
        {
            JsonPatch jp = new();

            jp.Append("$"u8, 1);
            jp.Append("$"u8, "two");
            jp.Append("$"u8, "{\"three\":3}"u8);
            jp.Append("$"u8, "[4]"u8);

            jp.Remove("$[1]"u8);

            Assert.That(jp.ToString("J"), Is.EqualTo("[1,{\"three\":3},[4]]"));
        }

        [Test]
        public void RemoveFromMultiDimensionalMixedArray()
        {
            JsonPatch jp = new("[[1,\"two\"],[{\"three\":3},[4]]]"u8.ToArray());

            jp.Remove("$[0][1]"u8);
            jp.Remove("$[1][0]"u8);

            Assert.That(jp.IsRemoved("$[0][1]"u8), Is.True);
            Assert.That(jp.IsRemoved("$[1][0]"u8), Is.True);

            Assert.That(jp.ToString("J"), Is.EqualTo("[[1],[[4]]]"));
        }
    }
}
