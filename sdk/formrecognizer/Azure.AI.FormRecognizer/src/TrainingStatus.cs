// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Describes the status of a training operation.
    /// </summary>
    [CodeGenModel("TrainStatus")]
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum TrainingStatus
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// The training operation succeeded without errors.
        /// </summary>
        Succeeded,

        /// <summary>
        /// The training operation succeeded, but it finished with errors.
        /// </summary>
        PartiallySucceeded,

        /// <summary>
        /// The training operation failed and the model cannot be used for custom form recognition.
        /// </summary>
        Failed,
    }
}
