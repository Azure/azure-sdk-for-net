// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.OpenAI.Tests.Models
{
    public class FineTuningCheckpoint : FineTuningModelBase
    {
        public DateTimeOffset CreatedAt { get; init; }
        public string? FineTunedModelCheckpoint { get; init; }
        public string? FineTuningJobID { get; init; }
        public int StepNumber { get; init; }
        public MetricsInfo Metrics { get; init; } = new MetricsInfo();

        public class MetricsInfo
        {
            public int Step { get; init; }
            public float TrainLoss { get; init; }
            public float TrainMeanTokenAccuracy { get; init; }
            public float ValidLoss { get; init; }
            public float ValidMeanTokenAccuracy { get; init; }
            public float FullValidLoss { get; init; }
            public float FullValidMeanTokenAccuracy { get; init; }
        }
    }
}
