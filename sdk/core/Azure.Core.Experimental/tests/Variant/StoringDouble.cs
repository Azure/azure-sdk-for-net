// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringDouble
    {
        public static double[] DoubleData => new[]
        {
            0d,
            42d,
            double.MaxValue,
            double.MinValue,
            double.NaN,
            double.NegativeInfinity,
            double.PositiveInfinity
        };

        [Test]
        public void DoubleImplicit([ValueSource("DoubleData")] double testValue)
        {
            Variant value = testValue;
            Assert.AreEqual(testValue, value.As<double>());
            Assert.AreEqual(typeof(double), value.Type);

            double? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<double?>());
            Assert.AreEqual(typeof(double), value.Type);
        }

        [Test]
        public void DoubleCreate([ValueSource("DoubleData")] double testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.AreEqual(testValue, value.As<double>());
            Assert.AreEqual(typeof(double), value.Type);

            double? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<double?>());
            Assert.AreEqual(typeof(double), value.Type);
        }

        [Test]
        public void DoubleInOut([ValueSource("DoubleData")] double testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out double result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<double>());
            Assert.AreEqual(testValue, (double)value);
        }

        [Test]
        public void NullableDoubleInDoubleOut([ValueSource("DoubleData")] double? testValue)
        {
            double? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out double result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<double>());

            Assert.AreEqual(testValue, (double)value);
        }

        [Test]
        public void DoubleInNullableDoubleOut([ValueSource("DoubleData")] double testValue)
        {
            double source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out double? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (double)value);
        }

        [Test]
        public void BoxedDouble([ValueSource("DoubleData")] double testValue)
        {
            double i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(double), value.Type);
            Assert.True(value.TryGetValue(out double result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out double? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            double? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(double), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullDouble()
        {
            double? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<double?>());
            Assert.False(value.As<double?>().HasValue);
        }

        [Test]
        public void OutAsObject([ValueSource("DoubleData")] double testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(double), o.GetType());
            Assert.AreEqual(testValue, (double)o);

            double? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(double), o.GetType());
            Assert.AreEqual(testValue, (double)o);
        }
    }
}
