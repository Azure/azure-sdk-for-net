// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core;

// TODO: this is a very demo implementation. We need to do better
/// <summary>
/// The client cache.
/// </summary>
public class ClientCache
{
    private readonly Dictionary<(Type, string), object> _clients = new Dictionary<(Type, string), object>();

    /// <summary>
    /// Gets a client from the cache.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public T Get<T>(Func<T> value, string id = default) where T: class
    {
        var client = (typeof(T), id);
        lock (_clients)
        {
            if (_clients.TryGetValue(client, out object cached))
            {
                return (T)cached;
            }

            if (_clients.Count > 100)
            {
                GC();
            }
            T created = value();
            _clients.Add(client, created);
            return created;
        }

        void GC()
        {
            foreach (object value in _clients.Values)
            {
                if (value is IDisposable disposable) disposable.Dispose();
            }
            _clients.Clear();
        }
    }
}
