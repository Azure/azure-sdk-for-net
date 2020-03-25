// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormTextElement
    {
        internal FormTextElement(string text, BoundingBox boundingBox, float? confidence)
        {
            Confidence = confidence;
            BoundingBox = boundingBox;
            Text = text;
        }

        /// <summary>
        /// </summary>
        public float? Confidence { get; }

        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// </summary>
        public string Text { get; }
    }
}
