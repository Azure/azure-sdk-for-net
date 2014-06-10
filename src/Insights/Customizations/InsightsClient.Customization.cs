//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Common;
using System.Net.Http;

namespace Microsoft.Azure.Insights
{
    public partial class InsightsClient
    {
        private MetricDefinitionCache _cache;

        internal MetricDefinitionCache Cache
        {
            get { return _cache ?? (_cache = new MetricDefinitionCache()); }
        }

        /// <summary>
        /// Get an instance of the AlertsClient class that uses the handler while initiating web requests.
        /// </summary>
        /// <param name="handler">the handler</param>
        public override InsightsClient WithHandler(DelegatingHandler handler)
        {
            return WithHandler(new InsightsClient(), handler);
        }

        protected override void Clone(ServiceClient<InsightsClient> client)
        {
            base.Clone(client);

            InsightsClient insightsClient = client as InsightsClient;
            if (insightsClient != null)
            {
                insightsClient._credentials = Credentials;
                insightsClient._baseUri = BaseUri;
                insightsClient.Credentials.InitializeServiceClient(insightsClient);
            }
        }

        internal class MetricDefinitionCache
        {
            private Cache<string, IEnumerable<MetricDefinition>> cache;

            public MetricDefinitionCache(int maxSize = 1000)
            {
                this.cache = new Cache<string, IEnumerable<MetricDefinition>>(maxSize);
            }

            public IEnumerable<MetricDefinition> Retrieve(string resourceUri)
            {
                return cache.Retrieve(resourceUri);
            }

            public void Store(string resourceUri, IEnumerable<MetricDefinition> value)
            {
                this.cache.Store(resourceUri, value);
            }

            // TODO: Add locking (thread safety)
            private class Cache<TKey, TValue>
            {
                private Dictionary<TKey, LinkedListNode<Tuple<TKey, TValue>>> dictionary;
                private LinkedList<Tuple<TKey, TValue>> list; 

                public int MaxSize { get; set; }

                public Cache(int maxSize)
                {
                    this.dictionary = new Dictionary<TKey, LinkedListNode<Tuple<TKey, TValue>>>();
                    this.list = new LinkedList<Tuple<TKey, TValue>>();
                    this.MaxSize = maxSize;
                }

                public TValue Retrieve(TKey key)
                {
                    // Return default (null) if not in cache
                    if (!dictionary.ContainsKey(key))
                    {
                        return default(TValue);
                    }

                    // Move accessed node to top of list (newest)
                    LinkedListNode<Tuple<TKey, TValue>> node = dictionary[key];
                    list.Remove(node);
                    list.AddFirst(node);

                    // Return value
                    return node.Value.Item2;
                }

                public void Store(TKey key, TValue value)
                {
                    LinkedListNode<Tuple<TKey, TValue>> node = new LinkedListNode<Tuple<TKey, TValue>>(new Tuple<TKey, TValue>(key, value));
                    
                    // Maintain only the latest version of an item
                    if (this.dictionary.ContainsKey(key))
                    {
                        list.Remove(dictionary[key]);
                    }

                    // Array accessor will add or replace in dictionary
                    dictionary[key] = node;
                    list.AddFirst(node);

                    // Maintain max size
                    this.Trim();
                }

                // Removes the oldest item from the dictionary and list
                private void RemoveOldest()
                {
                    dictionary.Remove(list.Last.Value.Item1);
                    list.RemoveLast();
                }

                // Deletes the oldest items until only MaxSize items remain
                private void Trim()
                {
                    while (dictionary.Count > MaxSize)
                    {
                        this.RemoveOldest(); 
                    }
                }
            }
        }
    }
}
