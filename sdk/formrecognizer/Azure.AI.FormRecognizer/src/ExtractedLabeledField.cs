// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    // Maps to FieldValue in swagger.
    public class ExtractedLabeledField
    {
        internal ExtractedLabeledField(KeyValuePair<string, FieldValue_internal> field, ReadResult_internal readResult)
        {
            // Supervised
            Confidence = field.Value.Confidence;
            Label = field.Key;
            Value = field.Value.Text;
            ValueBoundingBox = new BoundingBox(field.Value.BoundingBox);
            RawExtractedItems = ExtractedField.ConvertTextReferences(readResult, field.Value.Elements);

            // TODO: Add strongly-typed value
            // https://github.com/Azure/azure-sdk-for-net/issues/10333
        }

        // TODO: Why can this be nullable on FieldValue.Confidence?
        // https://github.com/Azure/azure-sdk-for-net/issues/10378
        public float? Confidence { get; internal set; }

        public string Label { get; internal set; }

        public string Value { get; internal set; }

        public BoundingBox ValueBoundingBox { get; internal set; }

        public IReadOnlyList<RawExtractedItem> RawExtractedItems { get; internal set; }
    }
}
