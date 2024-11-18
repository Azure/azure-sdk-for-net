// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.AI.Inference.Telemetry
{
#nullable enable
    internal class RecordedResponse
    {
        public string? Model { get; set; }
        public string? Id { get; set; }
        public string?[]? FinishReasons { get; set; }
        public int? CompletionTokens { get; set; }
        public int? PromptTokens { get; set; }
        public object[]? Choices { get; set; }

        public RecordedResponse()
        {
        }

        public RecordedResponse(ChatCompletions completions, bool recordContent)
        {
            Id = completions.Id;
            Model = completions.Model;
            PromptTokens = completions.Usage?.PromptTokens;
            CompletionTokens = completions.Usage?.CompletionTokens;

            if (completions.Choices == null)
            {
                return;
            }

            FinishReasons = new string[completions.Choices.Count];
            Choices = new object[completions.Choices.Count];

            for (int i = 0; i < completions.Choices.Count; i++)
            {
                var choice = completions.Choices[i];
                var finishReason = choice.FinishReason?.ToString();
                FinishReasons[i] = finishReason;

                Choices[i] = new
                {
                    finish_reason = finishReason,
                    index = choice.Index,
                    message = new
                    {
                        content = recordContent ? choice.Message.Content : null,
                        tool_calls = GetToolCalls(choice.Message.ToolCalls, recordContent)
                    }
                };
            }
        }

        private static object? GetToolCalls(IReadOnlyList<ChatCompletionsToolCall> toolCalls, bool traceContent)
        {
            if (toolCalls == null || !toolCalls.Any())
            {
                return null;
            }

            var calls = new object[toolCalls.Count];
            for (int t = 0; t < toolCalls.Count; t++)
            {
                calls[t] = new
                {
                    id = toolCalls[t].Id,
                    type = toolCalls[t].Type.ToString(),
                    function = toolCalls[t] is ChatCompletionsToolCall funcCall ?
                        new { name = funcCall.Name, arguments = traceContent ? funcCall.Arguments : null }
                        : null
                };
            }
            return calls;
        }
    }
}
