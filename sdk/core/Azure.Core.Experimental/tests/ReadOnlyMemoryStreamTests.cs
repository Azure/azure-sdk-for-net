// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ReadOnlyMemoryStreamTests
    {
        [Test]
        public async Task CanRead()
        {
            var buffer = Encoding.UTF8.GetBytes("some data");
            var stream = new ReadOnlyMemoryStream(buffer);

            var read = new byte[buffer.Length];
            stream.Read(read, 0, buffer.Length);
            Assert.AreEqual(buffer, read);

            read = new byte[buffer.Length];
            stream.Position = 0;
            await stream.ReadAsync(read, 0, buffer.Length);
            Assert.AreEqual(buffer, read);
        }

        [Test]
        public async Task CanSeek()
        {
            var buffer = Encoding.UTF8.GetBytes("some data");
            var stream = new ReadOnlyMemoryStream(buffer);

            stream.Seek(5, SeekOrigin.Begin);
            Assert.AreEqual(buffer[5], stream.ReadByte());
            stream.Seek(1, SeekOrigin.Current);
            Assert.AreEqual(buffer[7], stream.ReadByte());
            stream.Seek(-2, SeekOrigin.End);
            Assert.AreEqual(buffer.Length - 2, stream.Position);
            Assert.AreEqual(buffer[buffer.Length - 2], stream.ReadByte());
            stream.Seek(-2, SeekOrigin.End);
            var read = new byte[buffer.Length - stream.Position];
            await stream.ReadAsync(read, 0, read.Length);
            Assert.AreEqual(
                new ReadOnlyMemory<byte>(buffer, buffer.Length - 2, 2).ToArray(),
                read);
        }

        [Test]
        public async Task ValidatesReadArguments()
        {
            var buffer = Encoding.UTF8.GetBytes("some data");
            var stream = new ReadOnlyMemoryStream(buffer);
            stream.Seek(3, SeekOrigin.Begin);
            var read = new byte[buffer.Length - stream.Position];
            Assert.That(
               async () => await stream.ReadAsync(read, 0, buffer.Length),
               Throws.InstanceOf<ArgumentException>());
            Assert.That(
               async () => await stream.ReadAsync(null, 0, buffer.Length),
               Throws.InstanceOf<ArgumentException>());
            Assert.That(
               async () => await stream.ReadAsync(read, -1, read.Length),
               Throws.InstanceOf<ArgumentException>());
            Assert.That(
               async () => await stream.ReadAsync(read, 0, -1),
               Throws.InstanceOf<ArgumentException>());
            await stream.ReadAsync(read, 0, read.Length);
            Assert.AreEqual(
                new ReadOnlyMemory<byte>(buffer, 3, buffer.Length - 3).ToArray(),
                read);
        }

        [Test]
        public void ValidatesPositionValue()
        {
            var buffer = Encoding.UTF8.GetBytes("some data");
            var stream = new ReadOnlyMemoryStream(buffer);
            Assert.That(
                () => stream.Position = -1,
                Throws.InstanceOf<ArgumentException>());
            Assert.That(
                () => stream.Position = (long)int.MaxValue + 1,
                Throws.InstanceOf<ArgumentException>());
        }
    }
}
