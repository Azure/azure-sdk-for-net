// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringUInt
    {
        public static uint[] UInt32Data => new uint[]
        {
            42,
            uint.MaxValue,
            uint.MinValue
        };

        [Test]
        public void UIntImplicit([ValueSource("UInt32Data")] uint testValue)
        {
            Variant value = testValue;
            Assert.That(value.As<uint>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(uint)));

            uint? source = testValue;
            value = source;
            Assert.That(value.As<uint?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(uint)));
        }

        [Test]
        public void UIntCreate([ValueSource("UInt32Data")] uint testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<uint>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(uint)));

            uint? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<uint?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(uint)));
        }

        [Test]
        public void UIntInOut([ValueSource("UInt32Data")] uint testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out uint result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<uint>(), Is.EqualTo(testValue));
            Assert.That((uint)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableUIntInUIntOut([ValueSource("UInt32Data")] uint? testValue)
        {
            uint? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out uint result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<uint>(), Is.EqualTo(testValue));

            Assert.That((uint)value, Is.EqualTo(testValue));
        }

        [Test]
        public void UIntInNullableUIntOut([ValueSource("UInt32Data")] uint testValue)
        {
            uint source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out uint? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((uint?)value, Is.EqualTo(testValue));
        }

        [Test]
        public void BoxedUInt([ValueSource("UInt32Data")] uint testValue)
        {
            uint i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(uint)));
            Assert.That(value.TryGetValue(out uint result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out uint? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            uint? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(uint)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullUInt()
        {
            uint? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<uint?>(), Is.EqualTo(source));
            Assert.That(value.As<uint?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("UInt32Data")] uint testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(uint)));
            Assert.That((uint)o, Is.EqualTo(testValue));

            uint? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(uint)));
            Assert.That((uint)o, Is.EqualTo(testValue));
        }
    }
}
