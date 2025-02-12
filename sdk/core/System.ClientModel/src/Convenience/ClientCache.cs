// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;

namespace System.ClientModel.Primitives;

/// <summary>
/// A cache for storing client instances, ensuring efficient reuse.
/// </summary>
public class ClientCache
{
    private readonly ConcurrentDictionary<(Type, string), object> _clients = new();

    /// <summary>
    /// Retrieves a client from the cache or creates a new one if it doesn't exist.
    /// </summary>
    /// <typeparam name="T">The type of the client.</typeparam>
    /// <param name="value">A factory function to create the client if not cached.</param>
    /// <param name="id">An optional identifier for the client instance.</param>
    /// <returns>The cached or newly created client instance.</returns>
    public T Get<T>(Func<T> value, string id = "") where T : class
    {
        (Type, string) clientKey = (typeof(T), id ?? string.Empty);

        return (T)_clients.GetOrAdd(clientKey, _ =>
        {
            if (_clients.Count > 100)
            {
                Cleanup();
            }
            return value();
        });
    }

    /// <summary>
    /// Removes and disposes of all cached clients.
    /// </summary>
    private void Cleanup()
    {
        foreach (var key in _clients.Keys)
        {
            if (_clients.TryRemove(key, out object? instance) && instance is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
