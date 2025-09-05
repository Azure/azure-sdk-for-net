// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Microsoft.ClientModel.TestFramework.Tests.LibraryClient;

internal class BookFileContent : IJsonModel<BookFileContent>
{
    public string FileId { get; }
    public int Size { get; }

    public BookFileContent()
    {
        FileId = "no-file-id";
        Size = 0;
    }

    public BookFileContent(string fileId, int size)
    {
        FileId = fileId;
        Size = size;
    }

    internal static BookFileContent FromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(BookFileContent)}'");
        }

        string fileId = default;
        int? size = default;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("file_id"u8))
            {
                fileId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("size"u8))
            {
                size = property.Value.GetInt32();
                continue;
            }
        }

        if (fileId is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(BookFileContent)}': Missing 'file_id' property");
        }
        if (size is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(BookFileContent)}': Missing 'size' property");
        }

        return new BookFileContent(fileId, size.Value);
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    public BookFileContent Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return FromJson(document.RootElement);
    }

    public BookFileContent Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data.ToString());
        return FromJson(document.RootElement);
    }

    public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("file_id"u8, FileId);
        writer.WriteNumber("size"u8, Size);
        writer.WriteEndObject();
        writer.Flush();
    }

    public BinaryData Write(ModelReaderWriterOptions options)
    {
        return new BinaryData(JsonSerializer.SerializeToUtf8Bytes(this));
    }

    internal static BookFileContent FromResponse(PipelineResponse response)
    {
        using JsonDocument document = JsonDocument.Parse(response.Content);
        return FromJson(document.RootElement);
    }
}
