// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace Azure.AI.DocumentIntelligence
{
    // CUSTOM CODE NOTE: this class is used to replace any occurrence of
    // IReadOnlyDictionary<string, DocumentField> in case we want to add
    // helper methods to it in the future. Those helper methods could
    // facilitate extracting field values, similarly to the pattern seen
    // when parsing JSON with System.Text.Json.

    /// <summary>
    /// A dictionary of named field values.
    /// </summary>
    public class DocumentFieldDictionary : IReadOnlyDictionary<string, DocumentField>
    {
        internal DocumentFieldDictionary()
        {
            Source = new Dictionary<string, DocumentField>();
        }

        internal DocumentFieldDictionary(IReadOnlyDictionary<string, DocumentField> source)
        {
            Source = source;
        }

        internal IReadOnlyDictionary<string, DocumentField> Source { get; }

        /// <inheritdoc/>
        public DocumentField this[string key] => Source[key];

        /// <inheritdoc/>
        public IEnumerable<string> Keys => Source.Keys;

        /// <inheritdoc/>
        public IEnumerable<DocumentField> Values => Source.Values;

        /// <inheritdoc/>
        public int Count => Source.Count;

        /// <inheritdoc/>
        public bool ContainsKey(string key) => Source.ContainsKey(key);

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, DocumentField>> GetEnumerator() => Source.GetEnumerator();

        /// <inheritdoc/>
        public bool TryGetValue(string key, out DocumentField value) => Source.TryGetValue(key, out value);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => (Source as IEnumerable).GetEnumerator();
    }
}
