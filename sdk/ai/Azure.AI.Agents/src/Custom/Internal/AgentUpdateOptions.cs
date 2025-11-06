// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents;

[CodeGenType("UpdateAgentRequest1")]
internal partial class AgentUpdateOptions
{
    /// <summary> A human-readable description of the agent. </summary>
    [CodeGenMember("Description")]
    public string Description { get; set; }
}
