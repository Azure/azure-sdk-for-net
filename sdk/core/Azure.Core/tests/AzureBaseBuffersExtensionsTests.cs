// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Buffers;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AzureBaseBuffersExtensionsTests
    {
        [Test]
        public async Task WriteBufferToStream()
        {
            using MemoryStream ms = new MemoryStream();

            // Create a simple buffer
            ReadOnlyMemory<byte> buffer = new byte[] { 1, 2, 3 };
            await AzureBaseBuffersExtensions.WriteAsync(ms, buffer);

            ms.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(1, ms.ReadByte());
            Assert.AreEqual(2, ms.ReadByte());
            Assert.AreEqual(3, ms.ReadByte());
        }

        [Test]
        public async Task WriteEmptyBuffer()
        {
            using MemoryStream ms = new MemoryStream();

            // Create a simple buffer
            ReadOnlyMemory<byte> buffer = new byte[0];
            await AzureBaseBuffersExtensions.WriteAsync(ms, buffer);

            Assert.AreEqual(0, ms.Length);
        }

        [Test]
        public async Task WriteBufferSequence()
        {
            using MemoryStream ms = new MemoryStream();

            // Create a simple buffer
            ReadOnlySequence<byte> buffer = new  ReadOnlySequence<byte>(new byte[] { 1, 2, 3 });
            await AzureBaseBuffersExtensions.WriteAsync(ms, buffer);

            ms.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(1, ms.ReadByte());
            Assert.AreEqual(2, ms.ReadByte());
            Assert.AreEqual(3, ms.ReadByte());
        }


        [Test]
        public async Task WriteEmptySequence()
        {
            using MemoryStream ms = new MemoryStream();

            // Create a simple buffer
            ReadOnlySequence<byte> buffer = new ReadOnlySequence<byte>(new byte[0]);
            await AzureBaseBuffersExtensions.WriteAsync(ms, buffer);

            Assert.AreEqual(0, ms.Length);
        }

    }
}
