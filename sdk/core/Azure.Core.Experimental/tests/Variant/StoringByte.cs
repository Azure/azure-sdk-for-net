// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using NUnit.Framework;

namespace Azure
{
    public class StoringByte
    {
        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteImplicit(byte @byte)
        {
            Value value = @byte;
            Assert.AreEqual(@byte, value.As<byte>());
            Assert.AreEqual(typeof(byte), value.Type);

            byte? source = @byte;
            value = source;
            Assert.AreEqual(source, value.As<byte?>());
            Assert.AreEqual(typeof(byte), value.Type);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteCreate(byte @byte)
        {
            Value value;
            using (MemoryWatch.Create)
            {
                value = Value.Create(@byte);
            }

            Assert.AreEqual(@byte, value.As<byte>());
            Assert.AreEqual(typeof(byte), value.Type);

            byte? source = @byte;

            using (MemoryWatch.Create)
            {
                value = Value.Create(source);
            }

            Assert.AreEqual(source, value.As<byte?>());
            Assert.AreEqual(typeof(byte), value.Type);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteInOut(byte @byte)
        {
            Value value = new(@byte);
            bool success = value.TryGetValue(out byte result);
            Assert.True(success);
            Assert.AreEqual(@byte, result);

            Assert.AreEqual(@byte, value.As<byte>());
            Assert.AreEqual(@byte, (byte)value);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void NullableByteInByteOut(byte? @byte)
        {
            byte? source = @byte;
            Value value = new(source);

            bool success = value.TryGetValue(out byte result);
            Assert.True(success);
            Assert.AreEqual(@byte, result);

            Assert.AreEqual(@byte, value.As<byte>());

            Assert.AreEqual(@byte, (byte)value);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void ByteInNullableByteOut(byte @byte)
        {
            byte source = @byte;
            Value value = new(source);
            bool success = value.TryGetValue(out byte? result);
            Assert.True(success);
            Assert.AreEqual(@byte, result);

            Assert.AreEqual(@byte, (byte?)value);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void BoxedByte(byte @byte)
        {
            byte i = @byte;
            object o = i;
            Value value = new(o);

            Assert.AreEqual(typeof(byte), value.Type);
            Assert.True(value.TryGetValue(out byte result));
            Assert.AreEqual(@byte, result);
            Assert.True(value.TryGetValue(out byte? nullableResult));
            Assert.AreEqual(@byte, nullableResult!.Value);

            byte? n = @byte;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(byte), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@byte, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(@byte, nullableResult!.Value);
        }

        [Test]
        public void NullByte()
        {
            byte? source = null;
            Value value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<byte?>());
            Assert.False(value.As<byte?>().HasValue);
        }

        [TestCase(42)]
        [TestCase(byte.MinValue)]
        [TestCase(byte.MaxValue)]
        public void OutAsObject(byte @byte)
        {
            Value value = new(@byte);
            object o = value.As<object>();
            Assert.AreEqual(typeof(byte), o.GetType());
            Assert.AreEqual(@byte, (byte)o);

            byte? n = @byte;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(byte), o.GetType());
            Assert.AreEqual(@byte, (byte)o);
        }
    }
}
