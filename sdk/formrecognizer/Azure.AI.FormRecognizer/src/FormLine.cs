// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormLine : FormContent
    {
        internal FormLine(TextLine_internal textLine, int pageNumber) : base(new BoundingBox(textLine.BoundingBox), pageNumber, textLine.Text)
        {
            Words = ConvertWords(textLine.Words, pageNumber);
        }

        /// <summary> List of words in the text line. </summary>
        public IReadOnlyList<RawExtractedWord> Words { get; internal set; }

        private static IReadOnlyList<RawExtractedWord> ConvertWords(IReadOnlyList<TextWord_internal> textWords, int pageNumber)
        {
            List<RawExtractedWord> rawWords = new List<RawExtractedWord>();

            foreach (TextWord_internal textWord in textWords)
            {
                rawWords.Add(new RawExtractedWord(textWord, pageNumber));
            }

            return rawWords;
        }
    }
}
