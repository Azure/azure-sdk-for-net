// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    [CodeGenModel("Appearance")]
    public partial class TextAppearance
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TextAppearance"/>. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        internal TextAppearance(TextStyleName styleName, float styleConfidence)
        {
            Style = new Style(styleName, styleConfidence);
        }

        /// <summary>
        /// An object representing the style of the text line.
        /// </summary>
        internal Style Style { get; }

        /// <summary>
        /// The text line style name, including handwriting and other.
        /// </summary>
        public TextStyleName StyleName => Style.Name;

        /// <summary>
        /// The confidence of text line style.
        /// </summary>
        public float StyleConfidence => Style.Confidence;
    }
}
