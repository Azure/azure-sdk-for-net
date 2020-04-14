// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Represents the submodel with model accuracy, any errors while training the model, fields that were
    /// trained on, and the form type.
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
        ///  Identifier of the type of form.
        /// </summary>
        public string FormType { get; internal set; }

        /// <summary>
        /// The average accuracy of the model.
        /// </summary>
        public float? Accuracy { get; internal set; }

        /// <summary>
        /// The fields the model was trained on.
        /// </summary>
        public IReadOnlyDictionary<string, CustomFormModelField> Fields { get; internal set; }

        /// <summary>
        /// Errors returned during the training operation.
        /// </summary>
        public IReadOnlyList<FormRecognizerError> Errors { get; internal set; }
    }
}
