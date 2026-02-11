// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> An object returning sentence boundaries in the input and output texts. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SentenceBoundaries : IJsonModel<SentenceBoundaries>
    {
        /// <summary> Initializes a new instance of SentenceBoundaries. </summary>
        internal SentenceBoundaries() { }

        /// <summary>
        /// An integer array representing the lengths of the sentences in the input text.
        /// The length of the array is the number of sentences, and the values are the length of each sentence.
        /// </summary>
        public IReadOnlyList<int> SourceSentencesLengths { get; }
        /// <summary>
        /// An integer array representing the lengths of the sentences in the translated text.
        /// The length of the array is the number of sentences, and the values are the length of each sentence.
        /// </summary>
        public IReadOnlyList<int> TranslatedSentencesLengths { get; }

        SentenceBoundaries IJsonModel<SentenceBoundaries>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SentenceBoundaries is deprecated and not supported.");
        }

        SentenceBoundaries IPersistableModel<SentenceBoundaries>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SentenceBoundaries is deprecated and not supported.");
        }

        string IPersistableModel<SentenceBoundaries>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SentenceBoundaries is deprecated and not supported.");
        }

        void IJsonModel<SentenceBoundaries>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SentenceBoundaries is deprecated and not supported.");
        }

        BinaryData IPersistableModel<SentenceBoundaries>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SentenceBoundaries is deprecated and not supported.");
        }
    }
}
