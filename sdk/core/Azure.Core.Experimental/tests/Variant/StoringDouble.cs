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
            Assert.That(value.As<double>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(double)));

            double? source = testValue;
            value = source;
            Assert.That(value.As<double?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(double)));
        }

        [Test]
        public void DoubleCreate([ValueSource("DoubleData")] double testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<double>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(double)));

            double? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<double?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(double)));
        }

        [Test]
        public void DoubleInOut([ValueSource("DoubleData")] double testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out double result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<double>(), Is.EqualTo(testValue));
            Assert.That((double)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableDoubleInDoubleOut([ValueSource("DoubleData")] double? testValue)
        {
            double? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out double result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<double>(), Is.EqualTo(testValue));

            Assert.That((double)value, Is.EqualTo(testValue));
        }

        [Test]
        public void DoubleInNullableDoubleOut([ValueSource("DoubleData")] double testValue)
        {
            double source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out double? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((double)value, Is.EqualTo(testValue));
        }

        [Test]
        public void BoxedDouble([ValueSource("DoubleData")] double testValue)
        {
            double i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(double)));
            Assert.That(value.TryGetValue(out double result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out double? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            double? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(double)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullDouble()
        {
            double? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<double?>(), Is.EqualTo(source));
            Assert.That(value.As<double?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("DoubleData")] double testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(double)));
            Assert.That((double)o, Is.EqualTo(testValue));

            double? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(double)));
            Assert.That((double)o, Is.EqualTo(testValue));
        }
    }
}
