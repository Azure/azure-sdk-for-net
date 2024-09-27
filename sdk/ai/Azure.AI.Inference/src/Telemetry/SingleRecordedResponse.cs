// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.AI.Inference.Telemetry
{
    internal class SingleRecordedResponse : AbstractRecordedResponse
    {
        private readonly string[] _completions;
        /// <summary>
        /// Create the instance of Single recorded response.
        /// </summary>
        /// <param name="traceContent">If true the messges and function names will be recorded.</param>
        /// <param name="response"></param>
        public SingleRecordedResponse(ChatCompletions response, bool traceContent) {
            Id = response.Id;
            Model = response.Model;
            PromptTokens = response.Usage.PromptTokens;
            CompletionTokens = response.Usage.CompletionTokens;
            FinishReasons = new string[response.Choices.Count];

            _completions = new string[response.Choices.Count];

            for (int i = 0; i < response.Choices.Count; i++)
            {
                var choice = response.Choices[i];
                if (choice.FinishReason != null)
                {
                    FinishReasons[i] = choice.FinishReason.ToString();
                }
                var evt = new {
                    finish_reason = choice.FinishReason?.ToString(),
                    index = choice.Index,
                    message = new {
                        content = traceContent ? choice.Message.Content : null,
                        tool_calls = GetToolCalls(choice.Message.ToolCalls, traceContent)
                    }
                };
                _completions[i] = JsonSerializer.Serialize(evt);
            }
        }

        private object GetToolCalls(IReadOnlyList<ChatCompletionsToolCall> toolCalls, bool traceContent)
        {
            if (toolCalls == null || !toolCalls.Any())
            {
                return null;
            }

            var calls = new object[toolCalls.Count];
            for (int t = 0; t < toolCalls.Count; t++)
            {
                calls[t] = new {
                    id = toolCalls[t].Id,
                    type = toolCalls[t].Type,
                    function = toolCalls[t] is ChatCompletionsFunctionToolCall funcCall ?
                        new { name = funcCall.Name, arguments = traceContent ? funcCall.Arguments : null }
                        : null
                };
            }
            return calls;
        }

        public override string[] GetSerializedCompletions() { return _completions; }
    }
}
