// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents configuration options for a VoiceLive conversation session.
    /// </summary>
    /// <remarks>
    /// This class provides configuration options specifically tailored for conversational interactions
    /// with the VoiceLive service, including voice selection, tool usage, and conversation management.
    /// </remarks>
    public class ConversationSessionOptions : VoiceLiveSessionOptions
    {
        /// <summary>
        /// Gets or sets the voice configuration for the conversation.
        /// </summary>
        /// <value>
        /// The voice configuration to use for generating spoken responses. If not specified,
        /// the service will use a default voice.
        /// </value>
        public BinaryData Voice { get; set; }

        /// <summary>
        /// Gets or sets the model to use for the conversation.
        /// </summary>
        /// <value>
        /// The model identifier for conversation processing. If not specified, the service will use a default model.
        /// </value>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the instructions for the conversation assistant.
        /// </summary>
        /// <value>
        /// Instructions that guide the assistant's behavior and responses during the conversation.
        /// </value>
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the tools available to the conversation assistant.
        /// </summary>
        /// <value>
        /// A list of tools that the assistant can use during the conversation.
        /// </value>
        public IList<VoiceLiveTool> Tools { get; set; } = new List<VoiceLiveTool>();

        /// <summary>
        /// Gets or sets the tool choice strategy for the conversation.
        /// </summary>
        /// <value>
        /// Specifies how the assistant should choose which tools to use. If not specified,
        /// the assistant will automatically decide when to use tools.
        /// </value>
        public BinaryData ToolChoice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable parallel tool calling.
        /// </summary>
        /// <value>
        /// <c>true</c> to allow the assistant to call multiple tools in parallel; otherwise, <c>false</c>.
        /// Default is <c>false</c>.
        /// </value>
        public bool ParallelToolCalls { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversationSessionOptions"/> class.
        /// </summary>
        public ConversationSessionOptions() : base()
        {
        }

        /// <summary>
        /// Converts the conversation session options to a <see cref="VoiceLiveRequestSession"/> instance.
        /// </summary>
        /// <returns>A <see cref="VoiceLiveRequestSession"/> instance configured with the current options.</returns>
        internal override VoiceLiveRequestSession ToRequestSession()
        {
            var session = base.ToRequestSession();

            if (Voice != null)
            {
                session.Voice = Voice;
            }

            if (!string.IsNullOrEmpty(Model))
            {
                session.Model = Model;
            }

            if (!string.IsNullOrEmpty(Instructions))
            {
                session.Instructions = Instructions;
            }

            if (Tools != null && Tools.Count > 0)
            {
                session.Tools.Clear();
                foreach (var tool in Tools)
                {
                    session.Tools.Add(tool);
                }
            }

            if (ToolChoice != null)
            {
                session.ToolChoice = ToolChoice;
            }

            // Note: ParallelToolCalls is not supported in VoiceLiveRequestSession
            // This would need to be handled differently or added to generated model

            return session;
        }
    }
}
