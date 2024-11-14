// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Binary;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Shared;
using Azure.Storage.Test.Shared;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Tests;

[TestFixture(true)]
[TestFixture(false)]
public class StructuredMessageDecodingRetriableStreamTests
{
    public bool Async { get; }

    public StructuredMessageDecodingRetriableStreamTests(bool async)
    {
        Async = async;
    }

    private Mock<ResponseClassifier> AllExceptionsRetry()
    {
        Mock<ResponseClassifier> mock = new(MockBehavior.Strict);
        mock.Setup(rc => rc.IsRetriableException(It.IsAny<Exception>())).Returns(true);
        return mock;
    }

    [Test]
    public async ValueTask UninterruptedStream()
    {
        byte[] data = new Random().NextBytesInline(4 * Constants.KB).ToArray();
        byte[] dest = new byte[data.Length];

        // mock with a simple MemoryStream rather than an actual StructuredMessageDecodingStream
        using (Stream src = new MemoryStream(data))
        using (Stream retriableSrc = new StructuredMessageDecodingRetriableStream(src, new(), default, default, default, default, default, 1))
        using (Stream dst = new MemoryStream(dest))
        {
            await retriableSrc.CopyToInternal(dst, Async, default);
        }

        Assert.AreEqual(data, dest);
    }

    [Test]
    public async Task Interrupt_DataIntact([Values(true, false)] bool multipleInterrupts)
    {
        const int segments = 4;
        const int segmentLen = Constants.KB;
        const int readLen = 128;
        const int interruptPos = segmentLen + (3 * readLen) + 10;

        Random r = new();
        byte[] data = r.NextBytesInline(segments * Constants.KB).ToArray();
        byte[] dest = new byte[data.Length];

        // Mock a decoded data for the mocked StructuredMessageDecodingStream
        StructuredMessageDecodingStream.RawDecodedData initialDecodedData = new()
        {
            TotalSegments = segments,
            InnerStreamLength = data.Length,
            Flags = StructuredMessage.Flags.StorageCrc64
        };
        // for test purposes, initialize a DecodedData, since we are not actively decoding in this test
        initialDecodedData.SegmentCrcs.Add((BinaryPrimitives.ReadUInt64LittleEndian(r.NextBytesInline(StructuredMessage.Crc64Length)), segmentLen));

        (Stream DecodingStream, StructuredMessageDecodingStream.RawDecodedData DecodedData) Factory(long offset, bool faulty)
        {
            Stream stream = new MemoryStream(data, (int)offset, data.Length - (int)offset);
            if (faulty)
            {
                stream = new FaultyStream(stream, interruptPos, 1, new Exception(), () => { });
            }
            // Mock a decoded data for the mocked StructuredMessageDecodingStream
            StructuredMessageDecodingStream.RawDecodedData decodedData = new()
            {
                TotalSegments = segments,
                InnerStreamLength = data.Length,
                Flags = StructuredMessage.Flags.StorageCrc64,
            };
            // for test purposes, initialize a DecodedData, since we are not actively decoding in this test
            initialDecodedData.SegmentCrcs.Add((BinaryPrimitives.ReadUInt64LittleEndian(r.NextBytesInline(StructuredMessage.Crc64Length)), segmentLen));
            return (stream, decodedData);
        }

        // mock with a simple MemoryStream rather than an actual StructuredMessageDecodingStream
        using (Stream src = new MemoryStream(data))
        using (Stream faultySrc = new FaultyStream(src, interruptPos, 1, new Exception(), () => { }))
        using (Stream retriableSrc = new StructuredMessageDecodingRetriableStream(
            faultySrc,
            initialDecodedData,
            default,
            offset => Factory(offset, multipleInterrupts),
            offset => new ValueTask<(Stream DecodingStream, StructuredMessageDecodingStream.RawDecodedData DecodedData)>(Factory(offset, multipleInterrupts)),
            null,
            AllExceptionsRetry().Object,
            int.MaxValue))
        using (Stream dst = new MemoryStream(dest))
        {
            await retriableSrc.CopyToInternal(dst, readLen, Async, default);
        }

        Assert.AreEqual(data, dest);
    }

