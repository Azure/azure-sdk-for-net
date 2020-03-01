// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Information about the extracted key or value in a key-value pair. </summary>
    internal partial class KeyValueElement_internal
    {
        /// <summary> The text content of the key or value. </summary>
        public string Text { get; set; }
        /// <summary> Quadrangle bounding box, with coordinates specified relative to the top-left of the original image. The eight numbers represent the four points, clockwise from the top-left corner relative to the text orientation. For image, the (x, y) coordinates are measured in pixels. For PDF, the (x, y) coordinates are measured in inches. </summary>
        public ICollection<float> BoundingBox { get; set; }
        /// <summary> When includeTextDetails is set to true, a list of references to the text elements constituting this key or value. </summary>
        public ICollection<string> Elements { get; set; }
    }
}
