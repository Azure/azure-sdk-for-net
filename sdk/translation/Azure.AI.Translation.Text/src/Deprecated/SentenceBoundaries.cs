// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.AI.Translation.Text
{
    /// <summary> An object returning sentence boundaries in the input and output texts. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SentenceBoundaries
    {
        /// <summary> Initializes a new instance of SentenceBoundaries. </summary>
        internal SentenceBoundaries() { }

        /// <summary>
        /// An integer array representing the lengths of the sentences in the input text.
        /// The length of the array is the number of sentences, and the values are the length of each sentence.
        /// </summary>
        public IReadOnlyList<int> SourceSentencesLengths { get; }
        /// <summary>
        /// An integer array representing the lengths of the sentences in the translated text.
        /// The length of the array is the number of sentences, and the values are the length of each sentence.
        /// </summary>
        public IReadOnlyList<int> TranslatedSentencesLengths { get; }
    }
}
