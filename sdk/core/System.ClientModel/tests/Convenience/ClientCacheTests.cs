// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class ClientCacheTests
{
    [Test]
    public void CacheShouldCleanupWhenExceedsLimit()
    {
        var clientCache = new ClientCache();

        // Add 110 clients to trigger the cleanup.
        for (int i = 0; i < 110; i++)
        {
            var client = new object();
            clientCache.GetClient(() => client, $"client{i}");
        }

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<(Type, string), ClientEntry>;

        Assert.IsNotNull(clients, "The _clients field is null.");
        Assert.AreEqual(100, clients!.Count, "Cache did not cleanup correctly.");
    }

    [Test]
    public void CacheShouldNotCleanupWhenUnderLimit()
    {
        var clientCache = new ClientCache();

        // Add 50 clients, which is below the limit.
        for (int i = 0; i < 50; i++)
        {
            var client = new object();
            clientCache.GetClient(() => client, $"client{i}");
        }

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<(Type, string), ClientEntry>;

        Assert.IsNotNull(clients, "The _clients field is null.");
        Assert.AreEqual(50, clients!.Count, "Cache should not have cleaned up when under the limit.");
    }

    [Test]
    public void CacheShouldCleanupOldestClients()
    {
        var clientCache = new ClientCache();

        // Add 110 clients to trigger cleanup (exceeds _maxClients = 100)
        for (int i = 0; i < 110; i++)
        {
            var client = new object();
            clientCache.GetClient(() => client, $"client{i}");
        }

        // Re-access some clients to mark them as recently used
        // (These keys will be reinserted and move to the head of the LRU list.)
        clientCache.GetClient(() => new object(), "client0");
        clientCache.GetClient(() => new object(), "client1");

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<(Type, string), ClientEntry>;

        Assert.IsNotNull(clients, "The _clients field is null.");
        Assert.AreEqual(100, clients!.Count, "Cache did not cleanup correctly.");

        // Ensure that recently accessed clients are still in the cache.
        Assert.IsTrue(clients.ContainsKey((typeof(object), "client0")), "Most recently accessed client 'client0' should be in the cache.");
        Assert.IsTrue(clients.ContainsKey((typeof(object), "client1")), "Most recently accessed client 'client1' should be in the cache.");

        // Based on the LRU policy, after adding 110 items then re-accessing "client0" and "client1",
        // the evicted keys are those that were least recently used.
        // Keys "client2" through "client11" should have been evicted.
        for (int i = 2; i < 12; i++)
        {
            Assert.IsFalse(clients.ContainsKey((typeof(object), $"client{i}")),
                $"Least recently used client 'client{i}' should have been removed.");
        }
    }

    [Test]
    public void LRUShouldNotBeRemoved()
    {
        var clientCache = new ClientCache();

        for (int i = 0; i <= 100; i++)
        {
            var client = new object();
            clientCache.GetClient(() => client, $"client{i}");
        }

        // (These keys will be reinserted and move to the head of the LRU list.)
        clientCache.GetClient(() => new object(), "client0");
        clientCache.GetClient(() => new object(), "client1");

        clientCache.GetClient(() => new object(), "client101");
        clientCache.GetClient(() => new object(), "client102");

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<(Type, string), ClientEntry>;

        Assert.IsNotNull(clients, "The _clients field is null.");
        Assert.AreEqual(100, clients!.Count, "Cache did not cleanup correctly.");

        // Ensure that recently accessed clients are still in the cache.
        Assert.IsTrue(clients.ContainsKey((typeof(object), "client0")), "Most recently accessed client 'client0' should be in the cache.");
        Assert.IsTrue(clients.ContainsKey((typeof(object), "client1")), "Most recently accessed client 'client1' should be in the cache.");

        // Keys "client2" through "client3" should have been evicted.
        Assert.IsFalse(clients.ContainsKey((typeof(object), $"client2")));
        Assert.IsFalse(clients.ContainsKey((typeof(object), $"client3")));
    }

    [Test]
    public void CacheShouldDisposeClientsWhenRemoved()
    {
        var clientCache = new ClientCache();

        // Create a disposable client
        var disposableClient = new DisposableClient();
        clientCache.GetClient(() => disposableClient, "client0");

        // Add more clients to exceed the limit and trigger cleanup
        for (int i = 0; i < 110; i++)
        {
            var client = new object();
            clientCache.GetClient(() => client, $"client{i}");
        }

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<(Type, string), ClientEntry>;

        Assert.IsNotNull(clients, "The _clients field is null.");
        Assert.IsTrue(disposableClient.IsDisposed, "Disposable client was not disposed correctly.");
    }

    [Test]
    public void CacheShouldHandleDifferentClientIdsSeparately()
    {
        var clientCache = new ClientCache();

        // Add clients with the same type but different IDs
        var client1 = new object();
        clientCache.GetClient(() => client1, "client1");

        var client2 = new object();
        clientCache.GetClient(() => client2, "client2");

        var clientsField = typeof(ClientCache).GetField("_clients", BindingFlags.NonPublic | BindingFlags.Instance);
        var clients = clientsField?.GetValue(clientCache) as Dictionary<(Type, string), ClientEntry>;

        Assert.IsNotNull(clients, "The _clients field is null.");
        Assert.IsTrue(clients!.ContainsKey((typeof(object), "client1")), "Client1 should be in the cache.");
        Assert.IsTrue(clients!.ContainsKey((typeof(object), "client2")), "Client2 should be in the cache.");
    }
}

// Helper class to simulate a disposable client
internal class DisposableClient : IDisposable
{
    public bool IsDisposed { get; private set; }

    public void Dispose()
    {
        IsDisposed = true;
    }
}
