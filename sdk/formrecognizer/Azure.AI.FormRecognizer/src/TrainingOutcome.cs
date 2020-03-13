// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Custom
{
    [CodeGenSchema("TrainStatus")]
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum TrainingOutcome
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        Succeeded,
        PartiallySucceeded,
        Failed,
    }
}
