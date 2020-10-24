// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace System
{
    public class BinaryDataTests
    {
        [Test]
        public void CanCreateBinaryDataFromBytes()
        {
            byte[] payload = Encoding.UTF8.GetBytes("some data");
            BinaryData data = BinaryData.FromBytes(payload);
            Assert.AreEqual(payload, data.ToBytes().ToArray());

            MemoryMarshal.TryGetArray<byte>(payload, out var array);
            Assert.AreSame(payload, array.Array);

            // using implicit conversion
            ReadOnlyMemory<byte> bytes = data;
            Assert.AreEqual(payload, bytes.ToArray());
        }

        [Test]
        public void CanCreateBinaryDataFromString()
        {
            var payload = "some data";
            var data = new BinaryData(payload);
            Assert.AreEqual(payload, data.ToString());

            data = BinaryData.FromString(payload);
            Assert.AreEqual(payload, data.ToString());
        }

        [Test]
        public void ToStringRespectsArraySegmentBoundaries()
        {
            var payload = "pre payload post";
            var bytes = Encoding.UTF8.GetBytes(payload);
            var segment = new ArraySegment<byte>(bytes, 4, 7);
            var data = BinaryData.FromBytes(segment);
            Assert.AreEqual("payload", data.ToString());

            data = BinaryData.FromBytes(segment.Array);
            Assert.AreEqual("pre payload post", data.ToString());
        }

        [Test]
        public async Task ToStreamRespectsArraySegmentBoundaries()
        {
            var payload = "pre payload post";
            var bytes = Encoding.UTF8.GetBytes(payload);
            var segment = new ArraySegment<byte>(bytes, 4, 7);
            var data = BinaryData.FromBytes(segment);
            var stream = data.ToStream();
            var sr = new StreamReader(stream);
            Assert.AreEqual("payload", await sr.ReadToEndAsync());
        }

        [Test]
        public async Task CannotWriteToReadOnlyMemoryStream()
        {
            var buffer = Encoding.UTF8.GetBytes("some data");
            var payload = new MemoryStream(buffer);
            var data = BinaryData.FromStream(payload);
            var stream = data.ToStream();
            Assert.That(
                () => stream.Write(buffer, 0, buffer.Length),
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                async () => await stream.WriteAsync(buffer, 0, buffer.Length),
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => stream.WriteByte(1),
                Throws.InstanceOf<NotSupportedException>());
            Assert.IsFalse(stream.CanWrite);
            var sr = new StreamReader(stream);
            Assert.AreEqual("some data", await sr.ReadToEndAsync());
        }

        [Test]
        public async Task CanCreateBinaryDataFromStream()
        {
            var buffer = Encoding.UTF8.GetBytes("some data");
            var stream = new MemoryStream(buffer);
            var data = BinaryData.FromStream(stream);
            Assert.AreEqual(buffer, data.ToBytes().ToArray());
            Assert.AreEqual(stream, data.ToStream());

            stream.Position = 0;
            data = await BinaryData.FromStreamAsync(stream);
            Assert.AreEqual(buffer, data.ToBytes().ToArray());
            Assert.AreEqual(stream, data.ToStream());
        }

        [Test]
        public async Task StartPositionOfStreamRespected()
        {
            var buffer = Encoding.UTF8.GetBytes("some data");
            var stream = new MemoryStream(buffer);
            long start = 4;
            var payload = new ReadOnlyMemory<byte>(buffer, (int) start, buffer.Length - (int) start);

            stream.Position = start;
            var data = BinaryData.FromStream(stream);
            Assert.AreEqual(payload.ToArray(), data.ToBytes().ToArray());
            Assert.AreEqual(5, data.ToStream().Length);

            stream.Position = start;
            data = await BinaryData.FromStreamAsync(stream);
            Assert.AreEqual(payload.ToArray(), data.ToBytes().ToArray());
            Assert.AreEqual(5, data.ToStream().Length);
        }

        [Test]
        public void MaxStreamLengthRespected()
        {
            var mockStream = new Mock<Stream>();
            mockStream.Setup(s => s.CanSeek).Returns(true);
            mockStream.Setup(s => s.Length).Returns((long)int.MaxValue + 1);
            Assert.That(
                () => BinaryData.FromStream(mockStream.Object),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CanCreateBinaryDataFromCustomType()
        {
            var payload = new TestModel { A = "value", B = 5, C = true, D = null };

            AssertData(BinaryData.FromObjectAsJson(payload));
            AssertData(BinaryData.FromObjectAsJson(payload, new Text.Json.JsonSerializerOptions { IgnoreNullValues = true }));
            AssertData(new BinaryData(payload, type: typeof(TestModel)));
            AssertData(new BinaryData(payload, options: null, typeof(TestModel)));
            AssertData(new BinaryData(payload, new Text.Json.JsonSerializerOptions() { IgnoreNullValues = true }, typeof(TestModel)));

            void AssertData(BinaryData data)
            {
                var model = data.ToObjectFromJson<TestModel>();
                Assert.AreEqual(payload.A, model.A);
                Assert.AreEqual(payload.B, model.B);
                Assert.AreEqual(payload.C, model.C);
                Assert.AreEqual(payload.D, model.D);
            }
        }

        [Test]
        public void CanSerializeNullData()
        {
            var data = new BinaryData(jsonSerializable: null);
            Assert.IsNull(data.ToObjectFromJson<object>());
            data = BinaryData.FromObjectAsJson<object>(null);
            Assert.IsNull(data.ToObjectFromJson<object>());
        }

        [Test]
        public void CreateThrowsOnNullStream()
        {
            Assert.That(
                () => BinaryData.FromStream(null),
                Throws.InstanceOf<ArgumentNullException>());

            Assert.That(
                async () => await BinaryData.FromStreamAsync(null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ToObjectThrowsExceptionOnIncompatibleType()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            var data = BinaryData.FromObjectAsJson(payload);
            Assert.That(
                () => data.ToObjectFromJson<string>(),
                Throws.InstanceOf<Exception>());
        }

        [Test]
        public void EqualsRespectsReferenceEquality()
        {
            var payload = Encoding.UTF8.GetBytes("some data");
            var a = BinaryData.FromBytes(payload);
            var b = BinaryData.FromBytes(payload);
            Assert.AreEqual(a, b);

            var c = BinaryData.FromBytes(Encoding.UTF8.GetBytes("some data"));
            Assert.AreNotEqual(a, c);

            Assert.AreNotEqual(a, "string data");
        }

        [Test]
        public void GetHashCodeWorks()
        {
            var payload = Encoding.UTF8.GetBytes("some data");
            var a = BinaryData.FromBytes(payload);
            var b = BinaryData.FromBytes(payload);
            var set = new HashSet<BinaryData>
            {
                a
            };
            // hashcodes of a and b should match since instances use same memory.
            Assert.IsTrue(set.Contains(b));

            var c = BinaryData.FromBytes(Encoding.UTF8.GetBytes("some data"));
            // c should have a different hash code
            Assert.IsFalse(set.Contains(c));
            set.Add(c);
            Assert.IsTrue(set.Contains(c));
        }

        private class TestModel
        {
            public string A { get; set; }
            public int B { get; set; }
            public bool C { get; set; }
            public object D { get; set; }
        }
    }
}
