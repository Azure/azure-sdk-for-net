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
            Assert.That(value.As<DateTimeOffset>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(DateTimeOffset)));

            DateTimeOffset? source = testValue;
            value = source;
            Assert.That(value.As<DateTimeOffset?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(DateTimeOffset)));
        }

        [Test]
        public void DateTimeOffsetInOut([ValueSource("DateTimeOffsetData")] DateTimeOffset testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out DateTimeOffset result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<DateTimeOffset>(), Is.EqualTo(testValue));
            Assert.That((DateTimeOffset)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableDateTimeOffsetInDateTimeOffsetOut([ValueSource("DateTimeOffsetData")] DateTimeOffset? testValue)
        {
            DateTimeOffset? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out DateTimeOffset result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<DateTimeOffset>(), Is.EqualTo(testValue));

            Assert.That((DateTimeOffset)value, Is.EqualTo(testValue));
        }

        [Test]
        public void DateTimeOffsetInNullableDateTimeOffsetOut([ValueSource("DateTimeOffsetData")] DateTimeOffset testValue)
        {
            DateTimeOffset source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out DateTimeOffset? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((DateTimeOffset?)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullDateTimeOffset()
        {
            DateTimeOffset? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<DateTimeOffset?>(), Is.EqualTo(source));
            Assert.That(value.As<DateTimeOffset?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("DateTimeOffsetData")] DateTimeOffset testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(DateTimeOffset)));
            Assert.That((DateTimeOffset)o, Is.EqualTo(testValue));

            DateTimeOffset? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(DateTimeOffset)));
            Assert.That((DateTimeOffset)o, Is.EqualTo(testValue));
        }
    }
}
