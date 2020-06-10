// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Represents a submodel that extracts fields from a specific type of form.
    /// </summary>
    public class CustomFormSubmodel
    {
        internal CustomFormSubmodel(string formType, float? accuracy, IReadOnlyDictionary<string, CustomFormModelField> fields)
        {
            FormType = formType;
            Accuracy = accuracy;
            Fields = fields;
        }

        /// <summary>
        /// The type of form this submodel recognizes.
        /// </summary>
        public string FormType { get; }

        /// <summary>
        /// The mean of the accuracies of this model's <see cref="CustomFormModelField"/>
        /// instances.
        /// </summary>
        public float? Accuracy { get; }

        /// <summary>
        /// A dictionary of the fields that this submodel will recognize from the
        /// input document. The key is the <see cref="CustomFormModelField.Name"/>
        /// of the field. For models trained with labels, this is the training-time
        /// label of the field. For models trained with forms only, a unique name is
        /// generated for each field.
        /// </summary>
        public IReadOnlyDictionary<string, CustomFormModelField> Fields { get; }
    }
}
