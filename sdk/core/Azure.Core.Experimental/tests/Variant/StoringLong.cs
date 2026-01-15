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
            Assert.That(value.As<long>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(long)));

            long? source = testValue;
            value = source;
            Assert.That(value.As<long>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(long)));
        }

        [Test]
        public void LongCreate([ValueSource("LongData")] long testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<long>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(long)));

            long? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<long?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(long)));
        }

        [Test]
        public void LongInOut([ValueSource("LongData")] long testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out long result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<long>(), Is.EqualTo(testValue));
            Assert.That((long)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableLongInLongOut([ValueSource("LongData")] long? testValue)
        {
            long? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out long result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<long>(), Is.EqualTo(testValue));

            Assert.That((long)value, Is.EqualTo(testValue));
        }

        [Test]
        public void LongInNullableLongOut([ValueSource("LongData")] long testValue)
        {
            long source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out long? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((long?)value, Is.EqualTo(testValue));
        }

        [Test]
        public void BoxedLong([ValueSource("LongData")] long testValue)
        {
            long i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(long)));
            Assert.That(value.TryGetValue(out long result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out long? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            long? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(long)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullLong()
        {
            long? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<long?>(), Is.EqualTo(source));
            Assert.That(value.As<long?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("LongData")] long testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(long)));
            Assert.That((long)o, Is.EqualTo(testValue));

            long? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(long)));
            Assert.That((long)o, Is.EqualTo(testValue));
        }
    }
}
