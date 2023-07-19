// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class IndexingParameters
    {
        private IndexingParametersConfiguration _indexingParametersConfiguration;

        /// <summary> Initializes a new instance of IndexingParameters. </summary>
        public IndexingParameters()
        {
            Configuration = new ConfigurationAdapter(this);
        }

        /// <summary>
        /// A dictionary of indexer-specific configuration properties.
        /// Each name is the name of a <see href="https://docs.microsoft.com/rest/api/searchservice/create-indexer#parameters">specific property</see>.
        /// Each value must be of a primitive type.
        /// Use <see cref="IndexingParametersConfiguration"/> instead to set well-known properties intuitively.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, object> Configuration { get; }

        /// <summary>
        /// Indexer-specific configuration properties.
        /// Each value must be of a primitive type.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        [CodeGenMember("Configuration")]
        public IndexingParametersConfiguration IndexingParametersConfiguration
        {
            get => _indexingParametersConfiguration;
            set => _indexingParametersConfiguration = value;
        }
#pragma warning restore CA2227 // Collection properties should be readonly

        private class ConfigurationAdapter : IDictionary<string, object>
        {
            private readonly IndexingParameters _parameters;

            public ConfigurationAdapter(IndexingParameters parameters)
            {
                _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));

                Keys = new ConfigurationAdapterKeysCollection(this);
                Values = new ConfigurationAdapterValuesCollection(this);
            }

            /// <inheritdoc />
            public object this[string key]
            {
                get => TryGetValue(key, out object value) ? value : throw new KeyNotFoundException($"{key} not found");
                set
                {
                    EnsureInitialized();

                    IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;

                    if (IndexingParametersConfiguration.WellKnownProperties.TryGetValue(key, out (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set) property))
                    {
                        property.Set(configuration, value);
                    }
                    else
                    {
                        configuration[key] = value;
                    }
                }
            }

            /// <inheritdoc />
            public ICollection<string> Keys { get; }

            /// <inheritdoc />
            public ICollection<object> Values { get; }

            /// <inheritdoc />
            public int Count
            {
                get
                {
                    IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;
                    if (configuration is null)
                    {
                        return 0;
                    }

                    // Have to count ourselves since Enumerable.Count() will call into this property causing a StackOverflowException.
                    int count = 0;
                    foreach (KeyValuePair<string, object> item in this)
                    {
                        count++;
                    }

                    return count;
                }
            }

            /// <inheritdoc />
            public bool IsReadOnly => false;

            /// <inheritdoc />
            public void Add(string key, object value)
            {
                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                EnsureInitialized();

                IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;

                if (IndexingParametersConfiguration.WellKnownProperties.TryGetValue(key, out (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set) property))
                {
                    if (property.Get(configuration) is { })
                    {
                        throw new ArgumentException($"An item with the same key has already been added. Key: {key}");
                    }

                    property.Set(configuration, value);
                }
                else
                {
                    configuration.Add(key, value);
                }
            }

            /// <inheritdoc />
            public void Add(KeyValuePair<string, object> item) => Add(item.Key, item.Value);

            /// <inheritdoc />
            public void Clear() => _parameters._indexingParametersConfiguration?.Reset();

            /// <inheritdoc />
            public bool Contains(KeyValuePair<string, object> item)
            {
                IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;
                if (configuration is null)
                {
                    return false;
                }

                // Have to check ourselves since Enumerable.Contains() will call into this method causing a StackOverflowException.
                if (IndexingParametersConfiguration.WellKnownProperties.TryGetValue(item.Key, out (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set) property))
                {
                    return property.Get(configuration) is { } value && value.Equals(item.Value);
                }

                return ((ICollection<KeyValuePair<string, object>>)configuration).Contains(item);
            }

            /// <inheritdoc />
            public bool ContainsKey(string key)
            {
                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;
                if (configuration is null)
                {
                    return false;
                }

                if (IndexingParametersConfiguration.WellKnownProperties.TryGetValue(key, out (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set) property))
                {
                    return property.Get(configuration) is { };
                }

                return configuration.ContainsKey(key);
            }

            /// <inheritdoc />
            public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
            {
                if (array is null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                if (arrayIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                }

                IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;
                if (configuration is null)
                {
                    return;
                }

                foreach (KeyValuePair<string, object> pair in this)
                {
                    array[arrayIndex++] = pair;
                }
            }

            /// <summary>
            /// Enumerates the well-known properties and <see cref="IndexingParametersConfiguration.AdditionalProperties"/>
            /// of the parent's <see cref="IndexingParametersConfiguration"/> if initialized;
            /// otherwise, returns an enumerator over an empty enumerable.
            /// </summary>
            /// <returns></returns>
            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;
                if (configuration is null)
                {
                    yield break;
                }

                foreach (KeyValuePair<string, (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set)> property in IndexingParametersConfiguration.WellKnownProperties)
                {
                    if (property.Value.Get(configuration) is { } value)
                    {
                        yield return new KeyValuePair<string, object>(property.Key, value);
                    }
                }

                foreach (KeyValuePair<string, object> pair in configuration)
                {
                    yield return pair;
                }
            }

            /// <inheritdoc />
            public bool Remove(string key)
            {
                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;
                if (configuration is null)
                {
                    return false;
                }

                if (IndexingParametersConfiguration.WellKnownProperties.TryGetValue(key, out (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set) property))
                {
                    if (property.Get(configuration) is { })
                    {
                        property.Set(configuration, null);
                        return true;
                    }

                    return false;
                }

                return configuration.Remove(key);
            }

            /// <inheritdoc />
            public bool Remove(KeyValuePair<string, object> item)
            {
                IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;
                if (configuration is null)
                {
                    return false;
                }

                if (IndexingParametersConfiguration.WellKnownProperties.TryGetValue(item.Key, out (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set) property))
                {
                    if (property.Get(configuration) is { } value && value.Equals(item.Value))
                    {
                        property.Set(configuration, null);
                        return true;
                    }

                    return false;
                }

                return ((ICollection<KeyValuePair<string, object>>)configuration).Remove(item);
            }

            /// <inheritdoc />
            public bool TryGetValue(string key, out object value)
            {
                IndexingParametersConfiguration configuration = _parameters._indexingParametersConfiguration;
                if (configuration is null)
                {
                    value = null;
                    return false;
                }

                if (IndexingParametersConfiguration.WellKnownProperties.TryGetValue(key, out (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set) property))
                {
                    value = property.Get(configuration);
                    return value is { };
                }

                return configuration.TryGetValue(key, out value);
            }

            /// <summary>
            /// Gets a value indicating whether the parent's <see cref="IndexingParametersConfiguration"/> is initialized.
            /// </summary>
            internal bool IsInitialized => _parameters._indexingParametersConfiguration is { };

            /// <summary>
            /// Initializes the <see cref="IndexingParametersConfiguration"/> on the parent <see cref="IndexingParameters"/> if null.
            /// </summary>
            private void EnsureInitialized() =>
                LazyInitializer.EnsureInitialized(ref _parameters._indexingParametersConfiguration, () => new IndexingParametersConfiguration());

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        /// Base class for read-only keys and values collections for <see cref="ConfigurationAdapter"/>.
        /// </summary>
        /// <typeparam name="T">The type of element.</typeparam>
        private abstract class ConfigurationAdapterItemCollection<T> : ICollection<T>
        {
            /// <inheritdoc />
            public int Count => Items.Count();

            /// <inheritdoc />
            public bool IsReadOnly => true;

            /// <inheritdoc />
            public void Add(T item) => throw new NotSupportedException();

            /// <inheritdoc />
            public void Clear() => throw new NotSupportedException();

            /// <inheritdoc />
            public bool Contains(T item) => Items.Contains(item);

            /// <inheritdoc />
            public void CopyTo(T[] array, int arrayIndex)
            {
                if (array is null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                if (arrayIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                }

                foreach (T item in Items)
                {
                    array[arrayIndex++] = item;
                }
            }

            /// <inheritdoc />
            public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

            /// <inheritdoc />
            public bool Remove(T item) => throw new NotSupportedException();

            protected abstract IEnumerable<T> Items { get; }

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        /// Read-only keys collection for <see cref="ConfigurationAdapter"/>.
        /// </summary>
        private class ConfigurationAdapterKeysCollection : ConfigurationAdapterItemCollection<string>
        {
            private readonly ConfigurationAdapter _adapter;

            /// <summary>
            /// Creates a new instance of the <see cref="ConfigurationAdapterKeysCollection"/> class.
            /// </summary>
            /// <param name="adapter">The parent <see cref="ConfigurationAdapter"/> instance.</param>
            public ConfigurationAdapterKeysCollection(ConfigurationAdapter adapter) =>
                _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));

            /// <inheritdoc />
            protected override IEnumerable<string> Items
            {
                get
                {
                    if (!_adapter.IsInitialized)
                    {
                        yield break;
                    }

                    foreach (KeyValuePair<string, object> pair in _adapter)
                    {
                        yield return pair.Key;
                    }
                }
            }
        }

        /// <summary>
        /// Read-only values collection for <see cref="ConfigurationAdapter"/>.
        /// </summary>
        private class ConfigurationAdapterValuesCollection : ConfigurationAdapterItemCollection<object>
        {
            private readonly ConfigurationAdapter _adapter;

            /// <summary>
            /// Creates a new instance of the <see cref="ConfigurationAdapterValuesCollection"/> class.
            /// </summary>
            /// <param name="adapter">The parent <see cref="ConfigurationAdapter"/> instance.</param>
            public ConfigurationAdapterValuesCollection(ConfigurationAdapter adapter) =>
                _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));

            /// <inheritdoc />
            protected override IEnumerable<object> Items
            {
                get
                {
                    if (!_adapter.IsInitialized)
                    {
                        yield break;
                    }

                    foreach (KeyValuePair<string, object> pair in _adapter)
                    {
                        yield return pair.Value;
                    }
                }
            }
        }
    }
}
