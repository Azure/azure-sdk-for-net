// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Properties of a model, such as whether the model is a composed model or not.
    /// </summary>
    [CodeGenModel("Attributes")]
    public partial class CustomFormModelProperties
    {
        /// <summary>
        /// Indicates if the model is a composed model.
        /// </summary>
        [CodeGenMember("IsComposed")]
        public bool IsComposedModel { get; }
    }
}
