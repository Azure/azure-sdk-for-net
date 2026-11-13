// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Translation.Text
{
    /// <summary> Translation result. </summary>
    // Partial class to hold deprecated members.
    public partial class TranslationText
    {
        /// <summary> An object giving the translated text in the script specified by the toScript parameter. </summary>
        [Obsolete("Transliteration is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransliteratedText Transliteration { get; }

        /// <summary> A string representing the language code of the target language. </summary>
        [Obsolete("TargetLanguage is deprecated. Use Language instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TargetLanguage { get; }

        /// <summary> Alignment information. </summary>
        [Obsolete("Alignment is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TranslatedTextAlignment Alignment { get; }

        /// <summary> Sentence boundaries in the input and output texts. </summary>
        [Obsolete("SentenceBoundaries is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)] public SentenceBoundaries SentenceBoundaries { get; }
    }
}
