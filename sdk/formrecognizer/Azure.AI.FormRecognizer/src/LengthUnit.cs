// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The unit used by the width, height and bounding boxes of a <see cref="DocumentPage"/>. For images, the unit is
    /// pixel. For PDF, the unit is inch.
    /// </summary>
    public enum LengthUnit
    {
        /// <summary>
        /// Pixel.
        /// </summary>
        Pixel,

        /// <summary>
        /// Inch.
        /// </summary>
        Inch
    }
}
