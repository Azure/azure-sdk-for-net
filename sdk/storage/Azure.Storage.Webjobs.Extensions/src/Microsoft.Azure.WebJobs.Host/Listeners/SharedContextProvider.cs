// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal class SharedContextProvider : ISharedContextProvider
    {
        private readonly IDictionary<Type, object> _instances = new Dictionary<Type, object>();
        private readonly IDictionary<string, object> _items = new Dictionary<string, object>();

        public bool TryGetValue(string key, out object value)
        {
            return _items.TryGetValue(key, out value);
        }

        public void SetValue(string key, object value)
        {
            _items[key] = value;
        }

        public T GetOrCreateInstance<T>(IFactory<T> factory)
        {
            Type factoryItemType = typeof(T);

            if (_instances.ContainsKey(factoryItemType))
            {
                return (T)_instances[factoryItemType];
            }
            else
            {
                T listener = factory.Create();
                _instances.Add(factoryItemType, listener);
                return listener;
            }
        }
    }
}
