// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedField
    {
        internal ExtractedField(KeyValuePair_internal field)
        {
            // Unsupervised
            Confidence = field.Confidence;
            Label = field.Key.Text;

            // TODO: Better way to handle nulls here?
            LabelOutline = field.Key.BoundingBox == null ? null : new BoundingBox(field.Key.BoundingBox);
            if (field.Key.Elements != null)
            {
                LabelRawWordReferences = ConvertWordReferences(field.Key.Elements);
            }

            Value = field.Value.Text;
            ValueOutline = new BoundingBox(field.Value.BoundingBox);

            if (field.Value.Elements != null)
            {
                ValueRawWordReferences = ConvertWordReferences(field.Value.Elements);
            }
        }

        internal ExtractedField(KeyValuePair<string, FieldValue_internal> field)
        {
            // Supervised
            Confidence = field.Value.Confidence;
            Label = field.Key;
            Value = field.Value.Text;
            ValueOutline = new BoundingBox(field.Value.BoundingBox);
        }

        private ExtractedField() { }

        // TODO: Why can this be nullable on FieldValue.Confidence?
        public float? Confidence { get; internal set; }
        public string Label { get; internal set; }

        // TODO: Make this nullable - how?
        public BoundingBox LabelOutline { get; internal set; }

        ///public RawExtractedLine RawFieldExtraction { get; internal set; }
        public string Value { get; internal set; }
        public BoundingBox ValueOutline { get; internal set; }

        // TODO: Set this
        public IReadOnlyList<RawExtractedWordReference> LabelRawWordReferences { get; internal set; }
        public IReadOnlyList<RawExtractedWordReference> ValueRawWordReferences { get; internal set; }

        private static IReadOnlyList<RawExtractedWordReference> ConvertWordReferences(ICollection<string> elements)
        {
            List<RawExtractedWordReference> references = new List<RawExtractedWordReference>();
            foreach (var element in elements)
            {
                references.Add(new RawExtractedWordReference(element));
            }
            return references.AsReadOnly();
        }
    }
}
