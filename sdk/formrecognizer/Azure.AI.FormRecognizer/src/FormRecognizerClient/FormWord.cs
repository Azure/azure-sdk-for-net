// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a word recognized from the input document.
    /// </summary>
    public class FormWord : FormElement
    {
        internal FormWord(TextWord textWord, int pageNumber)
            : base(new FieldBoundingBox(textWord.BoundingBox), pageNumber, textWord.Text)
        {
            Confidence = textWord.Confidence ?? Constants.DefaultConfidenceValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormWord"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="confidence">Measures the degree of certainty of the recognition result.</param>
        internal FormWord(FieldBoundingBox boundingBox, int pageNumber, string text, float confidence)
            : base(boundingBox, pageNumber, text)
        {
            Confidence = confidence;
        }

        /// <summary>
        /// Measures the degree of certainty of the recognition result. Value is between [0.0, 1.0].
        /// </summary>
        public float Confidence { get; }
    }
}
