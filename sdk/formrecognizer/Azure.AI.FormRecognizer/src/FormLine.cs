// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a line of text recognized from the input document.
    /// </summary>
    public class FormLine : FormElement
    {
        internal FormLine(TextLine textLine, int pageNumber)
            : base(new BoundingBox(textLine.BoundingBox), pageNumber, textLine.Text)
        {
            Words = ConvertWords(textLine.Words, pageNumber);
        }

        /// <summary>
        /// A list of the words that make up the line.
        /// </summary>
        public IReadOnlyList<FormWord> Words { get; }

        private static IReadOnlyList<FormWord> ConvertWords(IReadOnlyList<TextWord> textWords, int pageNumber)
        {
            List<FormWord> rawWords = new List<FormWord>();

            foreach (TextWord textWord in textWords)
            {
                rawWords.Add(new FormWord(textWord, pageNumber));
            }

            return rawWords;
        }
    }
}
