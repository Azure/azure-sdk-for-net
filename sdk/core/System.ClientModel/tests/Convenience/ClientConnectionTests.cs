// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class ClientConnectionTests
{
    [Test]
    [TestCase(null, false)]
    [TestCase(CredentialKind.TokenCredential, false)]
    [TestCase(CredentialKind.TokenCredential, true)]
    public void TestClientConnectionConstructor(CredentialKind? credentialKind, bool hasMetadata)
    {
        ClientConnection conn;
        if (credentialKind is null)
        {
            conn = new(id: "123", locator: "www.microsoft.com");
            Assert.IsNull(conn.Credential);
            Assert.AreEqual(CredentialKind.None, conn.CredentialKind);
            Assert.AreEqual(0, conn.Metadata.Count);
        }
        else
        {
            object credential = new { foo="bar" };
            if (hasMetadata)
            {
                conn = new(id: "123", locator: "www.microsoft.com", credential: credential, credentialKind: credentialKind.Value);
                Assert.AreEqual(conn.Metadata.Count, 0);
            }
            else
            {
                var metadata = new Dictionary<string, string>
                {
                    { "test1", "123"},
                    { "test2", "456" }
                };
                conn = new(id: "123", locator: "www.microsoft.com", credential: credential, credentialKind: credentialKind.Value, metadata: metadata);
                Assert.AreEqual(conn.Metadata.Count, metadata.Count);
            }
            Assert.AreEqual(conn.CredentialKind, credentialKind);
            Assert.AreEqual(conn.Credential, credential);
        }
        Assert.AreEqual(conn.Id, "123");
        Assert.AreEqual(conn.Locator, "www.microsoft.com");
    }

#nullable disable
    [Test]
    [TestCase(null, "Id cannot be null or empty.")]
    [TestCase("123", "Locator cannot be null or empty.")]
    public void TestConstructorThrows(string id, string expected)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new ClientConnection(id: id, locator: null));
        Assert.That(exception.Message.StartsWith(expected));
    }

    [Test]
    [TestCase(null, null, "Id cannot be null or empty.")]
    [TestCase("123", null, "Locator cannot be null or empty.")]
    [TestCase("", "", "Id cannot be null or empty.")]
    [TestCase("123", "", "Locator cannot be null or empty.")]
    public void TestConstructorWithCredentialsThrows(string id, string locator, string expected)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new ClientConnection(id: id, locator: locator, credentialKind: CredentialKind.TokenCredential, credential: null));
        Assert.That(exception.Message.StartsWith(expected));
    }

    [Test]
    public void TestConstructorWithCredentialsThrowsArgumentNull()
    {
        ArgumentException exception = Assert.Throws<ArgumentNullException>(
            () => new ClientConnection(id: "123", locator: "www.microsoft.com", credentialKind: CredentialKind.TokenCredential, credential: null));
        Assert.That(exception.Message.StartsWith("Credential cannot be null."));
    }

    [Test]
    [TestCase(null, null, null, "Id cannot be null or empty.")]
    [TestCase("123", null, null, "Locator cannot be null or empty.")]
    [TestCase("", "", null, "Id cannot be null or empty.")]
    [TestCase("123", "", null, "Locator cannot be null or empty.")]
    public void TestConstructorWithMetadataThrows(string id, string locator, object credential, string expected)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new ClientConnection(id: id, locator: locator, credentialKind: CredentialKind.TokenCredential, credential: credential, metadata: null));
        Assert.That(exception.Message.StartsWith(expected), $"Expected: {expected}, got: {exception.Message}");
    }

    [Test]
    [TestCase("123", "www.microsoft.com", null, "Credential cannot be null.")]
    [TestCase("123", "www.microsoft.com", "test", "Metadata cannot be null")]
    public void TestConstructorWithMetadataThrowsArgumentNull(string id, string locator, object credential, string expected)
    {
        ArgumentException exception = Assert.Throws<ArgumentNullException>(() => new ClientConnection(id: id, locator: locator, credentialKind: CredentialKind.TokenCredential, credential: credential, metadata: null));
        Assert.That(exception.Message.StartsWith(expected), $"Expected: {expected}, got: {exception.Message}");
    }
#nullable enable
}
