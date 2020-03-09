// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
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
