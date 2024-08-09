// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
