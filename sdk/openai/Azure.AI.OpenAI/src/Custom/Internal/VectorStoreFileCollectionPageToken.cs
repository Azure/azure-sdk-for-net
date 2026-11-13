// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Text.Json;

#nullable enable

namespace Azure.AI.OpenAI.VectorStores;

internal class VectorStoreFileCollectionPageToken : ContinuationToken
{
    protected VectorStoreFileCollectionPageToken(string vectorStoreId, int? limit, string? order, string? after, string? before, string? filter)
    {
        VectorStoreId = vectorStoreId;

        Limit = limit;
        Order = order;
        After = after;
        Before = before;
        Filter = filter;
    }

    public string VectorStoreId { get; }

    public int? Limit { get; }

    public string? Order { get; }

    public string? After { get; }

    public string? Before { get; }

    public string? Filter { get; }

    public override BinaryData ToBytes()
    {
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        writer.WriteStartObject();
        writer.WriteString("vectorStoreId", VectorStoreId);

        if (Limit.HasValue)
        {
            writer.WriteNumber("limit", Limit.Value);
        }

        if (Order is not null)
        {
            writer.WriteString("order", Order);
        }

        if (After is not null)
        {
            writer.WriteString("after", After);
        }

        if (Before is not null)
        {
            writer.WriteString("before", Before);
        }

        if (Filter is not null)
        {
            writer.WriteString("filter", Filter);
        }

        writer.WriteEndObject();

        writer.Flush();
        stream.Position = 0;

        return BinaryData.FromStream(stream);
    }

    public static VectorStoreFileCollectionPageToken FromToken(ContinuationToken pageToken)
    {
        if (pageToken is VectorStoreFileCollectionPageToken token)
        {
            return token;
        }

        BinaryData data = pageToken.ToBytes();

        if (data.ToMemory().Length == 0)
        {
            throw new ArgumentException("Failed to create VectorStoreFilesPageToken from provided pageToken.", nameof(pageToken));
        }

        Utf8JsonReader reader = new(data);

        string vectorStoreId = null!;
        int? limit = null;
        string? order = null;
        string? after = null;
        string? before = null;
        string? filter = null;

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
                case "vectorStoreId":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    vectorStoreId = reader.GetString()!;
                    break;
                case "limit":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.Number);
                    limit = reader.GetInt32();
                    break;
                case "order":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    order = reader.GetString();
                    break;
                case "after":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    after = reader.GetString();
                    break;
                case "before":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    before = reader.GetString();
                    break;
                case "filter":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    filter = reader.GetString();
                    break;
                default:
                    throw new JsonException($"Unrecognized property '{propertyName}'.");
            }
        }

        if (vectorStoreId is null)
        {
            throw new ArgumentException("Failed to create VectorStoreFilesPageToken from provided pageToken.", nameof(pageToken));
        }

        return new(vectorStoreId, limit, order, after, before, filter);
    }

    public static VectorStoreFileCollectionPageToken FromOptions(string vectorStoreId, int? limit, string? order, string? after, string? before, string? filter)
        => new(vectorStoreId, limit, order, after, before, filter);

    public static VectorStoreFileCollectionPageToken? FromResponse(ClientResult result, string vectorStoreId, int? limit, string? order, string? before, string? filter)
    {
        PipelineResponse response = result.GetRawResponse();
        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string lastId = doc.RootElement.GetProperty("last_id"u8).GetString()!;
        bool hasMore = doc.RootElement.GetProperty("has_more"u8).GetBoolean();

        if (!hasMore || lastId is null)
        {
            return null;
        }

        return new(vectorStoreId, limit, order, lastId, before, filter);
    }
}
