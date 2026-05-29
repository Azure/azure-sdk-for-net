// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents.Telemetry
{
#nullable enable
    internal class RecordedResponse
    {
        public string? AgentId { get; set; }
        public string? ThreadId { get; set; }
        public string? MessageId { get; set; }
        public string? RunId { get; set; }

        public bool Stream { get; set; }
        public string? Model { get; set; }
        public string? RunStatus { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public string?[]? FinishReasons { get; set; }
        public long? CompletionTokens { get; set; }
        public long? PromptTokens { get; set; }
        public object[]? Choices { get; set; }

        private bool _recordContent = false;

        public RecordedResponse(bool recordContent)
        {
            _recordContent = recordContent;
            Stream = false;
        }
    }
}
