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
public class ClientConnectionCollectionTests
{
    [Test]
    public void AddConnectionShouldStoreCorrectly()
    {
        var collection = new ClientConnectionCollection();
        var connection = new ClientConnection("conn1", "https://example.com", "myAPIKey", CredentialKind.ApiKeyString);

        collection.Add(connection);

        Assert.AreEqual(1, collection.Count);
        Assert.AreEqual("conn1", collection["conn1"].Id);
        Assert.AreEqual("https://example.com", collection["conn1"].Locator);
        Assert.AreEqual("myAPIKey", collection["conn1"].Credential);
        Assert.AreEqual(CredentialKind.ApiKeyString, collection["conn1"].CredentialKind);
    }

    [Test]
    public void SerializeShouldMatchExpectedJson()
    {
        var collection = new ClientConnectionCollection();
        collection.Add(new ClientConnection("conn1", "https://example.com", "myAPIKey", CredentialKind.ApiKeyString));

        string json = JsonSerializer.Serialize(collection);

        using var document = JsonDocument.Parse(json);
        var root = document.RootElement.EnumerateArray().First();

        Assert.AreEqual("conn1", root.GetProperty("id").GetString());
        Assert.AreEqual("https://example.com", root.GetProperty("locator").GetString());
        Assert.AreEqual("ApiKeyString", root.GetProperty("credentialKind").GetString());
    }

    [Test]
    public void DeserializeShouldRestoreObjects()
    {
        string json = "[ { \"id\": \"conn1\", \"locator\": \"https://example.com\", \"credentialKind\": \"ApiKeyString\" } ]";

        ClientConnectionCollection? collection = JsonSerializer.Deserialize<ClientConnectionCollection>(json);

        Assert.AreEqual(1, collection!.Count);
        Assert.AreEqual("conn1", collection["conn1"].Id);
        Assert.AreEqual("https://example.com", collection["conn1"].Locator);
        Assert.AreEqual(CredentialKind.ApiKeyString, collection["conn1"].CredentialKind);
    }

    [Test]
    public void SerializeAndDeserializeShouldBeEqual()
    {
        var collection = new ClientConnectionCollection();
        collection.Add(new ClientConnection("id1", "locator1", "myAPIKey", CredentialKind.ApiKeyString));

        string json = JsonSerializer.Serialize(collection);
        ClientConnectionCollection? deserializedCollection = JsonSerializer.Deserialize<ClientConnectionCollection>(json);

        Assert.IsNotNull(deserializedCollection);
        Assert.AreEqual(1, deserializedCollection!.Count);
        Assert.AreEqual("locator1", deserializedCollection["id1"].Locator);
        Assert.AreEqual(CredentialKind.ApiKeyString, deserializedCollection["id1"].CredentialKind);
    }
}
