// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a form element recognized from the input document. Its text can be a line,
    /// a word, the content of a table cell, a selection mark, etc.
    /// </summary>
    public abstract class FormElement
    {
        internal FormElement(FieldBoundingBox boundingBox, int pageNumber)
            : this(boundingBox, pageNumber, default) { }

        internal FormElement(FieldBoundingBox boundingBox, int pageNumber, string text)
        {
            BoundingBox = boundingBox;
            PageNumber = pageNumber;
            Text = text;
        }

        /// <summary>
        /// The quadrilateral bounding box that outlines the text of this element. Units are in pixels for
        /// images and inches for PDF. The <see cref="LengthUnit"/> type of a recognized page can be found
        /// at <see cref="FormPage.Unit"/>.
        /// </summary>
        public FieldBoundingBox BoundingBox { get; }

        /// <summary>
        /// The 1-based number of the page in which this element is present.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The text of this form element. It can be a whole line or a single word.
        /// </summary>
        public string Text { get; }
    }
}
