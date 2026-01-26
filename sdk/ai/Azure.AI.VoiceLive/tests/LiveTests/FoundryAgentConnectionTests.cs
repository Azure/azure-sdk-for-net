// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
            // Try to find an existing agent with our test class name
            var agentName = $"{AgentNamePrefix}-{DateTime.UtcNow:yyyyMMdd}";

            try
            {
                _testAgentId = await TestAgent.FindAgentAsync(agentName, TestEnvironment).ConfigureAwait(false);

                if (string.IsNullOrEmpty(_testAgentId))
                {
                    // Agent doesn't exist, create it
                    TestContext.WriteLine($"Creating test agent: {agentName}");
                    await TestAgent.CreateAgentAsync(agentName, TestEnvironment).ConfigureAwait(false);

                    // Find the newly created agent to get its ID
                    _testAgentId = await TestAgent.FindAgentAsync(agentName, TestEnvironment).ConfigureAwait(false);

                    if (!string.IsNullOrEmpty(_testAgentId))
                    {
                        TestContext.WriteLine($"Created test agent with ID: {_testAgentId}");
                    }
                }
                else
                {
                    TestContext.WriteLine($"Found existing test agent with ID: {_testAgentId}");
                }

                _testAgentName = agentName;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Warning: Could not setup test agent: {ex.Message}");
                throw;
            }
        }

        private VoiceLiveFoundryAgentDefinition CreateTestFoundryAgent()
        {
            // Use the dynamically created/found agent ID if available, otherwise fall back to constants
            var agentName = !string.IsNullOrEmpty(_testAgentName)
                ? _testAgentName
                : TestConstants.TestFoundryAgentName;

            return new VoiceLiveFoundryAgentDefinition(
                agentName: agentName,
                projectName: TestConstants.TestFoundryProjectName)
            {
                AgentVersion = TestConstants.TestFoundryAgentVersion,
                ClientId = TestConstants.TestFoundryClientId,
                Description = TestConstants.TestFoundryAgentDescription,
                AgentContextType = FoundryAgentContextType.AgentContext,
                ReturnAgentResponseDirectly = false
            };
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
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldReceiveSessionUpdatedWithFoundryAgent()
        {
            // This test verifies that the session updated event includes the Foundry agent in the tools list
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
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.IsNotNull(sessionUpdated.Session);
            Assert.IsNotNull(sessionUpdated.Session.Tools);
            Assert.IsTrue(sessionUpdated.Session.Tools.Count > 0);

            var agentTool = sessionUpdated.Session.Tools.FirstOrDefault(t => t is VoiceLiveFoundryAgentDefinition);
            Assert.IsNotNull(agentTool, "Expected to find a Foundry agent tool in the session configuration");

            var agentDef = agentTool as VoiceLiveFoundryAgentDefinition;
            var expectedAgentName = !string.IsNullOrEmpty(_testAgentId)
                ? _testAgentId
                : TestConstants.TestFoundryAgentName;
            Assert.AreEqual(expectedAgentName, agentDef?.AgentName);
            Assert.AreEqual(TestConstants.TestFoundryProjectName, agentDef?.ProjectName);

            TestContext.WriteLine($"✓ Foundry agent '{agentDef?.AgentName}' found in session configuration");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
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
                ClientId = TestConstants.TestFoundryClientId,
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
                Assert.AreEqual(TestConstants.TestFoundryClientId, agentTool.ClientId);
                Assert.AreEqual(TestConstants.TestFoundryAgentDescription, agentTool.Description);
                Assert.AreEqual(FoundryAgentContextType.NoContext, agentTool.AgentContextType);
                Assert.AreEqual(true, agentTool.ReturnAgentResponseDirectly);
            }
            TestContext.WriteLine("✓ All Foundry agent configuration options verified");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
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

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            // Session should still be connected even if agent doesn't exist
            Assert.IsTrue(session.IsConnected);

            // Try to trigger agent call - it should fail gracefully
            var userMessage = new UserMessageItem(new InputTextContentPart("Use the agent to help me."));
            await session.AddItemAsync(userMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.StandardTimeout);

            bool foundFailure = false;
            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallFailed failedUpdate)
                    {
                        foundFailure = true;
                        TestContext.WriteLine($"✓ Agent call failed gracefully for item: {failedUpdate.ItemId}");
                        break;
                    }
                } while (update is not SessionUpdateResponseDone && !cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                // Timeout is acceptable - the key validation is that session remained stable
            }
            Assert.IsTrue(foundFailure);
            // Session should remain connected even after agent failure
            Assert.IsTrue(session.IsConnected);
            TestContext.WriteLine("✓ Session remained stable after invalid agent configuration");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
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
            Assert.IsTrue(agentTools.Count >= 2, $"Expected at least 2 Foundry agent tools, found {agentTools.Count}");

            TestContext.WriteLine($"✓ Session configured with {agentTools.Count} Foundry agents");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
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
                AgentContextType = FoundryAgentContextType.NoContext
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
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
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
                AgentContextType = FoundryAgentContextType.AgentContext
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
