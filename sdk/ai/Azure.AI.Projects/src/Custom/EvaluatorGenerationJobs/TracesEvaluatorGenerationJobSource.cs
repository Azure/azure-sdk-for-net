// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.Evaluation;

[CodeGenType("TracesEvaluatorGenerationJobSource")]
public partial class TracesEvaluatorGenerationJobSource
{
    /// <summary> Start of the time window (Unix timestamp in seconds) for fetching traces. </summary>
    [CodeGenMember("StartsOn")]
    public DateTimeOffset StartAt { get; set; }

    /// <summary> End of the time window (Unix timestamp in seconds). Defaults to current time. </summary>
    [CodeGenMember("EndsOn")]
    public DateTimeOffset? EndAt { get; set; }
}
