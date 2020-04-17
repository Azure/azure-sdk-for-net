// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormLine : FormContent
    {
        internal FormLine(TextLine_internal textLine, int pageNumber)
            : base(new BoundingBox(textLine.BoundingBox), pageNumber, textLine.Text)
        {
            Words = ConvertWords(textLine.Words, pageNumber);
        }

        /// <summary> List of words in the text line. </summary>
        public IReadOnlyList<FormWord> Words { get; internal set; }

        private static IReadOnlyList<FormWord> ConvertWords(IReadOnlyList<TextWord_internal> textWords, int pageNumber)
        {
            List<FormWord> rawWords = new List<FormWord>();

            foreach (TextWord_internal textWord in textWords)
            {
                rawWords.Add(new FormWord(textWord, pageNumber));
            }

            return rawWords;
        }
    }
}
