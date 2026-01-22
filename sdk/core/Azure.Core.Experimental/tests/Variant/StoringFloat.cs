// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringFloat
    {
        public static float[] FloatData => new[]
        {
            0f,
            42f,
            float.MaxValue,
            float.MinValue,
            float.NaN,
            float.NegativeInfinity,
            float.PositiveInfinity
        };

        [Test]
        public void FloatImplicit([ValueSource("FloatData")] float testValue)
        {
            Variant value = testValue;
            Assert.That(value.As<float>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(float)));

            float? source = testValue;
            value = source;
            Assert.That(value.As<float?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(float)));
        }

        [Test]
        public void FloatCreate([ValueSource("FloatData")] float testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<float>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(float)));

            float? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<float?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(float)));
        }

        [Test]
        public void FloatInOut([ValueSource("FloatData")] float testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out float result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<float>(), Is.EqualTo(testValue));
            Assert.That((float)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableFloatInFloatOut([ValueSource("FloatData")] float? testValue)
        {
            float? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out float result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<float>(), Is.EqualTo(testValue));

            Assert.That((float)value, Is.EqualTo(testValue));
        }

        [Test]
        public void FloatInNullableFloatOut([ValueSource("FloatData")] float testValue)
        {
            float source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out float? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((float?)value, Is.EqualTo(testValue));
        }

        [Test]
        public void BoxedFloat([ValueSource("FloatData")] float testValue)
        {
            float i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(float)));
            Assert.That(value.TryGetValue(out float result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out float? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            float? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(float)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullFloat()
        {
            float? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<float?>(), Is.EqualTo(source));
            Assert.That(value.As<float?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("FloatData")] float testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(float)));
            Assert.That((float)o, Is.EqualTo(testValue));

            float? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(float)));
            Assert.That((float)o, Is.EqualTo(testValue));
        }
    }
}
