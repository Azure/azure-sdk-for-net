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
    public class FoundryAgentConnectionTests : VoiceLiveTestBase
    {
        private string _testAgentId = string.Empty;
        private const string AgentNamePrefix = "FoundryAgentConnectionTests";
        private string _testAgentName = string.Empty;

        public FoundryAgentConnectionTests() : base(true)
        {
        }

        public FoundryAgentConnectionTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupTestAgent()
        {
            // V2 FOUNDRY AGENTS: Voice Live only works with V2 (new Foundry) agents
            var agentName = $"{AgentNamePrefix}-{DateTime.UtcNow:yyyyMMdd}";
            _testAgentName = agentName;
            _testAgentId = string.Empty; // Use environment or test constants

            await Task.CompletedTask;
        }

        private VoiceLiveFoundryAgentDefinition CreateTestFoundryAgent()
        {
            // Use environment variables if available, fallback to test constants
            var agentName = !string.IsNullOrEmpty(TestEnvironment.FoundryAgentName)
                ? TestEnvironment.FoundryAgentName
                : (!string.IsNullOrEmpty(_testAgentName)
                    ? _testAgentName
                    : TestConstants.TestFoundryAgentName);

            var projectName = !string.IsNullOrEmpty(TestEnvironment.FoundryProjectName)
                ? TestEnvironment.FoundryProjectName
                : TestConstants.TestFoundryProjectName;

            return new VoiceLiveFoundryAgentDefinition(
                agentName: agentName,
                projectName: projectName)
            {
                AgentVersion = TestConstants.TestFoundryAgentVersion,
                Description = TestConstants.TestFoundryAgentDescription,
                AgentContextType = FoundryAgentContextType.AgentContext,
                ReturnAgentResponseDirectly = false
            };
        }

        [Test]
        public async Task TestBasicConnection_NoAgent()
        {
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
                // NO AGENT/TOOLS
            };

            await using var session = await client.StartSessionAsync(options, TimeoutToken);
            Assert.IsTrue(session.IsConnected);
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldConnectWithFoundryAgentConfigured()
        {
            // This test verifies that a session can be established with a Foundry agent configured
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));
            var foundryAgent = CreateTestFoundryAgent();

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(foundryAgent);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.IsTrue(session.IsConnected);
            TestContext.WriteLine("✓ Session connected successfully with Foundry agent configured");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldReceiveSessionUpdatedWithFoundryAgent_EnvironmentAgent()
        {
            // This test verifies that the session updated event includes the environment-configured agent
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var foundryAgent = CreateTestFoundryAgent();  // Uses environment or constants

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
            var expectedAgentName = !string.IsNullOrEmpty(TestEnvironment.FoundryAgentName)
                ? TestEnvironment.FoundryAgentName
                : TestConstants.TestFoundryAgentName;
            Assert.AreEqual(expectedAgentName, agentDef?.AgentName);  // Test environment/constant agent
            Assert.AreEqual(TestConstants.TestFoundryProjectName, agentDef?.ProjectName);

            TestContext.WriteLine($"✓ Environment agent '{agentDef?.AgentName}' found in session configuration");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldVerifyAgentConfigurationOptions()
        {
            // This test verifies that all configuration options are properly set on the agent
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var agentName = !string.IsNullOrEmpty(_testAgentId)
                ? _testAgentId
                : TestConstants.TestFoundryAgentName;

            var foundryAgent = new VoiceLiveFoundryAgentDefinition(
                agentName: agentName,
                projectName: TestConstants.TestFoundryProjectName)
            {
                AgentVersion = TestConstants.TestFoundryAgentVersion,
                Description = TestConstants.TestFoundryAgentDescription,
                AgentContextType = FoundryAgentContextType.NoContext,
                ReturnAgentResponseDirectly = true
            };

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
                Assert.AreEqual(agentName, agentTool.AgentName);
                Assert.AreEqual(TestConstants.TestFoundryProjectName, agentTool.ProjectName);
                Assert.AreEqual(TestConstants.TestFoundryAgentVersion, agentTool.AgentVersion);
                Assert.AreEqual(TestConstants.TestFoundryAgentDescription, agentTool.Description);
                Assert.AreEqual(FoundryAgentContextType.NoContext, agentTool.AgentContextType);
                Assert.AreEqual(true, agentTool.ReturnAgentResponseDirectly);
            }
            TestContext.WriteLine("✓ All Foundry agent configuration options verified");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldHandleInvalidAgentNameGracefully()
        {
            // This test verifies that the SDK handles invalid agent names gracefully
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var invalidAgent = new VoiceLiveFoundryAgentDefinition(
                agentName: "nonexistent-agent-xyz123",
                projectName: TestConstants.TestFoundryProjectName);

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(invalidAgent);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            // Manually get session.created without auto-failing on errors
            var moved1 = await updatesEnum.MoveNextAsync().ConfigureAwait(false);
            Assert.IsTrue(moved1, "Expected to receive session.created");
            var sessionCreatedUpdate = updatesEnum.Current;
            Assert.IsNotNull(sessionCreatedUpdate);
            Assert.IsTrue(sessionCreatedUpdate is SessionUpdateSessionCreated, $"Expected SessionUpdateSessionCreated, got: {sessionCreatedUpdate.GetType().Name}");

            // The error should come next
            var moved2 = await updatesEnum.MoveNextAsync().ConfigureAwait(false);
            Assert.IsTrue(moved2, "Expected to receive an error after session created");
            var errorUpdate = updatesEnum.Current;
            Assert.IsNotNull(errorUpdate);

            // This should be an error message about the invalid agent
            if (errorUpdate is SessionUpdateError error)
            {
                TestContext.WriteLine($"✓ Received expected error for invalid agent: {error.Error.Message}");
                Assert.That(error.Error.Message, Does.Contain("not found").Or.Contain("nonexistent-agent-xyz123"));
                Assert.AreEqual("agent_not_found", error.Error.Code);
            }
            else
            {
                Assert.Fail($"Expected SessionUpdateError for invalid agent, but got: {errorUpdate.GetType().Name}");
            }

            // Session should still be connected even after agent error
            Assert.IsTrue(session.IsConnected);
            TestContext.WriteLine("✓ Session remained stable after invalid agent error");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldSupportMultipleAgentsInSameSession()
        {
            // This test verifies that multiple Foundry agents can be configured in a single session
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var agentName = !string.IsNullOrEmpty(_testAgentId)
                ? _testAgentId
                : TestConstants.TestFoundryAgentName;

            var agent1 = new VoiceLiveFoundryAgentDefinition(
                agentName: agentName,
                projectName: TestConstants.TestFoundryProjectName)
            {
                Description = "First test agent"
            };

            var agent2 = new VoiceLiveFoundryAgentDefinition(
                agentName: agentName + "-2",
                projectName: TestConstants.TestFoundryProjectName)
            {
                Description = "Second test agent"
            };

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
            Assert.Contains(agentName, agentNames, "First agent not found in session tools");
            Assert.Contains(agentName + "-2", agentNames, "Second agent not found in session tools");

            TestContext.WriteLine($"✓ Session configured with {agentTools.Count} Foundry agents: {string.Join(", ", agentNames)}");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldVerifyAgentContextTypeNoContext()
        {
            // This test verifies that NoContext mode works correctly
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var agentName = !string.IsNullOrEmpty(_testAgentId)
                ? _testAgentId
                : TestConstants.TestFoundryAgentName;

            var agent = new VoiceLiveFoundryAgentDefinition(
                agentName: agentName,
                projectName: TestConstants.TestFoundryProjectName)
            {
                AgentContextType = FoundryAgentContextType.NoContext,
                Description = TestConstants.TestFoundryAgentDescription
            };

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

            var agentName = !string.IsNullOrEmpty(_testAgentId)
                ? _testAgentId
                : TestConstants.TestFoundryAgentName;

            var agent = new VoiceLiveFoundryAgentDefinition(
                agentName: agentName,
                projectName: TestConstants.TestFoundryProjectName)
            {
                AgentContextType = FoundryAgentContextType.AgentContext,
                Description = TestConstants.TestFoundryAgentDescription
            };

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
