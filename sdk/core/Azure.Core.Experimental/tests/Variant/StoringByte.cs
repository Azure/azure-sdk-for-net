// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringByte
    {
        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteImplicit(byte testValue)
        {
            Variant value = testValue;
            Assert.That(value.As<byte>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(byte)));

            byte? source = testValue;
            value = source;
            Assert.That(value.As<byte?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(byte)));
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteCreate(byte testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<byte>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(byte)));

            byte? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<byte?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(byte)));
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteInOut(byte testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out byte result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<byte>(), Is.EqualTo(testValue));
            Assert.That((byte)value, Is.EqualTo(testValue));
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void NullableByteInByteOut(byte? testValue)
        {
            byte? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out byte result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<byte>(), Is.EqualTo(testValue));

            Assert.That((byte)value, Is.EqualTo(testValue));
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteInNullableByteOut(byte testValue)
        {
            byte source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out byte? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((byte?)value, Is.EqualTo(testValue));
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void BoxedByte(byte testValue)
        {
            byte i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(byte)));
            Assert.That(value.TryGetValue(out byte result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out byte? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            byte? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(byte)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullByte()
        {
            byte? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<byte?>(), Is.EqualTo(source));
            Assert.That(value.As<byte?>().HasValue, Is.False);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void OutAsObject(byte testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(byte)));
            Assert.That((byte)o, Is.EqualTo(testValue));

            byte? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(byte)));
            Assert.That((byte)o, Is.EqualTo(testValue));
        }
    }
}
