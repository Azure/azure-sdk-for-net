// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

/// <summary>
/// Unit tests for ConnectionCollection.
/// </summary>
public class ConnectionCollectionTests
{
    [Test]
    public void AddConnectionShouldStoreCorrectly()
    {
        var collection = new ConnectionCollection();
        var connection = new ClientConnection("conn1", "https://example.com", "myAPIKey");

        collection.Add(connection);

        Assert.AreEqual(1, collection.Count);
        Assert.AreEqual("conn1", collection["conn1"].Id);
        Assert.AreEqual("https://example.com", collection["conn1"].Locator);
        Assert.AreEqual(ClientAuthenticationMethod.ApiKey, collection["conn1"].Authentication);
    }

    [Test]
    public void SerializeShouldMatchExpectedJson()
    {
        var collection = new ConnectionCollection();
        collection.Add(new ClientConnection("conn1", "https://example.com", "myAPIKey"));

        string json = JsonSerializer.Serialize(collection);

        using var document = JsonDocument.Parse(json);
        var root = document.RootElement.EnumerateArray().First();

        Assert.AreEqual("conn1", root.GetProperty("id").GetString());
        Assert.AreEqual("https://example.com", root.GetProperty("locator").GetString());
        Assert.AreEqual("ApiKey", root.GetProperty("auth").GetString());
    }

    [Test]
    public void DeserializeShouldRestoreObjects()
    {
        string json = "[ { \"id\": \"conn1\", \"locator\": \"https://example.com\", \"auth\": \"ApiKey\" } ]";

        ConnectionCollection? collection = JsonSerializer.Deserialize<ConnectionCollection>(json);

        Assert.AreEqual(1, collection!.Count);
        Assert.AreEqual("conn1", collection["conn1"].Id);
        Assert.AreEqual("https://example.com", collection["conn1"].Locator);
        Assert.AreEqual(ClientAuthenticationMethod.ApiKey, collection["conn1"].Authentication);
    }

    [Test]
    public void SerializeAndDeserializeShouldBeEqual()
    {
        var collection = new ConnectionCollection();
        collection.Add(new ClientConnection("id1", "locator1", "myAPIKey"));

        string json = JsonSerializer.Serialize(collection);
        ConnectionCollection? deserializedCollection = JsonSerializer.Deserialize<ConnectionCollection>(json);

        Assert.IsNotNull(deserializedCollection);
        Assert.AreEqual(1, deserializedCollection!.Count);
        Assert.AreEqual("locator1", deserializedCollection["id1"].Locator);
        Assert.AreEqual(ClientAuthenticationMethod.ApiKey, deserializedCollection["id1"].Authentication);
    }
}
