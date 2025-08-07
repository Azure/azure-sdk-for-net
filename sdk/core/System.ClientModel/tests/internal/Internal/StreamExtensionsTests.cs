// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Buffers;
using System.ClientModel.Internal;
using System.IO;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Internal;

public class StreamExtensionsTests
{
    [Test]
    public async Task WriteArray()
    {
        using MemoryStream ms = new MemoryStream();

        // Create a simple buffer
        ReadOnlyMemory<byte> buffer = new byte[] { 0, 1, 2 };
        await StreamExtensions.WriteAsync(ms, buffer);

        CheckMemoryStreamContent(ms);
    }

    [Test]
    public async Task WriteEmptyArray()
    {
        using MemoryStream ms = new MemoryStream();

        // Create a simple buffer
        ReadOnlyMemory<byte> buffer = new byte[0];
        await StreamExtensions.WriteAsync(ms, buffer);

        Assert.AreEqual(0, ms.Length);
    }

    [Test]
    public async Task WriteArraySequence()
    {
        using MemoryStream ms = new MemoryStream();

        Memory<byte> totalMemory = new byte[32];

        ReadOnlySequence<byte> sequence = CreateSequenceFromMemory(new byte[32]);
        await StreamExtensions.WriteAsync(ms, sequence);

        CheckMemoryStreamContent(ms);
    }

    [Test]
    public async Task WriteEmptyArraySequence()
    {
        using MemoryStream ms = new MemoryStream();

        // Create a sequence with an empty buffer
        ReadOnlySequence<byte> buffer = new ReadOnlySequence<byte>(new byte[0]);
        await StreamExtensions.WriteAsync(ms, buffer);

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

        await StreamExtensions.WriteAsync(ms, sourceMemory);

        CheckMemoryStreamContent(ms);
    }

    [Test]
    public async Task WriteNativeMemorySequence()
    {
        using NativeMemoryManager totalNativeMemory = new NativeMemoryManager(32);
        using MemoryStream ms = new MemoryStream();

        ReadOnlySequence<byte> sequence = CreateSequenceFromMemory(totalNativeMemory.Memory);

        await StreamExtensions.WriteAsync(ms, sequence);

        CheckMemoryStreamContent(ms);
    }

    [Test]
    public async Task WriteNativeMemorySequenceEmptySequenceAndLargeSegment()
    {
        using NativeMemoryManager totalNativeMemory = new NativeMemoryManager(32);
        using MemoryStream ms = new MemoryStream();

        // Put some data in memory
        PopulateMemoryWithData(totalNativeMemory.Memory);

        // create the individual segments
        BufferSegment start = new BufferSegment(totalNativeMemory.Memory.Slice(0, 0)); // have an empty start segment
        BufferSegment last = start.Append(totalNativeMemory.Memory.Slice(0, 23)); // have a segment the size of the actual buffer
        ReadOnlySequence<byte> sequence = new ReadOnlySequence<byte>(start, 0, last, 23);

        await StreamExtensions.WriteAsync(ms, sequence);

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
        PopulateMemoryWithData(totalMemory);

        // create the individual segments
        BufferSegment start = new BufferSegment(totalMemory.Slice(0, 2));
        BufferSegment last = start.Append(totalMemory.Slice(2, 2))
            .Append(totalMemory.Slice(4, 17)) // this should be larger than the default size of the array rented from the pool up to that point
            .Append(totalMemory.Slice(21, 2));

        // create the sequence
        return new ReadOnlySequence<byte>(start, 0, last, 2); // the last segment has length 2
    }

    private static void PopulateMemoryWithData(Memory<byte> totalMemory)
    {
        // populate the memory with some data.
        for (byte i = 0; i < totalMemory.Length; i++)
        {
            totalMemory.Span[i] = i;
        }
    }
}
