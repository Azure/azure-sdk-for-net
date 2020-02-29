// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer
{
    public class ExtractedField
    {
        public float Confidence { get; internal set; }
        public string Label { get; internal set; }

        // TODO: How to make these nullable?
        public BoundingBox LabelOutline { get; internal set; }

        ///public RawExtractedLine RawFieldExtraction { get; internal set; }
        public string Value { get; internal set; }
        public BoundingBox ValueOutline { get; internal set; }
    }
}
