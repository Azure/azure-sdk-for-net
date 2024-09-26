// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.CloudMachine;

// TODO: this is a very demo implementation. We need to do better
public class ClientCache
{
    private readonly Dictionary<string, object> _clients = new Dictionary<string, object>();

    // TODO: consider uisng ICLientCreator instead of Func
    public T Get<T>(string id, Func<T> value) where T: class
    {
        lock (_clients)
        {
            if (_clients.TryGetValue(id, out object cached))
            {
                T client = (T)cached;
                return client;
            }

            if (_clients.Count > 100)
            {
                GC();
            }
            T created = value();
            _clients.Add(id, created);
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
