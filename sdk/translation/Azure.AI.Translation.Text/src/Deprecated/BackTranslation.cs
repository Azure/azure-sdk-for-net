// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Translation.Text
{
    /// <summary> Back Translation. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BackTranslation : IJsonModel<BackTranslation>
    {
        /// <summary> Initializes a new instance of BackTranslation. </summary>
        internal BackTranslation() { }

        /// <summary>
        /// A string giving the normalized form of the source term that is a back-translation of the target.
        /// This value should be used as input to lookup examples.
        /// </summary>
        public string NormalizedText { get; }
        /// <summary>
        /// A string giving the source term that is a back-translation of the target in a form best
        /// suited for end-user display.
        /// </summary>
        public string DisplayText { get; }
        /// <summary>
        /// An integer representing the number of examples that are available for this translation pair.
        /// Actual examples must be retrieved with a separate call to lookup examples. The number is mostly
        /// intended to facilitate display in a UX. For example, a user interface may add a hyperlink
        /// to the back-translation if the number of examples is greater than zero and show the back-translation
        /// as plain text if there are no examples. Note that the actual number of examples returned
        /// by a call to lookup examples may be less than numExamples, because additional filtering may be
        /// applied on the fly to remove "bad" examples.
        /// </summary>
        public int ExamplesCount { get; }
        /// <summary>
        /// An integer representing the frequency of this translation pair in the data. The main purpose of this
        /// field is to provide a user interface with a means to sort back-translations so the most frequent terms are first.
        /// </summary>
        public int FrequencyCount { get; }

        void IJsonModel<BackTranslation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BackTranslation is deprecated and not supported.");
        }

        BackTranslation IJsonModel<BackTranslation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BackTranslation is deprecated and not supported.");
        }

        BinaryData IPersistableModel<BackTranslation>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BackTranslation is deprecated and not supported.");
        }

        BackTranslation IPersistableModel<BackTranslation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BackTranslation is deprecated and not supported.");
        }

        string IPersistableModel<BackTranslation>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("BackTranslation is deprecated and not supported.");
        }
    }
}
