// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel.Primitives;

/// <summary>
/// A cache for storing client instances with a Least Recently Used (LRU) eviction policy.
/// </summary>
public class ClientCache
{
    private readonly int _maxClients = 100;
    private readonly ConcurrentDictionary<(Type Type, string Id), LinkedListNode<CacheItem>> _cacheMap = new();
    // Doubly linked list to maintain LRU order. The head is the most recently used, the tail is the least.
    private readonly LinkedList<CacheItem> _lruList = new();
    // ReaderWriterLockSlim to allow concurrent reads while synchronizing writes.
    private readonly ReaderWriterLockSlim _lock = new(LockRecursionPolicy.NoRecursion);

    /// <summary>
    /// Retrieves a client from the cache or creates a new one if it does not exist.
    /// </summary>
    /// <typeparam name="T">The type of the client.</typeparam>
    /// <param name="createClient">A factory function to create the client if not cached.</param>
    /// <param name="id">An optional identifier for the client instance.</param>
    /// <returns>The cached or newly created client instance.</returns>
    public T GetClient<T>(Func<T> createClient, string id = "") where T : class
    {
        (Type Type, string Id) clientKey = (typeof(T), id ?? string.Empty);

        // Try to retrieve an existing client.
        _lock.EnterUpgradeableReadLock();
        try
        {
            if (_cacheMap.TryGetValue(clientKey, out var node))
            {
                // Update the LRU list: move the accessed node to the front.
                _lock.EnterWriteLock();
                try
                {
                    _lruList.Remove(node);
                    node.Value.LastAccessTime = DateTime.UtcNow;
                    _lruList.AddFirst(node);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
                return (T)node.Value.Client;
            }
        }
        finally
        {
            _lock.ExitUpgradeableReadLock();
        }

        // Not found: create a new client.
        T client = createClient();

        _lock.EnterWriteLock();
        try
        {
            // Double-check to see if another thread added the client meanwhile.
            if (_cacheMap.TryGetValue(clientKey, out var existingNode))
            {
                _lruList.Remove(existingNode);
                existingNode.Value.LastAccessTime = DateTime.UtcNow;
                _lruList.AddFirst(existingNode);
                return (T)existingNode.Value.Client;
            }

            var newNode = new LinkedListNode<CacheItem>(new CacheItem(clientKey, client, DateTime.UtcNow));
            _lruList.AddFirst(newNode);
            _cacheMap[clientKey] = newNode;
        }
        finally
        {
            _lock.ExitWriteLock();
        }

        // Evict least recently used items if needed.
        if (_cacheMap.Count > _maxClients)
        {
            RemoveLeastRecentlyUsed();
        }

        return client;
    }

    /// <summary>
    /// Removes the least recently used clients from the cache until the cache is within its limit.
    /// </summary>
    private void RemoveLeastRecentlyUsed()
    {
        _lock.EnterWriteLock();
        try
        {
            while (_lruList.Count > _maxClients)
            {
                var lruNode = _lruList.Last;
                if (lruNode != null)
                {
                    _lruList.RemoveLast();
                    _cacheMap.TryRemove(lruNode.Value.Key, out _);
                    if (lruNode.Value.Client is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }
                else
                {
                    break;
                }
            }
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }

    /// <summary>
    /// Represents an item stored in the cache.
    /// </summary>
    internal class CacheItem
    {
        /// <summary>
        /// Gets the key that uniquely identifies the cache entry.
        /// </summary>
        public (Type Type, string Id) Key { get; }

        /// <summary>
        /// Gets the client instance.
        /// </summary>
        public object Client { get; }

        /// <summary>
        /// Gets or sets the last time this client was accessed.
        /// </summary>
        public DateTime LastAccessTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheItem"/> class.
        /// </summary>
        /// <param name="key">The key that uniquely identifies the cache entry.</param>
        /// <param name="client">The client instance.</param>
        /// <param name="lastAccessTime">The last access time.</param>
        public CacheItem((Type Type, string Id) key, object client, DateTime lastAccessTime)
        {
            Key = key;
            Client = client;
            LastAccessTime = lastAccessTime;
        }
    }
}
