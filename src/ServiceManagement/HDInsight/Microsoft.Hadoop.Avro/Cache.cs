// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro
{
    using System.Collections.Generic;

    /// <summary>
    /// This class represents a cache of generated serializer(s).
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    internal sealed class Cache<TKey, TValue>
        where TValue : class
    {
        private readonly Dictionary<TKey, TValue> cache;

        public Cache()
        {
            this.cache = new Dictionary<TKey, TValue>();
        }

        public TValue Get(TKey key)
        {
            lock (this.cache)
            {
                TValue value;
                if (this.cache.TryGetValue(key, out value))
                {
                    return value;
                }
            }

            return null;
        }

        public void Add(TKey key, TValue value)
        {
            lock (this.cache)
            {
                if (this.cache.ContainsKey(key))
                {
                    return;
                }

                this.cache.Add(key, value);
            }
        }

        internal int Count
        {
            get { return this.cache.Count; }
        }
    }
}
