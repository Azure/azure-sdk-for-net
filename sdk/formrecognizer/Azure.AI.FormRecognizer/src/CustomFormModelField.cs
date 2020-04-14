// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// A field that the model was trained on.
    /// </summary>
    [CodeGenModel("FormFieldsReport")]
    public partial class CustomFormModelField
    {
        internal CustomFormModelField(string name, string label, float? accuracy)
            : this(name, accuracy)
        {
            Label = label;
        }
        /// <summary>
        /// Name of the field.
        /// </summary>
        [CodeGenMember("FieldName")]
        public string Name { get; }

        /// <summary>
        /// Estimated extraction accuracy for this field.
        /// </summary>
        [CodeGenMember("Accuracy")]
        public float? Accuracy { get; }

        /// <summary>
        /// Name of label for field.
        /// </summary>
        public string Label { get; }
    }
}
