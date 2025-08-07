// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ClientModel.Tests.Collections;

internal class ValueCollectionPageToken : ContinuationToken
{
    protected ValueCollectionPageToken(int? pageSize, int? offset)
    {
        PageSize = pageSize;
        Offset = offset;
    }

    public int? PageSize { get; }

    public int? Offset { get; }

    public override BinaryData ToBytes()
    {
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        writer.WriteStartObject();

        if (PageSize.HasValue)
        {
            writer.WriteNumber("pageSize", PageSize.Value);
        }

        if (Offset.HasValue)
        {
            writer.WriteNumber("offset", Offset.Value);
        }

        writer.WriteEndObject();

        writer.Flush();
        stream.Position = 0;

        return BinaryData.FromStream(stream);
    }

    public ValueCollectionPageToken? GetNextPageToken(int offset, int count)
    {
        if (offset >= count)
        {
            return null;
        }

        return new ValueCollectionPageToken(PageSize, offset);
    }

    public static ValueCollectionPageToken FromToken(ContinuationToken pageToken)
    {
        if (pageToken is ValueCollectionPageToken token)
        {
            return token;
        }

        BinaryData data = pageToken.ToBytes();

        if (data.ToMemory().Length == 0)
        {
            throw new ArgumentException("Failed to create ValueCollectionPageToken from provided pageToken.", nameof(pageToken));
        }

        Utf8JsonReader reader = new(data);

        int? pageSize = null;
        int? offset = null;

        reader.Read();

        Debug.Assert(reader.TokenType == JsonTokenType.StartObject);

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            Debug.Assert(reader.TokenType == JsonTokenType.PropertyName);

            string propertyName = reader.GetString()!;

            switch (propertyName)
            {
                case "pageSize":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.Number);
                    pageSize = reader.GetInt32();
                    break;

                case "offset":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.Number);
                    offset = reader.GetInt32();
                    break;
                default:
                    throw new JsonException($"Unrecognized property '{propertyName}'.");
            }
        }

        return new(pageSize, offset);
    }

    public static ValueCollectionPageToken FromOptions(int? pageSize, int? offset)
        => new(pageSize, offset);

    public static ValueCollectionPageToken? FromResponse(ClientResult page, int? pageSize)
    {
        PipelineResponse response = page.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);

        JsonElement data = doc.RootElement.GetProperty("data");
        int lastId = data.EnumerateArray().LastOrDefault().GetProperty("id").GetInt32();
        bool hasMore = doc.RootElement.GetProperty("has_more"u8).GetBoolean();

        if (!hasMore)
        {
            return null;
        }

        return new(pageSize, lastId + 1);
    }
}
