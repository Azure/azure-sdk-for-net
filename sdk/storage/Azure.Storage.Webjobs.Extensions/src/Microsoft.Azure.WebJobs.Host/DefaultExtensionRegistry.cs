// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Host
{
    public class DefaultExtensionRegistry : IExtensionRegistry
    {
        private ConcurrentDictionary<Type, ConcurrentBag<object>> _registry = new ConcurrentDictionary<Type, ConcurrentBag<object>>();

        public DefaultExtensionRegistry()
        {
        }

        public void RegisterExtension(Type type, object instance)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            if (!type.IsAssignableFrom(instance.GetType()))
            {
                throw new ArgumentOutOfRangeException("instance");
            }

            ConcurrentBag<object> instances = _registry.GetOrAdd(type, (t) => new ConcurrentBag<object>());
            instances.Add(instance);
        }

        public IEnumerable<object> GetExtensions(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ConcurrentBag<object> instances = null;
            if (_registry.TryGetValue(type, out instances))
            {
                return instances;
            }

            return Enumerable.Empty<object>();
        }
    }
}
