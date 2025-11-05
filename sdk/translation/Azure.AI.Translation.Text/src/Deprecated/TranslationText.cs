// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Translation.Text
{
    /// <summary> Translation result. </summary>
    public partial class TranslationText
    {
        /// <summary> An object giving the translated text in the script specified by the toScript parameter. </summary>
        [Obsolete("Transliteration is deprecated and will be removed in a future release.")]
        public TransliteratedText Transliteration { get; }
    }
}
