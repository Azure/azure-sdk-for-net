// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class ClientCacheTests
{
    [Test]
    public void CacheShouldCleanupWhenExceedsLimit()
    {
        var clientCache = new ClientCache(100);

        // Add 110 clients to trigger the cleanup.
        for (int i = 0; i < 110; i++)
        {
            var client = new object();
            clientCache.GetClient(new DummyClientKey($"client{i}"), () => client);
        }

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<object, ClientEntry>;

        Assert.That(clients, Is.Not.Null, "The _clients field is null.");
        Assert.That(clients!.Count, Is.EqualTo(100), "Cache did not cleanup correctly.");
    }

    [Test]
    public void CacheShouldNotCleanupWhenUnderLimit()
    {
        var clientCache = new ClientCache(100);

        // Add 50 clients, which is below the limit.
        for (int i = 0; i < 50; i++)
        {
            var client = new object();
            clientCache.GetClient(new DummyClientKey($"client{i}"), () => client);
        }

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<object, ClientEntry>;

        Assert.That(clients, Is.Not.Null, "The _clients field is null.");
        Assert.That(clients!.Count, Is.EqualTo(50), "Cache should not have cleaned up when under the limit.");
    }

    [Test]
    public void CacheShouldCleanupOldestClients()
    {
        var clientCache = new ClientCache(100);

        // Add 110 clients to trigger cleanup (exceeds _maxClients = 100)
        for (int i = 0; i < 110; i++)
        {
            var client = new object();
            clientCache.GetClient(new DummyClientKey($"client{i}"), () => client);
        }

        // Re-access some clients to mark them as recently used
        // (These keys will be reinserted and move to the head of the LRU list.)
        clientCache.GetClient(new DummyClientKey("client0"), () => new object());
        clientCache.GetClient(new DummyClientKey("client1"), () => new object());

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<object, ClientEntry>;

        Assert.That(clients, Is.Not.Null, "The _clients field is null.");
        Assert.That(clients!.Count, Is.EqualTo(100), "Cache did not cleanup correctly.");

        // Ensure that recently accessed clients are still in the cache.
        Assert.That(clients.ContainsKey(new DummyClientKey("client0")), Is.True, "Most recently accessed client 'client0' should be in the cache.");
        Assert.That(clients.ContainsKey(new DummyClientKey("client1")), Is.True, "Most recently accessed client 'client1' should be in the cache.");

        // Based on the LRU policy, after adding 110 items then re-accessing "client0" and "client1",
        // the evicted keys are those that were least recently used.
        // Keys "client2" through "client11" should have been evicted.
        for (int i = 2; i < 12; i++)
        {
            Assert.That(clients.ContainsKey(new DummyClientKey($"client{i}")),
            Is.False,
            $"Least recently used client 'client{i}' should have been removed.");
        }
    }

    [Test]
    public void LRUShouldNotBeRemoved()
    {
        var clientCache = new ClientCache(100);

        for (int i = 0; i <= 100; i++)
        {
            var client = new object();
            clientCache.GetClient(new DummyClientKey($"client{i}"), () => client);
        }

        // (These keys will be reinserted and move to the head of the LRU list.)
        clientCache.GetClient(new DummyClientKey("client0"), () => new object());
        clientCache.GetClient(new DummyClientKey("client1"), () => new object());

        clientCache.GetClient(new DummyClientKey("client101"), () => new object());
        clientCache.GetClient(new DummyClientKey("client102"), () => new object());

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<object, ClientEntry>;

        Assert.That(clients, Is.Not.Null, "The _clients field is null.");
        Assert.That(clients!.Count, Is.EqualTo(100), "Cache did not cleanup correctly.");

        // Ensure that recently accessed clients are still in the cache.
        Assert.That(clients.ContainsKey(new DummyClientKey("client0")), Is.True, "Most recently accessed client 'client0' should be in the cache.");
        Assert.That(clients.ContainsKey(new DummyClientKey("client1")), Is.True, "Most recently accessed client 'client1' should be in the cache.");

        // Keys "client2" through "client3" should have been evicted.
        Assert.That(clients.ContainsKey(new DummyClientKey("client2")), Is.False);
        Assert.That(clients.ContainsKey(new DummyClientKey("client3")), Is.False);
    }

    [Test]
    public void CacheShouldDisposeClientsWhenRemoved()
    {
        var clientCache = new ClientCache(100);

        // Create a disposable client
        var disposableClient = new DisposableClient();
        clientCache.GetClient(new DummyClientKey("client0"), () => disposableClient);

        // Add more clients to exceed the limit and trigger cleanup
        for (int i = 0; i < 110; i++)
        {
            var client = new object();
            clientCache.GetClient(new DummyClientKey($"client{i}"), () => client);
        }

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<object, ClientEntry>;

        Assert.That(clients, Is.Not.Null, "The _clients field is null.");
        Assert.That(disposableClient.IsDisposed, Is.True, "Disposable client was not disposed correctly.");
    }

    [Test]
    public void CacheShouldHandleDifferentClientIdsSeparately()
    {
        var clientCache = new ClientCache(100);

        // Add clients with the same type but different IDs
        var client1 = new object();
        clientCache.GetClient(new DummyClientKey("client1"), () => client1);

        var client2 = new object();
        clientCache.GetClient(new DummyClientKey("client2"), () => client2);

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<object, ClientEntry>;

        Assert.That(clients, Is.Not.Null, "The _clients field is null.");
        Assert.That(clients!.ContainsKey(new DummyClientKey("client1")), Is.True, "Client1 should be in the cache.");
        Assert.That(clients!.ContainsKey(new DummyClientKey("client2")), Is.True, "Client2 should be in the cache.");
    }

    [Test]
    public void ClientCacheShouldRespectMaxCacheSize()
    {
        var clientCache = new ClientCache(maxSize: 3);

        // Insert 3 clients with DummyClientKey as the identifier
        clientCache.GetClient(new DummyClientKey("A"), () => new object());
        clientCache.GetClient(new DummyClientKey("B"), () => new object());
        clientCache.GetClient(new DummyClientKey("C"), () => new object());

        // Access client A to mark it as most recently used
        var wasRecreated = false;
        clientCache.GetClient(new DummyClientKey("A"), () =>
        {
            wasRecreated = true;
            return new object();
        });

        // Add a new client D to trigger eviction
        clientCache.GetClient(new DummyClientKey("D"), () => new object());

        // A should still be in the cache (was recently used), so this should not call the factory
        clientCache.GetClient(new DummyClientKey("A"), () =>
        {
            wasRecreated = true;
            return new object();  // This call should not trigger recreation for A
        });

        Assert.That(wasRecreated, Is.False, "Client A was unexpectedly recreated");

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<object, ClientEntry>;

        Assert.That(clients, Is.Not.Null, "_clients dictionary should not be null");

        // Extract the keys correctly
        var keys = clients!.Keys.Select(k => k is DummyClientKey DummyClientKey ? DummyClientKey.Key : null).ToList();

        // Verify that the cache contains the expected clients
        Assert.That(keys, Is.EquivalentTo(new[] { "A", "C", "D" }), "Cache should contain A, C, and D");

        // Ensure B was evicted as it was the least recently used
        Assert.That(keys.Contains("B"), Is.False, "Client B should have been evicted.");
    }

    [Test]
    public void CacheShouldHandleDifferentOptionsSeparately()
    {
        var clientCache = new ClientCache(100);

        // Define two different options as DummyClientKeys
        var options1 = new ClientPipelineOptions() { EnableDistributedTracing = true };
        var options2 = new ClientPipelineOptions() { EnableDistributedTracing = false };

        // Create and retrieve a client with options1
        clientCache.GetClient(new DummyClientKey("abc", options1), () => new object()); // Miss
        var client1 = clientCache.GetClient(new DummyClientKey("abc", options1), () => new object()); // Hit ✅

        // Create and retrieve a client with options2 (should be a separate entry)
        var client2 = clientCache.GetClient(new DummyClientKey("abc", options2), () => new object()); // Miss ✅

        // Assert that the two clients are distinct objects
        Assert.That(client2, Is.Not.SameAs(client1), "Clients should be distinct when options are different.");

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<object, ClientEntry>;

        // Assert that both clients are in the cache with the expected keys
        Assert.That(clients!.ContainsKey(new DummyClientKey("abc", options1)), Is.True, "Client with options1 should be in the cache.");
        Assert.That(clients!.ContainsKey(new DummyClientKey("abc", options2)), Is.True, "Client with options2 should be in the cache.");
    }
}

internal record DummyClientKey(string Key, ClientPipelineOptions? options = null);

// Helper class to simulate a disposable client
internal class DisposableClient : IDisposable
{
    public bool IsDisposed { get; private set; }

    public void Dispose()
    {
        IsDisposed = true;
    }
}
