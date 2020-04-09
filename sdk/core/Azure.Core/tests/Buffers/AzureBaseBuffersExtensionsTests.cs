// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Buffers;
using Azure.Core.Tests.Buffers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Azure;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Core.Tests.Buffers
{
    public class AzureBaseBuffersExtensionsTests
    {
        [Test]
        public async Task WriteArray()
        {
            using MemoryStream ms = new MemoryStream();

            // Create a simple buffer
            ReadOnlyMemory<byte> buffer = new byte[] { 0, 1, 2 };
            await AzureBaseBuffersExtensions.WriteAsync(ms, buffer);

            CheckMemoryStreamContent(ms);
        }

        [Test]
        public async Task WriteEmptyArray()
        {
            using MemoryStream ms = new MemoryStream();

            // Create a simple buffer
            ReadOnlyMemory<byte> buffer = new byte[0];
            await AzureBaseBuffersExtensions.WriteAsync(ms, buffer);

            Assert.AreEqual(0, ms.Length);
        }

        [Test]
        public async Task WriteArraySequence()
        {
            using MemoryStream ms = new MemoryStream();

            Memory<byte> totalMemory = new byte[32];

            ReadOnlySequence<byte> sequence = CreateSequenceFromMemory(new byte[32]);
            await AzureBaseBuffersExtensions.WriteAsync(ms, sequence);

            CheckMemoryStreamContent(ms);
        }

        [Test]
        public async Task WriteEmptyArraySequence()
        {
            using MemoryStream ms = new MemoryStream();

            // Create a sequence with an empty buffer
            ReadOnlySequence<byte> buffer = new ReadOnlySequence<byte>(new byte[0]);
            await AzureBaseBuffersExtensions.WriteAsync(ms, buffer);

            // Check that nothing was written
            Assert.AreEqual(0, ms.Length);
        }

        [Test]
        public async Task WriteNativeMemory()
        {
            using NativeMemoryManager totalNativeMemory = new NativeMemoryManager(10);
            using MemoryStream ms = new MemoryStream();

            Memory<byte> totalMemory = totalNativeMemory.Memory;
            Memory<byte> sourceMemory = totalMemory.Slice(3, 5);
            for (byte i = 0; i < sourceMemory.Length; i++)
            {
                sourceMemory.Span[i] = i;
            }

            await AzureBaseBuffersExtensions.WriteAsync(ms, sourceMemory);

            CheckMemoryStreamContent(ms);
        }

        [Test]
        public async Task WriteNativeMemorySequence()
        {
            using NativeMemoryManager totalNativeMemory = new NativeMemoryManager(32);
            using MemoryStream ms = new MemoryStream();

            ReadOnlySequence<byte> sequence = CreateSequenceFromMemory(totalNativeMemory.Memory);

            await AzureBaseBuffersExtensions.WriteAsync(ms, sequence);

            CheckMemoryStreamContent(ms);
        }

        private static void CheckMemoryStreamContent(MemoryStream ms)
        {
            ms.Seek(0, SeekOrigin.Begin);
            for (byte i = 0; i < ms.Length; i++)
            {
                Assert.AreEqual(i, ms.ReadByte());
            }
        }

        private static ReadOnlySequence<byte> CreateSequenceFromMemory(Memory<byte> totalMemory)
        {
            // populate the memory with some data.
            for (byte i = 0; i < totalMemory.Length; i++)
            {
                totalMemory.Span[i] = i;
            }

            // create the individual segments
            BufferSegment start = new BufferSegment(totalMemory.Slice(0, 2));
            BufferSegment last = start.Append(totalMemory.Slice(2, 2))
                .Append(totalMemory.Slice(4, 17)) // this should be larger than the default size of the array rented from the pool up to that point
                .Append(totalMemory.Slice(21, 2));

            // create the sequence
            return new ReadOnlySequence<byte>(start, 0, last, 2); // the last segment has length 2
        }
    }
}
