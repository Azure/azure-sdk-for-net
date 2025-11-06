// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Item containing break sentence result. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BreakSentenceItem : IJsonModel<BreakSentenceItem>
    {
        /// <summary> Initializes a new instance of BreakSentenceItem. </summary>
        internal BreakSentenceItem() { }

        /// <summary> The detectedLanguage property is only present in the result object when language auto-detection is requested. </summary>
        public DetectedLanguage DetectedLanguage { get; }
        /// <summary>
        /// An integer array representing the lengths of the sentences in the input text.
        /// The length of the array is the number of sentences, and the values are the length of each sentence.
        /// </summary>
        public IReadOnlyList<int> SentencesLengths { get; }

        BreakSentenceItem IJsonModel<BreakSentenceItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BreakSentenceItem is deprecated and not supported.");
        }

        BreakSentenceItem IPersistableModel<BreakSentenceItem>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BreakSentenceItem is deprecated and not supported.");
        }

        string IPersistableModel<BreakSentenceItem>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BreakSentenceItem is deprecated and not supported.");
        }

        void IJsonModel<BreakSentenceItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BreakSentenceItem is deprecated and not supported.");
        }

        BinaryData IPersistableModel<BreakSentenceItem>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BreakSentenceItem is deprecated and not supported.");
        }
    }
}
