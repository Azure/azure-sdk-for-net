// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringDateTime
    {
        public static DateTime[] DateTimeData => new[]
        {
            DateTime.Now,
            DateTime.UtcNow,
            DateTime.MaxValue,
            DateTime.MinValue
        };

        [Test]
        public void DateTimeImplicit([ValueSource("DateTimeData")] DateTime testValue)
        {
            Variant value = testValue;
            Assert.That(value.As<DateTime>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(DateTime)));

            DateTime? source = testValue;
            value = source;
            Assert.That(value.As<DateTime?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(DateTime)));
        }

        [Test]
        public void DateTimeInOut([ValueSource("DateTimeData")] DateTime testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out DateTime result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<DateTime>(), Is.EqualTo(testValue));
            Assert.That((DateTime)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableDateTimeInDateTimeOut([ValueSource("DateTimeData")] DateTime? testValue)
        {
            DateTime? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out DateTime result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<DateTime>(), Is.EqualTo(testValue));

            Assert.That((DateTime)value, Is.EqualTo(testValue));
        }

        [Test]
        public void DateTimeInNullableDateTimeOut([ValueSource("DateTimeData")] DateTime testValue)
        {
            DateTime source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out DateTime? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((DateTime?)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullDateTime()
        {
            DateTime? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<DateTime?>(), Is.EqualTo(source));
            Assert.That(value.As<DateTime?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("DateTimeData")] DateTime testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(DateTime)));
            Assert.That((DateTime)o, Is.EqualTo(testValue));

            DateTime? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(DateTime)));
            Assert.That((DateTime)o, Is.EqualTo(testValue));
        }
    }
}
