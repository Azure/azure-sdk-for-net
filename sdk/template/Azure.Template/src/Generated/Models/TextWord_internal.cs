// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> An object representing a word. </summary>
    internal partial class TextWord_internal
    {
        /// <summary> The text content of the word. </summary>
        public string Text { get; set; }
        /// <summary> Quadrangle bounding box, with coordinates specified relative to the top-left of the original image. The eight numbers represent the four points, clockwise from the top-left corner relative to the text orientation. For image, the (x, y) coordinates are measured in pixels. For PDF, the (x, y) coordinates are measured in inches. </summary>
        public ICollection<float> BoundingBox { get; set; } = new List<float>();
        /// <summary> Confidence value. </summary>
        public float? Confidence { get; set; }
    }
}
