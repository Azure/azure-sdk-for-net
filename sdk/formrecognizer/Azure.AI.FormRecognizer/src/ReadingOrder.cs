// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// Specifies the order in which recognized text lines are returned. As the sorting order
    /// depends on the detected text, it may change across images and OCR version updates. Thus,
    /// business logic should be built upon the actual line location instead of order.
    /// </summary>
    [CodeGenModel("ReadingOrder")]
    public enum ReadingOrder
    {
        /// <summary>
        /// The lines are sorted top to bottom, left to right, although in certain cases
        /// proximity is treated with higher priority.
        /// </summary>
        Basic,

        /// <summary>
        /// The algorithm uses positional information to keep nearby lines together.
        /// </summary>
        Natural
    }
}
