// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Vision.ImageAnalysis
{
    /// <summary> A basic rectangle specifying a sub-region of the image. </summary>
    public partial class ImageBoundingBox
    {
        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Top: {Y}, Left: {X}, Width: {Width}, Height: {Height}";
        }
    }
}
