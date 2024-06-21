// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    // Allow for "init" pattern using property setters.

    public partial class ChatCompletionsOptions
    {
        // CUSTOM CODE NOTE:
        // Add a public default constructor to allow for an "init" pattern using property setters.

        /// <summary> Initializes a new instance of <see cref="ChatCompletionsOptions"/>. </summary>
        public ChatCompletionsOptions()
        {
            Messages = new ChangeTrackingList<ChatRequestMessage>();
            StopSequences = new ChangeTrackingList<string>();
            Tools = new ChangeTrackingList<ChatCompletionsToolDefinition>();
        }
    }
}
