// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Dictionary Example element. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DictionaryExampleItem : IJsonModel<DictionaryExampleItem>
    {
        /// <summary> Initializes a new instance of DictionaryExampleItem. </summary>
        internal DictionaryExampleItem() { }

        /// <summary>
        /// A string giving the normalized form of the source term. Generally, this should be identical
        /// to the value of the Text field at the matching list index in the body of the request.
        /// </summary>
        public string NormalizedSource { get; }
        /// <summary>
        /// A string giving the normalized form of the target term. Generally, this should be identical
        /// to the value of the Translation field at the matching list index in the body of the request.
        /// </summary>
        public string NormalizedTarget { get; }
        /// <summary> A list of examples for the (source term, target term) pair. </summary>
        public IReadOnlyList<DictionaryExample> Examples { get; }

        DictionaryExampleItem IJsonModel<DictionaryExampleItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleItem is deprecated and not supported.");
        }

        DictionaryExampleItem IPersistableModel<DictionaryExampleItem>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleItem is deprecated and not supported.");
        }

        string IPersistableModel<DictionaryExampleItem>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleItem is deprecated and not supported.");
        }

        void IJsonModel<DictionaryExampleItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleItem is deprecated and not supported.");
        }

        BinaryData IPersistableModel<DictionaryExampleItem>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleItem is deprecated and not supported.");
        }
    }
}
