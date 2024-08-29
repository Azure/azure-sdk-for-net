using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Azure.AI.Inference.Telemetry
{
    internal class SingleRecordedResponse : AbstractRecordedResponse
    {
        private readonly string[] m_completions;
        /// <summary>
        /// Create the instance of Single recorded response.
        /// </summary>
        /// <param name="response"></param>
        public SingleRecordedResponse(ChatCompletions response) {
            Model = response.Model;
            PromptTokens = response.Usage.PromptTokens;
            CompletionTokens = response.Usage.CompletionTokens;

            m_completions = new string[response.Choices.Count];
            // Record the event for each response
            int i = 0;
            foreach (ChatChoice choice in response.Choices)
            {
                var messageDict = new Dictionary<string, object>
                {
                    {"content", choice.Message.Content}
                };
                var evt = new Dictionary<string, object> {
                    {"message", messageDict },
                    {"finish_reason", choice.FinishReason.ToString() ?? "" },
                    {"index", choice.Index},
                };
                if (choice.Message.ToolCalls != null)
                {
                    var calls = new List<Dictionary<string, string>>();
                    foreach (ChatCompletionsFunctionToolCall toolCall in choice.Message.ToolCalls)
                    {
                        calls.Add(JsonSerializer.Deserialize<Dictionary<string, string>>(toolCall.Arguments));
                    }
                    messageDict.Add("tool_calls", calls);
                }
                m_completions[i] = JsonSerializer.Serialize(evt);
                i++;
            }
        }

        public override string[] getSerializedCompletions() { return m_completions; }
    }
}
