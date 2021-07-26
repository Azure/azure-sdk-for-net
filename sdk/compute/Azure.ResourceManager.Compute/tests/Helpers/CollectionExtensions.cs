// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class CollectionExtensions
    {
        public static void AddRange<K, V>(this IDictionary<K, V> target, IDictionary<K, V> source)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (source == null)
                return;
            foreach (var kv in source)
            {
                target.Add(kv);
            }
        }
    }
}
