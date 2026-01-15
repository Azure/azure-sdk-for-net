// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringDecimal
    {
        public static decimal[] DecimalData => new[]
        {
            42,
            decimal.MaxValue,
            decimal.MinValue
        };

        [Test]
        public void DecimalImplicit()
        {
            Variant value = (decimal)42.0;
            Assert.That(value.As<decimal>(), Is.EqualTo((decimal)42.0));
            Assert.That(value.Type, Is.EqualTo(typeof(decimal)));

            decimal? source = (decimal?)42.0;
            value = source;
            Assert.That(value.As<decimal?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(decimal)));
        }

        [Test]
        public void DecimalInOut([ValueSource("DecimalData")] decimal testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out decimal result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<decimal>(), Is.EqualTo(testValue));
            Assert.That((decimal)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableDecimalInDecimalOut([ValueSource("DecimalData")] decimal? testValue)
        {
            decimal? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out decimal result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<decimal>(), Is.EqualTo(testValue));

            Assert.That((decimal)value, Is.EqualTo(testValue));
        }

        [Test]
        public void DecimalInNullableDecimalOut([ValueSource("DecimalData")] decimal testValue)
        {
            decimal source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out decimal? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((decimal?)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullDecimal()
        {
            decimal? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<decimal?>(), Is.EqualTo(source));
            Assert.That(value.As<decimal?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("DecimalData")] decimal testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(decimal)));
            Assert.That((decimal)o, Is.EqualTo(testValue));

            decimal? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(decimal)));
            Assert.That((decimal)o, Is.EqualTo(testValue));
        }
    }
}
