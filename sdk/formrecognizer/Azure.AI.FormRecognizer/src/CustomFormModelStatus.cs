// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Describes the status of a custom model.
    /// </summary>
    [CodeGenModel("ModelStatus")]
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum CustomFormModelStatus
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// The model cannot be used for form recognition.
        /// </summary>
        Invalid,

        /// <summary>
        /// The model is ready to be used for form recognition.
        /// </summary>
        Ready,

        /// <summary>
        /// The model is being created. Its status will be updated once it finishes.
        /// </summary>
        Creating
    }
}
