// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    public class LabeledFieldAccuracy
    {
        public LabeledFieldAccuracy(FormFieldsReport field)
        {
            Accuracy = field.Accuracy;
            Label = field.FieldName;
        }

        public float Accuracy { get; }

        public string Label { get; }
    }
}
