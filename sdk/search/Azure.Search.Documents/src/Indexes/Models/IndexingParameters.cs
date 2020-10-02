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
        [CodeGenMember("Configuration")]
        public IndexingParametersConfiguration IndexingParametersConfiguration
        {
            get => _indexingParametersConfiguration;
            set => _indexingParametersConfiguration = value;
        }

        private class ConfigurationAdapter : IDictionary<string, object>
        {
            private readonly IndexingParameters _parent;

            public ConfigurationAdapter(IndexingParameters parent)
            {
                _parent = parent;

                Keys = new KeyCollection(this);
                Values = new ValueCollection(this);
            }

            /// <inheritdoc />
            public object this[string key]
            {
                get => Configuration?[key] ?? null;
                set
                {
                    EnsureInitialized();

                    Configuration[key] = value;
                }
            }

            /// <inheritdoc />
            public ICollection<string> Keys { get; }

            /// <inheritdoc />
            public ICollection<object> Values { get; }

            /// <inheritdoc />
            public int Count =>
                Configuration?.Count ?? 0;

            /// <inheritdoc />
            public bool IsReadOnly =>
                Configuration?.IsReadOnly ?? false;

            /// <summary>
            /// Gets the <see cref="IndexingParametersConfiguration"/> from the parent <see cref="IndexingParameters"/>.
            /// You should call <see cref="EnsureInitialized"/> first to ensure it is initialized if required.
            /// </summary>
            private IDictionary<string, object> Configuration =>
                _parent._indexingParametersConfiguration?.Aggregate();

            /// <inheritdoc />
            public void Add(string key, object value)
            {
                EnsureInitialized();

                Configuration.Add(key, value);
            }

            /// <inheritdoc />
            public void Add(KeyValuePair<string, object> item)
            {
                EnsureInitialized();

                Configuration.Add(item);
            }

            /// <inheritdoc />
            public void Clear() =>
                Configuration?.Clear();

            /// <inheritdoc />
            public bool Contains(KeyValuePair<string, object> item) =>
                Configuration?.Contains(item) ?? false;

            /// <inheritdoc />
            public bool ContainsKey(string key) =>
                Configuration?.ContainsKey(key) ?? false;

            /// <inheritdoc />
            public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) =>
                Configuration?.CopyTo(array, arrayIndex);

            /// <inheritdoc />
            public IEnumerator<KeyValuePair<string, object>> GetEnumerator() =>
                Configuration?.GetEnumerator() ?? Enumerable.Empty<KeyValuePair<string, object>>().GetEnumerator();

            /// <inheritdoc />
            public bool Remove(string key) =>
                Configuration?.Remove(key) ?? false;

            /// <inheritdoc />
            public bool Remove(KeyValuePair<string, object> item) =>
                Configuration?.Remove(item) ?? false;

            /// <inheritdoc />
            public bool TryGetValue(string key, out object value)
            {
                if (Configuration != null)
                {
                    return TryGetValue(key, out value);
                }

                value = null;
                return false;
            }

            /// <summary>
            /// Initializes the <see cref="IndexingParametersConfiguration"/> on the parent <see cref="IndexingParameters"/> if null.
            /// </summary>
            private void EnsureInitialized() =>
                LazyInitializer.EnsureInitialized(ref _parent._indexingParametersConfiguration, () => new IndexingParametersConfiguration());

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() =>
                GetEnumerator();
        }

        /// <summary>
        /// Base class for read-only keys and values collections for <see cref="ConfigurationAdapter"/>.
        /// </summary>
        /// <typeparam name="T">The type of element.</typeparam>
        private abstract class ReadOnlyCollection<T> : ICollection<T>
        {
            /// <inheritdoc />
            public int Count => Items?.Count ?? 0;

            /// <inheritdoc />
            public bool IsReadOnly => true;

            /// <inheritdoc />
            protected abstract ICollection<T> Items { get; }

            /// <inheritdoc />
            public void Add(T item) => throw new NotSupportedException();

            /// <inheritdoc />
            public void Clear() => throw new NotSupportedException();

            /// <inheritdoc />
            public bool Contains(T item) => Items?.Contains(item) ?? false;

            /// <inheritdoc />
            public void CopyTo(T[] array, int arrayIndex) => Items?.CopyTo(array, arrayIndex);

            /// <inheritdoc />
            public IEnumerator<T> GetEnumerator() =>
                Items?.GetEnumerator() ?? Enumerable.Empty<T>().GetEnumerator();

            /// <inheritdoc />
            public bool Remove(T item) => Items?.Remove(item) ?? false;

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        /// Read-only keys collection for <see cref="ConfigurationAdapter"/>.
        /// </summary>
        private class KeyCollection : ReadOnlyCollection<string>
        {
            private readonly ConfigurationAdapter _parent;

            /// <summary>
            /// Creates a new instance of the <see cref="KeyCollection"/> class.
            /// </summary>
            /// <param name="parent">The parent <see cref="ConfigurationAdapter"/> instance.</param>
            public KeyCollection(ConfigurationAdapter parent) =>
                _parent = parent ?? throw new ArgumentNullException(nameof(parent));

            /// <inheritdoc />
            protected override ICollection<string> Items => _parent.Keys;
        }

        /// <summary>
        /// Read-only values collection for <see cref="ConfigurationAdapter"/>.
        /// </summary>
        private class ValueCollection : ReadOnlyCollection<object>
        {
            private readonly ConfigurationAdapter _parent;

            /// <summary>
            /// Creates a new instance of the <see cref="ValueCollection"/> class.
            /// </summary>
            /// <param name="parent">The parent <see cref="ConfigurationAdapter"/> instance.</param>
            public ValueCollection(ConfigurationAdapter parent) =>
                _parent = parent ?? throw new ArgumentNullException(nameof(parent));

            /// <inheritdoc />
            protected override ICollection<object> Items => _parent.Values;
        }
    }
}
