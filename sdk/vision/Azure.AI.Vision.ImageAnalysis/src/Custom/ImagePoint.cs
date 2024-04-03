// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Vision.ImageAnalysis
{
    /// <summary> Represents the coordinates of a single pixel in the image. </summary>
    public partial class ImagePoint
    {
        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
