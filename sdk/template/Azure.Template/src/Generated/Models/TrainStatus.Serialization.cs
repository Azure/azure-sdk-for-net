// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Template.Models
{
    internal static class TrainStatusExtensions
    {
        public static string ToSerialString(this TrainStatus value) => value switch
        {
            TrainStatus.Succeeded => "succeeded",
            TrainStatus.PartiallySucceeded => "partiallySucceeded",
            TrainStatus.Failed => "failed",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TrainStatus value.")
        };

        public static TrainStatus ToTrainStatus(this string value) => value switch
        {
            "succeeded" => TrainStatus.Succeeded,
            "partiallySucceeded" => TrainStatus.PartiallySucceeded,
            "failed" => TrainStatus.Failed,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TrainStatus value.")
        };
    }
}
