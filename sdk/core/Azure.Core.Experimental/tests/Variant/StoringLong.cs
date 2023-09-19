// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringLong
    {
        public static long[] LongData => new[]
        {
            0,
            42,
            long.MaxValue,
            long.MinValue
        };

        [Test]
        public void LongImplicit([ValueSource("LongData")] long testValue)
        {
            Variant value = testValue;
            Assert.AreEqual(testValue, value.As<long>());
            Assert.AreEqual(typeof(long), value.Type);

            long? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<long>());
            Assert.AreEqual(typeof(long), value.Type);
        }

        [Test]
        public void LongCreate([ValueSource("LongData")] long testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.AreEqual(testValue, value.As<long>());
            Assert.AreEqual(typeof(long), value.Type);

            long? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<long?>());
            Assert.AreEqual(typeof(long), value.Type);
        }

        [Test]
        public void LongInOut([ValueSource("LongData")] long testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out long result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<long>());
            Assert.AreEqual(testValue, (long)value);
        }

        [Test]
        public void NullableLongInLongOut([ValueSource("LongData")] long? testValue)
        {
            long? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out long result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<long>());

            Assert.AreEqual(testValue, (long)value);
        }

        [Test]
        public void LongInNullableLongOut([ValueSource("LongData")] long testValue)
        {
            long source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out long? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (long?)value);
        }

        [Test]
        public void BoxedLong([ValueSource("LongData")] long testValue)
        {
            long i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(long), value.Type);
            Assert.True(value.TryGetValue(out long result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out long? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            long? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(long), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullLong()
        {
            long? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<long?>());
            Assert.False(value.As<long?>().HasValue);
        }

        [Test]
        public void OutAsObject([ValueSource("LongData")] long testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(long), o.GetType());
            Assert.AreEqual(testValue, (long)o);

            long? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(long), o.GetType());
            Assert.AreEqual(testValue, (long)o);
        }
    }
}
