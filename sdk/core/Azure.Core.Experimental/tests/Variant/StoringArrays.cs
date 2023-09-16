// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringArrays
    {
        [Test]
        public void ByteArray()
        {
            byte[] b = new byte[10];

            var watch = MemoryWatch.Create();
            Variant value = Variant.Create(b);
            watch.Validate();

            Assert.AreEqual(typeof(byte[]), value.Type);
            Assert.AreSame(b, value.As<byte[]>());
            Assert.AreEqual(b, (byte[])value.As<object>());

            Assert.Throws<InvalidCastException>(() => value.As<ArraySegment<byte>>());
        }

        [Test]
        public void CharArray()
        {
            char[] b = new char[10];

            var watch = MemoryWatch.Create();
            Variant value = Variant.Create(b);
            watch.Validate();

            Assert.AreEqual(typeof(char[]), value.Type);
            Assert.AreSame(b, value.As<char[]>());
            Assert.AreEqual(b, (char[])value.As<object>());

            Assert.Throws<InvalidCastException>(() => value.As<ArraySegment<char>>());
        }

        [Test]
        public void ByteSegment()
        {
            byte[] b = new byte[10];
            ArraySegment<byte> segment = new(b);

            var watch = MemoryWatch.Create();
            Variant value = Variant.Create(segment);
            watch.Validate();

            Assert.AreEqual(typeof(ArraySegment<byte>), value.Type);
            Assert.AreEqual(segment, value.As<ArraySegment<byte>>());
            Assert.AreEqual(segment, (ArraySegment<byte>)value.As<object>());
            Assert.Throws<InvalidCastException>(() => value.As<byte[]>());

            segment = new(b, 0, 0);
            value = Variant.Create(segment);
            Assert.AreEqual(typeof(ArraySegment<byte>), value.Type);
            Assert.AreEqual(segment, value.As<ArraySegment<byte>>());
            Assert.AreEqual(segment, (ArraySegment<byte>)value.As<object>());
            Assert.Throws<InvalidCastException>(() => value.As<byte[]>());

            segment = new(b, 1, 1);
            value = Variant.Create(segment);
            Assert.AreEqual(typeof(ArraySegment<byte>), value.Type);
            Assert.AreEqual(segment, value.As<ArraySegment<byte>>());
            Assert.AreEqual(segment, (ArraySegment<byte>)value.As<object>());
            Assert.Throws<InvalidCastException>(() => value.As<byte[]>());
        }

        [Test]
        public void CharSegment()
        {
            char[] b = new char[10];
            ArraySegment<char> segment = new(b);

            var watch = MemoryWatch.Create();
            Variant value = Variant.Create(segment);
            watch.Validate();

            Assert.AreEqual(typeof(ArraySegment<char>), value.Type);
            Assert.AreEqual(segment, value.As<ArraySegment<char>>());
            Assert.AreEqual(segment, (ArraySegment<char>)value.As<object>());
            Assert.Throws<InvalidCastException>(() => value.As<char[]>());

            segment = new(b, 0, 0);
            value = Variant.Create(segment);
            Assert.AreEqual(typeof(ArraySegment<char>), value.Type);
            Assert.AreEqual(segment, value.As<ArraySegment<char>>());
            Assert.AreEqual(segment, (ArraySegment<char>)value.As<object>());
            Assert.Throws<InvalidCastException>(() => value.As<char[]>());

            segment = new(b, 1, 1);
            value = Variant.Create(segment);
            Assert.AreEqual(typeof(ArraySegment<char>), value.Type);
            Assert.AreEqual(segment, value.As<ArraySegment<char>>());
            Assert.AreEqual(segment, (ArraySegment<char>)value.As<object>());
            Assert.Throws<InvalidCastException>(() => value.As<char[]>());
        }
    }
}
