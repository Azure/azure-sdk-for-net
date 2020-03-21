// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class LineTextElement : FormTextElement
    {
        internal LineTextElement(TextLine_internal textLine)
        {
            Text = textLine.Text;
            BoundingBox = new BoundingBox(textLine.BoundingBox);
            Words = ConvertWords(textLine.Words);
        }

        /// <summary> List of words in the text line. </summary>
        public IReadOnlyList<WordTextElement> Words { get; internal set; }

        /// <summary>
        /// </summary>
        public static implicit operator string(LineTextElement line) => line.Text;

        private static IReadOnlyList<WordTextElement> ConvertWords(ICollection<TextWord_internal> textWords)
        {
            List<WordTextElement> rawWords = new List<WordTextElement>();

            foreach (TextWord_internal textWord in textWords)
            {
                rawWords.Add(new WordTextElement(textWord));
            }

            return rawWords;
        }
    }
}
