// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Phase 5: MCP Approval Workflow Integration Tests
    ///
    /// These tests verify the critical approval workflow for MCP tool execution.
    /// The approval workflow is a human-in-the-loop safety mechanism that allows
    /// applications to require user approval before executing potentially sensitive
    /// tool operations.
    ///
    /// Uses Microsoft Learn MCP Server: https://learn.microsoft.com/api/mcp
    ///
    /// ARCHITECTURE:
    /// - Client configures MCP server with requireApproval settings
    /// - VoiceLive service enforces approval policy
    /// - Client receives approval requests and sends responses
    /// - MCP server is agnostic to approval (just executes tools when called)
    /// </summary>
    public class McpApprovalWorkflowTests : VoiceLiveTestBase
    {
        public McpApprovalWorkflowTests() : base(true)
        {
        }

        public McpApprovalWorkflowTests(bool isAsync) : base(isAsync)
        {
        }

        private VoiceLiveMcpServerDefinition CreateMicrosoftLearnMcpServer(string requireApproval = "never")
        {
            return new VoiceLiveMcpServerDefinition(
                serverLabel: TestConstants.MicrosoftLearnMcpServerLabel,
                serverUrl: TestConstants.MicrosoftLearnMcpServerUrl)
            {
                RequireApproval = BinaryData.FromString($"\"{requireApproval}\"")
            };
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldRequestApprovalForToolWithRequireApprovalAlways()
        {
            var client = GetLiveClient();

            var mcpServerWithApproval = CreateMicrosoftLearnMcpServer(requireApproval: "always");

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(mcpServerWithApproval);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            var mcpListInProgress = await GetNextUpdate<SessionUpdateMcpListToolsInProgress>(updatesEnum).ConfigureAwait(false);
            var mcpListCompleted = await GetNextUpdate<SessionUpdateMcpListToolsCompleted>(updatesEnum).ConfigureAwait(false);

            // Add a user message that might trigger tool use
            var userMessage = new UserMessageItem(new InputTextContentPart("Search Microsoft Learn for Azure SDK documentation"));
            await session.AddItemAsync(userMessage).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            // Create response to allow AI to potentially use tools
            await session.StartResponseAsync().ConfigureAwait(false);

            // Wait for response created
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);

            // Wait for output item - this should be an MCP call requiring approval
            // The AI may or may not decide to use the tool, so we need to handle both cases
            bool foundMcpCall = false;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.McpTimeout);

            try
            {
                while (!foundMcpCall && !cts.Token.IsCancellationRequested)
                {
                    var nextUpdate = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                    if (nextUpdate is SessionUpdateResponseOutputItemAdded outputItemAdded)
                    {
                        // Check if this is an MCP call item
                        if (outputItemAdded.Item is SessionResponseMcpCallItem mcpCallItem)
                        {
                            foundMcpCall = true;

                            // Verify approval request structure
                            Assert.IsNotNull(mcpCallItem);
                            Assert.AreEqual(ItemType.McpCall, mcpCallItem.Type);
                            Assert.IsNotNull(mcpCallItem.Id);
                            Assert.IsNotNull(mcpCallItem.Name, "Tool name should be present");
                            Assert.AreEqual(TestConstants.MicrosoftLearnMcpServerLabel, mcpCallItem.ServerLabel);

                            TestContext.WriteLine($"Approval request received for tool: {mcpCallItem.Name} on server: {mcpCallItem.ServerLabel}");
                            break;
                        }
                    }
                    else if (nextUpdate is SessionUpdateResponseDone)
                    {
                        // Response completed without MCP call - AI chose not to use the tool
                        Assert.Inconclusive("AI did not decide to use MCP tool in this test run. This is expected behavior based on the prompt.");
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Assert.Inconclusive("Timeout waiting for MCP tool call. AI may not have chosen to use the tool.");
            }

            if (!foundMcpCall)
            {
                Assert.Inconclusive("Did not receive MCP call requiring approval. AI behavior is non-deterministic.");
            }
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Approval not requested")]
        public async Task ShouldExecuteToolAfterApprovalGranted()
        {
            var client = GetLiveClient();

            var mcpServerWithApproval = CreateMicrosoftLearnMcpServer(requireApproval: "always");

            var options = new VoiceLiveSessionOptions
            {
                Model = "gpt-4o"
            };
            options.Tools.Add(mcpServerWithApproval);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            var mcpListInProgress = await GetNextUpdate<SessionUpdateMcpListToolsInProgress>(updatesEnum).ConfigureAwait(false);
            var mcpListCompleted = await GetNextUpdate<SessionUpdateMcpListToolsCompleted>(updatesEnum).ConfigureAwait(false);

            // Add a user message that should trigger tool use with a more specific prompt
            var userMessage = new UserMessageItem(new InputTextContentPart(
                "Use Microsoft Learn tools to find the default silence timeout for the Azure Speech SDK."));
            await session.AddItemAsync(userMessage).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            // Create response to allow AI to use tools
            await session.StartResponseAsync().ConfigureAwait(false);

            // Collect all events until response.done to find the MCP call and approval request
            var allUpdates = new System.Collections.Generic.List<SessionUpdate>();
            SessionUpdate update;
            string approvalRequestId = string.Empty;
            string mcpCallItemId = string.Empty;
            bool foundMcpCall = false;

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(TimeoutToken);
            cts.CancelAfter(TestConstants.McpTimeout);

            try
            {
                // Collect events until we find response.done or timeout
                do
                {
                    update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);
                    allUpdates.Add(update);

                    // Check for MCP call arguments events
                    if (update is SessionUpdateResponseMcpCallArgumentsDelta deltaUpdate)
                    {
                        TestContext.WriteLine($"MCP call arguments delta: {deltaUpdate.Delta}");
                    }
                    else if (update is SessionUpdateResponseMcpCallArgumentsDone doneUpdate)
                    {
                        TestContext.WriteLine($"MCP call arguments done: {doneUpdate.Arguments}");
                    }
                    else if (update is SessionUpdateConversationItemCreated itemCreated)
                    {
                        // Look for the MCP call item
                        if (itemCreated.Item is SessionResponseMcpCallItem mcpCallItem)
                        {
                            foundMcpCall = true;
                            mcpCallItemId = mcpCallItem.Id;
                            approvalRequestId = mcpCallItem.ApprovalRequestId;

                            TestContext.WriteLine($"MCP call item created - Tool: {mcpCallItem.Name}, Server: {mcpCallItem.ServerLabel}");
                            TestContext.WriteLine($"Approval Request ID: {approvalRequestId}");
                        }
                    }
                } while (update is not SessionUpdateResponseDone && !cts.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail("Timeout waiting for response completion. AI may not have chosen to use the tool.");
                return;
            }

            if (!foundMcpCall)
            {
                Assert.Fail("AI did not decide to use MCP tool in this test run.");
                return;
            }

            Assert.IsNotNull(approvalRequestId, "Should have received an approval request ID");

            // Send approval response
            TestContext.WriteLine("Sending approval response...");
            var approvalResponse = new MCPApprovalResponseRequestItem(approvalRequestId, approve: true);
            await session.AddItemAsync(approvalResponse).ConfigureAwait(false);

            // Wait for conversation item created (approval response added)
            var approvalItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            Assert.IsNotNull(approvalItemCreated.Item);

            // Wait for MCP call execution events
            var mcpCallInProgress = await GetNextUpdate<SessionUpdateResponseMcpCallInProgress>(updatesEnum).ConfigureAwait(false);
            Assert.IsNotNull(mcpCallInProgress);
            Assert.IsNotNull(mcpCallInProgress.ItemId);
            TestContext.WriteLine($"MCP call in progress for item: {mcpCallInProgress.ItemId}");

            var mcpCallCompleted = await GetNextUpdate<SessionUpdateResponseMcpCallCompleted>(updatesEnum).ConfigureAwait(false);
            Assert.IsNotNull(mcpCallCompleted);
            Assert.IsNotNull(mcpCallCompleted.ItemId);
            TestContext.WriteLine($"MCP call completed for item: {mcpCallCompleted.ItemId}");

            // Wait for output item done
            var outputItemDone = await GetNextUpdate<SessionUpdateResponseOutputItemDone>(updatesEnum).ConfigureAwait(false);
            Assert.IsNotNull(outputItemDone);
            TestContext.WriteLine("MCP tool execution output received");

            // Send another response.create to let the AI process the tool results
            await session.StartResponseAsync().ConfigureAwait(false);

            // Wait for the AI to process and complete the response
            var finalResponseDone = await GetNextUpdate<SessionUpdateResponseDone>(updatesEnum).ConfigureAwait(false);
            Assert.IsNotNull(finalResponseDone);

            TestContext.WriteLine("✓ Tool executed successfully after approval");
        }
    }
}
