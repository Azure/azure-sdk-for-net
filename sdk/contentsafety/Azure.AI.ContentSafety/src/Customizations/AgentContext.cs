// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentSafety
{
    public abstract partial class AgentContext
    {
        private protected IList<AgentMessage> _messages;

        /// <summary> Model messages when available; required at pre_model_call. </summary>
        [CodeGenMember("Messages")]
        public IList<AgentMessage> Messages
        {
            get => _messages ??= new ChangeTrackingList<AgentMessage>();
            private set => _messages = value;
        }

        // Construction and deserialization must share one payload value with the point-specific contexts.

        /// <summary> Initialization payload when available; required at agent_startup. </summary>
        public AgentInitialization AgentInit
        {
            get => _agentInit;
            set => _agentInit = value;
        }

        /// <summary> Input payload when available; required at input. </summary>
        public AgentInput Input
        {
            get => _input;
            set => _input = value;
        }

        /// <summary> Model metadata when available; required at both model-call points. </summary>
        public AgentModel Model
        {
            get => _model;
            set => _model = value;
        }

        /// <summary> Model response when available; required at post_model_call. </summary>
        public AgentModelResult Response
        {
            get => _response;
            set => _response = value;
        }

        /// <summary> Tool-call payload when available; required at both tool-call points. </summary>
        public AgentToolCall ToolCall
        {
            get => _toolCall;
            set => _toolCall = value;
        }

        /// <summary> Tool-result payload when available; required at post_tool_call. </summary>
        public AgentToolResult ToolResult
        {
            get => _toolResult;
            set => _toolResult = value;
        }

        /// <summary> Output payload when available; required at output. </summary>
        public AgentOutput Output
        {
            get => _output;
            set => _output = value;
        }

        /// <summary> Session summary when available; required at agent_shutdown. </summary>
        public AgentSummary Summary
        {
            get => _summary;
            set => _summary = value;
        }
    }
}
