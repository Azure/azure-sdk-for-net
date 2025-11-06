// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Input Text Element for Translator Requests. </summary>
    [Obsolete("This class is deprecated and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputTextWithTranslation : IJsonModel<InputTextWithTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputTextWithTranslation"/> class.
        /// </summary>
        /// <param name="word">Word to lookup in the dictionary.</param>
        /// <param name="translation">Translation of the word.</param>
        public InputTextWithTranslation(string word, string translation)
        {
            throw new NotSupportedException("This class is deprecated and will be removed in a future release.");
        }

        /// <summary> Gets or Sets the Text to be translated. </summary>
        public string Text { get; }

        /// <summary> Gets or Sets the Translation of the Text. </summary>
        public string Translation { get; }

        InputTextWithTranslation IJsonModel<InputTextWithTranslation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("InputTextWithTranslation is deprecated and not supported.");
        }

        InputTextWithTranslation IPersistableModel<InputTextWithTranslation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("InputTextWithTranslation is deprecated and not supported.");
        }

        string IPersistableModel<InputTextWithTranslation>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("InputTextWithTranslation is deprecated and not supported.");
        }

        void IJsonModel<InputTextWithTranslation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("InputTextWithTranslation is deprecated and not supported.");
        }

        BinaryData IPersistableModel<InputTextWithTranslation>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("InputTextWithTranslation is deprecated and not supported.");
        }
    }
}
