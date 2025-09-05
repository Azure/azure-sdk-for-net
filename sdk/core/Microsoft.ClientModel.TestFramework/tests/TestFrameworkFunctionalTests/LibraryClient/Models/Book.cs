// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Microsoft.ClientModel.TestFramework.Tests.LibraryClient;

public class Book : IJsonModel<Book>
{
    public string Author { get; set; }

    public string Title { get; set; }

    public string Summary { get; set; }

    public Book()
    {
        Author = "No author";
        Title = "No title";
        Summary = "No summary";
    }

    public Book(string title, string author, string summary)
    {
        Author = author;
        Title = title;
        Summary = summary;
    }

    internal static Book FromJson(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Book)}'");
        }

        string author = default;
        string title = default;
        string yearPublished = default;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("author"u8))
            {
                author = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("title"u8))
            {
                title = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("summary"u8))
            {
                yearPublished = property.Value.GetString();
                continue;
            }
        }

        if (author is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Book)}': Missing 'author' property");
        }
        if (title is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Book)}': Missing 'title' property");
        }
        if (yearPublished is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Book)}': Missing 'summary' property");
        }

        return new Book(title, author, yearPublished);
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    public Book Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return FromJson(document.RootElement);
    }

    public Book Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data.ToString());
        return FromJson(document.RootElement);
    }

    public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("author"u8, Author);
        writer.WriteString("title"u8, Title);
        writer.WriteString("summary"u8, Summary);
        writer.WriteEndObject();
        writer.Flush();
    }

    public BinaryData Write(ModelReaderWriterOptions options)
    {
        return new BinaryData(JsonSerializer.SerializeToUtf8Bytes(this));
    }

    internal static Book FromResponse(PipelineResponse response)
    {
        using JsonDocument document = JsonDocument.Parse(response.Content);
        return FromJson(document.RootElement);
    }
}
