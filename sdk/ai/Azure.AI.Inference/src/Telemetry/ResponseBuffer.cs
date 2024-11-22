// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.AI.Inference.Telemetry
{
    internal class ResponseBuffer
    {
        private readonly bool _traceContent;
        private readonly RecordedResponse _response;
        private List<Choice> _choices;

        public ResponseBuffer(bool traceContent)
        {
            _traceContent = traceContent;
            _response = new RecordedResponse();
        }

        private class Choice
        {
            private readonly bool _traceContent;
            public int Index { get; }
            public string FinishReason { get; set; }
            public StringBuilder Content { get; }
            private List<ToolCall> _toolCalls;

            public Choice(int index, bool traceContent)
            {
                Index = index;
                Content = traceContent ? new StringBuilder() : null;
                _traceContent = traceContent;
            }

            public void CreateOrUpdateToolCall(StreamingToolCallUpdate call)
            {
                if (call == null)
                {
                    return;
                }

                _toolCalls ??= new List<ToolCall>();

                StreamingFunctionToolCallUpdate functionCall = call as StreamingFunctionToolCallUpdate;
                int index = functionCall.ToolCallIndex;
                while (_toolCalls.Count <= index)
                {
                    _toolCalls.Add(null);
                }

                if (_toolCalls[index] == null)
                {
                    _toolCalls[index] = new ToolCall(functionCall?.Name, call.Id, _traceContent)
                    {
                        Type = call.Type
                    };
                }

                if (_traceContent && functionCall?.ArgumentsUpdate != null)
                {
                    _toolCalls[index].Content.Append(functionCall.ArgumentsUpdate);
                }
            }

            public void CreateOrUpdateToolCall(StreamingChatResponseToolCallUpdate call)
            {
                if (call == null)
                {
                    return;
                }

                _toolCalls ??= new List<ToolCall>();

                // it's possible to get one or more tool calls in choice.delta
                // but the StreamingChatResponseToolCallUpdate does not provide
                // tool call index even though it's available on the wire.
                // So for now let's try to correlate using tool call id and
                // when index is available optimize to use index.
                // and if Id is null, let's assume there is just one tool call
                // which is obviously wrong, but at least we can support one tool call
                // this way.

                // TODO: THIS NEEDS TO BE FIXED WHEN INDEX IS SUPPORTED
                string id = call.Id ?? _toolCalls.FirstOrDefault()?.Id;

                ToolCall callToUpdate = null;
                foreach (ToolCall c in _toolCalls)
                {
                    if (c.Id == id)
                    {
                        callToUpdate = c;
                        break;
                    }
                }

                if (callToUpdate == null)
                {
                    callToUpdate = new ToolCall(call.Function?.Name, id, _traceContent) { Type = "function" };
                    _toolCalls.Add(callToUpdate);
                }

                if (_traceContent && call.Function?.Arguments != null)
                {
                    callToUpdate.Content.Append(call.Function.Arguments);
                }
            }

            public object[] GetToolCalls()
            {
                if (_toolCalls != null && _toolCalls.Any())
                {
                    return _toolCalls.Select(c => new
                    {
                        id = c?.Id,
                        type = c?.Type,
                        function = new
                        {
                            name = c?.Name,
                            arguments = c?.Content?.ToString()
                        }
                    }).ToArray();
                }

                return null;
            }
        }

        private class ToolCall
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string Type { get; set; }
            public StringBuilder Content { get; set; }

            public ToolCall(string name, string id, bool traceContent)
            {
                Name = name;
                Id = id;
                Content = traceContent ? new StringBuilder() : null;
            }
        }

        public void Update(StreamingChatCompletionsUpdate item)
        {
            _response.Model = item.Model;
            _response.Id = item.Id;

            if (item.Choices != null)
            {
                foreach (var choiceUpdate in item.Choices)
                {
                    Choice choice = GetOrCreateChoice(choiceUpdate.Index);
                    if (choiceUpdate.FinishReason != null)
                    {
                        choice.FinishReason = choice.FinishReason?.ToString();
                    }

                    if (_traceContent && choiceUpdate.Delta?.Content != null)
                    {
                        choice.Content?.Append(choiceUpdate.Delta?.Content);
                    }

                    if (choiceUpdate.Delta?.ToolCalls != null)
                    {
                        foreach (var call in choiceUpdate.Delta?.ToolCalls)
                        {
                            choice.CreateOrUpdateToolCall(call);
                        }
                    }
                }
            }
            else
            {
                Choice choice = GetOrCreateChoice(0);
                if (item.FinishReason != null)
                {
                    choice.FinishReason = item.FinishReason?.ToString();
                }

                if (_traceContent && item.ContentUpdate != null)
                {
                    choice.Content?.Append(item.ContentUpdate);
                }

                if (item.ToolCallUpdate != null)
                {
                    choice.CreateOrUpdateToolCall(item.ToolCallUpdate);
                }
            }

            if (item.Usage != null)
            {
                _response.CompletionTokens = item.Usage.CompletionTokens;
                _response.PromptTokens = item.Usage.PromptTokens;
            }
        }

        public RecordedResponse ToResponse()
        {
            _response.FinishReasons = _choices?.Select(c => c?.FinishReason).ToArray();
            _response.Choices = GetChoices();

            return _response;
        }

        private object[] GetChoices() {
            if (_choices == null)
            {
                return null;
            }

            object[] choices = new object[_choices.Count];
            for (int c = 0; c < _choices.Count; c++)
            {
                choices[c] = new
                {
                    finish_reason = _choices[c]?.FinishReason,
                    index = c,
                    message = new
                    {
                        content = _traceContent ? _choices[c]?.Content?.ToString() : null,
                        tool_calls = _choices[c]?.GetToolCalls()
                    }
                };
            }
            return choices;
        }

        private Choice GetOrCreateChoice(int index)
        {
            _choices ??= new List<Choice>();

            while (_choices.Count <= index)
            {
                _choices.Add(null);
            }

            if (_choices[index] == null)
            {
                _choices[index] = new Choice(index, _traceContent);
            }

            return _choices[index];
        }
    }
}
