// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Properties ot the source dictionary language. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SourceDictionaryLanguage : IJsonModel<SourceDictionaryLanguage>
    {
        /// <summary> Initializes a new instance of SourceDictionaryLanguage. </summary>
        internal SourceDictionaryLanguage() { }

        /// <summary> Display name of the language in the locale requested via Accept-Language header. </summary>
        public string Name { get; }
        /// <summary> Display name of the language in the locale native for this language. </summary>
        public string NativeName { get; }
        /// <summary> Directionality, which is rtl for right-to-left languages or ltr for left-to-right languages. </summary>
        public LanguageDirectionality Directionality { get; }
        /// <summary> List of languages with alterative translations and examples for the query expressed in the source language. </summary>
        public IReadOnlyList<TargetDictionaryLanguage> Translations { get; }

        SourceDictionaryLanguage IJsonModel<SourceDictionaryLanguage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceDictionaryLanguage is deprecated and not supported.");
        }

        SourceDictionaryLanguage IPersistableModel<SourceDictionaryLanguage>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceDictionaryLanguage is deprecated and not supported.");
        }

        string IPersistableModel<SourceDictionaryLanguage>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceDictionaryLanguage is deprecated and not supported.");
        }

        void IJsonModel<SourceDictionaryLanguage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceDictionaryLanguage is deprecated and not supported.");
        }

        BinaryData IPersistableModel<SourceDictionaryLanguage>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SourceDictionaryLanguage is deprecated and not supported.");
        }
    }
}
