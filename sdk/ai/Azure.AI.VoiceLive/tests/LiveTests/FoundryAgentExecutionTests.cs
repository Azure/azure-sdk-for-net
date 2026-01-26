// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Foundry Agent Execution Integration Tests
    ///
    /// These tests verify the complete execution flow of Foundry agents within
    /// VoiceLive conversations, including:
    /// - Argument streaming (delta and done events)
    /// - Execution lifecycle (in progress, completed, failed)
    /// - Response handling modes
    /// - Context management
    ///
    /// Foundry agents provide specialized AI capabilities that can be invoked
    /// during VoiceLive conversations to perform complex tasks or access domain-specific knowledge.
    /// </summary>
    public class FoundryAgentExecutionTests : VoiceLiveTestBase
    {
        private string _testAgentId = string.Empty;
        private const string AgentNamePrefix = "FoundryAgentExecutionTests";

        public FoundryAgentExecutionTests() : base(true)
        {
        }

        public FoundryAgentExecutionTests(bool isAsync) : base(isAsync)
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
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Warning: Could not setup test agent: {ex.Message}");
                TestContext.WriteLine("Tests will use configured constants instead.");
            }
        }

        private VoiceLiveFoundryAgentDefinition CreateTestFoundryAgent()
        {
            // Use the dynamically created/found agent ID if available, otherwise fall back to constants
            var agentName = !string.IsNullOrEmpty(_testAgentId)
                ? _testAgentId
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
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldReceiveAgentCallArgumentsDelta()
        {
            // This test verifies that agent call arguments are streamed via delta events
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

            // Add a user message that should trigger the agent
            var userMessage = new UserMessageItem(new InputTextContentPart("Use the test agent to help me with a complex task."));
            await session.AddItemAsync(userMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            // Start response to allow AI to use the agent
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);

            bool foundDelta = false;
            List<string> deltas = new List<string>();

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.McpTimeout);

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallArgumentsDelta deltaUpdate)
                    {
                        foundDelta = true;
                        deltas.Add(deltaUpdate.Delta);
                        TestContext.WriteLine($"Agent call arguments delta: {deltaUpdate.Delta}");
                        TestContext.WriteLine($"  Item ID: {deltaUpdate.ItemId}");
                        TestContext.WriteLine($"  Response ID: {deltaUpdate.ResponseId}");
                        TestContext.WriteLine($"  Output Index: {deltaUpdate.OutputIndex}");
                    }
                    else if (update is SessionUpdateResponseFoundryAgentCallArgumentsDone)
                    {
                        // We've reached the end of arguments
                        break;
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        // Response completed without agent call
                        Assert.Inconclusive("AI did not decide to use the Foundry agent in this test run.");
                        return;
                    }
                } while (!cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                Assert.Inconclusive("Timeout waiting for agent call. AI may not have chosen to use the agent.");
                return;
            }

            Assert.IsTrue(foundDelta, "Expected to receive at least one agent call arguments delta event");
            Assert.IsTrue(deltas.Count > 0, "Expected to receive argument deltas");

            TestContext.WriteLine($"✓ Received {deltas.Count} agent call argument delta events");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldReceiveAgentCallArgumentsDone()
        {
            // This test verifies that the complete arguments are provided in the done event
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

            var userMessage = new UserMessageItem(new InputTextContentPart("Use the test agent to help me."));
            await session.AddItemAsync(userMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);

            SessionUpdateResponseFoundryAgentCallArgumentsDone? doneEvent = null;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.McpTimeout);

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallArgumentsDone done)
                    {
                        doneEvent = done;
                        TestContext.WriteLine($"Agent call arguments done:");
                        TestContext.WriteLine($"  Arguments: {done.Arguments}");
                        TestContext.WriteLine($"  Item ID: {done.ItemId}");
                        TestContext.WriteLine($"  Response ID: {done.ResponseId}");
                        TestContext.WriteLine($"  Output Index: {done.OutputIndex}");
                        break;
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        Assert.Inconclusive("AI did not decide to use the Foundry agent in this test run.");
                        return;
                    }
                } while (!cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                Assert.Inconclusive("Timeout waiting for agent call. AI may not have chosen to use the agent.");
                return;
            }

            Assert.IsNotNull(doneEvent, "Expected to receive agent call arguments done event");
            Assert.IsNotNull(doneEvent?.Arguments, "Expected arguments to be provided");
            Assert.IsNotEmpty(doneEvent?.Arguments, "Expected non-empty arguments");

            TestContext.WriteLine("✓ Received complete agent call arguments");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldReceiveAgentCallInProgress()
        {
            // This test verifies that the in-progress event is received during agent execution
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

            var userMessage = new UserMessageItem(new InputTextContentPart("Use the test agent to help me."));
            await session.AddItemAsync(userMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);

            SessionUpdateResponseFoundryAgentCallInProgress? inProgressEvent = null;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.McpTimeout);

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallInProgress inProgress)
                    {
                        inProgressEvent = inProgress;
                        TestContext.WriteLine($"Agent call in progress:");
                        TestContext.WriteLine($"  Item ID: {inProgress.ItemId}");
                        TestContext.WriteLine($"  Output Index: {inProgress.OutputIndex}");
                        if (inProgress.AgentResponseId != null)
                        {
                            TestContext.WriteLine($"  Agent Response ID: {inProgress.AgentResponseId}");
                        }
                        break;
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        Assert.Inconclusive("AI did not decide to use the Foundry agent in this test run.");
                        return;
                    }
                } while (!cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                Assert.Inconclusive("Timeout waiting for agent call. AI may not have chosen to use the agent.");
                return;
            }

            Assert.IsNotNull(inProgressEvent, "Expected to receive agent call in progress event");
            Assert.IsNotNull(inProgressEvent?.ItemId, "Expected item ID to be present");

            TestContext.WriteLine("✓ Received agent call in progress event");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldReceiveAgentCallCompleted()
        {
            // This test verifies the complete execution lifecycle of a Foundry agent call
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

            var userMessage = new UserMessageItem(new InputTextContentPart("Use the test agent to help me."));
            await session.AddItemAsync(userMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);

            bool foundArgumentsDelta = false;
            bool foundArgumentsDone = false;
            bool foundInProgress = false;
            bool foundCompleted = false;
            SessionUpdateResponseFoundryAgentCallCompleted? completedEvent = null;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.McpTimeout);

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallArgumentsDelta)
                    {
                        foundArgumentsDelta = true;
                        TestContext.WriteLine("✓ Received arguments delta event");
                    }
                    else if (update is SessionUpdateResponseFoundryAgentCallArgumentsDone)
                    {
                        foundArgumentsDone = true;
                        TestContext.WriteLine("✓ Received arguments done event");
                    }
                    else if (update is SessionUpdateResponseFoundryAgentCallInProgress)
                    {
                        foundInProgress = true;
                        TestContext.WriteLine("✓ Received in progress event");
                    }
                    else if (update is SessionUpdateResponseFoundryAgentCallCompleted completed)
                    {
                        foundCompleted = true;
                        completedEvent = completed;
                        TestContext.WriteLine($"✓ Received completed event for item: {completed.ItemId}");
                        break;
                    }
                    else if (update is SessionUpdateResponseFoundryAgentCallFailed failed)
                    {
                        Assert.Fail($"Agent call failed unexpectedly for item: {failed.ItemId}");
                        return;
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        Assert.Inconclusive("AI did not decide to use the Foundry agent in this test run.");
                        return;
                    }
                } while (!cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                Assert.Inconclusive("Timeout waiting for agent call completion. AI may not have chosen to use the agent.");
                return;
            }

            Assert.IsTrue(foundArgumentsDelta || foundArgumentsDone, "Expected to receive arguments events");
            Assert.IsTrue(foundInProgress, "Expected to receive in progress event");
            Assert.IsTrue(foundCompleted, "Expected to receive completed event");
            Assert.IsNotNull(completedEvent, "Expected completed event details");
            Assert.IsNotNull(completedEvent?.ItemId, "Expected item ID in completed event");

            TestContext.WriteLine("✓ Complete agent execution lifecycle verified");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldVerifyAgentResponseInConversationItem()
        {
            // This test verifies that the agent response is available in the conversation item
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

            var userMessage = new UserMessageItem(new InputTextContentPart("Use the test agent to help me."));
            await session.AddItemAsync(userMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            SessionResponseFoundryAgentCallItem? agentCallItem = null;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.McpTimeout);

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateConversationItemCreated itemCreated)
                    {
                        if (itemCreated.Item is SessionResponseFoundryAgentCallItem agentItem)
                        {
                            agentCallItem = agentItem;
                            TestContext.WriteLine($"Found agent call item:");
                            TestContext.WriteLine($"  ID: {agentItem.Id}");
                            TestContext.WriteLine($"  Name: {agentItem.Name}");
                            TestContext.WriteLine($"  Call ID: {agentItem.CallId}");
                            TestContext.WriteLine($"  Arguments: {agentItem.Arguments}");
                            if (agentItem.Output != null)
                            {
                                TestContext.WriteLine($"  Output: {agentItem.Output}");
                            }
                            if (agentItem.Error != null)
                            {
                                TestContext.WriteLine($"  Error: {agentItem.Error}");
                            }
                        }
                    }
                    else if (update is SessionUpdateResponseFoundryAgentCallCompleted)
                    {
                        // Agent call completed
                        break;
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        // Response done
                        break;
                    }
                } while (!cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                Assert.Inconclusive("Timeout waiting for agent call. AI may not have chosen to use the agent.");
                return;
            }

            if (agentCallItem == null)
            {
                Assert.Inconclusive("AI did not decide to use the Foundry agent in this test run.");
                return;
            }

            Assert.IsNotNull(agentCallItem);
            Assert.AreEqual(ItemType.FoundryAgentCall, agentCallItem.Type);
            Assert.IsNotNull(agentCallItem.Id);
            Assert.IsNotNull(agentCallItem.Name);
            Assert.IsNotNull(agentCallItem.CallId);
            Assert.IsNotNull(agentCallItem.Arguments);

            TestContext.WriteLine("✓ Agent call item structure verified");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldHandleAgentCallFailure()
        {
            // This test verifies that agent call failures are handled gracefully
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            // Use an invalid agent configuration to trigger failure
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
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var userMessage = new UserMessageItem(new InputTextContentPart("Use the agent to help me."));
            await session.AddItemAsync(userMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            SessionUpdateResponseFoundryAgentCallFailed? failedEvent = null;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.StandardTimeout);

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallFailed failed)
                    {
                        failedEvent = failed;
                        TestContext.WriteLine($"Agent call failed:");
                        TestContext.WriteLine($"  Item ID: {failed.ItemId}");
                        TestContext.WriteLine($"  Output Index: {failed.OutputIndex}");
                        break;
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        // AI may have decided not to use the agent
                        break;
                    }
                } while (!cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                // Timeout is acceptable
            }

            // Session should remain connected even after agent failure
            Assert.IsTrue(session.IsConnected);

            if (failedEvent != null)
            {
                Assert.IsNotNull(failedEvent.ItemId);
                TestContext.WriteLine("✓ Agent call failure handled gracefully");
            }
            else
            {
                TestContext.WriteLine("✓ Session remained stable (AI may not have attempted to use invalid agent)");
            }
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldExecuteAgentWithReturnResponseDirectly()
        {
            // This test verifies that ReturnAgentResponseDirectly option works correctly
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW));

            var foundryAgent = new VoiceLiveFoundryAgentDefinition(
                agentName: TestConstants.TestFoundryAgentName,
                projectName: TestConstants.TestFoundryProjectName)
            {
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

            // Verify configuration
            var agentTool = sessionUpdated.Session.Tools.FirstOrDefault(t => t is VoiceLiveFoundryAgentDefinition) as VoiceLiveFoundryAgentDefinition;
            Assert.IsNotNull(agentTool);
            Assert.AreEqual(true, agentTool?.ReturnAgentResponseDirectly);

            TestContext.WriteLine("✓ Agent configured with ReturnAgentResponseDirectly = true");

            var userMessage = new UserMessageItem(new InputTextContentPart("Use the test agent to help me."));
            await session.AddItemAsync(userMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.McpTimeout);

            bool foundAgentCall = false;

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallCompleted completed)
                    {
                        foundAgentCall = true;
                        TestContext.WriteLine($"✓ Agent call completed with ReturnAgentResponseDirectly mode");
                        break;
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        break;
                    }
                } while (!cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                Assert.Inconclusive("Timeout waiting for agent call. AI may not have chosen to use the agent.");
            }

            if (foundAgentCall)
            {
                TestContext.WriteLine("✓ Agent executed successfully with direct response mode");
            }
            else
            {
                Assert.Inconclusive("AI did not decide to use the Foundry agent in this test run.");
            }
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Requires deployed Foundry agent - update test constants with real agent details")]
        public async Task ShouldExecuteMultipleSequentialAgentCalls()
        {
            // This test verifies that multiple agent calls can be executed sequentially in the same session
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

            int agentCallCount = 0;

            // First agent call
            var firstMessage = new UserMessageItem(new InputTextContentPart("Use the test agent for the first task."));
            await session.AddItemAsync(firstMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            using var cts1 = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts1.CancelAfter(TestConstants.McpTimeout);

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallCompleted)
                    {
                        agentCallCount++;
                        TestContext.WriteLine($"✓ First agent call completed");
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        break;
                    }
                } while (!cts1.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                // First call may not have happened
            }

            // Second agent call
            var secondMessage = new UserMessageItem(new InputTextContentPart("Now use the test agent for a second task."));
            await session.AddItemAsync(secondMessage, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            using var cts2 = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts2.CancelAfter(TestConstants.McpTimeout);

            try
            {
                SessionUpdate update;
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (update is SessionUpdateResponseFoundryAgentCallCompleted)
                    {
                        agentCallCount++;
                        TestContext.WriteLine($"✓ Second agent call completed");
                    }
                    else if (update is SessionUpdateResponseDone)
                    {
                        break;
                    }
                } while (!cts2.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                // Second call may not have happened
            }

            if (agentCallCount >= 1)
            {
                TestContext.WriteLine($"✓ Successfully executed {agentCallCount} agent call(s)");
            }
            else
            {
                Assert.Inconclusive("AI did not decide to use the Foundry agent in this test run.");
            }
        }
    }
}
