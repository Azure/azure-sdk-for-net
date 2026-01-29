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

            Assert.That(value.Type, Is.EqualTo(typeof(byte[])));
            Assert.That(value.As<byte[]>(), Is.SameAs(b));
            Assert.That((byte[])value.As<object>(), Is.EqualTo(b));

            Assert.Throws<InvalidCastException>(() => value.As<ArraySegment<byte>>());
        }

        [Test]
        public void CharArray()
        {
            char[] b = new char[10];

            var watch = MemoryWatch.Create();
            Variant value = Variant.Create(b);
            watch.Validate();

            Assert.That(value.Type, Is.EqualTo(typeof(char[])));
            Assert.That(value.As<char[]>(), Is.SameAs(b));
            Assert.That((char[])value.As<object>(), Is.EqualTo(b));

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

            Assert.That(value.Type, Is.EqualTo(typeof(ArraySegment<byte>)));
            Assert.That(value.As<ArraySegment<byte>>(), Is.EqualTo(segment));
            Assert.That((ArraySegment<byte>)value.As<object>(), Is.EqualTo(segment));
            Assert.Throws<InvalidCastException>(() => value.As<byte[]>());

            segment = new(b, 0, 0);
            value = Variant.Create(segment);
            Assert.That(value.Type, Is.EqualTo(typeof(ArraySegment<byte>)));
            Assert.That(value.As<ArraySegment<byte>>(), Is.EqualTo(segment));
            Assert.That((ArraySegment<byte>)value.As<object>(), Is.EqualTo(segment));
            Assert.Throws<InvalidCastException>(() => value.As<byte[]>());

            segment = new(b, 1, 1);
            value = Variant.Create(segment);
            Assert.That(value.Type, Is.EqualTo(typeof(ArraySegment<byte>)));
            Assert.That(value.As<ArraySegment<byte>>(), Is.EqualTo(segment));
            Assert.That((ArraySegment<byte>)value.As<object>(), Is.EqualTo(segment));
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

            Assert.That(value.Type, Is.EqualTo(typeof(ArraySegment<char>)));
            Assert.That(value.As<ArraySegment<char>>(), Is.EqualTo(segment));
            Assert.That((ArraySegment<char>)value.As<object>(), Is.EqualTo(segment));
            Assert.Throws<InvalidCastException>(() => value.As<char[]>());

            segment = new(b, 0, 0);
            value = Variant.Create(segment);
            Assert.That(value.Type, Is.EqualTo(typeof(ArraySegment<char>)));
            Assert.That(value.As<ArraySegment<char>>(), Is.EqualTo(segment));
            Assert.That((ArraySegment<char>)value.As<object>(), Is.EqualTo(segment));
            Assert.Throws<InvalidCastException>(() => value.As<char[]>());

            segment = new(b, 1, 1);
            value = Variant.Create(segment);
            Assert.That(value.Type, Is.EqualTo(typeof(ArraySegment<char>)));
            Assert.That(value.As<ArraySegment<char>>(), Is.EqualTo(segment));
            Assert.That((ArraySegment<char>)value.As<object>(), Is.EqualTo(segment));
            Assert.Throws<InvalidCastException>(() => value.As<char[]>());
        }
    }
}
