// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.Evaluation;

[CodeGenType("EvaluatorGenerationJob")]
public partial class EvaluatorGenerationJob
{
    internal FoundryOpenAIError Error { get; }

    /// <summary>
    /// Parse the raw result.
    /// </summary>
    /// <param name="result">The raw JSON, obtained from the service.</param>
    /// <returns></returns>
    public static EvaluatorGenerationJob FromClientResult(ClientResult result)
    {
        return result.ToProjectResult<EvaluatorGenerationJob>();
    }

    /// <summary> The timestamp when the job was created, represented in Unix time (seconds since January 1, 1970). </summary>
    [CodeGenMember("CreatedOn")]
    public DateTimeOffset CreatedAt { get; }

    /// <summary> The timestamp when the job finished, represented in Unix time (seconds since January 1, 1970). </summary>
    [CodeGenMember("FinishedOn")]
    public DateTimeOffset? CompletedAt { get; }
}
