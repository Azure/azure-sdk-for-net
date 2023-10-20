// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringShort
    {
        public static short[] ShortData => new short[]
        {
            0,
            42,
            short.MaxValue,
            short.MinValue
        };

        [Test]
        public void ShortImplicit([ValueSource("ShortData")] short testValue)
        {
            Variant value = testValue;
            Assert.AreEqual(testValue, value.As<short>());
            Assert.AreEqual(typeof(short), value.Type);

            short? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<short?>());
            Assert.AreEqual(typeof(short), value.Type);
        }

        [Test]
        public void ShortCreate([ValueSource("ShortData")] short testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.AreEqual(testValue, value.As<short>());
            Assert.AreEqual(typeof(short), value.Type);

            short? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<short?>());
            Assert.AreEqual(typeof(short), value.Type);
        }

        [Test]
        public void ShortInOut([ValueSource("ShortData")] short testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out short result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<short>());
            Assert.AreEqual(testValue, (short)value);
        }

        [Test]
        public void NullableShortInShortOut([ValueSource("ShortData")] short? testValue)
        {
            short? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out short result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<short>());

            Assert.AreEqual(testValue, (short)value);
        }

        [Test]
        public void ShortInNullableShortOut([ValueSource("ShortData")] short testValue)
        {
            short source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out short? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (short?)value);
        }

        [Test]
        public void BoxedShort([ValueSource("ShortData")] short testValue)
        {
            short i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(short), value.Type);
            Assert.True(value.TryGetValue(out short result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out short? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            short? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(short), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullShort()
        {
            short? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<short?>());
            Assert.False(value.As<short?>().HasValue);
        }

        [Test]
        public void OutAsObject([ValueSource("ShortData")] short testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(short), o.GetType());
            Assert.AreEqual(testValue, (short)o);

            short? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(short), o.GetType());
            Assert.AreEqual(testValue, (short)o);
        }
    }
}
