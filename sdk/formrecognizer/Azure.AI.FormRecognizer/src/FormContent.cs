// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public abstract class FormContent
    {
        internal FormContent(string text, BoundingBox boundingBox, int pageNumber)
        {
            BoundingBox = boundingBox;
            Text = text;
            PageNumber = pageNumber;
        }

        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// </summary>
        public int PageNumber { get; }
    }
}
