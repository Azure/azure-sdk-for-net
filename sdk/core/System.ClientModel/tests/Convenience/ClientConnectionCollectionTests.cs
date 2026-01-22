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

        Assert.That(collection.Count, Is.EqualTo(1));
        Assert.That(collection["conn1"].Id, Is.EqualTo("conn1"));
        Assert.That(collection["conn1"].Locator, Is.EqualTo("https://example.com"));
        Assert.That(collection["conn1"].Credential, Is.EqualTo("myAPIKey"));
        Assert.That(collection["conn1"].CredentialKind, Is.EqualTo(CredentialKind.ApiKeyString));
    }

    [Test]
    public void SerializeShouldMatchExpectedJson()
    {
        var collection = new ClientConnectionCollection();
        collection.Add(new ClientConnection("conn1", "https://example.com", "myAPIKey", CredentialKind.ApiKeyString));

        string json = JsonSerializer.Serialize(collection);

        using var document = JsonDocument.Parse(json);
        var root = document.RootElement.EnumerateArray().First();

        Assert.That(root.GetProperty("id").GetString(), Is.EqualTo("conn1"));
        Assert.That(root.GetProperty("locator").GetString(), Is.EqualTo("https://example.com"));
        Assert.That(root.GetProperty("credentialKind").GetString(), Is.EqualTo("ApiKeyString"));
    }

    [Test]
    public void DeserializeShouldRestoreObjects()
    {
        string json = "[ { \"id\": \"conn1\", \"locator\": \"https://example.com\", \"credentialKind\": \"ApiKeyString\" } ]";

        ClientConnectionCollection? collection = JsonSerializer.Deserialize<ClientConnectionCollection>(json);

        Assert.That(collection!.Count, Is.EqualTo(1));
        Assert.That(collection["conn1"].Id, Is.EqualTo("conn1"));
        Assert.That(collection["conn1"].Locator, Is.EqualTo("https://example.com"));
        Assert.That(collection["conn1"].CredentialKind, Is.EqualTo(CredentialKind.ApiKeyString));
    }

    [Test]
    public void SerializeAndDeserializeShouldBeEqual()
    {
        var collection = new ClientConnectionCollection();
        collection.Add(new ClientConnection("id1", "locator1", "myAPIKey", CredentialKind.ApiKeyString));

        string json = JsonSerializer.Serialize(collection);
        ClientConnectionCollection? deserializedCollection = JsonSerializer.Deserialize<ClientConnectionCollection>(json);

        Assert.That(deserializedCollection, Is.Not.Null);
        Assert.That(deserializedCollection!.Count, Is.EqualTo(1));
        Assert.That(deserializedCollection["id1"].Locator, Is.EqualTo("locator1"));
        Assert.That(deserializedCollection["id1"].CredentialKind, Is.EqualTo(CredentialKind.ApiKeyString));
    }
}
