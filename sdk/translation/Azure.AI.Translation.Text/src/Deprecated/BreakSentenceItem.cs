// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Translation.Text
{
    /// <summary> Item containing break sentence result. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    public class BreakSentenceItem
    {
        /// <summary> The detectedLanguage property is only present in the result object when language auto-detection is requested. </summary>
        public DetectedLanguage DetectedLanguage { get; }
        /// <summary>
        /// An integer array representing the lengths of the sentences in the input text.
        /// The length of the array is the number of sentences, and the values are the length of each sentence.
        /// </summary>
        public IReadOnlyList<int> SentencesLengths { get; }
    }
}
