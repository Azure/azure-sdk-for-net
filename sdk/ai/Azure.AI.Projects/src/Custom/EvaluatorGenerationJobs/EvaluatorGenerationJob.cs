// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
}
