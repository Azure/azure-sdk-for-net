// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Helper class for creating and managing Foundry agents in tests.
    /// </summary>
    public static class TestAgent
    {
        /// <summary>
        /// Gets the project endpoint from environment variables.
        /// </summary>
        /// <param name="testEnvironment">The test environment containing configuration.</param>
        /// <returns>Project endpoint from environment.</returns>
        /// <exception cref="InvalidOperationException">Thrown when FOUNDRY_PROJECT_ENDPOINT is not set.</exception>
        public static string GetProjectEndpoint(VoiceLiveTestEnvironment testEnvironment)
        {
            if (string.IsNullOrEmpty(testEnvironment.Endpoint))
            {
                throw new InvalidOperationException("Missing FOUNDRY_PROJECT_ENDPOINT environment variable");
            }
            return testEnvironment.Endpoint;
        }

        /// <summary>
        /// Gets the project name from environment variables or constants.
        /// </summary>
        /// <param name="testEnvironment">The test environment containing configuration.</param>
        /// <returns>Project name from environment or constants.</returns>
        public static string GetProjectName(VoiceLiveTestEnvironment testEnvironment)
        {
            return !string.IsNullOrEmpty(testEnvironment.AgentProjectName)
                ? testEnvironment.AgentProjectName
                : TestConstants.TestAgentProjectName;
        }

        /// <summary>
        /// Gets the model name from environment variables or uses default fallback.
        /// </summary>
        /// <param name="testEnvironment">The test environment containing configuration.</param>
        /// <returns>Model name from environment or "gpt-4o" fallback.</returns>
        public static string GetModelName(VoiceLiveTestEnvironment testEnvironment)
        {
            return !string.IsNullOrEmpty(testEnvironment.ModelName)
                ? testEnvironment.ModelName
                : "gpt-4o";
        }

        /// <summary>
        /// Creates an AgentSessionConfig for agent-centric sessions.
        /// This is the primary way to create agent-based sessions where the agent is the main AI actor.
        /// </summary>
        /// <param name="testEnvironment">The test environment containing configuration.</param>
        /// <param name="agentName">Optional override for agent name.</param>
        /// <param name="projectName">Optional override for project name.</param>
        /// <param name="agentVersion">Optional override for agent version.</param>
        /// <param name="conversationId">Optional conversation ID for continuation.</param>
        /// <returns>A configured AgentSessionConfig.</returns>
        public static AgentSessionConfig CreateAgentSessionConfig(
            VoiceLiveTestEnvironment testEnvironment,
            string? agentName = null,
            string? projectName = null,
            string? agentVersion = null,
            string? conversationId = null)
        {
            var finalAgentName = agentName
                ?? (!string.IsNullOrEmpty(testEnvironment.AgentName)
                    ? testEnvironment.AgentName
                    : TestConstants.TestAgentName);
            var finalProjectName = projectName ?? GetProjectName(testEnvironment);

            var agentConfig = new AgentSessionConfig(finalAgentName, finalProjectName)
            {
                AgentVersion = agentVersion ?? TestConstants.TestAgentVersion,
                ConversationId = conversationId
            };

            // Set authentication identity client ID if available
            if (!string.IsNullOrEmpty(testEnvironment.AgentClientId))
            {
                agentConfig.AuthenticationIdentityClientId = testEnvironment.AgentClientId;
            }

            return agentConfig;
        }

        /// <summary>
        /// Creates a SessionTarget for agent-centric sessions using test environment configuration.
        /// This uses the SessionTarget pattern to specify an agent session.
        /// </summary>
        /// <param name="testEnvironment">The test environment containing configuration.</param>
        /// <param name="agentName">Optional override for agent name.</param>
        /// <param name="projectName">Optional override for project name.</param>
        /// <param name="agentVersion">Optional override for agent version.</param>
        /// <param name="conversationId">Optional conversation ID for continuation.</param>
        /// <returns>A configured SessionTarget for an agent session.</returns>
        public static SessionTarget CreateAgentSessionTarget(
            VoiceLiveTestEnvironment testEnvironment,
            string? agentName = null,
            string? projectName = null,
            string? agentVersion = null,
            string? conversationId = null)
        {
            var agentConfig = CreateAgentSessionConfig(testEnvironment, agentName, projectName, agentVersion, conversationId);
            return SessionTarget.FromAgent(agentConfig);
        }

        /// <summary>
        /// Creates a SessionTarget for model-centric sessions.
        /// </summary>
        /// <param name="model">The model name to use (e.g., "gpt-4o-realtime-preview").</param>
        /// <returns>A configured SessionTarget for a model session.</returns>
        public static SessionTarget CreateModelSessionTarget(string model)
        {
            return SessionTarget.FromModel(model);
        }
    }
}