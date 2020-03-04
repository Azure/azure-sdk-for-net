// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedReceiptField
    {
        internal ExtractedReceiptField(FieldValue_internal field)
        {

            Text = field.Text;
            BoundingBox = new BoundingBox(field.BoundingBox);
            Confidence = field.Confidence;
        }

        public string Text { get; internal set; }
        public BoundingBox BoundingBox { get; internal set; }
        public float? Confidence { get; internal set; }
    }
}
