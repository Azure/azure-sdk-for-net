// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Tests focused on function calling configuration and execution flow patterns. While a dedicated
    /// CustomerServiceBot helper is not yet present, we validate the key synthetic workflow a bot would
    /// perform after a response.function_call.arguments.done server event (emitting a function_call_output
    /// item then requesting a new response). A remaining placeholder covers assistant message tracking
    /// awaiting future helper implementation.
    /// </summary>
    [TestFixture]
    public class FunctionCallingFlowTests
    {
        private static List<JsonDocument> GetSentMessagesOfType(FakeWebSocket socket, string type)
        {
            return TestUtilities.GetMessagesOfType(socket, type);
        }

        [Test]
        public async Task ConfigureConversationSession_WithFunctionTools_RegistersAll()
        {
            var session = TestSessionFactory.CreateSessionWithFakeSocket(out var fake);

            var options = new VoiceLiveSessionOptions
            {
                Model = TestConstants.ModelName,
                Voice = new AzureStandardVoice(TestConstants.VoiceName)
            };

            // Five sample tools (names only sufficient for serialization validation)
            options.Tools.Add(new VoiceLiveFunctionDefinition("get_account_balance") { Description = "Gets the customer's account balance." });
            options.Tools.Add(new VoiceLiveFunctionDefinition("lookup_order_status") { Description = "Retrieves the status of an order." });
            options.Tools.Add(new VoiceLiveFunctionDefinition("submit_support_ticket") { Description = "Submits a support ticket." });
            options.Tools.Add(new VoiceLiveFunctionDefinition("apply_refund") { Description = "Applies a refund to an order." });
            options.Tools.Add(new VoiceLiveFunctionDefinition("escalate_case") { Description = "Escalates the current case." });

            await session.ConfigureConversationSessionAsync(options);

            var updateMessages = GetSentMessagesOfType(fake, "session.update");
            Assert.That(updateMessages, Is.Not.Empty, "Expected a session.update message containing tools.");

            using var last = updateMessages.Last();
            var sessionEl = last.RootElement.GetProperty("session");
            Assert.That(sessionEl.TryGetProperty("tools", out var toolsEl), Is.True, "tools array missing in session.update payload");
            var toolNames = toolsEl.EnumerateArray().Select(t => t.GetProperty("name").GetString()).Where(n => n != null).ToArray();
            Assert.That(toolNames.Length, Is.EqualTo(5), "Expected all 5 tools to be serialized.");
            Assert.That(toolNames, Is.EquivalentTo(new[]
            {
                "get_account_balance",
                "lookup_order_status",
                "submit_support_ticket",
                "apply_refund",
                "escalate_case"
            }));

            // Dispose other docs not used further
            foreach (var d in updateMessages.Where(d => d != last)) d.Dispose();
        }

        [Test]
        public async Task FunctionCallArgumentsDone_SyntheticFlow_SendsFunctionCallOutputThenResponseCreate()
        {
            // This synthetic test simulates the core pieces of the intended bot workflow *without* the
            // yet-to-be-added CustomerServiceBot implementation. It validates that after parsing a
            // response.function_call.arguments.done server event, a caller could: (a) execute a local
            // function, (b) send the function_call_output as a conversation item, and (c) request a
            // follow-up assistant response, ensuring ordering of emitted client events.
            var session = TestSessionFactory.CreateSessionWithFakeSocket(out var fake);

            // Pretend we received a server event instructing a function call.
            string callId = "call-123";
            string functionName = "get_account_balance";
            string argumentsJson = "{ \"accountId\": \"abc\" }";
            string eventJson = TestUtilities.BuildResponseFunctionCallArgumentsDoneEvent(functionName, callId, argumentsJson);

            // Parse to ensure the model factory path works for this event type.
            var serverEvent = SessionUpdate.DeserializeSessionUpdate(JsonDocument.Parse(eventJson).RootElement, ModelSerializationExtensions.WireOptions);
            Assert.That(serverEvent, Is.TypeOf<SessionUpdateResponseFunctionCallArgumentsDone>());
            var fDone = (SessionUpdateResponseFunctionCallArgumentsDone)serverEvent;
            Assert.That(fDone.Name, Is.EqualTo(functionName));
            Assert.That(fDone.CallId, Is.EqualTo(callId));

            // Simulate executing the function locally -> returns object { success = true, value = 42 }
            var functionResultJson = JsonSerializer.Serialize(new { success = true, value = 42 });

            // Send function_call_output conversation item referencing callId
            var functionOutputItem = new FunctionCallOutputItem(callId, functionResultJson);

            await session.AddItemAsync(functionOutputItem);

            // Request next model response
            await session.StartResponseAsync();

            // Assertions: ensure conversation.item.create precedes response.create
            var sent = fake.GetSentTextMessages().ToList();
            int createIndex = -1;
            int responseIndex = -1;
            for (int i = 0; i < sent.Count; i++)
            {
                var msg = sent[i];
                if (string.IsNullOrWhiteSpace(msg)) continue;
                try
                {
                    using var doc = JsonDocument.Parse(msg);
                    if (!doc.RootElement.TryGetProperty("type", out var tProp) || tProp.ValueKind != JsonValueKind.String) continue;
                    var typeVal = tProp.GetString();
                    if (typeVal == "conversation.item.create" && createIndex == -1)
                    {
                        createIndex = i;
                        // Validate this is the function_call_output item with our call id
                        Assert.That(doc.RootElement.TryGetProperty("item", out var itemEl), Is.True, "item missing in create payload");
                        Assert.That(itemEl.TryGetProperty("call_id", out var callIdEl), Is.True, "call_id missing in item");
                        Assert.That(callIdEl.GetString(), Is.EqualTo(callId));
                        Assert.That(itemEl.TryGetProperty("output", out var outputEl), Is.True, "output missing");
                        // Basic structural assertion on output JSON string contents
                        StringAssert.Contains("\"value\":42", outputEl.GetString());
                    }
                    if (typeVal == "response.create" && responseIndex == -1)
                    {
                        responseIndex = i;
                    }
                }
                catch (JsonException)
                {
                    // ignore non-json frame
                }
            }

            if (createIndex == -1 || responseIndex == -1)
            {
                Assert.Fail("Did not observe expected conversation.item.create and response.create messages in synthetic flow.");
            }

            Assert.That(createIndex, Is.LessThan(responseIndex), "function_call_output item must be emitted before response.create in synthetic handling flow");
        }

        [Test, Ignore("CustomerServiceBot not available; cannot track assistant message response id mapping. When available, test will assert that only tracked assistant response ids influence transcript delta handling.")]
        public async Task ResponseOutputItemAdded_AssistantMessageTracked()
        {
            // Placeholder steps for future enablement:
            // 1. Instantiate CustomerServiceBot + session with FakeWebSocket
            // 2. Inject a response.output_item.added event containing an assistant 'message' item (track its response id)
            // 3. Send a response.audio.transcript.delta event for both tracked and untracked response ids
            // 4. Use reflection to inspect internal hash set / logging side-effects to ensure only tracked id processed
            await Task.CompletedTask;
        }
    }
}
