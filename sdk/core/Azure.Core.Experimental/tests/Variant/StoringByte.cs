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
            Assert.AreEqual(testValue, value.As<byte>());
            Assert.AreEqual(typeof(byte), value.Type);

            byte? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<byte?>());
            Assert.AreEqual(typeof(byte), value.Type);
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

            Assert.AreEqual(testValue, value.As<byte>());
            Assert.AreEqual(typeof(byte), value.Type);

            byte? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<byte?>());
            Assert.AreEqual(typeof(byte), value.Type);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteInOut(byte testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out byte result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<byte>());
            Assert.AreEqual(testValue, (byte)value);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void NullableByteInByteOut(byte? testValue)
        {
            byte? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out byte result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<byte>());

            Assert.AreEqual(testValue, (byte)value);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteInNullableByteOut(byte testValue)
        {
            byte source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out byte? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (byte?)value);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void BoxedByte(byte testValue)
        {
            byte i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(byte), value.Type);
            Assert.True(value.TryGetValue(out byte result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out byte? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            byte? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(byte), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullByte()
        {
            byte? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<byte?>());
            Assert.False(value.As<byte?>().HasValue);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void OutAsObject(byte testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(byte), o.GetType());
            Assert.AreEqual(testValue, (byte)o);

            byte? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(byte), o.GetType());
            Assert.AreEqual(testValue, (byte)o);
        }
    }
}
