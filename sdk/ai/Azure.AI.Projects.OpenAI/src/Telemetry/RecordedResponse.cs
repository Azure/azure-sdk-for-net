// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Projects.OpenAI.Telemetry
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
        //public List<PersistentThreadMessage>? Messages { get; set; }
        //public List<RunStep>? RunSteps { get; set; }

        //public ThreadRun? LastRun { get; set; }
        //public PersistentThreadMessage? LastMessage { get; set; }

        //public List<StreamingMessage>? StreamingMessages { get; set; } = null;

        private bool _recordContent = false;

        public RecordedResponse(bool recordContent)
        {
            _recordContent = recordContent;
            Stream = false;
        }

        //internal void AddStreamingMessage(StreamingMessage message)
        //{
        //    if (StreamingMessages == null)
        //    {
        //        StreamingMessages = new List<StreamingMessage>();
        //    }
        //    if (message != null)
        //    {
        //        StreamingMessages.Add(message);
        //        // Optionally: emit/log/trace here
        //    }
        //}
    }
}