    [Test]
    public async Task Interrupt_AppropriateRewind()
    {
        const int segments = 2;
        const int segmentLen = Constants.KB;
        const int dataLen = segments * segmentLen;
        const int readLen = segmentLen / 4;
        const int interruptOffset = 10;
        const int interruptPos = segmentLen + (2 * readLen) + interruptOffset;
        Random r = new();

        // Mock a decoded data for the mocked StructuredMessageDecodingStream
        StructuredMessageDecodingStream.RawDecodedData initialDecodedData = new()
        {
            TotalSegments = segments,
            InnerStreamLength = segments * segmentLen,
            Flags = StructuredMessage.Flags.StorageCrc64,
        };
        // By the time of interrupt, there will be one segment reported
        initialDecodedData.SegmentCrcs.Add((BinaryPrimitives.ReadUInt64LittleEndian(r.NextBytesInline(StructuredMessage.Crc64Length)), segmentLen));

        Mock<Stream> mock = new(MockBehavior.Strict);
        mock.SetupGet(s => s.CanRead).Returns(true);
        mock.SetupGet(s => s.CanSeek).Returns(false);
        if (Async)
        {
            mock.SetupSequence(s => s.ReadAsync(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(), default))
                .Returns(Task.FromResult(readLen)) // start first segment
                .Returns(Task.FromResult(readLen))
                .Returns(Task.FromResult(readLen))
                .Returns(Task.FromResult(readLen)) // finish first segment
                .Returns(Task.FromResult(readLen)) // start second segment
                .Returns(Task.FromResult(readLen))
                // faulty stream interrupt
                .Returns(Task.FromResult(readLen * 2)) // restart second segment. fast-forward uses an internal 4KB buffer, so it will leap the 512 byte catchup all at once
                .Returns(Task.FromResult(readLen))
                .Returns(Task.FromResult(readLen)) // end second segment
                .Returns(Task.FromResult(0)) // signal end of stream
                .Returns(Task.FromResult(0)) // second signal needed for stream wrapping reasons
                ;
        }
        else
        {
            mock.SetupSequence(s => s.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(readLen) // start first segment
                .Returns(readLen)
                .Returns(readLen)
                .Returns(readLen) // finish first segment
                .Returns(readLen) // start second segment
                .Returns(readLen)
                // faulty stream interrupt
                .Returns(readLen * 2) // restart second segment. fast-forward uses an internal 4KB buffer, so it will leap the 512 byte catchup all at once
                .Returns(readLen)
                .Returns(readLen) // end second segment
                .Returns(0) // signal end of stream
                .Returns(0) // second signal needed for stream wrapping reasons
                ;
        }
        Stream faultySrc = new FaultyStream(mock.Object, interruptPos, 1, new Exception(), default);
        Stream retriableSrc = new StructuredMessageDecodingRetriableStream(
            faultySrc,
            initialDecodedData,
            default,
            offset => (mock.Object, new()),
            offset => new(Task.FromResult((mock.Object, new StructuredMessageDecodingStream.RawDecodedData()))),
            null,
            AllExceptionsRetry().Object,
            1);

        int totalRead = 0;
        int read = 0;
        byte[] buf = new byte[readLen];
        if (Async)
        {
            while ((read = await retriableSrc.ReadAsync(buf, 0, buf.Length)) > 0)
            {
                totalRead += read;
            }
        }
        else
        {
            while ((read = retriableSrc.Read(buf, 0, buf.Length)) > 0)
            {
                totalRead += read;
            }
        }
        await retriableSrc.CopyToInternal(Stream.Null, readLen, Async, default);

        // Asserts we read exactly the data length, excluding the fastforward of the inner stream
        Assert.That(totalRead, Is.EqualTo(dataLen));
    }

    [Test]
    public async Task Interrupt_ProperDecode([Values(true, false)] bool multipleInterrupts)
    {
        // decoding stream inserts a buffered layer of 4 KB. use larger sizes to avoid interference from it.
        const int segments = 4;
        const int segmentLen = 128 * Constants.KB;
        const int readLen = 8 * Constants.KB;
        const int interruptPos = segmentLen + (3 * readLen) + 10;

        Random r = new();
        byte[] data = r.NextBytesInline(segments * Constants.KB).ToArray();
        byte[] dest = new byte[data.Length];

        (Stream DecodingStream, StructuredMessageDecodingStream.RawDecodedData DecodedData) Factory(long offset, bool faulty)
        {
            Stream stream = new MemoryStream(data, (int)offset, data.Length - (int)offset);
            stream = new StructuredMessageEncodingStream(stream, segmentLen, StructuredMessage.Flags.StorageCrc64);
            if (faulty)
            {
                stream  = new FaultyStream(stream, interruptPos, 1, new Exception(), () => { });
            }
            return StructuredMessageDecodingStream.WrapStream(stream);
        }

        (Stream decodingStream, StructuredMessageDecodingStream.RawDecodedData decodedData) = Factory(0, true);
        using Stream retriableSrc = new StructuredMessageDecodingRetriableStream(
            decodingStream,
            decodedData,
            default,
            offset => Factory(offset, multipleInterrupts),
            offset => new ValueTask<(Stream DecodingStream, StructuredMessageDecodingStream.RawDecodedData DecodedData)>(Factory(offset, multipleInterrupts)),
            null,
            AllExceptionsRetry().Object,
            int.MaxValue);
        using Stream dst = new MemoryStream(dest);

        await retriableSrc.CopyToInternal(dst, readLen, Async, default);

        Assert.AreEqual(data, dest);
    }
}
