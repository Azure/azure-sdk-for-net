// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// </summary>
    [CodeGenSchema("TrainStatus")]
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum TrainingStatus
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// </summary>
        Succeeded,

        /// <summary>
        /// </summary>
        PartiallySucceeded,

        /// <summary>
        /// </summary>
        Failed,
    }
}
