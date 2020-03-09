// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedReceiptField
    {
        internal ExtractedReceiptField(FieldValue_internal field)
        {
            Text = field.Text;
            Confidence = field.Confidence;

            if (field.BoundingBox != null)
            {
                BoundingBox = new BoundingBox(field.BoundingBox);
            }
        }

        public string Text { get; internal set; }
        public BoundingBox BoundingBox { get; internal set; }
        public float? Confidence { get; internal set; }
    }
}
