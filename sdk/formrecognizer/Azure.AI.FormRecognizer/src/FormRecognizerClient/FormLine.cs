// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a line of text and its appearance.
    /// </summary>
    public class FormLine : FormElement
    {
        internal FormLine(TextLine textLine, int pageNumber)
            : base(new FieldBoundingBox(textLine.BoundingBox), pageNumber, textLine.Text)
        {
            Words = ConvertWords(textLine.Words, pageNumber);
            Appearance = textLine.Appearance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormLine"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="words">A list of the words that make up the line.</param>
        /// <param name="appearance">An object representing the appearance of the text line.</param>
        internal FormLine(FieldBoundingBox boundingBox, int pageNumber, string text, IReadOnlyList<FormWord> words, TextAppearance appearance)
            : base(boundingBox, pageNumber, text)
        {
            Words = words;
            Appearance = appearance;
        }

        /// <summary>
        /// A list of the words that make up the line.
        /// </summary>
        public IReadOnlyList<FormWord> Words { get; }

        /// <summary>
        /// An object representing the appearance of the text line.
        /// </summary>
        /// <remarks>
        /// This property only has value for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> and newer.
        /// </remarks>
        public TextAppearance Appearance { get; }

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
