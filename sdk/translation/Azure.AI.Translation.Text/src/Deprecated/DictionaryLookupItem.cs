// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Dictionary Lookup Element. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DictionaryLookupItem : IJsonModel<DictionaryLookupItem>
    {
        /// <summary> Initializes a new instance of DictionaryLookupItem. </summary>
        internal DictionaryLookupItem() { }

        /// <summary>
        /// A string giving the normalized form of the source term.
        /// For example, if the request is "JOHN", the normalized form will be "john".
        /// The content of this field becomes the input to lookup examples.
        /// </summary>
        public string NormalizedSource { get; }
        /// <summary>
        /// A string giving the source term in a form best suited for end-user display.
        /// For example, if the input is "JOHN", the display form will reflect the usual
        /// spelling of the name: "John".
        /// </summary>
        public string DisplaySource { get; }
        /// <summary> A list of translations for the source term. </summary>
        public IReadOnlyList<DictionaryTranslation> Translations { get; }

        DictionaryLookupItem IJsonModel<DictionaryLookupItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryLookupItem is deprecated and not supported.");
        }

        DictionaryLookupItem IPersistableModel<DictionaryLookupItem>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryLookupItem is deprecated and not supported.");
        }

        string IPersistableModel<DictionaryLookupItem>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryLookupItem is deprecated and not supported.");
        }

        void IJsonModel<DictionaryLookupItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryLookupItem is deprecated and not supported.");
        }

        BinaryData IPersistableModel<DictionaryLookupItem>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryLookupItem is deprecated and not supported.");
        }
    }
}
