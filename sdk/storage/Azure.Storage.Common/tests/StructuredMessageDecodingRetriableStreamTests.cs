// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Shared;
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

    [Test]
    public async ValueTask UninterruptedStream()
    {
        byte[] data = new Random().NextBytesInline(4 * Constants.KB).ToArray();
        byte[] dest = new byte[data.Length];

        using (Stream src = new MemoryStream(data))
        using (Stream dst = new MemoryStream(dest))
        using (StructuredMessageDecodingRetriableStream retriable = new(
            src,
            offset => (new MemoryStream(data, (int)offset, data.Length - (int)offset), new StructuredMessageDecodingStream.DecodedData()),
            offset => new(Task.FromResult(((Stream)new MemoryStream(data, (int)offset, data.Length - (int)offset), new StructuredMessageDecodingStream.DecodedData()))),
            null,
            5))
        {
            await retriable.CopyToInternal(dst, Async, default);
        }

        Assert.AreEqual(data, dest);
    }
}
