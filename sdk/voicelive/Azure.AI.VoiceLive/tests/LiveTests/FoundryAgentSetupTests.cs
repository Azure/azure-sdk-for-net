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
    /// Foundry Agent Setup Tests
    ///
    /// These tests verify that Foundry agents can be properly configured and set up
    /// without requiring actual session connections. The goal is to ensure agents
    /// exist and are configured correctly for future use.
    ///
    /// Agent-centric sessions use AgentSessionConfig where the Foundry agent is the primary AI actor.
    /// The agent's configuration (tools, instructions, temperature, etc.) is managed in the
    /// Foundry portal, not in session code.
    /// </summary>
    public class FoundryAgentSetupTests : VoiceLiveTestBase
    {
        public FoundryAgentSetupTests() : base(true)
        {
        }

        public FoundryAgentSetupTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        public void ShouldCreateAgentSessionConfigWithRequiredProperties()
        {
            // This test verifies that AgentSessionConfig can be created with required properties
            var agentConfig = new AgentSessionConfig("test-agent", "test-project");

            // Required properties should be set
            Assert.AreEqual("test-agent", agentConfig.AgentName);
            Assert.AreEqual("test-project", agentConfig.ProjectName);

            TestContext.WriteLine($"✓ AgentSessionConfig created with agent: {agentConfig.AgentName}");
        }

        [TestCase]
        public void ShouldCreateAgentSessionConfigWithAllProperties()
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

        [TestCase]
        public void ShouldCreateAgentSessionConfigFromTestEnvironment()
        {
            // This test verifies that AgentSessionConfig can be created using TestAgent helper
            var agentConfig = TestAgent.CreateAgentSessionConfig(TestEnvironment);

            // Verify configuration is properly set up from environment
            Assert.IsNotNull(agentConfig.AgentName);
            Assert.IsNotNull(agentConfig.ProjectName);
            Assert.IsNotNull(agentConfig.AgentVersion);

            TestContext.WriteLine($"✓ AgentSessionConfig created from test environment: {agentConfig.AgentName}");
        }

        [TestCase]
        public void ShouldCreateAgentSessionConfigWithCustomParameters()
        {
            // This test verifies that AgentSessionConfig can be created with custom overrides
            var agentConfig = TestAgent.CreateAgentSessionConfig(
                TestEnvironment,
                agentName: "custom-agent",
                projectName: "custom-project",
                agentVersion: "custom-version",
                conversationId: "test-conversation-123");

            Assert.AreEqual("custom-agent", agentConfig.AgentName);
            Assert.AreEqual("custom-project", agentConfig.ProjectName);
            Assert.AreEqual("custom-version", agentConfig.AgentVersion);
            Assert.AreEqual("test-conversation-123", agentConfig.ConversationId);

            TestContext.WriteLine("✓ AgentSessionConfig created with custom parameters");
        }

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

        [TestCase]
        public void ShouldSupportImplicitConversionsToSessionTarget()
        {
            // This test verifies that implicit conversions work for SessionTarget
            var agentConfig = new AgentSessionConfig("test-agent", "test-project");

            // Test explicit conversion
            SessionTarget agentTarget = SessionTarget.FromAgent(agentConfig);
            Assert.IsTrue(agentTarget.IsAgentSession);
            Assert.AreEqual(agentConfig, agentTarget.Agent);

            // Test that implicit conversion also works
            SessionTarget implicitAgentTarget = agentConfig;
            Assert.IsTrue(implicitAgentTarget.IsAgentSession);
            Assert.AreEqual(agentConfig, implicitAgentTarget.Agent);

            TestContext.WriteLine("✓ Implicit conversions to SessionTarget work correctly");
        }

        [TestCase]
        public void ShouldCreateSessionTargetFromTestEnvironment()
        {
            // This test verifies that SessionTarget can be created using TestAgent helper
            var target = TestAgent.CreateAgentSessionTarget(TestEnvironment);

            Assert.IsTrue(target.IsAgentSession);
            Assert.IsFalse(target.IsModelSession);
            Assert.IsNotNull(target.Agent);
            Assert.IsNull(target.Model);

            TestContext.WriteLine($"✓ SessionTarget created from test environment for agent: {target.Agent?.AgentName}");
        }

        [TestCase]
        public void ShouldVerifySessionTargetTypeSystem()
        {
            // This test verifies that SessionTarget type checking works correctly
            var agentConfig = new AgentSessionConfig("my-agent", "my-project");
            var agentTarget = SessionTarget.FromAgent(agentConfig);

            // Test agent session target properties
            Assert.IsTrue(agentTarget.IsAgentSession);
            Assert.IsTrue(agentTarget.IsAgentSessionTarget());
            Assert.IsFalse(agentTarget.IsModelSession);
            Assert.IsFalse(agentTarget.IsModelSessionTarget());

            TestContext.WriteLine("✓ SessionTarget type system and type guards work correctly");
        }

        [TestCase]
        public void ShouldVerifyAgentSessionConfigWithClientIdFromEnvironment()
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

        [TestCase]
        public void ShouldCreateUnconnectedSession()
        {
            // This test verifies that CreateSession methods return unconnected sessions for setup validation
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            // Test agent-based session creation (without connecting)
            var agentConfig = new AgentSessionConfig("test-agent", "test-project");
            var agentTarget = SessionTarget.FromAgent(agentConfig);
            var agentSession = client.CreateSession(agentTarget);

            Assert.IsNotNull(agentSession);
            Assert.IsFalse(agentSession.IsConnected); // Should not be connected yet

            TestContext.WriteLine("✓ CreateSession method works for agent setup without auto-connecting");
        }
    }
}