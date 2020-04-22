// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Represents a submodel that extracts fields from a specific type of form.
    /// </summary>
    public class CustomFormSubModel
    {
        internal CustomFormSubModel(string formType, float? accuracy, IReadOnlyDictionary<string, CustomFormModelField> fields)
        {
            FormType = formType;
            Accuracy = accuracy;
            Fields = fields;
        }

        /// <summary>
        /// The type of form this submodel recognizes.
        /// </summary>
        public string FormType { get; internal set; }

        /// <summary>
        /// The mean of the accuracies of this model's <see cref="CustomFormModelField"/>
        /// instances.
        /// </summary>
        public float? Accuracy { get; internal set; }

        /// <summary>
        /// A dictionary of the key-value pairs that this submodel will recognize from the
        /// input document. Labeled models will use pre-defined labels as keys, and a unique
        /// key will be generated for <see cref="CustomFormModelField"/> instances with no
        /// pre-defined label available.
        /// </summary>
        public IReadOnlyDictionary<string, CustomFormModelField> Fields { get; internal set; }
    }
}
