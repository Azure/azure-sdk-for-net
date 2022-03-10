// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Azure
{
    public class StoringEnum
    {
        [Test]
        public void BasicFunctionality()
        {
            InitType();
            DayOfWeek day = DayOfWeek.Monday;

            MemoryWatch watch = MemoryWatch.Create;
            Value value = Value.Create(day);
            DayOfWeek outDay = value.As<DayOfWeek>();
            watch.Validate();

            Assert.AreEqual(day, outDay);
            Assert.AreEqual(typeof(DayOfWeek), value.Type);
        }

        [Test]
        public void NullableEnum()
        {
            DayOfWeek? day = DayOfWeek.Monday;

            Value value = Value.Create(day);
            DayOfWeek outDay = value.As<DayOfWeek>();

            Assert.AreEqual(day.Value, outDay);
            Assert.AreEqual(typeof(DayOfWeek), value.Type);
        }

        [Test]
        public void ToFromNullableEnum()
        {
            DayOfWeek day = DayOfWeek.Monday;
            Value value = Value.Create(day);
            Assert.True(value.TryGetValue(out DayOfWeek? nullDay));
            Assert.AreEqual(day, nullDay);

            value = Value.Create((DayOfWeek?)day);
            Assert.True(value.TryGetValue(out DayOfWeek outDay));
            Assert.AreEqual(day, outDay);
        }

        [Test]
        public void BoxedEnum()
        {
            DayOfWeek day = DayOfWeek.Monday;
            Value value = new(day);
            Assert.True(value.TryGetValue(out DayOfWeek? nullDay));
            Assert.AreEqual(day, nullDay);

            value = new((DayOfWeek?)day);
            Assert.True(value.TryGetValue(out DayOfWeek outDay));
            Assert.AreEqual(day, outDay);
        }

        [TestCase(ByteEnum.MinValue)]
        [TestCase(ByteEnum.MaxValue)]
        public void ByteSize(ByteEnum @enum)
        {
            Value value = Value.Create(@enum);
            Assert.True(value.TryGetValue(out ByteEnum result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out ByteEnum? nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
            value = Value.Create((ByteEnum?)@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);

            // Create boxed
            value = new(@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
            value = new((ByteEnum?)@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
        }

        [TestCase(ShortEnum.MinValue)]
        [TestCase(ShortEnum.MaxValue)]
        public void ShortSize(ShortEnum @enum)
        {
            Value value = Value.Create(@enum);
            Assert.True(value.TryGetValue(out ShortEnum result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out ShortEnum? nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
            value = Value.Create((ShortEnum?)@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);

            // Create boxed
            value = new(@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
            value = new((ShortEnum?)@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
        }

        [TestCase(LongEnum.MinValue)]
        [TestCase(LongEnum.MaxValue)]
        public void LongSize(LongEnum @enum)
        {
            Value value = Value.Create(@enum);
            Assert.True(value.TryGetValue(out LongEnum result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out LongEnum? nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
            value = Value.Create((LongEnum?)@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);

            // Create boxed
            value = new(@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
            value = new((LongEnum?)@enum);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@enum, result);
            Assert.True(value.TryGetValue(out nullResult));
            Assert.AreEqual(@enum, nullResult!.Value);
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        internal DayOfWeek InitType()
        {
            DayOfWeek day = DayOfWeek.Monday;
            return Value.Create(day).As<DayOfWeek>();
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
