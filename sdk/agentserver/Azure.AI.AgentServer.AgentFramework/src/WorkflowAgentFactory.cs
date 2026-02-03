// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework
{
    /// <summary>
    /// A factory delegate for creating workflow-based AI agents.
    /// </summary>
    /// <returns>A Workflow-based AI agent.</returns>
    public delegate Task<AIAgent> WorkflowAgentFactory();
}
