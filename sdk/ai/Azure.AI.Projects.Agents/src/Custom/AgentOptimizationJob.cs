// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;

namespace Azure.AI.Projects.Agents;

public partial class AgentOptimizationJob
{
    /// <summary> Error details — populated only on failure. </summary>
    internal FoundryOpenAIError Error { get; }

    /// <summary>
    /// Parse the raw result.
    /// </summary>
    /// <param name="result">The raw JSON, obtained from the service.</param>
    /// <returns></returns>
    public static AgentOptimizationJob FromClientResult(ClientResult result)
    {
        return result.ToProjectAgentsResult<AgentOptimizationJob>();
    }
}
