﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents a collection of client connections.
/// </summary>
[JsonConverter(typeof(ConnectionCollectionConverter))]
[DebuggerTypeProxy(typeof(ConnectionCollectionViewer))]
public class ConnectionCollection : KeyedCollection<string, ClientConnection>
{
    /// <summary>
    /// Gets the key for a given <see cref="ClientConnection"/>.
    /// </summary>
    protected override string GetKeyForItem(ClientConnection item) => item.Id;

    /// <summary>
    /// Adds a range of <see cref="ClientConnection"/> instances to the collection.
    /// </summary>
    /// <param name="connections">The connections to add.</param>
    public void AddRange(IEnumerable<ClientConnection> connections)
    {
        foreach (ClientConnection connection in connections)
        {
            Add(connection);
        }
    }
}

/// <summary>
/// Provides a debugger-friendly view of <see cref="ConnectionCollection"/>.
/// </summary>
internal class ConnectionCollectionViewer(ConnectionCollection connections)
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public ClientConnection[] Items
    {
        get
        {
            ClientConnection[] items = new ClientConnection[connections.Count];
            connections.CopyTo(items, 0);
            return items;
        }
    }
}

/// <summary>
/// Handles JSON serialization and deserialization of <see cref="ConnectionCollection"/>.
/// </summary>
internal class ConnectionCollectionConverter : JsonConverter<ConnectionCollection>
{
    public override ConnectionCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement json = document.RootElement;

        ConnectionCollection connections = [];

        foreach (JsonElement connectionJson in json.EnumerateArray())
        {
            // Retrieve 'id', 'locator', and 'auth' properties from the JSON
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
