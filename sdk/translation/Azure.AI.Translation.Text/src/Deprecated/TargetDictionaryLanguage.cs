// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Properties of the target dictionary language. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TargetDictionaryLanguage : IJsonModel<TargetDictionaryLanguage>
    {
        /// <summary> Initializes a new instance of TargetDictionaryLanguage. </summary>
        internal TargetDictionaryLanguage() { }

        /// <summary> Display name of the language in the locale requested via Accept-Language header. </summary>
        public string Name { get; }
        /// <summary> Display name of the language in the locale native for this language. </summary>
        public string NativeName { get; }
        /// <summary> Directionality, which is rtl for right-to-left languages or ltr for left-to-right languages. </summary>
        public LanguageDirectionality Directionality { get; }
        /// <summary> Language code identifying the target language. </summary>
        public string Code { get; }

        TargetDictionaryLanguage IJsonModel<TargetDictionaryLanguage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("TargetDictionaryLanguage is deprecated and not supported.");
        }

        TargetDictionaryLanguage IPersistableModel<TargetDictionaryLanguage>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("TargetDictionaryLanguage is deprecated and not supported.");
        }

        string IPersistableModel<TargetDictionaryLanguage>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("TargetDictionaryLanguage is deprecated and not supported.");
        }

        void IJsonModel<TargetDictionaryLanguage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("TargetDictionaryLanguage is deprecated and not supported.");
        }

        BinaryData IPersistableModel<TargetDictionaryLanguage>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("TargetDictionaryLanguage is deprecated and not supported.");
        }
    }
}
