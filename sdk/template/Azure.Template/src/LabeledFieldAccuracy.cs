// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    public class LabeledFieldAccuracy
    {
        internal LabeledFieldAccuracy(FormFieldsReport_internal field)
        {
            Accuracy = field.Accuracy;
            Label = field.FieldName;
        }

        public float Accuracy { get; }

        public string Label { get; }
    }
}
