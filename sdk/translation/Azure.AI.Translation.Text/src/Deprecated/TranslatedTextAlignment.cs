// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Translation.Text
{
    /// <summary> Alignment information object. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    public class TranslatedTextAlignment
    {
        /// <summary> Initializes a new instance of TranslatedTextAlignment. </summary>
        internal TranslatedTextAlignment() { }

        /// <summary>
        /// Maps input text to translated text. The alignment information is only provided when the request
        /// parameter includeAlignment is true. Alignment is returned as a string value of the following
        /// format: [[SourceTextStartIndex]:[SourceTextEndIndex]–[TgtTextStartIndex]:[TgtTextEndIndex]].
        /// The colon separates start and end index, the dash separates the languages, and space separates the words.
        /// One word may align with zero, one, or multiple words in the other language, and the aligned words may
        /// be non-contiguous. When no alignment information is available, the alignment element will be empty.
        /// </summary>
        public string Projections { get; }
    }
}
