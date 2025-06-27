// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

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

        Assert.IsNull(content.MediaType);
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

        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(model.SerializedValue.Length, length);
    }

    [Test]
    public async Task CanWriteToStreamFromModelBinaryContent()
    {
        MockPersistableModel model = new MockPersistableModel(404, "abcde");
        using BinaryContent content = BinaryContent.Create(model);

        Assert.AreEqual("application/json", content.MediaType);

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

        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(model.Utf8BytesValue.Length, length);
    }

    [Test]
    public async Task CanWriteToStreamFromJsonModelBinaryContent()
    {
        MockJsonModel model = new MockJsonModel(404, "abcde");
        using BinaryContent content = BinaryContent.Create(model, ModelReaderWriterOptions.Json);

        Assert.AreEqual("application/json", content.MediaType);

        MemoryStream contentStream = new MemoryStream();
        await content.WriteToSyncOrAsync(contentStream, CancellationToken.None, IsAsync);

        Assert.AreEqual(model.Utf8BytesValue.Length, contentStream.Position);

        MemoryStream modelStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(modelStream);

        ((IJsonModel<object>)model).Write(writer, ModelReaderWriterOptions.Json);
        writer.Flush();

        Assert.AreEqual(model.Utf8BytesValue, contentStream.ToArray());
    }

    [Test]
    public void CanGetLengthFromStreamBinaryContent()
    {
        int size = 100;
        byte[] sourceArray = new byte[size];
        new Random(100).NextBytes(sourceArray);

        MemoryStream stream = new(sourceArray);

        using BinaryContent content = BinaryContent.Create(stream);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(size, length);
    }

    [Test]
    public async Task CanWriteToStreamFromStreamBinaryContent()
    {
        int size = 100;

        byte[] sourceArray = new byte[size];
        new Random(100).NextBytes(sourceArray);
        MemoryStream source = new(sourceArray);

        byte[] destinationArray = new byte[size * 2];
        MemoryStream destination = new(destinationArray);

        using BinaryContent content = BinaryContent.Create(source);

        await content.WriteToSyncOrAsync(destination, CancellationToken.None, IsAsync);

        Assert.AreEqual(size, destination.Position);

        Assert.AreEqual(source.ToArray(), destination.ToArray().AsSpan().Slice(0, size).ToArray());
    }

    [Test]
    public void StreamBinaryContentWriteToCanBeCancelled()
    {
        int size = 100;
        MemoryStream source = new(size);
        MemoryStream destination = new(size);

        BinaryContent content = BinaryContent.Create(source);
        CancellationTokenSource cts = new();
        cts.Cancel();

        Assert.Throws<OperationCanceledException>(() => { content.WriteTo(destination, cts.Token); });
    }

    [Test]
    public void StreamBinaryContentMustBeSeekable()
    {
        NonSeekableMemoryStream stream = new();

        Assert.Throws<ArgumentException>(() => { BinaryContent.Create(stream); });
    }

    [Test]
    public async Task CanCreateAndWriteJsonBinaryContentFromObject()
    {
        var testObject = new { Name = "test", Value = 42 };
        using BinaryContent content = BinaryContent.CreateJson(testObject);

        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.Greater(length, 0);

        MemoryStream stream = new MemoryStream();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        string json = System.Text.Encoding.UTF8.GetString(stream.ToArray());
        Assert.IsTrue(json.Contains("test"));
        Assert.IsTrue(json.Contains("42"));
    }

    [Test]
    public async Task CanCreateAndWriteJsonBinaryContentWithOptions()
    {
        var testObject = new { Name = "TEST", Value = 42 };
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        using BinaryContent content = BinaryContent.CreateJson(testObject, options);

        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.Greater(length, 0);

        MemoryStream stream = new MemoryStream();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        string json = System.Text.Encoding.UTF8.GetString(stream.ToArray());
        // With camelCase naming policy, "Name" should become "name"
        Assert.IsTrue(json.Contains("name"));
        Assert.IsTrue(json.Contains("value"));
    }

    [Test]
    public void JsonBinaryContentMatchesBinaryDataFromObjectAsJson()
    {
        var testObject = new { Name = "test", Value = 42 };

        // Create using the new CreateJson method
        using BinaryContent content = BinaryContent.CreateJson(testObject);

        // Create using the existing pattern
        BinaryData binaryData = BinaryData.FromObjectAsJson(testObject);
        using BinaryContent expectedContent = BinaryContent.Create(binaryData);

        // They should have the same length
        Assert.IsTrue(content.TryComputeLength(out long contentLength));
        Assert.IsTrue(expectedContent.TryComputeLength(out long expectedLength));
        Assert.AreEqual(expectedLength, contentLength);
    }

    [Test]
    public async Task CanCreateAndWriteJsonBinaryContentFromString()
    {
        string jsonString = """{"name":"test","value":42}""";
        using BinaryContent content = BinaryContent.CreateJson(jsonString);

        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(jsonString.Length, length);

        MemoryStream stream = new MemoryStream();
        await content.WriteToSyncOrAsync(stream, CancellationToken.None, IsAsync);

        string result = System.Text.Encoding.UTF8.GetString(stream.ToArray());
        Assert.AreEqual(jsonString, result);
    }

    [Test]
    public void JsonStringBinaryContentMatchesBinaryDataFromString()
    {
        string jsonString = """{"name":"test","value":42}""";

        // Create using the new CreateJson string method
        using BinaryContent content = BinaryContent.CreateJson(jsonString);

        // Create using the existing pattern
        BinaryData binaryData = BinaryData.FromString(jsonString);
        using BinaryContent expectedContent = BinaryContent.Create(binaryData);

        // They should have the same length
        Assert.IsTrue(content.TryComputeLength(out long contentLength));
        Assert.IsTrue(expectedContent.TryComputeLength(out long expectedLength));
        Assert.AreEqual(expectedLength, contentLength);

        // Content should have JSON media type, while regular Create should not
        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsNull(expectedContent.MediaType);
    }

    [Test]
    public void CreateJsonWithValidationSucceedsForValidJson()
    {
        string validJson = """{"name":"test","value":42,"nested":{"array":[1,2,3]}}""";
        using BinaryContent content = BinaryContent.CreateJson(validJson, validate: true);

        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(validJson.Length, length);
    }

    [Test]
    public void CreateJsonWithValidationThrowsForInvalidJson()
    {
        string invalidJson = """{"name":"test","value":42"""; // Missing closing brace

        var ex = Assert.Throws<ArgumentException>(() => BinaryContent.CreateJson(invalidJson, validate: true));
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Assert.AreEqual("jsonString", ex.ParamName);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        Assert.IsTrue(ex.Message.Contains("not valid JSON"));
    }

    [Test]
    public void CreateJsonWithoutValidationSucceedsForInvalidJson()
    {
        string invalidJson = """{"name":"test","value":42"""; // Missing closing brace

        // Should not throw when validation is disabled (default behavior)
        using BinaryContent content = BinaryContent.CreateJson(invalidJson, validate: false);
        Assert.AreEqual("application/json", content.MediaType);

        // Should also not throw when validation parameter is omitted
        using BinaryContent content2 = BinaryContent.CreateJson(invalidJson);
        Assert.AreEqual("application/json", content2.MediaType);
    }

    [Test]
    public void CreateJsonWithValidationHandlesEmptyObject()
    {
        string emptyObject = "{}";
        using BinaryContent content = BinaryContent.CreateJson(emptyObject, validate: true);

        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(2, length);
    }

    [Test]
    public void CreateJsonWithValidationHandlesEmptyArray()
    {
        string emptyArray = "[]";
        using BinaryContent content = BinaryContent.CreateJson(emptyArray, validate: true);

        Assert.AreEqual("application/json", content.MediaType);
        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(2, length);
    }

    [Test]
    public void CreateJsonWithValidationThrowsForMalformedJson()
    {
        string[] malformedJsonStrings = new[]
        {
            "{",
            "}",
            "[",
            "]",
            "{\"key\":}",
            "{\"key\"",
            "\"unterminated string",
            "{\"key\": value}",  // unquoted value
            "{key: \"value\"}",  // unquoted key
        };

        foreach (string malformedJson in malformedJsonStrings)
        {
            Assert.Throws<ArgumentException>(() => BinaryContent.CreateJson(malformedJson, validate: true),
                $"Expected validation to fail for: {malformedJson}");
        }
    }
}
