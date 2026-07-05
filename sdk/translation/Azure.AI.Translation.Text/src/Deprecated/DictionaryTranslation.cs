// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.AI.Translation.Text
{
    /// <summary> Translation source term. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DictionaryTranslation : IJsonModel<DictionaryTranslation>
    {
        /// <summary> Initializes a new instance of DictionaryTranslation. </summary>
        internal DictionaryTranslation() { }

        /// <summary>
        /// A string giving the normalized form of this term in the target language.
        /// This value should be used as input to lookup examples.
        /// </summary>
        public string NormalizedTarget { get; }
        /// <summary>
        /// A string giving the term in the target language and in a form best suited
        /// for end-user display. Generally, this will only differ from the normalizedTarget
        /// in terms of capitalization. For example, a proper noun like "Juan" will have
        /// normalizedTarget = "juan" and displayTarget = "Juan".
        /// </summary>
        public string DisplayTarget { get; }
        /// <summary> A string associating this term with a part-of-speech tag. </summary>
        public string PosTag { get; }
        /// <summary>
        /// A value between 0.0 and 1.0 which represents the "confidence"
        /// (or perhaps more accurately, "probability in the training data") of that translation pair.
        /// The sum of confidence scores for one source word may or may not sum to 1.0.
        /// </summary>
        public float Confidence { get; }
        /// <summary>
        /// A string giving the word to display as a prefix of the translation. Currently,
        /// this is the gendered determiner of nouns, in languages that have gendered determiners.
        /// For example, the prefix of the Spanish word "mosca" is "la", since "mosca" is a feminine noun in Spanish.
        /// This is only dependent on the translation, and not on the source.
        /// If there is no prefix, it will be the empty string.
        /// </summary>
        public string PrefixWord { get; }
        /// <summary>
        /// A list of "back translations" of the target. For example, source words that the target can translate to.
        /// The list is guaranteed to contain the source word that was requested (e.g., if the source word being
        /// looked up is "fly", then it is guaranteed that "fly" will be in the backTranslations list).
        /// However, it is not guaranteed to be in the first position, and often will not be.
        /// </summary>
        public IReadOnlyList<BackTranslation> BackTranslations { get; }

        DictionaryTranslation IJsonModel<DictionaryTranslation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryTranslation is deprecated and not supported.");
        }

        DictionaryTranslation IPersistableModel<DictionaryTranslation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryTranslation is deprecated and not supported.");
        }

        string IPersistableModel<DictionaryTranslation>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryTranslation is deprecated and not supported.");
        }

        void IJsonModel<DictionaryTranslation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryTranslation is deprecated and not supported.");
        }

        BinaryData IPersistableModel<DictionaryTranslation>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("DictionaryTranslation is deprecated and not supported.");
        }
    }
}
