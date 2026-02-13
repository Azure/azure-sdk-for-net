// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Helper class for creating and managing Foundry agents in tests.
    /// Matches the JavaScript testAgent infrastructure patterns.
    /// </summary>
    public static class TestAgent
    {
        private static VoiceLiveFoundryAgentDefinition? _cachedFoundryAgent;

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
        /// This is the primary way to create agent-based sessions.
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
        /// Gets a cached Foundry agent definition, creating it if necessary.
        /// Reuses the same agent across all tests.
        /// </summary>
        /// <param name="testEnvironment">The test environment containing configuration.</param>
        /// <returns>A cached VoiceLiveFoundryAgentDefinition.</returns>
        public static VoiceLiveFoundryAgentDefinition GetOrCreateCachedFoundryAgent(
            VoiceLiveTestEnvironment testEnvironment)
        {
            return _cachedFoundryAgent ??= CreateFoundryAgentTool(testEnvironment);
        }

        /// <summary>
        /// Creates a VoiceLiveFoundryAgentDefinition tool for use in VoiceLive sessions.
        /// Equivalent to JS createFoundryAgentTool function.
        /// </summary>
        /// <param name="testEnvironment">The test environment containing configuration.</param>
        /// <param name="agentName">Optional override for agent name.</param>
        /// <param name="projectName">Optional override for project name.</param>
        /// <param name="description">Optional override for description.</param>
        /// <returns>A configured VoiceLiveFoundryAgentDefinition.</returns>
        public static VoiceLiveFoundryAgentDefinition CreateFoundryAgentTool(
            VoiceLiveTestEnvironment testEnvironment,
            string? agentName = null,
            string? projectName = null,
            string? description = null)
        {
            var finalAgentName = agentName
                ?? (!string.IsNullOrEmpty(testEnvironment.AgentName)
                    ? testEnvironment.AgentName
                    : TestConstants.TestAgentName);
            var finalProjectName = projectName ?? GetProjectName(testEnvironment);

            // Extract region from endpoint if possible
            var endpoint = GetProjectEndpoint(testEnvironment);
            if (endpoint.Contains("."))
            {
                var parts = endpoint.Split('.');
                if (parts.Length > 1)
                {
                    Console.WriteLine($"  Endpoint Region/Service: {string.Join(".", parts)}");
                }
            }

            var agent = new VoiceLiveFoundryAgentDefinition(
                agentName: finalAgentName,
                projectName: finalProjectName)
            {
                AgentVersion = TestConstants.TestAgentVersion,
                AgentContextType = FoundryAgentContextType.AgentContext,
                ReturnAgentResponseDirectly = false
            };

            if (description != null)
            {
                agent.Description = description;
            }
            else if (!string.IsNullOrEmpty(TestConstants.TestAgentDescription))
            {
                agent.Description = TestConstants.TestAgentDescription;
            }

            return agent;
        }

        /// <summary>
        /// Clears the cached Foundry agent definition.
        /// </summary>
        public static void ClearCachedFoundryAgent()
        {
            _cachedFoundryAgent = null;
        }
    }
}
