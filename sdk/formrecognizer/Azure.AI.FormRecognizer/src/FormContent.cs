// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a general content recognized from the input document. Its text can be a whole line
    /// or a single word.
    /// </summary>
    public abstract class FormContent
    {
        internal FormContent(BoundingBox boundingBox, int pageNumber, string text)
        {
            BoundingBox = boundingBox;
            PageNumber = pageNumber;
            Text = text;
        }

        /// <summary>
        /// The quadrangle bounding box that outlines the text of this content. Units are in pixels for
        /// images and inches for PDF.
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// The 1-based number of the page in which this content is present.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The text string that constitutes this content. It can be a whole line or a single word.
        /// </summary>
        public string Text { get; }
    }
}
