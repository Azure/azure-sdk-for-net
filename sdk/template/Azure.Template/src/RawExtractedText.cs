// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    public class RawExtractedItem
    {
        public BoundingBox BoundingBox { get; internal set; }
        public string Text { get; internal set; }
    }
}
