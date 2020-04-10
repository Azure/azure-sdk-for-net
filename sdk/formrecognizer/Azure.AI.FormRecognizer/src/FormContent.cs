// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
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
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// The 1-based page number in the input document.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// </summary>
        public string Text { get; }
    }
}
