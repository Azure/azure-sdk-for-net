// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework
{
    /// <summary>
    /// Interface for building workflow-based AI agents.
    /// User provides implementation to build the workflow agent.
    /// </summary>
    public interface IWorkflowAgentFactory
    {
        /// <summary>
        /// Creates and returns a configured AIAgent workflow.
        /// </summary>
        /// <returns>The constructed AIAgent instance representing the workflow.</returns>
        public AIAgent BuildWorkflow();
    }
}
