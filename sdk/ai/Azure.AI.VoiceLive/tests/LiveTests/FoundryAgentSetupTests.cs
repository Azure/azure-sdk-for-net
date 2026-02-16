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

        [LiveOnly]
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

            // Test required properties
            Assert.AreEqual("test-agent", agentConfig.AgentName);
            Assert.AreEqual("test-project", agentConfig.ProjectName);

            // Test optional properties
            Assert.AreEqual("3.0", agentConfig.AgentVersion);
            Assert.AreEqual("conv-123", agentConfig.ConversationId);
            Assert.AreEqual("auth-client-id", agentConfig.AuthenticationIdentityClientId);
            Assert.AreEqual("override-resource", agentConfig.FoundryResourceOverride);

            TestContext.WriteLine("✓ All AgentSessionConfig properties configured correctly");
        }

        [TestCase]
        public void ShouldVerifyAgentSessionConfigOptionalPropertiesAreNullByDefault()
        {
            // This test verifies that optional properties are null by default
            var agentConfig = new AgentSessionConfig("test-agent", "test-project");

            // Required properties should be set
            Assert.AreEqual("test-agent", agentConfig.AgentName);
            Assert.AreEqual("test-project", agentConfig.ProjectName);

            // Optional properties should be null by default
            Assert.IsNull(agentConfig.AgentVersion);
            Assert.IsNull(agentConfig.ConversationId);
            Assert.IsNull(agentConfig.AuthenticationIdentityClientId);
            Assert.IsNull(agentConfig.FoundryResourceOverride);

            TestContext.WriteLine("✓ Optional AgentSessionConfig properties default to null as expected");
        }

        [LiveOnly]
        [TestCase]
        public void ShouldCreateSessionTargetFromModel()
        {
            // This test verifies that SessionTarget can be created for model sessions
            var target = SessionTarget.FromModel("gpt-4o-realtime-preview");

            Assert.IsTrue(target.IsModelSession);
            Assert.IsFalse(target.IsAgentSession);
            Assert.AreEqual("gpt-4o-realtime-preview", target.Model);
            Assert.IsNull(target.Agent);

            // Test type guards
            Assert.IsTrue(target.IsModelSessionTarget());
            Assert.IsFalse(target.IsAgentSessionTarget());

            TestContext.WriteLine("✓ SessionTarget created from model");
        }

        [LiveOnly]
        [TestCase]
        public void ShouldCreateSessionTargetFromAgent()
        {
            // This test verifies that SessionTarget can be created for agent sessions
            var agentConfig = new AgentSessionConfig("test-agent", "test-project");
            var target = SessionTarget.FromAgent(agentConfig);

            Assert.IsFalse(target.IsModelSession);
            Assert.IsTrue(target.IsAgentSession);
            Assert.IsNull(target.Model);
            Assert.AreEqual(agentConfig, target.Agent);

            // Test type guards
            Assert.IsFalse(target.IsModelSessionTarget());
            Assert.IsTrue(target.IsAgentSessionTarget());

            TestContext.WriteLine("✓ SessionTarget created from agent");
        }

        [LiveOnly]
        [TestCase]
        public void ShouldSupportImplicitConversionsToSessionTarget()
        {
            // This test verifies that implicit conversions work for SessionTarget
            SessionTarget modelTarget = "gpt-4o-realtime-preview";
            Assert.IsTrue(modelTarget.IsModelSession);
            Assert.AreEqual("gpt-4o-realtime-preview", modelTarget.Model);

            var agentConfig = new AgentSessionConfig("test-agent", "test-project");
            SessionTarget agentTarget = SessionTarget.FromAgent(agentConfig); // Using explicit conversion temporarily
            Assert.IsTrue(agentTarget.IsAgentSession);
            Assert.AreEqual(agentConfig, agentTarget.Agent);

            // Test that implicit conversion also works
            SessionTarget implicitAgentTarget = agentConfig;
            Assert.IsTrue(implicitAgentTarget.IsAgentSession);
            Assert.AreEqual(agentConfig, implicitAgentTarget.Agent);

            TestContext.WriteLine("✓ Implicit conversions to SessionTarget work correctly");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldCreateSessionWithSessionTargetFromModel()
        {
            // This test verifies that sessions can be created using SessionTarget with model
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var target = SessionTarget.FromModel("gpt-4o");

            await using var session = await client.StartSessionAsync(target, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            Assert.IsTrue(session.IsConnected);
            TestContext.WriteLine("✓ Session created using SessionTarget with model");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldCreateSessionWithSessionTargetFromAgent()
        {
            // This test verifies that sessions can be created using SessionTarget with agent
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var target = TestAgent.CreateAgentSessionTarget(TestEnvironment);

            await using var session = await client.StartSessionAsync(target, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            Assert.IsTrue(session.IsConnected);
            TestContext.WriteLine($"✓ Session created using SessionTarget with agent: {target.Agent?.AgentName}");
        }

        [TestCase]
        public void ShouldCreateSessionWithoutConnecting()
        {
            // This test verifies that CreateSession methods return unconnected sessions
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            // Test model-based session creation
            var modelSession = client.CreateSession("gpt-4o");
            Assert.IsNotNull(modelSession);
            Assert.IsFalse(modelSession.IsConnected); // Should not be connected yet

            // Test SessionTarget-based session creation
            var target = SessionTarget.FromModel("gpt-4o-realtime-preview");
            var targetSession = client.CreateSession(target);
            Assert.IsNotNull(targetSession);
            Assert.IsFalse(targetSession.IsConnected); // Should not be connected yet

            // Test agent-based session creation
            var agentConfig = new AgentSessionConfig("test-agent", "test-project");
            var agentTarget = SessionTarget.FromAgent(agentConfig);
            var agentSession = client.CreateSession(agentTarget);
            Assert.IsNotNull(agentSession);
            Assert.IsFalse(agentSession.IsConnected); // Should not be connected yet

            TestContext.WriteLine("✓ CreateSession methods work without auto-connecting");
        }

        [TestCase]
        public void ShouldVerifySessionTargetTypeSystem()
        {
            // This test verifies that SessionTarget type checking works correctly
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            // Test model session target
            var modelTarget = SessionTarget.FromModel("gpt-4o");
            var modelSession = client.CreateSession(modelTarget);
            Assert.IsTrue(modelTarget.IsModelSession);
            Assert.IsTrue(modelTarget.IsModelSessionTarget());

            // Test agent session target
            var agentConfig = new AgentSessionConfig("my-agent", "my-project");
            var agentTarget = SessionTarget.FromAgent(agentConfig);
            var agentSession = client.CreateSession(agentTarget);
            Assert.IsTrue(agentTarget.IsAgentSession);
            Assert.IsTrue(agentTarget.IsAgentSessionTarget());
            // Test type guard methods work correctly
            Assert.IsTrue(modelTarget.IsModelSessionTarget());
            Assert.IsFalse(modelTarget.IsAgentSessionTarget());
            Assert.IsFalse(agentTarget.IsModelSessionTarget());
            Assert.IsTrue(agentTarget.IsAgentSessionTarget());

            TestContext.WriteLine("✓ SessionTarget type system and type guards work correctly");
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
    }
}
