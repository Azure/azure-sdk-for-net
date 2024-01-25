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
            Assert.AreEqual(testValue, value.As<DateTime>());
            Assert.AreEqual(typeof(DateTime), value.Type);

            DateTime? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<DateTime?>());
            Assert.AreEqual(typeof(DateTime), value.Type);
        }

        [Test]
        public void DateTimeInOut([ValueSource("DateTimeData")] DateTime testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out DateTime result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<DateTime>());
            Assert.AreEqual(testValue, (DateTime)value);
        }

        [Test]
        public void NullableDateTimeInDateTimeOut([ValueSource("DateTimeData")] DateTime? testValue)
        {
            DateTime? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out DateTime result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<DateTime>());

            Assert.AreEqual(testValue, (DateTime)value);
        }

        [Test]
        public void DateTimeInNullableDateTimeOut([ValueSource("DateTimeData")] DateTime testValue)
        {
            DateTime source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out DateTime? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (DateTime?)value);
        }

        [Test]
        public void NullDateTime()
        {
            DateTime? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<DateTime?>());
            Assert.False(value.As<DateTime?>().HasValue);
        }

        [Test]
        public void OutAsObject([ValueSource("DateTimeData")] DateTime testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(DateTime), o.GetType());
            Assert.AreEqual(testValue, (DateTime)o);

            DateTime? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(DateTime), o.GetType());
            Assert.AreEqual(testValue, (DateTime)o);
        }
    }
}
