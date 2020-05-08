// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Represents a field that a model will extract from forms it analyzes. A form field includes
    /// a name unique to the submodel, a field label representing the label of the field on the form,
    /// and, if a model was trained with training-time labels, an estimated accuracy for recognition
    /// of the field.
    /// </summary>
    [CodeGenModel("FormFieldsReport")]
    public partial class CustomFormModelField
    {
        internal CustomFormModelField(string name, string label, float? accuracy)
        {
            Name = name;
            Label = label;
            Accuracy = accuracy;
        }

        /// <summary>
        /// Canonical name; uniquely identifies a field within the form.
        /// </summary>
        [CodeGenMember("FieldName")]
        public string Name { get; }

        /// <summary>
        /// The estimated recognition accuracy for this field.
        /// </summary>
        [CodeGenMember("Accuracy")]
        public float? Accuracy { get; }

        /// <summary>
        /// The label of this field on the form.
        /// </summary>
        public string Label { get; }
    }
}
