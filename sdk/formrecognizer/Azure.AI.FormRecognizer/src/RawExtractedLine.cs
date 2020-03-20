// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RawExtractedLine : RawExtractedItem
    {
        internal RawExtractedLine(TextLine_internal textLine)
        {
            Text = textLine.Text;
            BoundingBox = new BoundingBox(textLine.BoundingBox);
            Words = ConvertWords(textLine.Words);
        }

        /// <summary> List of words in the text line. </summary>
        public IReadOnlyList<RawExtractedWord> Words { get; internal set; }

        /// <summary>
        /// </summary>
        public static implicit operator string(RawExtractedLine line) => line.Text;

        private static IReadOnlyList<RawExtractedWord> ConvertWords(ICollection<TextWord_internal> textWords)
        {
            List<RawExtractedWord> rawWords = new List<RawExtractedWord>();

            foreach (TextWord_internal textWord in textWords)
            {
                rawWords.Add(new RawExtractedWord(textWord));
            }

            return rawWords;
        }
    }
}
