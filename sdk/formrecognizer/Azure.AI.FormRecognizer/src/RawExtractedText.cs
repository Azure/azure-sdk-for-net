// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public readonly struct FieldText
    {
        /// <summary>
        /// </summary>
        /// <param name="textElements"></param>
        /// <param name="boundingBox"></param>
        /// <param name="text"></param>
        internal FieldText(string text, BoundingBox boundingBox, IReadOnlyList<FormContent> textElements)
        {
            BoundingBox = boundingBox;
            Text = text;
            TextContent = textElements;
        }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormContent> TextContent { get; }

        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// </summary>
        /// <param name="text"></param>
        public static implicit operator string(FieldText text) => text.Text;
    }
}
