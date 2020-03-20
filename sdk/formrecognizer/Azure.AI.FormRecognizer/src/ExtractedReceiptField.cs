// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
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

        /// <summary>
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; internal set; }

        /// <summary>
        /// </summary>
        public float? Confidence { get; internal set; }
    }
}
