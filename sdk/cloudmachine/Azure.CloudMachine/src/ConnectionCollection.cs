﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.CloudMachine;

/// <summary>
/// Represents the connection options for a client.
/// </summary>
[JsonConverter(typeof(ConnectionCollectionConverter))]
public class ConnectionCollection : KeyedCollection<string, ClientConnection>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionCollection"/> class.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected override string GetKeyForItem(ClientConnection item) => item.Id;

    internal void AddRange(IEnumerable<ClientConnection> connections)
    {
        foreach (ClientConnection connection in connections)
            Add(connection);
    }
}

internal class ConnectionCollectionConverter : JsonConverter<ConnectionCollection>
{
    public override ConnectionCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement json = document.RootElement;

        ConnectionCollection connections = [];
        foreach (JsonElement connectionJson in json.EnumerateArray())
        {
            string id = connectionJson.GetProperty("id").GetString();
            string locator = connectionJson.GetProperty("locator").GetString();
            string auth = connectionJson.GetProperty("auth").GetString();
            ClientAuthenticationMethod authMethod = (ClientAuthenticationMethod)Enum.Parse(typeof(ClientAuthenticationMethod), auth);
            ClientConnection connection = new ClientConnection(id, locator, authMethod);
            connections.Add(connection);
        }
        return connections;
    }

    public override void Write(Utf8JsonWriter writer, ConnectionCollection value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (ClientConnection connection in value)
        {
            writer.WriteStartObject();
            writer.WriteString("id", connection.Id);
            writer.WriteString("locator", connection.Locator);
            writer.WriteString("auth", connection.Authentication.ToString());
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }
}
