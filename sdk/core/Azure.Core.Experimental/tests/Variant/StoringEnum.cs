// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringEnum
    {
        [Test]
        public void BasicFunctionality()
        {
            InitType();
            DayOfWeek day = DayOfWeek.Monday;

            Variant value;
            DayOfWeek outDay;
            using (MemoryWatch watch = MemoryWatch.Create())
            {
                value = Variant.Create(day);
                outDay = value.As<DayOfWeek>();
            }

            Assert.AreEqual(day, outDay);
            Assert.AreEqual(typeof(DayOfWeek), value.Type);
        }

        [Test]
        public void NullableEnum()
        {
            DayOfWeek? day = DayOfWeek.Monday;

            Variant value = Variant.Create(day);
            DayOfWeek outDay = value.As<DayOfWeek>();

            Assert.AreEqual(day.Value, outDay);
            Assert.AreEqual(typeof(DayOfWeek), value.Type);
        }

        [Test]
        public void ToFromNullableEnum()
        {
            DayOfWeek day = DayOfWeek.Monday;
            Variant value = Variant.Create(day);
            Assert.True(value.TryGetValue(out DayOfWeek? nullDay));
            Assert.AreEqual(day, nullDay);

            value = Variant.Create((DayOfWeek?)day);
            Assert.True(value.TryGetValue(out DayOfWeek outDay));
            Assert.AreEqual(day, outDay);
        }

        [Test]
        public void BoxedEnum()
        {
            DayOfWeek day = DayOfWeek.Monday;
            Variant value = new(day);
            Assert.True(value.TryGetValue(out DayOfWeek? nullDay));
            Assert.AreEqual(day, nullDay);

            value = new((DayOfWeek?)day);
            Assert.True(value.TryGetValue(out DayOfWeek outDay));
            Assert.AreEqual(day, outDay);
        }

        [TestCase(ByteEnum.MinValue)]
        [TestCase(ByteEnum.MaxValue)]
        public void ByteSize(ByteEnum testValue)
        {
            Variant value = Variant.Create(testValue);
            Assert.True(value.TryGetValue(out ByteEnum result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out ByteEnum? nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
            value = Variant.Create((ByteEnum?)testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);

            // Create boxed
            value = new(testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
            value = new((ByteEnum?)testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
        }

        [TestCase(ShortEnum.MinValue)]
        [TestCase(ShortEnum.MaxValue)]
        public void ShortSize(ShortEnum testValue)
        {
            Variant value = Variant.Create(testValue);
            Assert.True(value.TryGetValue(out ShortEnum result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out ShortEnum? nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
            value = Variant.Create((ShortEnum?)testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);

            // Create boxed
            value = new(testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
            value = new((ShortEnum?)testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
        }

        [TestCase(LongEnum.MinValue)]
        [TestCase(LongEnum.MaxValue)]
        public void LongSize(LongEnum testValue)
        {
            Variant value = Variant.Create(testValue);
            Assert.True(value.TryGetValue(out LongEnum result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out LongEnum? nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
            value = Variant.Create((LongEnum?)testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);

            // Create boxed
            value = new(testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
            value = new((LongEnum?)testValue);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(testValue, nullResult!.Value);
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        internal DayOfWeek InitType()
        {
            DayOfWeek day = DayOfWeek.Monday;
            return Variant.Create(day).As<DayOfWeek>();
        }

        public enum ByteEnum : byte
        {
            MinValue = byte.MinValue,
            MaxValue = byte.MaxValue
        }

        public enum ShortEnum : short
        {
            MinValue = short.MinValue,
            MaxValue = short.MaxValue
        }

        public enum LongEnum : long
        {
            MinValue = long.MinValue,
            MaxValue = long.MaxValue
        }
    }
}
