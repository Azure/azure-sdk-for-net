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

            Assert.That(outDay, Is.EqualTo(day));
            Assert.That(value.Type, Is.EqualTo(typeof(DayOfWeek)));
        }

        [Test]
        public void NullableEnum()
        {
            DayOfWeek? day = DayOfWeek.Monday;

            Variant value = Variant.Create(day);
            DayOfWeek outDay = value.As<DayOfWeek>();

            Assert.That(outDay, Is.EqualTo(day.Value));
            Assert.That(value.Type, Is.EqualTo(typeof(DayOfWeek)));
        }

        [Test]
        public void ToFromNullableEnum()
        {
            DayOfWeek day = DayOfWeek.Monday;
            Variant value = Variant.Create(day);
            Assert.That(value.TryGetValue(out DayOfWeek? nullDay), Is.True);
            Assert.That(nullDay, Is.EqualTo(day));

            value = Variant.Create((DayOfWeek?)day);
            Assert.That(value.TryGetValue(out DayOfWeek outDay), Is.True);
            Assert.That(outDay, Is.EqualTo(day));
        }

        [Test]
        public void BoxedEnum()
        {
            DayOfWeek day = DayOfWeek.Monday;
            Variant value = new(day);
            Assert.That(value.TryGetValue(out DayOfWeek? nullDay), Is.True);
            Assert.That(nullDay, Is.EqualTo(day));

            value = new((DayOfWeek?)day);
            Assert.That(value.TryGetValue(out DayOfWeek outDay), Is.True);
            Assert.That(outDay, Is.EqualTo(day));
        }

        [TestCase(ByteEnum.MinValue)]
        [TestCase(ByteEnum.MaxValue)]
        public void ByteSize(ByteEnum testValue)
        {
            Variant value = Variant.Create(testValue);
            Assert.That(value.TryGetValue(out ByteEnum result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out ByteEnum? nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
            value = Variant.Create((ByteEnum?)testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));

            // Create boxed
            value = new(testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
            value = new((ByteEnum?)testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
        }

        [TestCase(ShortEnum.MinValue)]
        [TestCase(ShortEnum.MaxValue)]
        public void ShortSize(ShortEnum testValue)
        {
            Variant value = Variant.Create(testValue);
            Assert.That(value.TryGetValue(out ShortEnum result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out ShortEnum? nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
            value = Variant.Create((ShortEnum?)testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));

            // Create boxed
            value = new(testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
            value = new((ShortEnum?)testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
        }

        [TestCase(LongEnum.MinValue)]
        [TestCase(LongEnum.MaxValue)]
        public void LongSize(LongEnum testValue)
        {
            Variant value = Variant.Create(testValue);
            Assert.That(value.TryGetValue(out LongEnum result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out LongEnum? nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
            value = Variant.Create((LongEnum?)testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));

            // Create boxed
            value = new(testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
            value = new((LongEnum?)testValue);
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullResult), Is.True);
            Assert.That(nullResult!.Value, Is.EqualTo(testValue));
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
