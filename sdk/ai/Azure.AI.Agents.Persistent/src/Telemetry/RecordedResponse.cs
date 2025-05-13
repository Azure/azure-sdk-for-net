// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents.Persistent.Telemetry
{
#nullable enable
    internal class RecordedResponse
    {
        public string? AgentId { get; set; }
        public string? ThreadId { get; set; }
        public string? MessageId { get; set; }
        public string? RunId { get; set; }
        public string? Model { get; set; }
        public string? RunStatus { get; set; }
        public string? Id { get; set; }
        public string?[]? FinishReasons { get; set; }
        public int? CompletionTokens { get; set; }
        public int? PromptTokens { get; set; }
        public object[]? Choices { get; set; }
        public Response<PageableList<ThreadMessage>>? Messages { get; set; }
        public Response<PageableList<RunStep>>? RunSteps { get; set; }

        private bool _recordContent = false;

        public RecordedResponse(bool recordContent)
        {
            _recordContent = recordContent;
        }
    }
}
