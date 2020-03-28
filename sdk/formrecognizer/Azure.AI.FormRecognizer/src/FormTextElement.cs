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
        internal FormContent(string text, BoundingBox boundingBox)
        {
            BoundingBox = boundingBox;
            Text = text;
        }

        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// </summary>
        public string Text { get; }
    }
}
