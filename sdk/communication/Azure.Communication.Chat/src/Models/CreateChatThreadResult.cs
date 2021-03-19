// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.Chat
{
    /// <summary> Result of the create chat thread operation. </summary>
    public class CreateChatThreadResult
    {
        /// <summary> Initializes a new instance of CreateChatThreadResult. </summary>
        /// <param name="createChatThreadResultInternal"> Chat thread. </param>
        internal CreateChatThreadResult(CreateChatThreadResultInternal createChatThreadResultInternal)
        {
            ChatThread = new ChatThreadProperties(createChatThreadResultInternal.ChatThread);
            InvalidParticipants = createChatThreadResultInternal.InvalidParticipants;
        }

        /// <summary> Chat thread. </summary>
        public ChatThreadProperties ChatThread { get; }
        /// <summary> Errors encountered during the creation of the chat thread. </summary>
        public IReadOnlyList<ChatError> InvalidParticipants { get; }
    }
}
