// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    public class RawExtractedItem
    {
        internal RawExtractedItem() { }

        public BoundingBox BoundingBox { get; internal set; }
        public string Text { get; internal set; }
    }
}
