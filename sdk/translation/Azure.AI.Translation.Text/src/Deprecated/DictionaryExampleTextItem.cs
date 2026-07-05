// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Element containing the text with translation. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DictionaryExampleTextItem : InputTextItem, IJsonModel<DictionaryExampleTextItem>
    {
        /// <summary> Initializes a new instance of <see cref="DictionaryExampleTextItem"/>. </summary>
        /// <param name="text"> Text to translate. </param>
        /// <param name="translation">
        /// A string specifying the translated text previously returned by the Dictionary lookup operation.
        /// This should be the value from the normalizedTarget field in the translations list of the Dictionary
        /// lookup response. The service will return examples for the specific source-target word-pair.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="translation"/> is null. </exception>
        public DictionaryExampleTextItem(string text, string translation) : base(text)
        {
            throw new NotSupportedException("DictionaryExampleTextItem is deprecated and not supported.");
        }

        /// <summary>
        /// A string specifying the translated text previously returned by the Dictionary lookup operation.
        /// This should be the value from the normalizedTarget field in the translations list of the Dictionary
        /// lookup response. The service will return examples for the specific source-target word-pair.
        /// </summary>
        public string Translation { get; }

        DictionaryExampleTextItem IJsonModel<DictionaryExampleTextItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleTextItem is deprecated and not supported.");
        }

        DictionaryExampleTextItem IPersistableModel<DictionaryExampleTextItem>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleTextItem is deprecated and not supported.");
        }

        string IPersistableModel<DictionaryExampleTextItem>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleTextItem is deprecated and not supported.");
        }

        void IJsonModel<DictionaryExampleTextItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleTextItem is deprecated and not supported.");
        }

        BinaryData IPersistableModel<DictionaryExampleTextItem>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryExampleTextItem is deprecated and not supported.");
        }
    }
}
