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
            BinaryData data = BinaryData.FromMemory(payload);
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
            BinaryData data = new BinaryData(payload);

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
        }

        [Test]
        public void ToStringRespectsArraySegmentBoundaries()
        {
            var payload = "pre payload post";
            var bytes = Encoding.UTF8.GetBytes(payload);
            var segment = new ArraySegment<byte>(bytes, 4, 7);
            var data = BinaryData.FromMemory(segment);
            Assert.AreEqual("payload", data.ToString());
        }

        [Test]
        public async Task ToStreamRespectsArraySegmentBoundaries()
        {
            var payload = "pre payload post";
            var bytes = Encoding.UTF8.GetBytes(payload);
            var segment = new ArraySegment<byte>(bytes, 4, 7);
            var data = BinaryData.FromMemory(segment);
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

            await AssertData(BinaryData.Serialize(payload, serializer));
            await AssertData(await BinaryData.SerializeAsync(payload, serializer));

            await AssertData(BinaryData.Serialize(payload));
            await AssertData(await BinaryData.SerializeAsync(payload));

            await AssertData(new BinaryData(payload, typeof(TestModel)));
            await AssertData(new BinaryData(payload, typeof(TestModel), null));
            await AssertData(new BinaryData(payload, typeof(TestModel), serializer));

            async Task AssertData(BinaryData data)
            {
                Assert.AreEqual(payload.A, data.Deserialize<TestModel>(serializer).A);
                Assert.AreEqual(payload.B, data.Deserialize<TestModel>(serializer).B);
                Assert.AreEqual(payload.C, data.Deserialize<TestModel>(serializer).C);
                Assert.AreEqual(payload.A, (await data.DeserializeAsync<TestModel>(serializer)).A);
                Assert.AreEqual(payload.B, (await data.DeserializeAsync<TestModel>(serializer)).B);
                Assert.AreEqual(payload.C, (await data.DeserializeAsync<TestModel>(serializer)).C);

                Assert.AreEqual(payload.A, data.Deserialize<TestModel>().A);
                Assert.AreEqual(payload.B, data.Deserialize<TestModel>().B);
                Assert.AreEqual(payload.C, data.Deserialize<TestModel>().C);
                Assert.AreEqual(payload.A, (await data.DeserializeAsync<TestModel>()).A);
                Assert.AreEqual(payload.B, (await data.DeserializeAsync<TestModel>()).B);
                Assert.AreEqual(payload.C, (await data.DeserializeAsync<TestModel>()).C);
            }
        }

        [Test]
        public void FromSerializableThrowsOnNullSerializer()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            Assert.That(
                () => BinaryData.Serialize(payload, null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                async () => await BinaryData.SerializeAsync(payload, null),
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
        public async Task DeserializeThrowsExceptionOnIncompatibleType()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            AssertData(BinaryData.Serialize(payload));
            AssertData(await BinaryData.SerializeAsync(payload));

            void AssertData(BinaryData data)
            {
                Assert.That(
                    () => data.Deserialize<string>(),
                    Throws.InstanceOf<Exception>());
                Assert.That(
                    async () => await data.DeserializeAsync<string>(),
                    Throws.InstanceOf<Exception>());
            }
        }

        [Test]
        public void DeserializeThrowsOnNullSerializer()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            var serializer = new JsonObjectSerializer();
            var data = BinaryData.Serialize(payload, serializer);
            Assert.That(
                () => data.Deserialize<TestModel>(null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                async () => await data.DeserializeAsync<TestModel>(null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void EqualsRespectsReferenceEquality()
        {
            var payload = Encoding.UTF8.GetBytes("some data");
            var a = BinaryData.FromMemory(payload);
            var b = BinaryData.FromMemory(payload);
            Assert.AreEqual(a, b);

            var c = BinaryData.FromMemory(Encoding.UTF8.GetBytes("some data"));
            Assert.AreNotEqual(a, c);

            Assert.AreNotEqual(a, "string data");
        }

        [Test]
        public void GetHashCodeWorks()
        {
            var payload = Encoding.UTF8.GetBytes("some data");
            var a = BinaryData.FromMemory(payload);
            var b = BinaryData.FromMemory(payload);
            var set = new HashSet<BinaryData>
            {
                a
            };
            // hashcodes of a and b should match since instances use same memory.
            Assert.IsTrue(set.Contains(b));

            var c = BinaryData.FromMemory(Encoding.UTF8.GetBytes("some data"));
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
