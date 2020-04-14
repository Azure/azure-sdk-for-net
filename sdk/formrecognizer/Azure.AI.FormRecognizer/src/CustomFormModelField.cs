// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// A field that the model will extract from forms it analyzes.
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
        /// Unique name of the field.
        /// </summary>
        [CodeGenMember("FieldName")]
        public string Name { get; }

        /// <summary>
        /// Estimated extraction accuracy for this field.
        /// </summary>
        [CodeGenMember("Accuracy")]
        public float? Accuracy { get; }

        /// <summary>
        /// The form fields label on the form.
        /// </summary>
        public string Label { get; }
    }
}
