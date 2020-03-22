// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{

    /// <summary>
    /// </summary>
    public class RawExtractedItem
    {
        internal RawExtractedItem() { }

        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; internal set; }

        /// <summary>
        /// </summary>
        public string Text { get; internal set; }
    }
}
