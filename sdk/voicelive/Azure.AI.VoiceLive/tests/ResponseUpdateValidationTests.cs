// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class ResponseUpdateValidationTests
    {
        private const string ResponseId = "response-test";

        public enum FinalOutputMismatch
        {
            ItemId,
            Arguments,
            Status,
            MissingItem
        }

        [Test]
        [Combinatorial]
        public void FunctionCallsAreValidatedByOutputIndex(
            [Values(1, 2, 3)] int outputCount,
            [Values] bool interleaved)
        {
            List<SessionUpdate> updates = CreateFunctionCallUpdates(outputCount, interleaved);

            Assert.DoesNotThrow(() => BasicConversationTests.ValidateResponseUpdates(updates, string.Empty));
        }

        [Test]
        [Combinatorial]
        public void EveryFinalOutputIsValidated(
            [Values(0, 1, 2)] int outputIndex,
            [Values] FinalOutputMismatch mismatch)
        {
            List<SessionUpdate> updates = CreateFunctionCallUpdates(3, false, outputIndex, mismatch);

            Assert.Throws<AssertionException>(() => BasicConversationTests.ValidateResponseUpdates(updates, string.Empty));
        }

        [Test]
        [Combinatorial]
        public void ArgumentDeltaCannotReferenceAnotherOutput([Values(0, 1)] int outputIndex)
        {
            List<SessionUpdate> updates = CreateFunctionCallUpdates(2, false);
            int updateIndex = updates.FindIndex(update =>
                update is SessionUpdateResponseFunctionCallArgumentsDelta delta && delta.OutputIndex == outputIndex);
            var delta = (SessionUpdateResponseFunctionCallArgumentsDelta)updates[updateIndex];
            updates[updateIndex] = new SessionUpdateResponseFunctionCallArgumentsDelta(
                delta.ResponseId, $"tool-{1 - outputIndex}", delta.OutputIndex, delta.CallId, delta.Delta);

            Assert.Throws<AssertionException>(() => BasicConversationTests.ValidateResponseUpdates(updates, string.Empty));
        }

        private static List<SessionUpdate> CreateFunctionCallUpdates(
            int outputCount,
            bool interleaved,
            int invalidOutputIndex = -1,
            FinalOutputMismatch? mismatch = null)
        {
            var updates = new List<SessionUpdate>
            {
                Deserialize(new
                {
                    type = "response.created",
                    response = new { id = ResponseId, status = "in_progress" }
                })
            };

            void AddOutput(int index) => updates.Add(Deserialize(new
            {
                type = "response.output_item.added",
                response_id = ResponseId,
                output_index = index,
                item = FunctionCallItem(index, "in_progress", string.Empty)
            }));

            void AddDelta(int index, int part)
            {
                string arguments = Arguments(index);
                int midpoint = arguments.Length / 2;
                updates.Add(new SessionUpdateResponseFunctionCallArgumentsDelta(
                    ResponseId, $"tool-{index}", index, $"call-{index}",
                    part == 0 ? arguments.Substring(0, midpoint) : arguments.Substring(midpoint)));
            }

            void CompleteOutput(int index)
            {
                updates.Add(new SessionUpdateResponseFunctionCallArgumentsDone(
                    ResponseId, $"tool-{index}", index, $"call-{index}", Arguments(index), "add_numbers"));
                updates.Add(Deserialize(new
                {
                    type = "response.output_item.done",
                    response_id = ResponseId,
                    output_index = index,
                    item = FunctionCallItem(index, "completed", Arguments(index))
                }));
            }

            if (interleaved)
            {
                for (int index = 0; index < outputCount; index++)
                {
                    AddOutput(index);
                }

                for (int part = 0; part < 2; part++)
                {
                    for (int index = 0; index < outputCount; index++)
                    {
                        AddDelta(index, part);
                    }
                }

                for (int index = outputCount - 1; index >= 0; index--)
                {
                    CompleteOutput(index);
                }
            }
            else
            {
                for (int index = 0; index < outputCount; index++)
                {
                    AddOutput(index);
                    AddDelta(index, 0);
                    AddDelta(index, 1);
                    CompleteOutput(index);
                }
            }

            object[] output = Enumerable.Range(0, outputCount)
                .Where(index => index != invalidOutputIndex || mismatch != FinalOutputMismatch.MissingItem)
                .Select(index => FunctionCallItem(
                    index,
                    index == invalidOutputIndex && mismatch == FinalOutputMismatch.Status ? "in_progress" : "completed",
                    index == invalidOutputIndex && mismatch == FinalOutputMismatch.Arguments ? "{}" : Arguments(index),
                    index == invalidOutputIndex && mismatch == FinalOutputMismatch.ItemId ? "unexpected-item" : null))
                .ToArray();
            updates.Add(Deserialize(new
            {
                type = "response.done",
                response = new
                {
                    id = ResponseId,
                    status = "completed",
                    output,
                    usage = new
                    {
                        total_tokens = 5,
                        input_tokens = 2,
                        output_tokens = 3,
                        input_token_details = new
                        {
                            audio_tokens = 0,
                            text_tokens = 2,
                            cached_tokens = 0,
                            cached_tokens_details = new { audio_tokens = 0, text_tokens = 0 }
                        },
                        output_token_details = new { audio_tokens = 0, text_tokens = 3 }
                    }
                }
            }));
            return updates;
        }

        private static object FunctionCallItem(int index, string status, string arguments, string? id = null) => new
        {
            type = "function_call",
            id = id ?? $"tool-{index}",
            call_id = $"call-{index}",
            name = "add_numbers",
            arguments,
            status
        };

        private static string Arguments(int index) => $"{{\"a\":{index},\"b\":1}}";

        private static SessionUpdate Deserialize(object value)
        {
            using var document = JsonDocument.Parse(JsonSerializer.Serialize(value));
            return SessionUpdate.DeserializeSessionUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
