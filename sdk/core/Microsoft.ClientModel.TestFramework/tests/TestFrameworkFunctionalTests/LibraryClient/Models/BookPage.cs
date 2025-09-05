// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Microsoft.ClientModel.TestFramework.Tests.LibraryClient;

public class BookPage : IJsonModel<BookPage>
{
    public IReadOnlyList<Book> Books { get; }
    public string? NextToken { get; }
    public bool HasMore { get; }

    public BookPage()
    {
        Books = Array.Empty<Book>();
        NextToken = null;
        HasMore = false;
    }

    public BookPage(IReadOnlyList<Book> books, string? nextToken, bool hasMore)
    {
        Books = books ?? Array.Empty<Book>();
        NextToken = nextToken;
        HasMore = hasMore;
    }

    internal static BookPage FromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(BookPage)}'");
        }

        List<Book> books = new();
        string? nextToken = null;
        bool? hasMore = null;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("data"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement bookElement in property.Value.EnumerateArray())
                    {
                        books.Add(Book.FromJson(bookElement));
                    }
                }
                continue;
            }
            if (property.NameEquals("next_token"u8))
            {
                nextToken = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("has_more"u8))
            {
                hasMore = property.Value.GetBoolean();
                continue;
            }
        }

        if (hasMore is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(BookPage)}': Missing 'has_more' property");
        }

        return new BookPage(books, nextToken, hasMore.Value);
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    public BookPage Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return FromJson(document.RootElement);
    }

    public BookPage Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data.ToString());
        return FromJson(document.RootElement);
    }

    public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        
        writer.WriteStartArray("data"u8);
        foreach (Book book in Books)
        {
            book.Write(writer, options);
        }
        writer.WriteEndArray();

        if (NextToken != null)
        {
            writer.WriteString("next_token"u8, NextToken);
        }
        else
        {
            writer.WriteNull("next_token"u8);
        }

        writer.WriteBoolean("has_more"u8, HasMore);
        writer.WriteEndObject();
        writer.Flush();
    }

    public BinaryData Write(ModelReaderWriterOptions options)
    {
        return new BinaryData(JsonSerializer.SerializeToUtf8Bytes(this));
    }

    internal static BookPage FromResponse(PipelineResponse response)
    {
        using JsonDocument document = JsonDocument.Parse(response.Content);
        return FromJson(document.RootElement);
    }
}
