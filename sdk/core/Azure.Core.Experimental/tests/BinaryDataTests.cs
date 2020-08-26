// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class BinaryDataTests
    {
        [Test]
        public void CanCreateBinaryDataFromBytes()
        {
            byte[] payload = Encoding.UTF8.GetBytes("some data");
            BinaryData data = BinaryData.FromBytes(payload);
            Assert.AreEqual(payload, data.Bytes.ToArray());

            MemoryMarshal.TryGetArray<byte>(payload, out var array);
            Assert.AreSame(payload, array.Array);

            // using implicit conversion
            ReadOnlyMemory<byte> bytes = data;
            Assert.AreEqual(payload, bytes.ToArray());
        }

        [Test]
        public void CanCreateBinaryDataUsingSpanCtor()
        {
            byte[] payload = Encoding.UTF8.GetBytes("some data");
            BinaryData data = new BinaryData(payload.AsSpan());

            Assert.AreNotSame(payload, data.Bytes);
            Assert.AreNotEqual(payload, data.Bytes);

            Assert.AreEqual(payload, data.Bytes.ToArray());

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
            var data = BinaryData.FromBytes((ReadOnlyMemory<byte>)segment);
            Assert.AreEqual("payload", data.ToString());

            data = BinaryData.FromBytes((ReadOnlySpan<byte>)segment);
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
            var data = BinaryData.FromBytes((ReadOnlyMemory<byte>)segment);
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
            var payload = new MemoryStream(buffer);
            var data = BinaryData.FromStream(payload);
            Assert.AreEqual(buffer, data.Bytes.ToArray());
            Assert.AreEqual(payload, data.ToStream());

            payload.Position = 0;
            data = await BinaryData.FromStreamAsync(payload);
            Assert.AreEqual(buffer, data.Bytes.ToArray());
            Assert.AreEqual(payload, data.ToStream());
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
        public async Task CanCreateBinaryDataFromCustomType()
        {
            var payload = new TestModel { A = "value", B = 5, C = true};
            var serializer = new JsonObjectSerializer();

            await AssertData(BinaryData.FromObject(payload, serializer));
            await AssertData(await BinaryData.FromObjectAsync(payload, serializer));

            await AssertData(BinaryData.FromObject(payload));
            await AssertData(await BinaryData.FromObjectAsync(payload));

            await AssertData(new BinaryData(payload, type: typeof(TestModel)));
            await AssertData(new BinaryData(payload, null, typeof(TestModel)));
            await AssertData(new BinaryData(payload, serializer, typeof(TestModel)));

            async Task AssertData(BinaryData data)
            {
                Assert.AreEqual(payload.A, data.ToObject<TestModel>(serializer).A);
                Assert.AreEqual(payload.B, data.ToObject<TestModel>(serializer).B);
                Assert.AreEqual(payload.C, data.ToObject<TestModel>(serializer).C);
                Assert.AreEqual(payload.A, (await data.ToObjectAsync<TestModel>(serializer)).A);
                Assert.AreEqual(payload.B, (await data.ToObjectAsync<TestModel>(serializer)).B);
                Assert.AreEqual(payload.C, (await data.ToObjectAsync<TestModel>(serializer)).C);

                Assert.AreEqual(payload.A, data.ToObject<TestModel>().A);
                Assert.AreEqual(payload.B, data.ToObject<TestModel>().B);
                Assert.AreEqual(payload.C, data.ToObject<TestModel>().C);
                Assert.AreEqual(payload.A, (await data.ToObjectAsync<TestModel>()).A);
                Assert.AreEqual(payload.B, (await data.ToObjectAsync<TestModel>()).B);
                Assert.AreEqual(payload.C, (await data.ToObjectAsync<TestModel>()).C);
            }
        }

        [Test]
        public void CanSerializeNullData()
        {
            var data = new BinaryData(jsonSerializable: null);
            Assert.IsNull(data.ToObject<object>());
            data = BinaryData.FromObject<object>(null);
            Assert.IsNull(data.ToObject<object>());
        }

        [Test]
        public void FromObjectThrowsOnNullSerializer()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            Assert.That(
                () => BinaryData.FromObject(payload, null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                async () => await BinaryData.FromObjectAsync(payload, null),
                Throws.InstanceOf<ArgumentNullException>());
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
        public async Task ToObjectThrowsExceptionOnIncompatibleType()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            AssertData(BinaryData.FromObject(payload));
            AssertData(await BinaryData.FromObjectAsync(payload));

            void AssertData(BinaryData data)
            {
                Assert.That(
                    () => data.ToObject<string>(),
                    Throws.InstanceOf<Exception>());
                Assert.That(
                    async () => await data.ToObjectAsync<string>(),
                    Throws.InstanceOf<Exception>());
            }
        }

        [Test]
        public void ToObjectThrowsOnNullSerializer()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            var serializer = new JsonObjectSerializer();
            var data = BinaryData.FromObject(payload, serializer);
            Assert.That(
                () => data.ToObject<TestModel>(null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                async () => await data.ToObjectAsync<TestModel>(null),
                Throws.InstanceOf<ArgumentNullException>());
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
        }
    }
}
