// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    // Allow for "init" pattern using property setters.

    public partial class ChatCompletionsOptions
    {
        // CUSTOM CODE NOTE:
        // Add a public default constructor to allow for an "init" pattern using property setters.

        /// <summary>
        /// If specified, the model will configure which of the provided tools it can use for the chat completions response.
        /// </summary>
        public ChatCompletionsToolChoice ToolChoice { get; set; }

        // CUSTOM CODE NOTE:
        //  Retaining the generated "ToolChoice" as a renamed, internal property facilitates the change of type of
        //  ToolChoice to the custom abstraction seen above.

        [CodeGenMember("ToolChoice")]
        internal BinaryData InternalSuppressedToolChoice { get; set; }

        // CUSTOM CODE NOTE:
        //  This property is set by our specific operator methods, not by users

        /// <summary> A value indicating whether chat completions should be streamed for this request. </summary>
        internal bool? InternalShouldStreamResponse { get; set; }

        /// <summary>
        /// The collection of context messages associated with this chat completions request.
        /// Typical usage begins with a chat message for the System role that provides instructions for
        /// the behavior of the assistant, followed by alternating messages between the User and
        /// Assistant roles.
        /// Please note <see cref="ChatRequestMessage"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ChatRequestAssistantMessage"/>, <see cref="ChatRequestSystemMessage"/>, <see cref="ChatRequestToolMessage"/> and <see cref="ChatRequestUserMessage"/>.
        /// </summary>
        public IList<ChatRequestMessage> Messages { get; set; }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionsOptions"/>. </summary>
        public ChatCompletionsOptions()
        {
            Messages = new ChangeTrackingList<ChatRequestMessage>();
            StopSequences = new ChangeTrackingList<string>();
            Tools = new ChangeTrackingList<ChatCompletionsToolDefinition>();
            AdditionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}
