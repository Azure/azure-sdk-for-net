// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

public partial class AgentOptimizationJob
{
    /// <summary> Error details — populated only on failure. </summary>
    internal FoundryOpenAIError Error { get; }
}
