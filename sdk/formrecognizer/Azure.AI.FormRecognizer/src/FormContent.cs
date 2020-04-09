// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public abstract class FormContent
    {
        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// </summary>
        public string Text { get; }

        internal FormContent(BoundingBox boundingBox, int pageNumber, string text)
        {
            BoundingBox = boundingBox;
            PageNumber = pageNumber;
            Text = text;
        }
    }
}
