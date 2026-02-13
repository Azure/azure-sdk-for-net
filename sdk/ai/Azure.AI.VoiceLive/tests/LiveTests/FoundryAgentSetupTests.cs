// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Foundry Agent Connection Integration Tests
    ///
    /// These tests verify that the SDK can correctly configure Foundry agents
    /// and establish connections with the VoiceLive service.
    ///
    /// Foundry agents are AI agents deployed in Azure AI Foundry that can be
    /// integrated into VoiceLive conversations to provide specialized capabilities.
    /// </summary>
    public class FoundryAgentSetupTests : VoiceLiveTestBase
    {
        public FoundryAgentSetupTests() : base(true)
        {
        }

        public FoundryAgentSetupTests(bool isAsync) : base(isAsync)
        {
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldReceiveSessionUpdatedWithFoundryAgent_EnvironmentAgent()
        {
            // This test verifies that the session updated event includes the environment-configured agent
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var foundryAgent = TestAgent.CreateFoundryAgentTool(TestEnvironment);

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(foundryAgent);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.IsNotNull(sessionUpdated.Session);
            Assert.IsNotNull(sessionUpdated.Session.Tools);
            Assert.IsTrue(sessionUpdated.Session.Tools.Count > 0);

            var agentTool = sessionUpdated.Session.Tools.FirstOrDefault(t => t is VoiceLiveFoundryAgentDefinition);
            Assert.IsNotNull(agentTool, "Expected to find a Foundry agent tool in the session configuration");

            var agentDef = agentTool as VoiceLiveFoundryAgentDefinition;
            var expectedAgentName = !string.IsNullOrEmpty(TestEnvironment.AgentName)
                ? TestEnvironment.AgentName
                : TestConstants.TestAgentName;
            Assert.AreEqual(expectedAgentName, agentDef?.AgentName);  // Test environment/constant agent
            Assert.AreEqual(TestConstants.TestAgentProjectName, agentDef?.ProjectName);

            TestContext.WriteLine($"✓ Environment agent '{agentDef?.AgentName}' found in session configuration");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldVerifyAgentConfigurationOptions()
        {
            // This test verifies that all configuration options are properly set on the agent
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var foundryAgent = TestAgent.CreateFoundryAgentTool(TestEnvironment);
            foundryAgent.AgentContextType = FoundryAgentContextType.NoContext;
            foundryAgent.ReturnAgentResponseDirectly = true;

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(foundryAgent);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var agentTool = sessionUpdated.Session.Tools.FirstOrDefault(t => t is VoiceLiveFoundryAgentDefinition) as VoiceLiveFoundryAgentDefinition;
            Assert.IsNotNull(agentTool);

            if (null != agentTool)
            {
                Assert.AreEqual(TestConstants.TestAgentName, agentTool.AgentName);
                Assert.AreEqual(TestConstants.TestAgentProjectName, agentTool.ProjectName);
                Assert.AreEqual(TestConstants.TestAgentVersion, agentTool.AgentVersion);
                Assert.AreEqual(TestConstants.TestAgentDescription, agentTool.Description);
                Assert.AreEqual(FoundryAgentContextType.NoContext, agentTool.AgentContextType);
                Assert.AreEqual(true, agentTool.ReturnAgentResponseDirectly);
            }
            TestContext.WriteLine("✓ All Foundry agent configuration options verified");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldSupportMultipleAgentsInSameSession()
        {
            // This test verifies that multiple Foundry agents can be configured in a single session
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var agent1 = TestAgent.CreateFoundryAgentTool(TestEnvironment, description: "First test agent");
            var agent2 = TestAgent.CreateFoundryAgentTool(TestEnvironment, agentName: TestConstants.TestAgentName + "-2", description: "Second test agent");

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(agent1);
            options.Tools.Add(agent2);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.IsNotNull(sessionUpdated.Session.Tools);

            var agentTools = sessionUpdated.Session.Tools.Where(t => t is VoiceLiveFoundryAgentDefinition).ToList();
            Assert.AreEqual(2, agentTools.Count, $"Expected exactly 2 Foundry agent tools, found {agentTools.Count}");

            var agentNames = agentTools.Cast<VoiceLiveFoundryAgentDefinition>().Select(a => a.AgentName).ToList();
            Assert.Contains(TestConstants.TestAgentName, agentNames, "First agent not found in session tools");
            Assert.Contains(TestConstants.TestAgentName + "-2", agentNames, "Second agent not found in session tools");

            TestContext.WriteLine($"✓ Session configured with {agentTools.Count} Foundry agents: {string.Join(", ", agentNames)}");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldVerifyAgentContextTypeNoContext()
        {
            // This test verifies that NoContext mode works correctly
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var agent = TestAgent.CreateFoundryAgentTool(TestEnvironment);
            agent.AgentContextType = FoundryAgentContextType.NoContext;

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(agent);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var agentTool = sessionUpdated.Session.Tools.FirstOrDefault(t => t is VoiceLiveFoundryAgentDefinition) as VoiceLiveFoundryAgentDefinition;
            Assert.IsNotNull(agentTool);
            Assert.AreEqual(FoundryAgentContextType.NoContext, agentTool?.AgentContextType);

            TestContext.WriteLine("✓ Agent configured with NoContext mode");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldVerifyAgentContextTypeAgentContext()
        {
            // This test verifies that AgentContext mode works correctly
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var agent = TestAgent.CreateFoundryAgentTool(TestEnvironment);
            agent.AgentContextType = FoundryAgentContextType.AgentContext;

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(agent);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var agentTool = sessionUpdated.Session.Tools.FirstOrDefault(t => t is VoiceLiveFoundryAgentDefinition) as VoiceLiveFoundryAgentDefinition;
            Assert.IsNotNull(agentTool);
            Assert.AreEqual(FoundryAgentContextType.AgentContext, agentTool?.AgentContextType);

            TestContext.WriteLine("✓ Agent configured with AgentContext mode");
        }
    }
}

        [LiveOnly]
        [TestCase]
        public async Task ShouldCreateAgentCentricSessionWithAgentSessionConfig()
        {
            // This test verifies that AgentSessionConfig is properly configured for agent-centric sessions
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));
            
            var agentConfig = TestAgent.CreateAgentSessionConfig(TestEnvironment);

            // Verify the agent configuration is properly set up
            Assert.AreEqual(TestConstants.TestAgentName, agentConfig.AgentName);
            Assert.AreEqual(TestConstants.TestAgentProjectName, agentConfig.ProjectName);
            Assert.AreEqual(TestConstants.TestAgentVersion, agentConfig.AgentVersion);

            TestContext.WriteLine($"✓ Agent-centric session configured with agent: {agentConfig.AgentName}");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldVerifyAgentSessionConfigProperties()
        {
            // This test verifies that AgentSessionConfig properties are set correctly
            var agentConfig = TestAgent.CreateAgentSessionConfig(
                TestEnvironment, 
                agentVersion: "custom-version",
                conversationId: "test-conversation-123");

            Assert.AreEqual(TestConstants.TestAgentName, agentConfig.AgentName);
            Assert.AreEqual(TestConstants.TestAgentProjectName, agentConfig.ProjectName);
            Assert.AreEqual("custom-version", agentConfig.AgentVersion);
            Assert.AreEqual("test-conversation-123", agentConfig.ConversationId);

            TestContext.WriteLine("✓ AgentSessionConfig properties verified");
        }

        [TestCase]
        public void ShouldVerifyFoundryAgentToolAllProperties()
        {
            // This test verifies that VoiceLiveFoundryAgentDefinition can be configured with all properties
            var foundryAgent = new VoiceLiveFoundryAgentDefinition("test-agent", "test-project")
            {
                AgentVersion = "2.0",
                ClientId = "test-client-id",
                Description = "Test agent description",
                FoundryResourceOverride = "custom-resource",
                AgentContextType = FoundryAgentContextType.NoContext,
                ReturnAgentResponseDirectly = true
            };

            Assert.AreEqual("test-agent", foundryAgent.AgentName);
            Assert.AreEqual("test-project", foundryAgent.ProjectName);
            Assert.AreEqual("2.0", foundryAgent.AgentVersion);
            Assert.AreEqual("test-client-id", foundryAgent.ClientId);
            Assert.AreEqual("Test agent description", foundryAgent.Description);
            Assert.AreEqual("custom-resource", foundryAgent.FoundryResourceOverride);
            Assert.AreEqual(FoundryAgentContextType.NoContext, foundryAgent.AgentContextType);
            Assert.AreEqual(true, foundryAgent.ReturnAgentResponseDirectly);

            TestContext.WriteLine("✓ All VoiceLiveFoundryAgentDefinition properties configured correctly");
        }

        [TestCase]
        public void ShouldVerifyAgentSessionConfigAllProperties()
        {
            // This test verifies that AgentSessionConfig can be configured with all properties
            var agentConfig = new AgentSessionConfig("test-agent", "test-project")
            {
                AgentVersion = "3.0",
                ConversationId = "conv-123",
                AuthenticationIdentityClientId = "auth-client-id",
                FoundryResourceOverride = "override-resource"
            };

            Assert.AreEqual("test-agent", agentConfig.AgentName);
            Assert.AreEqual("test-project", agentConfig.ProjectName);
            Assert.AreEqual("3.0", agentConfig.AgentVersion);
            Assert.AreEqual("conv-123", agentConfig.ConversationId);
            Assert.AreEqual("auth-client-id", agentConfig.AuthenticationIdentityClientId);
            Assert.AreEqual("override-resource", agentConfig.FoundryResourceOverride);

            TestContext.WriteLine("✓ All AgentSessionConfig properties configured correctly");
        }
        [LiveOnly]
        [TestCase]
        public async Task ShouldVerifyAgentSessionConfigWithClientId()
        {
            // This test verifies that AgentSessionConfig with AuthenticationIdentityClientId is properly configured
            var agentConfig = TestAgent.CreateAgentSessionConfig(TestEnvironment);
            
            // Verify the client ID is set if available in test environment
            if (!string.IsNullOrEmpty(TestEnvironment.AgentClientId))
            {
                Assert.AreEqual(TestEnvironment.AgentClientId, agentConfig.AuthenticationIdentityClientId);
                TestContext.WriteLine($"✓ AgentSessionConfig configured with client ID: {agentConfig.AuthenticationIdentityClientId}");
            }
            else
            {
                Assert.IsNull(agentConfig.AuthenticationIdentityClientId);
                TestContext.WriteLine("✓ AgentSessionConfig configured without client ID (not set in environment)");
            }
        }
