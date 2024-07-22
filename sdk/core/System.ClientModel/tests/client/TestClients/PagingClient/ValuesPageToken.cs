// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace ClientModel.Tests.Paging;

internal class ValuesPageToken : ContinuationToken
{
    protected ValuesPageToken(string? order, int? pageSize, int? offset)
    {
        Order = order;
        PageSize = pageSize;
        Offset = offset;
    }

    public string? Order { get; }
    public int? PageSize { get; }
    public int? Offset { get; }

    public override BinaryData ToBytes()
    {
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        writer.WriteStartObject();

        if (Order is not null)
        {
            writer.WriteString("order", Order);
        }

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

    public ValuesPageToken? GetNextPageToken(int offset, int count)
    {
        if (offset >= count)
        {
            return null;
        }

        return new ValuesPageToken(Order, PageSize, offset);
    }

    public static ValuesPageToken FromToken(ContinuationToken pageToken)
    {
        if (pageToken is ValuesPageToken token)
        {
            return token;
        }

        BinaryData data = pageToken.ToBytes();

        if (data.ToMemory().Length == 0)
        {
            throw new ArgumentException("Failed to create ValuesPageToken from provided pageToken.", nameof(pageToken));
        }

        Utf8JsonReader reader = new(data);

        string? order = null;
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
                case "order":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    order = reader.GetString();
                    break;

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

        return new(order, pageSize, offset);
    }

    public static ValuesPageToken FromOptions(string? order, int? pageSize, int? offset)
        => new(order, pageSize, offset);
}
