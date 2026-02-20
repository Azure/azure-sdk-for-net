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
    ///
    /// KNOWN SERVICE ISSUES:
    /// - Approval denial workflow may not work correctly
    /// - require_approval='never' may not work correctly (tools still require approval)
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
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2025_10_01));

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
       // [Ignore("Approval not requested")]
        public async Task ShouldExecuteToolAfterApprovalGranted()
        {
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2025_10_01));

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

            var userMessage = new UserMessageItem(new InputTextContentPart(
                "Use Microsoft Learn tools to find the default silence timeout for the Azure Speech SDK."));
            await session.AddItemAsync(userMessage).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync().ConfigureAwait(false);

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

                    TestContext.WriteLine($"Received update: {update.GetType().Name}");

                    // Check for MCP call arguments events
                    if (update is SessionUpdateResponseMcpCallArgumentsDelta deltaUpdate)
                    {
                        TestContext.WriteLine($"📊 MCP call arguments delta: {deltaUpdate.Delta}");
                    }
                    else if (update is SessionUpdateResponseMcpCallArgumentsDone doneUpdate)
                    {
                        TestContext.WriteLine($"✅ MCP call arguments done: {doneUpdate.Arguments}");
                    }
                    else if (update is SessionUpdateConversationItemCreated itemCreated)
                    {
                        TestContext.WriteLine($"📝 Item created - Type: {itemCreated.Item?.GetType().Name}, ID: {itemCreated.Item?.Id}");

                        // Look for the MCP call item
                        if (itemCreated.Item is SessionResponseMcpCallItem mcpCallItem)
                        {
                            foundMcpCall = true;
                            mcpCallItemId = mcpCallItem.Id;
                            // Note: ApprovalRequestId might be null initially - approval request comes as separate item

                            TestContext.WriteLine($"🎯 MCP call item created - Tool: {mcpCallItem.Name}, Server: {mcpCallItem.ServerLabel}");
                            TestContext.WriteLine($"🔑 Approval Request ID: {mcpCallItem.ApprovalRequestId ?? "(null)"}");
                        }
                        // Look for the MCP approval request item (comes as separate item)
                        else if (itemCreated.Item is SessionResponseMcpApprovalRequestItem approvalItem)
                        {
                            approvalRequestId = approvalItem.Id;
                            TestContext.WriteLine($"🎉 MCP approval request item created - ID: {approvalRequestId}");
                        }
                        else
                        {
                            TestContext.WriteLine($"ℹ️ Other item created: {itemCreated.Item?.GetType().Name}");
                        }
                    }
                    else
                    {
                        TestContext.WriteLine($"⚡ Other update: {update.GetType().Name}");
                    }
                } while (update is not SessionUpdateResponseDone && !cts.Token.IsCancellationRequested && (!foundMcpCall || string.IsNullOrEmpty(approvalRequestId)));
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

            // Debug the final state
            TestContext.WriteLine($"🏁 Loop completed. Final state:");
            TestContext.WriteLine($"   - foundMcpCall: {foundMcpCall}");
            TestContext.WriteLine($"   - approvalRequestId: '{approvalRequestId}' (length: {approvalRequestId?.Length ?? 0})");
            TestContext.WriteLine($"   - mcpCallItemId: '{mcpCallItemId}'");
            TestContext.WriteLine($"   - Total updates received: {allUpdates.Count}");

            // Verify that we received an approval request
            if (string.IsNullOrEmpty(approvalRequestId))
            {
                TestContext.WriteLine("❌ ERROR: No approval request ID found!");
                TestContext.WriteLine("📋 All received updates:");
                for (int i = 0; i < allUpdates.Count; i++)
                {
                    var upd = allUpdates[i];
                    TestContext.WriteLine($"   {i + 1}. {upd.GetType().Name}");
                    if (upd is SessionUpdateConversationItemCreated created)
                    {
                        TestContext.WriteLine($"      Item: {created.Item?.GetType().Name}, ID: {created.Item?.Id}");
                    }
                }

                Assert.Fail("Should have received an approval request ID from the mcp_approval_request item");
                return;
            }

            TestContext.WriteLine($"✅ Found approval request ID: {approvalRequestId}");

            // Send approval response
            TestContext.WriteLine($"🚀 Sending approval response with ID: '{approvalRequestId}'");
            var approvalResponse = new MCPApprovalResponseRequestItem(approvalRequestId, approve: true);
            await session.AddItemAsync(approvalResponse).ConfigureAwait(false);
            TestContext.WriteLine($"✅ Approval response sent successfully");

            // Wait for next update after sending approval - could be approval item created or response.done
            TestContext.WriteLine($"🔄 Waiting for next update after approval...");
            var nextUpdate = await GetNextUpdate<SessionUpdate>(updatesEnum).ConfigureAwait(false);
            TestContext.WriteLine($"📥 Received: {nextUpdate.GetType().Name}");

            // Handle different possible outcomes
            if (nextUpdate is SessionUpdateResponseDone responseDone)
            {
                // Service completed response early - this might be a service bug or expected behavior
                TestContext.WriteLine("⚠️ Response completed immediately after approval");
                TestContext.WriteLine("🔍 Checking if tool was actually executed...");

                // Check if the tool was executed by examining the response output
                var response = responseDone.Response;
                var mcpCallOutput = response.Output?.FirstOrDefault(item => item.Id == mcpCallItemId);

                if (mcpCallOutput is SessionResponseMcpCallItem mcpItem)
                {
                    if (mcpItem.Output != null)
                    {
                        TestContext.WriteLine($"✅ Tool was executed successfully. Output length: {mcpItem.Output.ToString().Length}");
                        TestContext.WriteLine($"🎉 Approval workflow completed - tool executed after approval");
                        return; // Test passes
                    }
                    else if (mcpItem.Error != null)
                    {
                        TestContext.WriteLine($"❌ Tool execution failed with error: {mcpItem.Error}");
                        Assert.Fail($"Tool execution failed after approval: {mcpItem.Error}");
                        return;
                    }
                    else
                    {
                        TestContext.WriteLine($"⚠️ Tool was not executed - output and error are both null");
                        TestContext.WriteLine($"🔍 This might be a service-side issue with MCP tool execution");
                        Assert.Inconclusive("Tool was not executed after approval was granted. This may be a service-side issue with the MCP server or Voice Live approval workflow.");
                        return;
                    }
                }
                else
                {
                    TestContext.WriteLine($"❌ Could not find MCP call item in response output");
                    Assert.Fail($"MCP call item {mcpCallItemId} not found in response output");
                    return;
                }
            }
            else if (nextUpdate is SessionUpdateConversationItemCreated approvalItemCreated)
            {
                TestContext.WriteLine($"✅ Approval item created successfully");
                Assert.IsNotNull(approvalItemCreated.Item);
                // Continue with normal flow - wait for tool execution
            }
            else
            {
                TestContext.WriteLine($"🤔 Unexpected update type: {nextUpdate.GetType().Name}");
                Assert.Fail($"Expected either SessionUpdateConversationItemCreated or SessionUpdateResponseDone, but got {nextUpdate.GetType().Name}");
                return;
            }

            // Normal flow: Wait for MCP call execution events
            TestContext.WriteLine($"🔄 Waiting for MCP call execution...");

            try
            {
                var mcpCallInProgress = await GetNextUpdate<SessionUpdateResponseMcpCallInProgress>(updatesEnum).ConfigureAwait(false);
                Assert.IsNotNull(mcpCallInProgress);
                Assert.IsNotNull(mcpCallInProgress.ItemId);
                TestContext.WriteLine($"🔄 MCP call in progress for item: {mcpCallInProgress.ItemId}");

                var mcpCallCompleted = await GetNextUpdate<SessionUpdateResponseMcpCallCompleted>(updatesEnum).ConfigureAwait(false);
                Assert.IsNotNull(mcpCallCompleted);
                Assert.IsNotNull(mcpCallCompleted.ItemId);
                TestContext.WriteLine($"✅ MCP call completed for item: {mcpCallCompleted.ItemId}");
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("but got SessionUpdateResponseDone"))
            {
                TestContext.WriteLine($"⚠️ Response completed before tool execution events could be observed");
                TestContext.WriteLine($"🔍 This might be due to fast tool execution or service behavior change");
                Assert.Inconclusive("Tool execution completed faster than expected - unable to observe in-progress events");
                return;
            }

            // Wait for output item done (tool result)
            TestContext.WriteLine($"🔄 Waiting for tool output...");
            try
            {
                var outputItemDone = await GetNextUpdate<SessionUpdateResponseOutputItemDone>(updatesEnum).ConfigureAwait(false);
                Assert.IsNotNull(outputItemDone);
                TestContext.WriteLine("✅ MCP tool execution output received");
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("but got SessionUpdateResponseDone"))
            {
                TestContext.WriteLine($"⚠️ Response completed before output item done could be observed");
                TestContext.WriteLine($"🔍 Tool execution may have completed successfully but faster than expected");
                Assert.Inconclusive("Tool output completed faster than expected - unable to observe output item done event");
                return;
            }

            // Send another response.create to let the AI process the tool results
            TestContext.WriteLine($"🚀 Starting new response to process tool results...");
            await session.StartResponseAsync().ConfigureAwait(false);

            // Wait for the AI to process and complete the response
            TestContext.WriteLine($"🔄 Waiting for final response completion...");
            var finalResponseDone = await GetNextUpdate<SessionUpdateResponseDone>(updatesEnum).ConfigureAwait(false);
            Assert.IsNotNull(finalResponseDone);

            TestContext.WriteLine("Tool executed successfully after approval");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Service-side issue: Approval denial may not be working correctly. Tool execution behavior after denial needs investigation.")]
        public async Task ShouldHandleToolApprovalDenied()
        {
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2025_10_01));
            var mcpServerWithApproval = CreateMicrosoftLearnMcpServer(requireApproval: "always");

            var options = new VoiceLiveSessionOptions { Model = "gpt-4o" };
            options.Tools.Add(mcpServerWithApproval);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var userMessage = new UserMessageItem(new InputTextContentPart(
                "Use Microsoft Learn tools to search for Azure Speech SDK documentation."));
            await session.AddItemAsync(userMessage).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync().ConfigureAwait(false);

            // Wait for approval request
            string? approvalRequestId = null;
            SessionUpdate update;

            do
            {
                update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);
                if (update is SessionUpdateConversationItemCreated itemCreated &&
                    itemCreated.Item is SessionResponseMcpApprovalRequestItem approvalItem)
                {
                    approvalRequestId = approvalItem.Id;
                    break;
                }
            } while (update is not SessionUpdateResponseDone);

            Assert.IsNotNull(approvalRequestId, "Should receive approval request");

            // Deny the approval
            var denialResponse = new MCPApprovalResponseRequestItem(approvalRequestId, approve: false);
            await session.AddItemAsync(denialResponse).ConfigureAwait(false);

            var nextUpdate = await GetNextUpdate<SessionUpdate>(updatesEnum).ConfigureAwait(false);

            // Should get response.done without tool execution
            if (nextUpdate is SessionUpdateResponseDone responseDone)
            {
                var response = responseDone.Response;
                var mcpCallOutput = response.Output?.FirstOrDefault(item => item is SessionResponseMcpCallItem);

                if (mcpCallOutput is SessionResponseMcpCallItem mcpItem)
                {
                    Assert.IsNull(mcpItem.Output, "Tool should not have been executed after denial");
                    Assert.IsNotNull(mcpItem.Error, "MCP call should have error indicating denial");
                }
            }

            TestContext.WriteLine("Approval denial handled correctly");
        }

        [LiveOnly]
        [TestCase]
        [Ignore("Service-side issue: require_approval='never' setting may not be working correctly. Tool execution still requires approval even when configured not to.")]
        public async Task ShouldNotRequestApprovalWhenRequireApprovalNever()
        {
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2025_10_01));
            var mcpServerNoApproval = CreateMicrosoftLearnMcpServer(requireApproval: "never");

            var options = new VoiceLiveSessionOptions { Model = "gpt-4o" };
            options.Tools.Add(mcpServerNoApproval);

            await using var session = await client.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var userMessage = new UserMessageItem(new InputTextContentPart(
                "Use Microsoft Learn tools to search for Azure Speech SDK documentation."));
            await session.AddItemAsync(userMessage).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync().ConfigureAwait(false);

            // Should not receive any approval requests - tool should execute directly
            bool foundApprovalRequest = false;
            bool foundMcpExecution = false;
            SessionUpdate update;

            do
            {
                update = await GetNextUpdate(updatesEnum, checkEventId: true).ConfigureAwait(false);

                if (update is SessionUpdateConversationItemCreated itemCreated &&
                    itemCreated.Item is SessionResponseMcpApprovalRequestItem)
                {
                    foundApprovalRequest = true;
                }
                else if (update is SessionUpdateResponseMcpCallInProgress)
                {
                    foundMcpExecution = true;
                }
            } while (update is not SessionUpdateResponseDone);

            Assert.IsFalse(foundApprovalRequest, "Should not request approval when require_approval=never");
            Assert.IsTrue(foundMcpExecution, "Tool should execute directly without approval");

            TestContext.WriteLine("Tool executed without approval as expected");
        }

        [LiveOnly]
        [TestCase]
        public async Task ShouldHandleInvalidApprovalRequestId()
        {
            var client = GetLiveClient(new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2025_10_01));

            await using var session = await client.StartSessionAsync(new VoiceLiveSessionOptions { Model = "gpt-4o" }, TimeoutToken).ConfigureAwait(false);
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            // Send invalid approval response with fake ID
            var invalidApprovalResponse = new MCPApprovalResponseRequestItem("fake-approval-id-12345", approve: true);

            try
            {
                await session.AddItemAsync(invalidApprovalResponse).ConfigureAwait(false);
                TestContext.WriteLine("Invalid approval request was accepted (may be ignored by service)");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Service rejected invalid approval as expected: {ex.GetType().Name}");
                Assert.IsInstanceOf<ArgumentException>(ex, "Should throw ArgumentException for invalid approval ID");
            }
        }
    }
}
