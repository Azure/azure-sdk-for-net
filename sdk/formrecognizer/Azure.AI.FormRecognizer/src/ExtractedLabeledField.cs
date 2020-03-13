// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    // Maps to FieldValue in swagger.
    public class ExtractedLabeledField
    {
        internal ExtractedLabeledField(KeyValuePair<string, FieldValue_internal> field, IList<ReadResult_internal> readResults)
        {
            // Supervised
            Confidence = field.Value.Confidence;
            PageNumber = field.Value.Page;
            Label = field.Key;
            Value = field.Value.Text;
            ValueBoundingBox = new BoundingBox(field.Value.BoundingBox);

            if (field.Value.Elements != null)
            {
                RawExtractedItems = ExtractedField.ConvertTextReferences(readResults, field.Value.Elements);
            }

            // TODO: Add strongly-typed value
            // https://github.com/Azure/azure-sdk-for-net/issues/10333
        }

        // TODO: Why can this be nullable on FieldValue.Confidence?
        // https://github.com/Azure/azure-sdk-for-net/issues/10378
        public float? Confidence { get; internal set; }

        public int? PageNumber { get; internal set; }

        public string Label { get; internal set; }

        public string Value { get; internal set; }

        public BoundingBox ValueBoundingBox { get; internal set; }

        public IReadOnlyList<RawExtractedItem> RawExtractedItems { get; internal set; }
    }
}
