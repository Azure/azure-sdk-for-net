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
    }
}
