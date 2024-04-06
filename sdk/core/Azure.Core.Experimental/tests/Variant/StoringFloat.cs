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
            Assert.AreEqual(testValue, value.As<float>());
            Assert.AreEqual(typeof(float), value.Type);

            float? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<float?>());
            Assert.AreEqual(typeof(float), value.Type);
        }

        [Test]
        public void FloatCreate([ValueSource("FloatData")] float testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.AreEqual(testValue, value.As<float>());
            Assert.AreEqual(typeof(float), value.Type);

            float? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<float?>());
            Assert.AreEqual(typeof(float), value.Type);
        }

        [Test]
        public void FloatInOut([ValueSource("FloatData")] float testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out float result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<float>());
            Assert.AreEqual(testValue, (float)value);
        }

        [Test]
        public void NullableFloatInFloatOut([ValueSource("FloatData")] float? testValue)
        {
            float? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out float result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<float>());

            Assert.AreEqual(testValue, (float)value);
        }

        [Test]
        public void FloatInNullableFloatOut([ValueSource("FloatData")] float testValue)
        {
            float source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out float? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (float?)value);
        }

        [Test]
        public void BoxedFloat([ValueSource("FloatData")] float testValue)
        {
            float i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(float), value.Type);
            Assert.True(value.TryGetValue(out float result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out float? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            float? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(float), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullFloat()
        {
            float? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<float?>());
            Assert.False(value.As<float?>().HasValue);
        }

        [Test]
        public void OutAsObject([ValueSource("FloatData")] float testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(float), o.GetType());
            Assert.AreEqual(testValue, (float)o);

            float? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(float), o.GetType());
            Assert.AreEqual(testValue, (float)o);
        }
    }
}
