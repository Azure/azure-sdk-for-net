// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class BinaryDataTests
    {
        [Test]
        public void CanCreateBinaryDataFromBytes()
        {
            var payload = Encoding.UTF8.GetBytes("some data");
            var data = new BinaryData(payload);
            Assert.AreEqual(payload, data.AsBytes().ToArray());

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
        public void AsStringThrowsOnNullEncoding()
        {
            var payload = "some data";
            var data = new BinaryData(payload);
            Assert.That(
                () => data.ToString(null),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public async Task CanCreateBinaryDataFromStream()
        {
            var buffer = Encoding.UTF8.GetBytes("some data");
            var payload = new MemoryStream(buffer);
            var data = BinaryData.FromStream(payload);
            Assert.AreEqual(buffer, data.AsBytes().ToArray());
            Assert.AreEqual(payload, data.ToStream());

            payload.Position = 0;
            data = await BinaryData.FromStreamAsync(payload);
            Assert.AreEqual(buffer, data.AsBytes().ToArray());
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
            await AssertData(BinaryData.FromSerializable(payload, serializer));
            await AssertData(await BinaryData.FromSerializableAsync(payload, serializer));

            async Task AssertData(BinaryData data)
            {
                Assert.AreEqual(payload.A, data.Deserialize<TestModel>(serializer).A);
                Assert.AreEqual(payload.B, data.Deserialize<TestModel>(serializer).B);
                Assert.AreEqual(payload.C, data.Deserialize<TestModel>(serializer).C);
                Assert.AreEqual(payload.A, (await data.DeserializeAsync<TestModel>(serializer)).A);
                Assert.AreEqual(payload.B, (await data.DeserializeAsync<TestModel>(serializer)).B);
                Assert.AreEqual(payload.C, (await data.DeserializeAsync<TestModel>(serializer)).C);
            }
        }

        [Test]
        public void GenericCreateThrowsOnNullSerializer()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            Assert.That(
                () => BinaryData.FromSerializable(payload, null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                async () => await BinaryData.FromSerializableAsync(payload, null),
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
        public async Task AsThrowsExceptionOnIncompatibleType()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            var serializer = new JsonObjectSerializer();
            AssertData(BinaryData.FromSerializable(payload, serializer));
            AssertData(await BinaryData.FromSerializableAsync(payload, serializer));

            void AssertData(BinaryData data)
            {
                Assert.That(
                    () => data.Deserialize<string>(serializer),
                    Throws.InstanceOf<Exception>());
                Assert.That(
                    async () => await data.DeserializeAsync<string>(serializer),
                    Throws.InstanceOf<Exception>());
            }
        }

        [Test]
        public void AsThrowsOnNullSerializer ()
        {
            var payload = new TestModel { A = "value", B = 5, C = true };
            var serializer = new JsonObjectSerializer();
            var data = BinaryData.FromSerializable(payload, serializer);
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
            var a = new BinaryData(payload);
            var b = new BinaryData(payload);
            Assert.AreEqual(a, b);

            var c = new BinaryData(Encoding.UTF8.GetBytes("some data"));
            Assert.AreNotEqual(a, c);

            Assert.AreNotEqual(a, "string data");
        }

        [Test]
        public void GetHashCodeWorks()
        {
            var payload = Encoding.UTF8.GetBytes("some data");
            var a = new BinaryData(payload);
            var b = new BinaryData(payload);
            var set = new HashSet<BinaryData>
            {
                a
            };
            // hashcodes of a and b should match since instances use same memory.
            Assert.IsTrue(set.Contains(b));

            var c = new BinaryData(Encoding.UTF8.GetBytes("some data"));
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
