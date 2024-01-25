// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Message;

internal class BinaryContentTests : SyncAsyncTestBase
{
    public BinaryContentTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void CanGetLengthFromBinaryDataBinaryContent()
    {
        string value = "01234";
        BinaryData data = BinaryData.FromString(value);
        using BinaryContent content = BinaryContent.Create(data);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(value.Length, length);
    }

    [Test]
    public async Task CanWriteToStreamFromBinaryDataBinaryContent()
    {
        byte[] bytes = new byte[] { 0, 1, 2, 3, 4 };
        BinaryData data = BinaryData.FromBytes(bytes);
        using BinaryContent content = BinaryContent.Create(data);

        MemoryStream stream = new MemoryStream();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        Assert.AreEqual(bytes.Length, stream.Position);
        Assert.AreEqual(bytes, stream.ToArray());
    }

    [Test]
    public void CanGetLengthFromModelBinaryContent()
    {
        MockPersistableModel model = new MockPersistableModel(404, "abcde");
        using BinaryContent content = BinaryContent.Create(model);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(model.SerializedValue.Length, length);
    }

    [Test]
    public async Task CanWriteToStreamFromModelBinaryContent()
    {
        MockPersistableModel model = new MockPersistableModel(404, "abcde");
        using BinaryContent content = BinaryContent.Create(model);

        MemoryStream stream = new MemoryStream();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        Assert.AreEqual(model.SerializedValue.Length, stream.Position);

        BinaryData serializedContent = ((IPersistableModel<object>)model).Write(ModelReaderWriterOptions.Json);
        Assert.AreEqual(serializedContent.ToArray(), stream.ToArray());
    }

    [Test]
    public void CanGetLengthFromJsonModelBinaryContent()
    {
        MockJsonModel model = new MockJsonModel(404, "abcde");
        using BinaryContent content = BinaryContent.Create(model, ModelReaderWriterOptions.Json);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(model.Utf8BytesValue.Length, length);
    }

    [Test]
    public async Task CanWriteToStreamFromJsonModelBinaryContent()
    {
        MockJsonModel model = new MockJsonModel(404, "abcde");
        using BinaryContent content = BinaryContent.Create(model, ModelReaderWriterOptions.Json);

        MemoryStream contentStream = new MemoryStream();
        await content.WriteToSyncOrAsync(contentStream, CancellationToken.None, IsAsync);

        Assert.AreEqual(model.Utf8BytesValue.Length, contentStream.Position);

        MemoryStream modelStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(modelStream);

        ((IJsonModel<object>)model).Write(writer, ModelReaderWriterOptions.Json);
        writer.Flush();

        Assert.AreEqual(model.Utf8BytesValue, contentStream.ToArray());
    }
}
