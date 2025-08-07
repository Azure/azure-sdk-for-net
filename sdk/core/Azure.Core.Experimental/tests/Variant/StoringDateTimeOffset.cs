// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringDateTimeOffset
    {
        public static DateTimeOffset[] DateTimeOffsetData => new[]
        {
            DateTimeOffset.Now,
            DateTimeOffset.UtcNow,
            DateTimeOffset.MaxValue,
            DateTimeOffset.MinValue
        };

        [Test]
        public void DateTimeOffsetImplicit([ValueSource("DateTimeOffsetData")] DateTimeOffset testValue)
        {
            Variant value = testValue;
            Assert.AreEqual(testValue, value.As<DateTimeOffset>());
            Assert.AreEqual(typeof(DateTimeOffset), value.Type);

            DateTimeOffset? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<DateTimeOffset?>());
            Assert.AreEqual(typeof(DateTimeOffset), value.Type);
        }

        [Test]
        public void DateTimeOffsetInOut([ValueSource("DateTimeOffsetData")] DateTimeOffset testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out DateTimeOffset result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<DateTimeOffset>());
            Assert.AreEqual(testValue, (DateTimeOffset)value);
        }

        [Test]
        public void NullableDateTimeOffsetInDateTimeOffsetOut([ValueSource("DateTimeOffsetData")] DateTimeOffset? testValue)
        {
            DateTimeOffset? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out DateTimeOffset result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<DateTimeOffset>());

            Assert.AreEqual(testValue, (DateTimeOffset)value);
        }

        [Test]
        public void DateTimeOffsetInNullableDateTimeOffsetOut([ValueSource("DateTimeOffsetData")] DateTimeOffset testValue)
        {
            DateTimeOffset source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out DateTimeOffset? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (DateTimeOffset?)value);
        }

        [Test]
        public void NullDateTimeOffset()
        {
            DateTimeOffset? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<DateTimeOffset?>());
            Assert.False(value.As<DateTimeOffset?>().HasValue);
        }

        [Test]
        public void OutAsObject([ValueSource("DateTimeOffsetData")] DateTimeOffset testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(DateTimeOffset), o.GetType());
            Assert.AreEqual(testValue, (DateTimeOffset)o);

            DateTimeOffset? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(DateTimeOffset), o.GetType());
            Assert.AreEqual(testValue, (DateTimeOffset)o);
        }
    }
}
