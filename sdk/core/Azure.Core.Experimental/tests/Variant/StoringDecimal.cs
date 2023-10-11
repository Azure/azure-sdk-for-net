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
            Assert.AreEqual((decimal)42.0, value.As<decimal>());
            Assert.AreEqual(typeof(decimal), value.Type);

            decimal? source = (decimal?)42.0;
            value = source;
            Assert.AreEqual(source, value.As<decimal?>());
            Assert.AreEqual(typeof(decimal), value.Type);
        }

        [Test]
        public void DecimalInOut([ValueSource("DecimalData")] decimal testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out decimal result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<decimal>());
            Assert.AreEqual(testValue, (decimal)value);
        }

        [Test]
        public void NullableDecimalInDecimalOut([ValueSource("DecimalData")] decimal? testValue)
        {
            decimal? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out decimal result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<decimal>());

            Assert.AreEqual(testValue, (decimal)value);
        }

        [Test]
        public void DecimalInNullableDecimalOut([ValueSource("DecimalData")] decimal testValue)
        {
            decimal source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out decimal? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (decimal?)value);
        }

        [Test]
        public void NullDecimal()
        {
            decimal? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<decimal?>());
            Assert.False(value.As<decimal?>().HasValue);
        }

        [Test]
        public void OutAsObject([ValueSource("DecimalData")] decimal testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(decimal), o.GetType());
            Assert.AreEqual(testValue, (decimal)o);

            decimal? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(decimal), o.GetType());
            Assert.AreEqual(testValue, (decimal)o);
        }
    }
}
