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
            Assert.That(value.As<short>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(short)));

            short? source = testValue;
            value = source;
            Assert.That(value.As<short?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(short)));
        }

        [Test]
        public void ShortCreate([ValueSource("ShortData")] short testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<short>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(short)));

            short? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<short?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(short)));
        }

        [Test]
        public void ShortInOut([ValueSource("ShortData")] short testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out short result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<short>(), Is.EqualTo(testValue));
            Assert.That((short)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableShortInShortOut([ValueSource("ShortData")] short? testValue)
        {
            short? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out short result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<short>(), Is.EqualTo(testValue));

            Assert.That((short)value, Is.EqualTo(testValue));
        }

        [Test]
        public void ShortInNullableShortOut([ValueSource("ShortData")] short testValue)
        {
            short source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out short? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((short?)value, Is.EqualTo(testValue));
        }

        [Test]
        public void BoxedShort([ValueSource("ShortData")] short testValue)
        {
            short i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(short)));
            Assert.That(value.TryGetValue(out short result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out short? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            short? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(short)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullShort()
        {
            short? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<short?>(), Is.EqualTo(source));
            Assert.That(value.As<short?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("ShortData")] short testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(short)));
            Assert.That((short)o, Is.EqualTo(testValue));

            short? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(short)));
            Assert.That((short)o, Is.EqualTo(testValue));
        }
    }
}
